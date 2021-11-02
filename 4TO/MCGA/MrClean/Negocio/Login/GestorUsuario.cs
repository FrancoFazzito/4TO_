using Entidades;
using Repositorio;

namespace Negocio
{
    public class GestorUsuario
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly GestorDigitoUsuario _gestorDigitoUsuario;
        private readonly GestorPass _gestorPass;
        private readonly GestorBitacora _gestorBitacora;

        public GestorUsuario()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
            _gestorDigitoUsuario = new GestorDigitoUsuario();
            _gestorPass = new GestorPass();
            _gestorBitacora = new GestorBitacora();
        }

        public Usuario Login(string mail, string pass)
        {
            var usuario = _usuarioRepositorio.ObtenerUsuarioPorMail(mail);
            if (usuario == null)
            {
                _gestorBitacora.Registrar(new ItemBitacora($"Se ha intentado loguear sin exito el usuario: {usuario.Email}", TipoEvento.Message, mail));
                return null;
            }

            var esValido = _gestorPass.PassValida(pass, usuario.PassSalted.PassHashed, usuario.PassSalted.Salt);
            if (!esValido)
            {
                _gestorBitacora.Registrar(new ItemBitacora($"Se ha intentado loguear sin exito el usuario: {usuario.Email}", TipoEvento.Message, mail));
                return null;
            }

            UsuarioLogueado.Instancia.Usuario = usuario;
            _gestorBitacora.Registrar(new ItemBitacora($"Se ha logueado con exito el usuario: {usuario.Email}", TipoEvento.Message, mail));
            return usuario;
        }

        public void AltaUsuario(Usuario usuario)
        {
            var passHashed = _gestorPass.GenerateSaltedHash(usuario.Pass);
            var digitoVerificador = new HasherObjeto().HashearObjeto(usuario);
            _usuarioRepositorio.AltaUsuario(usuario, passHashed, digitoVerificador);
            ActualizarDigitoVertical(usuario);
            _gestorBitacora.Registrar(new ItemBitacora($"Se ha dado de alta al usuario: {usuario.Email} con rol [Cliente]", TipoEvento.Message, usuario.Email));
        }

        public void ActualizarDigitoVertical(Usuario usuario)
        {
            var digitosHorizontales = _gestorDigitoUsuario.GetDigitosHorizontalesGuardados();
            var usuarioString = string.Join("", digitosHorizontales);
            var digitoVerticalUsuario = new HasherObjeto().HashearObjeto(usuarioString);
            _usuarioRepositorio.ActualizarDigitoVertical(digitoVerticalUsuario);
            _gestorBitacora.Registrar(new ItemBitacora($"Se ha actualizado el digito verificador vertical para los usuarios", TipoEvento.Message, usuario.Email));
        }

        public void DesactivarUsuario(string mail)
        {
            _usuarioRepositorio.DesactivarUsuario(mail);
        }

        public void Logout()
        {
            UsuarioLogueado.Instancia.Usuario = null;
        }
    }
}