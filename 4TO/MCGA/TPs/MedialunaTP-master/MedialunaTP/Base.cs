using BE;
using BLL;

namespace MedialunaTP
{
    public class Base : System.Web.UI.Page
    {
        protected Usuario usuario;

        protected void UsuarioLogueado()
        {
            string login = Session["Login"].ToString();
            usuario = UsuariosBLL.buscar(login);
            if (usuario == null)
                usuarioNoLogueado();
        }

        protected void UsuarioLogueado(BE.Permiso permisoRequerido)
        {
            string login = Session["Login"].ToString();
            usuario = UsuariosBLL.buscar(login);
            if (usuario == null || !permisoRequerido.Equals(usuario.permiso))
                usuarioNoLogueado();
        }

        protected void usuarioNoLogueado()
        {
            Session["Login"] = "";
            usuario = null;
            Response.Redirect("inicio.aspx");
        }
    }
}
