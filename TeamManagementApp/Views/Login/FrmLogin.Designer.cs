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
            btnLogin.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnLogin.Location = new Point(105, 90);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 25);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft Sans Serif", 8.25F);
            txtUsername.Location = new Point(105, 32);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(212, 20);
            txtUsername.TabIndex = 1;
            txtUsername.KeyUp += textBox_KeyUp;
            // 
            // lblIntorduceti
            // 
            lblIntorduceti.AutoSize = true;
            lblIntorduceti.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            lblIntorduceti.Location = new Point(107, 9);
            lblIntorduceti.Name = "lblIntorduceti";
            lblIntorduceti.Size = new Size(181, 13);
            lblIntorduceti.TabIndex = 6;
            lblIntorduceti.Text = "Enter username and password.";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblUser.Location = new Point(43, 35);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(55, 13);
            lblUser.TabIndex = 9;
            lblUser.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblPassword.Location = new Point(43, 61);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(53, 13);
            lblPassword.TabIndex = 10;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft Sans Serif", 8.25F);
            txtPassword.Location = new Point(105, 61);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(212, 20);
            txtPassword.TabIndex = 2;
            txtPassword.KeyUp += textBox_KeyUp;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnCancel.Location = new Point(186, 90);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnAnulare_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Microsoft Sans Serif", 8.25F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(20, 118);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 13);
            lblError.TabIndex = 11;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 138);
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