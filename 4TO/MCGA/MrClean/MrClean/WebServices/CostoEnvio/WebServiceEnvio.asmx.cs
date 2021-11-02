using System.Web.Services;

namespace MrClean
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebServiceCostoEnvio : WebService
    {
        [WebMethod]
        public Respuesta ObtenerCostoEnvio(string codigoPostal, decimal importe)
        {
            var calculadorCosto = new CalculadorCostoEnvio();
            var costoEnvio = calculadorCosto.ObtenerCostoEnvio(codigoPostal, importe);
            var importeTotal = importe + costoEnvio;
            return new Respuesta()
            {
                ImporteTotal = importeTotal,
                CostoEnvio = costoEnvio
            };
        }
    }
}