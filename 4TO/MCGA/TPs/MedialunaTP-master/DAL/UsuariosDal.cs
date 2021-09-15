using BE;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuariosDAL
    {
        public static List<Usuario> Listar()
        {
            var lista = new List<Usuario>();

            Acceso acceso = new Acceso();
            DataTable tabla = acceso.leer("usuario_leer", null);
            foreach (DataRow item in tabla.Rows)
            {
                Usuario obj = new Usuario();
                obj.id = int.Parse(item["id"].ToString());
                obj.login = item["login"].ToString();
                obj.pass = item["pass"].ToString();
                obj.nombre = item["nombre"].ToString();
                obj.apellido = item["apellido"].ToString();
                obj.correo = item["correo"].ToString();
                obj.intentosLogin = int.Parse(item["intentos"].ToString());
                obj.habilitado = int.Parse(item["habilitado"].ToString()) == 0;
                obj.DVH = item["DVH"].ToString();
                lista.Add(obj);
            }
            return lista;
        }

        public static int baja(Usuario param)
        {
            return 0;
        }

        public static int Insertar(Usuario param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter("@login", param.login);
            parametros[1] = new SqlParameter("@pass", param.pass);
            parametros[2] = new SqlParameter("@nombre", param.nombre);
            parametros[3] = new SqlParameter("@apellido", param.apellido);
            parametros[4] = new SqlParameter("@correo", param.correo);
            parametros[5] = new SqlParameter("@dvh", param.DVH);
            return acceso.escribir("usuario_alta", parametros);
        }

        public static int cambiasPass(Usuario param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@login", param.login);
            parametros[1] = new SqlParameter("@pass", param.pass);
            return acceso.escribir("usuario_modificarPass", parametros);
        }

        public static int Modificar(Usuario param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = new SqlParameter("@login", param.login);
            parametros[1] = new SqlParameter("@pass", param.pass);
            parametros[2] = new SqlParameter("@nombre", param.nombre);
            parametros[3] = new SqlParameter("@apellido", param.apellido);
            parametros[4] = new SqlParameter("@correo", param.correo);
            parametros[5] = new SqlParameter("@intentos", param.intentosLogin);
            parametros[6] = new SqlParameter("@habilitado", param.habilitado);
            parametros[7] = new SqlParameter("@dvh", param.DVH);
            return acceso.escribir("usuario_modificar", parametros);
        }

        public static Usuario Login(Usuario param)
        {
            Usuario obj = null;
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@login", param.login);
            parametros[1] = new SqlParameter("@pass", param.pass);
            DataTable tabla = acceso.leer("usuario_login", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Usuario();
                obj.id = int.Parse(item["id"].ToString());
                obj.login = item["login"].ToString();
                obj.pass = item["pass"].ToString();
                obj.nombre = item["nombre"].ToString();
                obj.apellido = item["apellido"].ToString();
                obj.correo = item["correo"].ToString();
                obj.intentosLogin = int.Parse(item["intentos"].ToString());
                obj.habilitado = int.Parse(item["habilitado"].ToString()) == 0;
                obj.DVH = item["DVH"].ToString();
            }
            if (obj != null)
            {
                var permiso = VerificarPermiso(obj);
                if (permiso != null)
                    obj.permiso = permiso;
                return obj;
            }
            else
                return null;
        }

        public static Usuario Buscar(Usuario param)
        {
            Usuario obj = null;
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@login", param.login);
            DataTable tabla = acceso.leer("usuario_buscar", parametros);
            foreach (DataRow item in tabla.Rows)
            {
                obj = new Usuario();
                obj.id = int.Parse(item["id"].ToString());
                obj.login = item["login"].ToString();
                obj.pass = item["pass"].ToString();
                obj.nombre = item["nombre"].ToString();
                obj.apellido = item["apellido"].ToString();
                obj.correo = item["correo"].ToString();
                obj.intentosLogin = int.Parse(item["intentos"].ToString());
                obj.habilitado = int.Parse(item["habilitado"].ToString()) == 0;
                obj.DVH = item["DVH"].ToString();
            }
            if (obj != null)
            {
                obj.permiso = VerificarPermiso(obj);
                return obj;
            }
            else
                return null;
        }

        public static Usuario Buscar(string param)
        {
            var obj = new Usuario();
            obj.login = param;
            return Buscar(obj);
        }

        public static Permiso VerificarPermiso(Usuario param)
        {
            Acceso acceso = new Acceso();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@usuario", param.login);
            DataTable tabla = acceso.leer("usuario_permisos", parametros);
            foreach (DataRow item in tabla.Rows)
                return PermisosDAL.buscarPermiso(int.Parse(item["permiso"].ToString()));
            return null;
        }
    }
}