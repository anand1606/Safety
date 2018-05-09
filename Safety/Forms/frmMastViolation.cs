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

namespace Safety.Forms
{
    public partial class frmMastViolation: Form
    {
        public string mode = "NEW";
        public string GRights = "XXXV";
        public string oldCode = "";

        public frmMastViolation()
        {
            InitializeComponent();
        }

        private void frmMastViolation_Load(object sender, EventArgs e)
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

            return err;
        }
        
        private void ResetCtrl()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            
            object s = new object();
            EventArgs e = new EventArgs();
          
            txtReasonCode.Text = "";
            txtReasonDesc.Text = "";
            txtPenaltyAmt.Text = "";
            
            txtPenaltyDesc.Text = "";
            txtRemarks.Text = "";
            txtViolationID.Text = "";
            txtViolationDesc.Text = "";

            oldCode = "";
        }

        private void SetRights()
        {
            if ( txtReasonCode.Text.Trim() != "" && mode == "NEW" && GRights.Contains("A") )
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (txtReasonCode.Text.Trim() != "" && mode == "OLD")
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
            using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        cn.Open();
                        cmd.Connection = cn;
                        string sql = "Insert into MastReason (ReasonCode,ReasonDesc,PenaltyAmt,AddDt,AddID,ViolatoinID,Remarks,PenaltyDesc,Remarks) " + 
                            " Values ('{0}','{1}','{2}',GetDate(),'{3}','{4}','{5}','{6}','{7}')";
                        sql = string.Format(sql,
                            txtReasonCode.Text.Trim().ToString().ToUpper(),
                            txtReasonDesc.Text.Trim().ToString(),
                            txtPenaltyAmt.Text.Trim().ToString(),                           
                            Utils.User.GUserID,
                            txtViolationID.Text.Trim().ToString(),
                            txtRemarks.Text.Trim().ToString(),
                            txtPenaltyDesc.Text.Trim().ToString(),
                            txtRemarks.Text.Trim().ToString()                            
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
                        string sql = "Update MastReason Set ReasonDesc = '{0}', PenaltyAmt ='{1}', UpdDt = GetDate(), UpdID = '{2}' " +
                            " ,ViolationID = '{3}' , PenaltyDesc = '{4}', Remarks = '{5}' " +
                            " Where ReasonCode = '{6}' ";

                        sql = string.Format(sql, txtReasonDesc.Text.ToString(),
                             txtPenaltyAmt.Text.Trim().ToString(),
                             Utils.User.GUserID,  
                             txtViolationID.Text.Trim().ToString(),
                             txtPenaltyDesc.Text.Trim().ToString(),
                             txtRemarks.Text.Trim().ToString(),
                             txtReasonCode.Text.Trim()

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
                    txtPenaltyAmt.Text = dr["PenaltyAmt"].ToString();
                    txtViolationID.Text = dr["ViolationID"].ToString();
                    txtViolationID_Validated(sender, e);

                    txtRemarks.Text = dr["Remarks"].ToString();
                    txtPenaltyDesc.Text = dr["PenaltyDesc"].ToString();


                    mode = "OLD";
                    oldCode =  dr["ReasonCode"].ToString();

                }
            }
            else
            {
                mode = "NEW";
            }

            SetRights();
        }

        private void txtViolationID_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";
                sql = "Select ViolationID,ViolationDesc From MastViolation Where 1 =1 ";


                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "ViolationID", "ViolationID", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {

                    obj = (List<string>)hlp.Show(sql, "ViolationDesc", "ViolationDesc", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
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

                    txtViolationID.Text = obj.ElementAt(0).ToString();
                    txtViolationDesc.Text = obj.ElementAt(1).ToString();

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

    }
}
