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
using quickinfo_v2.Connectivity;
using quickinfo_v2.CommonCLS;

namespace quickinfo_v2.Views.Commission
{
    
    public partial class Parameter_Setup : System.Web.UI.Page
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
                    CmbValue.Items.Clear();
                    CmbValue.DataSource = com.SelectType("VALUE_TYPE");
                    CmbValue.DataValueField = "DESCRIPTION";
                    CmbValue.DataTextField = "DESCRIPTION";
                    CmbValue.DataBind();
                    CmbValue.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));
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


        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                com.InsertParameters(txtDes.Text, "ACTIVE", Session["USER"].ToString(), CmbValue.SelectedItem.Text, txtLength.Text);
                lblError.Text = "Insert Successfull..";
                DataTable Dt1 = com.MaxJobNo_Param();
                if (Dt1.Rows.Count > 0)
                {
                    txtParamID.Text = Dt1.Rows[0]["JOBS"].ToString();
                
                }
                BtnInsert.Enabled = false;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }

        }

        protected void btnSearch1_Click(object sender, EventArgs e)
        {

            try 
            {
            DataTable dt1=    com.SelectParamData("CASE1", txtParamIDSrch.Text, txtDesSearch.Text, "", "");
            grdParaSearch.DataSource = dt1;
            grdParaSearch.DataBind();

           
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
                com.UpdateParameters(txtParamID.Text, txtDes.Text, Session["USER"].ToString(), CmbValue.SelectedItem.Text, txtLength.Text);
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

        protected void grdParaSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dt2 = com.SelectParamData("CASE2", dataitem["PARAMID"].Text, txtDesSearch.Text, "", "");
                    grdParaSearch.DataSource = dt2;
                    grdParaSearch.DataBind();

                    BtnInsert.Enabled = false;

                    txtParamID.Text = dt2.Rows[0]["PARAMID"].ToString();
                    txtDes.Text = dt2.Rows[0]["PARAMDESCRIPTION"].ToString();

                    if (dt2.Rows[0]["VALUETYPE"].ToString() != "")
                    {

                        CmbValue.Items.Clear();
                        CmbValue.DataSource = com.SelectType("VALUE_TYPE");
                        CmbValue.DataValueField = "DESCRIPTION";
                        CmbValue.DataTextField = "DESCRIPTION";
                        CmbValue.DataBind();
                        CmbValue.Items.Insert(0, new RadComboBoxItem(dt2.Rows[0]["VALUETYPE"].ToString(), dt2.Rows[0]["VALUETYPE"].ToString()));
                    }

                    txtLength.Text = dt2.Rows[0]["PARAMLENGTH"].ToString();

                }
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

            Response.Redirect("parameter_setup.aspx");
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("parameter_setup.aspx");
        }
    }
}