using Entidades;
using Negocio;
using System;
using System.Drawing;
using System.Linq;
using System.Web.UI;

namespace MrClean
{
    public partial class Catalogo : Page
    {
        private GestorProducto _gestorProducto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DigitoVerificador.EsValido)
            {
                Response.Redirect("ErrorDigitosVerificadores.aspx");
            }
            if (!UsuarioVerificador.EsCliente)
            {
                Response.Redirect("Login.aspx");
            }
            _gestorProducto = new GestorProducto();
            Listar();
        }

        private void Listar()
        {
            DgvProductos.DataSource = _gestorProducto.ObtenerTodos().Select(p => new ProductoCatalogo()
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = $"${p.Precio}",
                RutaImagen = p.RutaImagen
            });
            DgvProductos.DataBind();
        }

        protected void DgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = DgvProductos.SelectedRow;
            var nombre = fila.Cells[0].Text;
            var id = _gestorProducto.ObtenerPorNombre(nombre).Id;

            if (Session[$"{id}"] == null)
            {
                Session[$"{id}"] = 1;
            }
            else
            {
                var cantidad = Convert.ToInt32(Session[$"{id}"]);
                cantidad++;
                Session[$"{id}"] = cantidad;
            }

            LblInfoCatalogo.ForeColor = Color.Green;
            LblInfoCatalogo.Text = $"Se ha agregado el producto {nombre} al carrito";
        }
    }
}