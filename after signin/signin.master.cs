using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class after_signin_signin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["validated"] == null)
            {
                Response.Redirect("~/Login.aspx");
                Session["Loginid"] = "";
            }
        }

        catch (Exception)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void ASPxButton1_Click(object sender, EventArgs e)
    {
        Session["validated"] = null;
        Response.Redirect("~/Login.aspx");
    }
}
