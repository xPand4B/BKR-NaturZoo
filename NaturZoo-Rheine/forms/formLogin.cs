using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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
         * 
         * @return void
         **/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String email = textLoginEmail.Text;
            String password = textLoginPassword.Text;

            if(Login.Check(email, password)) {
                loginSuccess = true;
                this.Close();
            }
            else {
                MessageBox.Show("E-Mail oder Password ungültig.", "Login Error", MessageBoxButtons.OK);
                textLoginEmail.Focus();
                textLoginEmail.Text = "";
                textLoginPassword.Text = "";
            }
            
        }

        /**
         * Exit Click
         * 
         * @param object sender
         * @param EventArgs e
         * 
         * @return void
         */ 
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
