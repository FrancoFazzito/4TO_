using System;

namespace MedialunaTP
{
    public partial class alta_producto : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogueado(BLL.PermisosBLL.Admin());
            lblUsuario.Text = usuario.ToString();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("administrador.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            BE.Producto obj = new BE.Producto();
            obj.descripcion = txtDesc.Text;
            obj.imagen = txtImg.Text;
            BLL.ProductosBLL.insertarProducto(usuario, obj);
            Response.Redirect("administrador.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            usuarioNoLogueado();
        }
    }
}