using Entidades;
using Negocio;
using System.Collections.Generic;
using System.Web.Services;

namespace MrClean
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebServiceComprasDisponibles : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Compra> ComprasDisponibles()
        {
            return new GestorCompra().ObtenerComprasPorEntregar();
        }
    }
}