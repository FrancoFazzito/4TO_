using Negocio;
using System.Collections.Generic;

namespace MrClean
{
    public class DigitoVerificador
    {
        public static bool EsValido => new GestorDigitoVerificadorVertical().EsValido();

        public static List<string> Errores => new GestorErroresDigitoVerificadorHorizontal().GetErrores();
    }
}