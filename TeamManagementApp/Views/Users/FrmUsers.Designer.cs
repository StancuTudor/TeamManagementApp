namespace TeamManagementApp.Views.Users
{
    partial class FrmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsers));
            cmbSearchUsername = new ComboBox();
            gbUser = new GroupBox();
            cmbUserMember = new ComboBox();
            lblMember = new Label();
            txtUserUsername = new TextBox();
            btnResetPassword = new Button();
            lblUsername = new Label();
            cmbSearchMember = new ComboBox();
            gbSearch = new GroupBox();
            rbNewUser = new RadioButton();
            rbMember = new RadioButton();
            rbUsername = new RadioButton();
            btnSave = new Button();
            btnDelete = new Button();
            gbUser.SuspendLayout();
            gbSearch.SuspendLayout();
            SuspendLayout();
            // 
            // cmbSearchUsername
            // 
            cmbSearchUsername.Font = new Font("Segoe UI", 12F);
            cmbSearchUsername.FormattingEnabled = true;
            cmbSearchUsername.Location = new Point(105, 52);
            cmbSearchUsername.Name = "cmbSearchUsername";
            cmbSearchUsername.Size = new Size(121, 29);
            cmbSearchUsername.TabIndex = 19;
            cmbSearchUsername.SelectedIndexChanged += cmbSearchUsername_SelectedIndexChanged;
            // 
            // gbUser
            // 
            gbUser.Controls.Add(cmbUserMember);
            gbUser.Controls.Add(lblMember);
            gbUser.Controls.Add(txtUserUsername);
            gbUser.Controls.Add(btnResetPassword);
            gbUser.Controls.Add(lblUsername);
            gbUser.Location = new Point(261, 12);
            gbUser.Name = "gbUser";
            gbUser.Size = new Size(218, 128);
            gbUser.TabIndex = 20;
            gbUser.TabStop = false;
            gbUser.Text = "User";
            // 
            // cmbUserMember
            // 
            cmbUserMember.Font = new Font("Segoe UI", 12F);
            cmbUserMember.FormattingEnabled = true;
            cmbUserMember.Location = new Point(87, 52);
            cmbUserMember.Name = "cmbUserMember";
            cmbUserMember.Size = new Size(121, 29);
            cmbUserMember.TabIndex = 26;
            // 
            // lblMember
            // 
            lblMember.AutoSize = true;
            lblMember.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMember.Location = new Point(6, 57);
            lblMember.Name = "lblMember";
            lblMember.Size = new Size(65, 20);
            lblMember.TabIndex = 25;
            lblMember.Text = "Member";
            // 
            // txtUserUsername
            // 
            txtUserUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserUsername.Location = new Point(87, 21);
            txtUserUsername.Name = "txtUserUsername";
            txtUserUsername.Size = new Size(121, 27);
            txtUserUsername.TabIndex = 12;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnResetPassword.Location = new Point(6, 87);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(202, 30);
            btnResetPassword.TabIndex = 23;
            btnResetPassword.Text = "Reset password";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(6, 24);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 20);
            lblUsername.TabIndex = 13;
            lblUsername.Text = "Username";
            // 
            // cmbSearchMember
            // 
            cmbSearchMember.Font = new Font("Segoe UI", 12F);
            cmbSearchMember.FormattingEnabled = true;
            cmbSearchMember.Location = new Point(105, 87);
            cmbSearchMember.Name = "cmbSearchMember";
            cmbSearchMember.Size = new Size(121, 29);
            cmbSearchMember.TabIndex = 25;
            cmbSearchMember.SelectedIndexChanged += cmbSearchMember_SelectedIndexChanged;
            // 
            // gbSearch
            // 
            gbSearch.Controls.Add(rbNewUser);
            gbSearch.Controls.Add(rbMember);
            gbSearch.Controls.Add(cmbSearchMember);
            gbSearch.Controls.Add(rbUsername);
            gbSearch.Controls.Add(cmbSearchUsername);
            gbSearch.Location = new Point(12, 12);
            gbSearch.Name = "gbSearch";
            gbSearch.Size = new Size(243, 128);
            gbSearch.TabIndex = 26;
            gbSearch.TabStop = false;
            gbSearch.Text = "Search users";
            // 
            // rbNewUser
            // 
            rbNewUser.AutoSize = true;
            rbNewUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbNewUser.Location = new Point(6, 19);
            rbNewUser.Name = "rbNewUser";
            rbNewUser.Size = new Size(88, 24);
            rbNewUser.TabIndex = 28;
            rbNewUser.TabStop = true;
            rbNewUser.Text = "New user";
            rbNewUser.UseVisualStyleBackColor = true;
            rbNewUser.CheckedChanged += rbNewUser_CheckedChanged;
            // 
            // rbMember
            // 
            rbMember.AutoSize = true;
            rbMember.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbMember.Location = new Point(6, 89);
            rbMember.Name = "rbMember";
            rbMember.Size = new Size(83, 24);
            rbMember.TabIndex = 27;
            rbMember.TabStop = true;
            rbMember.Text = "Member";
            rbMember.UseVisualStyleBackColor = true;
            rbMember.CheckedChanged += rbMember_CheckedChanged;
            // 
            // rbUsername
            // 
            rbUsername.AutoSize = true;
            rbUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbUsername.Location = new Point(6, 54);
            rbUsername.Name = "rbUsername";
            rbUsername.Size = new Size(93, 24);
            rbUsername.TabIndex = 26;
            rbUsername.TabStop = true;
            rbUsername.Text = "Username";
            rbUsername.UseVisualStyleBackColor = true;
            rbUsername.CheckedChanged += rbUsername_CheckedChanged;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(380, 146);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(99, 30);
            btnSave.TabIndex = 28;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(277, 146);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 30);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // FrmUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 186);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(gbSearch);
            Controls.Add(gbUser);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmUsers";
            Text = "Configure users";
            Load += FrmUsers_Load;
            gbUser.ResumeLayout(false);
            gbUser.PerformLayout();
            gbSearch.ResumeLayout(false);
            gbSearch.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cmbSearchUsername;
        private GroupBox gbUser;
        private TextBox txtUserUsername;
        private Label lblUsername;
        private Button btnResetPassword;
        private ComboBox cmbSearchMember;
        private GroupBox gbSearch;
        private RadioButton rbUsername;
        private RadioButton rbMember;
        private RadioButton rbNewUser;
        private Button btnSave;
        private Button btnDelete;
        private Label lblMember;
        private ComboBox cmbUserMember;
    }
}