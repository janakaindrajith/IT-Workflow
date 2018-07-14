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
using Oracle.DataAccess;
using Oracle.DataAccess.Client;


using quickinfo_v2.Connectivity;
using quickinfo_v2.CommonCLS;


namespace quickinfo_v2.Views.ChangeManagement
{
    public partial class Implement : System.Web.UI.Page
    {
        string UserName = "";
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        ChangeManagementMain CM_Main = new ChangeManagementMain();
        DataTable DtRef;
        string ReqID;
        StringBuilder sb = new StringBuilder();
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

                    DataTable dtconall = CM_Main.SelectJob("CASE2", "", "APPROVE", "", "", "", System.DateTime.Now);
                    grdRequest.DataSource = dtconall;
                    grdRequest.DataBind();

                    if (Request.QueryString["ReqID"] != null)
                    {
                        ReqID = Request.QueryString["ReqID"];

                        DataTable dtcon = CM_Main.SelectJob("CASE11", ReqID, "", "", "", "", System.DateTime.Now);
                        grdRequest.DataSource = dtcon;
                        grdRequest.DataBind();

                        BtnUpdate.Enabled = true;
                        // BtnReject.Enabled = true;

                        txtReqID.Text = dtcon.Rows[0]["REQUEST_ID"].ToString();
                        lblCompany.Text = dtcon.Rows[0]["COMPANY"].ToString();
                        lblStatus.Text = dtcon.Rows[0]["STATUS"].ToString();
                        lblTitle.Text = dtcon.Rows[0]["TITLE"].ToString();
                        lblSystem.Text = dtcon.Rows[0]["SYSTEM"].ToString();
                        lblDescription.Text = dtcon.Rows[0]["DESCRIPTION"].ToString();
                        lblApprovalComment.Text = dtcon.Rows[0]["APPROVE_COMMENT"].ToString();

                        lblRequestUser.Text = dtcon.Rows[0]["RU_FULLNAME"].ToString();
                        lblManager.Text = dtcon.Rows[0]["MAN_FULLNAME"].ToString();
                        lblImplement.Text = dtcon.Rows[0]["IMP_FULLNAME"].ToString();
                        lblQA.Text = dtcon.Rows[0]["QA_FULLNAME"].ToString();
                        lblRelease.Text = dtcon.Rows[0]["RE_FULLNAME"].ToString();

                        lblRejectRea.Text = dtcon.Rows[0]["REJECT_COMMENT"].ToString();
                        lblImpact.Text = dtcon.Rows[0]["IMPACT"].ToString();
                        lblOutage.Text = dtcon.Rows[0]["OUTAGE"].ToString();
                        lblFallBack.Text = dtcon.Rows[0]["FEEDBACK_PLAN"].ToString();

                        lblParent.Text = dtcon.Rows[0]["PARENT_ID"].ToString();

                        lblCreation.Text = dtcon.Rows[0]["REQUEST_DATE"].ToString();
                        lblStart.Text = dtcon.Rows[0]["START_DATE"].ToString();
                        lblEnd.Text = dtcon.Rows[0]["END_DATE"].ToString();
                        lblLastUpdate.Text = dtcon.Rows[0]["LAST_UPDATE_DATE"].ToString();
                        lblAssign.Text = dtcon.Rows[0]["ASSIGN_DATE"].ToString();


                        txtApproveComment.Text = dtcon.Rows[0]["IMPLEMENTATION_COMMENT"].ToString();

                        RdGrdEvents.DataSource = CM_Main.SelectJob("CASE10", ReqID, "", "", "", "", System.DateTime.Now);
                        RdGrdEvents.DataBind();


                        DataTable dtDocsJobWise = CM_Main.SelectJob("CASE13", txtReqID.Text, "", "", "", "", System.DateTime.Now);
                        if (dtDocsJobWise.Rows.Count >= 1)
                        {
                            RadListBox2.DataSource = dtDocsJobWise;
                            RadListBox2.DataTextField = "DOCUMENT";
                            RadListBox2.DataValueField = "DOCUMENT";
                            RadListBox2.DataBind();
                        }

                        GrdViewDocs.DataSource = CM_Main.SelectJob("CASE15", txtReqID.Text, "", "", "", "", System.DateTime.Now);
                        GrdViewDocs.DataBind();


                        DataTable dt = Main.SelectImages(dtcon.Rows[0]["IT_REQUEST_ID"].ToString(), "BRANCH_IMAGE");
                        galleryDataList.DataSource = dt;
                        galleryDataList.DataBind();

                        DataTable dt33 = Main.SelectImages(dtcon.Rows[0]["IT_REQUEST_ID"].ToString(), "BRANCH_DOCS");
                        DataList2.DataSource = dt33;
                        DataList2.DataBind();


                        DataTable dtEvents = Main.SelectJobFromRegister("CASE16", dtcon.Rows[0]["IT_REQUEST_ID"].ToString(), "", "", System.DateTime.Now);
                        RadGrdEventsITWF.DataSource = dtEvents;
                        RadGrdEventsITWF.DataBind();
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

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtcon = CM_Main.SelectJob("CASE2", txtChangeID.Text, ddlStatusSch.SelectedItem.Value, TxtTitleSch.Text,ddlRequestUserSch.SelectedItem.Value, "", System.DateTime.Now);
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

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Implement.aspx");
        }

        protected void grdRequest_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {

                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dtcon = CM_Main.SelectJob("CASE11", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    grdRequest.DataSource = dtcon;
                    grdRequest.DataBind();

                    BtnUpdate.Enabled = true;
                   // BtnReject.Enabled = true;

                    txtReqID.Text = dtcon.Rows[0]["REQUEST_ID"].ToString();
                    lblCompany.Text = dtcon.Rows[0]["COMPANY"].ToString();
                    lblStatus.Text = dtcon.Rows[0]["STATUS"].ToString();
                    lblTitle.Text = dtcon.Rows[0]["TITLE"].ToString();
                    lblSystem.Text = dtcon.Rows[0]["SYSTEM"].ToString();
                    lblDescription.Text = dtcon.Rows[0]["DESCRIPTION"].ToString();
                    lblApprovalComment.Text = dtcon.Rows[0]["APPROVE_COMMENT"].ToString();

                    lblRequestUser.Text = dtcon.Rows[0]["RU_FULLNAME"].ToString();
                    lblManager.Text = dtcon.Rows[0]["MAN_FULLNAME"].ToString();
                    lblImplement.Text = dtcon.Rows[0]["IMP_FULLNAME"].ToString();
                    lblQA.Text = dtcon.Rows[0]["QA_FULLNAME"].ToString();
                    lblRelease.Text = dtcon.Rows[0]["RE_FULLNAME"].ToString();

                    lblRejectRea.Text = dtcon.Rows[0]["REJECT_COMMENT"].ToString();
                    lblImpact.Text = dtcon.Rows[0]["IMPACT"].ToString();
                    lblOutage.Text = dtcon.Rows[0]["OUTAGE"].ToString();
                    lblFallBack.Text = dtcon.Rows[0]["FEEDBACK_PLAN"].ToString();

                    lblParent.Text = dtcon.Rows[0]["PARENT_ID"].ToString();

                    lblCreation.Text = dtcon.Rows[0]["REQUEST_DATE"].ToString();
                    lblStart.Text = dtcon.Rows[0]["START_DATE"].ToString();
                    lblEnd.Text = dtcon.Rows[0]["END_DATE"].ToString();
                    lblLastUpdate.Text = dtcon.Rows[0]["LAST_UPDATE_DATE"].ToString();
                    lblAssign.Text = dtcon.Rows[0]["ASSIGN_DATE"].ToString();


                    txtApproveComment.Text = dtcon.Rows[0]["IMPLEMENTATION_COMMENT"].ToString();

                    RdGrdEvents.DataSource = CM_Main.SelectJob("CASE10", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    RdGrdEvents.DataBind();


                    DataTable dtDocsJobWise = CM_Main.SelectJob("CASE13", txtReqID.Text, "", "", "", "", System.DateTime.Now);
                    if (dtDocsJobWise.Rows.Count >= 1)
                    {
                        RadListBox2.DataSource = dtDocsJobWise;
                        RadListBox2.DataTextField = "DOCUMENT";
                        RadListBox2.DataValueField = "DOCUMENT";
                        RadListBox2.DataBind();
                    }

                    GrdViewDocs.DataSource = CM_Main.SelectJob("CASE15", txtReqID.Text, "", "", "", "", System.DateTime.Now);
                    GrdViewDocs.DataBind();



                    DataTable dt = Main.SelectImages(dtcon.Rows[0]["IT_REQUEST_ID"].ToString(), "BRANCH_IMAGE");
                    galleryDataList.DataSource = dt;
                    galleryDataList.DataBind();

                    DataTable dt33 = Main.SelectImages(dtcon.Rows[0]["IT_REQUEST_ID"].ToString(), "BRANCH_DOCS");
                    DataList2.DataSource = dt33;
                    DataList2.DataBind();


                    DataTable dtEvents = Main.SelectJobFromRegister("CASE16", dtcon.Rows[0]["IT_REQUEST_ID"].ToString(), "", "", System.DateTime.Now);
                    RadGrdEventsITWF.DataSource = dtEvents;
                    RadGrdEventsITWF.DataBind();

                }
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        public void ImplementEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            //    DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtReqID.Text, "");
            //   string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();




            DataTable dtcon = CM_Main.SelectJob("CASE14", txtReqID.Text, "", "", "", "", System.DateTime.Now);

            if (lblManager.Text != "")
            {

                message.To.Add(dtcon.Rows[0]["MANAGER_EMAIL"].ToString());
            }
            if (lblImplement.Text != "")
            {

                message.To.Add(dtcon.Rows[0]["IMPLEMENTOR_EMAIL"].ToString());
            }
            if (lblQA.Text != "")
            {

                message.To.Add(dtcon.Rows[0]["QA_EMAIL"].ToString());
            }

            if (lblRelease.Text != "")
            {

                message.To.Add(dtcon.Rows[0]["RELEASE_EMAIL"].ToString());
            }


            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.To.Add(FromAdd);


            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();


            message.From = from;
            message.Subject = Prifix + "CR Implemented" + "-" + txtReqID.Text;
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
                             "             <td colspan=2 class=txt_normal><strong>" + "CR has been Implemented in the IT Change Management System. Please log in to the system to Release - ID :" + txtReqID.Text + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>IT Work Flow ID : " + dtcon.Rows[0]["IT_REQUEST_ID"].ToString() + "</td>" +
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
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>CR Manager : " + lblManager.Text + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>CR Implementor : " + lblImplement.Text + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>CR QA Agent : " + lblQA.Text + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>CR Release Person : " + lblRelease.Text + "</td>" +//
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
                             "       <td class=inner_table_td_red>To view more details and Release : <a href=" + "http://192.168.10.89:82/ITWorkflow/Views/ChangeManagement/Monitor.aspx?ReqID=" + txtReqID.Text + "> Click Here </a> </td> " +
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string chk1 = "";
                string chk2 = "";
                string chk3 = "";
                string chk4 = "";
                string chk5 = "";


                CM_Main.UpdateRegister_Implement(txtReqID.Text, txtApproveComment.Text, chk1, chk2,chk3,chk4,chk5, Session["USER"].ToString());

                lblError.Text = "Job Implemented...Job No : " + txtReqID.Text;
                ImplementEmail();
                string myStringVariable = "Job Implemented...Job No : " + txtReqID.Text;
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Implement.aspx");
        }

        protected void RadAsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
           
        }





        protected void RadListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnUpload.Visible = true;
            RadAsyncUpload1.UploadedFiles.Clear();
        //    string message = String.Format("RadListBox1: SelectedIndexChanged {{ SelectedIndex: {0}, SelectedValue: {1} }}", RadListBox2.SelectedIndex, RadListBox2.SelectedValue);
            lblUpload.Text = "";
           
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (RadAsyncUpload1.UploadedFiles.Count > 0)
            {

                var path = Server.MapPath("~/UploadDocuments/" + txtReqID.Text);
                var directory = new DirectoryInfo(path);

                foreach (UploadedFile file in RadAsyncUpload1.UploadedFiles)
                {

                    //New

                    if (directory.Exists == false)
                    {
                        directory.Create();
                    }

                    //New

                    file.SaveAs(Server.MapPath("~/UploadDocuments/" + txtReqID.Text + "/" + file.GetName()));
                    string savePath = (Server.MapPath("~/UploadDocuments/" + txtReqID.Text + "/" + file.GetName())).ToString();
                    //Blob Begin
                    byte[] byteArray = null;

                    using (FileStream fs = new FileStream(savePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {

                        byteArray = new byte[fs.Length];

                        int iBytesRead = fs.Read(byteArray, 0, (int)fs.Length);
                    }

                    string sql = "INSERT INTO WF_CM_DOCS_JOBWISE_BLOB (JOB_NO,DOCUMENT,ATTATCHED_DATE,DOCUMENT_NAME,REMARK,TYPE,ID) VALUES (:JOB_NO, :DOCUMENT,:ATTATCHED_DATE,:DOCUMENT_NAME,:REMARK,:TYPE,:ID)";

                    OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());


                    conn.Open();
                    string a = file.GetName();

                    DataTable DtID = CM_Main.CM_SelectMaxIDinDocuments();
                    int MaxID = Convert.ToInt32(DtID.Rows[0]["MAXID"]);
                    int NextID = MaxID + 1;



                    string Type = "IMAGE";
                    string Extention = file.GetExtension().ToUpper();

                    if ((Extention == ".TIF") || (Extention == ".TIFF") || (Extention == ".PNG") || (Extention == ".JPEG") || (Extention == ".JPG") || (Extention == ".JIF") || (Extention == ".JFIF"))
                    {
                        Type = "IMAGE";
                    }
                    else
                    {
                        Type = "DOCS";
                    }

                    string DocName = "CM" + NextID + Extention;
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {

                        cmd.Parameters.Add("JOB_NO", OracleDbType.Varchar2, txtReqID.Text, ParameterDirection.Input);
                        cmd.Parameters.Add("DOCUMENT", OracleDbType.Blob, byteArray, ParameterDirection.Input);
                        cmd.Parameters.Add("ATTATCHED_DATE", OracleDbType.Date, System.DateTime.Now, ParameterDirection.Input);
                        cmd.Parameters.Add("DOCUMENT_NAME", OracleDbType.Varchar2, DocName, ParameterDirection.Input);
                        cmd.Parameters.Add("REMARK", OracleDbType.Varchar2, txtRemark.Text, ParameterDirection.Input);
                        cmd.Parameters.Add("TYPE", OracleDbType.Varchar2, RadListBox2.SelectedValue, ParameterDirection.Input);
                        cmd.Parameters.Add("ID", OracleDbType.Int32, NextID, ParameterDirection.Input);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                    //Blob END
               

                    System.IO.File.Delete(savePath);

                }


                directory.Delete();



            }



            lblUpload.Text = "Document Uploaded..";
            txtRemark.Text = "";
            GrdViewDocs.DataSource = CM_Main.SelectJob("CASE15", txtReqID.Text, "", "", "", "", System.DateTime.Now);
            GrdViewDocs.DataBind();



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

            System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            System.Data.OracleClient.OracleCommand myCommand = new System.Data.OracleClient.OracleCommand("SELECT * FROM wf_it_images WHERE ID = '" + lbl.Text + "'", conn);
            conn.Open();
            System.Data.OracleClient.OracleDataReader myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.Default);
            try
            {
                while (myReader.Read())
                {

                    System.Data.OracleClient.OracleLob myLob = myReader.GetOracleLob(myReader.GetOrdinal("IMAGE"));
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

        protected void GrdViewDocs_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                GridDataItem dataitem = e.Item as GridDataItem;

                //DataTable dtcon = CM_Main.SelectJob("CASE11", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                //grdRequest.DataSource = dtcon;
                //grdRequest.DataBind();

              //  int idx = dataitem["REQUEST_ID"].Text;

               // Label lbl = dataitem["ID"].Text;

                System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                System.Data.OracleClient.OracleCommand myCommand = new System.Data.OracleClient.OracleCommand("SELECT * FROM wf_cm_docs_jobwise_blob WHERE ID = '" + dataitem["ID"].Text + "'", conn);
                conn.Open();
                System.Data.OracleClient.OracleDataReader myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.Default);
                try
                {
                    while (myReader.Read())
                    {

                        System.Data.OracleClient.OracleLob myLob = myReader.GetOracleLob(myReader.GetOrdinal("DOCUMENT"));
                        if (!myLob.IsNull)
                        {
                            string FN = myReader.GetString(myReader.GetOrdinal("DOCUMENT_NAME"));


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

        protected void RadGrdEventsITWF_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
           
        }

        protected void RdGrdEvents_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RdGrdEvents.DataSource = CM_Main.SelectJob("CASE10", txtReqID.Text, "", "", "", "", System.DateTime.Now);
        }

    
    }
}