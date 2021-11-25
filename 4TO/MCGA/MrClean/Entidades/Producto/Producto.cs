namespace Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string RutaImagen { get; set; }
        public int Stock { get; set; }
        public override string ToString()
        {
            return $"{Nombre}{Precio}{RutaImagen}";
        }
    }
}