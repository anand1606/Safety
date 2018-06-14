using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ToolsInsp_ReminderService
{
    internal class Library
    {
        
        public static string GetLocalIpAddress()
        {

            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog("Can not get Local IP Address");
            }
            return "";
        }
                       
        public static void WriteErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string basepath = AppDomain.CurrentDomain.BaseDirectory;
                string fullpath = Path.Combine(basepath, dt.ToString("yyyyMMdd") + ".txt");
                sw = new StreamWriter(fullpath, true);
                sw.WriteLine((DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : " + ex.ToString().Trim()));
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }

        public static void WriteErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                DateTime dt = new DateTime() ;
                dt = DateTime.Now;
                string basepath = AppDomain.CurrentDomain.BaseDirectory;
                string fullpath = Path.Combine(basepath, dt.ToString("yyyyMMdd") + ".txt");
                sw = new StreamWriter(fullpath, true);

                sw.WriteLine((DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : " + Message));
                sw.Flush();
                sw.Close();
            }
            catch
            {

            }
        }

        public static string SendSMS(string mobileno, string msg)
        {
            string result = string.Empty;
            string userName = "jindalsawcom";
            string password = "93411402";

             
            string no2 = "91" + mobileno;
            string sURL = @"https://www.txtguru.in/imobile/api.php?username={0}&password={1}&source=JSLIPU&dmobile={2}&message={3}";
            sURL = string.Format(sURL, userName, password, no2, msg.Replace(" ", "+"));

            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                var objReader = new StreamReader(objStream);
                result = objReader.ReadToEnd();
                objReader.Close();
            }
            catch (Exception ex)
            {
                result = "Error : 1";
            }

            return result;
        }

        public void InitFTPTransfer(string srcfilepath,string destfilepath)
        {
            
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://172.16.12.16:21/" + destfilepath + "/" + srcfilepath );
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential("smgdc\acharyaa","anand123");

            byte[] fileContents = File.ReadAllBytes(srcfilepath);

            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            response.Close();

        }

        public static DataSet GetData(string sql, string ConnectionString, out string err)
        {
            err = string.Empty;
            DataSet Result = new DataSet();
            if (string.IsNullOrEmpty(sql))
            {
                err = "Query is not defined";
                return Result;
            }

            if (string.IsNullOrEmpty(ConnectionString))
            {
                err = "Connection String is not defined";
                return Result;
            }


            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(sql, conn) { CommandType = CommandType.Text };
            SqlDataAdapter da = new SqlDataAdapter();


            try
            {
                conn.Open();
                command.ExecuteNonQuery();
                da.SelectCommand = command;
                da.Fill(Result, "RESULT");
                conn.Close();
            }
            catch (SqlException ex) { err = ex.Message.ToString(); }
            catch (Exception ex) { err = ex.Message.ToString(); }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return Result;
        }

        public static bool SendMail(string smtphost, string emailaccount, string AccountUser, string AccountPass, string SendTo, string CCTo, string BCCTo, string subject, string tbody)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(smtphost);

                mail.From = new MailAddress(emailaccount);

                #region Addressing
                var tolist = SendTo.Split(';');
                foreach (var to in tolist)
                {
                    if (!string.IsNullOrEmpty(to))
                        mail.To.Add(to.ToString());
                }

                var cclist = CCTo.Split(';');
                foreach (var cc in cclist)
                {
                    if (!string.IsNullOrEmpty(cc))
                        mail.CC.Add(cc.ToString());
                }

                var bcclist = BCCTo.Split(';');
                foreach (var bcc in bcclist)
                {
                    if (!string.IsNullOrEmpty(bcc))
                        mail.Bcc.Add(bcc.ToString());
                }
                #endregion


                mail.Subject = subject;

                mail.IsBodyHtml = true;
                mail.Body = tbody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(AccountUser, AccountPass);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Library.WriteErrorLog(ex);
                return false;
            }
        }

    }
}
