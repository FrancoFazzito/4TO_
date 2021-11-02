using Negocio;
using System;

namespace MrClean
{
    public partial class Bitacora : System.Web.UI.Page
    {
        private GestorBitacora _gestorBitacora;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DigitoVerificador.EsValido)
            {
                Response.Redirect("ErrorDigitosVerificadores.aspx");
            }
            if (!UsuarioVerificador.EsWebMaster)
            {
                Response.Redirect("Login.aspx");
            }
            _gestorBitacora = new GestorBitacora();
            DgvBitacora.DataSource = _gestorBitacora.GetItems();
            DgvBitacora.DataBind();
        }
    }
}