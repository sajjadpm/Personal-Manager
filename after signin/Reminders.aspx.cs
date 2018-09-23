using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using PM.Classes;

namespace PersonalManager.after_signin
{
    public partial class Reminders : System.Web.UI.Page
    {
        Carddetails cd = new Carddetails();
        billdetails bd = new billdetails();
        Connection cn= new Connection();
        protected void Page_Load(object sender, EventArgs e)
        {
             if (IsPostBack != true)
            {
                 string s41="select * from Card";
                 DataTable dt = cn.viewdatatable(s41);
                 cbo_Type.DataSource = dt;
                 cbo_Type.TextField = "Typeofcard";
                 cbo_Type.ValueField = "Id";
                 cbo_Type.DataBind();
                 string s42 = "select * from bills";
                 DataTable dt1 = cn.viewdatatable(s42);
                 cbo_bill.DataSource = dt1;
                 cbo_bill.TextField = "value";
                 cbo_bill.ValueField = "id";
                 cbo_bill.DataBind();
            }

        }
        public void clear()
        {
            cbo_Type.SelectedItem.Text = "";
            txt_fullname.Text = "";
            txt_email.Text = "";
            DE_expdate.Text = "";
            txt_country.Text = "";
        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            cd.Typeofcard = cbo_Type.SelectedItem.Text;
            cd.Cardname = txt_fullname.Text;
            cd.Dateofexpiry = DE_expdate.Text;
            cd.Notificationmail = txt_email.Text;
            cd.Country = txt_country.Text;
            cd.Insert();
            clear();
        }
        public void billclear()
        {
            txt_billamount.Text = "";
            DE_billexp.Text = "";
            txt_billemil.Text = "";
            cbo_bill.SelectedItem.Text = "";
        }
        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            bd.billamount = txt_billamount.Text;
            bd.billdate = DE_billexp.Text;
            bd.notificationmail = txt_billemil.Text;
            bd.billtype=cbo_bill.SelectedItem.Text;
            bd.Insert();
            billclear();
        }
    }
}