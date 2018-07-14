using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
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
using System.Data.OracleClient;

using quickinfo_v2.Connectivity;

namespace quickinfo_v2.Views.ITWorkflow
{
    public partial class Image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imageid = Request.QueryString["ImID"];
            int a = Convert.ToInt32(imageid);
            Image1.ImageUrl = "ImageHandler.ashx?ImID=" + a;

        }
    }
}