using BE;
using DAL;
using System;
using System.Security.Cryptography;

namespace BLL
{
    public class SeguridadBLL
    {
        private static string pass = "lamedialuna";

        public static string getSHA1(string param)
        {
            SHA1CryptoServiceProvider sha1Obj = new SHA1CryptoServiceProvider();
            byte[] hacerHash = System.Text.Encoding.ASCII.GetBytes(param);
            hacerHash = sha1Obj.ComputeHash(hacerHash);
            string resultado = "";
            foreach (byte b in hacerHash)
                resultado += b.ToString("x2");
            return resultado;
        }

        private static byte[] getSHA1Hash(string param)
        {
            SHA1CryptoServiceProvider sha1Obj = new SHA1CryptoServiceProvider();
            byte[] hash = System.Text.Encoding.ASCII.GetBytes(param);
            hash = sha1Obj.ComputeHash(hash);
            return hash;
        }


        public static string AES_Encrypt(string input)
        {
            System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
            System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string encrypted = "";
            try
            {
                AES.Key = getSHA1Hash(pass);
                AES.Mode = System.Security.Cryptography.CipherMode.CBC;
                System.Security.Cryptography.ICryptoTransform DESEncrypter = AES.CreateEncryptor();
                byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return encrypted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string AES_Decrypt(string input)
        {
            System.Security.Cryptography.RijndaelManaged AES = new System.Security.Cryptography.RijndaelManaged();
            System.Security.Cryptography.MD5CryptoServiceProvider Hash_AES = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string decrypted = "";
            try
            {
                AES.Key = getSHA1Hash(pass);
                AES.Mode = System.Security.Cryptography.CipherMode.ECB;
                System.Security.Cryptography.ICryptoTransform DESDecrypter = AES.CreateDecryptor();
                byte[] Buffer = Convert.FromBase64String(input);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));
                return decrypted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string calcularDVH(BE.DigitoVerificador param)
        {
            return getSHA1(param.verificar());
        }

        public static bool verificarDVH(BE.DigitoVerificador param)
        {
            string verificar = calcularDVH(param);
            return param.DVH.Equals(verificar);
        }


        public static string insertarDVVertical(string tabla, string digito)
        {
            DigitoVerificadorVertical dv = new DigitoVerificadorVertical();
            dv.tabla = tabla;
            dv.DVV = digito;
            dv.DVH = SeguridadBLL.calcularDVH(dv);
            DigitoVerificadorDAL.Modificar(dv);
            return digito;
        }
    }
}