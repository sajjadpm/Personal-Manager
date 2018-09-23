using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.Drawing;


namespace usacreator.signin
{
    public partial class app : System.Web.UI.Page
    {
        static int f = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

             
            
            if (f == 1)
            {
                Label1.ForeColor = Color.Green;
                Label1.Text = "successfully inserted";
            }
          
        }

       

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (Fileupload1.HasFile)
            {
                string path = string.Concat((Server.MapPath("~/Upload/" + Fileupload1.FileName)));
                Fileupload1.PostedFile.SaveAs(path);
                OleDbConnection OleDbcon = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;");

                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", OleDbcon);
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter(cmd);

                OleDbcon.Open();
                DbDataReader dr = cmd.ExecuteReader();

                string con_str = @"Data Source=ZAINASOFT\SQL;Initial Catalog=usa;User ID=sa;Password=creative007";

                // Bulk Copy to SQL Server 
                SqlBulkCopy bulkInsert = new SqlBulkCopy(con_str);
                bulkInsert.DestinationTableName = "stream";
                bulkInsert.WriteToServer(dr);
                OleDbcon.Close();
                Array.ForEach(Directory.GetFiles((Server.MapPath("~/Upload/"))), File.Delete);
               

                f = 1;
                Response.Redirect(Request.RawUrl);
               
                
            }
            else
            {
                Label1.ForeColor = Color.Red;
                Label1.Text = "Please select the File";
            }

            
        }
        
    }
}