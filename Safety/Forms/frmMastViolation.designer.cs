namespace Safety.Forms
{
    partial class frmMastViolation
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtPenaltyAmt = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReasonCode = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReasonDesc = new DevExpress.XtraEditors.MemoEdit();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grpUserRights = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtViolationID = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtViolationDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtPenaltyDesc = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonDesc.Properties)).BeginInit();
            this.grpUserRights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtViolationID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViolationDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPenaltyDesc);
            this.groupBox1.Controls.Add(this.txtViolationDesc);
            this.groupBox1.Controls.Add(this.txtViolationID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPenaltyAmt);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtReasonCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtReasonDesc);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Penalty Amt.";
            // 
            // txtPenaltyAmt
            // 
            this.txtPenaltyAmt.Location = new System.Drawing.Point(97, 161);
            this.txtPenaltyAmt.Name = "txtPenaltyAmt";
            this.txtPenaltyAmt.Properties.Mask.EditMask = "d";
            this.txtPenaltyAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPenaltyAmt.Properties.MaxLength = 35;
            this.txtPenaltyAmt.Size = new System.Drawing.Size(96, 20);
            this.txtPenaltyAmt.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Reason Desc";
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.Location = new System.Drawing.Point(97, 16);
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.Properties.Mask.EditMask = "[0-9]+";
            this.txtReasonCode.Properties.Mask.ShowPlaceHolders = false;
            this.txtReasonCode.Properties.MaxLength = 3;
            this.txtReasonCode.Size = new System.Drawing.Size(96, 20);
            this.txtReasonCode.TabIndex = 0;
            this.txtReasonCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReasonCode_KeyDown);
            this.txtReasonCode.Validated += new System.EventHandler(this.txtReasonCode_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Reason Code";
            // 
            // txtReasonDesc
            // 
            this.txtReasonDesc.Location = new System.Drawing.Point(97, 42);
            this.txtReasonDesc.Name = "txtReasonDesc";
            this.txtReasonDesc.Properties.MaxLength = 50;
            this.txtReasonDesc.Size = new System.Drawing.Size(340, 87);
            this.txtReasonDesc.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.btnAdd.Location = new System.Drawing.Point(29, 14);
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
            this.grpUserRights.Location = new System.Drawing.Point(12, 337);
            this.grpUserRights.Name = "grpUserRights";
            this.grpUserRights.Size = new System.Drawing.Size(455, 52);
            this.grpUserRights.TabIndex = 2;
            this.grpUserRights.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Cornsilk;
            this.btnClose.Location = new System.Drawing.Point(352, 14);
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
            this.btnCancel.Location = new System.Drawing.Point(272, 14);
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
            this.btnDelete.Location = new System.Drawing.Point(191, 14);
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
            this.btnUpdate.Location = new System.Drawing.Point(110, 14);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtViolationID
            // 
            this.txtViolationID.Location = new System.Drawing.Point(97, 135);
            this.txtViolationID.Name = "txtViolationID";
            this.txtViolationID.Properties.Mask.EditMask = "[0-9]+";
            this.txtViolationID.Properties.Mask.ShowPlaceHolders = false;
            this.txtViolationID.Properties.MaxLength = 3;
            this.txtViolationID.Properties.ReadOnly = true;
            this.txtViolationID.Size = new System.Drawing.Size(96, 20);
            this.txtViolationID.TabIndex = 2;
            this.txtViolationID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtViolationID_KeyDown);
            this.txtViolationID.Validated += new System.EventHandler(this.txtViolationID_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Violation Type:";
            // 
            // txtViolationDesc
            // 
            this.txtViolationDesc.Location = new System.Drawing.Point(201, 135);
            this.txtViolationDesc.Name = "txtViolationDesc";
            this.txtViolationDesc.Properties.Mask.EditMask = "[0-9]+";
            this.txtViolationDesc.Properties.Mask.ShowPlaceHolders = false;
            this.txtViolationDesc.Properties.MaxLength = 3;
            this.txtViolationDesc.Properties.ReadOnly = true;
            this.txtViolationDesc.Size = new System.Drawing.Size(236, 20);
            this.txtViolationDesc.TabIndex = 3;
            // 
            // txtPenaltyDesc
            // 
            this.txtPenaltyDesc.Location = new System.Drawing.Point(97, 187);
            this.txtPenaltyDesc.Name = "txtPenaltyDesc";
            this.txtPenaltyDesc.Properties.Mask.EditMask = "[0-9]+";
            this.txtPenaltyDesc.Properties.Mask.ShowPlaceHolders = false;
            this.txtPenaltyDesc.Properties.MaxLength = 50;
            this.txtPenaltyDesc.Size = new System.Drawing.Size(338, 20);
            this.txtPenaltyDesc.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Penalty Desc.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Remarks :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(97, 213);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Properties.MaxLength = 50;
            this.txtRemarks.Size = new System.Drawing.Size(340, 65);
            this.txtRemarks.TabIndex = 6;
            // 
            // frmMastReason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 401);
            this.Controls.Add(this.grpUserRights);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMastReason";
            this.Text = "Violation Reason Master";
            this.Load += new System.EventHandler(this.frmMastViolation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonDesc.Properties)).EndInit();
            this.grpUserRights.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtViolationID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViolationDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtReasonCode;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtPenaltyAmt;
        private DevExpress.XtraEditors.MemoEdit txtReasonDesc;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.MemoEdit txtRemarks;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtPenaltyDesc;
        private DevExpress.XtraEditors.TextEdit txtViolationDesc;
        private DevExpress.XtraEditors.TextEdit txtViolationID;
        private System.Windows.Forms.Label label1;
    }
}