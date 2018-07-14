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
    public partial class AgentHierarchy : System.Web.UI.Page
    {
        string UserName = "";
        CommissionClass com = new CommissionClass();
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

                    CmbNewLevel.Items.Clear();
                    CmbNewLevel.DataSource = com.SelectType("AGENT_LEVEL_WITHOUT0");
                    CmbNewLevel.DataValueField = "AGENT_LEVEL";
                    CmbNewLevel.DataTextField = "LEVEL_DESCRIPTION";
                    CmbNewLevel.DataBind();

                    grdAgentSearch.DataSource = new int[] { };
                    grdAgentParent.DataSource = new int[] { };

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


        protected void btnAddParent_Click(object sender, EventArgs e)
        {
           
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = com.SelectAgentHierarchyData("CASE2", txtAgentCode.Text, "", "");
                Decimal PercentageSum=0;
                if (dt1.Rows.Count == 0)
                {
                    //Check if changed parent exists in the ref table
                    if (lblApprove.Text == "1")
                    {
                        foreach (GridDataItem item in grdAgentParent.Items)
                        {
                            TextBox ParentCode = (TextBox)item["PARENT_CODE"].FindControl("txtParentCode");
                            DataTable dt2 = com.SelectAgentHierarchyData("CASE3", ParentCode.Text, "", "");

                            TextBox Percentage = (TextBox)item["PARENT_PERCENTAGE"].FindControl("txtParentCom");
                            if (dt2.Rows.Count == 0)
                            {
                                lblChangeParent.Text = "1";
                            }

                           //Check if maximum percentage is 45
                            PercentageSum +=  Convert.ToDecimal(Percentage.Text);


                        }
                    }
                    //Check if changed parent exists in the ref table--End


                    if ((lblChangeParent.Text != "1") && (PercentageSum <= 45))
                    {
                        foreach (GridDataItem item in grdAgentParent.Items)
                        {
                            TextBox ParentCode = (TextBox)item["PARENT_CODE"].FindControl("txtParentCode");
                            TextBox Percentage = (TextBox)item["PARENT_PERCENTAGE"].FindControl("txtParentCom");

                            string EndD =item["END_DATE"].Text;
                            DateTime? dt = null;
                            if (EndD != "&nbsp;")
                            {
                                dt = Convert.ToDateTime(EndD);
                            }

                            if (lblApprove.Text == "1")
                            {
                                com.InsertAgentHierarchy(txtAgentCode.Text, ParentCode.Text, Convert.ToDecimal(Percentage.Text),
                                    item["PARENT_LEVEL"].Text, "INACTIVE", Session["USER"].ToString(), dt);
                                lblError.Text = "Hierachy sent for Approval..";
                               
                                Session["TableRecords"] = null;
                                BtnInsert.Enabled = false;
                            }
                            else
                            {
                                com.InsertAgentHierarchy(txtAgentCode.Text, ParentCode.Text, Convert.ToDecimal(Percentage.Text),
                                    item["PARENT_LEVEL"].Text, "ACTIVE", Session["USER"].ToString(), dt);
                                lblError.Text = "Insert Successful..";
                              
                                Session["TableRecords"] = null;
                                BtnInsert.Enabled = false;
                            }


                        }
                    }
                    else
                    {
                        lblError.Text = "Parent Code does not exists or Commission Percentage exeeds the maximum..";
                        lblChangeParent.Text = "";
                    }

                }
                else
                {
                    lblError.Text = "Hierarchy already exists..";
                }
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
                DataTable dt1 = com.SelectAgentData("CASE1", txtAgentCodeSearch.Text, "", "");
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

        protected void grdAgentSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Session["TableRecords"] = null;
                    GridDataItem dataitem = e.Item as GridDataItem;
                    DataTable dt1 = com.SelectAgentHierarchyData("CASE1", dataitem["PARENT_CODE"].Text, "", "");

                    txtAgentCode.Text = dataitem["AGENT_CODE"].Text;

                    grdAgentParent.DataSource = dt1;
                    grdAgentParent.DataBind();

                    Session["TableRecords"] = dt1;
                    
                    //DataTable table = new DataTable();
                    //table.Columns.Add("AGENTID", typeof(string));
                    //table.Columns.Add("AGENT_CODE", typeof(string));
                    //table.Columns.Add("AGENT_NAME", typeof(string));
                    //table.Columns.Add("PARENT_CODE", typeof(string));
                    //table.Columns.Add("COMMISSION", typeof(string));
                    //table.Columns.Add("AGENT_LEVEL", typeof(string));

                    //if (dt1.Rows.Count > 0)
                    //{
                    //    table.Rows.Add(dt1.Rows[0]["AGENTID"].ToString(),
                    //                  dt1.Rows[0]["AGENT_CODE"].ToString(),
                    //                  dt1.Rows[0]["AGENT_NAME"].ToString(),
                    //                  dt1.Rows[0]["PARENT_CODE"].ToString(),
                    //                  dt1.Rows[0]["COMMISSION"].ToString(),
                    //                  dt1.Rows[0]["AGENT_LEVEL"].ToString()
                    //                  );

                    //    DataTable dt2 = com.SelectAgentData("CASE1", dt1.Rows[0]["PARENT_CODE"].ToString(), "", "");
                    //    if (dt2.Rows.Count > 0)
                    //    {
                    //        table.Rows.Add(dt2.Rows[0]["AGENTID"].ToString(),
                    //                       dt2.Rows[0]["AGENT_CODE"].ToString(),
                    //                       dt2.Rows[0]["AGENT_NAME"].ToString(),
                    //                       dt2.Rows[0]["PARENT_CODE"].ToString(),
                    //                       dt2.Rows[0]["COMMISSION"].ToString(),
                    //                       dt2.Rows[0]["AGENT_LEVEL"].ToString()
                    //     );

                    //    }

                    //grdAgentParent.DataSource = table;
                    //grdAgentParent.DataBind();
                    //  }
                    //else
                    //{
                    //    grdAgentParent.DataSource = new int[] { };
                    //} 




                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void grdAgentParent_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Change")
                {
                    GridEditableItem item = e.Item as GridEditableItem;
                    (item["PARENT_CODE"].FindControl("txtParentCode")  as TextBox).ReadOnly = false;
                    (item["PARENT_PERCENTAGE"].FindControl("txtParentCom") as TextBox).ReadOnly = false;
                    lblApprove.Text = "1";
                   
                }

                if (e.CommandName == "Remove")
                {

                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dt1 = (DataTable)Session["TableRecords"];

                    TextBox ParentCode = (TextBox)dataitem["PARENT_CODE"].FindControl("txtParentCode");
                    string Parent = ParentCode.Text;

                    foreach (DataRow dr in dt1.Rows)
                    {
                        if (dr["PARENT_CODE"].ToString() == Parent)
                        {
                             dr.Delete();
                             lblApprove.Text = "1";
                        }

                    }

                    grdAgentParent.DataSource = dt1;
                    grdAgentParent.DataBind();

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
            Session["TableRecords"] = null;
            Response.Redirect("AgentHierarchy.aspx");
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Session["TableRecords"] = null;
            Response.Redirect("AgentHierarchy.aspx");
        }

        protected void BtnAddParent_Click1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt2 = com.SelectAgentHierarchyData("CASE3", txtNewPArentCode.Text, "", "");
                  if (dt2.Rows.Count != 0)
                   {
                       DataTable dt1 = (DataTable)Session["TableRecords"];

                       DateTime? EndDate = null;
                       EndDate = dtNewEndDate.SelectedDate;

                       dt1.Rows.Add("", txtNewPArentCode.Text, Convert.ToDecimal(txtNewCommission.Text), CmbNewLevel.SelectedValue.ToString(), EndDate);

                       grdAgentParent.DataSource = dt1;
                       grdAgentParent.DataBind();

                       lblApprove.Text = "1";
                       Session["TableRecords"] = dt1;
                   }
                   else
                    {
                        lblError.Text = "Invalid...";
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