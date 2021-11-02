using Entidades;
using Repositorio;
using System.Collections.Generic;

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