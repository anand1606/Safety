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
    public partial class frmMastTools: Form
    {
        public string mode = "NEW";
        public string dmode = "NEW";
        public string GRights = "XXXV";
        public string oldCode = "";

        public frmMastTools()
        {
            InitializeComponent();
        }

        private void frmMastTools_Load(object sender, EventArgs e)
        {
            ResetCtrl();
            GRights = Safety.Classes.Globals.GetFormRights(this.Name);
            SetRights();            
        }

        private string DataValidate()
        {
            string err = string.Empty;

            if (mode == "NEW")
            {
                string newid = Utils.Helper.GetDescription("Select isnull(Max(ToolsID),0) + 1 From MastToolsHd Where 1=1", Utils.Helper.constr);
                if (!string.IsNullOrEmpty(newid))
                {
                    txtToolsID.Text = newid;
                    txtToolsID2.Text = newid;
                }
            }

            if (string.IsNullOrEmpty(txtToolsID.Text))
            {
                err = err + "Please Enter Tools ID" + Environment.NewLine;
            }
           
            if (string.IsNullOrEmpty(txtToolsName.Text))
            {
                err = err + "Please Enter Tools Name" + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtTypeofTools.Text))
            {
                err = err + "Please Enter Type of Tools.." + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtFormNo.Text))
            {
                err = err + "Please Enter FormNo.." + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtReportNo.Text))
            {
                err = err + "Please Enter Report Number.." + Environment.NewLine;
            }


            if (string.IsNullOrEmpty(txtRespPerson.Text))
            {
                err = err + "Please Enter Responsible Person Name.." + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtRespEmail.Text))
            {
                err = err + "Please Enter Responsible Person Email ID.." + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtPlant.Text))
            {
                err = err + "Please Enter Plant Name.." + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtDept.Text))
            {
                err = err + "Please Enter Department.." + Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtLocation.Text))
            {
                err = err + "Please Enter Location.." + Environment.NewLine;
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
          
            txtToolsID.Text = "";
            txtToolsName.Text = "";
            txtTypeofTools.Text = "";
            txtCapacity.Text = "";

            txtDept.Text = "";
            txtPlant.Text = "";
            txtLocation.Text = "";
            txtReportNo.Text = "";
            
            txtFormNo.Text = "";
            txtRespPerson.Text = "";
            txtRespEmail.Text = "";
            txtRemarks.Text = "";
            ResetCtrl2();
            grd_Details.DataSource = null;
           
            mode = "NEW";
            oldCode = "";
        }

        private void ResetCtrl2()
        {
            txtSrNo.Text = "";
            txtInspTypeID.Text = "";
            txtInspTypeDesc.Text = "";
            txtLastInspDt.EditValue = null;
            txtActInspDt.EditValue = null;
            txtDueInspDt.EditValue = null;
            txtToolsID2.Text = "";            
            txtCertRecFrom.Text = "";
            txtRemarks2.Text = "";

            chkIsDue.Checked = true;

            txtSrNo.Enabled = true;
            txtLastInspDt.Enabled = true;
            txtInspTypeID.Enabled = true;
            txtInspTypeDesc.Enabled = true;
            txtDueInspDt.Enabled = true;

            chkIsDue.Enabled = false;
            txtCertRecFrom.Enabled = false;
            txtActInspDt.Enabled = false;
        }


        private void SetRights()
        {
            if ( txtToolsID.Text.Trim() != "" && mode == "NEW" && GRights.Contains("A") )
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else if (txtToolsID.Text.Trim() != "" && mode == "OLD")
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
                        string sql = "Insert into MastToolsHD (ToolsID,ToolsName,TypeofTools,Capacity," +
                            " DeptName,PlantName,Location,ReportNo," +
                            " FormNo,RespPerson,RespEmailID, Remarks," + 
                            " AddDt,AddID) " + 
                            " Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}', GetDate(),'{12}')";
                        sql = string.Format(sql,
                            txtToolsID.Text.Trim().ToString().ToUpper(),                            
                            txtToolsName.Text.Trim().ToString().ToUpper(),
                            txtTypeofTools.Text.Trim().ToString().ToUpper(),
                            txtCapacity.Text.Trim().ToString().ToUpper(),
                            txtDept.Text.Trim().ToString().ToUpper(),
                            txtPlant.Text.Trim().ToString().ToUpper(),
                            txtLocation.Text.Trim().ToString().ToUpper(),
                            txtReportNo.Text.Trim().ToString().ToUpper(),            
                            txtFormNo.Text.Trim().ToString().ToUpper(),
                            txtRespPerson.Text.Trim().ToString().ToUpper(),
                            txtRespEmail.Text.Trim().ToString().ToUpper(),
                            txtRemarks.Text.Trim().ToString().ToUpper(),
                            Utils.User.GUserID
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
                        string sql = "Update MastToolsHD Set ToolsName = '{0}'," +
                            " TypeofTools = '{1}', Capacity = '{2}'," +
                            " DeptName = '{3}',PlantName = '{4}',Location = '{5}', ReportNo = '{6}'," +
                            " FormNo = '{7}' ,RespPerson = '{8}' ,RespEmailID = '{9}', Remarks = '{10}', " +
                            " UpdDt = GetDate(), UpdID = '{11}' Where ToolsID = '{12}'";
                        
                        sql = string.Format(sql, 
                             txtToolsName.Text.Trim().ToString().ToUpper(),
                            txtTypeofTools.Text.Trim().ToString().ToUpper(),
                            txtCapacity.Text.Trim().ToString().ToUpper(),
                            txtDept.Text.Trim().ToString().ToUpper(),
                            txtPlant.Text.Trim().ToString().ToUpper(),
                            txtLocation.Text.Trim().ToString().ToUpper(),
                            txtReportNo.Text.Trim().ToString().ToUpper(),            
                            txtFormNo.Text.Trim().ToString().ToUpper(),
                            txtRespPerson.Text.Trim().ToString().ToUpper(),
                            txtRespEmail.Text.Trim().ToString().ToUpper(),
                            txtRemarks.Text.Trim().ToString().ToUpper(),
                            Utils.User.GUserID,
                            txtToolsID.Text.Trim()
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
            string err = string.Empty;
            if (!string.IsNullOrEmpty(txtToolsID.Text.Trim()))
            {
                MessageBox.Show("Please Select Tools ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mode != "OLD")
            {
                return;
            }

            DialogResult dr = MessageBox.Show("Are You Sure to Delete This Tools ?", "Question", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string sql = "Delete From MastToolsHD where ToolsID ='" + txtToolsID.Text.Trim() + "'";
                        
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        sql = "Delete From MastToolsDT Where ToolsID = '" + txtToolsID.Text.Trim() + "'";
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();


                        MessageBox.Show("Record Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;


                    }

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

       
        private void txtToolsID_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";
                sql = "Select ToolsID,ToolsName,PlantName,DeptName From MastToolsHD Where 1 = 1 ";

               
                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "ToolsID", "ToolsID", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {

                    obj = (List<string>)hlp.Show(sql, "ToolsName", "ToolsName", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
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

                    txtToolsID.Text = obj.ElementAt(0).ToString();
                    //txtReasonDesc.Text = obj.ElementAt(1).ToString();

                }
            }
        }
        
        private void txtToolsID_Validated(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtToolsID.Text.Trim().ToString()))
            {
                oldCode = "";
                 mode = "NEW";
                 SetRights();
                return;
            }

            txtToolsID.Text = txtToolsID.Text.Trim().ToString();

            DataSet ds = new DataSet();
            string sql = "select * From MastToolsHD where  ToolsID ='" + txtToolsID.Text.Trim() + "' ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                   
                    txtToolsID.Text = dr["ToolsID"].ToString();
                    txtToolsID2.Text = dr["ToolsID"].ToString();

                    txtToolsName.Text = dr["ToolsName"].ToString();
                    txtTypeofTools.Text = dr["TypeofTools"].ToString();
                    txtCapacity.Text = dr["Capacity"].ToString();

                    txtDept.Text = dr["DeptName"].ToString();
                    txtPlant.Text = dr["PlantName"].ToString();
                    txtLocation.Text = dr["Location"].ToString();
                    
                    txtReportNo.Text = dr["ReportNo"].ToString();
                    txtFormNo.Text = dr["FormNo"].ToString();


                    
                    txtRespPerson.Text = dr["RespPerson"].ToString();
                    txtRespEmail.Text = dr["RespEmailID"].ToString();
                    txtRemarks.Text = dr["Remarks"].ToString();

                    LoadGrid();

                    mode = "OLD";
                    oldCode =  dr["ToolsID"].ToString();

                }
            }
            
            SetRights();
        }

        private void txtInspTypeID_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";
                sql = "Select InspTypeID,InspTypeDesc From MastInspType Where 1 =1 ";


                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "InspTypeID", "InspTypeID", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {

                    obj = (List<string>)hlp.Show(sql, "InspTypeDesc", "InspTypeDesc", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
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

                    txtInspTypeID.Text = obj.ElementAt(0).ToString();
                    txtInspTypeDesc.Text = obj.ElementAt(1).ToString();

                }
            }
        }

        private void txtInspTypeID_Validated(object sender, EventArgs e)
        {

            txtInspTypeID.Text = txtInspTypeID.Text.Trim().ToString();

            DataSet ds = new DataSet();
            string sql = "select * From MastInspType where  InspTypeID ='" + txtInspTypeID.Text.Trim() + "' ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>()
                           .Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    txtInspTypeID.Text = dr["InspTypeID"].ToString();
                    txtInspTypeDesc.Text = dr["InspTypeDesc"].ToString();
                    

                }
            }
           
        }

        private void txtSrNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(string.IsNullOrEmpty(txtToolsID.Text.Trim()))
            {
                MessageBox.Show("Please Save record first, than enter inspection types", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";
                sql = "Select SrNo,InspTypeDesc,ToolsID From V_Tools_Insp_History Where ToolsID = '" + txtToolsID.Text.Trim() + "'";


                if (e.KeyCode == Keys.F1)
                {

                    obj = (List<string>)hlp.Show(sql, "SrNo", "SrNo", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }
                else
                {

                    obj = (List<string>)hlp.Show(sql, "InspTypeDesc", "InspTypeDesc", typeof(string), Utils.Helper.constr, "System.Data.SqlClient",
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

                    txtSrNo.Text = obj.ElementAt(0).ToString();
                    
                }
            }
        }

        private void txtSrNo_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSrNo.Text.Trim()))
            {
                //ResetCtrl2();
                dmode = "NEW";
                return;
            }

            DataSet ds = new DataSet();
            string sql = "select * From V_Tools_Insp_History where  ToolsID ='" + txtToolsID.Text.Trim() + "' and SrNo = '" + txtSrNo.Text.Trim().ToString() + "' Order By SrNo ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);

            if (hasRows)
            {   
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    
                    txtInspTypeID.Text = dr["InspTypeID"].ToString();
                    txtInspTypeDesc.Text = dr["InspTypeDesc"].ToString() ;
                    txtCertRecFrom.Text = dr["CertRecFrom"].ToString();
                    txtRemarks2.Text = dr["Remarks"].ToString();

                    chkIsDue.Checked = Convert.ToBoolean(dr["InspDue"]);

                    if (dr["LastInspDt"] != DBNull.Value)
                    {
                        txtLastInspDt.DateTime = Convert.ToDateTime(dr["LastInspDt"]);
                    }
                    else
                    {
                        txtLastInspDt.EditValue = null;
                    }
                    
                    if (dr["ActInspDt"] != DBNull.Value)
                    {
                        txtActInspDt.DateTime = Convert.ToDateTime(dr["ActInspDt"]);
                    }
                    else
                    {
                        txtActInspDt.EditValue = null;
                    }
                    if (dr["DueInspDt"] != DBNull.Value)
                    {
                        txtDueInspDt.DateTime = Convert.ToDateTime(dr["DueInspDt"]);
                    }
                    else
                    {
                        txtDueInspDt.EditValue = null;
                    }
                    
                    dmode = "OLD";

                    txtSrNo.Enabled = false;
                    txtLastInspDt.Enabled = false;
                    txtInspTypeID.Enabled = false;
                    txtInspTypeDesc.Enabled = false;
                    
                    txtDueInspDt.Enabled = true;
                    chkIsDue.Enabled = true;
                    txtCertRecFrom.Enabled = true;
                    txtActInspDt.Enabled = true;

                }
            }
            else
            {
                dmode = "NEW";

                txtSrNo.Enabled = true;
                txtLastInspDt.Enabled = true;
                txtInspTypeID.Enabled = true;
                txtInspTypeDesc.Enabled = true;
                txtDueInspDt.Enabled = true;
                
                chkIsDue.Enabled = false;
                txtCertRecFrom.Enabled = false;
                txtActInspDt.Enabled = false;

            }
           
            
        }

        private void btnAddInsp_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            
            if (dmode == "NEW")
            {
                err = DataValidate2("NEW");
            }
            else
            {
                err = DataValidate2("OLD");
            }

            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dmode == "NEW")
            {
                using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {
                            cn.Open();
                            cmd.Connection = cn;
                            string sql = "Insert into MastToolsDT (ToolsID,SrNo,InspTypeID,LastInspDt,DueInspDt,AddDt,AddID,InspDue) " +
                                " Values ('{0}','{1}','{2}','{3}','{4}', GetDate(),'{5}','{6}','{7}')";
                            sql = string.Format(sql,
                                txtToolsID.Text.Trim().ToString().ToUpper(),
                                txtSrNo.Text.Trim().ToString().ToUpper(),
                                txtInspTypeID.Text.Trim().ToString().ToUpper(),
                                txtLastInspDt.DateTime.ToString("yyyy-MM-dd"),
                                txtDueInspDt.DateTime.ToString("yyyy-MM-dd"),
                                Utils.User.GUserID,
                                1,
                                txtRemarks2.Text.Trim().ToString()
                                );

                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record saved...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCtrl2();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if (dmode == "OLD")
            {
                bool PreStatus = true;
                bool NewStatus = chkIsDue.Checked;
               

                using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {

                            string sql = string.Empty;                            
                            cn.Open();
                            cmd.Connection = cn;
                            
                            //get the previous status of inspDue
                             DataSet PreDs = Utils.Helper.GetData("Select * From MastToolsDt Where ToolsID ='" + txtToolsID.Text.Trim().ToString() + "' and SrNo ='" + txtSrNo.Text.Trim() + "'", Utils.Helper.constr);
                             bool hasRows = PreDs.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);

                             if (hasRows)
                             {
                                 foreach (DataRow dr in PreDs.Tables[0].Rows)
                                 {
                                     PreStatus = Convert.ToBoolean(dr["InspDue"]);
                                 }
                             }
                             else
                             {
                                 dmode = "NEW";
                                 ResetCtrl2();
                                 return;
                             }


                             if (PreStatus && NewStatus)
                             {
                                 sql = "Update MastToolsDT set DueInspDt = '{0}' , " +
                                " CertRecFrom ='{1}', ActInspDt = '{2}' , Remarks = '{3}',   UpdDt = GetDate(), UpdID = '{4}' Where ToolsID = '{5}' and SrNo = '{6}' ";
                                 sql = string.Format(sql,
                                     txtToolsID.Text.Trim().ToString().ToUpper(),
                                     txtSrNo.Text.Trim().ToString().ToUpper(),
                                     txtDueInspDt.DateTime.ToString("yyyy-MM-dd"),
                                     txtCertRecFrom.Text.Trim(),
                                     txtActInspDt.DateTime.ToString("yyyy-MM-dd"),
                                     txtRemarks2.Text.Trim().ToString(),
                                     Utils.User.GUserID,
                                     txtToolsID2.Text.Trim().ToString(),
                                     txtSrNo.Text.Trim().ToString()
                                  );

                                 cmd.CommandText = sql;
                                 cmd.ExecuteNonQuery();
                                 dmode = "NEW";

                             }
                             else if (PreStatus && NewStatus == false)
                             {
                                 sql = "Update MastToolsDT set DueInspDt = '{0}' , " +
                                    " CertRecFrom ='{1}', ActInspDt = '{2}' , Remarks='{3}', UpdDt = GetDate(), UpdID = '{4}', InspDue ='{5}'  Where ToolsID = '{6}' and SrNo = '{7}' ";
                                 sql = string.Format(sql,
                                     txtDueInspDt.DateTime.ToString("yyyy-MM-dd"),
                                     txtCertRecFrom.Text.Trim(),
                                     txtActInspDt.DateTime.ToString("yyyy-MM-dd"),
                                     txtRemarks2.Text.Trim().ToString(),
                                     Utils.User.GUserID,
                                     0,
                                     txtToolsID2.Text.Trim().ToString(),
                                     txtSrNo.Text.Trim().ToString()
                                  );

                                 cmd.CommandText = sql;
                                 cmd.ExecuteNonQuery();

                                 double NextDue = (txtDueInspDt.DateTime - txtLastInspDt.DateTime).TotalDays;
                                 //insert new record with pending status
                                 //get new srno

                                 string newid = Utils.Helper.GetDescription("Select isnull(Max(SrNo),0) + 1 From MastToolsDT Where ToolsID='" + txtToolsID2.Text.Trim() + "'", Utils.Helper.constr);
                                 if (!string.IsNullOrEmpty(newid))
                                 {
                                     sql = "Insert into MastToolsDT (ToolsID,SrNo,InspTypeID,LastInspDt,DueInspDt,AddDt,AddID,InspDue) " +
                                         " Values ('{0}','{1}','{2}','{3}','{4}', GetDate(),'{5}','{6}')";
                                     sql = string.Format(sql,
                                         txtToolsID.Text.Trim().ToString().ToUpper(),
                                         newid,
                                         txtInspTypeID.Text.Trim().ToString().ToUpper(),
                                         txtActInspDt.DateTime.ToString("yyyy-MM-dd"),
                                         txtActInspDt.DateTime.AddDays(NextDue),
                                         Utils.User.GUserID,
                                         1
                                         );

                                     cmd.CommandText = sql;
                                     cmd.ExecuteNonQuery();
                                 }
                                 dmode = "NEW";
                            }
                            
                            MessageBox.Show("Record Updated...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetCtrl2();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }



            LoadGrid();

        }

        private void btnDeleteInsp_Click(object sender, EventArgs e)
        {

            string err = string.Empty;
            if (string.IsNullOrEmpty(txtToolsID.Text.Trim()))
            {
                MessageBox.Show("Please Select Tools ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtSrNo.Text.Trim()))
            {
                MessageBox.Show("Please Select SrNo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dmode != "OLD")
            {
                return;
            }

            DialogResult dr = MessageBox.Show("Are You Sure to Delete This Inspection Record ?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                using (SqlConnection cn = new SqlConnection(Utils.Helper.constr))
                {
                    try
                    {
                        cn.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string sql = "Delete From MastToolsDt where ToolsID ='" + txtToolsID.Text.Trim() + "' and SrNo = '" + txtSrNo.Text.Trim().ToString() + "'";

                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetCtrl2();
                        return;
                    }

                }


            }

            LoadGrid();
        }

        private void LoadGrid()
        {
            DataSet ds = new DataSet();
            string sql = "select * From V_Tools_Insp_History where  ToolsID ='" + txtToolsID.Text.Trim() + "' Order By SrNo ";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                grd_Details.DataSource = ds;
                grd_Details.DataMember = ds.Tables[0].TableName;
            }
        }

        private string DataValidate2(string tMode)
        {
            string err = string.Empty;

            if (tMode == "NEW")
            {
                string newid = Utils.Helper.GetDescription("Select isnull(Max(SrNo),0) + 1 From MastToolsDT Where ToolsID='" + txtToolsID2.Text.Trim() + "'", Utils.Helper.constr);
                if (!string.IsNullOrEmpty(newid))
                {
                    txtSrNo.Text = newid;
                    //txtToolsID2.Text = newid;
                }

                if (string.IsNullOrEmpty(txtSrNo.Text))
                {
                    err = err + "Please Enter SrNo." + Environment.NewLine;
                }

                if (txtLastInspDt.EditValue == DBNull.Value || txtDueInspDt.EditValue == DBNull.Value)
                {
                    err = err + "Please Enter Last Inspection Date/Next Due Inspection Date" + Environment.NewLine;
                }
                else
                {
                    if (txtDueInspDt.DateTime <= txtLastInspDt.DateTime )
                    {
                        err = err + "Due Inspection Date must be gretor than Last Inspection Date." + Environment.NewLine;
                    }

                }

            }
            else
            {
                if (string.IsNullOrEmpty(txtSrNo.Text))
                {
                    err = err + "Please Enter SrNo." + Environment.NewLine;
                }

                if (txtLastInspDt.EditValue == DBNull.Value || txtDueInspDt.EditValue == DBNull.Value)
                {
                    err = err + "Please Enter Last Inspection Date/Next Due Inspection Date" + Environment.NewLine;
                }
                else
                {
                    if (txtDueInspDt.DateTime <= txtLastInspDt.DateTime)
                    {
                        err = err + "Due Inspection Date must be gretor than Last Inspection Date." + Environment.NewLine;
                    }

                }

                if (chkIsDue.Checked && txtCertRecFrom.Text.Trim().ToString() == "")
                {
                    err = err + "Certificate Received From is Required..." + Environment.NewLine;
                }

                if (chkIsDue.Checked && txtActInspDt.Text.Trim().ToString() == "")
                {
                    err = err + "Actual Inspection Date is Required..." + Environment.NewLine;
                }

            }

            return err;
        }

        

    }
}
