﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;

namespace ContractPayroll.Forms
{
    public partial class frmReports : DevExpress.XtraEditors.XtraForm
    {

        public string GRights = "XXXV";
        public string mode = "NEW";
        string sql = string.Empty;
        public DataSet GridDataSet;


        public frmReports()
        {
            InitializeComponent();
        }

        private void ResetCtrl()
        {
            
            object s = new object();
            EventArgs e = new EventArgs();

            txtPayPeriod.Properties.ReadOnly = true;
            GRights = ContractPayroll.Classes.Globals.GetFormRights(this.Name);
           
            txtPayPeriod.Text = "";
            txtPayDesc.Text = "";
            mode = "NEW";
            grid1.DataSource = null;

        }

        private void SetRights()
        {
            if (txtPayPeriod.Text.Trim() != "" && GRights.Contains("A"))
            {
                btnRefresh.Enabled = true;
                if (mode == "NEW")
                    btnRefresh.Enabled = false;

            }
            else if (txtPayPeriod.Text.Trim() != "")
            {
                btnRefresh.Enabled = false;

                if (GRights.Contains("U") || GRights.Contains("D"))
                {
                    btnRefresh.Enabled = true;
                    if (mode == "NEW")
                        btnRefresh.Enabled = false;
                }

            }

            if (GRights.Contains("XXXV"))
            {
                btnRefresh.Enabled = false;
            }


        }

        private string DataValidate()
        {
            string err = string.Empty;

           

            if (string.IsNullOrEmpty(txtPayPeriod.Text))
            {
                err = err + "Please select Pay Period " + Environment.NewLine;
                return err;
            }


            if (string.IsNullOrEmpty(txtPayDesc.Text))
            {
                err = err + "Please Enter Description.." + Environment.NewLine;
                return err;
            }

            if (mode != "OLD")
            {
                err = err + "Invalid Pay Period.." + Environment.NewLine;
                return err;
            }

            if (string.IsNullOrEmpty(cmbReports.Text.Trim()))
            {
                err = err + "Invalid Report Selection.." + Environment.NewLine;
                return err;
            }

            return err;
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            ResetCtrl();
            DataSet ds = new DataSet();
            ds = Utils.Helper.GetData("Select ReportName From Cont_Reports Order By ReportID", Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);

            if (!hasRows)
            {
                MessageBox.Show("system does not have any configured reports", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cmbReports.Properties.Items.Add(dr["ReportName"].ToString());
                }
            }
        }

        private void txtPayPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";


                sql = "Select PayPeriod,PayDesc,FromDt,ToDt from Cont_MastPayPeriod Where 1 = 1 Order by PayPeriod desc ";


                if (e.KeyCode == Keys.F1)
                {
                    obj = (List<string>)hlp.Show(sql, "PayPeriod", "PayPeriod", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }

                if (obj.Count == 0)
                {
                    txtPayPeriod.Text = "";
                    txtPayDesc.Text = "";
                  
                    return;
                }
                else if (obj.ElementAt(0).ToString() == "0")
                {
                    txtPayPeriod.Text = "";
                    txtPayDesc.Text = "";
                    return;
                }
                else if (obj.ElementAt(0).ToString() == "")
                {
                    txtPayPeriod.Text = "";
                    txtPayDesc.Text = "";
                    return;
                }
                else
                {

                    txtPayPeriod.Text = obj.ElementAt(0).ToString();
                    txtPayDesc.Text = obj.ElementAt(1).ToString();
                    txtPayPeriod_Validated(sender, e);
                }
            }
        }

        private void txtPayPeriod_Validated(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            string sql = "select * From Cont_MastPayPeriod where  PayPeriod='" + txtPayPeriod.Text.Trim() + "'";

            ds = Utils.Helper.GetData(sql, Utils.Helper.constr);
            bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    txtPayDesc.Text = dr["PayDesc"].ToString();
                    mode = "OLD";
                }

                sql = "select PayPeriod, ParaCode as DedCode, PValue as Amount,Convert(Bit,BCFlg) as BCFlg From Cont_ParaMast where  PayPeriod='" + txtPayPeriod.Text.Trim() + "' and BCFlg = 1 and AppFlg = 1";
                

            }
            else
            {
               
                
                mode = "NEW";
                
            }

            SetRights();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GridDataSet = new DataSet();
            gridView1.Columns.Clear();
            grid1.DataSource = null;
          

            string err = DataValidate();
            if (!string.IsNullOrEmpty(err))
            {
                MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sqltyp = string.Empty;
            string reportname = cmbReports.Text.Trim();
            DataSet ds = Utils.Helper.GetData("Select * from Cont_Reports Where ReportName ='" + reportname + "'", Utils.Helper.constr);
            
            bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);

            if (hasRows)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sqltyp = dr["ReportType"].ToString();
                    sql = dr["ReportSQL"].ToString();
                }

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    if (sqltyp == "SQL")
                    {
                        sql = sql.Replace("@payperiod", txtPayPeriod.Text.Trim());

                        string subsql = string.Empty;

                        if (string.IsNullOrEmpty(txtContCode.Text.Trim()))
                        {
                            subsql = "Select Distinct ContCode from Cont_MastEmp where PayPeriod ='" + txtPayPeriod.Text.Trim() + "' ";
                        }
                        else
                        {
                            subsql = "Select Distinct ContCode from Cont_MastEmp where PayPeriod ='" + txtPayPeriod.Text.Trim() + "' and ContCode = '" + txtContCode.Text.Trim() + "'";
                        }

                        sql = sql.Replace("@ContCode", subsql);
                        
                        GridDataSet = Utils.Helper.GetData(sql, Utils.Helper.constr);
                    }
                    else if (sqltyp == "SP")
                    {

                        using (SqlConnection conn = new SqlConnection(Utils.Helper.constr))
                        {
                            SqlCommand sqlComm = new SqlCommand(sql, conn);
                            sqlComm.Parameters.AddWithValue("@payperiod", txtPayPeriod.Text.Trim());
                            sqlComm.Parameters.AddWithValue("@ContCode", txtContCode.Text.Trim());
                            sqlComm.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = sqlComm;
                            da.Fill(GridDataSet);
                            da.Dispose();
                        }
                    }

                    this.Cursor = Cursors.Default;

                    grid1.DataSource = GridDataSet;
                    grid1.DataMember = GridDataSet.Tables[0].TableName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                GridDataSet = new DataSet();
                gridView1.Columns.Clear();
                grid1.DataSource = null;
            }


        }

        private void btnExportGrid_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gridView1.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gridView1.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gridView1.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gridView1.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gridView1.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gridView1.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtContCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F2)
            {
                List<string> obj = new List<string>();

                Help_F1F2.ClsHelp hlp = new Help_F1F2.ClsHelp();
                string sql = "";


                sql = "Select Distinct ContCode,ContDesc from Cont_MastEmp Where PayPeriod = '" + txtPayPeriod.Text.Trim() + "' Order by ContCode Asc ";


                if (e.KeyCode == Keys.F1)
                {
                    obj = (List<string>)hlp.Show(sql, "ContCode", "ContCode", typeof(int), Utils.Helper.constr, "System.Data.SqlClient",
                   100, 300, 400, 600, 100, 100);
                }

                if (obj.Count == 0)
                {
                    txtContCode.Text = "";
                    return;
                }
                else if (obj.ElementAt(0).ToString() == "0")
                {
                    txtContCode.Text = "";
                    return;
                }
                else if (obj.ElementAt(0).ToString() == "")
                {
                    txtContCode.Text = "";
                    return;
                }
                else
                {

                    txtContCode.Text = obj.ElementAt(0).ToString();

                }
            }
        }
    }
}