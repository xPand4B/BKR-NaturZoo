using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NaturZoo_Rheine.src;

namespace NaturZoo_Rheine {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check if config is set up correctly
            var Checker = new ConfigCheck();

            Application.Run(new formMain());
        }
    }
}
