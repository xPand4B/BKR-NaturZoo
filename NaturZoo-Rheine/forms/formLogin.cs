using System;
using System.Windows.Forms;
using NaturZoo_Rheine.src;

namespace NaturZoo_Rheine {
    public partial class formLogin : MetroFramework.Forms.MetroForm
    {
        /**
         * @var Login Login
         **/
        private Login Login;
        /**
         * @var Boolean loginSuccess
         **/
        public Boolean loginSuccess { get; private set; }


        /**
         * Constructor
         **/
        public formLogin()
        {
            InitializeComponent();
            loginSuccess = false;
            Login = new Login();
        }

        
        /**
         * Login Click
         * 
         * @param object sender
         * @param EventArgs e
         * @return void
         **/
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

        /**
         * Exit Click
         * 
         * @param object sender
         * @param EventArgs e
         * @return void
         */ 
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
