using System;
using System.Windows.Forms;

namespace NaturZoo_Rheine
{
    static class Program {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region ConfigCheck
            var configChecker = new Queries.Repositories.ConfigRepository();
            var config = configChecker.GetConfig();
            #endregion

            #region Run Login Form
            var loginView = new View.LoginForm();
            //Application.Run(loginView);
            #endregion

            #region Run Main 
            if (loginView.LoginSuccess) {
                NaturZoo_Rheine.Database.Database DbContext = new Database.Database(config);
                var mainView = new View.MainForm(DbContext, loginView.Permission, config.Start_Password);
                Application.Run(mainView);
            }
            #endregion
        }
    }
}
