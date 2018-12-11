using System;
using NaturZoo_Rheine.config;
using System.Windows.Forms;

/*
|-----------------------------------------------------------------------------
| Hashing Manager
|-----------------------------------------------------------------------------
|
| 
|
*/
namespace NaturZoo_Rheine.src.Hashing
{
    class Hashmanager : NaturZoo_Rheine.config.HashConfig
    {
        /**
         * Create Hash
         * 
         * @param String rawData
         * @return String hash
         **/
        public static String Hash(String rawData)
        {
            HashConfig Config = new HashConfig();

            switch (Config.Driver) {
                case "sha256":
                    return Sha256Hasher.Make(rawData);

                default:
                    MessageBox.Show("No Driver in HashConfig set." , "Hashing Error");
                    Environment.Exit(1);
                    return null;
            }
        }
    }
}
