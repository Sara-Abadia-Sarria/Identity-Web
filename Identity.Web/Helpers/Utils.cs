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
       
                SHA256CryptoServiceProvider hashsha2;

                byte[] keyhash, buff;
                string encrypted;

              
                hashsha2 = new SHA256CryptoServiceProvider();

                keyhash = hashsha2.ComputeHash(ASCIIEncoding.ASCII.GetBytes("your_site_key"));

               
                hashsha2 = null;
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
             
                SHA256CryptoServiceProvider hashsha2;
                byte[] keyhash, buff;
                string decrypted;
           
                hashsha2 = new SHA256CryptoServiceProvider();
         
                keyhash = hashsha2.ComputeHash(ASCIIEncoding.ASCII.GetBytes("your_site_key"));
            
                hashsha2 = null;
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
