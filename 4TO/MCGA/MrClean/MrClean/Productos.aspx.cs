using Entidades;
using Negocio;
using System;
using System.Linq;

namespace MrClean
{
    public partial class Productos : System.Web.UI.Page
    {
        private GestorProducto _gestorProducto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DigitoVerificador.EsValido)
            {
                Response.Redirect("ErrorDigitosVerificadores.aspx");
            }
            if (!UsuarioVerificador.EsOperador)
            {
                Response.Redirect("Login.aspx");
            }
            _gestorProducto = new GestorProducto();
            ListarProductos();
        }

        private void ListarProductos()
        {
            DgvProductos.DataSource = _gestorProducto.ObtenerTodos().Select(p => new ProductoCatalogo()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = $"${p.Precio}",
                RutaImagen = p.RutaImagen,
                Stock = p.Stock
            });
            DgvProductos.DataBind();
        }
    }
}