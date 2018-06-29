using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Safety.Forms
{
    public partial class frmTranViolation : Form
    {
        public string mode = "NEW";
        public string GRights = "XXXV";
        public string oldCode = "";
        
        public frmTranViolation()
        {
            InitializeComponent();
        }

        private void frmTranViolation_Load(object sender, EventArgs e)
        {
            ResetCtrl();
            GRights = Safety.Classes.Globals.GetFormRights(this.Name);
            SetRights();
        }

        private string DataValidate()
        {
            string err = string.Empty;

            if (string.IsNullOrEmpty(txtReasonCode.Text))
            {
                err = err + "Please Enter Cont Code" + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtReasonDesc.Text))
            {
                err = err + "Please Enter Reason Description" + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtViolationID.Text))
            {
                err = err + "Please Enter Violaiton Type Code.." + Environment.NewLine;
            }

            if (txtDefaulterType.Text.Trim().ToString() == "")
            {
                err = err + "Please Enter Defaulter Type.." + Environment.NewLine;
            }

            if (txtDefaulterCode.Text.Trim().ToString() == "")
            {
                err = err + "Please Enter Defaulter Code.." + Environment.NewLine;
            }

            if (txtLocation.Text.Trim().ToString() == "")
            {
                err = err + "Please Enter Location.." + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(txtDefaulterType.Text.Trim().ToString()))
            {
                if (txtDefaulterType.Text.Trim().ToString() == "Vendor")
                {
                    txtHodEmail.Text = "";
                    txtSupervisorCode.Text = "";

                }
                else
                {
                    if (txtHodEmail.Text.Trim().ToString() == "")
                    {
                        err = err + "Please Enter Hod Email ID .." + Environment.NewLine;
                    }
                }
            }


            return err;
        }

        private void ResetCtrl()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnEmail.Enabled = false;

            object s = new object();
            EventArgs e = new EventArgs();

            txtTrID.Text = "0";
            txtTrDate.EditValue = null;

            txtReasonCode.Text = "";
            txtReasonDesc.Text = "";
            txtPenaltyAmt.Text = "";
            txtPenaltyRemarks.Text = "";
            txtPenaltyDesc.Text = "";           
            txtViolationID.Text = "";
            txtViolationDesc.Text = "";
            
            txtDefaulterType.Text = "";
            txtDefaulterCode.Text = "";
            txtDefaulterName.Text = "";
            txtSupervisorCode.Text = "";
            txtSuperVisorName.Text = "";
            txtHodEmail.Text = "";
            txtRemarks.Text = "";
            txtLocation.Text = "";
            txtActionTaken.Text = "";

            chkPenaltyCollected.Checked = false;
            lblDeleted.Text = "";

            oldCode = "";
        }

        private void SetRights()
        {
            if (txtTrID.Text.Trim() != "" && mode == "NEW" && GRights.Contains("A"))
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

            }
            else if (txtTrID.Text.Trim() != "" && mode == "OLD")
            {
                btnAdd.Enabled = false;
                if (GRights.Contains("U"))
                    btnUpdate.Enabled = true;
                    
                if (GRights.Contains("D"))
                    btnDelete.Enabled = true;
            }

            if (GRights.Contains("XXXV"))
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                
            }

            if (GRights.Contains("XUXV"))
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEmail.Enabled = false;
                grpDefaulter.Enabled = false;
                grpPenltyType.Enabled = false;
                grpUpdate.Enabled = true;
            }
            
            if(GRights.Contains("AUXV") )
            {
                grpDefaulter.Enabled = true;
                grpPenltyType.Enabled = true;
                grpUpdate.Enabled = false;
            }

            if (GRights.Contains("AUDV"))
            {
                grpDefaulter.Enabled = true;
                grpPenltyType.Enabled = true;
                grpUpdate.Enabled = true;
            }


        }

        private void txtReasonCode_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";
                sql = "Select ReasonCode,ReasonDesc,PenaltyAmt From MastReason Where 1 =1 ";


                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "ReasonCode", "ReasonCode", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {

                    obj = (List<string>)hlp.Show(sql, "ReasonDesc", "ReasonDesc", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }

                if (obj.Count == 0)
                {

                    return;
                }
                else if (obj.ElementAt(0).ToString() == "0")
                {
                    return;
                }
                else if (obj.ElementAt(0).ToString() == "")
                {
                    return;
                }
                else
                {

                    txtReasonCode.Text = obj.ElementAt(0).ToString();
                    txtReasonDesc.Text = obj.ElementAt(1).ToString();

                }
            }
        }

        private void txtReasonCode_Validated(object sender, EventArgs e)
        {


            txtReasonCode.Text = txtReasonCode.Text.Trim().ToString();

            DataSet ds = new DataSet();
            string sql = "select * From MastReason where  ReasonCode ='" + txtReasonCode.Text.Trim() + "' ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>()
                           .Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    txtReasonCode.Text = dr["ReasonCode"].ToString();
                    txtReasonDesc.Text = dr["ReasonDesc"].ToString();
                    if (mode == "NEW")
                    {
                        txtPenaltyAmt.Text = dr["PenaltyAmt"].ToString();
                    }                        
                    txtViolationID.Text = dr["ViolationID"].ToString();
                    txtViolationID_Validated(sender, e);

                    txtPenaltyRemarks.Text = dr["Remarks"].ToString();
                    txtPenaltyDesc.Text = dr["PenaltyDesc"].ToString();                  

                }
            }

            
        }

        private void txtViolationID_Validated(object sender, EventArgs e)
        {

            txtViolationID.Text = txtViolationID.Text.Trim().ToString();

            DataSet ds = new DataSet();
            string sql = "select * From MastViolation where  ViolationID ='" + txtViolationID.Text.Trim() + "' ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>()
                           .Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    txtViolationID.Text = dr["ViolationID"].ToString();
                    txtViolationDesc.Text = dr["ViolationDesc"].ToString();


                }
            }

        }

        private void txtTrID_Validated(object sender, EventArgs e)
        {
            txtTrID.Text = txtTrID.Text.Trim().ToString();

            DataSet ds = new DataSet();
            string sql = "select * From ViolationDT where  ID ='" + txtTrID.Text.Trim() + "' and DelFlg = 0 ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>()
                           .Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                SetRights();
                
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    txtTrID.Text = dr["ID"].ToString();
                    txtTrDate.DateTime = Convert.ToDateTime(dr["ViolationDT"]);
                    
                    txtReasonCode.Text = dr["ReasonCode"].ToString();
                    txtReasonDesc.Text = dr["ReasonDesc"].ToString();
                    txtPenaltyAmt.Text = dr["PenaltyAmt"].ToString();
                    
                    txtPenaltyDesc.Text = dr["PenaltyDesc"].ToString();
                    txtPenaltyRemarks.Text = dr["PenaltyRemark"].ToString();
                    txtViolationID.Text = dr["ViolationID"].ToString();
                    txtViolationDesc.Text = dr["ViolationDesc"].ToString();

                    txtDefaulterType.Text = dr["DefaulterType"].ToString();
                    txtDefaulterCode.Text = dr["DefaulterCode"].ToString();
                    txtDefaulterName.Text = dr["DefaulterName"].ToString();
                    txtSupervisorCode.Text = dr["SuperVisorCode"].ToString();
                    txtSuperVisorName.Text = dr["SupervisorName"].ToString();
                    txtLocation.Text = dr["Location"].ToString();
                    txtRemarks.Text = dr["TransactionRemark"].ToString();
                    txtHodEmail.Text = dr["HodEmailID"].ToString();
                    txtActionTaken.Text = dr["ActionTaken"].ToString();

                    chkPenaltyCollected.Checked = Convert.ToBoolean(dr["PenaltyCollected"]);
                    txtPenaltyAmt.Properties.ReadOnly = true;

                    if (Convert.ToBoolean(dr["MailSent"]))
                    {
                        btnEmail.Enabled = false;
                        txtPenaltyAmt.Properties.ReadOnly = true;
                    }
                    else
                    {
                        btnEmail.Enabled = true;
                        txtPenaltyAmt.Properties.ReadOnly = false;
                    }

                    if (Convert.ToBoolean(dr["DelFlg"]))
                    {
                        lblDeleted.Text = "DELETED";
                        
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnEmail.Enabled = false;
                    }
                    else
                    {
                        lblDeleted.Text = "";
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                    }

                    mode = "OLD";
                    oldCode = dr["ID"].ToString();

                }
            }
            else
            {
                txtTrID.Text = "0";
                txtPenaltyAmt.Properties.ReadOnly = false;
                oldCode = "";
                mode = "NEW";
                
            }

            SetRights();
        }

        private void txtTrID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";
                sql = "Select ID,ViolationDt,ViolationDesc,DefaulterType,DefaulterCode,DefaulterName From ViolationDt Where DelFlg = 0  ";


                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "ID", "ID", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {
                    obj = (List<string>)hlp.Show(sql, "DefaulterName", "DefaulterName", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }

                if (obj.Count == 0)
                {

                    return;
                }
                else if (obj.ElementAt(0).ToString() == "0")
                {
                    return;
                }
                else if (obj.ElementAt(0).ToString() == "")
                {
                    return;
                }
                else
                {

                    txtTrID.Text = obj.ElementAt(0).ToString();
                   

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetCtrl();
            GRights = Safety.Classes.Globals.GetFormRights(this.Name);
            SetRights();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string err = DataValidate();
            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        string sql = "Insert into ViolationDt (ViolationDt,ReasonCode,ReasonDesc,ViolationID," +
                            " ViolationDesc,PenaltyRemark,PenaltyAmt,PenaltyDesc,DefaulterType,DefaulterCode,DefaulterName," +
                            "  SupervisorCode, SupervisorName,Location,TransactionRemark,AddID,HodEmailID,AddDt)  " +
                            " Values ('{0}','{1}','{2}','{3}'," + 
                            " '{4}','{5}','{6}','{7}','{8}','{9}','{10}'," + 
                            " '{11}','{12}','{13}','{14}','{15}','{16}',GetDate())";
                        sql = string.Format(sql,
                            txtTrDate.DateTime.ToString("yyyy-MM-dd"),
                            txtReasonCode.Text.Trim().ToString().ToUpper(),
                            txtReasonDesc.Text.Trim().ToString(),
                            txtViolationID.Text.Trim().ToString(),
                            txtViolationDesc.Text.Trim().ToString(),
                            txtPenaltyRemarks.Text.Trim().ToString(),
                            txtPenaltyAmt.Text.Trim().ToString(),
                            txtPenaltyDesc.Text.Trim().ToString(),
                            txtDefaulterType.Text.Trim().ToString(),
                            txtDefaulterCode.Text.Trim().ToString(),
                            txtDefaulterName.Text.Trim().ToString(),
                            txtSupervisorCode.Text.Trim().ToString(),
                            txtSuperVisorName.Text.Trim().ToString(),
                            txtLocation.Text.Trim().ToString(),
                            txtRemarks.Text.Trim().ToString(),
                            Utils.User.GUserID,
                            txtHodEmail.Text.Trim().ToString()
                            );

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record saved...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetCtrl();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string err = DataValidate();
            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if mail has been sent if yes do not allow to change other details
            //else update all fields

            string isMailSent = Utils.Helper.GetDescription("Select MailSent From ViolationDt where ID = '" + txtTrID.Text.Trim() + "'", Utils.Helper.constr);

            using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        string sql = string.Empty;
                        if (isMailSent == "1")
                        {
                            sql = "Update ViolationDt Set PenaltyCollected = '{0}', UpdDt = GetDate(), UpdID = '{1}' , ActionTaken ='{2}' " +
                                " Where ID = '{3}'  ";

                            sql = string.Format(sql, (chkPenaltyCollected.Checked ? 1 : 0),                                 
                                Utils.User.GUserID, txtTrID.Text.Trim().ToString(),
                                txtActionTaken.Text.Trim().ToString()
                                );

                        }
                        else
                        {
                            
                            if(GRights.Contains("AUDV") || GRights.Contains("AUXV"))
                            {
                                sql = "Update ViolationDt Set " +
                                " ViolationDt = '" + txtTrDate.DateTime.ToString("yyyy-MM-dd") + "'," +
                                " ReasonCode = '" + txtReasonCode.Text.Trim().ToString() + "'," +
                                " ReasonDesc = '" + txtReasonDesc.Text.Trim().ToString() + "'," +
                                " ViolationID = '" + txtViolationID.Text.Trim().ToString() + "'," +
                                " ViolationDesc ='" + txtViolationDesc.Text.Trim().ToString() + "'," +
                                " Location = '" + txtLocation.Text.Trim().ToString() + "'," +
                                " DefaulterType = '" + txtDefaulterType.Text.Trim().ToString() + "'," +
                                " DefaulterCode = '" + txtDefaulterCode.Text.Trim().ToString() + "'," +
                                " DefaulterName ='" + txtDefaulterName.Text.Trim().ToString() + "'," +
                                " SupervisorCode = '" + txtSupervisorCode.Text.Trim().ToString() + "'," +
                                " SupervisorName ='" + txtSuperVisorName.Text.Trim().ToString() + "'," +
                                " PenaltyAmt = '" + txtPenaltyAmt.Text.Trim().ToString() + "'," +
                                " PenaltyDesc =' " + txtPenaltyDesc.Text.Trim().ToString() + "'," +
                                " PenaltyRemark ='" + txtPenaltyRemarks.Text.Trim().ToString() + "'," +
                                " TransactionRemark ='" + txtRemarks.Text.Trim().ToString() + "'," +
                                " HodEmailID ='" + txtHodEmail.Text.Trim().ToString() + "'," +
                                " PenaltyCollected = '" + (chkPenaltyCollected.Checked ? 1 : 0) + "'," +
                                " ActionTaken ='" + txtActionTaken.Text.Trim().ToString() + "'," +
                                " UpdDt = GetDate(), UpdID = '" + Utils.User.GUserID + "'" +
                                " Where ID = '" + txtTrID.Text.Trim().ToString() + "'";
                            }
                            else if (GRights.Contains("XUXV"))
                            {
                                sql = "Update ViolationDt Set PenaltyCollected = '{0}', UpdDt = GetDate(), UpdID = '{1}' , ActionTaken ='{2}' " +
                                " Where ID = '{3}'  ";

                            }
                            
                        }
                        
                        //sql = string.Format(sql, (chkPenaltyCollected.Checked ? 1 : 0), Utils.User.GUserID, txtTrID.Text.Trim().ToString());
                        if (!string.IsNullOrEmpty(sql))
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Updated...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Nothing to Update...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        ResetCtrl();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string err = DataValidate();
            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string isCollected = Utils.Helper.GetDescription("Select PenaltyCollected From ViolationDt where ID = '" + txtTrID.Text.Trim() + "'", Utils.Helper.constr);
            if(isCollected == "1")
            {
                MessageBox.Show("Panelty has been collected, hense system does not allowed to delete.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult ans = MessageBox.Show("Are you sure to Delete this record..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //check if mail has been sent if yes do not allow to change other details
            //else update all fields

            if (ans == DialogResult.Yes)
            {
                using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {
                            cn.Open();
                            cmd.Connection = cn;
                            string sql = string.Empty;
                            
                            sql = "Update ViolationDt Set DelFlg = '{0}', DelDt = GetDate(), DelID = '{1}' " +
                                    " Where ID = '{2}'  ";
                            
                            sql = string.Format(sql, 1, Utils.User.GUserID, txtTrID.Text.Trim().ToString());                            
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Deleted...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCtrl();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Transaction Aborted...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (mode == "NEW")
            {
                MessageBox.Show("Please Save the record first..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult ans = new DialogResult() ;
                           
            ans = MessageBox.Show("Are you sure to send mails..?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            if (ans == DialogResult.No)
            {
                return;
            }

            int t = Convert.ToInt32(txtTrID.Text.Trim().ToString());
            string err;
            bool isSent = sendmail(t,out err);
            
            if(!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if(isSent)
            {
                MessageBox.Show("Email sent" + Environment.NewLine + err,"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private bool sendmail(int violationid,out string err)
        {
            //prepare the mail format
            err = "mail could not be sent...";
            Cursor.Current = Cursors.WaitCursor;

            bool send = false;
            DataSet ds = Utils.Helper.GetData("Select * from V_Safety_Violation where ID ='" + violationid.ToString() + "'", Utils.Helper.constr);
            Boolean hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
            DataRow dr;
            
            if (!hasRows)
            {
                err = "No Records Found..., Please Save first";
                return false;
            
            }else{
                
                dr = ds.Tables[0].Rows[0];

                if(Convert.ToBoolean(dr["MailSent"]))
                {
                    err = "Email is already sent on.." + Convert.ToDateTime(dr["MailSentDt"]).ToString("yyyy-MM-dd HH:mm:ss") + ", can not send again.";
                    return false;
                }

            }

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Classes.Globals.G_EmailConfig.Host);

                mail.From = new MailAddress(Classes.Globals.G_EmailConfig.SenderEMailID);

                 #region Addressing
                if(dr["DefaulterType"].ToString() == "Employee"){

                    var tolist = Classes.Globals.G_EmailConfig.HRER_GrpEmailID.Split(';');
                    foreach (var to in tolist)
                    {
                        if (!string.IsNullOrEmpty(to))
                            mail.To.Add(to.ToString());
                    }

                    if (!string.IsNullOrEmpty(dr["HODEmailID"].ToString()))
                        mail.To.Add(dr["HODEmailID"].ToString());

                }else{

                    var tolist = Classes.Globals.G_EmailConfig.Finance_GrpEmailID.Split(';');
                    foreach (var to in tolist)
                    {
                        if (!string.IsNullOrEmpty(to))
                            mail.To.Add(to.ToString());
                    }
                }
                
                var cclist = Classes.Globals.G_EmailConfig.CCToGrpEmailID.Split(';');
                foreach (var cc in cclist)
                {
                    if (!string.IsNullOrEmpty(cc))
                        mail.CC.Add(cc.ToString());
                }

                var bcclist = Classes.Globals.G_EmailConfig.SenderEMailID.Split(';');
                foreach (var bcc in bcclist)
                {
                    if (!string.IsNullOrEmpty(bcc))
                        mail.Bcc.Add(bcc.ToString());
                }
                #endregion


                mail.Subject = "Notification Safety Violation : " + dr["DefaulterType"].ToString();

                mail.IsBodyHtml = true;
               
                string thead = "<html> " +
                   "<head>" +
                   "<style>" +
                   " table { " +
                       " font-family: arial, sans-serif; " +
                       " border-collapse: collapse; " +
                       " width: 100%; " +
                   "} " +

                   " td, th { " +
                   "    border: 1px solid #dddddd; " +
                   "    text-align: left; " +
                   "    padding: 8px; " +
                   "} " +

                   " tr:nth-child(even) { " +
                   "    background-color: #dddddd;" +
                   "}" +
                   "</style>" +
                   "</head>" +
                   "<body>";

                string tbody = "Sir, <br/><p>" + "Kindly take a necessary action as described below. " + "</p> <br/> <br/> " +
                "<table>" +
                "<tr><td>Sr No: </td><td>" + dr["ID"].ToString() + "</td></tr>" +
                "<tr><td>Defaulter Type : </td><td>" + dr["DefaulterType"].ToString() + "</td></tr>" +
                "<tr><td>Defaulter Code : </td><td>" + dr["DefaulterCode"].ToString() + "</td></tr>" +
                "<tr><td>Defaulter Name : </td><td>" + dr["DefaulterName"].ToString() + "</td></tr>" +
                "<tr><td>Supervisor Code : </td><td>" + dr["SuperVisorCode"].ToString() + "</td></tr>" +
                "<tr><td>Supervisor Name : </td><td>" + dr["SuperVisorName"].ToString()  + "</td></tr>" +
                "<tr><td>Violation Date :</td><td>" + Convert.ToDateTime(dr["ViolationDt"]).ToString("dd/MM/yyyy") + "</td></tr>" +
                "<tr><td>Location :</td><td>" + dr["Location"].ToString() + "</td></tr>" +
                "<tr><td>Violation Type :</td><td>" + dr["ViolationDesc"].ToString() + "</td></tr>" +
                "<tr><td>Violation Desc. :</td><td>" + dr["ReasonDesc"].ToString() + "</td></tr>" +
                "<tr><td>Penalty Remarks :</td><td>" + dr["PenaltyRemark"].ToString() + "</td></tr>" +
                "<tr><td>Penalty Desc. :</td><td>" + dr["PenaltyDesc"].ToString() + "</td></tr>" +
                "<tr><td>Penalty Amount :</td><td>" + dr["PenaltyAmt"].ToString() + "</td></tr>" +
                "<tr><td>Remark :</td><td>" + dr["TransactionRemark"].ToString() + "</td></tr>" +
                "</table><br/><br/> " +
                "</body></html>";
     

                mail.Body = thead + tbody;

                SmtpServer.Port = Classes.Globals.G_EmailConfig.Port;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Classes.Globals.G_EmailConfig.AccountUser, Classes.Globals.G_EmailConfig.AccountPass);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Mail Send");
                send = true;

                using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            string sql = "Update ViolationDT set MailSent = 1, [MailSentDt] = GetDate() Where ID = '" + dr["ID"].ToString() + "'";
                            cmd.CommandText = sql;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        err = "Error while saving mail sent staus " + ex.ToString();

                    }
                    
                }

            }
            catch (Exception ex)
            {
               err = ex.ToString();
            }

            return send;

        }

        private void txtDefaulterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDefaulterType.Text.Trim()))
            {
                MessageBox.Show("Please Select defaulter type..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "";
            string cnstr = "";
            if (txtDefaulterType.Text.Trim().ToString() == "Employee")
            {
                sql = "Select EmpUnqID ,EmpName ,WrkGrp,EmpCode from MastEmp where Active = 1";
                cnstr = "Data Source = 172.16.12.47;Initial Catalog=Attendance;User ID=attd;Password=attd123;";
            }
            else
            {
                sql = "Select VendorCode,VendorName from MastVendor where 1 = 1";
                cnstr = Utils.Helper.constr;
            }

            
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();


                if (e.KeyCode == Keys.F1)
                {
                    if (txtDefaulterType.Text.Trim().ToString() == "Employee")
                    {
                        obj = (List<string>)hlp.Show(sql, "EmpUnqID", "EmpUnqID", typeof(string), cnstr, "System.Data.SqlClient",
                       100, 300, 400, 600, 100, 100);
                    }
                    else
                    {
                        obj = (List<string>)hlp.Show(sql, "VendorCode", "VendorCode", typeof(string), cnstr, "System.Data.SqlClient",
                       100, 300, 400, 600, 100, 100);
                    }
                }
                else
                {
                    if (txtDefaulterType.Text.Trim().ToString() == "Employee")
                    {
                        obj = (List<string>)hlp.Show(sql, "EmpUnqID", "EmpUnqID", typeof(string), cnstr, "System.Data.SqlClient",
                       100, 300, 400, 600, 100, 100);
                    }
                    else
                    {
                        obj = (List<string>)hlp.Show(sql, "VendorCode", "VendorCode", typeof(string), cnstr, "System.Data.SqlClient",
                       100, 300, 400, 600, 100, 100);
                    }
                }

                if (obj.Count == 0)
                {

                    return;
                }
                else if (obj.ElementAt(0).ToString() == "0")
                {
                    return;
                }
                else if (obj.ElementAt(0).ToString() == "")
                {
                    return;
                }
                else
                {

                    txtDefaulterCode.Text = obj.ElementAt(0).ToString();
                    txtDefaulterName.Text = obj.ElementAt(1).ToString();

                }
            }
        }

        private void txtSupervisorCode_KeyDown(object sender, KeyEventArgs e)
        {

            string sql = "";
            string cnstr = "Data Source = 172.16.12.47;Initial Catalog=Attendance;User ID=attd;Password=attd123;";
            
            sql = "Select EmpUnqID ,EmpName ,WrkGrp,EmpCode from MastEmp where Active = 1 and WrkGrp = 'Comp'";
            
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();


                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "EmpUnqID", "EmpUnqID", typeof(string), cnstr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {

                    obj = (List<string>)hlp.Show(sql, "EmpName", "EmpName", typeof(string), cnstr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }

                if (obj.Count == 0)
                {

                    return;
                }
                else if (obj.ElementAt(0).ToString() == "0")
                {
                    txtSupervisorCode.Text = "";
                    txtSuperVisorName.Text = "";
                    return;
                }
                else if (obj.ElementAt(0).ToString() == "")
                {
                    txtSupervisorCode.Text = "";
                    txtSuperVisorName.Text = "";

                    return;
                }
                else
                {

                    txtSupervisorCode.Text = obj.ElementAt(0).ToString();
                    txtSuperVisorName.Text = obj.ElementAt(1).ToString();

                }
            }
        }

        private void txtDefaulterType_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDefaulterType.Text.Trim().ToString()))
            {
                if (txtDefaulterType.Text.Trim().ToString() == "Vendor")
                {
                    txtHodEmail.Text = "";
                    txtSupervisorCode.Text = "";
                    txtSuperVisorName.Text = "";
                }
            }
        }
    }
}
