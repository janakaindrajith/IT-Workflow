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
using quickinfo_v2.CommonCLS;

namespace quickinfo_v2.Views.ChangeManagement
{
    public partial class ApproveRelease : System.Web.UI.Page
    {
        string UserName = "";
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        ChangeManagementMain CM_Main = new ChangeManagementMain();
        DataTable DtRef;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    UserName = User.Identity.Name;
                    if (Left(UserName, 4) == "HNBA")
                    {

                        UserName = Right(UserName, (UserName.Length) - 5);
                        Session["USER"] = UserName;
                        GetUser(UserName.ToString());

                    }
                    else if (Left(UserName, 5) == "HNBGI")
                    {

                        UserName = Right(UserName, (UserName.Length) - 6);
                        Session["USER"] = UserName;
                        GetUser(UserName.ToString());

                    }

                    DataTable dtcon = CM_Main.SelectJob("CASE16", "", "", "", "", "", System.DateTime.Now);
                    grdRequest.DataSource = dtcon;
                    grdRequest.DataBind();

                    ddlStatusSch.Items.Clear();
                    ddlStatusSch.DataSource = CM_Main.SelectReferanceData("STATUS", "", "");
                    ddlStatusSch.DataValueField = "DESCRIPTION";
                    ddlStatusSch.DataTextField = "DESCRIPTION";
                    ddlStatusSch.DataBind();
                    ddlStatusSch.Items.Insert(0, new RadComboBoxItem("--Select Status--", ""));

                    ddlRequestUserSch.Items.Clear();
                    ddlRequestUserSch.DataSource = Main.SelectReferanceData("HELPDESK_USERS", "", "");
                    ddlRequestUserSch.DataValueField = "USER_NAME";
                    ddlRequestUserSch.DataTextField = "FULL_NAME";
                    ddlRequestUserSch.DataBind();
                    ddlRequestUserSch.Items.Insert(0, new RadComboBoxItem("--Select Request User--", ""));

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

        protected void grdRequest_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridDataItem dataitem = e.Item as GridDataItem;
                string ReqID = dataitem["REQUEST_ID"].Text;
                string Level = "APPROVE";
                Response.Redirect("Monitor.aspx?ReqID=" + ReqID + "&ApproveLevel=" + Level, false);


            }
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtcon = CM_Main.SelectJob("CASE2", txtChangeID.Text, ddlStatusSch.SelectedItem.Value, TxtTitleSch.Text, ddlRequestUserSch.SelectedItem.Value, "", System.DateTime.Now);
                grdRequest.DataSource = dtcon;
                grdRequest.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {

        }

        protected void grdRequest_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

        }
    }
}