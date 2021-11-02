using System.Collections.Generic;
using System.Linq;

namespace Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public bool Entregado { get; set; }
        public string Usuario { get; set; }
        public decimal Total { get; set; }
        public List<Producto> Productos { get; set; }

        public decimal CalcularTotal()
        {
            Total = Productos.Sum(p => p.Precio);
            return Total;
        }
    }
}