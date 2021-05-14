using System;
using System.Security.Cryptography;
using System.Text;

namespace Identity.Web.Helpers
{
    public class Utils
    {
        #region Encriptacion
        /// <summary>
        /// Metodo para encriptar
        /// </summary>
        /// <param name="stCadena">Cadena que se desea encriptar</param>
        /// <returns>Cadena con el valor encriptado</returns>
        /// ///<summary>
        public static string stEncrypt(string stCadena)
        {
            try
            {
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hashmd5;

                byte[] keyhash, buff;
                string encrypted;

                hashmd5 = new MD5CryptoServiceProvider();
                keyhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes("your_site_key"));

                hashmd5 = null;
                des = new TripleDESCryptoServiceProvider();

                des.Key = keyhash;
                des.Mode = CipherMode.ECB;

                buff = ASCIIEncoding.ASCII.GetBytes(stCadena);
                encrypted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));

                return encrypted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ///Metodo para desencriptar
        ///</summary>
        ///<param name="stCadena">Cadena que se desea desencriptar</param>
        ///<returns>Cadena con el valor desencriptado</returns>
        public static string stDecrypt(string stCadena)
        {
            try
            {
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hashmd5;
                byte[] keyhash, buff;
                string decrypted;
                hashmd5 = new MD5CryptoServiceProvider();

                keyhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes("your_site_key"));
                hashmd5 = null;
                des = new TripleDESCryptoServiceProvider();
                des.Key = keyhash;

                des.Mode = CipherMode.ECB;
                buff = Convert.FromBase64String(stCadena);

                decrypted = ASCIIEncoding.ASCII.GetString(
                des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));

                return decrypted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}