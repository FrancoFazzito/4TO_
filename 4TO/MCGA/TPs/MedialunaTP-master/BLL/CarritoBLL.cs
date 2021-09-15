using BE;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class CarritoBLL
    {
        private List<Item> _listaProductos = new List<Item>();

        public static List<Panaderia> listarPanaderias()
        {
            return PanaderiasDAL.Listar();
        }

        public int confirmarCompra(Pedidos param)
        {
            return 0;
        }

        public Pedidos armarPedido(Usuario usuario)
        {
            Pedidos pedido = new Pedidos();
            pedido.usuario = usuario;
            pedido.items = _listaProductos;
            pedido.panaderia = ubicarPanaderiaCercana();
            return pedido;
        }

        public void agregarItemCarrito(Producto producto, float precio, int cantidad)
        {
            var item = new Item();
            item.producto = producto;
            item.cantidad = cantidad;
            item.precio = precio;
            _listaProductos.Add(item);
        }

        private Panaderia ubicarPanaderiaCercana()
        {
            // Temporal
            Panaderia pan = new Panaderia();
            pan.nombre = "Panaderia 1";
            pan.ubicacion = "1";

            return PanaderiasDAL.Buscar(pan);
        }
    }
}