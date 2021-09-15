using BLL;
using System;
using System.Web.UI;

namespace MedialunaTP
{
    public partial class crearUsuario : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = Button1.ID;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("inicio.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BE.Usuario usuario = new BE.Usuario();
            usuario.login = txtUsuario.Text;
            usuario.pass = txtPass.Text;
            usuario.nombre = txtNombre.Text;
            usuario.apellido = txtApellido.Text;
            usuario.correo = txtCorreo.Text;
            var resultado = UsuariosBLL.crearUsuario(usuario);
            if (resultado == 1)
                Session["Login"] = usuario.login;
            Response.Redirect("inicio.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BE.Usuario admin = new BE.Usuario();
            admin.login = "administrador";
            admin.pass = "administrador";
            admin.nombre = "juan";
            admin.apellido = "sanchez";
            admin.correo = "juansanchez@gmail.com";
            BLL.UsuariosBLL.crearUsuario(admin);

            BE.Usuario web = new BE.Usuario();
            web.login = "webmaster";
            web.pass = "webmaster";
            web.nombre = "roberto";
            web.apellido = "piombi";
            web.correo = "robertopiombi@gmail.com";
            BLL.UsuariosBLL.crearUsuario(web);

            BE.Usuario cliente1 = new BE.Usuario();
            cliente1.login = "palermo";
            cliente1.pass = "palermo";
            cliente1.nombre = "Martin";
            cliente1.apellido = "Palermo";
            cliente1.correo = "palermo@gmail.com";
            BLL.UsuariosBLL.crearUsuario(cliente1);
        }
    }
}