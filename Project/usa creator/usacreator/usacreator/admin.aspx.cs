using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace usacreator
{
    public partial class admin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=ZAINASOFT\\SQL;Initial Catalog=usa;Persist Security Info=True;User ID=sa;Password=creative007");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submit_Click(object sender, EventArgs e)
        {
             con.Open();
            SqlCommand cmd = new SqlCommand("select email,password from admin where email='" + username.Text + "' and Password='" + password.Text + " '", con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (username.Text == dr[0].ToString() && password.Text == dr[1].ToString())
                {
                    username.Text = "";
                    password.Text = "";
                    Session["validated"] = "validated";
                    Response.Redirect("./signin/app.aspx");
                }
                else
                {


                }
            }

            else
            {
                username.Text = "Wrong Username-Password";
            }
            dr.Close();
            con.Close();
        }
    }
}