using System.Collections.Generic;

namespace Negocio
{
    public class GestorDigitoVerificadorVertical
    {
        private readonly List<IGestorDigito> _gestorDigitos;

        public GestorDigitoVerificadorVertical()
        {
            _gestorDigitos = new List<IGestorDigito>()
            {
                new GestorDigitoProducto(),
                new GestorDigitoUsuario()
            };
        }

        public bool EsValido()
        {
            foreach (var gestorDigito in _gestorDigitos)
            {
                if (gestorDigito.GetErroresDigitoHorizontal().Count > 0)
                {
                    return false;
                }
                var digitosHorizontalesGuardado = string.Join("", gestorDigito.GetDigitosHorizontalesGuardados());
                var digitoVerticalGenerado = new HasherObjeto().HashearObjeto(digitosHorizontalesGuardado);
                var digitoVerticalGuardado = gestorDigito.GetDigitoVerticalGuardado();
                if (digitoVerticalGenerado != digitoVerticalGuardado)
                {
                    return false;
                }
            }
            return true;
        }
    }
}