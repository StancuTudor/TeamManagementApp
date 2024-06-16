namespace TeamManagementApp.Views.Projects
{
    partial class FrmProjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProjects));
            lblProject = new Label();
            cmbAssignee = new ComboBox();
            txtProjectName = new TextBox();
            rtxtDescription = new RichTextBox();
            lblDescription = new Label();
            gbDetails = new GroupBox();
            lblDateEnd = new Label();
            dtpDateEnd = new DateTimePicker();
            lblDateStart = new Label();
            dtpDateStart = new DateTimePicker();
            lblType = new Label();
            cmbType = new ComboBox();
            lblAssignee = new Label();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            gbMembers = new GroupBox();
            btnEmptyList = new Button();
            btnAdd = new Button();
            lvwMembers = new ListView();
            lblMember = new Label();
            cmbMember = new ComboBox();
            lblMemberClass = new Label();
            cmbMemberClass = new ComboBox();
            btnSave = new Button();
            btnDelete = new Button();
            colMember = new ColumnHeader();
            gbDetails.SuspendLayout();
            gbMembers.SuspendLayout();
            SuspendLayout();
            // 
            // lblProject
            // 
            lblProject.AutoSize = true;
            lblProject.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProject.Location = new Point(12, 15);
            lblProject.Name = "lblProject";
            lblProject.Size = new Size(96, 20);
            lblProject.TabIndex = 0;
            lblProject.Text = "Project name";
            // 
            // cmbAssignee
            // 
            cmbAssignee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbAssignee.FormattingEnabled = true;
            cmbAssignee.Location = new Point(102, 22);
            cmbAssignee.Name = "cmbAssignee";
            cmbAssignee.Size = new Size(150, 28);
            cmbAssignee.TabIndex = 1;
            // 
            // txtProjectName
            // 
            txtProjectName.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProjectName.Location = new Point(114, 12);
            txtProjectName.Name = "txtProjectName";
            txtProjectName.Size = new Size(363, 27);
            txtProjectName.TabIndex = 2;
            // 
            // rtxtDescription
            // 
            rtxtDescription.Location = new Point(6, 182);
            rtxtDescription.Name = "rtxtDescription";
            rtxtDescription.Size = new Size(459, 96);
            rtxtDescription.TabIndex = 3;
            rtxtDescription.Text = "";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription.Location = new Point(6, 159);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(85, 20);
            lblDescription.TabIndex = 4;
            lblDescription.Text = "Description";
            // 
            // gbDetails
            // 
            gbDetails.Controls.Add(lblDateEnd);
            gbDetails.Controls.Add(dtpDateEnd);
            gbDetails.Controls.Add(lblDateStart);
            gbDetails.Controls.Add(dtpDateStart);
            gbDetails.Controls.Add(lblType);
            gbDetails.Controls.Add(cmbType);
            gbDetails.Controls.Add(lblAssignee);
            gbDetails.Controls.Add(rtxtDescription);
            gbDetails.Controls.Add(lblDescription);
            gbDetails.Controls.Add(cmbAssignee);
            gbDetails.Location = new Point(12, 45);
            gbDetails.Name = "gbDetails";
            gbDetails.Size = new Size(471, 287);
            gbDetails.TabIndex = 5;
            gbDetails.TabStop = false;
            gbDetails.Text = "Details";
            // 
            // lblDateEnd
            // 
            lblDateEnd.AutoSize = true;
            lblDateEnd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateEnd.Location = new Point(6, 128);
            lblDateEnd.Name = "lblDateEnd";
            lblDateEnd.Size = new Size(74, 20);
            lblDateEnd.TabIndex = 11;
            lblDateEnd.Text = "Date start";
            // 
            // dtpDateEnd
            // 
            dtpDateEnd.CustomFormat = "dd.MM.yyyy";
            dtpDateEnd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDateEnd.Format = DateTimePickerFormat.Custom;
            dtpDateEnd.Location = new Point(102, 123);
            dtpDateEnd.Name = "dtpDateEnd";
            dtpDateEnd.ShowCheckBox = true;
            dtpDateEnd.Size = new Size(150, 27);
            dtpDateEnd.TabIndex = 10;
            dtpDateEnd.ValueChanged += dtpDateEnd_ValueChanged;
            // 
            // lblDateStart
            // 
            lblDateStart.AutoSize = true;
            lblDateStart.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateStart.Location = new Point(6, 95);
            lblDateStart.Name = "lblDateStart";
            lblDateStart.Size = new Size(74, 20);
            lblDateStart.TabIndex = 9;
            lblDateStart.Text = "Date start";
            // 
            // dtpDateStart
            // 
            dtpDateStart.CustomFormat = "dd.MM.yyyy";
            dtpDateStart.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDateStart.Format = DateTimePickerFormat.Custom;
            dtpDateStart.Location = new Point(102, 90);
            dtpDateStart.Name = "dtpDateStart";
            dtpDateStart.ShowCheckBox = true;
            dtpDateStart.Size = new Size(150, 27);
            dtpDateStart.TabIndex = 8;
            dtpDateStart.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblType.Location = new Point(6, 59);
            lblType.Name = "lblType";
            lblType.Size = new Size(40, 20);
            lblType.TabIndex = 7;
            lblType.Text = "Type";
            // 
            // cmbType
            // 
            cmbType.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(102, 56);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(150, 28);
            cmbType.TabIndex = 6;
            // 
            // lblAssignee
            // 
            lblAssignee.AutoSize = true;
            lblAssignee.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAssignee.Location = new Point(6, 25);
            lblAssignee.Name = "lblAssignee";
            lblAssignee.Size = new Size(68, 20);
            lblAssignee.TabIndex = 5;
            lblAssignee.Text = "Assignee";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(489, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(49, 20);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            cmbStatus.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(579, 11);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 28);
            cmbStatus.TabIndex = 6;
            // 
            // gbMembers
            // 
            gbMembers.Controls.Add(btnEmptyList);
            gbMembers.Controls.Add(btnAdd);
            gbMembers.Controls.Add(lvwMembers);
            gbMembers.Controls.Add(lblMember);
            gbMembers.Controls.Add(cmbMember);
            gbMembers.Controls.Add(lblMemberClass);
            gbMembers.Controls.Add(cmbMemberClass);
            gbMembers.Location = new Point(489, 46);
            gbMembers.Name = "gbMembers";
            gbMembers.Size = new Size(246, 286);
            gbMembers.TabIndex = 8;
            gbMembers.TabStop = false;
            gbMembers.Text = "Members";
            // 
            // btnEmptyList
            // 
            btnEmptyList.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEmptyList.Location = new Point(116, 84);
            btnEmptyList.Name = "btnEmptyList";
            btnEmptyList.Size = new Size(101, 30);
            btnEmptyList.TabIndex = 20;
            btnEmptyList.Text = "Remove all";
            btnEmptyList.UseVisualStyleBackColor = true;
            btnEmptyList.Click += btnEmptyList_Click;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(9, 84);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(101, 30);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lvwMembers
            // 
            lvwMembers.Columns.AddRange(new ColumnHeader[] { colMember });
            lvwMembers.Location = new Point(9, 120);
            lvwMembers.Name = "lvwMembers";
            lvwMembers.Size = new Size(231, 157);
            lvwMembers.TabIndex = 12;
            lvwMembers.UseCompatibleStateImageBehavior = false;
            lvwMembers.View = View.Details;
            // 
            // lblMember
            // 
            lblMember.AutoSize = true;
            lblMember.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMember.Location = new Point(9, 53);
            lblMember.Name = "lblMember";
            lblMember.Size = new Size(65, 20);
            lblMember.TabIndex = 11;
            lblMember.Text = "Member";
            // 
            // cmbMember
            // 
            cmbMember.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMember.FormattingEnabled = true;
            cmbMember.Location = new Point(90, 50);
            cmbMember.Name = "cmbMember";
            cmbMember.Size = new Size(150, 28);
            cmbMember.TabIndex = 10;
            // 
            // lblMemberClass
            // 
            lblMemberClass.AutoSize = true;
            lblMemberClass.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMemberClass.Location = new Point(9, 19);
            lblMemberClass.Name = "lblMemberClass";
            lblMemberClass.Size = new Size(42, 20);
            lblMemberClass.TabIndex = 9;
            lblMemberClass.Text = "Class";
            // 
            // cmbMemberClass
            // 
            cmbMemberClass.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMemberClass.FormattingEnabled = true;
            cmbMemberClass.Location = new Point(90, 16);
            cmbMemberClass.Name = "cmbMemberClass";
            cmbMemberClass.Size = new Size(150, 28);
            cmbMemberClass.TabIndex = 8;
            cmbMemberClass.SelectedIndexChanged += cmbMemberClass_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(634, 338);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 30);
            btnSave.TabIndex = 18;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(527, 338);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(101, 30);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // colMember
            // 
            colMember.Text = "Members";
            colMember.Width = 180;
            // 
            // FrmProjects
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 375);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(gbMembers);
            Controls.Add(lblStatus);
            Controls.Add(cmbStatus);
            Controls.Add(gbDetails);
            Controls.Add(txtProjectName);
            Controls.Add(lblProject);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmProjects";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Projects";
            Load += FrmProjects_Load;
            gbDetails.ResumeLayout(false);
            gbDetails.PerformLayout();
            gbMembers.ResumeLayout(false);
            gbMembers.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProject;
        private ComboBox cmbAssignee;
        private TextBox txtProjectName;
        private RichTextBox rtxtDescription;
        private Label lblDescription;
        private GroupBox gbDetails;
        private Label lblAssignee;
        private Label lblType;
        private ComboBox cmbType;
        private DateTimePicker dtpDateStart;
        private Label lblDateStart;
        private Label lblDateEnd;
        private DateTimePicker dtpDateEnd;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private GroupBox gbMembers;
        private Label lblMemberClass;
        private ComboBox cmbMemberClass;
        private Label lblMember;
        private ComboBox cmbMember;
        private ListView lvwMembers;
        private Button btnSave;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnEmptyList;
        private ColumnHeader colMember;
    }
}