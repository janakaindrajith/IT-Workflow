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

namespace quickinfo_v2.Views.Commission
{
    public partial class AdvisorCreation : System.Web.UI.Page
    {
        CommissionClass com = new CommissionClass();
        string UserName = "";
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

                    CmbLevel.Items.Clear();
                    CmbLevel.DataSource = com.SelectType("AGENT_LEVEL");
                    CmbLevel.DataValueField = "AGENT_LEVEL";
                    CmbLevel.DataTextField = "LEVEL_DESCRIPTION";
                    CmbLevel.DataBind();

                    CmbStatus.Items.Clear();
                    CmbStatus.Items.Insert(0, new RadComboBoxItem("ACTIVE", "ACTIVE"));
                    CmbStatus.Items.Insert(1, new RadComboBoxItem("INACTIVE", "INACTIVE"));

                    grdAgentSearch.DataSource = new int[] { };
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
                DataTable dt1 = com.SelectParamData("CASE9", txtAgentCodeSearch.Text, txtDesSearch.Text, "", "");
                grdAgentSearch.DataSource = dt1;
                grdAgentSearch.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = com.SelectParamData("CASE11", txtAgentCode.Text, "", "", "");
                if (dt1.Rows.Count == 0)
                {

                    com.InsertAgentRef(txtAgentCode.Text, txtDes.Text, CmbStatus.SelectedItem.Text, CmbLevel.SelectedValue.ToString(), Session["USER"].ToString());
                    lblError.Text = "Insert Successful..";
                    BtnInsert.Enabled = false;
                }
                else
                {
                    lblError.Text = "Agent Code already exists..";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void grdAgentSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {

                    GridDataItem dataitem = e.Item as GridDataItem;
                    DataTable dt1 = com.SelectParamData("CASE10", dataitem["AGENTID"].Text, "", "", "");
                    grdAgentSearch.DataSource = dt1;

                    lblID.Text = dt1.Rows[0]["AGENTID"].ToString();
                    txtAgentCode.Text = dt1.Rows[0]["AGENT_CODE"].ToString();
                    txtDes.Text = dt1.Rows[0]["AGENT_DESCRIPTION"].ToString();

                    CmbLevel.Items.Clear();
                    CmbLevel.DataSource = com.SelectType("AGENT_LEVEL");
                    CmbLevel.DataValueField = "AGENT_LEVEL";
                    CmbLevel.DataTextField = "LEVEL_DESCRIPTION";
                    CmbLevel.DataBind();
                    CmbLevel.Items.Insert(0, new RadComboBoxItem(dt1.Rows[0]["LEVEL_DESCRIPTION"].ToString(), dt1.Rows[0]["AGENT_LEVEL"].ToString()));

                    CmbStatus.Items.Insert(0, new RadComboBoxItem(dt1.Rows[0]["STATUS"].ToString(), dt1.Rows[0]["STATUS"].ToString()));

                    BtnInsert.Enabled = false;
                    BtnUpdate.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                com.UpdateAgentRef(lblID.Text,txtAgentCode.Text, txtDes.Text, CmbStatus.SelectedItem.Text, CmbLevel.SelectedValue.ToString(), Session["USER"].ToString());
                lblError.Text = "Update Successful..";
                BtnUpdate.Enabled = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorCreation.aspx");
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdvisorCreation.aspx");
        }
    }
}