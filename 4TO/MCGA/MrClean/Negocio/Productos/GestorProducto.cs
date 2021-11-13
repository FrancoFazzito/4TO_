using Entidades;
using Repositorio;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Negocio
{
    public class GestorProducto
    {
        private readonly ProductoRepositorio _productoRepositorio;
        private readonly GestorDigitoProducto _gestorDigitoProducto;
        private readonly GestorBitacora _gestorBitacora;

        public GestorProducto()
        {
            _productoRepositorio = new ProductoRepositorio();
            _gestorDigitoProducto = new GestorDigitoProducto();
            _gestorBitacora = new GestorBitacora();
        }

        public List<Producto> ObtenerTodos()
        {
            return _productoRepositorio.ObtenerTodos();
        }

        public string ObtenerTodosPorXML()
        {
            var productos = _productoRepositorio.ObtenerTodos();
            var xmlDoc = new XmlDocument();
            var rootNode = xmlDoc.CreateElement("Productos");
            xmlDoc.AppendChild(rootNode);
            
            foreach (var producto in productos)
            {
                var productNode = xmlDoc.CreateElement("Producto");
                productNode.InnerText = producto.Nombre;

                var id = xmlDoc.CreateAttribute("Id");
                id.Value = producto.Id.ToString();
                productNode.Attributes.Append(id);

                var nombre = xmlDoc.CreateAttribute("Nombre");
                nombre.Value = producto.Nombre;
                productNode.Attributes.Append(nombre);

                var precio = xmlDoc.CreateAttribute("Precio");
                precio.Value = producto.Precio.ToString();
                productNode.Attributes.Append(precio);

                var rutaImagen = xmlDoc.CreateAttribute("RutaImagen");
                rutaImagen.Value = producto.RutaImagen.ToString();
                productNode.Attributes.Append(rutaImagen);

                rootNode.AppendChild(productNode);
            }

            var Filename = "C:\\Users\\Franc\\Documents\\XML\\Productos.xml";
            xmlDoc.Save(Filename);
            return Filename;
        }

        public void AltaProducto(Producto producto)
        {
            var digito = new HasherObjeto().HashearObjeto(producto);
            _productoRepositorio.AltaProducto(producto, digito);
            ActualizarDigitoVertical();
        }

        public void ActualizarDigitoVertical()
        {
            var digitosHorizontales = _gestorDigitoProducto.GetDigitosHorizontalesGuardados();
            var productoString = string.Join("", digitosHorizontales);
            var digitoVerticalProducto = new HasherObjeto().HashearObjeto(productoString);
            _productoRepositorio.ActualizarDigitoVertical(digitoVerticalProducto);
            _gestorBitacora.Registrar(new ItemBitacora($"Se ha actualizado el digito verificador vertical para los productos", TipoEvento.Message, UsuarioLogueado.Instancia.Usuario.Email));
        }

        public Producto ObtenerPorId(int id)
        {
            return _productoRepositorio.ObtenerPorId(id);
        }

        public Producto ObtenerPorNombre(string nombre)
        {
            return _productoRepositorio.ObtenerPorNombre(nombre);
        }
    }
}