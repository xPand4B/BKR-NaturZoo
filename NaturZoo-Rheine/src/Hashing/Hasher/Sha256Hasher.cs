using System;
using System.Text;
using System.Security.Cryptography;

namespace NaturZoo_Rheine.src.Hashing.Hasher {
    /// <summary>
    ///     Provides the algorithm for SHA256.
    /// </summary>
    class Sha256Hasher
    {
        /// <summary>
        ///     Created and get SHA256 hashed <see cref="String"/>.
        /// </summary>
        /// <param name="rawData">The <see cref="String"/> that should be hashed.</param>
        /// <returns>
        ///     SHA256 hashed <seealso cref="String"/>.
        /// </returns>
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
