﻿using System;
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
    public partial class HandlerForm : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        DataTable DtRef;
        string UserName = "";
        StringBuilder sb = new StringBuilder();
        string ReqID = "";
        ChangeManagementMain CM_Main = new ChangeManagementMain();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    grdRequest.DataSource = new int[] { };

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

                    if (Request.QueryString["ReqID"] != null)
                    {
                        ReqID = Request.QueryString["ReqID"];

                        DataTable dd = Main.SelectJobFromRegister("CASE4", ReqID, "", "", System.DateTime.Now);
                        grdRequest.DataSource = dd;
                        grdRequest.DataBind();

                        txtRequestID.Text = dd.Rows[0]["REQUEST_ID"].ToString();
                        txtJobDes.Text = dd.Rows[0]["JOB_DESCRIPTION"].ToString();
                        txtStatus.Text = dd.Rows[0]["STATUS"].ToString();
                        txtRemarks.Text = dd.Rows[0]["REMARKS_UNIT"].ToString();

                        DataTable UserType = Main.SelectReferanceData("HANDLED_USERS_TYPES", Session["USER"].ToString(), "");
                        string Type = UserType.Rows[0]["USER_TYPE"].ToString();
                        if ((Type == "IN_HOUSE_DEV") || (Type == "HELP_DESK") || (Type == "APPROVAL"))
                        {
                            DataTable dt = Main.SelectImages(txtRequestID.Text, "BRANCH_IMAGE");
                            galleryDataList.DataSource = dt;
                            galleryDataList.DataBind();

                            DataTable dt33 = Main.SelectImages(txtRequestID.Text, "BRANCH_DOCS");
                            //galleryDataList.DataSource = myImageDir.GetFiles();
                            DataList1.DataSource = dt33;
                            DataList1.DataBind();
                        }

                        CmbStatus.Items.Clear();
                        CmbStatus.DataSource = Main.SelectReferanceData("HANDLER_STATUS", "", "");
                        CmbStatus.DataValueField = "DESCRIPTION";
                        CmbStatus.DataTextField = "DESCRIPTION";
                        CmbStatus.DataBind();
                        CmbStatus.Items.Insert(0, new RadComboBoxItem("--Select Status--", ""));


                    }
                    else
                    {
                        DataTable Reg = Main.SelectJobFromRegister("CASE6", "", Session["USER"].ToString(), "", System.DateTime.Now);
                        grdRequest.DataSource = Reg;
                        grdRequest.DataBind();

                    }

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



        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try 
            {
                if (CmbStatus.SelectedItem.Value != "")
                {
                    Main.UpdateRegister_StatusByHandler(txtRequestID.Text, CmbStatus.SelectedItem.Value, Session["USER"].ToString());
                    lblError.Text = "Update Successful..";
                }
                if (CmbStatus.SelectedItem.Value == "APPROVE")
                {
                    DataTable dd = Main.SelectJobFromRegister("CASE19", txtRequestID.Text, "", "", System.DateTime.Now);

                    if (dd.Rows.Count >= 1)
                    {
                        if (dd.Rows[0]["REQUEST_ID"].ToString() != "")
                        {
                            if (dd.Rows[0]["JOB_TYPE"].ToString() == "CR")
                            {

                                CM_Main.InsertRegister(txtRequestID.Text, "", Session["USER"].ToString(), "APPROVED CR", dd.Rows[0]["SYSTEM_TYPE"].ToString(), "IT WORKFLOW APPROVED CHANGE", Session["HnbaEmail"].ToString());

                                DataTable dt = CM_Main.MaxJobNo();
                                string JobNo = dt.Rows[0]["JOBS"].ToString();
                                lblCMID.Text = JobNo;

                                IntimateEmail();

                                lblError.Text = "Update Successful,CR Created in the Change Management System..";
                            }

                        }
                    }
                    else
                    {
                        lblError.Text = "CR already created in the Change Management System..";
                    }
                    
                    ApproveEmail();
                }
                if (CmbStatus.SelectedItem.Value == "RETURN")
                {
                    ReturnEmail();
                }


            }

            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }



        public void IntimateEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            //    DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtReqID.Text, "");
            //   string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();

            DataTable dd = Main.SelectJobFromRegister("CASE4", txtRequestID.Text, "", "", System.DateTime.Now);

            if (dd.Rows[0]["SYSTEM_TYPE"].ToString() == "TCS")
            {
                //----Handled User
                DataTable AssignAndPlan = CM_Main.SelectReferanceData("ASSIGN_PLAN_USERS", "TCS", "");
                string AssignAndPlanEmail = AssignAndPlan.Rows[0]["EMAIL"].ToString();
                message.To.Add(AssignAndPlanEmail);
            }
            else if (dd.Rows[0]["SYSTEM_TYPE"].ToString() == "HARDWARE")
            {
                DataTable AssignAndPlan = CM_Main.SelectReferanceData("ASSIGN_PLAN_USERS", "HARDWARE", "");
                string AssignAndPlanEmail = AssignAndPlan.Rows[0]["EMAIL"].ToString();
                message.To.Add(AssignAndPlanEmail);
            }
            else if (dd.Rows[0]["SYSTEM_TYPE"].ToString() == "IT_SUPPORT")
            {
                DataTable AssignAndPlan = CM_Main.SelectReferanceData("ASSIGN_PLAN_USERS", "IT_SUPPORT", "");
                string AssignAndPlanEmail = AssignAndPlan.Rows[0]["EMAIL"].ToString();
                message.To.Add(AssignAndPlanEmail);
            }
            else
            {
                DataTable AssignAndPlan = CM_Main.SelectReferanceData("ASSIGN_PLAN_USERS", "INHOUSE_DEV", "");
                string AssignAndPlanEmail = AssignAndPlan.Rows[0]["EMAIL"].ToString();
                message.To.Add(AssignAndPlanEmail);
            }


            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
           // message.To.Add(FromAdd);
            //     message.To.Add(AssinUserEmail);
            //   message.To.Add(HandledUserEmail);


            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();



            message.From = from;
            message.Subject = Prifix + "Change Management Request" + "-" + lblCMID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>" + "APPROVED CR" + " </td>" +
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
                             "             <td colspan=2 class=txt_normal><strong>" + "New Job Request has been intimated in the IT Change Management System. Please log in to the system to Assign and Plan - ID :" + lblCMID.Text + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>IT Work Flow ID : " + dd.Rows[0]["REQUEST_ID"].ToString() + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Oraganization : " + dd.Rows[0]["COMPANY"].ToString() + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>System : " + dd.Rows[0]["SYSTEM_TYPE"].ToString() + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Description : " + "IT WORKFLOW APPROVED CHANGE" + "</td>" +//
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
                             "       <td class=inner_table_td_red>To view more details and to Assign and Plan : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + lblCMID.Text + "> Click Here </a> </td> " +
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

        public void ApproveEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtRequestID.Text, "");
            string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();

            //----Handled User
            DataTable HandledUser = Main.SelectReferanceData("HANDLED_FOREMAIL", txtRequestID.Text, "");
            string HandledUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();

            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.To.Add(FromAdd);
            message.To.Add(AssinUserEmail);
            message.To.Add(HandledUserEmail);

            if (RadAsyncUpload2.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in RadAsyncUpload2.UploadedFiles)
                {
                    file.SaveAs(Server.MapPath("~/UploadDocuments/" + file.GetName()));
                    message.Attachments.Add(new Attachment(Server.MapPath("~/UploadDocuments/" + file.GetName())));

                }
            }

            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();


            message.From = from;
            message.Subject = Prifix + "Request-APPROVED" + "-" + txtRequestID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>" + txtJobDes.Text + " </td>" +
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
                             "             <td colspan=2 class=txt_normal><strong>" + txtRemarks.Text + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Job ID : " + txtRequestID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Handled User : " + Session["USER"].ToString() + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Status : " + CmbStatus.SelectedItem.Text + "</td>" +//
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + txtRequestID.Text + "> Click Here </a> </td> " +
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
                             " This is an auto generated email sent to you from the IT Workflow system. Please do not reply to this email. " +
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


        public void ReturnEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtRequestID.Text, "");
            string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();

            //----Handled User
            DataTable HandledUser = Main.SelectReferanceData("HANDLED_FOREMAIL", txtRequestID.Text, "");
            string HandledUserEmail = HandledUser.Rows[0]["EMAIL_ADDRESS"].ToString();

            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.To.Add(FromAdd);
            message.To.Add(AssinUserEmail);
            message.To.Add(HandledUserEmail);

            if (RadAsyncUpload2.UploadedFiles.Count > 0)
            {
                foreach (UploadedFile file in RadAsyncUpload2.UploadedFiles)
                {
                    file.SaveAs(Server.MapPath("~/UploadDocuments/" + file.GetName()));
                    message.Attachments.Add(new Attachment(Server.MapPath("~/UploadDocuments/" + file.GetName())));

                }
            }

            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();


            message.From = from;
            message.Subject = Prifix + "Request-RETURNED" + "-" + txtRequestID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>" + txtJobDes.Text + " </td>" +
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
                             "             <td colspan=2 class=txt_normal><strong>Return Reason :  " + txtRejectReason.Text + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Job ID : " + txtRequestID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Handled User : " + Session["USER"].ToString() + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Status : " + CmbStatus.SelectedItem.Text + "</td>" +//
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + txtRequestID.Text + "> Click Here </a> </td> " +
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
                             " This is an auto generated email sent to you from the IT Workflow system. Please do not reply to this email. " +
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

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable Reg = Main.SelectJobFromRegister("CASE4", txtReqNo.Text, "", "", System.DateTime.Now);
                grdRequest.DataSource = Reg;
                grdRequest.DataBind();



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

        protected void grdRequest_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {

                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dd = Main.SelectJobFromRegister("CASE4", dataitem["REQUEST_ID"].Text, "", "", System.DateTime.Now);
                    grdRequest.DataSource = dd;
                    grdRequest.DataBind();

                    txtRequestID.Text = dd.Rows[0]["REQUEST_ID"].ToString();
                    txtJobDes.Text = dd.Rows[0]["JOB_DESCRIPTION"].ToString();
                    txtStatus.Text = dd.Rows[0]["STATUS"].ToString();
                    txtRemarks.Text = dd.Rows[0]["REMARKS_UNIT"].ToString();
                    txtRemarksBranch.Text = dd.Rows[0]["REMARKS_BRANCH"].ToString();

                    DataTable UserType = Main.SelectReferanceData("HANDLED_USERS_TYPES", Session["USER"].ToString(), "");
                    string Type = UserType.Rows[0]["USER_TYPE"].ToString();
                    if ((Type == "IN_HOUSE_DEV") || (Type == "HELP_DESK") || (Type == "APPROVAL"))
                    {
                        DataTable dt = Main.SelectImages(txtRequestID.Text, "BRANCH_IMAGE");
                        galleryDataList.DataSource = dt;
                        galleryDataList.DataBind();

                        DataTable dt33 = Main.SelectImages(txtRequestID.Text, "BRANCH_DOCS");
                        //galleryDataList.DataSource = myImageDir.GetFiles();
                        DataList1.DataSource = dt33;
                        DataList1.DataBind();
                    }

                    CmbStatus.Items.Clear();
                    CmbStatus.DataSource = Main.SelectReferanceData("HANDLER_STATUS", "", "");
                    CmbStatus.DataValueField = "DESCRIPTION";
                    CmbStatus.DataTextField = "DESCRIPTION";
                    CmbStatus.DataBind();
                    CmbStatus.Items.Insert(0, new RadComboBoxItem("--Select Status--", ""));


                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void grdRequest_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable Reg = Main.SelectJobFromRegister("CASE6", "", Session["USER"].ToString(), "", System.DateTime.Now);
            grdRequest.DataSource = Reg;
        }

        protected void CmbStatus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (CmbStatus.SelectedItem.Value == "RETURN")
            {
                txtRejectReason.Visible = true;
            }
            else
            {
                txtRejectReason.Text = "";
                txtRejectReason.Visible = false;
            }
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HandlerForm.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HandlerForm.aspx");
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = DataList1.SelectedIndex;

            Label lbl = (Label)DataList1.Items[idx].FindControl("Label2");

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




       


    }
}