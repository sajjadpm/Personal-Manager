using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PM.Classes;

public partial class after_signin_profile : System.Web.UI.Page
{
    Connection cn = new Connection();
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

        catch (Exception)
        {
            Response.Redirect("../login.aspx");
        }











    }
    protected void BtnDOCDownload_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lbt = (ImageButton)sender;
        string FileName = lbt.CommandArgument;
        string fpath = Server.MapPath("~/UploadDocuments/" + FileName);
        FileInfo file = new FileInfo(fpath);
        Response.AddHeader("Content-Disposition", "inline;filename=" + FileName);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.ContentType = MimeType(Path.GetExtension(FileName));
        Response.TransmitFile(file.FullName);
        Response.End();
    }
    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
            mime = rk.GetValue("Content Type").ToString();
        return mime;
    }
    protected void BtnDOCDelete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton lbt = (ImageButton)sender;
        int DocID = int.Parse(lbt.CommandArgument);
        string st101 = "delete from Storage where ID='" + DocID + "'";
        cn.query(st101);
        Response.Redirect(Request.RawUrl);
        
       // if (File.Exists(Server.MapPath("Documents/" + Request.QueryString["ID"] + "/" + e.Values["FileName"].ToString())))
        //    File.Delete(Server.MapPath("Documents/" + Request.QueryString["ID"] + "/" + e.Values["FileName"].ToString()));
    }
}