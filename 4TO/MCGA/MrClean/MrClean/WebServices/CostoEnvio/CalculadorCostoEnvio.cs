using Entidades;
using System.Collections.Generic;

namespace MrClean
{
    public class CalculadorCostoEnvio
    {
        private readonly Dictionary<string, CostoEnvio> codigoPostalEnvio = new Dictionary<string, CostoEnvio>()
        {
            { "B1650", new CostoEnvio(500, 2500) },
            { "B5000", new CostoEnvio(750, 3000) },
            { "C1004", new CostoEnvio(300, 1500) }
        };

        public decimal ObtenerCostoEnvio(string codigoPostal, decimal importe)
        {
            var envio = codigoPostalEnvio[codigoPostal];
            return importe >= envio.PrecioDeBonificacion ? 0 : envio.Precio;
        }
    }
}