using Entidades;

namespace Negocio
{
    public class UsuarioLogueado
    {
        private static UsuarioLogueado instancia;

        private UsuarioLogueado()
        {
        }

        public static UsuarioLogueado Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new UsuarioLogueado();
                }
                return instancia;
            }
        }

        public static void Reset()
        {
            instancia = null;
        }

        public Usuario Usuario { get; set; }
    }
}