namespace Safety.Forms
{
    partial class frmTranViolation
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
            this.txtTrDate = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrID = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpUserRights = new System.Windows.Forms.GroupBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPenaltyRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPenaltyDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtViolationDesc = new DevExpress.XtraEditors.TextEdit();
            this.txtViolationID = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReasonCode = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReasonDesc = new DevExpress.XtraEditors.MemoEdit();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRemarks = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPenaltyAmt = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.txtSuperVisorName = new DevExpress.XtraEditors.TextEdit();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSupervisorCode = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDefaulterName = new DevExpress.XtraEditors.TextEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDefaulterCode = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDefaulterType = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkPenaltyCollected = new System.Windows.Forms.CheckBox();
            this.lblDeleted = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrID.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpUserRights.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViolationDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViolationID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonDesc.Properties)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyAmt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuperVisorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupervisorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaulterName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaulterCode.Properties)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDeleted);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTrDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTrID);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date :";
            // 
            // txtTrDate
            // 
            this.txtTrDate.EditValue = null;
            this.txtTrDate.Location = new System.Drawing.Point(248, 28);
            this.txtTrDate.Name = "txtTrDate";
            this.txtTrDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTrDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTrDate.Properties.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
            this.txtTrDate.Properties.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
            this.txtTrDate.Size = new System.Drawing.Size(100, 20);
            this.txtTrDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tran. ID :";
            // 
            // txtTrID
            // 
            this.txtTrID.Location = new System.Drawing.Point(97, 29);
            this.txtTrID.Name = "txtTrID";
            this.txtTrID.Properties.Mask.EditMask = "d";
            this.txtTrID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTrID.Size = new System.Drawing.Size(100, 20);
            this.txtTrID.TabIndex = 0;
            this.txtTrID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTrID_KeyDown);
            this.txtTrID.Validated += new System.EventHandler(this.txtTrID_Validated);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grpUserRights, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.70175F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.29825F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1035, 453);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grpUserRights
            // 
            this.grpUserRights.Controls.Add(this.btnEmail);
            this.grpUserRights.Controls.Add(this.btnClose);
            this.grpUserRights.Controls.Add(this.btnCancel);
            this.grpUserRights.Controls.Add(this.btnDelete);
            this.grpUserRights.Controls.Add(this.btnUpdate);
            this.grpUserRights.Controls.Add(this.btnAdd);
            this.grpUserRights.Location = new System.Drawing.Point(3, 397);
            this.grpUserRights.Name = "grpUserRights";
            this.grpUserRights.Size = new System.Drawing.Size(1029, 48);
            this.grpUserRights.TabIndex = 0;
            this.grpUserRights.TabStop = false;
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.Cornsilk;
            this.btnEmail.Location = new System.Drawing.Point(678, 10);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(94, 32);
            this.btnEmail.TabIndex = 5;
            this.btnEmail.Text = "Send E&mail";
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Cornsilk;
            this.btnClose.Location = new System.Drawing.Point(597, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Clos&e";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Cornsilk;
            this.btnCancel.Location = new System.Drawing.Point(517, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Cornsilk;
            this.btnDelete.Location = new System.Drawing.Point(436, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Cornsilk;
            this.btnUpdate.Location = new System.Drawing.Point(355, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cornsilk;
            this.btnAdd.Location = new System.Drawing.Point(274, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPenaltyRemarks);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPenaltyDesc);
            this.groupBox2.Controls.Add(this.txtViolationDesc);
            this.groupBox2.Controls.Add(this.txtViolationID);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtReasonCode);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtReasonDesc);
            this.groupBox2.Location = new System.Drawing.Point(3, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1029, 147);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Penalty Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 14);
            this.label9.TabIndex = 28;
            this.label9.Text = "(Press F1 for Selection)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 14);
            this.label4.TabIndex = 27;
            this.label4.Text = "Remarks :";
            // 
            // txtPenaltyRemarks
            // 
            this.txtPenaltyRemarks.Location = new System.Drawing.Point(579, 71);
            this.txtPenaltyRemarks.Name = "txtPenaltyRemarks";
            this.txtPenaltyRemarks.Properties.MaxLength = 50;
            this.txtPenaltyRemarks.Properties.ReadOnly = true;
            this.txtPenaltyRemarks.Size = new System.Drawing.Size(340, 65);
            this.txtPenaltyRemarks.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "Penalty Desc.";
            // 
            // txtPenaltyDesc
            // 
            this.txtPenaltyDesc.Location = new System.Drawing.Point(579, 45);
            this.txtPenaltyDesc.Name = "txtPenaltyDesc";
            this.txtPenaltyDesc.Properties.Mask.EditMask = "[0-9]+";
            this.txtPenaltyDesc.Properties.Mask.ShowPlaceHolders = false;
            this.txtPenaltyDesc.Properties.MaxLength = 50;
            this.txtPenaltyDesc.Properties.ReadOnly = true;
            this.txtPenaltyDesc.Size = new System.Drawing.Size(338, 20);
            this.txtPenaltyDesc.TabIndex = 4;
            // 
            // txtViolationDesc
            // 
            this.txtViolationDesc.Location = new System.Drawing.Point(683, 20);
            this.txtViolationDesc.Name = "txtViolationDesc";
            this.txtViolationDesc.Properties.Mask.EditMask = "[0-9]+";
            this.txtViolationDesc.Properties.Mask.ShowPlaceHolders = false;
            this.txtViolationDesc.Properties.MaxLength = 3;
            this.txtViolationDesc.Properties.ReadOnly = true;
            this.txtViolationDesc.Size = new System.Drawing.Size(236, 20);
            this.txtViolationDesc.TabIndex = 3;
            // 
            // txtViolationID
            // 
            this.txtViolationID.Location = new System.Drawing.Point(579, 20);
            this.txtViolationID.Name = "txtViolationID";
            this.txtViolationID.Properties.Mask.EditMask = "[0-9]+";
            this.txtViolationID.Properties.Mask.ShowPlaceHolders = false;
            this.txtViolationID.Properties.MaxLength = 3;
            this.txtViolationID.Properties.ReadOnly = true;
            this.txtViolationID.Size = new System.Drawing.Size(96, 20);
            this.txtViolationID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(466, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "Violation Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "Reason Desc";
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.Location = new System.Drawing.Point(97, 20);
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.Properties.Mask.EditMask = "[0-9]+";
            this.txtReasonCode.Properties.Mask.ShowPlaceHolders = false;
            this.txtReasonCode.Properties.MaxLength = 3;
            this.txtReasonCode.Properties.ReadOnly = true;
            this.txtReasonCode.Size = new System.Drawing.Size(96, 20);
            this.txtReasonCode.TabIndex = 0;
            this.txtReasonCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReasonCode_KeyDown);
            this.txtReasonCode.Validated += new System.EventHandler(this.txtReasonCode_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "Reason Code";
            // 
            // txtReasonDesc
            // 
            this.txtReasonDesc.Location = new System.Drawing.Point(97, 49);
            this.txtReasonDesc.Name = "txtReasonDesc";
            this.txtReasonDesc.Properties.MaxLength = 50;
            this.txtReasonDesc.Properties.ReadOnly = true;
            this.txtReasonDesc.Size = new System.Drawing.Size(340, 87);
            this.txtReasonDesc.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtRemarks);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtPenaltyAmt);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtLocation);
            this.groupBox3.Controls.Add(this.txtSuperVisorName);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtSupervisorCode);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtDefaulterName);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtDefaulterCode);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtDefaulterType);
            this.groupBox3.Location = new System.Drawing.Point(3, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1029, 113);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(466, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 14);
            this.label15.TabIndex = 38;
            this.label15.Text = "Remarks :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(579, 82);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Properties.Mask.EditMask = "[-a-zA-Z0-9 .:@#$!*()+:<,>;/?]+";
            this.txtRemarks.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRemarks.Properties.MaxLength = 35;
            this.txtRemarks.Size = new System.Drawing.Size(340, 20);
            this.txtRemarks.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 14);
            this.label6.TabIndex = 36;
            this.label6.Text = "Penalty Amt.";
            // 
            // txtPenaltyAmt
            // 
            this.txtPenaltyAmt.Location = new System.Drawing.Point(97, 82);
            this.txtPenaltyAmt.Name = "txtPenaltyAmt";
            this.txtPenaltyAmt.Properties.Mask.EditMask = "d";
            this.txtPenaltyAmt.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPenaltyAmt.Properties.MaxLength = 35;
            this.txtPenaltyAmt.Size = new System.Drawing.Size(96, 20);
            this.txtPenaltyAmt.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 14);
            this.label12.TabIndex = 34;
            this.label12.Text = "Location :";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(97, 56);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.Mask.EditMask = "[-a-zA-Z0-9 .:@#$!*()+:<,>;/?]+";
            this.txtLocation.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtLocation.Properties.MaxLength = 35;
            this.txtLocation.Size = new System.Drawing.Size(340, 20);
            this.txtLocation.TabIndex = 1;
            // 
            // txtSuperVisorName
            // 
            this.txtSuperVisorName.Location = new System.Drawing.Point(683, 56);
            this.txtSuperVisorName.Name = "txtSuperVisorName";
            this.txtSuperVisorName.Properties.Mask.EditMask = "d";
            this.txtSuperVisorName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSuperVisorName.Properties.MaxLength = 35;
            this.txtSuperVisorName.Properties.ReadOnly = true;
            this.txtSuperVisorName.Size = new System.Drawing.Size(234, 20);
            this.txtSuperVisorName.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(466, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 14);
            this.label14.TabIndex = 31;
            this.label14.Text = "Supervisor Code";
            // 
            // txtSupervisorCode
            // 
            this.txtSupervisorCode.Location = new System.Drawing.Point(579, 56);
            this.txtSupervisorCode.Name = "txtSupervisorCode";
            this.txtSupervisorCode.Properties.Mask.EditMask = "d";
            this.txtSupervisorCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSupervisorCode.Properties.MaxLength = 35;
            this.txtSupervisorCode.Properties.ReadOnly = true;
            this.txtSupervisorCode.Size = new System.Drawing.Size(96, 20);
            this.txtSupervisorCode.TabIndex = 4;
            this.txtSupervisorCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupervisorCode_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(542, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(153, 14);
            this.label13.TabIndex = 29;
            this.label13.Text = "(Press F1/F2 for Selection)";
            // 
            // txtDefaulterName
            // 
            this.txtDefaulterName.Location = new System.Drawing.Point(683, 30);
            this.txtDefaulterName.Name = "txtDefaulterName";
            this.txtDefaulterName.Properties.Mask.EditMask = "d";
            this.txtDefaulterName.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDefaulterName.Properties.MaxLength = 35;
            this.txtDefaulterName.Properties.ReadOnly = true;
            this.txtDefaulterName.Size = new System.Drawing.Size(234, 20);
            this.txtDefaulterName.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(466, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 14);
            this.label11.TabIndex = 22;
            this.label11.Text = "Defaulter Account";
            // 
            // txtDefaulterCode
            // 
            this.txtDefaulterCode.Location = new System.Drawing.Point(579, 30);
            this.txtDefaulterCode.Name = "txtDefaulterCode";
            this.txtDefaulterCode.Properties.Mask.EditMask = "d";
            this.txtDefaulterCode.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDefaulterCode.Properties.MaxLength = 35;
            this.txtDefaulterCode.Properties.ReadOnly = true;
            this.txtDefaulterCode.Size = new System.Drawing.Size(96, 20);
            this.txtDefaulterCode.TabIndex = 3;
            this.txtDefaulterCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDefaulterCode_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 14);
            this.label10.TabIndex = 12;
            this.label10.Text = "Defaulter Type";
            // 
            // txtDefaulterType
            // 
            this.txtDefaulterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDefaulterType.FormattingEnabled = true;
            this.txtDefaulterType.Items.AddRange(new object[] {
            "Employee",
            "Vendor"});
            this.txtDefaulterType.Location = new System.Drawing.Point(99, 21);
            this.txtDefaulterType.Name = "txtDefaulterType";
            this.txtDefaulterType.Size = new System.Drawing.Size(146, 22);
            this.txtDefaulterType.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkPenaltyCollected);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 353);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1029, 38);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // chkPenaltyCollected
            // 
            this.chkPenaltyCollected.AutoSize = true;
            this.chkPenaltyCollected.Location = new System.Drawing.Point(99, 15);
            this.chkPenaltyCollected.Name = "chkPenaltyCollected";
            this.chkPenaltyCollected.Size = new System.Drawing.Size(191, 18);
            this.chkPenaltyCollected.TabIndex = 0;
            this.chkPenaltyCollected.Text = "Is Penalty Amount Collected ?";
            this.chkPenaltyCollected.UseVisualStyleBackColor = true;
            // 
            // lblDeleted
            // 
            this.lblDeleted.AutoSize = true;
            this.lblDeleted.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleted.ForeColor = System.Drawing.Color.Red;
            this.lblDeleted.Location = new System.Drawing.Point(655, 25);
            this.lblDeleted.Name = "lblDeleted";
            this.lblDeleted.Size = new System.Drawing.Size(0, 23);
            this.lblDeleted.TabIndex = 4;
            // 
            // frmTranViolation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 468);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTranViolation";
            this.Text = "Safety Violation";
            this.Load += new System.EventHandler(this.frmTranViolation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrID.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpUserRights.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViolationDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtViolationID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReasonDesc.Properties)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPenaltyAmt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSuperVisorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupervisorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaulterName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDefaulterCode.Properties)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtTrID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit txtTrDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.MemoEdit txtPenaltyRemarks;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtPenaltyDesc;
        private DevExpress.XtraEditors.TextEdit txtViolationDesc;
        private DevExpress.XtraEditors.TextEdit txtViolationID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtReasonCode;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.MemoEdit txtReasonDesc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox txtDefaulterType;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.TextEdit txtRemarks;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtPenaltyAmt;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.TextEdit txtSuperVisorName;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.TextEdit txtSupervisorCode;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtDefaulterName;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtDefaulterCode;
        private System.Windows.Forms.GroupBox grpUserRights;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkPenaltyCollected;
        private System.Windows.Forms.Label lblDeleted;
    }
}