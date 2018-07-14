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
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Threading;


//using System.Drawing;
//using System.Text;
//using System.Data.OleDb;
//using System.Data.OracleClient;
//using System.Data.SqlClient;
//using System.Net;
//using System.DirectoryServices;
//using System.Net.Mail;
//using System.IO;

using quickinfo_v2.Connectivity;
using quickinfo_v2.CommonCLS;



namespace quickinfo_v2.Views.ITWorkflow
{

    public partial class JobSearch : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        DataTable DtRef;
        string UserName = "";
        ChangeManagementMain CM_Main = new ChangeManagementMain();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    grdRequest.DataSource = new int[] { };
                    UserName = User.Identity.Name;

                    if (Cache["user_company"].ToString() == "HNBA")
                    {

                        UserName = Right(UserName, (UserName.Length) - 5);
                        Session["USER"] = UserName;
                        GetUser(UserName.ToString());

                    }
                    else if (Cache["user_company"].ToString() == "HNBGI")
                    {

                        UserName = Right(UserName, (UserName.Length) - 6);
                        Session["USER"] = UserName;
                        GetUser(UserName.ToString());

                    }


 

                }
                if (IsPostBack)
                {
                    return;
                }


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        public DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry oDE;

            CommonFunctions cmnFunctions = new CommonFunctions();
            oDE = new DirectoryEntry(cmnFunctions.getADIPAddress(Cache["user_company"].ToString()));


            return oDE;
        }


        public DirectoryEntry GetUser(string UserName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher();
            deSearch.SearchRoot = de;

            deSearch.Filter = "(&(objectClass=user)(SAMAccountName=" + UserName + "))";
            deSearch.SearchScope = SearchScope.Subtree;
            SearchResult results = deSearch.FindOne();


            if (!(results == null))
            {

                de = new DirectoryEntry(results.Path);
                Session["EmployeeID"] = de.Properties["EmployeeID"][0].ToString();
                Session["DisplayName"] = de.Properties["displayName"][0].ToString();
                Session["HnbaEmail"] = de.Properties["Mail"][0].ToString();
                Session["Departmnet"] = de.Properties["Department"].Value.ToString();
                // Session["Manager"] = de.Properties["Manager"].Value.ToString();
                Session["Branch"] = de.Properties["postalCode"].Value.ToString();
                //  Session["Branch"] = "APR";

                return de;
            }
            else
            {
                Session["EmployeeID"] = "";
                Session["DisplayName"] = "";
                Session["HnbaEmail"] = "";
                Session["Departmnet"] = "";
                // Session["Manager"] = "";
                Session["Branch"] = "";
                return null;
            }
        }

        public static string Left(string text, int length)
        {
            return text.Substring(0, length);
        }

        public static string Right(string text, int length)
        {
            return text.Substring(text.Length - length, length);
        }

        public static string Mid(string text, int start, int end)
        {
            return text.Substring(start, end);
        }

        public static string Mid(string text, int start)
        {
            return text.Substring(start, text.Length - start);
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Reg = Main.SelectJobFromRegister("CASE1", txtRefNo.Text, txtRequestID.Text, "", System.DateTime.Now);
                grdRequest.DataSource = Reg;
                grdRequest.DataBind();


            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }


        protected void grdRequest_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable Reg = Main.SelectJobFromRegister("CASE1", txtRefNo.Text, "", "", System.DateTime.Now);
            grdRequest.DataSource = Reg;
        }

        protected void grdRequest_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {

                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dd = Main.SelectJobFromRegister("CASE4", dataitem["REQUEST_ID"].Text, "", "", System.DateTime.Now);
                    grdRequest.DataSource = dd;
                    grdRequest.DataBind();


                    DataTable dtEvents = Main.SelectJobFromRegister("CASE16", dataitem["REQUEST_ID"].Text, "", "", System.DateTime.Now);
                    GrdEvents.DataSource = dtEvents;
                    GrdEvents.DataBind();



                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }


    }
}