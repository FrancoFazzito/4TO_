using System;

namespace MedialunaTP
{
    public partial class administrador : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogueado(BLL.PermisosBLL.Admin());
            lblUsuario.Text = usuario.ToString();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            usuarioNoLogueado();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("alta_producto.aspx");
        }
    }
}