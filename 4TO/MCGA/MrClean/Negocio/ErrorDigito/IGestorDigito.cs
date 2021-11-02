using System.Collections.Generic;

namespace Negocio
{
    public interface IGestorDigito
    {
        List<string> GetDigitosHorizontalesGuardados();

        string GetDigitoVerticalGuardado();

        List<string> GetErroresDigitoHorizontal();
    }
}