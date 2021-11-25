using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MrClean
{
    public partial class Carrito : System.Web.UI.Page
    {
        private GestorProducto _gestorProducto;
        private GestorCompra _gestorCompra;
        private IEnumerable<ProductoCarrito> _productosEnCarrito;
        private IEnumerable<Producto> _productosAgregados;
        private decimal _importeTotal;

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
            if (!IsPostBack)
            {
                Session["EnvioCalculado"] = false;
            }
            _gestorCompra = new GestorCompra();
            _gestorProducto = new GestorProducto();
            _productosAgregados = _gestorProducto.ObtenerTodos().Where(producto => ObtenerCantidadProductoDelCarrito(producto) != null);
            _productosEnCarrito = GetProductosCarrito();
            _importeTotal = CalcularImporteTotal();
            DgvProductos.DataSource = _productosEnCarrito;
            DgvProductos.DataBind();
            lblPrecio.Text = _importeTotal.ToString();
        }

        private IEnumerable<ProductoCarrito> GetProductosCarrito()
        {
            return from producto in _productosAgregados
                   let cantidad = Convert.ToInt32(ObtenerCantidadProductoDelCarrito(producto))
                   select new ProductoCarrito()
                   {
                       Cantidad = cantidad,
                       Nombre = producto.Nombre,
                       Precio = $"${producto.Precio}",
                       Total = $"${cantidad * producto.Precio}"
                   };
        }

        private object ObtenerCantidadProductoDelCarrito(Producto producto)
        {
            return Session[$"{producto.Id}"];
        }

        protected void BtnCalcularEnvio_Click(object sender, EventArgs e)
        {
            var servicio = new WebServiceCostoEnvio();
            var codigoPostal = DropDownCodigosPostales.SelectedValue;
            var importe = servicio.ObtenerCostoEnvio(codigoPostal, _importeTotal);
            lblPrecioEnvio.Text = $"${importe.CostoEnvio}";
            LblPrecioFinalConEnvio.Text = $"${importe.ImporteTotal}";
            if (string.IsNullOrEmpty(TxtDireccion.Text))
            {
                Session["EnvioCalculado"] = false;
            }
            Session["EnvioCalculado"] = true;
            LblInfoEnvio.Text = string.Empty;
        }

        private decimal CalcularImporteTotal()
        {
            decimal importeTotal = 0;
            foreach (var producto in _productosAgregados)
            {
                var cantidad = Convert.ToDecimal(ObtenerCantidadProductoDelCarrito(producto));
                importeTotal += producto.Precio * cantidad;
            }
            return importeTotal;
        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["EnvioCalculado"]))
            {
                var productos = new List<Producto>();
                foreach (var producto in _productosAgregados)
                {
                    for (var i = 0; i < Convert.ToInt32(ObtenerCantidadProductoDelCarrito(producto)); i++)
                    {
                        productos.Add(producto);
                    }
                }

                var direccion = TxtDireccion.Text;
                var codigo = _gestorCompra.RegistrarCompra(productos, direccion);
                TxtCodigo.Text = codigo.ToString();
                LblnfoCompra.ForeColor = Color.Green;
                LblnfoCompra.Text = "Su compra se realizo con exito, su codigo aparece mas arriba y debera compartirlo con su repartidor";
            }
            else
            {
                LblInfoEnvio.ForeColor = Color.Red;
                LblInfoEnvio.Text = "Debe ingresar el codigo postal de envio y la direccion para poder realizar la compra";
            }
        }
    }
}