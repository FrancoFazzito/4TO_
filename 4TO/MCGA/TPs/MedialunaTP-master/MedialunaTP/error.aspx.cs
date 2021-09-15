using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedialunaTP
{
    public partial class error : System.Web.UI.Page
    {
        Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            string login = Session["Login"] == null ? "" : Session["Login"].ToString();

            if (!string.IsNullOrWhiteSpace(login))
            {
                usuario = UsuariosBLL.buscar(login);
                lblUsuario.Text = usuario.ToString();
                lblUsu.Visible = true;
                btnLogin.Visible = false;
                lblUsuario.Visible = true;
                btnCerrar.Visible = true;
            }
            else
                usuarioNoLogueado();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            usuarioNoLogueado();
        }

        private void usuarioNoLogueado()
        {
            Session["Login"] = "";
            usuario = null;
            lblUsu.Visible = false;
            lblUsuario.Visible = false;
            btnCerrar.Visible = false;
            btnLogin.Visible = true;
        }

    }
}