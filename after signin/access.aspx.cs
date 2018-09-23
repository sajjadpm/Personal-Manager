using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PM.Classes;
using System.IO;

public partial class after_signin_access : System.Web.UI.Page
{
    Storage SC = new Storage();
    protected void Page_Load(object sender, EventArgs e)
    {
       

        
        }
       
    
    protected void Btn_Fileupload_Click(object sender, EventArgs e)
    {
     
        string filepath = Server.MapPath("\\UploadDocuments");
        HttpFileCollection uploadedFiles = Request.Files;
        for (int i = 0; i < uploadedFiles.Count; i++)
        {
            HttpPostedFile userPostedFile = uploadedFiles[i];
            try
            {
                if (userPostedFile.ContentLength > 0)
                {
                    SC.filename = userPostedFile.FileName ;
                    SC.Path = filepath;
                    SC.Insert();
                    userPostedFile.SaveAs(filepath + "\\" + Path.GetFileName(userPostedFile.FileName));
                }
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
