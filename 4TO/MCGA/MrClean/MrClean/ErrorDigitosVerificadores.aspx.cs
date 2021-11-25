using Negocio;
using System;
using System.Linq;

namespace MrClean
{
    public partial class ErrorDigitosVerificadores : System.Web.UI.Page
    {
        private GestorBackup _gestorBackup;

        protected void Page_Load(object sender, EventArgs e)
        {
            _gestorBackup = new GestorBackup();
            DgvErrores.DataSource = DigitoVerificador.Errores.Select(error => new
            {
                Error = error
            });
            DgvErrores.DataBind();
        }

        protected void BtnRestaurar_Click(object sender, EventArgs e)
        {
            _gestorBackup.Restaurar();
            Response.Redirect("Default.aspx");
        }
    }
}