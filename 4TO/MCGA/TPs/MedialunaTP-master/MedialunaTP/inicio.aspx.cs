using BE;
using BLL;
using MedialunaTP.Webservices;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace MedialunaTP
{

    public partial class inicio : System.Web.UI.Page
    {
        Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            verficarIntegridad();

            string login = Session["Login"] == null ? "": Session["Login"].ToString();

            if (!string.IsNullOrWhiteSpace(login))
            {
                usuario = UsuariosBLL.buscar(login);
                lblUsuario.Text = usuario.ToString();
                lblUsu.Visible = true;
                lblUsuario.Visible = true;
                btnLogin.Visible = false;
                btnCrearUsuario.Visible = false;
                btnCerrar.Visible = true;
            }
            else
                usuarioNoLogueado();
            cargarTablaProductos();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("crearUsuario.aspx");
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
            btnLogin.Visible = true;
            btnCrearUsuario.Visible = true;
            btnCerrar.Visible = false;
        }

        private void verficarIntegridad()
        {
            if (WebmasterBLL.verificarAInicio())
                Response.Redirect("error.aspx");
        }

        private void cargarTablaProductos()
        {
            lblPermiso.Text = "Listado de Productos";

            WebService1 web = new WebService1();
            List<Webservices.Producto> listaWS = new List<Webservices.Producto>(web.ListarProductos());
            //List<BE.Producto> listaWS = ProductosBLL.listar();


            foreach (var item in listaWS)
            {
                TableRow fila = new TableRow();

                TableCell id = new TableCell();
                id.Text = item.id.ToString();

                TableCell descripcion = new TableCell();
                descripcion.Text = item.descripcion;

                TableCell imagen = new TableCell();
                Image img = new Image();
                img.ImageUrl = "~/imgProductos/" + item.imagen;
                img.Height = 40;
                imagen.Controls.Add(img);

                // fila.Cells.Add(id)
                fila.Cells.Add(imagen);
                fila.Cells.Add(descripcion);
                tablaProductos.Rows.Add(fila);
            }
        }
    }
}//http://converter.telerik.com/