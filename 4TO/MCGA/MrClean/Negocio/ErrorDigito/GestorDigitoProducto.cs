using Repositorio;
using System.Collections.Generic;

namespace Negocio
{
    public class GestorDigitoProducto : IGestorDigito
    {
        private readonly ProductoRepositorio _productoRepositorio;

        public GestorDigitoProducto()
        {
            _productoRepositorio = new ProductoRepositorio();
        }

        public List<string> GetErroresDigitoHorizontal()
        {
            var productos = _productoRepositorio.ObtenerTodos();
            var errores = new List<string>();
            foreach (var producto in productos)
            {
                var digitoHorizontal = new HasherObjeto().HashearObjeto(producto);
                var digitoHorizontalGuardado = _productoRepositorio.ObtenerDigitoHorizontal(producto.Id);
                if (digitoHorizontal != digitoHorizontalGuardado)
                {
                    errores.Add($"Error de digito en la tabla Producto, el producto [{producto.Id}: {producto.Nombre}]");
                }
            }

            return errores;
        }

        public List<string> GetDigitosHorizontalesGuardados()
        {
            var productos = _productoRepositorio.ObtenerTodos();
            var digitos = new List<string>();
            foreach (var producto in productos)
            {
                var digitoHorizontal = _productoRepositorio.ObtenerDigitoHorizontal(producto.Id);
                digitos.Add(digitoHorizontal);
            }
            return digitos;
        }

        public string GetDigitoVerticalGuardado()
        {
            return _productoRepositorio.ObtenerDigitoVertical();
        }
    }
}