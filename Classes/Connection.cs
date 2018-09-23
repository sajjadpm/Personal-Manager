using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Web.UI.HtmlControls;
using PM.Classes;


namespace PM.Classes
{
    public class Connection
    {
        public SqlCommand cmd;
        public string path;
        string mailid, password ;
        private static Random RNG = new Random();
        
        public SqlConnection con = new SqlConnection();
        string err;
        string s;
        public Connection()
        {
            AppSettingsReader app = new AppSettingsReader();
            string st = app.GetValue("connect", typeof(String)).ToString();
          
            //FileStream fs = new FileStream(@"C:\connPath.txt", FileMode.Open, FileAccess.Read);

            //StreamReader m_streamReader = new StreamReader(fs);
            //path = m_streamReader.ReadLine();

            //SqlConnection con= new SqlConnection(path);

            con = new SqlConnection(st);
        }
        public void AddSqlParameter(SqlCommand command)
        {
            SqlParameter param = new SqlParameter(
                "@Description", SqlDbType.NVarChar, 16);
            param.Value = "Beverages";
            command.Parameters.Add(param);
        }
        public void open()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
               
                     con.Open();
        }
        public void query(string sql)
        {
            open();
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
        }
        public Bitmap ResizeImage(Stream streamImage, int maxWidth, int maxHeight)
        {
            Bitmap originalImage = new Bitmap(streamImage);
            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;
            double aspectRatio = (double)originalImage.Width / (double)originalImage.Height;

            if (aspectRatio <= 1 && originalImage.Width > maxWidth)
            {
                newWidth = maxWidth;
                newHeight = (int)Math.Round(newWidth / aspectRatio);
            }
            else if (aspectRatio > 1 && originalImage.Height > maxHeight)
            {
                newHeight = maxHeight;
                newWidth = (int)Math.Round(newHeight * aspectRatio);
            }

            Bitmap newImage = new Bitmap(originalImage, newWidth, newHeight);

            Graphics g = Graphics.FromImage(newImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            g.DrawImage(originalImage, 0, 0, newImage.Width, newImage.Height);

            originalImage.Dispose();

            return newImage;
        }
        public string EncryptData(string InputData)
        {
            try
            {
                //SHA1Managed shaM = new SHA1Managed();
                //Convert.ToBase64String(shaM.ComputeHash(Encoding.Unicode.GetBytes(InputData)));
                Byte[] eNC_data = Encoding.Unicode.GetBytes(InputData);
                string eNC_str = Convert.ToBase64String(eNC_data);
                return eNC_str;
            }
            catch
            {
                return InputData;
            }
        }

        public string DecryptData(string InputData)
        {
            try
            {
                Byte[] dEC_data = Convert.FromBase64String(InputData);
                string dEC_Str = Encoding.Unicode.GetString(dEC_data);
                return dEC_Str;
            }
            catch
            {
                return InputData;
            }
        }

        public void WriteError(string errorMessage)
        {
            try
            {
                string path = "~/Error/" + DateTime.Today.ToString("dd-MM-yyyy") + ".txt";
                if (!File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
                }

                using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
                {
                    w.WriteLine("\r\nLog Entry : ");
                    w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() +
                                 ". Error Message:" + errorMessage;
                    w.WriteLine(err);
                    w.WriteLine("__________________________");
                    w.Flush();
                    w.Close();
                }

                string s43 = "select top 1 mailid,password from EmailTable order by id desc";
                open();

                SqlDataAdapter da = new SqlDataAdapter(s43, con);
                DataTable d47 = new DataTable();
                da.Fill(d47);


                //DataTable d47 = cn.viewdatatable(s43);
                for (int k = 0; k < d47.Rows.Count; k++)
                {

                    mailid = d47.Rows[k]["mailid"].ToString();
                    password = d47.Rows[k]["password"].ToString();

                }
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["SMTPServer"];
                //smtp.Port = 587;
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = true;
                //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["SMTPCredentialUser"]) && !string.IsNullOrEmpty(ConfigurationManager.AppSettings["SMTPCredentialPass"]))
                //{
                //    smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SMTPCredentialUser"], ConfigurationManager.AppSettings["SMTPCredentialPass"]);
                //}
                smtp.Credentials = new System.Net.NetworkCredential(mailid, password);
                MailMessage message = new MailMessage();
                message.From = new MailAddress(mailid);
                message.Subject = "Error Message";
                message.IsBodyHtml = true;
                StringBuilder body = new StringBuilder();


                body.Append("<table>");

                //body.Append("<tr><td>" + pass + "</td></tr>");

                body.Append("<tr><td>" + err + " has Occured</td></tr>");

                body.Append("</table>");
                body.Append("<br />");
                body.Append("<br />");
                body.Append("Sincerely,<br />");
                body.Append("<span style=\"font-weight: bold; color: #000099;\">Team - ResumeManager</span>");
                body.Append("<br />");
                body.Append("<br />");

                message.Body = body.ToString();
                message.To.Add(mailid);
                message.CC.Add("careers@zainasoft.com");
                //  message.To.Add("alexander@zainasoft.com");
                try
                {
                    smtp.Send(message);
                    //lblmsg.Visible = true;
                    //lblmsg.Text = "Password has been send to your email id";
                }
                catch (Exception ex)
                {


                }
                // Div77.Style.Value = "display:block";

            }
            catch (Exception ex)
            {
                WriteError(ex.Message);
            }

        }
        public DataSet viewdataset(string val)
        {
            open();
            SqlDataAdapter da = new SqlDataAdapter(val, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "a");
            return ds;
        }
        public DataTable viewdatatable(string val)
        {
            open();
            SqlDataAdapter da = new SqlDataAdapter(val, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataSet data(string str)
        {
            open();
            cmd.Connection = con;
            cmd.CommandText = str;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public DataSet getdata(string str)
        {
            open();
            cmd.Connection = con;
            cmd.CommandText = str;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public SqlDataReader exereader(string str)
        {
            open();
            cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public string executescalar(string val)
        {
            open();
            cmd = new SqlCommand(val, con);
            object check = cmd.ExecuteScalar();
            if (check != null)
            {
                s = cmd.ExecuteScalar().ToString();
            }
            else
            {
                s = "";
            }

            return s;
        }
        public void PopulateDropdown(DropDownList drp, string datType, Boolean SelectReqd = false)
        {
            // To fill values from tbl_Values into the given dropdown, based on datType.
            // If SelectReqd is set to TRUE, default option is shown as '----Select----'.

            string sqlValues = " select id, value from [tbl_Values] where Type = '" + datType + "' order by Type, isnull(sOrder,0), value";
            // if there is specific SOrder in table, values are shown in that order, else alphabetically.
            DataTable dtValues = viewdatatable(sqlValues);
            drp.DataTextField = "Value";
            drp.DataValueField = "Id";
            drp.DataSource = dtValues;
            drp.DataBind();
            if (SelectReqd)    // Default '----Select----' option.
            {
                drp.Items.Insert(0, "-- Select --");
            }

        }
        public void PopulateHtmlList(HtmlSelect drp, string datType, Boolean SelectReqd = false)
        {
            // To fill values from tbl_Values into the given dropdown, based on datType.
            // If SelectReqd is set to TRUE, default option is shown as '----Select----'.

            string sqlValues = " select id, value from [tbl_Values] where Type = '" + datType + "' order by Type, isnull(sOrder,0), value";
            // if there is specific SOrder in table, values are shown in that order, else alphabetically.
            DataTable dtValues = viewdatatable(sqlValues);
            drp.DataTextField = "Value";
            drp.DataValueField = "Id";
            drp.DataSource = dtValues;
            drp.DataBind();
            if (SelectReqd)    // Default '----Select----' option.
            {
                drp.Items.Insert(0, "-- Select --");
            }

        }
        public string Create16DigitString()
        {
            var builder = new StringBuilder();
            while (builder.Length < 16)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }




    }
}