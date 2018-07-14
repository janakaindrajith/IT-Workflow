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
    public partial class ReferanceData : System.Web.UI.Page
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
                    CmbRefTypeSrch.Items.Clear();
                    CmbRefTypeSrch.DataSource = com.SelectType("REF_TYPE");
                    CmbRefTypeSrch.DataValueField = "PARAMID";
                    CmbRefTypeSrch.DataTextField = "PARAMDESCRIPTION";
                    CmbRefTypeSrch.DataBind();
                    CmbRefTypeSrch.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    CmbRefType.Items.Clear();
                    CmbRefType.DataSource = com.SelectType("REF_TYPE");
                    CmbRefType.DataValueField = "PARAMID";
                    CmbRefType.DataTextField = "PARAMDESCRIPTION";
                    CmbRefType.DataBind();
                    CmbRefType.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));
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

                DataTable dt1 = com.SelectParamData("CASE3", CmbRefTypeSrch.SelectedValue.ToString(), txtDesSearch.Text, txtCodeSrch.Text, "");
                grdRefSearch.DataSource = dt1;
                grdRefSearch.DataBind();


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
                com.InsertReferanceData(txtCode.Text, txtDes.Text, "ACTIVE", Session["USER"].ToString(), CmbRefType.SelectedValue.ToString());
                lblError.Text = "Insert Successfull..";
                BtnInsert.Enabled = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void grdRefSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dt2 = com.SelectParamData("CASE4", dataitem["ID"].Text, txtDesSearch.Text, "", "");
                    grdRefSearch.DataSource = dt2;
                    grdRefSearch.DataBind();

                    BtnInsert.Enabled = false;

                    lblID.Text = dt2.Rows[0]["ID"].ToString();
                    txtCode.Text = dt2.Rows[0]["CODE"].ToString();
                    txtDes.Text = dt2.Rows[0]["DESCRIPTION"].ToString();

                    if (dt2.Rows[0]["REF_TYPE"].ToString() != "")
                    {
                        CmbRefType.Items.Clear();
                        CmbRefType.DataSource = com.SelectType("REF_TYPE");
                        CmbRefType.DataValueField = "PARAMID";
                        CmbRefType.DataTextField = "PARAMDESCRIPTION";
                        CmbRefType.DataBind();
                        CmbRefType.Items.Insert(0, new RadComboBoxItem(dt2.Rows[0]["PARAMDESCRIPTION"].ToString(), dt2.Rows[0]["REF_TYPE"].ToString()));

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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                com.UpdateReferance(lblID.Text, txtCode.Text, txtDes.Text, Session["USER"].ToString(), CmbRefType.SelectedValue.ToString());
                lblError.Text = "Update Successfull..";
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
            Response.Redirect("ReferanceData.aspx");
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReferanceData.aspx");
        }

    }
}