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
    public partial class frmMastVendor: Form
    {
        public string mode = "NEW";
        public string GRights = "XXXV";
        public string oldCode = "";

        public frmMastVendor()
        {
            InitializeComponent();
        }

        private void frmMastVendor_Load(object sender, EventArgs e)
        {
            ResetCtrl();
            GRights = Safety.Classes.Globals.GetFormRights(this.Name);
            SetRights();            
        }

        private string DataValidate()
        {
            string err = string.Empty;

           

            if (string.IsNullOrEmpty(txtVendorCode.Text))
            {
                err = err + "Please Enter Cont Code" + Environment.NewLine;
            }
           
            if (string.IsNullOrEmpty(txtVendorName.Text))
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
          
            txtVendorCode.Text = "";
            txtVendorName.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtPhone.Text = "";
            oldCode = "";
        }

        private void SetRights()
        {
            if ( txtVendorCode.Text.Trim() != "" && mode == "NEW" && GRights.Contains("A") )
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (txtVendorCode.Text.Trim() != "" && mode == "OLD")
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
                        string sql = "Insert into MastVendor (VendorCode,VendorName,Add1,Add2,Phone,AddDt,AddID) Values ('{0}','{1}','{2}','{3}','{4}',GetDate(),'{5}')";
                        sql = string.Format(sql,
                            txtVendorCode.Text.Trim().ToString().ToUpper(),
                            txtVendorName.Text.Trim().ToString(),
                            txtAdd1.Text.Trim().ToString(),
                            txtAdd2.Text.Trim().ToString(),
                            txtPhone.Text.Trim().ToString(),
                            Utils.User.GUserID);

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
                        string sql = "Update MastVendor Set VendorName = '{0}',Add1='{1}',Add2='{2}',Phone='{3}', UpdDt = GetDate(), UpdID = '{4}' " +
                            " Where VendorCode = '{5}' ";

                        sql = string.Format(sql, txtVendorName.Text.ToString(),
                             txtAdd1.Text.Trim().ToString(),
                             txtAdd2.Text.Trim().ToString(),
                             txtPhone.Text.Trim().ToString(),
                             Utils.User.GUserID,  txtVendorCode.Text.Trim()

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

       
        
        private void txtVendorCode_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";

                sql = "Select VendorCode,VendorName From MastVendor Where 1 =1 ";
               
                if (e.KeyCode == Keys.F1)
                {
                   
                    obj = (List<string>)hlp.Show(sql, "VendorCode", "VendorCode", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {
                  
                    obj = (List<string>)hlp.Show(sql, "VendorName", "VendorName", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
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

                    txtVendorCode.Text = obj.ElementAt(0).ToString();
                    txtVendorName.Text = obj.ElementAt(1).ToString();

                }
            }
        }
        
        private void txtVendorCode_Validated(object sender, EventArgs e)
        {


            txtVendorCode.Text = txtVendorCode.Text.Trim().ToString();

            DataSet ds = new DataSet();
            string sql = "select * From MastVendor where VendorCode ='" + txtVendorCode.Text.Trim() + "' ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>()
                           .Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                   
                    txtVendorCode.Text = dr["VendorCode"].ToString();
                    txtVendorName.Text = dr["VendorName"].ToString();
                    txtAdd1.Text = dr["Add1"].ToString();
                    txtAdd2.Text = dr["Add2"].ToString();
                    txtPhone.Text = dr["Phone"].ToString();
                    mode = "OLD";
                    oldCode =  dr["VendorCode"].ToString();

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
