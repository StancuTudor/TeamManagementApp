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
            StripMainMenu = new MenuStrip();
            mnuAddProject = new ToolStripMenuItem();
            dgvProjects = new DataGridView();
            pnlProjects = new Panel();
            btnResetFilters = new Button();
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
            StripMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).BeginInit();
            pnlProjects.SuspendLayout();
            SuspendLayout();
            // 
            // StripMainMenu
            // 
            StripMainMenu.ImageScalingSize = new Size(48, 48);
            StripMainMenu.Items.AddRange(new ToolStripItem[] { mnuAddProject });
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
            mnuAddProject.Image = Properties.Resources.question;
            mnuAddProject.Name = "mnuAddProject";
            mnuAddProject.Padding = new Padding(0);
            mnuAddProject.Size = new Size(64, 64);
            mnuAddProject.ToolTipText = "Add project";
            // 
            // dgvProjects
            // 
            dgvProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProjects.Location = new Point(0, 72);
            dgvProjects.Name = "dgvProjects";
            dgvProjects.Size = new Size(984, 574);
            dgvProjects.TabIndex = 1;
            // 
            // pnlProjects
            // 
            pnlProjects.Controls.Add(btnResetFilters);
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
            pnlProjects.Size = new Size(984, 646);
            pnlProjects.TabIndex = 2;
            // 
            // btnResetFilters
            // 
            btnResetFilters.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnResetFilters.Location = new Point(860, 36);
            btnResetFilters.Name = "btnResetFilters";
            btnResetFilters.Size = new Size(121, 30);
            btnResetFilters.TabIndex = 13;
            btnResetFilters.Text = "Reset filters";
            btnResetFilters.UseVisualStyleBackColor = true;
            btnResetFilters.Click += btnResetFilters_Click;
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
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(StripMainMenu);
            Controls.Add(pnlProjects);
            Name = "FrmMain";
            Text = "Projects";
            Load += FrmMain_Load;
            StripMainMenu.ResumeLayout(false);
            StripMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProjects).EndInit();
            pnlProjects.ResumeLayout(false);
            pnlProjects.PerformLayout();
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
        private Button btnResetFilters;
    }
}
