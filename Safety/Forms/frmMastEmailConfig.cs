using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Safety.Classes;

namespace Safety.Forms
{
    public partial class frmMastEmailConfig: Form
    {
        public string mode = "NEW";
        public string GRights = "XXXV";
        public string oldCode = "";

        public frmMastEmailConfig()
        {
            InitializeComponent();
        }

        private void frmMastEmailConfig_Load(object sender, EventArgs e)
        {
            ResetCtrl();
            GRights = Safety.Classes.Globals.GetFormRights(this.Name);
            SetRights();

            bool temail = Globals.SetEmailConfig();
            if (temail)
            {
                txtEmailID.Text = Globals.G_EmailConfig.SenderEMailID;
                txtEmailAccount.Text = Globals.G_EmailConfig.AccountUser;
                txtAccountPassword.Text = Globals.G_EmailConfig.AccountPass;
                txtSMTPHost.Text = Globals.G_EmailConfig.Host;
                txtSMTPPort.Text = Globals.G_EmailConfig.Port.ToString();
                
                txtHRSentTo.Text = Globals.G_EmailConfig.HRER_GrpEmailID;
                txtFinSentTo.Text = Globals.G_EmailConfig.Finance_GrpEmailID;
                txtCCTo.Text = Globals.G_EmailConfig.CCToGrpEmailID;
                
            }
        }

        private string DataValidate()
        {
            string err = string.Empty;

           

            if (string.IsNullOrEmpty(txtEmailAccount.Text))
            {
                err = err + "Please Enter Cont Code" + Environment.NewLine;
            }
           
            if (string.IsNullOrEmpty(txtAccountPassword.Text))
            {
                err = err + "Please Enter Contractor Name" + Environment.NewLine;
            }
            
            return err;
        }
        
        private void ResetCtrl()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            
            object s = new object();
            EventArgs e = new EventArgs();
          
            txtEmailAccount.Text = "";
            txtAccountPassword.Text = "";
            txtSMTPHost.Text = "";
            txtEmailID.Text = "";
            txtFinSentTo.Text = "";
            txtHRSentTo.Text = "";
            txtEmailID.Text = "";
            txtSMTPPort.Text = "";
            txtCCTo.Text = "";
            oldCode = "";
        }

        private void SetRights()
        {
            if ( txtEmailAccount.Text.Trim() != "" && mode == "NEW" && GRights.Contains("A") )
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (txtEmailAccount.Text.Trim() != "" && mode == "OLD")
            {
                btnAdd.Enabled = false;
                if(GRights.Contains("U"))
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
        }
        
       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string err = DataValidate();
            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cnt = Convert.ToInt32(Utils.Helper.GetDescription("Select isnull(Count(*),0) From EmailConfig", Utils.Helper.constr));

            if (cnt > 0)
            {
                MessageBox.Show("Only One Account can be permissable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string sql = "Insert into EMailConfig ( EmailAccount,AccountPassword,EmailID,smtpHost,smtpport,SentFinanceTo,SentHRTo,AddDt,AddID,SentCCto) Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',GetDate(),'{7}','{8}')";
                        sql = string.Format(sql,
                            txtEmailAccount.Text.Trim().ToString().ToUpper(),
                            txtAccountPassword.Text.Trim().ToString(),
                            txtEmailID.Text.Trim().ToString(),
                            txtSMTPHost.Text.Trim().ToString(),
                            txtSMTPPort.Text.Trim().ToString(),
                            txtFinSentTo.Text.Trim().ToString(),
                            txtHRSentTo.Text.Trim().ToString(),
                            Utils.User.GUserID,
                            txtCCTo.Text.Trim().ToString()
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

            using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        string sql = "Update EMailConfig Set AccountPassword = '{0}', EmailID='{1}',smtpHost='{2}',smtpport='{3}', SentFinanceTo = '{4}', SentHRTo = '{5}' , UpdDt = GetDate(), UpdID = '{6}' , SentCCTo = '{7}' " +
                            " Where EmailAccount = '{7}' ";

                        sql = string.Format(sql, txtAccountPassword.Text.ToString(),                             
                             txtEmailID.Text.Trim().ToString(),
                             txtSMTPHost.Text.Trim().ToString(),
                             txtSMTPPort.Text.Trim().ToString(),
                             txtFinSentTo.Text.Trim().ToString(),
                             txtHRSentTo.Text.Trim().ToString(),
                             Utils.User.GUserID,  txtEmailAccount.Text.Trim(),
                             txtCCTo.Text.Trim().ToString()

                           );

                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record Updated...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            MessageBox.Show("Not Implemented...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                
        private void txtEmailAccount_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";

                sql = "Select EmailAccount,EmailID From EmailConfig Where 1 =1 ";
               
                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "EmailAccount", "EmailAccount", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {

                    obj = (List<string>)hlp.Show(sql, "EmailID", "EmailID", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
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

                    txtEmailAccount.Text = obj.ElementAt(0).ToString();
                    txtAccountPassword.Text = obj.ElementAt(1).ToString();

                }
            }
        }
        
        private void txtEmailAccount_Validated(object sender, EventArgs e)
        {


            txtEmailAccount.Text = txtEmailAccount.Text.Trim().ToString();

            DataSet ds = new DataSet();
            string sql = "select * From EMailConfig where EmailAccount ='" + txtEmailAccount.Text.Trim() + "' ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>()
                           .Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    txtEmailAccount.Text = dr["EmailAccount"].ToString();
                    txtAccountPassword.Text = dr["AccountPassword"].ToString();
                    txtSMTPHost.Text = dr["smtpHost"].ToString();
                    txtEmailID.Text = dr["EmailID"].ToString();
                    txtFinSentTo.Text = dr["SentFinanceTo"].ToString();
                    txtHRSentTo.Text = dr["SentHRTo"].ToString();
                    txtSMTPPort.Text = dr["smtpport"].ToString();
                    txtCCTo.Text = dr["SentCCTo"].ToString();
                    mode = "OLD";
                    oldCode = dr["EmailAccount"].ToString();

                }
            }
            else
            {
                mode = "NEW";
            }

            SetRights();
        }

       

    }
}
