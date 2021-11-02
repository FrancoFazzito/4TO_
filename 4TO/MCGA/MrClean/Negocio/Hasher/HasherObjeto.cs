using System.Security.Cryptography;
using System.Text;

namespace Negocio
{
    public class HasherObjeto
    {
        private const string Format = "x2";

        public string HashearObjeto(object objeto)
        {
            var objetoParaHashear = objeto.ToString();
            var objetoHasheado = new StringBuilder();
            foreach (var _byte in new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(objetoParaHashear.ToString())))
            {
                objetoHasheado.Append(_byte.ToString(Format));
            }
            return objetoHasheado.ToString();
        }
    }
}