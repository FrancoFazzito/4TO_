using BE;
using DAL;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class UsuariosBLL
    {
        public static List<Usuario> listar()
        {
            return UsuariosDAL.Listar();
        }

        public static Usuario login(Usuario param)
        {
            param.pass = SeguridadBLL.getSHA1(param.pass);
            Usuario usuario = UsuariosDAL.Login(param);
            Usuario existe;
            if (usuario == null)
            {
                existe = UsuariosDAL.Buscar(param);
                if (existe != null)
                {
                    existe.intentosLogin += 1;
                    UsuariosDAL.Modificar(existe);
                    BitacoraBLL.Insertar(existe, "Login erroneo intento: " + existe.intentosLogin);
                }
                return null;
            }
            if (usuario.permiso != null)
                BitacoraBLL.Insertar(usuario, "Logueo de: " + usuario.permiso.descripcion);
            return usuario;
        }

        public static int crearUsuario(Usuario param)
        {
            param.pass = SeguridadBLL.getSHA1(param.pass);
            param.DVH = SeguridadBLL.calcularDVH(param);
            int resultado = UsuariosDAL.Insertar(param);
            if (resultado > 0)
                BitacoraBLL.Insertar(param, "Usuario creado");
            recalcularDVVertical();
            return resultado;
        }

        public static Usuario buscar(string param)
        {
            return UsuariosDAL.Buscar(param);
        }

        public static Permiso verificarPermiso(Usuario param)
        {
            return UsuariosDAL.VerificarPermiso(param);
        }

        public static int cambiarPass(Usuario param)
        {
            param.pass = SeguridadBLL.getSHA1(param.pass);
            int resultado = UsuariosDAL.cambiasPass(param);
            if (resultado > 0)
                BitacoraBLL.Insertar(param, "Cambio su contraseña");
            recalcularDV();
            return resultado;
        }

        public static string generarPass(string param)
        {
            Usuario usuario = buscar(param);
            string nueva = "No existe el usuario";
            if (usuario != null)
            {
                nueva = "hola1234";
                usuario.pass = nueva;
                cambiarPass(usuario);
            }
            return nueva;
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
                cantidadModificados += UsuariosDAL.Modificar(item);
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
            return SeguridadBLL.insertarDVVertical("Usuario", verificarDVVertical());
        }
    }
}