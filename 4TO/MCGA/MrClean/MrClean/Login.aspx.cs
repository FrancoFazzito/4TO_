using Entidades;
using Negocio;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace MrClean
{
    public partial class About : Page
    {
        private readonly GestorUsuario _gestorLogin = new GestorUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DigitoVerificador.EsValido)
            {
                Response.Redirect("ErrorDigitosVerificadores.aspx");
            }
            ActualizarBtnLogout();
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            var mail = TxtEmail.Text;
            var pass = TxtClave.Text;

            var usuario = _gestorLogin.Login(mail, pass);
            if (usuario == null)
            {
                SetLabelInfo(Color.Red, "E-mail o contraseña incorrecta");
                return;
            }

            SetVariableSesionUsuario(usuario);
            SetLabelInfo(Color.Green, $"Bienvenido {usuario.Email} con rol {usuario.Rol.Nombre}");
        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            var mail = TxtEmail.Text;
            var pass = TxtClave.Text;

            if (string.IsNullOrWhiteSpace(mail) && string.IsNullOrWhiteSpace(pass))
            {
                SetLabelInfo(Color.Red, "Ninguno de los campos pueden estar vacios");
                return;
            }

            var regex = new Regex(@"^(?=.{7,})(?=.*[a-z])(?=.*[A-Z]).*$");
            var passValida = regex.IsMatch(pass);
            if (!passValida)
            {
                SetLabelInfo(Color.Red, "la contraseña debe tener: 7 caracteres - una minuscula - una mayuscula");
                return;
            }

            var cliente = new Usuario()
            {
                Email = mail,
                Pass = pass,
                Rol = new Rol()
                {
                    Nombre = "cliente",
                    Id = 2
                }
            };
            _gestorLogin.AltaUsuario(cliente);
            SetLabelInfo(Color.Green, $"{mail} registrado con exito");
        }

        private void SetLabelInfo(Color color, string info)
        {
            lblInfoLogin.ForeColor = color;
            lblInfoLogin.Text = info;
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            var email = UsuarioLogueado.Instancia.Usuario.Email;
            _gestorLogin.Logout();
            SetVariableSesionUsuario(null);
            SetLabelInfo(Color.Green, $"Se ha deslogueado {email} con exito");
        }

        private void SetVariableSesionUsuario(Usuario usuario)
        {
            Session["Usuario"] = usuario;
            ActualizarBtnLogout();
        }

        private void ActualizarBtnLogout()
        {
            BtnCerrarSesion.Enabled = Session["Usuario"] != null;
        }
    }
}