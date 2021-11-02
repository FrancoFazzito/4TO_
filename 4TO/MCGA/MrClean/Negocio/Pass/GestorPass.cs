using Entidades;
using System;
using System.Security.Cryptography;

namespace Negocio
{
    public class GestorPass
    {
        public HashSalt GenerateSaltedHash(string pass)
        {
            var salt = new byte[64];
            new RNGCryptoServiceProvider().GetNonZeroBytes(salt);
            return new HashSalt
            {
                PassHashed = Convert.ToBase64String(ObtenerBytesDerivados(pass, salt).GetBytes(256)),
                Salt = Convert.ToBase64String(salt)
            };
        }

        public bool PassValida(string passIngresada, string usuarioHash, string usuarioSalt)
        {
            var saltBytes = Convert.FromBase64String(usuarioSalt);
            var DeriveBytes = ObtenerBytesDerivados(passIngresada, saltBytes);
            var hash = Convert.ToBase64String(DeriveBytes.GetBytes(256));
            return hash == usuarioHash;
        }

        private Rfc2898DeriveBytes ObtenerBytesDerivados(string enteredPassword, byte[] saltBytes)
        {
            return new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000, HashAlgorithmName.SHA256);
        }
    }
}