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

namespace quickinfo_v2.Views.ITWorkflow
{
    public partial class TCS_Unlock : System.Web.UI.Page
    {
        string UserName = ""; 
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
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

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("TCS_Unlock.aspx");
        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            DataTable dtcon = Main.SelectTCSLockedUsers(txtUserID.Text);
            grdUsers.DataSource = dtcon;
            grdUsers.DataBind();
        }

        protected void ChkBxAllocate_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridDataItem item in grdUsers.MasterTableView.Items)
            {
                CheckBox chkbx = (CheckBox)item["ChkAssign"].FindControl("ChkBxAllocate");
            }
        }

        string TCSUserCode = ""; string ULE_RLE_ROLE_ID = ""; DateTime USER_STARTDATE ; string ULE_PFY_PTY_PARTY_ID = ""; string ULE_PFY_PARTY_FUNCTION_ID = "";
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridDataItem item in grdUsers.MasterTableView.Items)
            {
                CheckBox chkbx = (CheckBox)item["ChkAssign"].FindControl("ChkBxAllocate");

                if (chkbx != null)
                {
                    if (chkbx.Checked)
                    {
                        TCSUserCode = item["USER_CODE"].Text;
                        ULE_RLE_ROLE_ID = item["ULE_RLE_ROLE_ID"].Text;
                        USER_STARTDATE =Convert.ToDateTime(item["USER_STARTDATE"].Text);
                        ULE_PFY_PTY_PARTY_ID = item["ULE_PFY_PTY_PARTY_ID"].Text;
                        ULE_PFY_PARTY_FUNCTION_ID = item["ULE_PFY_PARTY_FUNCTION_ID"].Text;

                        Main.Update_IT_UnlockUser(TCSUserCode, ULE_RLE_ROLE_ID, USER_STARTDATE, ULE_PFY_PTY_PARTY_ID, ULE_PFY_PARTY_FUNCTION_ID);

                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TCS_Unlock.aspx");
        }
    }
}