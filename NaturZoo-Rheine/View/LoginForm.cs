using System;
using System.Windows.Forms;

namespace NaturZoo_Rheine.View {
    /// <summary>
    ///     Provides the Login form.
    /// </summary>
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public Boolean LoginSuccess { get; private set; }
        public Int32 Permission { get; private set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            LoginSuccess = true;
        }

        /// <summary>
        ///     Login button click
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //
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
