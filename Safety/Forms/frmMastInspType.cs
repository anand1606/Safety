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
    public partial class frmMastInspType: Form
    {
        public string mode = "NEW";
        public string GRights = "XXXV";
        public string oldCode = "";

        public frmMastInspType()
        {
            InitializeComponent();
        }

        private void frmMastInspType_Load(object sender, EventArgs e)
        {
            ResetCtrl();
            GRights = Safety.Classes.Globals.GetFormRights(this.Name);
            SetRights();            
        }

        private string DataValidate()
        {
            string err = string.Empty;

           

            if (string.IsNullOrEmpty(txtInspTypeCode.Text))
            {
                err = err + "Please Enter Cont Code" + Environment.NewLine;
            }
           
            if (string.IsNullOrEmpty(txtInspTypeDesc.Text))
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
          
            txtInspTypeCode.Text = "";
            txtInspTypeDesc.Text = "";
           
            oldCode = "";
        }

        private void SetRights()
        {
            if ( txtInspTypeCode.Text.Trim() != "" && mode == "NEW" && GRights.Contains("A") )
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (txtInspTypeCode.Text.Trim() != "" && mode == "OLD")
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
                        string sql = "Insert into MastInspType (InspTypeCode,InspDesc,AddDt,AddID) Values ('{0}','{1}',GetDate(),'{2}')";
                        sql = string.Format(sql,
                            txtInspTypeCode.Text.Trim().ToString().ToUpper(),
                            txtInspTypeDesc.Text.Trim().ToString(),
                           
                           
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
                        string sql = "Update MastInspType Set InspDesc = '{0}',  UpdDt = GetDate(), UpdID = '{1}' " +
                            " Where InspTypeCode = '{2}' ";

                        sql = string.Format(sql, txtInspTypeDesc.Text.ToString(),
                             Utils.User.GUserID,  txtInspTypeCode.Text.Trim()

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

       
        
        private void txtInspTypeCode_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";
                sql = "Select InspTypeCode,InspDesc From MastInspType Where 1 =1 ";

               
                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "InspTypeCode", "InspTypeCode", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {

                    obj = (List<string>)hlp.Show(sql, "InspDesc", "InspDesc", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
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

                    txtInspTypeCode.Text = obj.ElementAt(0).ToString();
                    txtInspTypeDesc.Text = obj.ElementAt(1).ToString();

                }
            }
        }
        
        private void txtInspTypeCode_Validated(object sender, EventArgs e)
        {


            txtInspTypeCode.Text = txtInspTypeCode.Text.Trim().ToString();

            DataSet ds = new DataSet();
            string sql = "select * From MastInspType where  InspTypeCode ='" + txtInspTypeCode.Text.Trim() + "' ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>()
                           .Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                   
                    txtInspTypeCode.Text = dr["InspTypeCode"].ToString();
                    txtInspTypeDesc.Text = dr["InspDesc"].ToString();
                                   
                    mode = "OLD";
                    oldCode =  dr["InspTypeCode"].ToString();

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
