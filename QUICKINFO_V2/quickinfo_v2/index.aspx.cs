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
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Net;
using System.DirectoryServices;
using System.Net.Mail;
using System.IO;


namespace quickinfo_v2
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SaveLoggedUser();
            }
        }


        private void SaveLoggedUser()
        {

            //string UserName = "";
            //UserName = Context.User.Identity.Name;


            //if (UserName == "")
            //{
            //    return;
            //}


            //if (Left(UserName, 4) == "HNBA")
            //{
            //    UserName = Right(UserName, (UserName.Length) - 5);
            //}
            //else if (Left(UserName, 5) == "HNBGI")
            //{

            //    UserName = Right(UserName, (UserName.Length) - 6);

            //}
            //else
            //{
            //    UserName = Right(UserName, (UserName.Length) - 7);
            //}



            //try
            //{
            //    OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["ORAWF"].ToString());
            //    conProcess.Open();
            //    OracleCommand spProcess = null;

            //    spProcess = new OracleCommand("INSERT_QUICKINFO_ONLINE_USERS");

            //    spProcess.CommandType = System.Data.CommandType.StoredProcedure;
            //    spProcess.Connection = conProcess;
            //    spProcess.Parameters.Add("V_USER_CODE", OracleType.VarChar, 50).Value = UserName;


            //    spProcess.ExecuteNonQuery();
            //    conProcess.Close();



            //}
            //catch (Exception ex)
            //{

            //}

        }

        public string Left(string text, int length)
        {
            return text.Substring(0, length);
        }
        public string Right(string text, int length)
        {
            return text.Substring(text.Length - length, length);
        }

      
    }
}