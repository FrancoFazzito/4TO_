using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MrClean
{
    public partial class Backup : Page
    {
        private GestorBackup _gestorBackup;

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
            _gestorBackup = new GestorBackup();
        }

        protected void BtnBackup_Click(object sender, EventArgs e)
        {
            _gestorBackup.GuardarBackup();
            lblInfoBackup.ForeColor = Color.Green;
            lblInfoBackup.Text = $"Se ha guardado con exito en la ruta: {_gestorBackup.RutaBackup}";
        }
    }
}