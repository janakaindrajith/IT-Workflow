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
    public partial class TCS_PolicyCancelation_GI : System.Web.UI.Page
    {
        string UserName = ""; string UserChk = "0";
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    UserName = Context.User.Identity.Name;
                        //User.Identity.Name;
                    if (Left(UserName, 5) == "HNBGI")
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

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Users = Main.GetPolicyCancelUsers();

                for (int i = 0; i < Users.Rows.Count; i++)
                {

                    if (Users.Rows[i]["USER_NAME"].ToString() == Session["USER"].ToString())
                    {
                        UserChk = "1";

                    }

                }

                if (UserChk == "1")
                {
                    DataTable dtcon = Main.SelectCancelExpirePolicies(txtUserID.Text);
                    grdUsers.DataSource = dtcon;
                    grdUsers.DataBind();
                }
                else
                {
                    lblError.Text = "You Do Not Have Privileages..";
                }
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }

        }

        protected void ChkBxAllocate_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridDataItem item in grdUsers.MasterTableView.Items)
            {
                CheckBox chkbx = (CheckBox)item["ChkAssign"].FindControl("ChkBxAllocate");
            }
        }

        string PolNo = ""; string Status = "";

        //Cancel Policy - 09
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridDataItem item in grdUsers.MasterTableView.Items)
            {
                CheckBox chkbx = (CheckBox)item["ChkAssign"].FindControl("ChkBxAllocate");

                if (chkbx != null)
                {
                    if (chkbx.Checked)
                    {

                        PolNo = item["POLICY_NUMBER"].Text;
                        Status = item["POL_POLICY_STATUS"].Text;

                        Main.Update_IT_Cancel_Expire("CANCEL", PolNo);

                    }
                }
            }
        }


        //Expire Policy - 09
        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridDataItem item in grdUsers.MasterTableView.Items)
            {
                CheckBox chkbx = (CheckBox)item["ChkAssign"].FindControl("ChkBxAllocate");

                if (chkbx != null)
                {
                    if (chkbx.Checked)
                    {

                        PolNo = item["POLICY_NUMBER"].Text;
                        Status = item["POL_POLICY_STATUS"].Text;

                        Main.Update_IT_Cancel_Expire("EXPIRE", PolNo);


                    }
                }
            }
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("TCS_PolicyCancelation_GI.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TCS_PolicyCancelation_GI.aspx");
        }
    }
}