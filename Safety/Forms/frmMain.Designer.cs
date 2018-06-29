namespace Safety
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDBConn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUserRights = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogOff = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMast = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVendorMast = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViolationMast = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmailConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTranS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTranSafetyViolation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsMast = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRptOthers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsUserID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsUserDesc = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsExtra = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuInspTypeMast = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdmin,
            this.mnuUser,
            this.mnuMast,
            this.mnuTranS,
            this.mnuReports,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuAdmin
            // 
            this.mnuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDBConn,
            this.mnuUserRights});
            this.mnuAdmin.Name = "mnuAdmin";
            this.mnuAdmin.Size = new System.Drawing.Size(55, 20);
            this.mnuAdmin.Text = "&Admin";
            // 
            // mnuDBConn
            // 
            this.mnuDBConn.Name = "mnuDBConn";
            this.mnuDBConn.Size = new System.Drawing.Size(187, 22);
            this.mnuDBConn.Text = "Database Connection";
            this.mnuDBConn.Click += new System.EventHandler(this.mnuDBConn_Click);
            // 
            // mnuUserRights
            // 
            this.mnuUserRights.Name = "mnuUserRights";
            this.mnuUserRights.Size = new System.Drawing.Size(187, 22);
            this.mnuUserRights.Text = "User Rights";
            this.mnuUserRights.Click += new System.EventHandler(this.mnuUserRights_Click);
            // 
            // mnuUser
            // 
            this.mnuUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangePass,
            this.mnuLogOff});
            this.mnuUser.Name = "mnuUser";
            this.mnuUser.Size = new System.Drawing.Size(71, 20);
            this.mnuUser.Text = "&Users Info";
            // 
            // mnuChangePass
            // 
            this.mnuChangePass.Name = "mnuChangePass";
            this.mnuChangePass.Size = new System.Drawing.Size(168, 22);
            this.mnuChangePass.Text = "Change &Password";
            this.mnuChangePass.Click += new System.EventHandler(this.mnuChangePass_Click);
            // 
            // mnuLogOff
            // 
            this.mnuLogOff.Name = "mnuLogOff";
            this.mnuLogOff.Size = new System.Drawing.Size(168, 22);
            this.mnuLogOff.Text = "&Log Off";
            this.mnuLogOff.Click += new System.EventHandler(this.mnuLogOff_Click);
            // 
            // mnuMast
            // 
            this.mnuMast.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuVendorMast,
            this.mnuViolationMast,
            this.mnuEmailConfig,
            this.mnuInspTypeMast});
            this.mnuMast.Name = "mnuMast";
            this.mnuMast.Size = new System.Drawing.Size(60, 20);
            this.mnuMast.Text = "&Masters";
            // 
            // mnuVendorMast
            // 
            this.mnuVendorMast.Name = "mnuVendorMast";
            this.mnuVendorMast.Size = new System.Drawing.Size(196, 22);
            this.mnuVendorMast.Text = "Vendor Master";
            this.mnuVendorMast.Click += new System.EventHandler(this.mnuVendorMast_Click);
            // 
            // mnuViolationMast
            // 
            this.mnuViolationMast.Name = "mnuViolationMast";
            this.mnuViolationMast.Size = new System.Drawing.Size(196, 22);
            this.mnuViolationMast.Text = "Violation Master";
            this.mnuViolationMast.Click += new System.EventHandler(this.mnuReasonMast_Click);
            // 
            // mnuEmailConfig
            // 
            this.mnuEmailConfig.Name = "mnuEmailConfig";
            this.mnuEmailConfig.Size = new System.Drawing.Size(196, 22);
            this.mnuEmailConfig.Text = "Email Configuration";
            this.mnuEmailConfig.Click += new System.EventHandler(this.mnuEmailConfig_Click);
            // 
            // mnuTranS
            // 
            this.mnuTranS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTranSafetyViolation,
            this.mnuToolsMast});
            this.mnuTranS.Name = "mnuTranS";
            this.mnuTranS.Size = new System.Drawing.Size(80, 20);
            this.mnuTranS.Text = "&Transaction";
            // 
            // mnuTranSafetyViolation
            // 
            this.mnuTranSafetyViolation.Name = "mnuTranSafetyViolation";
            this.mnuTranSafetyViolation.Size = new System.Drawing.Size(176, 22);
            this.mnuTranSafetyViolation.Text = "Safety Violation";
            this.mnuTranSafetyViolation.Click += new System.EventHandler(this.mnuTranSafetyViolation_Click);
            // 
            // mnuToolsMast
            // 
            this.mnuToolsMast.Name = "mnuToolsMast";
            this.mnuToolsMast.Size = new System.Drawing.Size(176, 22);
            this.mnuToolsMast.Text = "Tools/Equp. Master";
            this.mnuToolsMast.Click += new System.EventHandler(this.mnuToolsMast_Click);
            // 
            // mnuReports
            // 
            this.mnuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRptOthers});
            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Size = new System.Drawing.Size(59, 20);
            this.mnuReports.Text = "Reports";
            // 
            // mnuRptOthers
            // 
            this.mnuRptOthers.Name = "mnuRptOthers";
            this.mnuRptOthers.Size = new System.Drawing.Size(147, 22);
            this.mnuRptOthers.Text = "Other Reports";
            this.mnuRptOthers.Click += new System.EventHandler(this.mnuRptOthers_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.stsUserID,
            this.toolStripStatusLabel3,
            this.stsUserDesc,
            this.stsExtra});
            this.statusStrip1.Location = new System.Drawing.Point(0, 678);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel1.Text = "User ID : ";
            // 
            // stsUserID
            // 
            this.stsUserID.Name = "stsUserID";
            this.stsUserID.Size = new System.Drawing.Size(49, 17);
            this.stsUserID.Text = "GUserID";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(74, 17);
            this.toolStripStatusLabel3.Text = "User Name : ";
            // 
            // stsUserDesc
            // 
            this.stsUserDesc.Name = "stsUserDesc";
            this.stsUserDesc.Size = new System.Drawing.Size(70, 17);
            this.stsUserDesc.Text = "GUserName";
            // 
            // stsExtra
            // 
            this.stsExtra.Name = "stsExtra";
            this.stsExtra.Size = new System.Drawing.Size(0, 17);
            // 
            // mnuInspTypeMast
            // 
            this.mnuInspTypeMast.Name = "mnuInspTypeMast";
            this.mnuInspTypeMast.Size = new System.Drawing.Size(196, 22);
            this.mnuInspTypeMast.Text = "Inspection Type Master";
            this.mnuInspTypeMast.Click += new System.EventHandler(this.mnuInspTypeMast_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Safety System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuAdmin;
        private System.Windows.Forms.ToolStripMenuItem mnuUserRights;
        private System.Windows.Forms.ToolStripMenuItem mnuUser;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePass;
        private System.Windows.Forms.ToolStripMenuItem mnuLogOff;
        private System.Windows.Forms.ToolStripMenuItem mnuMast;
        private System.Windows.Forms.ToolStripMenuItem mnuTranS;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel stsUserID;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel stsUserDesc;
        private System.Windows.Forms.ToolStripStatusLabel stsExtra;
        private System.Windows.Forms.ToolStripMenuItem mnuDBConn;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuRptOthers;
        private System.Windows.Forms.ToolStripMenuItem mnuVendorMast;
        private System.Windows.Forms.ToolStripMenuItem mnuViolationMast;
        private System.Windows.Forms.ToolStripMenuItem mnuTranSafetyViolation;
        private System.Windows.Forms.ToolStripMenuItem mnuEmailConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsMast;
        private System.Windows.Forms.ToolStripMenuItem mnuInspTypeMast;


    }
}
