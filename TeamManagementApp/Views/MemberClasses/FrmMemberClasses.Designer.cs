namespace TeamManagementApp.Views.Members
{
    partial class FrmMemberClasses
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
            cmbMemberClass = new ComboBox();
            lblMemberClass = new Label();
            txtMemberClassDetails = new TextBox();
            lblMemberClassDetails = new Label();
            gbDetails = new GroupBox();
            chkActive = new CheckBox();
            btnDelete = new Button();
            btnSave = new Button();
            gbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // cmbMemberClass
            // 
            cmbMemberClass.Font = new Font("Segoe UI", 12F);
            cmbMemberClass.FormattingEnabled = true;
            cmbMemberClass.Location = new Point(86, 12);
            cmbMemberClass.Name = "cmbMemberClass";
            cmbMemberClass.Size = new Size(121, 29);
            cmbMemberClass.TabIndex = 7;
            cmbMemberClass.SelectedIndexChanged += cmbMemberClass_SelectedIndexChanged;
            // 
            // lblMemberClass
            // 
            lblMemberClass.AutoSize = true;
            lblMemberClass.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMemberClass.Location = new Point(12, 16);
            lblMemberClass.Name = "lblMemberClass";
            lblMemberClass.Size = new Size(42, 20);
            lblMemberClass.TabIndex = 6;
            lblMemberClass.Text = "Class";
            // 
            // txtMemberClassDetails
            // 
            txtMemberClassDetails.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMemberClassDetails.Location = new Point(80, 16);
            txtMemberClassDetails.Name = "txtMemberClassDetails";
            txtMemberClassDetails.Size = new Size(121, 27);
            txtMemberClassDetails.TabIndex = 12;
            // 
            // lblMemberClassDetails
            // 
            lblMemberClassDetails.AutoSize = true;
            lblMemberClassDetails.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMemberClassDetails.Location = new Point(6, 19);
            lblMemberClassDetails.Name = "lblMemberClassDetails";
            lblMemberClassDetails.Size = new Size(42, 20);
            lblMemberClassDetails.TabIndex = 13;
            lblMemberClassDetails.Text = "Class";
            // 
            // gbDetails
            // 
            gbDetails.Controls.Add(chkActive);
            gbDetails.Controls.Add(txtMemberClassDetails);
            gbDetails.Controls.Add(lblMemberClassDetails);
            gbDetails.Location = new Point(12, 47);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new Size(279, 56);
            gbDetails.TabIndex = 15;
            gbDetails.TabStop = false;
            gbDetails.Text = "Details";
            // 
            // chkActive
            // 
            chkActive.AutoSize = true;
            chkActive.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkActive.Location = new Point(207, 18);
            chkActive.Name = "chkActive";
            chkActive.Size = new Size(69, 24);
            chkActive.TabIndex = 15;
            chkActive.Text = "Active";
            chkActive.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(15, 109);
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
            btnSave.Location = new Point(122, 109);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 30);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FrmMemberClasses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(303, 147);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(cmbMemberClass);
            Controls.Add(lblMemberClass);
            Controls.Add(gbDetails);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmMemberClasses";
            Text = "Member classes";
            Load += FrmMemberClasses_Load;
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbMemberClass;
        private Label lblMemberClass;
        private TextBox txtMemberClassDetails;
        private Label lblMemberClassDetails;
        private GroupBox gbDetails;
        private Button btnDelete;
        private Button btnSave;
        private CheckBox chkActive;
    }
}