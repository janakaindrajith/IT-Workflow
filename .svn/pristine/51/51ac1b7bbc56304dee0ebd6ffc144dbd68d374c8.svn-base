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
    public partial class RuleEngine : System.Web.UI.Page
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
                    DataTable RefType = com.SelectType("REF_TYPE");

                    ddlType1.Items.Clear();
                    ddlType1.DataSource = RefType;
                    ddlType1.DataValueField = "PARAMID";
                    ddlType1.DataTextField = "PARAMDESCRIPTION";
                    ddlType1.DataBind();
                    ddlType1.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType2.Items.Clear();
                    ddlType2.DataSource = RefType;
                    ddlType2.DataValueField = "PARAMID";
                    ddlType2.DataTextField = "PARAMDESCRIPTION";
                    ddlType2.DataBind();
                    ddlType2.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType3.Items.Clear();
                    ddlType3.DataSource = RefType;
                    ddlType3.DataValueField = "PARAMID";
                    ddlType3.DataTextField = "PARAMDESCRIPTION";
                    ddlType3.DataBind();
                    ddlType3.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType4.Items.Clear();
                    ddlType4.DataSource = RefType;
                    ddlType4.DataValueField = "PARAMID";
                    ddlType4.DataTextField = "PARAMDESCRIPTION";
                    ddlType4.DataBind();
                    ddlType4.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType5.Items.Clear();
                    ddlType5.DataSource = RefType;
                    ddlType5.DataValueField = "PARAMID";
                    ddlType5.DataTextField = "PARAMDESCRIPTION";
                    ddlType5.DataBind();
                    ddlType5.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType6.Items.Clear();
                    ddlType6.DataSource = RefType;
                    ddlType6.DataValueField = "PARAMID";
                    ddlType6.DataTextField = "PARAMDESCRIPTION";
                    ddlType6.DataBind();
                    ddlType6.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType7.Items.Clear();
                    ddlType7.DataSource = RefType;
                    ddlType7.DataValueField = "PARAMID";
                    ddlType7.DataTextField = "PARAMDESCRIPTION";
                    ddlType7.DataBind();
                    ddlType7.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType8.Items.Clear();
                    ddlType8.DataSource = RefType;
                    ddlType8.DataValueField = "PARAMID";
                    ddlType8.DataTextField = "PARAMDESCRIPTION";
                    ddlType8.DataBind();
                    ddlType8.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType9.Items.Clear();
                    ddlType9.DataSource = RefType;
                    ddlType9.DataValueField = "PARAMID";
                    ddlType9.DataTextField = "PARAMDESCRIPTION";
                    ddlType9.DataBind();
                    ddlType9.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));

                    ddlType10.Items.Clear();
                    ddlType10.DataSource = RefType;
                    ddlType10.DataValueField = "PARAMID";
                    ddlType10.DataTextField = "PARAMDESCRIPTION";
                    ddlType10.DataBind();
                    ddlType10.Items.Insert(0, new RadComboBoxItem("--Select Type--", ""));


                    DataTable Controlers = com.SelectType("CONTROLERS");

                    DdlCon1.Items.Clear();
                    DdlCon1.DataSource = Controlers;
                    DdlCon1.DataValueField = "DESCRIPTION";
                    DdlCon1.DataTextField = "DESCRIPTION";
                    DdlCon1.DataBind();

                    DdlCon2.Items.Clear();
                    DdlCon2.DataSource = Controlers;
                    DdlCon2.DataValueField = "DESCRIPTION";
                    DdlCon2.DataTextField = "DESCRIPTION";
                    DdlCon2.DataBind();

                    DdlCon3.Items.Clear();
                    DdlCon3.DataSource = Controlers;
                    DdlCon3.DataValueField = "DESCRIPTION";
                    DdlCon3.DataTextField = "DESCRIPTION";
                    DdlCon3.DataBind();

                    DdlCon4.Items.Clear();
                    DdlCon4.DataSource = Controlers;
                    DdlCon4.DataValueField = "DESCRIPTION";
                    DdlCon4.DataTextField = "DESCRIPTION";
                    DdlCon4.DataBind();

                    DdlCon5.Items.Clear();
                    DdlCon5.DataSource = Controlers;
                    DdlCon5.DataValueField = "DESCRIPTION";
                    DdlCon5.DataTextField = "DESCRIPTION";
                    DdlCon5.DataBind();

                    DdlCon6.Items.Clear();
                    DdlCon6.DataSource = Controlers;
                    DdlCon6.DataValueField = "DESCRIPTION";
                    DdlCon6.DataTextField = "DESCRIPTION";
                    DdlCon6.DataBind();

                    DdlCon7.Items.Clear();
                    DdlCon7.DataSource = Controlers;
                    DdlCon7.DataValueField = "DESCRIPTION";
                    DdlCon7.DataTextField = "DESCRIPTION";
                    DdlCon7.DataBind();

                    DdlCon8.Items.Clear();
                    DdlCon8.DataSource = Controlers;
                    DdlCon8.DataValueField = "DESCRIPTION";
                    DdlCon8.DataTextField = "DESCRIPTION";
                    DdlCon8.DataBind();

                    DdlCon9.Items.Clear();
                    DdlCon9.DataSource = Controlers;
                    DdlCon9.DataValueField = "DESCRIPTION";
                    DdlCon9.DataTextField = "DESCRIPTION";
                    DdlCon9.DataBind();

                    DdlCon10.Items.Clear();
                    DdlCon10.Items.Insert(0, new RadComboBoxItem("", ""));


                    DataTable Operators = com.SelectType("OPERATORS");

                    ddlOp1.Items.Clear();
                    ddlOp1.DataSource = Operators;
                    ddlOp1.DataValueField = "OPERATORS";
                    ddlOp1.DataTextField = "OPERATORS";
                    ddlOp1.DataBind();


                    ddlOp2.Items.Clear();
                    ddlOp2.DataSource = Operators;
                    ddlOp2.DataValueField = "OPERATORS";
                    ddlOp2.DataTextField = "OPERATORS";
                    ddlOp2.DataBind();


                    ddlOp3.Items.Clear();
                    ddlOp3.DataSource = Operators;
                    ddlOp3.DataValueField = "OPERATORS";
                    ddlOp3.DataTextField = "OPERATORS";
                    ddlOp3.DataBind();


                    ddlOp4.Items.Clear();
                    ddlOp4.DataSource = Operators;
                    ddlOp4.DataValueField = "OPERATORS";
                    ddlOp4.DataTextField = "OPERATORS";
                    ddlOp4.DataBind();


                    ddlOp5.Items.Clear();
                    ddlOp5.DataSource = Operators;
                    ddlOp5.DataValueField = "OPERATORS";
                    ddlOp5.DataTextField = "OPERATORS";
                    ddlOp5.DataBind();

                    ddlOp6.Items.Clear();
                    ddlOp6.DataSource = Operators;
                    ddlOp6.DataValueField = "OPERATORS";
                    ddlOp6.DataTextField = "OPERATORS";
                    ddlOp6.DataBind();


                    ddlOp7.Items.Clear();
                    ddlOp7.DataSource = Operators;
                    ddlOp7.DataValueField = "OPERATORS";
                    ddlOp7.DataTextField = "OPERATORS";
                    ddlOp7.DataBind();

                    ddlOp8.Items.Clear();
                    ddlOp8.DataSource = Operators;
                    ddlOp8.DataValueField = "OPERATORS";
                    ddlOp8.DataTextField = "OPERATORS";
                    ddlOp8.DataBind();

                    ddlOp9.Items.Clear();
                    ddlOp9.DataSource = Operators;
                    ddlOp9.DataValueField = "OPERATORS";
                    ddlOp9.DataTextField = "OPERATORS";
                    ddlOp9.DataBind();

                    ddlOp10.Items.Clear();
                    ddlOp10.DataSource = Operators;
                    ddlOp10.DataValueField = "OPERATORS";
                    ddlOp10.DataTextField = "OPERATORS";
                    ddlOp10.DataBind();



                    DataTable Brackets = com.SelectType("BRACKETS");

                    for (int i = 1; i <= 10; i++)
                    {

                        RadComboBox Brac = Panel2.FindControl("ddlBrac" + i) as RadComboBox;
                        Brac.Items.Clear();
                        Brac.DataSource = Brackets;
                        Brac.DataValueField = "DESCRIPTION";
                        Brac.DataTextField = "DESCRIPTION";
                        Brac.DataBind();
                        Brac.Items.Insert(0, new RadComboBoxItem("--", ""));
                    }

                    for (int i = 1; i <= 10; i++)
                    {

                        RadComboBox Brac = Panel2.FindControl("ddlRBrac" + i) as RadComboBox;
                        Brac.Items.Clear();
                        Brac.DataSource = Brackets;
                        Brac.DataValueField = "DESCRIPTION";
                        Brac.DataTextField = "DESCRIPTION";
                        Brac.DataBind();
                        Brac.Items.Insert(0, new RadComboBoxItem("--", ""));
                    }


                    DataTable ComType = com.SelectType("COMISSION_TYPE");

                    ddlComType.Items.Clear();
                    ddlComType.DataSource = ComType;
                    ddlComType.DataValueField = "DESCRIPTION";
                    ddlComType.DataTextField = "DESCRIPTION";
                    ddlComType.DataBind();

                    grdRuleSearch.DataSource = new int[] { };

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

        protected void ddlType1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType1.SelectedIndex != 0)
                {
                    ddlValue1.Items.Clear();
                    ddlValue1.DataSource = com.SelectParamData("CASE5", ddlType1.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue1.DataValueField = "ID";
                    ddlValue1.DataTextField = "CODE";
                    ddlValue1.DataBind();
                    ddlValue1.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType2.SelectedIndex != 0)
                {
                    ddlValue2.Items.Clear();
                    ddlValue2.DataSource = com.SelectParamData("CASE5", ddlType2.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue2.DataValueField = "ID";
                    ddlValue2.DataTextField = "CODE";
                    ddlValue2.DataBind();
                    ddlValue2.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType3_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType3.SelectedIndex != 0)
                {
                    ddlValue3.Items.Clear();
                    ddlValue3.DataSource = com.SelectParamData("CASE5", ddlType3.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue3.DataValueField = "ID";
                    ddlValue3.DataTextField = "CODE";
                    ddlValue3.DataBind();
                    ddlValue3.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType4_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType4.SelectedIndex != 0)
                {
                    ddlValue4.Items.Clear();
                    ddlValue4.DataSource = com.SelectParamData("CASE5", ddlType4.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue4.DataValueField = "ID";
                    ddlValue4.DataTextField = "CODE";
                    ddlValue4.DataBind();
                    ddlValue4.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType5_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType5.SelectedIndex != 0)
                {
                    ddlValue5.Items.Clear();
                    ddlValue5.DataSource = com.SelectParamData("CASE5", ddlType5.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue5.DataValueField = "ID";
                    ddlValue5.DataTextField = "CODE";
                    ddlValue5.DataBind();
                    ddlValue5.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType6_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType6.SelectedIndex != 0)
                {
                    ddlValue6.Items.Clear();
                    ddlValue6.DataSource = com.SelectParamData("CASE5", ddlType6.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue6.DataValueField = "ID";
                    ddlValue6.DataTextField = "CODE";
                    ddlValue6.DataBind();
                    ddlValue6.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType7_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType7.SelectedIndex != 0)
                {
                    ddlValue7.Items.Clear();
                    ddlValue7.DataSource = com.SelectParamData("CASE5", ddlType7.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue7.DataValueField = "ID";
                    ddlValue7.DataTextField = "CODE";
                    ddlValue7.DataBind();
                    ddlValue7.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType8_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType8.SelectedIndex != 0)
                {
                    ddlValue8.Items.Clear();
                    ddlValue8.DataSource = com.SelectParamData("CASE5", ddlType8.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue8.DataValueField = "ID";
                    ddlValue8.DataTextField = "CODE";
                    ddlValue8.DataBind();
                    ddlValue8.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType9_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType9.SelectedIndex != 0)
                {
                    ddlValue9.Items.Clear();
                    ddlValue9.DataSource = com.SelectParamData("CASE5", ddlType9.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue9.DataValueField = "ID";
                    ddlValue9.DataTextField = "CODE";
                    ddlValue9.DataBind();
                    ddlValue9.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void ddlType10_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                if (ddlType10.SelectedIndex != 0)
                {
                    ddlValue10.Items.Clear();
                    ddlValue10.DataSource = com.SelectParamData("CASE5", ddlType10.SelectedValue.ToString(), "", "", ""); ;
                    ddlValue10.DataValueField = "ID";
                    ddlValue10.DataTextField = "CODE";
                    ddlValue10.DataBind();
                    ddlValue10.Items.Insert(0, new RadComboBoxItem("--Select Value--", ""));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void btnCreateRule_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtPercentage.Text != "")
                {
                    if (lblID.Text!="")
                    {
                        btnUpdate.Enabled = true;
                    }
                    if (lblID.Text == "")
                    {
                        btnSave.Enabled = true;
                    }
                    if ((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString();
                    }

                    //2
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != "")) 
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString();
                    }

                    //3
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != "")) 
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != "")) 
                        && ((ddlType3.SelectedValue.ToString() != "") && (ddlValue3.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString() + DdlCon2.SelectedValue.ToString()
                            + ddlBrac3.SelectedValue.ToString() + ddlType3.SelectedItem.Text + ddlOp3.SelectedItem.Text + "'" + ddlValue3.SelectedItem.Text + "'" + ddlRBrac3.SelectedValue.ToString();
                    }

                    //4
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != ""))
                        && ((ddlType3.SelectedValue.ToString() != "") && (ddlValue3.SelectedValue.ToString() != ""))
                        && ((ddlType4.SelectedValue.ToString() != "") && (ddlValue4.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString() + DdlCon2.SelectedValue.ToString()
                            + ddlBrac3.SelectedValue.ToString() + ddlType3.SelectedItem.Text + ddlOp3.SelectedItem.Text + "'" + ddlValue3.SelectedItem.Text + "'" + ddlRBrac3.SelectedValue.ToString() + DdlCon3.SelectedValue.ToString()
                            + ddlBrac4.SelectedValue.ToString() + ddlType4.SelectedItem.Text + ddlOp4.SelectedItem.Text + "'" + ddlValue4.SelectedItem.Text + "'" + ddlRBrac4.SelectedValue.ToString();
                    }


                    //5
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != ""))
                        && ((ddlType3.SelectedValue.ToString() != "") && (ddlValue3.SelectedValue.ToString() != ""))
                        && ((ddlType4.SelectedValue.ToString() != "") && (ddlValue4.SelectedValue.ToString() != ""))
                        && ((ddlType5.SelectedValue.ToString() != "") && (ddlValue5.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString() + DdlCon2.SelectedValue.ToString()
                            + ddlBrac3.SelectedValue.ToString() + ddlType3.SelectedItem.Text + ddlOp3.SelectedItem.Text + "'" + ddlValue3.SelectedItem.Text + "'" + ddlRBrac3.SelectedValue.ToString() + DdlCon3.SelectedValue.ToString()
                            + ddlBrac4.SelectedValue.ToString() + ddlType4.SelectedItem.Text + ddlOp4.SelectedItem.Text + "'" + ddlValue4.SelectedItem.Text + "'" + ddlRBrac4.SelectedValue.ToString() + DdlCon4.SelectedValue.ToString()
                            + ddlBrac5.SelectedValue.ToString() + ddlType5.SelectedItem.Text + ddlOp5.SelectedItem.Text + "'" + ddlValue5.SelectedItem.Text + "'" + ddlRBrac5.SelectedValue.ToString();
                    }

                    //6
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != ""))
                        && ((ddlType3.SelectedValue.ToString() != "") && (ddlValue3.SelectedValue.ToString() != ""))
                        && ((ddlType4.SelectedValue.ToString() != "") && (ddlValue4.SelectedValue.ToString() != ""))
                        && ((ddlType5.SelectedValue.ToString() != "") && (ddlValue5.SelectedValue.ToString() != ""))
                        && ((ddlType6.SelectedValue.ToString() != "") && (ddlValue6.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString() + DdlCon2.SelectedValue.ToString()
                            + ddlBrac3.SelectedValue.ToString() + ddlType3.SelectedItem.Text + ddlOp3.SelectedItem.Text + "'" + ddlValue3.SelectedItem.Text + "'" + ddlRBrac3.SelectedValue.ToString() + DdlCon3.SelectedValue.ToString()
                            + ddlBrac4.SelectedValue.ToString() + ddlType4.SelectedItem.Text + ddlOp4.SelectedItem.Text + "'" + ddlValue4.SelectedItem.Text + "'" + ddlRBrac4.SelectedValue.ToString() + DdlCon4.SelectedValue.ToString()
                            + ddlBrac5.SelectedValue.ToString() + ddlType5.SelectedItem.Text + ddlOp5.SelectedItem.Text + "'" + ddlValue5.SelectedItem.Text + "'" + ddlRBrac5.SelectedValue.ToString() + DdlCon5.SelectedValue.ToString()
                            + ddlBrac6.SelectedValue.ToString() + ddlType6.SelectedItem.Text + ddlOp6.SelectedItem.Text + "'" + ddlValue6.SelectedItem.Text + "'" + ddlRBrac6.SelectedValue.ToString();
                    }

                    //7
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != ""))
                        && ((ddlType3.SelectedValue.ToString() != "") && (ddlValue3.SelectedValue.ToString() != ""))
                        && ((ddlType4.SelectedValue.ToString() != "") && (ddlValue4.SelectedValue.ToString() != ""))
                        && ((ddlType5.SelectedValue.ToString() != "") && (ddlValue5.SelectedValue.ToString() != ""))
                        && ((ddlType6.SelectedValue.ToString() != "") && (ddlValue6.SelectedValue.ToString() != ""))
                        && ((ddlType7.SelectedValue.ToString() != "") && (ddlValue7.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString() + DdlCon2.SelectedValue.ToString()
                            + ddlBrac3.SelectedValue.ToString() + ddlType3.SelectedItem.Text + ddlOp3.SelectedItem.Text + "'" + ddlValue3.SelectedItem.Text + "'" + ddlRBrac3.SelectedValue.ToString() + DdlCon3.SelectedValue.ToString()
                            + ddlBrac4.SelectedValue.ToString() + ddlType4.SelectedItem.Text + ddlOp4.SelectedItem.Text + "'" + ddlValue4.SelectedItem.Text + "'" + ddlRBrac4.SelectedValue.ToString() + DdlCon4.SelectedValue.ToString()
                            + ddlBrac5.SelectedValue.ToString() + ddlType5.SelectedItem.Text + ddlOp5.SelectedItem.Text + "'" + ddlValue5.SelectedItem.Text + "'" + ddlRBrac5.SelectedValue.ToString() + DdlCon5.SelectedValue.ToString()
                            + ddlBrac6.SelectedValue.ToString() + ddlType6.SelectedItem.Text + ddlOp6.SelectedItem.Text + "'" + ddlValue6.SelectedItem.Text + "'" + ddlRBrac6.SelectedValue.ToString() + DdlCon6.SelectedValue.ToString()
                            + ddlBrac7.SelectedValue.ToString() + ddlType7.SelectedItem.Text + ddlOp7.SelectedItem.Text + "'" + ddlValue7.SelectedItem.Text + "'" + ddlRBrac7.SelectedValue.ToString();
                    }

                    //8
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != ""))
                        && ((ddlType3.SelectedValue.ToString() != "") && (ddlValue3.SelectedValue.ToString() != ""))
                        && ((ddlType4.SelectedValue.ToString() != "") && (ddlValue4.SelectedValue.ToString() != ""))
                        && ((ddlType5.SelectedValue.ToString() != "") && (ddlValue5.SelectedValue.ToString() != ""))
                        && ((ddlType6.SelectedValue.ToString() != "") && (ddlValue6.SelectedValue.ToString() != ""))
                        && ((ddlType7.SelectedValue.ToString() != "") && (ddlValue7.SelectedValue.ToString() != ""))
                        && ((ddlType8.SelectedValue.ToString() != "") && (ddlValue8.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString() + DdlCon2.SelectedValue.ToString()
                            + ddlBrac3.SelectedValue.ToString() + ddlType3.SelectedItem.Text + ddlOp3.SelectedItem.Text + "'" + ddlValue3.SelectedItem.Text + "'" + ddlRBrac3.SelectedValue.ToString() + DdlCon3.SelectedValue.ToString()
                            + ddlBrac4.SelectedValue.ToString() + ddlType4.SelectedItem.Text + ddlOp4.SelectedItem.Text + "'" + ddlValue4.SelectedItem.Text + "'" + ddlRBrac4.SelectedValue.ToString() + DdlCon4.SelectedValue.ToString()
                            + ddlBrac5.SelectedValue.ToString() + ddlType5.SelectedItem.Text + ddlOp5.SelectedItem.Text + "'" + ddlValue5.SelectedItem.Text + "'" + ddlRBrac5.SelectedValue.ToString() + DdlCon5.SelectedValue.ToString()
                            + ddlBrac6.SelectedValue.ToString() + ddlType6.SelectedItem.Text + ddlOp6.SelectedItem.Text + "'" + ddlValue6.SelectedItem.Text + "'" + ddlRBrac6.SelectedValue.ToString() + DdlCon6.SelectedValue.ToString()
                            + ddlBrac7.SelectedValue.ToString() + ddlType7.SelectedItem.Text + ddlOp7.SelectedItem.Text + "'" + ddlValue7.SelectedItem.Text + "'" + ddlRBrac7.SelectedValue.ToString() + DdlCon7.SelectedValue.ToString()
                            + ddlBrac8.SelectedValue.ToString() + ddlType8.SelectedItem.Text + ddlOp8.SelectedItem.Text + "'" + ddlValue8.SelectedItem.Text + "'" + ddlRBrac8.SelectedValue.ToString();
                    }

                    //9
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != ""))
                        && ((ddlType3.SelectedValue.ToString() != "") && (ddlValue3.SelectedValue.ToString() != ""))
                        && ((ddlType4.SelectedValue.ToString() != "") && (ddlValue4.SelectedValue.ToString() != ""))
                        && ((ddlType5.SelectedValue.ToString() != "") && (ddlValue5.SelectedValue.ToString() != ""))
                        && ((ddlType6.SelectedValue.ToString() != "") && (ddlValue6.SelectedValue.ToString() != ""))
                        && ((ddlType7.SelectedValue.ToString() != "") && (ddlValue7.SelectedValue.ToString() != ""))
                        && ((ddlType8.SelectedValue.ToString() != "") && (ddlValue8.SelectedValue.ToString() != ""))
                        && ((ddlType9.SelectedValue.ToString() != "") && (ddlValue9.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString() + DdlCon2.SelectedValue.ToString()
                            + ddlBrac3.SelectedValue.ToString() + ddlType3.SelectedItem.Text + ddlOp3.SelectedItem.Text + "'" + ddlValue3.SelectedItem.Text + "'" + ddlRBrac3.SelectedValue.ToString() + DdlCon3.SelectedValue.ToString()
                            + ddlBrac4.SelectedValue.ToString() + ddlType4.SelectedItem.Text + ddlOp4.SelectedItem.Text + "'" + ddlValue4.SelectedItem.Text + "'" + ddlRBrac4.SelectedValue.ToString() + DdlCon4.SelectedValue.ToString()
                            + ddlBrac5.SelectedValue.ToString() + ddlType5.SelectedItem.Text + ddlOp5.SelectedItem.Text + "'" + ddlValue5.SelectedItem.Text + "'" + ddlRBrac5.SelectedValue.ToString() + DdlCon5.SelectedValue.ToString()
                            + ddlBrac6.SelectedValue.ToString() + ddlType6.SelectedItem.Text + ddlOp6.SelectedItem.Text + "'" + ddlValue6.SelectedItem.Text + "'" + ddlRBrac6.SelectedValue.ToString() + DdlCon6.SelectedValue.ToString()
                            + ddlBrac7.SelectedValue.ToString() + ddlType7.SelectedItem.Text + ddlOp7.SelectedItem.Text + "'" + ddlValue7.SelectedItem.Text + "'" + ddlRBrac7.SelectedValue.ToString() + DdlCon7.SelectedValue.ToString()
                            + ddlBrac8.SelectedValue.ToString() + ddlType8.SelectedItem.Text + ddlOp8.SelectedItem.Text + "'" + ddlValue8.SelectedItem.Text + "'" + ddlRBrac8.SelectedValue.ToString() + DdlCon8.SelectedValue.ToString()
                            + ddlBrac9.SelectedValue.ToString() + ddlType9.SelectedItem.Text + ddlOp9.SelectedItem.Text + "'" + ddlValue9.SelectedItem.Text + "'" + ddlRBrac9.SelectedValue.ToString();
                    }

                    //10
                    if (((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                        && ((ddlType2.SelectedValue.ToString() != "") && (ddlValue2.SelectedValue.ToString() != ""))
                        && ((ddlType3.SelectedValue.ToString() != "") && (ddlValue3.SelectedValue.ToString() != ""))
                        && ((ddlType4.SelectedValue.ToString() != "") && (ddlValue4.SelectedValue.ToString() != ""))
                        && ((ddlType5.SelectedValue.ToString() != "") && (ddlValue5.SelectedValue.ToString() != ""))
                        && ((ddlType6.SelectedValue.ToString() != "") && (ddlValue6.SelectedValue.ToString() != ""))
                        && ((ddlType7.SelectedValue.ToString() != "") && (ddlValue7.SelectedValue.ToString() != ""))
                        && ((ddlType8.SelectedValue.ToString() != "") && (ddlValue8.SelectedValue.ToString() != ""))
                        && ((ddlType9.SelectedValue.ToString() != "") && (ddlValue9.SelectedValue.ToString() != ""))
                        && ((ddlType10.SelectedValue.ToString() != "") && (ddlValue10.SelectedValue.ToString() != "")))
                    {
                        txtQuery.Text = ddlBrac1.SelectedValue.ToString() + ddlType1.SelectedItem.Text + ddlOp1.SelectedItem.Text + "'" + ddlValue1.SelectedItem.Text + "'" + ddlRBrac1.SelectedValue.ToString() + DdlCon1.SelectedValue.ToString()
                            + ddlBrac2.SelectedValue.ToString() + ddlType2.SelectedItem.Text + ddlOp2.SelectedItem.Text + "'" + ddlValue2.SelectedItem.Text + "'" + ddlRBrac2.SelectedValue.ToString() + DdlCon2.SelectedValue.ToString()
                            + ddlBrac3.SelectedValue.ToString() + ddlType3.SelectedItem.Text + ddlOp3.SelectedItem.Text + "'" + ddlValue3.SelectedItem.Text + "'" + ddlRBrac3.SelectedValue.ToString() + DdlCon3.SelectedValue.ToString()
                            + ddlBrac4.SelectedValue.ToString() + ddlType4.SelectedItem.Text + ddlOp4.SelectedItem.Text + "'" + ddlValue4.SelectedItem.Text + "'" + ddlRBrac4.SelectedValue.ToString() + DdlCon4.SelectedValue.ToString()
                            + ddlBrac5.SelectedValue.ToString() + ddlType5.SelectedItem.Text + ddlOp5.SelectedItem.Text + "'" + ddlValue5.SelectedItem.Text + "'" + ddlRBrac5.SelectedValue.ToString() + DdlCon5.SelectedValue.ToString()
                            + ddlBrac6.SelectedValue.ToString() + ddlType6.SelectedItem.Text + ddlOp6.SelectedItem.Text + "'" + ddlValue6.SelectedItem.Text + "'" + ddlRBrac6.SelectedValue.ToString() + DdlCon6.SelectedValue.ToString()
                            + ddlBrac7.SelectedValue.ToString() + ddlType7.SelectedItem.Text + ddlOp7.SelectedItem.Text + "'" + ddlValue7.SelectedItem.Text + "'" + ddlRBrac7.SelectedValue.ToString() + DdlCon7.SelectedValue.ToString()
                            + ddlBrac8.SelectedValue.ToString() + ddlType8.SelectedItem.Text + ddlOp8.SelectedItem.Text + "'" + ddlValue8.SelectedItem.Text + "'" + ddlRBrac8.SelectedValue.ToString() + DdlCon8.SelectedValue.ToString()
                            + ddlBrac9.SelectedValue.ToString() + ddlType9.SelectedItem.Text + ddlOp9.SelectedItem.Text + "'" + ddlValue9.SelectedItem.Text + "'" + ddlRBrac9.SelectedValue.ToString() + DdlCon9.SelectedValue.ToString()
                            + ddlBrac10.SelectedValue.ToString() + ddlType10.SelectedItem.Text + ddlOp10.SelectedItem.Text + "'" + ddlValue10.SelectedItem.Text + "'" + ddlRBrac10.SelectedValue.ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try 
            {
                if ((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                {

                    com.InsertRule(txtRuleDes.Text, "ACTIVE", Session["USER"].ToString(), txtQuery.Text, ddlComType.SelectedItem.Text, txtPercentage.Text);

                    DataTable Dt1 = com.MaxJobNo_Rule();
                    if (Dt1.Rows.Count > 0)
                    {
                        txtRuleID.Text = Dt1.Rows[0]["JOBS"].ToString();

                    }

                    for (int i = 1; i <= 10; i++)
                    {

                        int inc = i + 10;
                        RadComboBox Brac1 = Panel2.FindControl("ddlBrac" + i) as RadComboBox;
                        RadComboBox Type = Panel2.FindControl("ddlType" + i) as RadComboBox;
                        RadComboBox Operator = Panel2.FindControl("ddlOp" + i) as RadComboBox;
                        RadComboBox Value = Panel2.FindControl("ddlValue" + i) as RadComboBox;
                        RadComboBox Brac2 = Panel2.FindControl("ddlRBrac" + i) as RadComboBox;
                        RadComboBox LogicalCon = Panel2.FindControl("DdlCon" + i) as RadComboBox;

                        if ((Type.SelectedValue.ToString() != "") && (Value.SelectedValue.ToString() != ""))
                        {
                            string b1 = "";
                            string b2 = "";
                            if (Brac1.SelectedItem.Text != "--")
                            {
                                b1 = Brac1.SelectedValue.ToString();
                            }


                            if (Brac2.SelectedItem.Text != "--")
                            {
                                b2 = Brac2.SelectedValue.ToString();
                            }



                            com.InsertRule_RowByRow(txtRuleID.Text, i.ToString(), b1, Type.SelectedValue.ToString(), Operator.SelectedValue.ToString(), Value.SelectedValue.ToString(), b2,
                                LogicalCon.SelectedValue.ToString());
                            inc = 0;
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("RuleEngine.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = com.SelectParamData("CASE6", txtRuleID.Text,txtDesSearch.Text, "", "");
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

        protected void btnclear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RuleEngine.aspx");
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

                        for (int i = 1; i <= dt3.Rows.Count; i++)
                        {

                            int inc = i + 10;
                            RadComboBox Brac1 = Panel2.FindControl("ddlBrac" + i) as RadComboBox;
                            RadComboBox Type = Panel2.FindControl("ddlType" + i) as RadComboBox;
                            RadComboBox Operator = Panel2.FindControl("ddlOp" + i) as RadComboBox;
                            RadComboBox Value = Panel2.FindControl("ddlValue" + i) as RadComboBox;
                            RadComboBox Brac2 = Panel2.FindControl("ddlRBrac" + i) as RadComboBox;
                            RadComboBox LogicalCon = Panel2.FindControl("DdlCon" + i) as RadComboBox;


                            DataTable Brackets = com.SelectType("BRACKETS");

                            if (dt3.Rows[i - 1]["COL1"].ToString() != "")
                            {
                                Brac1.Items.Clear();
                                Brac1.DataSource = Brackets;
                                Brac1.DataValueField = "DESCRIPTION";
                                Brac1.DataTextField = "DESCRIPTION";
                                Brac1.DataBind();
                                Brac1.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i - 1]["COL1"].ToString(), dt3.Rows[i-1]["COL1"].ToString()));
                                Brac1.Items.Insert(1, new RadComboBoxItem("--", ""));
                            }

                            DataTable RefType = com.SelectType("REF_TYPE");
                            if (dt3.Rows[i - 1]["COL2"].ToString() != "")
                            {
                                Type.Items.Clear();
                                Type.DataSource = RefType;
                                Type.DataValueField = "PARAMID";
                                Type.DataTextField = "PARAMDESCRIPTION";
                                Type.DataBind();
                                Type.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i - 1]["COL2DES"].ToString(), dt3.Rows[i - 1]["COL2"].ToString()));
                                Type.Items.Insert(1, new RadComboBoxItem("--Select Type--", ""));

                            }

                            DataTable Operators = com.SelectType("OPERATORS");
                            if (dt3.Rows[i - 1]["COL3"].ToString() != "")
                            {
                                Operator.Items.Clear();
                                Operator.DataSource = Operators;
                                Operator.DataValueField = "OPERATORS";
                                Operator.DataTextField = "OPERATORS";
                                Operator.DataBind();
                                Operator.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i - 1]["COL3"].ToString(), dt3.Rows[i - 1]["COL3"].ToString()));

                            }


                            if (dt3.Rows[i - 1]["COL4"].ToString() != "")
                            {
                                Value.Items.Clear();
                                Value.DataSource = com.SelectParamData("CASE5", dt3.Rows[i - 1]["COL2"].ToString(), "", "", ""); ;
                                Value.DataValueField = "ID";
                                Value.DataTextField = "CODE";
                                Value.DataBind();
                                Value.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i - 1]["COL4DES"].ToString(), dt3.Rows[i - 1]["COL4"].ToString()));
                                Value.Items.Insert(1, new RadComboBoxItem("--Select Value--", ""));
                            }


                            if (dt3.Rows[i - 1]["COL5"].ToString() != "")
                            {
                                Brac2.Items.Clear();
                                Brac2.DataSource = Brackets;
                                Brac2.DataValueField = "DESCRIPTION";
                                Brac2.DataTextField = "DESCRIPTION";
                                Brac2.DataBind();
                                Brac2.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i - 1]["COL5"].ToString(), dt3.Rows[i - 1]["COL5"].ToString()));
                                Brac2.Items.Insert(1, new RadComboBoxItem("--", ""));
                            }

                            DataTable Controlers = com.SelectType("CONTROLERS");
                            if (dt3.Rows[i - 1]["COL6"].ToString() != "")
                            {
                                LogicalCon.Items.Clear();
                                LogicalCon.DataSource = Controlers;
                                LogicalCon.DataValueField = "DESCRIPTION";
                                LogicalCon.DataTextField = "DESCRIPTION";
                                LogicalCon.DataBind();
                                LogicalCon.Items.Insert(0, new RadComboBoxItem(dt3.Rows[i - 1]["COL6"].ToString(), dt3.Rows[i - 1]["COL6"].ToString()));

                            }




                            inc = 0;



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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if ((ddlType1.SelectedValue.ToString() != "") && (ddlValue1.SelectedValue.ToString() != ""))
                {

                    com.UpdateRule(lblID.Text, txtRuleDes.Text, "ACTIVE", Session["USER"].ToString(), txtQuery.Text, ddlComType.SelectedItem.Text, txtPercentage.Text);


                    for (int i = 1; i <= 10; i++)
                    {

                        int inc = i + 10;
                        RadComboBox Brac1 = Panel2.FindControl("ddlBrac" + i) as RadComboBox;
                        RadComboBox Type = Panel2.FindControl("ddlType" + i) as RadComboBox;
                        RadComboBox Operator = Panel2.FindControl("ddlOp" + i) as RadComboBox;
                        RadComboBox Value = Panel2.FindControl("ddlValue" + i) as RadComboBox;
                        RadComboBox Brac2 = Panel2.FindControl("ddlRBrac" + i) as RadComboBox;
                        RadComboBox LogicalCon = Panel2.FindControl("DdlCon" + i) as RadComboBox;

                        if ((Type.SelectedValue.ToString() != "") && (Value.SelectedValue.ToString() != ""))
                        {
                            string b1 = "";
                            string b2 = "";
                            if (Brac1.SelectedItem.Text != "--")
                            {
                                b1 = Brac1.SelectedValue.ToString();
                            }


                            if (Brac2.SelectedItem.Text != "--")
                            {
                                b2 = Brac2.SelectedValue.ToString();
                            }



                            com.UpdateRule_RowByRow(lblID.Text, i.ToString(), b1, Type.SelectedValue.ToString(), Operator.SelectedValue.ToString(), Value.SelectedValue.ToString(), b2,
                                LogicalCon.SelectedValue.ToString());
                            inc = 0;
                        }

                    }

                    lblError.Text = "Update Successful.Rule ID : " + lblID.Text;
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





    }
}