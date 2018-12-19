using System;
using NaturZoo_Rheine.Models;
using NaturZoo_Rheine.Hashing.Hasher;

namespace NaturZoo_Rheine.Hashing
{
    class HashManager
    {
        public String Hash(String rawData)
        {
            string tmp = "sha256";
            switch (tmp) {
                case "sha256":
                    return Sha256Hasher.Make(rawData);

                default:
                    return null;
            }
        }
    }
}
