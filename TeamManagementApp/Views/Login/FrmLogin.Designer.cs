namespace TeamManagementApp.Views
{
    partial class FrmLogin
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            btnLogin = new Button();
            txtUsername = new TextBox();
            lblIntorduceti = new Label();
            lblUser = new Label();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnCancel = new Button();
            lblError = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnLogin.Location = new Point(119, 97);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(86, 29);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft Sans Serif", 11.25F);
            txtUsername.Location = new Point(119, 38);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(265, 24);
            txtUsername.TabIndex = 1;
            txtUsername.KeyUp += textBox_KeyUp;
            // 
            // lblIntorduceti
            // 
            lblIntorduceti.AutoSize = true;
            lblIntorduceti.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIntorduceti.Location = new Point(88, 9);
            lblIntorduceti.Name = "lblIntorduceti";
            lblIntorduceti.Size = new Size(242, 18);
            lblIntorduceti.TabIndex = 6;
            lblIntorduceti.Text = "Enter username and password.";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblUser.Location = new Point(36, 41);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(77, 18);
            lblUser.TabIndex = 9;
            lblUser.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft Sans Serif", 11.25F);
            lblPassword.Location = new Point(36, 70);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(75, 18);
            lblPassword.TabIndex = 10;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft Sans Serif", 11.25F);
            txtPassword.Location = new Point(119, 67);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(265, 24);
            txtPassword.TabIndex = 2;
            txtPassword.KeyUp += textBox_KeyUp;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 11.25F);
            btnCancel.Location = new Point(211, 97);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(86, 29);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnAnulare_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(20, 131);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 18);
            lblError.TabIndex = 11;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 158);
            Controls.Add(lblError);
            Controls.Add(btnCancel);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(lblUser);
            Controls.Add(btnLogin);
            Controls.Add(txtUsername);
            Controls.Add(lblIntorduceti);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox txtUsername;
        private Label lblIntorduceti;
        private Label lblUser;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnCancel;
        private Label lblError;
    }
}