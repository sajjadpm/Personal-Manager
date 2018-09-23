using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace usacreator.signin
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                string vali = Session["validated"].ToString();

                if (vali == "validated")
                {

                }
                else
                {
                    Session.Abandon();
                    Response.Redirect("../usa.aspx");
                }
            }

            catch (Exception)
            {
                Response.Redirect("../usa.aspx");
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {

            
            Session.Abandon();
            Response.Redirect("../usa.aspx");
        }
    }
}