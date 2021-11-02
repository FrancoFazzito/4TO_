using System.Collections.Generic;

namespace Negocio
{
    public class GestorErroresDigitoVerificadorHorizontal
    {
        private readonly List<IGestorDigito> _errorDigitos;

        public GestorErroresDigitoVerificadorHorizontal()
        {
            _errorDigitos = new List<IGestorDigito>()
            {
                new GestorDigitoProducto(),
                new GestorDigitoUsuario()
            };
        }

        public List<string> GetErrores()
        {
            var errores = new List<string>();
            foreach (var errorDigito in _errorDigitos)
            {
                errores.AddRange(errorDigito.GetErroresDigitoHorizontal());
            }
            return errores;
        }
    }
}