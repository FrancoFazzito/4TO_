using BE;
using DAL;

namespace BLL
{
    public class PermisosBLL
    {
        private static Permiso _permisoAdmin;
        private static Permiso _permisoWeb;

        public static Permiso Admin()
        {
            if (_permisoAdmin == null)
                _permisoAdmin = PermisosDAL.permisoAdmin();
            return _permisoAdmin;
        }

        public static Permiso Web()
        {
            if (_permisoWeb == null)
                _permisoWeb = PermisosDAL.permisoWeb();
            return _permisoWeb;
        }
    }

}