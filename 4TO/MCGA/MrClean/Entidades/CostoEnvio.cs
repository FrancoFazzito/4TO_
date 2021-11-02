namespace Entidades
{
    public class CostoEnvio
    {
        public CostoEnvio(decimal precio, decimal precioDeBonificacion)
        {
            Precio = precio;
            PrecioDeBonificacion = precioDeBonificacion;
        }

        public decimal Precio { get; }

        public decimal PrecioDeBonificacion { get; }
    }
}