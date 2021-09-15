using BLL;
using System;

namespace MedialunaTP
{
    public partial class webmaster : Base
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            UsuarioLogueado(BLL.PermisosBLL.Web());
            lblUsuario.Text = usuario.ToString();

            txtResultado.Text = WebmasterBLL.verificarDVHBase(usuario);
            txtResultado.Text += WebmasterBLL.verificarDVVerticalBase(usuario);
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            usuarioNoLogueado();
        }

        protected void btnBitacora_Click(object sender, EventArgs e)
        {
            Response.Redirect("bitacora.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("backup.aspx");
        }

        protected void btnVerificarH_Click(object sender, EventArgs e)
        {
            txtResultado.Text = WebmasterBLL.verificarDVHBase(usuario);
        }

        protected void btnRecalcularH_Click(object sender, EventArgs e)
        {
            txtResultado.Text = WebmasterBLL.recalcularDVHBase(usuario);
        }

        protected void btnVerificarV_Click(object sender, EventArgs e)
        {
            txtResultado.Text = WebmasterBLL.verificarDVVerticalBase(usuario);
        }

        protected void btnRecalcularV_Click(object sender, EventArgs e)
        {
            txtResultado.Text = WebmasterBLL.recalcularDVVerticalBase(usuario);
        }
    }
}