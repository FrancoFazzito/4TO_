using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BitacoraDAL
    {
        public static List<Bitacora> Listar()
        {
            var lista = new List<Bitacora>();
            Acceso acceso = new Acceso();
            DataTable tabla = acceso.leer("bitacora_leer", null/* TODO Change to default(_) if this is not a reference type */);
            foreach (DataRow item in tabla.Rows)
            {
                Bitacora obj = new Bitacora();
                obj.id = int.Parse(item["id"].ToString());
                obj.usuario = UsuariosDAL.Buscar(item["usuario"].ToString());
                obj.accion = item["accion"].ToString();
                obj.fecha = DateTime.Parse(item["fecha"].ToString());
                obj.DVH = item["DVH"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static int Insertar(Bitacora param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("@usuario", param.usuario.login);
            parametros[1] = new SqlParameter("@accion", param.accion);
            SqlParameter paramFecha = new SqlParameter("@fecha", SqlDbType.DateTime);
            paramFecha.Value = param.fecha;
            parametros[2] = paramFecha;
            parametros[3] = new SqlParameter("@dvh", param.DVH);
            return acceso.escribir("bitacora_alta", parametros);
        }

        public static Bitacora Buscar(Bitacora param)
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