using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Acceso
    {
        protected SqlConnection conexion;

        public Acceso()
        {
            conexion = new SqlConnection(@"INITIAL CATALOG=Medialunas; DATA SOURCE=.\SQL_UAI; INTEGRATED SECURITY= SSPI");
        }

        public void abrir()
        {
            conexion.Open();
        }

        public void cerrar()
        {
            conexion.Close();
        }

        public DataTable leer(string nombre, SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            abrir();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(nombre, conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (parametros != null)
            {
                adapter.SelectCommand.Parameters.AddRange(parametros);
            }
            adapter.Fill(tabla);
            cerrar();
            return tabla;
        }

        public int escribir(string nombre, SqlParameter[] parametros)
        {
            int filas = 0;
            abrir();
            SqlCommand cmd = new SqlCommand(nombre, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros);
            }
            filas = cmd.ExecuteNonQuery();
            cerrar();
            return filas;
        }

        public int ejecutarSQL(string nombre, SqlParameter[] parametros)
        {
            int filas = 0;
            SqlCommand cmd = new SqlCommand(nombre, conexion);
            cmd.CommandType = CommandType.Text;
            if (parametros != null)
            {
                cmd.Parameters.AddRange(parametros);
            }
            filas = cmd.ExecuteNonQuery();
            return filas;
        }
    }
}