using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PM.Classes;
using System.Data.SqlClient;

namespace PersonalManager
{
    public partial class Login : System.Web.UI.Page
    {
        Connection cn = new Connection();
        Logindetails LD = new Logindetails();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ASPxButton1_Click(object sender, EventArgs e)
        {

            string userid, password;
            userid = username.Text;
            password = pass.Text;
            SqlConnection con = new SqlConnection("Data Source=SAJJAD\\SQLEXPRESS;Initial Catalog=PMANAGER;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Emailaddress,Password from Logindetails where Emailaddress='" + username.Text + "' and Password='" + pass.Text + " '", con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (username.Text == dr[0].ToString() && pass.Text == dr[1].ToString())
                {
                    username.Text = "";
                    pass.Text = "";
                    Session["validated"] = "validated";
                    Response.Redirect("./after%20signin/Default1.aspx");
                }
                else
                {
                   

                }

            }
            else
            {
                username.Text = "Please Enter Valid Username Or Password";
            }
            dr.Close();
            con.Close();
        }
        public void clear()
        {
            Txt_Name.Text = "";
            Txt_Email.Text = "";
            Txt_passowrd.Text = "";
            txtConfimpassword.Text = "";
        }
        protected void Btn_SignUp_Click(object sender, EventArgs e)
        {
            LD.Name = Txt_Name.Text;
            LD.Emailaddress = Txt_Email.Text;
            LD.Password = Txt_passowrd.Text;
            LD.createdon = DateTime.Now;
            LD.Insert();
            clear();

            string message = "Registered Successfully";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        
        
        }
    }
}