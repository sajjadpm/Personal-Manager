using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PM.Classes;
using System.Net.Mail;
using System.Configuration;
using System.Text;

public partial class after_signin_Default1 : System.Web.UI.Page
{
    Connection cn = new Connection();
    // string password = "software";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack != true)
            {
                string s13 = "select * from Carddetails";
                DataTable d37 = cn.viewdatatable(s13);
                for (int k = 0; k < d37.Rows.Count; k++)
                {
                    string date = DateTime.Now.ToString("MM/dd/yyy");
                    string expdate = DateTime.Parse(d37.Rows[k]["Dateofexpiry"].ToString()).ToString("MM/dd/yyy");
                    if (date == expdate)
                    {
                        MailMessage myMessage = new MailMessage();
                        myMessage.Subject = "Card Expired Message";
                        myMessage.IsBodyHtml = true;
                        StringBuilder body = new StringBuilder();



                        body.Append("<table>");
                        body.Append("<tr><td><strong>Dear " + d37.Rows[k]["Cardname"].ToString() + ",</strong></td></tr>");
                        body.Append("<br />");
                        body.Append("<br />");
                        body.Append("<br />");
                        body.Append("<tr><td>Your " + d37.Rows[k]["Typeofcard"].ToString() + " Expired Today. <br /> Please go for further Movements.</td></tr>");

                        body.Append("</table>");
                        body.Append("<br />");
                        body.Append("<br />");

                        myMessage.Body = body.ToString();
                        myMessage.From = new MailAddress("pmanager111@gmail.com", "Personal Manager");
                        myMessage.To.Add(new MailAddress(d37.Rows[k]["notificationmail"].ToString(), ""));
                        SmtpClient mySmtpClient = new SmtpClient(); mySmtpClient.Send(myMessage);
                    }
                }
                string s132 = "select * from billdetails";
                DataTable d372 = cn.viewdatatable(s132);
                for (int k = 0; k < d372.Rows.Count; k++)
                {
                    string date = DateTime.Now.ToString("MM/dd/yyy");
                    string expdate = DateTime.Parse(d372.Rows[k]["billdate"].ToString()).ToString("MM/dd/yyy");
                    if (date == expdate)
                    {

                    }
                }
            }


            try
            {

                string vali = Session["validated"].ToString();

                if (vali == "validated")
                {

                }
                else
                {
                    Session.Abandon();
                    Response.Redirect("../login.aspx");
                }
            }

            catch (Exception)
            {
                //  Response.Redirect("../login.aspx");
            }

        }
        catch (Exception)
        {
            //  Response.Redirect("../login.aspx");
        }

    }

}