using BE;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PermisosDAL
    {
        public static Permiso buscarPermiso(int id)
        {
            Permiso obj = null;
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@id", id);
            DataTable tabla = acceso.leer("permiso_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Permiso();
                obj.id = int.Parse(item["id"].ToString());
                obj.descripcion = item["descripcion"].ToString();
            }
            return obj;
        }

        public static Permiso permisoAdmin()
        {
            return buscarPermiso(1);
        }


        public static Permiso permisoWeb()
        {
            return buscarPermiso(2);
        }
    }


}