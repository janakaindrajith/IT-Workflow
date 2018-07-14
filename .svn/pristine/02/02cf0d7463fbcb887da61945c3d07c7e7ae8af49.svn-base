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
    public partial class RuleGeneration : System.Web.UI.Page
    {
        CommissionClass com = new CommissionClass();
        string UserName = "";
        DataTable table = new DataTable();
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
                    grdRuleSearch.DataSource = new int[] { };
                    grdRuleRowByRow.DataSource = new int[] { };

                    DataTable ComType = com.SelectType("COMISSION_TYPE");

                    ddlComType.Items.Clear();
                    ddlComType.DataSource = ComType;
                    ddlComType.DataValueField = "DESCRIPTION";
                    ddlComType.DataTextField = "DESCRIPTION";
                    ddlComType.DataBind();

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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = com.SelectParamData("CASE6", txtRuleID.Text, txtDesSearch.Text, "", "");
                grdRuleSearch.DataSource = dt1;
                grdRuleSearch.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void grdRuleSearch_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {

                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dt2 = com.SelectParamData("CASE7", dataitem["RULE_ID"].Text, "", "", "");
                    grdRuleSearch.DataSource = dt2;
                    grdRuleSearch.DataBind();

                    lblID.Text = dataitem["RULE_ID"].Text;

                    btnaddnew.Enabled = false;

                    if (dt2.Rows[0]["RULE_DES"].ToString() != "")
                    {
                        txtRuleDes.Text = dt2.Rows[0]["RULE_DES"].ToString();
                    }
                    if (dt2.Rows[0]["PERCENTAGE"].ToString() != "")
                    {
                        txtPercentage.Text = dt2.Rows[0]["PERCENTAGE"].ToString();
                    }
                    if (dt2.Rows[0]["RULE_DEFINITION"].ToString() != "")
                    {
                        txtQuery.Text = dt2.Rows[0]["RULE_DEFINITION"].ToString();
                    }
                    if (dt2.Rows[0]["TYPE"].ToString() != "")
                    {
                        ddlComType.Items.Insert(0, new RadComboBoxItem(dt2.Rows[0]["TYPE"].ToString(), dt2.Rows[0]["TYPE"].ToString()));
                    }

                    DataTable dt3 = com.SelectParamData("CASE8", dataitem["RULE_ID"].Text, "", "", "");
                    grdRuleRowByRow.DataSource = dt3;
                    grdRuleRowByRow.DataBind();

                    DataTable Brackets = com.SelectType("BRACKETS");
                    DataTable RefType = com.SelectType("REF_TYPE");
                    DataTable Controlers = com.SelectType("CONTROLERS");
                    DataTable Operators = com.SelectType("OPERATORS");

                    int rownum ;
                    int i = 0;
                    foreach (GridDataItem item in grdRuleRowByRow.MasterTableView.Items)
                    {
                            rownum = Convert.ToInt32(item["LINE_NO"].Text);

                            if (dt3.Rows[i]["COL1"].ToString() != "")
                            {
                                RadComboBox ddl = (RadComboBox)item.FindControl("ddlBrac");
                                ddl.DataSource = Brackets;
                                ddl.DataTextField = "DESCRIPTION";
                                ddl.DataValueField = "DESCRIPTION";
                                ddl.DataBind();
                                ddl.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i]["COL1"].ToString(), dt3.Rows[i]["COL1"].ToString()));
                                ddl.Items.Insert(1, new RadComboBoxItem("--", ""));
                            }
                            else
                            {
                                RadComboBox ddl = (RadComboBox)item.FindControl("ddlBrac");
                                ddl.DataSource = Brackets;
                                ddl.DataTextField = "DESCRIPTION";
                                ddl.DataValueField = "DESCRIPTION";
                                ddl.DataBind();
                                ddl.Items.Insert(0, new RadComboBoxItem("--", ""));

                            }
                            if (dt3.Rows[i ]["COL2"].ToString() != "")
                            {
                                RadComboBox Type = (RadComboBox)item.FindControl("ddlType");
                                Type.DataSource = RefType;
                                Type.DataTextField = "PARAMDESCRIPTION";
                                Type.DataValueField = "PARAMID";
                                Type.DataBind();
                                Type.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i ]["COL2DES"].ToString(), dt3.Rows[i]["COL2"].ToString()));
                                Type.Items.Insert(1, new RadComboBoxItem("--Select Type--", ""));
                            }
                            else
                            {
                                RadComboBox Type = (RadComboBox)item.FindControl("ddlType");
                                Type.DataSource = RefType;
                                Type.DataTextField = "PARAMDESCRIPTION";
                                Type.DataValueField = "PARAMID";
                                Type.DataBind();
                                Type.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));
                            }

                            if (dt3.Rows[i ]["COL3"].ToString() != "")
                            {
                                RadComboBox ddlOp1 = (RadComboBox)item.FindControl("ddlOp");
                                ddlOp1.Items.Clear();
                                ddlOp1.DataSource = Operators;
                                ddlOp1.DataValueField = "OPERATORS";
                                ddlOp1.DataTextField = "OPERATORS";
                                ddlOp1.DataBind();
                                ddlOp1.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i ]["COL3"].ToString(), dt3.Rows[i]["COL3"].ToString()));
                            }
                            else
                            {
                                RadComboBox ddlOp1 = (RadComboBox)item.FindControl("ddlOp");
                                ddlOp1.Items.Clear();
                                ddlOp1.DataSource = Operators;
                                ddlOp1.DataValueField = "OPERATORS";
                                ddlOp1.DataTextField = "OPERATORS";
                                ddlOp1.DataBind();

                           
                            }
                            if (dt3.Rows[i]["COL4"].ToString() != "")
                            {
                                RadComboBox ddlValue8 = (RadComboBox)item.FindControl("ddlValue");
                                ddlValue8.Items.Clear();
                                ddlValue8.DataSource = com.SelectParamData("CASE5", dt3.Rows[i]["COL2"].ToString(), "", "", ""); ;
                                ddlValue8.DataValueField = "ID";
                                ddlValue8.DataTextField = "CODE";
                                ddlValue8.DataBind();
                                ddlValue8.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i ]["COL4DES"].ToString(), dt3.Rows[i ]["COL4"].ToString()));
                                ddlValue8.Items.Insert(1, new RadComboBoxItem("--Select Value--", ""));
                            }
                            else
                            {
                                RadComboBox ddlValue8 = (RadComboBox)item.FindControl("ddlValue");
                                ddlValue8.Items.Clear();
                                ddlValue8.DataSource = com.SelectParamData("CASE5", dt3.Rows[i]["COL2"].ToString(), "", "", ""); ;
                                ddlValue8.DataValueField = "ID";
                                ddlValue8.DataTextField = "CODE";
                                ddlValue8.DataBind();
                                ddlValue8.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));

                            }

                            if (dt3.Rows[i]["COL5"].ToString() != "")
                            {
                                RadComboBox ddlBR = (RadComboBox)item.FindControl("ddlRBrac");
                                ddlBR.DataSource = Brackets;
                                ddlBR.DataTextField = "DESCRIPTION";
                                ddlBR.DataValueField = "DESCRIPTION";
                                ddlBR.DataBind();
                                ddlBR.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i]["COL5"].ToString(), dt3.Rows[i]["COL5"].ToString()));
                                ddlBR.Items.Insert(1, new RadComboBoxItem("--", ""));
                            }
                            else
                            {
                                RadComboBox ddlBR = (RadComboBox)item.FindControl("ddlRBrac");
                                ddlBR.DataSource = Brackets;
                                ddlBR.DataTextField = "DESCRIPTION";
                                ddlBR.DataValueField = "DESCRIPTION";
                                ddlBR.DataBind();
                                ddlBR.Items.Insert(0, new RadComboBoxItem("--", ""));

                            }

                            if (dt3.Rows[i ]["COL6"].ToString() != "")
                            {
                                RadComboBox DdlCon1 = (RadComboBox)item.FindControl("DdlCon");
                                DdlCon1.Items.Clear();
                                DdlCon1.DataSource = Controlers;
                                DdlCon1.DataValueField = "DESCRIPTION";
                                DdlCon1.DataTextField = "DESCRIPTION";
                                DdlCon1.DataBind();
                                DdlCon1.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i]["COL6"].ToString(), dt3.Rows[i]["COL6"].ToString()));
                            }
                            else
                            {
                                RadComboBox DdlCon1 = (RadComboBox)item.FindControl("DdlCon");
                                DdlCon1.Items.Clear();
                                DdlCon1.DataSource = Controlers;
                                DdlCon1.DataValueField = "DESCRIPTION";
                                DdlCon1.DataTextField = "DESCRIPTION";
                                DdlCon1.DataBind();

                            }

                            i++;



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

        protected void btnaddnew_Click(object sender, EventArgs e)
        {
            DataTable dd = (DataTable)Session["tb"];
            if (dd != null)
            {
                table = (DataTable)Session["tb"];
            }
            else
            {
                table.Columns.Add("ROWID", typeof(string));

            }

            int rowID = Convert.ToInt32(lblRowID.Text) + 1;
            lblRowID.Text = rowID.ToString();


            string a = "";


            table.Rows.Add(rowID);
            Session["tb"] = table;

            grdRuleRowByRow.DataSource = table;
            grdRuleRowByRow.DataBind();


            DataTable Brackets = com.SelectType("BRACKETS");
            DataTable RefType = com.SelectType("REF_TYPE");
            DataTable Controlers = com.SelectType("CONTROLERS");
            DataTable Operators = com.SelectType("OPERATORS");

            string rownum = "";

            foreach (GridDataItem item in grdRuleRowByRow.MasterTableView.Items)
            {
                rownum = item["LINE_NO"].Text;
                RadComboBox ddl = (RadComboBox)item.FindControl("ddlBrac");
                    ddl.DataSource = Brackets;
                    ddl.DataTextField = "DESCRIPTION";
                    ddl.DataValueField = "DESCRIPTION";
                    ddl.DataBind();
                    ddl.Items.Insert(0, new RadComboBoxItem("--", ""));



                    RadComboBox ddlBR = (RadComboBox)item.FindControl("ddlRBrac");
                    ddlBR.DataSource = Brackets;
                    ddlBR.DataTextField = "DESCRIPTION";
                    ddlBR.DataValueField = "DESCRIPTION";
                    ddlBR.DataBind();
                    ddlBR.Items.Insert(0, new RadComboBoxItem("--", ""));

                    RadComboBox Type = (RadComboBox)item.FindControl("ddlType");
                    Type.DataSource = RefType;
                    Type.DataTextField = "PARAMDESCRIPTION";
                    Type.DataValueField = "PARAMID";
                    Type.DataBind();
                    Type.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    RadComboBox DdlCon1 = (RadComboBox)item.FindControl("DdlCon");
                    DdlCon1.Items.Clear();
                    DdlCon1.DataSource = Controlers;
                    DdlCon1.DataValueField = "DESCRIPTION";
                    DdlCon1.DataTextField = "DESCRIPTION";
                    DdlCon1.DataBind();


                    RadComboBox ddlOp1 = (RadComboBox)item.FindControl("ddlOp");
                    ddlOp1.Items.Clear();
                    ddlOp1.DataSource = Operators;
                    ddlOp1.DataValueField = "OPERATORS";
                    ddlOp1.DataTextField = "OPERATORS";
                    ddlOp1.DataBind();

                
            }




            }

        protected void grdRuleRowByRow_ItemDataBound(object sender, GridItemEventArgs e)
        {


            //DataTable Brackets = com.SelectType("BRACKETS");
            //DataTable RefType = com.SelectType("REF_TYPE");
            //DataTable Controlers = com.SelectType("CONTROLERS");
            //DataTable Operators = com.SelectType("OPERATORS");

            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem item = (GridDataItem)e.Item;

            //    RadComboBox ddl = (RadComboBox)item.FindControl("ddlBrac");

            //    string rownum = "";
            //    rownum = item["LINE_NO"].Text;
            //    if (grdRuleRowByRow.MasterTableView.Items.Count.ToString() != rownum)
            //    {
            //        ddl.AutoPostBack = false;
            //        ddl.DataSource = Brackets;
            //        ddl.DataTextField = "DESCRIPTION";
            //        ddl.DataValueField = "DESCRIPTION";
            //        ddl.DataBind();
            //        ddl.Items.Insert(0, new RadComboBoxItem("--", ""));
            //    }

            //    else
            //    {
            //        ddl.DataSource = Brackets;
            //        ddl.DataTextField = "DESCRIPTION";
            //        ddl.DataValueField = "DESCRIPTION";
            //        ddl.DataBind();
            //        ddl.Items.Insert(0, new RadComboBoxItem("--", ""));

            //    }

            //    RadComboBox ddlBR = (RadComboBox)item.FindControl("ddlRBrac");
            //    ddlBR.DataSource = Brackets;
            //    ddlBR.DataTextField = "DESCRIPTION";
            //    ddlBR.DataValueField = "DESCRIPTION";
            //    ddlBR.DataBind();
            //    ddlBR.Items.Insert(0, new RadComboBoxItem("--", ""));

            //    RadComboBox Type = (RadComboBox)item.FindControl("ddlType");
            //    Type.DataSource = RefType;
            //    Type.DataTextField = "PARAMDESCRIPTION";
            //    Type.DataValueField = "PARAMID";
            //    Type.DataBind();
            //    Type.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

            //    RadComboBox DdlCon1 = (RadComboBox)item.FindControl("DdlCon");
            //    DdlCon1.Items.Clear();
            //    DdlCon1.DataSource = Controlers;
            //    DdlCon1.DataValueField = "DESCRIPTION";
            //    DdlCon1.DataTextField = "DESCRIPTION";
            //    DdlCon1.DataBind();


            //    RadComboBox ddlOp1 = (RadComboBox)item.FindControl("ddlOp");
            //    ddlOp1.Items.Clear();
            //    ddlOp1.DataSource = Operators;
            //    ddlOp1.DataValueField = "OPERATORS";
            //    ddlOp1.DataTextField = "OPERATORS";
            //    ddlOp1.DataBind();


            //}
        }

        protected void ddlType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

             foreach (GridDataItem item in grdRuleRowByRow.MasterTableView.Items)
            {

                RadComboBox Type = (RadComboBox)item.FindControl("ddlType");
                RadComboBox ddlValue8 = (RadComboBox)item.FindControl("ddlValue");

                if (ddlValue8.SelectedValue.ToString() == "")
                {
                    ddlValue8.Items.Clear();
                    ddlValue8.DataSource = com.SelectParamData("CASE5", Type.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue8.DataValueField = "ID";
                    ddlValue8.DataTextField = "CODE";
                    ddlValue8.DataBind();
                    ddlValue8.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
               
            }

            
        }

        protected void btnCreateRule_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPercentage.Text != "")
                {
                    if (lblID.Text != "")
                    {
                        btnUpdate.Enabled = true;
                    }
                    if (lblID.Text == "")
                    {
                        btnSave.Enabled = true;
                    }
                    //  txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString();

                    string query = "";
                    string rownum = "";
                    foreach (GridDataItem item in grdRuleRowByRow.MasterTableView.Items)
                    {
                        rownum = item["LINE_NO"].Text;
                        RadComboBox BracLeft = (RadComboBox)item.FindControl("ddlBrac");
                        RadComboBox Type = (RadComboBox)item.FindControl("ddlType");
                        RadComboBox Operator = (RadComboBox)item.FindControl("ddlOp");
                        RadComboBox Value = (RadComboBox)item.FindControl("ddlValue");
                        RadComboBox BracRight = (RadComboBox)item.FindControl("ddlRBrac");
                        RadComboBox LogicalCon = (RadComboBox)item.FindControl("DdlCon");


                        query = query + BracLeft.SelectedValue.ToString() + Type.SelectedItem.Text + Operator.SelectedItem.Text + "'" + Value.SelectedItem.Text + "'" + BracRight.SelectedValue.ToString();

                        if (grdRuleRowByRow.MasterTableView.Items.Count.ToString() != rownum)
                        {
                            query = query + LogicalCon.SelectedValue.ToString();
                        }

                    }
                    txtQuery.Text = query;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try 
            {
            if(txtQuery.Text !="")
            {

                com.InsertRule(txtRuleDes.Text, "ACTIVE", Session["USER"].ToString(), txtQuery.Text, ddlComType.SelectedItem.Text, txtPercentage.Text);

                DataTable Dt1 = com.MaxJobNo_Rule();
                if (Dt1.Rows.Count > 0)
                {
                    txtRuleID.Text = Dt1.Rows[0]["JOBS"].ToString();

                }

                foreach (GridDataItem item in grdRuleRowByRow.MasterTableView.Items)
                {
                    //   rownum = item["LINE_NO"].Text;
                    RadComboBox BracLeft = (RadComboBox)item.FindControl("ddlBrac");
                    RadComboBox Type = (RadComboBox)item.FindControl("ddlType");
                    RadComboBox Operator = (RadComboBox)item.FindControl("ddlOp");
                    RadComboBox Value = (RadComboBox)item.FindControl("ddlValue");
                    RadComboBox BracRight = (RadComboBox)item.FindControl("ddlRBrac");
                    RadComboBox LogicalCon = (RadComboBox)item.FindControl("DdlCon");

                    if ((Type.SelectedValue.ToString() != "") && (Value.SelectedValue.ToString() != ""))
                    {
                        string b1 = "";
                        string b2 = "";
                        if (BracLeft.SelectedItem.Text != "--")
                        {
                            b1 = BracLeft.SelectedValue.ToString();
                        }


                        if (BracRight.SelectedItem.Text != "--")
                        {
                            b2 = BracRight.SelectedValue.ToString();
                        }
                        string LoglCon = "";
                        if (grdRuleRowByRow.MasterTableView.Items.Count.ToString() != item["LINE_NO"].Text)
                        {
                            LoglCon = LogicalCon.SelectedValue.ToString();
                        }

                        com.InsertRule_RowByRow(txtRuleID.Text, item["LINE_NO"].Text, b1, Type.SelectedValue.ToString(), Operator.SelectedValue.ToString(), Value.SelectedValue.ToString(), b2,
                            LoglCon);
                      
                    }
                    else
                    {
                        lblError.Text = "Invalid...";
                    }
                }

                lblError.Text = "Insert Successful.Rule ID : " + txtRuleID.Text;
                btnSave.Enabled = false;
                btnCreateRule.Enabled = false;
                                    
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

        protected void grdRuleSearch_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                DataTable dt1 = com.SelectParamData("CASE6", txtRuleID.Text, txtDesSearch.Text, "", "");
                grdRuleSearch.DataSource = dt1;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtQuery.Text != "")
                {
                    com.UpdateRule(lblID.Text, txtRuleDes.Text, "ACTIVE", Session["USER"].ToString(), txtQuery.Text, ddlComType.SelectedItem.Text, txtPercentage.Text);

                    foreach (GridDataItem item in grdRuleRowByRow.MasterTableView.Items)
                    {
                        //   rownum = item["LINE_NO"].Text;
                        RadComboBox BracLeft = (RadComboBox)item.FindControl("ddlBrac");
                        RadComboBox Type = (RadComboBox)item.FindControl("ddlType");
                        RadComboBox Operator = (RadComboBox)item.FindControl("ddlOp");
                        RadComboBox Value = (RadComboBox)item.FindControl("ddlValue");
                        RadComboBox BracRight = (RadComboBox)item.FindControl("ddlRBrac");
                        RadComboBox LogicalCon = (RadComboBox)item.FindControl("DdlCon");

                        if ((Type.SelectedValue.ToString() != "") && (Value.SelectedValue.ToString() != ""))
                        {
                            string b1 = "";
                            string b2 = "";
                            if (BracLeft.SelectedItem.Text != "--")
                            {
                                b1 = BracLeft.SelectedValue.ToString();
                            }


                            if (BracRight.SelectedItem.Text != "--")
                            {
                                b2 = BracRight.SelectedValue.ToString();
                            }
                            string LoglCon = "";
                            if (grdRuleRowByRow.MasterTableView.Items.Count.ToString() != item["LINE_NO"].Text)
                            {
                                LoglCon = LogicalCon.SelectedValue.ToString();
                            }

                            com.UpdateRule_RowByRow(lblID.Text, item["LINE_NO"].Text, b1, Type.SelectedValue.ToString(), Operator.SelectedValue.ToString(), Value.SelectedValue.ToString(), b2,
                                LoglCon);

                        }
                        else
                        {
                            lblError.Text = "Invalid...";
                        }
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


    }
}