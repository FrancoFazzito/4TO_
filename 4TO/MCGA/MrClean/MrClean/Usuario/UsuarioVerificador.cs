using Negocio;

namespace MrClean
{
    public static class UsuarioVerificador
    {
        public static bool EsWebMaster
        {
            get
            {
                var usuarioLogueado = UsuarioLogueado.Instancia.Usuario;
                return usuarioLogueado != null && usuarioLogueado.Rol.Id == 1;
            }
        }

        public static bool EsCliente
        {
            get
            {
                var usuarioLogueado = UsuarioLogueado.Instancia.Usuario;
                return usuarioLogueado != null && usuarioLogueado.Rol.Id == 2;
            }
        }

        public static bool EsOperador
        {
            get
            {
                var usuarioLogueado = UsuarioLogueado.Instancia.Usuario;
                return usuarioLogueado != null && usuarioLogueado.Rol.Id == 3;
            }
        }

        public static bool EsGerente
        {
            get
            {
                var usuarioLogueado = UsuarioLogueado.Instancia.Usuario;
                return usuarioLogueado != null && usuarioLogueado.Rol.Id == 4;
            }
        }
    }
}