using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Security.Layer.Encryption
{
    public class Envio
    {
        public string texto { get; set; }

        public Envio()
        {
            texto = "";
        }
    }

    public class Retorno
    {
        public string texto { get; set; }
        public string ASCIIencript { get; set; }
        //public string Md5encript { get; set; }
        //public string Md5Strongencript { get; set; }
        //public string Sha256encript { get; set; }

        public Retorno()
        {
            texto = "";
            ASCIIencript = "";
            //Md5encript = "";
            //Md5Strongencript = "";
            //Sha256encript = "";
        }
    }

    public class Encrypt
    {
        /// <summary>
        /// Método que invert ou desinverte uma cadeia de string        
        /// </summary>
        /// <param name="Texto">String a ser inverte ou desinverte</param>
        /// <returns></returns>
        static public string Inverter(string Texto)
        {
            //Cria a partir do texto original um array de char
            char[] ArrayChar = Texto.ToCharArray();
            //Com o array criado invertemos a ordem do mesmo
            Array.Reverse(ArrayChar);
            //Agora basta criarmos uma nova String, ja com o array invertido.
            return new string(ArrayChar);
        }

        /// <summary>
        /// Método que criptografa uma string e retorna a mesma criptografada
        /// </summary>
        /// <param name="stringToEncrypt">String a ser criptografada</param>
        /// <returns>String criptografada</returns>
        public static string EncryptString(string stringToEncrypt)
        {
            Byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);
            string encryptedString = Convert.ToBase64String(b);
            return Inverter("w37xlU1="+encryptedString+"=43v3r");
        }

        /// <summary>
        /// Método que descriptografa uma string criptografada e retorna a mesma
        /// </summary>
        /// <param name="stringToDecrypt">String a ser descriptografada</param>
        /// <returns>String descriptografada</returns>
        public static string DecryptString(string stringToDecrypt)
        {
            string stringRevert = Inverter(stringToDecrypt);
            Byte[] b = Convert.FromBase64String(stringRevert.Replace("w37xlU1=", "").Replace("=43v3r", ""));
            string decryptedString = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return decryptedString;
        }

        /// <summary>
        /// Método que criptografa uma string utilizando MD5
        /// </summary>
        /// <param name="stringToEncrypt">String a ser criptografada</param>
        /// <returns>String criptografada</returns>
        public static string EncryptStringMd5(string stringToEncrypt)
        {
            MD5 md = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(stringToEncrypt);
            byte[] hash = md.ComputeHash(inputBytes);
            StringBuilder encryptedString = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                encryptedString.Append(hash[i].ToString("X2"));
            }
            return encryptedString.ToString();
        }


        /// <summary>
        /// Método que criptografa uma string utilizando SHA256
        /// </summary>
        /// <param name="stringToEncrypt">String a ser criptografada</param>
        /// <returns>String criptografada</returns>
        public static string EncryptStringSha256(string stringToEncrypt)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringToEncrypt), 0, Encoding.UTF8.GetByteCount(stringToEncrypt));
            foreach (byte bit in crypto)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }

        /// <summary>
        /// Método de encriptação forte
        /// </summary>
        /// <param name="stringToEncrypt">String a ser criptografada</param>
        /// <returns>String criptografada</returns>
        public static string EncryptStrong(string stringToEncrypt)
        {
            return EncryptString(EncryptStringMd5(stringToEncrypt));
        }

        /// <summary>
        /// Método que gera número aleatório.
        /// </summary>
        /// <returns>Retorna o número aleaório gerado.</returns>
        public static int GenerateRandomNumber()
        {
            Random randomNumber = new Random();
            return randomNumber.Next();
        }

    }
}
