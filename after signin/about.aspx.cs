using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class after_signin_about : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

        catch(Exception){
            Response.Redirect("../login.aspx");
        }
       
    }
    }
