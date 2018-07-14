using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;


using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Text;
using System.Net;
using System.DirectoryServices;
using System.Net.Mail;
using System.IO;
using Telerik.Web.UI;
using System.Web.Configuration;

namespace quickinfo_v2.Views.ChangeManagement
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

           string imageid = context.Request.QueryString["ImID"];
           int a = Convert.ToInt32(imageid);
        //    string b = "ITHDO201400036";
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());

            conn.Open();

            OracleCommand myCommand = new OracleCommand("SELECT IMAGE,ID FROM wf_it_images WHERE TYPE='BRANCH_IMAGE' AND ID = '" + a + "'", conn);

            OracleDataReader myReader = myCommand.ExecuteReader();



            myReader.Read();

            context.Response.BinaryWrite((Byte[])myReader[0]);


 
            conn.Close();

            context.Response.End(); 
      
      
        }

        public bool IsReusable
        {

            get
            {

                return false;

            }

        }


    }
}