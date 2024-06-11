namespace TeamManagementApp.Views.Members
{
    partial class FrmTypes
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
            cmbType = new ComboBox();
            lblType = new Label();
            txtTypeDetails = new TextBox();
            lblTypeDetails = new Label();
            gbDetails = new GroupBox();
            btnDelete = new Button();
            btnSave = new Button();
            gbDetails.SuspendLayout();
            SuspendLayout();
            // 
            // cmbType
            // 
            cmbType.Font = new Font("Segoe UI", 12F);
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(86, 12);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(121, 29);
            cmbType.TabIndex = 7;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblType.Location = new Point(12, 16);
            lblType.Name = "lblType";
            lblType.Size = new Size(40, 20);
            lblType.TabIndex = 6;
            lblType.Text = "Type";
            // 
            // txtTypeDetails
            // 
            txtTypeDetails.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTypeDetails.Location = new Point(80, 16);
            txtTypeDetails.Name = "txtTypeDetails";
            txtTypeDetails.Size = new Size(121, 27);
            txtTypeDetails.TabIndex = 12;
            // 
            // lblTypeDetails
            // 
            lblTypeDetails.AutoSize = true;
            lblTypeDetails.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTypeDetails.Location = new Point(6, 19);
            lblTypeDetails.Name = "lblTypeDetails";
            lblTypeDetails.Size = new Size(40, 20);
            lblTypeDetails.TabIndex = 13;
            lblTypeDetails.Text = "Type";
            // 
            // gbDetails
            // 
            gbDetails.Controls.Add(txtTypeDetails);
            gbDetails.Controls.Add(lblTypeDetails);
            gbDetails.Location = new Point(12, 47);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new Size(211, 56);
            gbDetails.TabIndex = 15;
            gbDetails.TabStop = false;
            gbDetails.Text = "Details";
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
            // FrmTypes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 147);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(cmbType);
            Controls.Add(lblType);
            Controls.Add(gbDetails);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmTypes";
            Text = "Project types";
            Load += FrmTypes_Load;
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbType;
        private Label lblType;
        private TextBox txtTypeDetails;
        private Label lblTypeDetails;
        private GroupBox gbDetails;
        private Button btnDelete;
        private Button btnSave;
    }
}