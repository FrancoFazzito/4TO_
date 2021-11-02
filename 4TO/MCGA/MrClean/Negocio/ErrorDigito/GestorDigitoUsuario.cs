using Repositorio;
using System.Collections.Generic;

namespace Negocio
{
    public class GestorDigitoUsuario : IGestorDigito
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public GestorDigitoUsuario()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public List<string> GetErroresDigitoHorizontal()
        {
            var usuarios = _usuarioRepositorio.ObtenerTodos();
            var errores = new List<string>();
            foreach (var usuario in usuarios)
            {
                var digitoHorizontal = new HasherObjeto().HashearObjeto(usuario);
                var digitoHorizontalGuardado = _usuarioRepositorio.ObtenerDigitoHorizontal(usuario.Id);
                if (digitoHorizontal != digitoHorizontalGuardado)
                {
                    errores.Add($"Error de digito en la tabla Usuario, el usuario [{usuario.Id}: {usuario.Email}]");
                }
            }
            return errores;
        }

        public List<string> GetDigitosHorizontalesGuardados()
        {
            var usuarios = _usuarioRepositorio.ObtenerTodos();
            var digitos = new List<string>();
            foreach (var usuario in usuarios)
            {
                digitos.Add(_usuarioRepositorio.ObtenerDigitoHorizontal(usuario.Id));
            }
            return digitos;
        }

        public string GetDigitoVerticalGuardado()
        {
            return _usuarioRepositorio.ObtenerDigitoVertical();
        }
    }
}