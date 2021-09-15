using BE;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ProductosDAL
    {
        public static List<Producto> Listar()
        {
            var lista = new List<Producto>();
            Acceso acceso = new Acceso();
            DataTable tabla = acceso.leer("producto_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                Producto obj = new Producto();
                obj.id = int.Parse(item["id"].ToString());
                obj.descripcion = item["descripcion"].ToString();
                obj.imagen = item["imagen"].ToString();
                obj.DVH = item["DVH"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static int baja(Producto param)
        {
            return 0;
        }

        public static int Insertar(Producto param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@descripcion", param.descripcion);
            parametros[1] = new SqlParameter("@imagen", param.imagen);
            parametros[2] = new SqlParameter("@dvh", param.DVH);
            return acceso.escribir("producto_alta", parametros);
        }

        public static int Modificar(Producto param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@id", param.id);
            parametros[1] = new SqlParameter("@descripcion", param.descripcion);
            parametros[2] = new SqlParameter("@imagen", param.imagen);
            parametros[3] = new SqlParameter("@dvh", param.DVH);
            return acceso.escribir("producto_modificar", parametros);
        }

        public static Producto Buscar(Producto param)
        {
            var lista = Listar();
            int encontro = lista.IndexOf(param);
            if (encontro != -1)
                return lista[encontro];
            else
                return null;
        }
    }
}