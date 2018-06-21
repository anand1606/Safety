namespace Safety.Forms
{
    partial class frmMastEmailConfig
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSMTPPort = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHRSentTo = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSMTPHost = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFinSentTo = new DevExpress.XtraEditors.TextEdit();
            this.txtEmailID = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAccountPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtEmailAccount = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpUserRights = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCCTo = new DevExpress.XtraEditors.TextEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHRSentTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinSentTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailAccount.Properties)).BeginInit();
            this.grpUserRights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCCTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCCTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSMTPPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtHRSentTo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSMTPHost);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtFinSentTo);
            this.groupBox1.Controls.Add(this.txtEmailID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAccountPassword);
            this.groupBox1.Controls.Add(this.txtEmailAccount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Smtp Port";
            // 
            // txtSMTPPort
            // 
            this.txtSMTPPort.Location = new System.Drawing.Point(169, 93);
            this.txtSMTPPort.Name = "txtSMTPPort";
            this.txtSMTPPort.Properties.Mask.EditMask = "[0-9]+";
            this.txtSMTPPort.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSMTPPort.Properties.MaxLength = 35;
            this.txtSMTPPort.Size = new System.Drawing.Size(93, 20);
            this.txtSMTPPort.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "HRER - SentTo";
            // 
            // txtHRSentTo
            // 
            this.txtHRSentTo.Location = new System.Drawing.Point(169, 170);
            this.txtHRSentTo.Name = "txtHRSentTo";
            this.txtHRSentTo.Properties.Mask.ShowPlaceHolders = false;
            this.txtHRSentTo.Properties.MaxLength = 200;
            this.txtHRSentTo.Size = new System.Drawing.Size(529, 20);
            this.txtHRSentTo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Smtp Host";
            // 
            // txtSMTPHost
            // 
            this.txtSMTPHost.Location = new System.Drawing.Point(169, 68);
            this.txtSMTPHost.Name = "txtSMTPHost";
            this.txtSMTPHost.Properties.MaxLength = 200;
            this.txtSMTPHost.Size = new System.Drawing.Size(286, 20);
            this.txtSMTPHost.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Finance - SentTo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Sender ID";
            // 
            // txtFinSentTo
            // 
            this.txtFinSentTo.Location = new System.Drawing.Point(169, 144);
            this.txtFinSentTo.Name = "txtFinSentTo";
            this.txtFinSentTo.Properties.Mask.ShowPlaceHolders = false;
            this.txtFinSentTo.Properties.MaxLength = 200;
            this.txtFinSentTo.Size = new System.Drawing.Size(529, 20);
            this.txtFinSentTo.TabIndex = 5;
            // 
            // txtEmailID
            // 
            this.txtEmailID.Location = new System.Drawing.Point(169, 118);
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Properties.MaxLength = 200;
            this.txtEmailID.Size = new System.Drawing.Size(286, 20);
            this.txtEmailID.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Sender Account Password";
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Location = new System.Drawing.Point(169, 42);
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.Properties.Mask.ShowPlaceHolders = false;
            this.txtAccountPassword.Properties.MaxLength = 200;
            this.txtAccountPassword.Size = new System.Drawing.Size(286, 20);
            this.txtAccountPassword.TabIndex = 1;
            // 
            // txtEmailAccount
            // 
            this.txtEmailAccount.Location = new System.Drawing.Point(169, 16);
            this.txtEmailAccount.Name = "txtEmailAccount";
            this.txtEmailAccount.Properties.Mask.ShowPlaceHolders = false;
            this.txtEmailAccount.Properties.MaxLength = 200;
            this.txtEmailAccount.Size = new System.Drawing.Size(286, 20);
            this.txtEmailAccount.TabIndex = 0;
            this.txtEmailAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmailAccount_KeyDown);
            this.txtEmailAccount.Validated += new System.EventHandler(this.txtEmailAccount_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email Sender Account";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.btnAdd.Location = new System.Drawing.Point(138, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpUserRights
            // 
            this.grpUserRights.Controls.Add(this.btnClose);
            this.grpUserRights.Controls.Add(this.btnCancel);
            this.grpUserRights.Controls.Add(this.btnDelete);
            this.grpUserRights.Controls.Add(this.btnUpdate);
            this.grpUserRights.Controls.Add(this.btnAdd);
            this.grpUserRights.Location = new System.Drawing.Point(12, 259);
            this.grpUserRights.Name = "grpUserRights";
            this.grpUserRights.Size = new System.Drawing.Size(696, 52);
            this.grpUserRights.TabIndex = 2;
            this.grpUserRights.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Cornsilk;
            this.btnClose.Location = new System.Drawing.Point(461, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Clos&e";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Cornsilk;
            this.btnCancel.Location = new System.Drawing.Point(381, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Cornsilk;
            this.btnDelete.Location = new System.Drawing.Point(300, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Cornsilk;
            this.btnUpdate.Location = new System.Drawing.Point(219, 14);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Common - CC To";
            // 
            // txtCCTo
            // 
            this.txtCCTo.Location = new System.Drawing.Point(169, 196);
            this.txtCCTo.Name = "txtCCTo";
            this.txtCCTo.Properties.Mask.ShowPlaceHolders = false;
            this.txtCCTo.Properties.MaxLength = 200;
            this.txtCCTo.Size = new System.Drawing.Size(529, 20);
            this.txtCCTo.TabIndex = 7;
            // 
            // frmMastEmailConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 318);
            this.Controls.Add(this.grpUserRights);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMastEmailConfig";
            this.Text = "Email Configuration Master";
            this.Load += new System.EventHandler(this.frmMastEmailConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHRSentTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFinSentTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmailAccount.Properties)).EndInit();
            this.grpUserRights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCCTo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpUserRights;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtAccountPassword;
        private DevExpress.XtraEditors.TextEdit txtEmailAccount;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtSMTPHost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtFinSentTo;
        private DevExpress.XtraEditors.TextEdit txtEmailID;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtSMTPPort;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtHRSentTo;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtCCTo;
    }
}