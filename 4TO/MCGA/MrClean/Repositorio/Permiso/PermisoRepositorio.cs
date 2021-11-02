using Database;
using Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Repositorio
{
    public class PermisoRepositorio
    {
        private readonly SqlDatabase<SqlConnection> _sqlDatabase;

        public PermisoRepositorio()
        {
            _sqlDatabase = new SqlDatabase<SqlConnection>();
        }

        public List<Permiso> ObtenerPermisosPorRol(int id)
        {
            return _sqlDatabase.Query("SELECT p.Id,p.Nombre FROM Rol_permiso rp inner join Permiso p on rp.IdPermiso = p.Id where rp.IdRol = @idrol")
                               .WithParam("idrol", id)
                               .Select(row => new Permiso()
                               {
                                   Id = row.GetValue<int>("id"),
                                   Nombre = row.GetValue<string>("nombre")
                               })
                               .ToList();
        }
    }
}