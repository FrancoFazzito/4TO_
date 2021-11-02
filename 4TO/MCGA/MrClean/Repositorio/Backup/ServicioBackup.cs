using Database;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Repositorio
{
    public class ServicioBackup
    {
        private readonly string _ruta = ConfigurationManager.AppSettings["RutaBackup"];
        private readonly SqlDatabase<SqlConnection> _database;

        public ServicioBackup()
        {
            _database = new SqlDatabase<SqlConnection>();
        }

        public void Backup()
        {
            File.Delete(RutaBackup);
            _database.NonQuery("backup database [MrClean] to disk = @ruta")
                     .WithParam("ruta", RutaBackup)
                     .Execute();
        }

        public void Restaurar()
        {
            var stringConexion = ConfigurationManager.ConnectionStrings["conexionMaster"].ConnectionString;
            var connection = new SqlConnection(stringConexion);
            connection.Open();

            var command = new SqlCommand("alter database [MrClean] set offline with rollback immediate", connection);
            command.ExecuteNonQuery();

            command = new SqlCommand("restore database [MrClean] from disk = @ruta with replace", connection);
            command.Parameters.AddWithValue("ruta", RutaBackup);
            command.ExecuteNonQuery();

            command = new SqlCommand("alter database [MrClean] set online", connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public string RutaBackup => _ruta + "MrClean.bak";
    }
}