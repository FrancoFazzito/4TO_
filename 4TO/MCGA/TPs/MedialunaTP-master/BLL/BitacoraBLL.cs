using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace BLL
{
    public class BitacoraBLL
    {
        public static List<BE.Bitacora> listar()
        {
            return BitacoraDAL.Listar();
        }

        public static int Insertar(BE.Bitacora param)
        {
            param.fecha = DateTime.Now;
            param.DVH = SeguridadBLL.calcularDVH(param);
            int resultado = BitacoraDAL.Insertar(param);
            recalcularDVVertical();
            return resultado;
        }

        public static int Insertar(Usuario usuario, string accion)
        {
            Bitacora bi = new Bitacora();
            bi.usuario = usuario;
            bi.accion = accion;
            return Insertar(bi);
        }

        public static string verificarDVH()
        {
            string resultado = "";
            foreach (var item in listar())
            {
                if (!SeguridadBLL.verificarDVH(item))
                    resultado += "Error en el registro: " + item.id + Environment.NewLine;
            }
            if (string.IsNullOrWhiteSpace(resultado))
                return "Ok";
            return resultado;
        }

        public static string verificarDVVertical()
        {
            string digito = "";
            foreach (var item in listar())
                digito += item.DVH;
            return SeguridadBLL.getSHA1(digito);
        }

        public static string recalcularDVVertical()
        {
            return SeguridadBLL.insertarDVVertical("Bitacora", verificarDVVertical());
        }
    }
}