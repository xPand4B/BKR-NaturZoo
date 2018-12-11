using System;
using System.Text;
using System.Security.Cryptography;

/*
|-----------------------------------------------------------------------------
| SHA256 Hasher
|-----------------------------------------------------------------------------
|
| This class is creating a SHA256 hashed string.
|
*/
namespace NaturZoo_Rheine.src.Hashing
{
    class Sha256Hasher
    {
        /**
         * Create Hash
         * 
         * @param String rawData
         * @return String HashValue
         **/
        public static String Make(String rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create()) {
                // ComputeHash - returns byte array  
                Byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
