using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class GestorCompra
    {
        private readonly CompraRepositorio _compraRepositorio;

        public GestorCompra()
        {
            _compraRepositorio = new CompraRepositorio();
        }

        public List<Compra> ObtenerComprasPorEntregar()
        {
            return _compraRepositorio.ObtenerCompras().Where(c => !c.Entregado).ToList();
        }

        public int RegistrarCompra(List<Producto> productos, string direccion)
        {
            var codigo = CodigoRandom;
            var codigoHasheado = new HasherObjeto().HashearObjeto(codigo);
            var compra = new Compra()
            {
                Productos = productos,
                Entregado = false,
                Usuario = UsuarioLogueado.Instancia.Usuario.Email
            };
            _compraRepositorio.RegistrarCompra(compra, codigoHasheado, direccion);
            return codigo;
        }

        private int CodigoRandom => new Random(DateTime.Now.Millisecond).Next(111111, 999999);
    }
}