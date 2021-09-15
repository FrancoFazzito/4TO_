using BE;
using BLL;
using System;
using System.Web.Security;
using System.Web.UI;

namespace MedialunaTP
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            Page.Form.DefaultButton = btnEnviar.ID;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["Login"] = "";
            Response.Redirect("inicio.aspx");
        }

        private void irA(Permiso param)
        {
            if (param == null)
                Response.Redirect("inicio.aspx");
            else if (BLL.PermisosBLL.Admin().Equals(param))
                Response.Redirect("administrador.aspx");
            else if (BLL.PermisosBLL.Web().Equals(param))
                Response.Redirect("webmaster.aspx");
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            string nueva = UsuariosBLL.generarPass(txtUsuario.Text);
            lblNueva.Text = "Su nueva pass es: " + nueva;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.login = txtUsuario.Text;
            usuario.pass = txtPAss.Text;
            Usuario usuarioCompleto = UsuariosBLL.login(usuario);
            if (usuarioCompleto != null)
            {
                if (usuarioCompleto.intentosLogin < 3)
                {
                    Session["Login"] = usuarioCompleto.login;
                    FormsAuthentication.RedirectFromLoginPage(usuario.login, false);
                    irA(usuarioCompleto.permiso);
                }
                else
                    lblError.Text = "3 intentos erroneos, usuario bloqueado";
            }
            else
                lblError.Text = "No se encontro el usuario o la Contraseña es erronea";
        }
    }
}