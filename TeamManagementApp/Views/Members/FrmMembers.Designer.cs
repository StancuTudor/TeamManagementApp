namespace TeamManagementApp.Views.Members
{
    partial class FrmMembers
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
            cmbMember = new ComboBox();
            lblMember = new Label();
            cmbClass = new ComboBox();
            lblClass = new Label();
            cmbUser = new ComboBox();
            lblUser = new Label();
            txtMemberDetails = new TextBox();
            lblMemberDetails = new Label();
            chkActive = new CheckBox();
            gbDetails = new GroupBox();
            btnDelete = new Button();
            btnSave = new Button();
            gbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // cmbMember
            // 
            cmbMember.Font = new Font("Segoe UI", 12F);
            cmbMember.FormattingEnabled = true;
            cmbMember.Location = new Point(86, 12);
            cmbMember.Name = "cmbMember";
            cmbMember.Size = new Size(121, 29);
            cmbMember.TabIndex = 7;
            cmbMember.SelectedIndexChanged += cmbMember_SelectedIndexChanged;
            // 
            // lblMember
            // 
            lblMember.AutoSize = true;
            lblMember.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMember.Location = new Point(12, 16);
            lblMember.Name = "lblMember";
            lblMember.Size = new Size(65, 20);
            lblMember.TabIndex = 6;
            lblMember.Text = "Member";
            // 
            // cmbClass
            // 
            cmbClass.Font = new Font("Segoe UI", 12F);
            cmbClass.FormattingEnabled = true;
            cmbClass.Location = new Point(80, 49);
            cmbClass.Name = "cmbClass";
            cmbClass.Size = new Size(121, 29);
            cmbClass.TabIndex = 9;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblClass.Location = new Point(6, 53);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(42, 20);
            lblClass.TabIndex = 8;
            lblClass.Text = "Class";
            // 
            // cmbUser
            // 
            cmbUser.Font = new Font("Segoe UI", 12F);
            cmbUser.FormattingEnabled = true;
            cmbUser.Location = new Point(80, 84);
            cmbUser.Name = "cmbUser";
            cmbUser.Size = new Size(121, 29);
            cmbUser.TabIndex = 11;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(6, 88);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(38, 20);
            lblUser.TabIndex = 10;
            lblUser.Text = "User";
            // 
            // txtMemberDetails
            // 
            txtMemberDetails.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMemberDetails.Location = new Point(80, 16);
            txtMemberDetails.Name = "txtMemberDetails";
            txtMemberDetails.Size = new Size(121, 27);
            txtMemberDetails.TabIndex = 12;
            // 
            // lblMemberDetails
            // 
            lblMemberDetails.AutoSize = true;
            lblMemberDetails.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMemberDetails.Location = new Point(6, 19);
            lblMemberDetails.Name = "lblMemberDetails";
            lblMemberDetails.Size = new Size(65, 20);
            lblMemberDetails.TabIndex = 13;
            lblMemberDetails.Text = "Member";
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkActive.Location = new Point(207, 18);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(69, 24);
            chkActive.TabIndex = 14;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // gbDetails
            // 
            gbDetails.Controls.Add(chkActive);
            gbDetails.Controls.Add(txtMemberDetails);
            gbDetails.Controls.Add(lblMemberDetails);
            gbDetails.Controls.Add(lblClass);
            gbDetails.Controls.Add(cmbClass);
            gbDetails.Controls.Add(cmbUser);
            gbDetails.Controls.Add(lblUser);
            gbDetails.Location = new Point(12, 47);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new Size(279, 126);
            gbDetails.TabIndex = 15;
            gbDetails.TabStop = false;
            gbDetails.Text = "Details";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(83, 179);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 30);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(190, 179);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 30);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FrmMembers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 218);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(cmbMember);
            Controls.Add(lblMember);
            Controls.Add(gbDetails);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmMembers";
            Text = "Members";
            Load += FrmMembers_Load;
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMember;
        private Label lblMember;
        private ComboBox cmbClass;
        private Label lblClass;
        private ComboBox cmbUser;
        private Label lblUser;
        private TextBox txtMemberDetails;
        private Label lblMemberDetails;
        private CheckBox chkActive;
        private GroupBox gbDetails;
        private Button btnDelete;
        private Button btnSave;
    }
}