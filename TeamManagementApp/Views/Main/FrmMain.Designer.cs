namespace TeamManagementApp
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            StripMainMenu = new MenuStrip();
            mnuAddProject = new ToolStripMenuItem();
            mnuMembers = new ToolStripMenuItem();
            mnuConfigMembers = new ToolStripMenuItem();
            mnuConfigMemberClasses = new ToolStripMenuItem();
            mnuProjects = new ToolStripMenuItem();
            mnuConfigProjectTypes = new ToolStripMenuItem();
            mnuConfigGeneral = new ToolStripMenuItem();
            mnuConfigUsers = new ToolStripMenuItem();
            dgvProjects = new DataGridView();
            pnlProjects = new Panel();
            btnRefreshList = new Button();
            btnRefreshFilters = new Button();
            btnEmptyList = new Button();
            btnAddToList = new Button();
            btnApplyFilters = new Button();
            cmbTypeFilter = new ComboBox();
            lblTypeFilter = new Label();
            cmbStatusFilter = new ComboBox();
            lblStatusFilter = new Label();
            cmbAssigneeFilter = new ComboBox();
            lblAssigneeFilter = new Label();
            txtProjectFilter = new TextBox();
            lblProjectFilter = new Label();
            statusStrip = new StatusStrip();
            lblLoggedInUser = new ToolStripStatusLabel();
            lblConnectedServer = new ToolStripStatusLabel();
            lblAppVersion = new ToolStripStatusLabel();
            StripMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            pnlProjects.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // StripMainMenu
            // 
            StripMainMenu.ImageScalingSize = new Size(48, 48);
            StripMainMenu.Items.AddRange(new ToolStripItem[] { mnuAddProject, mnuMembers, mnuProjects, mnuConfigGeneral });
            StripMainMenu.Location = new Point(0, 0);
            StripMainMenu.Name = "StripMainMenu";
            StripMainMenu.ShowItemToolTips = true;
            StripMainMenu.Size = new Size(1008, 68);
            StripMainMenu.TabIndex = 0;
            StripMainMenu.Text = "menuStrip1";
            // 
            // mnuAddProject
            // 
            mnuAddProject.AutoSize = false;
            mnuAddProject.AutoToolTip = true;
            mnuAddProject.Image = Properties.Resources.document;
            mnuAddProject.Name = "mnuAddProject";
            mnuAddProject.Padding = new Padding(0);
            mnuAddProject.Size = new Size(64, 64);
            mnuAddProject.ToolTipText = "Add project";
            mnuAddProject.Click += mnuAddProject_Click;
            // 
            // mnuMembers
            // 
            mnuMembers.AutoSize = false;
            mnuMembers.AutoToolTip = true;
            mnuMembers.DropDownItems.AddRange(new ToolStripItem[] { mnuConfigMembers, mnuConfigMemberClasses });
            mnuMembers.Image = Properties.Resources.user;
            mnuMembers.Name = "mnuMembers";
            mnuMembers.Padding = new Padding(0);
            mnuMembers.Size = new Size(64, 64);
            // 
            // mnuConfigMembers
            // 
            mnuConfigMembers.Name = "mnuConfigMembers";
            mnuConfigMembers.Size = new Size(214, 22);
            mnuConfigMembers.Text = "Configure members";
            mnuConfigMembers.Click += mnuConfigMembers_Click;
            // 
            // mnuConfigMemberClasses
            // 
            mnuConfigMemberClasses.Name = "mnuConfigMemberClasses";
            mnuConfigMemberClasses.Size = new Size(214, 22);
            mnuConfigMemberClasses.Text = "Configure member classes";
            mnuConfigMemberClasses.Click += mnuConfigMemberClasses_Click;
            // 
            // mnuProjects
            // 
            mnuProjects.AutoSize = false;
            mnuProjects.AutoToolTip = true;
            mnuProjects.DropDownItems.AddRange(new ToolStripItem[] { mnuConfigProjectTypes });
            mnuProjects.Image = Properties.Resources.connection;
            mnuProjects.Name = "mnuProjects";
            mnuProjects.Padding = new Padding(0);
            mnuProjects.Size = new Size(64, 64);
            // 
            // mnuConfigProjectTypes
            // 
            mnuConfigProjectTypes.Name = "mnuConfigProjectTypes";
            mnuConfigProjectTypes.Size = new Size(198, 22);
            mnuConfigProjectTypes.Text = "Configure project types";
            mnuConfigProjectTypes.Click += mnuConfigProjectTypes_Click;
            // 
            // mnuConfigGeneral
            // 
            mnuConfigGeneral.AutoSize = false;
            mnuConfigGeneral.AutoToolTip = true;
            mnuConfigGeneral.DropDownItems.AddRange(new ToolStripItem[] { mnuConfigUsers });
            mnuConfigGeneral.Image = Properties.Resources.box;
            mnuConfigGeneral.Name = "mnuConfigGeneral";
            mnuConfigGeneral.Padding = new Padding(0);
            mnuConfigGeneral.Size = new Size(64, 64);
            // 
            // mnuConfigUsers
            // 
            mnuConfigUsers.Name = "mnuConfigUsers";
            mnuConfigUsers.Size = new Size(157, 22);
            mnuConfigUsers.Text = "Configure users";
            mnuConfigUsers.Click += mnuConfigUsers_Click;
            // 
            // dgvProjects
            // 
            dgvProjects.AllowUserToAddRows = false;
            dgvProjects.AllowUserToDeleteRows = false;
            dgvProjects.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProjects.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProjects.ColumnHeadersHeight = 28;
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProjects.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProjects.Location = new Point(0, 72);
            dgvProjects.Name = "dgvProjects";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProjects.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProjects.Size = new Size(984, 558);
            dgvProjects.TabIndex = 1;
            dgvProjects.CellMouseDoubleClick += dgvProjects_CellMouseDoubleClick;
            // 
            // pnlProjects
            // 
            pnlProjects.Controls.Add(btnRefreshList);
            pnlProjects.Controls.Add(btnRefreshFilters);
            pnlProjects.Controls.Add(btnEmptyList);
            pnlProjects.Controls.Add(btnAddToList);
            pnlProjects.Controls.Add(btnApplyFilters);
            pnlProjects.Controls.Add(cmbTypeFilter);
            pnlProjects.Controls.Add(lblTypeFilter);
            pnlProjects.Controls.Add(cmbStatusFilter);
            pnlProjects.Controls.Add(lblStatusFilter);
            pnlProjects.Controls.Add(cmbAssigneeFilter);
            pnlProjects.Controls.Add(lblAssigneeFilter);
            pnlProjects.Controls.Add(txtProjectFilter);
            pnlProjects.Controls.Add(lblProjectFilter);
            pnlProjects.Controls.Add(dgvProjects);
            pnlProjects.Location = new Point(12, 71);
            pnlProjects.Name = "pnlProjects";
            pnlProjects.Size = new Size(984, 633);
            pnlProjects.TabIndex = 2;
            // 
            // btnRefreshList
            // 
            btnRefreshList.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefreshList.Location = new Point(733, 37);
            btnRefreshList.Name = "btnRefreshList";
            btnRefreshList.Size = new Size(121, 30);
            btnRefreshList.TabIndex = 14;
            btnRefreshList.Text = "Refresh list";
            btnRefreshList.UseVisualStyleBackColor = true;
            btnRefreshList.Click += btnRefreshList_Click;
            // 
            // btnRefreshFilters
            // 
            btnRefreshFilters.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefreshFilters.Location = new Point(860, 36);
            btnRefreshFilters.Name = "btnRefreshFilters";
            btnRefreshFilters.Size = new Size(121, 30);
            btnRefreshFilters.TabIndex = 13;
            btnRefreshFilters.Text = "Refresh filters";
            btnRefreshFilters.UseVisualStyleBackColor = true;
            btnRefreshFilters.Click += btnRefreshFilters_Click;
            // 
            // btnEmptyList
            // 
            btnEmptyList.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEmptyList.Location = new Point(257, 36);
            btnEmptyList.Name = "btnEmptyList";
            btnEmptyList.Size = new Size(121, 30);
            btnEmptyList.TabIndex = 12;
            btnEmptyList.Text = "Empty list";
            btnEmptyList.UseVisualStyleBackColor = true;
            btnEmptyList.Click += btnEmptyList_Click;
            // 
            // btnAddToList
            // 
            btnAddToList.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddToList.Location = new Point(130, 36);
            btnAddToList.Name = "btnAddToList";
            btnAddToList.Size = new Size(121, 30);
            btnAddToList.TabIndex = 11;
            btnAddToList.Text = "Add to list";
            btnAddToList.UseVisualStyleBackColor = true;
            btnAddToList.Click += btnAddToList_Click;
            // 
            // btnApplyFilters
            // 
            btnApplyFilters.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnApplyFilters.Location = new Point(3, 36);
            btnApplyFilters.Name = "btnApplyFilters";
            btnApplyFilters.Size = new Size(121, 30);
            btnApplyFilters.TabIndex = 10;
            btnApplyFilters.Text = "Apply filters";
            btnApplyFilters.UseVisualStyleBackColor = true;
            btnApplyFilters.Click += btnApplyFilters_Click;
            // 
            // cmbTypeFilter
            // 
            cmbTypeFilter.Font = new Font("Segoe UI", 12F);
            cmbTypeFilter.FormattingEnabled = true;
            cmbTypeFilter.Location = new Point(860, 3);
            cmbTypeFilter.Name = "cmbTypeFilter";
            cmbTypeFilter.Size = new Size(121, 29);
            cmbTypeFilter.TabIndex = 9;
            // 
            // lblTypeFilter
            // 
            lblTypeFilter.AutoSize = true;
            lblTypeFilter.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTypeFilter.Location = new Point(773, 7);
            lblTypeFilter.Name = "lblTypeFilter";
            lblTypeFilter.Size = new Size(40, 20);
            lblTypeFilter.TabIndex = 8;
            lblTypeFilter.Text = "Type";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.Font = new Font("Segoe UI", 12F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(646, 2);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(121, 29);
            cmbStatusFilter.TabIndex = 7;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusFilter.Location = new Point(591, 7);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(49, 20);
            lblStatusFilter.TabIndex = 6;
            lblStatusFilter.Text = "Status";
            // 
            // cmbAssigneeFilter
            // 
            cmbAssigneeFilter.Font = new Font("Segoe UI", 12F);
            cmbAssigneeFilter.FormattingEnabled = true;
            cmbAssigneeFilter.Location = new Point(464, 2);
            cmbAssigneeFilter.Name = "cmbAssigneeFilter";
            cmbAssigneeFilter.Size = new Size(121, 29);
            cmbAssigneeFilter.TabIndex = 5;
            // 
            // lblAssigneeFilter
            // 
            lblAssigneeFilter.AutoSize = true;
            lblAssigneeFilter.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAssigneeFilter.Location = new Point(329, 7);
            lblAssigneeFilter.Name = "lblAssigneeFilter";
            lblAssigneeFilter.Size = new Size(68, 20);
            lblAssigneeFilter.TabIndex = 4;
            lblAssigneeFilter.Text = "Assignee";
            // 
            // txtProjectFilter
            // 
            txtProjectFilter.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProjectFilter.Location = new Point(64, 3);
            txtProjectFilter.Name = "txtProjectFilter";
            txtProjectFilter.Size = new Size(259, 27);
            txtProjectFilter.TabIndex = 3;
            txtProjectFilter.KeyUp += txtProjectFilter_KeyUp;
            // 
            // lblProjectFilter
            // 
            lblProjectFilter.AutoSize = true;
            lblProjectFilter.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProjectFilter.Location = new Point(3, 7);
            lblProjectFilter.Name = "lblProjectFilter";
            lblProjectFilter.Size = new Size(55, 20);
            lblProjectFilter.TabIndex = 2;
            lblProjectFilter.Text = "Project";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { lblLoggedInUser, lblConnectedServer, lblAppVersion });
            statusStrip.Location = new Point(0, 704);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1008, 25);
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip1";
            // 
            // lblLoggedInUser
            // 
            lblLoggedInUser.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoggedInUser.Name = "lblLoggedInUser";
            lblLoggedInUser.Size = new Size(107, 20);
            lblLoggedInUser.Text = "Logged in user";
            // 
            // lblConnectedServer
            // 
            lblConnectedServer.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConnectedServer.Name = "lblConnectedServer";
            lblConnectedServer.Size = new Size(123, 20);
            lblConnectedServer.Text = "Connected server";
            // 
            // lblAppVersion
            // 
            lblAppVersion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAppVersion.Name = "lblAppVersion";
            lblAppVersion.Size = new Size(88, 20);
            lblAppVersion.Text = "App version";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(statusStrip);
            Controls.Add(StripMainMenu);
            Controls.Add(pnlProjects);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Projects";
            Load += FrmMain_Load;
            Resize += FrmMain_Resize;
            StripMainMenu.ResumeLayout(false);
            StripMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            pnlProjects.ResumeLayout(false);
            pnlProjects.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip StripMainMenu;
        private ToolStripMenuItem mnuAddProject;
        private DataGridView dgvProjects;
        private Panel pnlProjects;
        private TextBox txtProjectFilter;
        private Label lblProjectFilter;
        private Label lblAssigneeFilter;
        private Label lblStatusFilter;
        private ComboBox cmbAssigneeFilter;
        private ComboBox cmbStatusFilter;
        private ComboBox cmbTypeFilter;
        private Label lblTypeFilter;
        private Button btnEmptyList;
        private Button btnAddToList;
        private Button btnApplyFilters;
        private Button btnRefreshFilters;
        private ToolStripMenuItem mnuMembers;
        private ToolStripMenuItem mnuProjects;
        private ToolStripMenuItem mnuConfigGeneral;
        private ToolStripMenuItem mnuConfigUsers;
        private ToolStripMenuItem mnuConfigMembers;
        private ToolStripMenuItem mnuConfigMemberClasses;
        private ToolStripMenuItem mnuConfigProjectTypes;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblLoggedInUser;
        private ToolStripStatusLabel lblConnectedServer;
        private ToolStripStatusLabel lblAppVersion;
        private Button btnRefreshList;
    }
}
