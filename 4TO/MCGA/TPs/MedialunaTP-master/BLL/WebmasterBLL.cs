using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class WebmasterBLL
    {
        public static string verificarDVHBase(Usuario param)
        {
            string resultado = verificarDVH();
            BitacoraBLL.Insertar(param, "Verificación DV Horizontal");
            return resultado;
        }

        public static string verificarDVH()
        {
            string resultado = "Inicio verificacion de la Base de datos" + Environment.NewLine;
            resultado += "Tabla Producto: ";
            resultado += ProductosBLL.verificarDVH() + Environment.NewLine;
            resultado += "Tabla Usuario: ";
            resultado += UsuariosBLL.verificarDVH() + Environment.NewLine;
            resultado += "Tabla Bitacora: ";
            resultado += BitacoraBLL.verificarDVH() + Environment.NewLine;
            resultado += "Fin.";
            return resultado;
        }

        public static string recalcularDVHBase(Usuario param)
        {
            string resultado = "Inicio de recalculo de DVH de la Base de datos" + Environment.NewLine;
            resultado += "Tabla Producto:" + Environment.NewLine;
            resultado += ProductosBLL.recalcularDV() + Environment.NewLine;
            resultado += "Tabla Usuario:" + Environment.NewLine;
            resultado += UsuariosBLL.recalcularDV() + Environment.NewLine;
            resultado += "Fin.";
            BitacoraBLL.Insertar(param, "Recalculo DV Horizontal ");
            return resultado;
        }

        public static string verificarDVVerticalBase(Usuario param)
        {
            string resultado = verificarDVVertical();
            BitacoraBLL.Insertar(param, "Verificación DV Vertical ");
            return resultado;
        }

        public static string verificarDVVertical()
        {
            string resultado = "Inicio de verificacion de DV Vertical de la Base de datos" + Environment.NewLine;

            List<DigitoVerificadorVertical> lista = DigitoVerificadorDAL.Listar();
            foreach (var item in lista)
            {
                if (item.tabla == "Usuario")
                {
                    if (item.DVV.Equals(UsuariosBLL.verificarDVVertical()))
                        resultado += "Tabla Usuario: Ok" + Environment.NewLine;
                    else
                        resultado += "Tabla Usuario: Error" + Environment.NewLine;
                }
                else if (item.tabla == "Producto")
                {
                    if (item.DVV.Equals(ProductosBLL.verificarDVVertical()))
                        resultado += "Tabla Producto: Ok" + Environment.NewLine;
                    else
                        resultado += "Tabla Producto: Error" + Environment.NewLine;
                }
                else if (item.tabla == "Bitacora")
                {
                    if (item.DVV.Equals(BitacoraBLL.verificarDVVertical()))
                        resultado += "Tabla Bitacora: Ok" + Environment.NewLine;
                    else
                        resultado += "Tabla Bitacora: Error" + Environment.NewLine;
                }
            }
            resultado += "Fin.";
            return resultado;
        }

        public static string recalcularDVVerticalBase(Usuario param)
        {
            string resultado = "Inicio de recalculo de DV Vertical de la Base de datos" + Environment.NewLine;
            resultado += "Tabla Usuario:" + Environment.NewLine;
            resultado += UsuariosBLL.recalcularDVVertical() + Environment.NewLine;
            resultado += "Tabla Producto:" + Environment.NewLine;
            resultado += ProductosBLL.recalcularDVVertical() + Environment.NewLine;
            resultado += "Tabla Bitacora:" + Environment.NewLine;
            resultado += BitacoraBLL.recalcularDVVertical() + Environment.NewLine;
            BitacoraBLL.Insertar(param, "Recalculo DV Vertical ");
            resultado += "Fin.";
            return resultado;
        }

        public static bool verificarAInicio()
        {
            string resultado = verificarDVH() + verificarDVVertical();
            return resultado.Contains("Error");
        }

        public static string hacerBackup(Usuario param)
        {
            BitacoraBLL.Insertar(param, "Se realizo Copia de seguridad");
            return backupDAL.hacerBackup();
        }

        public static string restaurarBackup(Usuario param)
        {
            string resultado = backupDAL.restaurarBackup();
            BitacoraBLL.Insertar(param, "Se Restauro Copia de seguridad");
            return resultado;
        }
    }
}