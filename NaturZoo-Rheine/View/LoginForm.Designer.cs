namespace NaturZoo_Rheine.View {
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupLogin = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupLoginPassword = new System.Windows.Forms.GroupBox();
            this.textLoginPassword = new System.Windows.Forms.TextBox();
            this.groupLoginEmail = new System.Windows.Forms.GroupBox();
            this.textLoginEmail = new System.Windows.Forms.TextBox();
            this.groupLogin.SuspendLayout();
            this.groupLoginPassword.SuspendLayout();
            this.groupLoginEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupLogin
            // 
            this.groupLogin.Controls.Add(this.btnExit);
            this.groupLogin.Controls.Add(this.btnLogin);
            this.groupLogin.Controls.Add(this.groupLoginPassword);
            this.groupLogin.Controls.Add(this.groupLoginEmail);
            this.groupLogin.Location = new System.Drawing.Point(23, 63);
            this.groupLogin.Name = "groupLogin";
            this.groupLogin.Size = new System.Drawing.Size(312, 283);
            this.groupLogin.TabIndex = 1;
            this.groupLogin.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("BankGothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(167, 223);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(138, 38);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("BankGothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(10, 223);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(135, 38);
            this.btnLogin.TabIndex = 18;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // groupLoginPassword
            // 
            this.groupLoginPassword.Controls.Add(this.textLoginPassword);
            this.groupLoginPassword.Font = new System.Drawing.Font("BankGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupLoginPassword.Location = new System.Drawing.Point(29, 121);
            this.groupLoginPassword.Name = "groupLoginPassword";
            this.groupLoginPassword.Size = new System.Drawing.Size(256, 65);
            this.groupLoginPassword.TabIndex = 3;
            this.groupLoginPassword.TabStop = false;
            this.groupLoginPassword.Text = "Password";
            // 
            // textLoginPassword
            // 
            this.textLoginPassword.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLoginPassword.Location = new System.Drawing.Point(6, 26);
            this.textLoginPassword.MaxLength = 256;
            this.textLoginPassword.Name = "textLoginPassword";
            this.textLoginPassword.PasswordChar = '*';
            this.textLoginPassword.Size = new System.Drawing.Size(244, 26);
            this.textLoginPassword.TabIndex = 0;
            // 
            // groupLoginEmail
            // 
            this.groupLoginEmail.Controls.Add(this.textLoginEmail);
            this.groupLoginEmail.Font = new System.Drawing.Font("BankGothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupLoginEmail.Location = new System.Drawing.Point(29, 20);
            this.groupLoginEmail.Name = "groupLoginEmail";
            this.groupLoginEmail.Size = new System.Drawing.Size(256, 65);
            this.groupLoginEmail.TabIndex = 2;
            this.groupLoginEmail.TabStop = false;
            this.groupLoginEmail.Text = "E-Mail";
            // 
            // textLoginEmail
            // 
            this.textLoginEmail.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLoginEmail.Location = new System.Drawing.Point(6, 26);
            this.textLoginEmail.MaxLength = 256;
            this.textLoginEmail.Name = "textLoginEmail";
            this.textLoginEmail.Size = new System.Drawing.Size(244, 26);
            this.textLoginEmail.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(361, 369);
            this.Controls.Add(this.groupLogin);
            this.Font = new System.Drawing.Font("BankGothic", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(30, 60, 30, 20);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Natur Zoo - Rheine";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.groupLogin.ResumeLayout(false);
            this.groupLoginPassword.ResumeLayout(false);
            this.groupLoginPassword.PerformLayout();
            this.groupLoginEmail.ResumeLayout(false);
            this.groupLoginEmail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupLogin;
        private System.Windows.Forms.GroupBox groupLoginEmail;
        private System.Windows.Forms.TextBox textLoginEmail;
        private System.Windows.Forms.GroupBox groupLoginPassword;
        private System.Windows.Forms.TextBox textLoginPassword;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogin;
    }
}