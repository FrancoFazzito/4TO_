using Database;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio
{
    public class RolRepositorio : SqlDbReadonly<Rol>
    {
        private readonly PermisoRepositorio _permisoRepositorio;

        public RolRepositorio()
        {
            _permisoRepositorio = new PermisoRepositorio();
        }

        public List<Rol> ObtenerTodos()
        {
            return GetAll().ToList();
        }

        protected override string SelectAllQuery => "SELECT * FROM Rol";

        protected override Func<DatabaseRow, Rol> NewRow => row => new Rol()
        {
            Id = row.GetValue<int>("Id"),
            Nombre = row.GetValue<string>("Nombre"),
            Permisos = _permisoRepositorio.ObtenerPermisosPorRol(row.GetValue<int>("Id"))
        };
    }
}