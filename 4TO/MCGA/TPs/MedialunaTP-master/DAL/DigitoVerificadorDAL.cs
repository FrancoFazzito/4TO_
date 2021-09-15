using BE;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DigitoVerificadorDAL
    {
        public static List<DigitoVerificadorVertical> Listar()
        {
            var lista = new List<DigitoVerificadorVertical>();
            Acceso acceso = new Acceso();
            DataTable tabla = acceso.leer("digitoverificador_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                DigitoVerificadorVertical obj = new DigitoVerificadorVertical();
                obj.id = int.Parse(item["id"].ToString());
                obj.tabla = item["tabla"].ToString();
                obj.DVV = item["DVV"].ToString();
                obj.DVH = item["DVH"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static int baja(DigitoVerificadorVertical param)
        {
            return 0;
        }

        public static int Insertar(DigitoVerificadorVertical param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@tabla", param.tabla);
            parametros[1] = new SqlParameter("@dvv", param.DVV);
            parametros[2] = new SqlParameter("@dvh", param.DVH);
            return acceso.escribir("digitoverificador_alta", parametros);
        }

        public static int Modificar(DigitoVerificadorVertical param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@tabla", param.tabla);
            parametros[1] = new SqlParameter("@dvv", param.DVV);
            parametros[2] = new SqlParameter("@dvh", param.DVH);
            return acceso.escribir("digitoverificador_modificar", parametros);
        }

        public static DigitoVerificadorVertical Buscar(DigitoVerificadorVertical param)
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