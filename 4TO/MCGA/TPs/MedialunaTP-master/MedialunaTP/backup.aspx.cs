using BLL;
using System;

namespace MedialunaTP
{
    public partial class backup : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogueado(BLL.PermisosBLL.Web());
            lblUsuario.Text = usuario.ToString();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            usuarioNoLogueado();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            lblmensaje.Text = WebmasterBLL.hacerBackup(usuario);
        }

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {
            lblmensaje.Text = WebmasterBLL.restaurarBackup(usuario);
        }
    }
}