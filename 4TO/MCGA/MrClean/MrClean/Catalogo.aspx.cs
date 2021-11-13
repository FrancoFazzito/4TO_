using Entidades;
using Negocio;
using System;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Xml;

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
            ListarProductos();
        }

        private void ListarProductos()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(_gestorProducto.ObtenerTodosPorXML());
            var productos = from XmlNode producto in xmlDocument.ChildNodes[0].ChildNodes
                            select new Producto()
                            {
                                Id = int.Parse(producto.Attributes["Id"].Value),
                                Nombre = producto.Attributes["Nombre"].Value,
                                Precio = decimal.Parse(producto.Attributes["Precio"].Value),
                                RutaImagen = producto.Attributes["RutaImagen"].Value
                            };

            DgvProductos.DataSource = productos.Select(p => new ProductoCatalogo()
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