using System;
using System.Windows.Forms;
using NaturZoo_Rheine.src;

namespace NaturZoo_Rheine {
    /// <summary>
    ///     Provides the Login form.
    /// </summary>
    public partial class formLogin : MetroFramework.Forms.MetroForm
    {
        private Login Login;
        
        public Boolean loginSuccess { get; private set; }


        /// <summary>
        ///     Initializes a new instance of the <see cref="formLogin"/> class.
        /// </summary>
        public formLogin()
        {
            InitializeComponent();
            loginSuccess = false;
            Login = new Login();
        }


        /// <summary>
        ///     Login button click
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String email    = textLoginEmail.Text;
            String password = textLoginPassword.Text;

            if(Login.Check(email, password)) {
                loginSuccess = true;
                this.Close();
            }
            else {
                MessageBox.Show("E-Mail oder Password ungültig.", "Login Error", MessageBoxButtons.OK);

                textLoginEmail.Focus();
                textLoginPassword.Text  = "";
            }
            
        }
        
        /// <summary>
        ///     Exit button click
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
