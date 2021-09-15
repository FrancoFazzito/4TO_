using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ProductosBLL
    {
        public static List<Producto> listar()
        {
            return ProductosDAL.Listar();
        }

        public static int insertarProducto(Usuario usuario, Producto param)
        {
            param.DVH = SeguridadBLL.calcularDVH(param);
            int resultado = ProductosDAL.Insertar(param);
            if (resultado > 0)
                BitacoraBLL.Insertar(usuario, "Producto Ins: " + param.descripcion);
            recalcularDVVertical();
            return resultado;
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

        public static string recalcularDV()
        {
            int cantidadModificados = 0;
            foreach (var item in listar())
            {
                item.DVH = SeguridadBLL.calcularDVH(item);
                cantidadModificados += ProductosDAL.Modificar(item);
            }
            return cantidadModificados.ToString();
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
            return SeguridadBLL.insertarDVVertical("Producto", verificarDVVertical());
        }
    }
}