using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.Mail;  

namespace ToolsInsp_ReminderService
{
    
    
    public partial class Scheduler : ServiceBase
    {

        class ToolsInfo
        {
            public int ToolsID { get; set; }
            public string Plant { get; set; }
            public string Location { get; set; }
            public string Department { get; set; }
            public string ToolsName { get; set; }
            public string Capacity { get; set; }
            public DateTime LastInspDt { get; set; }
            public DateTime DueInspDt { get; set; }
            public string Remarks { get; set; }
            public string RespEmailID { get; set; }
        }
        
        
        #region ServiceStatus

        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);
        #endregion

        #region GlobalVars

        private System.Timers.Timer timer = new System.Timers.Timer();
        private static TimeSpan tSch = new TimeSpan(10, 00, 00);
        private DateTime tSchLastRun = DateTime.Now;
        private static string constr = "Server=172.16.12.14;Database=Safety;User Id=ipu_safety;Password=ipu_safety;";

        #endregion


        public Scheduler()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
           
            // Update the service state to Start Pending.  
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            tSchLastRun = DateTime.Now;
            // Set up a timer to trigger every minute.  
            timer = new System.Timers.Timer();
            timer.Interval = 30000; // 30 seconds  
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start(); 


            // Update the service state to Running.  
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);  
        }

        protected override void OnStop()
        {
            // Update the service state to Start Pending.  
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            timer.Stop();
            timer.Enabled = false;



            // Update the service state to Running.  
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);  
        }


        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            // TODO: Insert monitoring activities here.  

            if (tSchLastRun.Hour == tSch.Hours && tSchLastRun.Minute == tSch.Minutes)
            {
                //assure do not run multiple times in same minutes
                return;
            }

            timer.Enabled = false;

            if (DateTime.Now.Hour == tSch.Hours && DateTime.Now.Minute == tSch.Minutes )
            {
                tSchLastRun = DateTime.Now;

                List<ToolsInfo> temp = new List<ToolsInfo>();
                
                string err = string.Empty;

                //get list of pending ->exactly 30 days
                string sql = "SELECT * FROM V_Tools_Insp_History where InspDue = 1 and DueInspDt = DateAdd(day,30,GetDate()) Order By [RespEmailID]";
                DataSet ds30 = Library.GetData(sql, constr, out err);
                bool hasRows = ds30.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
                if (hasRows)
                {
                    foreach (DataRow dr in ds30.Tables[0].Rows)
                    {
                        ToolsInfo t = new ToolsInfo();
                        t.ToolsID = Convert.ToInt32(dr["ToolsID"]);
                        t.Plant = dr["PlantName"].ToString();
                        t.Location = dr["Location"].ToString();
                        t.Department = dr["DeptName"].ToString();
                        t.LastInspDt = Convert.ToDateTime(dr["LastInspDt"]);
                        t.DueInspDt = Convert.ToDateTime(dr["DueInspDt"]);
                        t.ToolsName = dr["ToolsName"].ToString();
                        t.Capacity = dr["Capacity"].ToString();
                        t.RespEmailID = dr["RespEmailID"].ToString();
                        t.Remarks = "Pending At 30th Day From :" + DateTime.Now.ToString("dd/MM/yyyy");

                        temp.Add(t);
                    }
                }

                //get list of pending ->exactly 30 days
                sql = "SELECT * FROM V_Tools_Insp_History where InspDue = 1 and DueInspDt = DateAdd(day,15,GetDate()) Order By [RespEmailID]";
                DataSet ds15 = Library.GetData(sql, constr, out err);
                hasRows = ds15.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
                if (hasRows)
                {
                    foreach (DataRow dr in ds15.Tables[0].Rows)
                    {
                        ToolsInfo t = new ToolsInfo();
                        t.ToolsID = Convert.ToInt32(dr["ToolsID"]);
                        t.Plant = dr["PlantName"].ToString();
                        t.Location = dr["Location"].ToString();
                        t.Department = dr["DeptName"].ToString();
                        t.LastInspDt = Convert.ToDateTime(dr["LastInspDt"]);
                        t.DueInspDt = Convert.ToDateTime(dr["DueInspDt"]);
                        t.ToolsName = dr["ToolsName"].ToString();
                        t.Capacity = dr["Capacity"].ToString();
                        t.RespEmailID = dr["RespEmailID"].ToString();
                        t.Remarks = "Pending At 15th Day From :" + DateTime.Now.ToString("dd/MM/yyyy");

                        temp.Add(t);
                    }
                }

                //get list of pending ->exactly 30 days
                sql = "SELECT * FROM V_Tools_Insp_History where InspDue = 1 and DueInspDt = DateAdd(day,3,GetDate()) Order By [RespEmailID]";
                DataSet ds3 = Library.GetData(sql, constr, out err);
                hasRows = ds3.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
                if (hasRows)
                {
                    foreach (DataRow dr in ds3.Tables[0].Rows)
                    {
                        ToolsInfo t = new ToolsInfo();
                        t.ToolsID = Convert.ToInt32(dr["ToolsID"]);
                        t.Plant = dr["PlantName"].ToString();
                        t.Location = dr["Location"].ToString();
                        t.Department = dr["DeptName"].ToString();
                        t.LastInspDt = Convert.ToDateTime(dr["LastInspDt"]);
                        t.DueInspDt = Convert.ToDateTime(dr["DueInspDt"]);
                        t.ToolsName = dr["ToolsName"].ToString();
                        t.Capacity = dr["Capacity"].ToString();
                        t.RespEmailID = dr["RespEmailID"].ToString();
                        t.Remarks = "Pending At 3rd Day From :" + DateTime.Now.ToString("dd/MM/yyyy");

                        temp.Add(t);
                    }
                }

                 sql = "SELECT * FROM V_Tools_Insp_History where InspDue = 1 and DueInspDt <= GetDate() Order By [RespEmailID]";
                DataSet ds4 = Library.GetData(sql, constr, out err);
                hasRows = ds4.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
                if (hasRows)
                {
                    foreach (DataRow dr in ds4.Tables[0].Rows)
                    {
                        ToolsInfo t = new ToolsInfo();
                        t.ToolsID = Convert.ToInt32(dr["ToolsID"]);
                        t.Plant = dr["PlantName"].ToString();
                        t.Location = dr["Location"].ToString();
                        t.Department = dr["DeptName"].ToString();
                        t.LastInspDt = Convert.ToDateTime(dr["LastInspDt"]);
                        t.DueInspDt = Convert.ToDateTime(dr["DueInspDt"]);
                        t.ToolsName = dr["ToolsName"].ToString();
                        t.Capacity = dr["Capacity"].ToString();
                        t.RespEmailID = dr["RespEmailID"].ToString();
                        t.Remarks = "Inspection till Pending";

                        temp.Add(t);
                    }
                }

                if (temp.Count <= 0)
                {
                    return;
                }

                List<ToolsInfo> SortedList = temp.OrderBy(o => o.RespEmailID).ToList();


                List<ToolsInfo> tools = new List<ToolsInfo>();
                List<List<ToolsInfo>> mails = new List<List<ToolsInfo>>();

                if (SortedList.Count > 0)
                {
                    //prepare mails and shoot
                    string PreMailID = string.Empty, NextMailID = string.Empty;
                    foreach (ToolsInfo t in SortedList)
                    {
                        NextMailID = t.RespEmailID;

                        if (NextMailID != PreMailID)
                        {                            
                            if (tools.Count > 0)
                            {
                                mails.Add(tools);
                            }                            
                            tools = new List<ToolsInfo>();                            
                        }
                        tools.Add(t);
                        PreMailID = NextMailID;
                    }
                }
                if (tools.Count > 0)
                {
                    mails.Add(tools);
                }

                //here we get list of list of tools
                if(mails.Count > 0)
                {
                    foreach (List<ToolsInfo> listoftools in mails)
                    {
                       
                        //prepare new mail
                        //testing use anand's mailid
                        string smtphost = "smtp.office365.com";
                        string emailaccount = "anand.acharya@jindalsaw.com";
                        string accountuser = "acharyaa@jindalsaw.com";
                        string accountpss = "Jind@l123";
                        string subject = "Tools & Tackles Inspection Reminder";
                        //string emailto = listoftools[0].RespEmailID;
                        string emailto = "anand.acharya@jindalsaw.com";
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
                            "<body>" +
                            "Sir, </br><p>" + "Please Find the List of tools which are pending for inspection. " + "</p> <br/> <br/> " +
                           "<table>" +
                           "<thead>" +
                            "<tr>" +
                             "<th>ToolsSrNo</th>" +
                             "<th>PlantName</th>" +
                             "<th>Department</th>" +
                             "<th>Location</th>" +
                             "<th>Tools Name</th>" +
                             "<th>Capacity</th>" +
                             "<th>LastInsp.Dt.</th>" +
                             "<th>DueInsp.Dt</th>" +
                             "<th>Remarks</th>" +
                            "</tr>" +
                            "</thead>" +
                            "<tbody>";

                        string trows = string.Empty;
                        Library.WriteErrorLog("Trying to Send Email to : " + emailto);
                        foreach (ToolsInfo t in listoftools)
                        {
                            //build contents
                            trows += "<tr><td>" + t.ToolsID.ToString() + "</td>" +
                                    "<td>" + t.Plant.ToString() + "</td>" +
                                    "<td>" + t.Department.ToString() + "</td>" +
                                    "<td>" + t.Location.ToString() + "</td>" +
                                    "<td>" + t.Capacity.ToString() + "</td>" +
                                    "<td>" + t.LastInspDt.ToString("dd/MM/yyyy") + "</td>" +
                                    "<td>" + t.DueInspDt.ToString("dd/MM/yyyy") + "</td>" +
                                    "<td>" + t.Remarks + "</td></tr>";
                        }
                        string tbody = thead + trows + "</tbody></table></br>*This is Auto-generated notification, do not reply on this e-mail id. </body></html>";
                        //send mail
                        bool test = Library.SendMail(smtphost, emailaccount, accountuser, accountpss, emailto, "", "", subject, tbody);
                        if (!test)
                        {
                            Library.WriteErrorLog("Email Send Fails to : " + emailto);
                        }
                        else
                        {
                            Library.WriteErrorLog("Email Successfully Sent to : " + emailto);
                        }
                    }
                }
                
            }

            timer.Enabled = true;
        }

       
    }
}
