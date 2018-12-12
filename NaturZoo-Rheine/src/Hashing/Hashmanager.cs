using System;
using NaturZoo_Rheine.config;

namespace NaturZoo_Rheine.src.Hashing {
    /// <summary>
    ///     Provides the Hasher, based on the selected driver inside the <see cref="HashConfig"/>.
    /// </summary>
    class Hashmanager
    {
        /// <summary>
        ///     Created and get hashed <see cref="String"/>, based on the selected driver inside the <seealso cref="HashConfig"/>.
        /// </summary>
        /// <param name="rawData">The <see cref="String"/> that should be hashed.</param>
        /// <returns>
        ///     Hashed <seealso cref="String"/>, based on the selected driver inside the <seealso cref="HashConfig"/>.
        /// </returns>
        public static String Hash(String rawData)
        {
            HashConfig Config = new HashConfig();

            switch (Config.Driver) {
                case "sha256":
                    return Hasher.Sha256Hasher.Make(rawData);

                default:
                    return null;
            }
        }
    }
}
