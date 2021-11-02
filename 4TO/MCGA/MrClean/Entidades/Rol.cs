using System.Collections.Generic;

namespace Entidades
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<Permiso> Permisos { get; set; }
    }
}