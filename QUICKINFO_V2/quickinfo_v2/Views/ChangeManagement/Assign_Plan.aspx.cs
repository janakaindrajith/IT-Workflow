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
    public partial class Assign_Plan : System.Web.UI.Page
    {
        string UserName = "";
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        ChangeManagementMain CM_Main = new ChangeManagementMain();
        DataTable DtRef;
        string ReqID = "";
        StringBuilder sb = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {



                if (!IsPostBack)
                {

                DataTable dtconall = CM_Main.SelectJob("CASE2", "", "INTIMATE", "", "", "", System.DateTime.Now);
                grdRequest.DataSource = dtconall;
                grdRequest.DataBind();

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
                    //DataTable dtconall = CM_Main.SelectJob("CASE2", "", "INTIMATE", "", "", "", System.DateTime.Now);
                    //grdRequest.DataSource = dtconall;
                    //grdRequest.DataBind();

                    if (Request.QueryString["ReqID"] != null)
                    {
                        ReqID = Request.QueryString["ReqID"];

                        DataTable dtcon = CM_Main.SelectJob("CASE3", ReqID, "", "", "", "", System.DateTime.Now);
                        grdRequest.DataSource = dtcon;
                        grdRequest.DataBind();

                        BtnUpdate.Enabled = true;
                        BtnReject.Enabled = true;

                        lblID.Text = dtcon.Rows[0]["REQUEST_ID"].ToString();
                        txtReqID.Text = dtcon.Rows[0]["REQUEST_ID"].ToString();

                        if (dtcon.Rows[0]["START_DATE"].ToString() != "")
                        {
                            Start.SelectedDate = Convert.ToDateTime(dtcon.Rows[0]["START_DATE"]);
                        }
                        if (dtcon.Rows[0]["END_DATE"].ToString() != "")
                        {
                            End.SelectedDate = Convert.ToDateTime(dtcon.Rows[0]["END_DATE"]);
                        }

                        if (dtcon.Rows[0]["IMPACT"].ToString() != "")
                        {
                            txtImpact.Text = dtcon.Rows[0]["IMPACT"].ToString();
                        }

                        if (dtcon.Rows[0]["FEEDBACK_PLAN"].ToString() != "")
                        {
                            txtFallback.Text = dtcon.Rows[0]["FEEDBACK_PLAN"].ToString();
                        }

                        if (dtcon.Rows[0]["REJECT_COMMENT"].ToString() != "")
                        {
                            txtReject.Text = dtcon.Rows[0]["REJECT_COMMENT"].ToString();
                        }

                        DataTable Users = CM_Main.SelectJob("CASE1", "", "", "", "", "", System.DateTime.Now);

                        CmbUsers1.DataSource = Users;
                        CmbUsers1.DataValueField = "USER_NAME";
                        CmbUsers1.DataTextField = "FULL_NAME";
                        CmbUsers1.DataBind();

                        if (dtcon.Rows[0]["MANAGER"].ToString() != "")
                        {
                            CmbUsers1.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["MANAGER"].ToString(), dtcon.Rows[0]["MANAGER"].ToString()));
                        }
                        else
                        {
                            CmbUsers1.Items.Insert(0, new RadComboBoxItem("--Select User--", ""));
                        }

                        CmbUsers2.DataSource = Users;
                        CmbUsers2.DataValueField = "USER_NAME";
                        CmbUsers2.DataTextField = "FULL_NAME";
                        CmbUsers2.DataBind();

                        if (dtcon.Rows[0]["IMPLEMENTOR"].ToString() != "")
                        {
                            CmbUsers2.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["IMPLEMENTOR"].ToString(), dtcon.Rows[0]["IMPLEMENTOR"].ToString()));
                        }
                        else
                        {
                            CmbUsers2.Items.Insert(0, new RadComboBoxItem("--Select User--", ""));
                        }

                        CmbUsers3.DataSource = Users;
                        CmbUsers3.DataValueField = "USER_NAME";
                        CmbUsers3.DataTextField = "FULL_NAME";
                        CmbUsers3.DataBind();

                        if (dtcon.Rows[0]["QA_AGENT"].ToString() != "")
                        {
                            CmbUsers3.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["QA_AGENT"].ToString(), dtcon.Rows[0]["QA_AGENT"].ToString()));
                        }
                        else
                        {
                            CmbUsers3.Items.Insert(0, new RadComboBoxItem("--Select User--", ""));
                        }

                        CmbUsers4.DataSource = Users;
                        CmbUsers4.DataValueField = "USER_NAME";
                        CmbUsers4.DataTextField = "FULL_NAME";
                        CmbUsers4.DataBind();

                        if (dtcon.Rows[0]["RELEASE_TEAM"].ToString() != "")
                        {
                            CmbUsers4.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["RELEASE_TEAM"].ToString(), dtcon.Rows[0]["RELEASE_TEAM"].ToString()));
                        }
                        else
                        {
                            CmbUsers4.Items.Insert(0, new RadComboBoxItem("--Select User--", ""));
                        }


                        if (dtcon.Rows[0]["OUTAGE"].ToString() != "")
                        {
                            CmbOutage.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["OUTAGE"].ToString(), dtcon.Rows[0]["OUTAGE"].ToString()));
                            CmbOutage.Items.Insert(1, new RadComboBoxItem("YES", "YES"));
                            CmbOutage.Items.Insert(2, new RadComboBoxItem("NO", "NO"));
                        }
                        else
                        {
                            CmbOutage.Items.Insert(0, new RadComboBoxItem("YES", "YES"));
                            CmbOutage.Items.Insert(1, new RadComboBoxItem("NO", "NO"));
                        }

                        //-------IT Work Flow Details

                        DataTable dtconIT = CM_Main.SelectJob("CASE11", ReqID, "", "", "", "", System.DateTime.Now);

                        txtReqID.Text = dtconIT.Rows[0]["REQUEST_ID"].ToString();
                        lblCompany.Text = dtconIT.Rows[0]["COMPANY"].ToString();
                        lblStatus.Text = dtconIT.Rows[0]["STATUS"].ToString();
                        lblTitle.Text = dtconIT.Rows[0]["TITLE"].ToString();
                        lblSystem.Text = dtconIT.Rows[0]["SYSTEM"].ToString();
                        lblDescription.Text = dtconIT.Rows[0]["IT_DES"].ToString();
                        lblITWorkFlowID.Text = dtconIT.Rows[0]["IT_REQUEST_ID"].ToString();


                        lblParent.Text = dtconIT.Rows[0]["PARENT_ID"].ToString();

                        DataTable dt = Main.SelectImages(lblITWorkFlowID.Text, "BRANCH_IMAGE");
                        galleryDataList.DataSource = dt;
                        galleryDataList.DataBind();

                        DataTable dt33 = Main.SelectImages(lblITWorkFlowID.Text, "BRANCH_DOCS");
                        DataList2.DataSource = dt33;
                        DataList2.DataBind();

                        RdGrdEvents.DataSource = CM_Main.SelectJob("CASE10", ReqID, "", "", "", "", System.DateTime.Now);
                        RdGrdEvents.DataBind();

                        DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblITWorkFlowID.Text, "", "", System.DateTime.Now);
                        RadGrdEventsITWF.DataSource = dtEvents;
                        RadGrdEventsITWF.DataBind();

                        DataTable dtDocsSysWise = CM_Main.SelectJob("CASE12", txtReqID.Text, "", "", "", "", System.DateTime.Now);
                        RadListBox1.DataSource = dtDocsSysWise;
                        RadListBox1.DataTextField = "DOCUMENT";
                        RadListBox1.DataValueField = "DOCUMENT";
                        RadListBox1.DataBind();

                        DataTable dtDocsJobWise = CM_Main.SelectJob("CASE13", txtReqID.Text, "", "", "", "", System.DateTime.Now);
                        if (dtDocsJobWise.Rows.Count >= 1)
                        {
                            RadListBox2.DataSource = dtDocsJobWise;
                            RadListBox2.DataTextField = "DOCUMENT";
                            RadListBox2.DataValueField = "DOCUMENT";
                            RadListBox2.DataBind();
                        }

                    }

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

        protected void grdRequest_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {


                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dtcon = CM_Main.SelectJob("CASE3", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    grdRequest.DataSource = dtcon;
                    grdRequest.DataBind();

                    BtnUpdate.Enabled = true;
                    BtnReject.Enabled = true;

                    lblID.Text = dtcon.Rows[0]["REQUEST_ID"].ToString();
                    txtReqID.Text = dtcon.Rows[0]["REQUEST_ID"].ToString();

                    if (dtcon.Rows[0]["START_DATE"].ToString()!="")
                    {
                        Start.SelectedDate = Convert.ToDateTime(dtcon.Rows[0]["START_DATE"]);
                    }
                    if (dtcon.Rows[0]["END_DATE"].ToString() != "")
                    {
                        End.SelectedDate = Convert.ToDateTime(dtcon.Rows[0]["END_DATE"]);
                    }

                    if (dtcon.Rows[0]["IMPACT"].ToString() != "")
                    {
                        txtImpact.Text = dtcon.Rows[0]["IMPACT"].ToString();
                    }

                    if (dtcon.Rows[0]["FEEDBACK_PLAN"].ToString() != "")
                    {
                        txtFallback.Text = dtcon.Rows[0]["FEEDBACK_PLAN"].ToString();
                    }

                    if (dtcon.Rows[0]["REJECT_COMMENT"].ToString() != "")
                    {
                        txtReject.Text = dtcon.Rows[0]["REJECT_COMMENT"].ToString();
                    }

                    DataTable Users = CM_Main.SelectJob("CASE1", "", "", "", "", "", System.DateTime.Now);

                    CmbUsers1.DataSource = Users;
                    CmbUsers1.DataValueField = "USER_NAME";
                    CmbUsers1.DataTextField = "FULL_NAME";
                    CmbUsers1.DataBind();

                    if (dtcon.Rows[0]["MANAGER"].ToString() != "")
                    {
                        CmbUsers1.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["MANAGER"].ToString(), dtcon.Rows[0]["MANAGER"].ToString()));
                    }
                    else
                    {
                        CmbUsers1.Items.Insert(0, new RadComboBoxItem("--Select User--", ""));
                    }

                    CmbUsers2.DataSource = Users;
                    CmbUsers2.DataValueField = "USER_NAME";
                    CmbUsers2.DataTextField = "FULL_NAME";
                    CmbUsers2.DataBind();

                    if (dtcon.Rows[0]["IMPLEMENTOR"].ToString() != "")
                    {
                        CmbUsers2.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["IMPLEMENTOR"].ToString(), dtcon.Rows[0]["IMPLEMENTOR"].ToString()));
                    }
                    else
                    {
                        CmbUsers2.Items.Insert(0, new RadComboBoxItem("--Select User--", ""));
                    }

                    CmbUsers3.DataSource = Users;
                    CmbUsers3.DataValueField = "USER_NAME";
                    CmbUsers3.DataTextField = "FULL_NAME";
                    CmbUsers3.DataBind();

                    if (dtcon.Rows[0]["QA_AGENT"].ToString() != "")
                    {
                        CmbUsers3.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["QA_AGENT"].ToString(), dtcon.Rows[0]["QA_AGENT"].ToString()));
                    }
                    else
                    {
                        CmbUsers3.Items.Insert(0, new RadComboBoxItem("--Select User--", ""));
                    }

                    CmbUsers4.DataSource = Users;
                    CmbUsers4.DataValueField = "USER_NAME";
                    CmbUsers4.DataTextField = "FULL_NAME";
                    CmbUsers4.DataBind();

                    if (dtcon.Rows[0]["RELEASE_TEAM"].ToString() != "")
                    {
                        CmbUsers4.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["RELEASE_TEAM"].ToString(), dtcon.Rows[0]["RELEASE_TEAM"].ToString()));
                    }
                    else
                    {
                        CmbUsers4.Items.Insert(0, new RadComboBoxItem("--Select User--", ""));
                    }


                    if (dtcon.Rows[0]["OUTAGE"].ToString() != "")
                    {
                        CmbOutage.Items.Insert(0, new RadComboBoxItem(dtcon.Rows[0]["OUTAGE"].ToString(), dtcon.Rows[0]["OUTAGE"].ToString()));
                        CmbOutage.Items.Insert(1, new RadComboBoxItem("YES", "YES"));
                        CmbOutage.Items.Insert(2, new RadComboBoxItem("NO", "NO"));
                    }
                    else
                    {
                        CmbOutage.Items.Insert(0, new RadComboBoxItem("YES", "YES"));
                        CmbOutage.Items.Insert(1, new RadComboBoxItem("NO", "NO"));
                    }


                    //-------IT Work Flow Details

                    DataTable dtconIT = CM_Main.SelectJob("CASE11", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);

                    txtReqID.Text = dtconIT.Rows[0]["REQUEST_ID"].ToString();
                    lblCompany.Text = dtconIT.Rows[0]["COMPANY"].ToString();
                    lblStatus.Text = dtconIT.Rows[0]["STATUS"].ToString();
                    lblTitle.Text = dtconIT.Rows[0]["TITLE"].ToString();
                    lblSystem.Text = dtconIT.Rows[0]["SYSTEM"].ToString();
                    lblDescription.Text = dtconIT.Rows[0]["IT_DES"].ToString();
                    lblITWorkFlowID.Text = dtconIT.Rows[0]["IT_REQUEST_ID"].ToString();


                    lblParent.Text = dtconIT.Rows[0]["PARENT_ID"].ToString();

                    DataTable dt = Main.SelectImages(lblITWorkFlowID.Text, "BRANCH_IMAGE");
                    galleryDataList.DataSource = dt;
                    galleryDataList.DataBind();

                    DataTable dt33 = Main.SelectImages(lblITWorkFlowID.Text, "BRANCH_DOCS");
                    DataList2.DataSource = dt33;
                    DataList2.DataBind();

                    RdGrdEvents.DataSource = CM_Main.SelectJob("CASE10", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    RdGrdEvents.DataBind();

                    DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblITWorkFlowID.Text, "", "", System.DateTime.Now);
                    RadGrdEventsITWF.DataSource = dtEvents;
                    RadGrdEventsITWF.DataBind();


                    DataTable dtDocsSysWise = CM_Main.SelectJob("CASE12", txtReqID.Text, "", "", "", "", System.DateTime.Now);
                    RadListBox1.DataSource = dtDocsSysWise;
                    RadListBox1.DataTextField = "DOCUMENT";
                    RadListBox1.DataValueField = "DOCUMENT";
                    RadListBox1.DataBind();

                    DataTable dtDocsJobWise = CM_Main.SelectJob("CASE13", txtReqID.Text, "", "", "", "", System.DateTime.Now);
                    if (dtDocsJobWise.Rows.Count >= 1)
                    {
                        RadListBox2.DataSource = dtDocsJobWise;
                        RadListBox2.DataTextField = "DOCUMENT";
                        RadListBox2.DataValueField = "DOCUMENT";
                        RadListBox2.DataBind();
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

                CM_Main.UpdateRegister_Plan(lblID.Text, txtImpact.Text, CmbOutage.SelectedItem.Text, Start.SelectedDate.Value, End.SelectedDate.Value,txtFallback.Text, CmbUsers1.SelectedItem.Value,
                    CmbUsers2.SelectedItem.Value, CmbUsers3.SelectedItem.Value, CmbUsers4.SelectedItem.Value, Session["USER"].ToString());

                if (RadListBox2.Items.Count >= 1)
                {
                    for (int i = 0; i < RadListBox2.Items.Count; i++)
                    {
                        CM_Main.InsertDocsToJobNo(lblID.Text, RadListBox2.Items[i].Value.ToString());
                    }

                }

                if (txtOtherDocs.Text != "")
                {
                    CM_Main.InsertDocsToJobNo(lblID.Text, txtOtherDocs.Text);
                }
                PlanAndAssign();
                lblError.Text = "Update Successfull...Job No : " + lblID.Text;
                string myStringVariable = "Update Successfull...Job No : " + lblID.Text;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }


        public void PlanAndAssign()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            //    DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtReqID.Text, "");
            //   string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();



            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.To.Add(FromAdd);

            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();


            message.From = from;
            message.Subject = Prifix + "CR Assigned and Planed" + "-" + lblID.Text;
            message.IsBodyHtml = true;

            string BodyText = "<html>" +
                             "<head>" +
                             "<title></title>" +
                             "<style type=" + "text/css" + ">" +
                             ".outer_table{" +
                             "border:#309dcf solid 1px;" +
                             "}" +
                             ".outer_table_td{" +
                             "background-color:#309dcf;" +
                             "height:33px;" +
                             "font-family: Tahoma;" +
                             "font-size:14px;" +
                             "font-size-adjust:none;" +
                             "font-weight:bold;" +
                             "color:#FFFFFF;" +
                             "}" +
                             ".outer_table_td1{" +
                             "background-color:#309dcf;" +
                             "height:33px;" +
                             "font-family: Tahoma;" +
                             "font-size:14px;" +
                             "font-size-adjust:none;" +
                             "font-weight:bold;" +
                             "color:#FFFFFF;" +
                             "}" +
                             ".txt_normal{" +
                             "font-family: Tahoma;" +
                             "font-size:11px;" +
                             "font-size-adjust:none;" +
                             "color:#585858;" +
                             "height:18px;" +
                             "}" +
                             ".inner_table_td_green{" +
                             "border-bottom:#CCCCCC solid 1px;" +
                             "background-color:#f3fde4;" +
                             "font-family: Tahoma;" +
                             "font-size:11px;" +
                             "font-size-adjust:none;" +
                             "color:#528c00;" +
                             "width:150px;" +
                             "height:18px;" +
                             "text-indent:5px;" +
                             "}" +
                             ".inner_table_td_black{" +
                             "border-bottom:#CCCCCC solid 1px;" +
                             "background-color:#f3fde4; " +
                             "font-family: Tahoma;" +
                             "font-size:11px;" +
                             "font-size-adjust:none;" +
                             " color:#000000; " +
                             "height:18px;" +
                             "text-indent:5px;" +
                             "}" +
                             ".inner_table_td_white{" +
                             "border-bottom:#CCCCCC solid 1px;" +
                             "background-color:#f3fde4;" +
                             "font-family: Tahoma;" +
                             "font-size:11px;" +
                             "font-size-adjust:none;" +
                             "color:#FFFFFF;" +
                             "height:18px;" +
                             "text-indent:5px;" +
                             "}" +
                             ".inner_table_td_red{" +
                             "border-bottom:#CCCCCC solid 1px;" +
                             "background-color:#f3fde4;" +
                             "font-family: Tahoma;" +
                             "font-size:11px;" +
                             "font-size-adjust:none;" +
                             "color:#E10505;" +
                             "height:18px;" +
                             "text-indent:5px;" +
                             "}" +
                             ".inner_table_td_blue{" +
                             "border-bottom:#CCCCCC solid 1px;" +
                             "background-color:#f2fbff;" +
                             "font-family: Tahoma;" +
                             "font-size:11px;" +
                             "font-size-adjust:none;" +
                             "color:#0776a8;" +
                             "height:18px;" +
                             "width:1050px;" +
                             "text-indent:10px;" +
                             "}" +
                             "</style>" +
                             "</head>" +
                             "<body>" +
                             "<table width=850 border=0 cellspacing=0 cellpadding=0 class=outer_table>" +
                             "  <tr>" +
                             "    <td  class=outer_table_td width=10>&nbsp;</td>" +
                             "    <td align=left valign=middle  class=outer_table_td>" + lblTitle.Text + " </td>" +
                             "    <td align=left valign=middle  class=outer_table_td  width=10>&nbsp;</td>" +
                             "  </tr>" +
                             "  <tr>" +
                             "    <td >&nbsp;</td>" +
                             "    <td align=left valign=top >" +
                             "    <table width=100% border=0 cellspacing=0 cellpadding=0>" +
                             "      <tr>" +
                             "        <td class=txt_normal></td>" +
                             "     </tr>" +
                             "     <tr>" +
                             "       <td class=txt_normal></td>" +
                             "     </tr>" +
                             "     <tr>" +
                             "       <td ></td>" +
                             "     </tr>" +
                             "   </table>" +
                             "   <table width=850 border=0 cellspacing=2 cellpadding=3>" +
                             "           <tr >" +
                             "             <td colspan=2 class=txt_normal><strong>" + "CR has been Assigned and Planed in the IT Change Management System. Please log in to the system to Approve - ID :" + lblID.Text + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>IT Work Flow ID : " + lblITWorkFlowID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Oraganization : " + lblCompany.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>System : " + lblSystem.Text + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Description : " + lblDescription.Text + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             " <tr>" +
                             "      </table>" +
                             "<br /> " +
                             "<table width=850 border=0 cellspacing=1 cellpadding=3> " +
                             " <tr> " +
                             "       <td></td> " +
                             " <tr> " +
                             " <tr> " +
                             "       <td class=inner_table_td_red>To view more details and Approve : <a href=" + "http://192.168.10.89:82/ITWorkflow/Views/ChangeManagement/Approval.aspx?ReqID=" + lblID.Text + "> Click Here </a> </td> " +
                             " <tr> " +
                             "</table> " +
                             "<br /> " +
                             "</br> " +
                             "</br> " +
                             "</br> " +
                             "<table width=850 border=0 cellspacing=1 cellpadding=3> " +
                             "<tr> " +
                             " <td class=inner_table_td_blue><strong>Original sent by:</strong></td> " +
                             "<tr> " +
                             "</table> " +
                             "   <table width=100% border=0 cellspacing=0 cellpadding=0> " +
                             "<tr> " +
                             " <td>&nbsp;</td> " +
                             "</tr> " +
                             "<tr> " +
                             "  <td class=txt_normal ><p style=height:29px> " +
                             " This is an auto generated email sent to you from the IT Change Management system. Please do not reply to this email. " +
                             "</p> " +
                             "</td> " +
                             "</tr> " +
                             "</table> " +
                             "   </td> " +
                             "  <td align=left valign=top ></td> " +
                             "</tr> " +
                             "<tr> " +
                             " <td colspan=3 >&nbsp;</td> " +
                             "</tr> " +
                             "</table> " +
                             " <p> " +
                             "</p>  " +
                             " </body> " +
                             " </html>"
            ;

            message.Body = @BodyText;
            CommonFunctions cmnFunctions = new CommonFunctions();
            SmtpClient client = new SmtpClient(cmnFunctions.getSMTPAddress(Cache["user_company"].ToString()));

            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("crc", "HNBA@customer");
            client.UseDefaultCredentials = false;
            client.Credentials = SMTPUserInfo;

            client.Send(message);

        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assign_Plan.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assign_Plan.aspx");
        }

        protected void BtnReject_Click(object sender, EventArgs e)
        {
            try
            {
                CM_Main.UpdateRegister_Reject(lblID.Text, txtReject.Text, Session["USER"].ToString());

                lblError.Text = "Job Rejected...Job No : " + lblID.Text;
                string myStringVariable = "Job Rejected...Job No : " + lblID.Text;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void galleryDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = galleryDataList.SelectedIndex;

            Label lbl = (Label)galleryDataList.Items[idx].FindControl("Label1");


            string URL = "Image.aspx?ImID=" + lbl.Text;
            sb.Append("<script>");
            sb.Append("window.open('" + URL + "', '','left=50, top=50, height=600, width= 900, status=no, resizable= yes, scrollbars= yes, toolbar= no,location= no, menubar= no');");
            sb.Append("</script>");
            Page.RegisterStartupScript("test", sb.ToString());
        }

        protected void DataList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = DataList2.SelectedIndex;

            Label lbl = (Label)DataList2.Items[idx].FindControl("Label2");

            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            OracleCommand myCommand = new OracleCommand("SELECT * FROM wf_it_images WHERE ID = '" + lbl.Text + "'", conn);
            conn.Open();
            OracleDataReader myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.Default);
            try
            {
                while (myReader.Read())
                {

                    OracleLob myLob = myReader.GetOracleLob(myReader.GetOrdinal("IMAGE"));
                    if (!myLob.IsNull)
                    {
                        string FN = myReader.GetString(myReader.GetOrdinal("IMAGE_NAME"));


                        //Use buffer to transfer data
                        byte[] b = new byte[myLob.Length];
                        //Read data from database
                        myLob.Read(b, 0, (int)myLob.Length);


                        Response.AddHeader("content-disposition", "attachment;filename=" + FN);
                        Response.ContentType = "application/octectstream";
                        Response.BinaryWrite(b);
                        Response.End();
                    }
                }
            }
            finally
            {
                myReader.Close();
                conn.Close();
            }

        }

        protected void grdRequest_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable dtconall = CM_Main.SelectJob("CASE2", "", "INTIMATE", "", "", "", System.DateTime.Now);
            grdRequest.DataSource = dtconall;
            //grdRequest.DataBind();
        }


    }
}