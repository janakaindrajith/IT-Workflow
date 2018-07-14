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
using System.Threading;


//using System.Drawing;
//using System.Text;
//using System.Data.OleDb;
//using System.Data.OracleClient;
//using System.Data.SqlClient;
//using System.Net;
//using System.DirectoryServices;
//using System.Net.Mail;
//using System.IO;

using quickinfo_v2.Connectivity;
using quickinfo_v2.CommonCLS;



namespace quickinfo_v2.Views.ITWorkflow
{

    public partial class UserRequestForm : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        DataTable DtRef;
        string UserName = "";
        ChangeManagementMain CM_Main = new ChangeManagementMain();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    grdRequest.DataSource = new int[] { };
                    UserName = User.Identity.Name;

                    if (Cache["user_company"].ToString() == "HNBA")
                    {

                        UserName = Right(UserName, (UserName.Length) - 5);
                        Session["USER"] = UserName;
                        GetUser(UserName.ToString());

                    }
                    else if (Cache["user_company"].ToString() == "HNBGI")
                    {

                        UserName = Right(UserName, (UserName.Length) - 6);
                        Session["USER"] = UserName;
                        GetUser(UserName.ToString());

                    }


                    ddlSystem.Items.Clear();
                    ddlSystem.DataSource = Main.SelectReferanceData("SYSTEM_TYPE", "", "");
                    ddlSystem.DataValueField = "ID";
                    ddlSystem.DataTextField = "DESCRIPTION";
                    ddlSystem.DataBind();
                    ddlSystem.Items.Insert(0, new RadComboBoxItem("--Select System--", ""));


                    ddlPriority.Items.Clear();
                    ddlPriority.DataSource = Main.SelectReferanceData("PRIORITY", "", "");
                    ddlPriority.DataValueField = "ID";
                    ddlPriority.DataTextField = "DESCRIPTION";
                    ddlPriority.DataBind();


                    DataTable Reg = Main.SelectJobFromRegister("CASE15", Session["USER"].ToString(), "", "", System.DateTime.Now);
                    grdRequest.DataSource = Reg;
                    grdRequest.DataBind();


                    if (Request.QueryString["ReqID"] != null)
                    {
                        string ReqID = Request.QueryString["ReqID"];
                        DataTable dd = Main.SelectJobFromRegister("CASE4", ReqID, "", "", System.DateTime.Now);
                        grdRequest.DataSource = dd;
                        grdRequest.DataBind();

                        BtnUpdate.Enabled = true;
                        BtnInsert.Enabled = false;

                        if (dd.Rows[0]["SYSTEM_TYPE"].ToString() != "")
                        {

                            ddlSystem.Items.Clear();
                            ddlSystem.DataSource = Main.SelectReferanceData("SYSTEM_TYPE", "", "");
                            ddlSystem.DataValueField = "ID";
                            ddlSystem.DataTextField = "DESCRIPTION";
                            ddlSystem.DataBind();
                            ddlSystem.Items.Insert(0, new RadComboBoxItem(dd.Rows[0]["SYSTEM_TYPE"].ToString(), dd.Rows[0]["SYSTEM_TYPE"].ToString()));
                        }

                        if (dd.Rows[0]["PRIORITY"].ToString() != "")
                        {
                            ddlPriority.Items.Clear();
                            ddlPriority.DataSource = Main.SelectReferanceData("PRIORITY", "", "");
                            ddlPriority.DataValueField = "ID";
                            ddlPriority.DataTextField = "DESCRIPTION";
                            ddlPriority.DataBind();
                            ddlPriority.Items.Insert(0, new RadComboBoxItem(dd.Rows[0]["PRIORITY"].ToString(), dd.Rows[0]["PRIORITY"].ToString()));
                        }

                        txtRefNo2.Text = dd.Rows[0]["REF_NO"].ToString();
                        txtRemarks.Text = dd.Rows[0]["REMARKS_BRANCH"].ToString();
                        lblStatus.Text = dd.Rows[0]["STATUS"].ToString();
                        lblRequestID.Text = dd.Rows[0]["REQUEST_ID"].ToString();

                        DataTable dtEvents = Main.SelectJobFromRegister("CASE16", ReqID, "", "", System.DateTime.Now);
                        GrdEvents.DataSource = dtEvents;
                        GrdEvents.DataBind();

                        if (lblStatus.Text == "CLOSE")
                        {
                            LnkBtnClose.Visible = true;
                            lblClose.Visible = true;
                        }
                        if (lblStatus.Text == "UAT RELEASE")
                        {
                            BtnUAT.Visible = true;
                            BtnUATReject.Visible = true;
                            LnkBtnClose.Visible = false;
                            lblClose.Visible = false;
                            BtnUpdate.Enabled = false;
                        }
                        if (lblStatus.Text == "CLOSE-CONFIRM")
                        {
                            LnkBtnClose.Visible = false;
                            lblClose.Visible = false;
                            BtnUpdate.Enabled = false;
                            BtnUAT.Visible = false;
                            BtnUATReject.Visible = false;

                        }

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

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Reg = Main.SelectJobFromRegister("CASE1", txtRefNo.Text, txtRequestID.Text, "", System.DateTime.Now);
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {

                ////-----------janaka--------------
                String Temp = User.Identity.Name;
                String Comp = "";
                if (Left(Temp, 4) == "HNBA")
                {
                    Comp = "LIFE";
                }
                else if (Left(Temp, 5) == "HNBGI")
                {
                    Comp = "GENERAL";
                }
                ////-------------------------------

                //Shanika
                //Main.InsertRegisterBranch(txtRefNo2.Text, ddlSystem.SelectedItem.Text, txtRemarks.Text, Session["Branch"].ToString(), Session["USER"].ToString(),
                //Session["HnbaEmail"].ToString(), ddlPriority.SelectedItem.Text, "LIFE");
                if(ddlSystem.SelectedIndex == 0)
                {
                    lblError.Text = "Please select a system and try again...!";
                    return;
                }

                Main.InsertRegisterBranch(txtRefNo2.Text, ddlSystem.SelectedItem.Text, txtRemarks.Text, Session["Branch"].ToString(), Session["USER"].ToString(),
                    Session["HnbaEmail"].ToString(), ddlPriority.SelectedItem.Text, Comp, Session["Departmnet"].ToString());

                DataTable dt = Main.MaxJobNo();
                string JobNo = dt.Rows[0]["JOBS"].ToString();
                lblRequestID.Text = JobNo;

                DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblRequestID.Text, "", "", System.DateTime.Now);
                GrdEvents.DataSource = dtEvents;
                GrdEvents.DataBind();


                if (RadAsyncUpload1.UploadedFiles.Count > 0)
                {

                    var path = Server.MapPath("~/UploadDocuments/" + JobNo);
                    var directory = new DirectoryInfo(path);

                    foreach (UploadedFile file in RadAsyncUpload1.UploadedFiles)
                    {
                        //string savePath = System.IO.Path.Combine("~/UploadDocuments/" + Session["USER"].ToString()+ "/", file.GetName());
                        // file.SaveAs(savePath);


                        //New

                        if (directory.Exists == false)
                        {
                            directory.Create();
                        }

                        //New

                        file.SaveAs(Server.MapPath("~/UploadDocuments/" + JobNo + "/" + file.GetName()));
                        string savePath = (Server.MapPath("~/UploadDocuments/" + JobNo + "/" + file.GetName())).ToString();
                        //Blob Begin
                        byte[] byteArray = null;

                        using (FileStream fs = new FileStream(savePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {

                            byteArray = new byte[fs.Length];

                            int iBytesRead = fs.Read(byteArray, 0, (int)fs.Length);
                        }

                        string sql = "INSERT INTO WF_IT_IMAGES (JOB_NO,IMAGE,ATTATCH_DATE,IMAGE_NAME,ID,TYPE) VALUES (:JOB_NO, :IMAGE,:ATTATCH_DATE,:IMAGE_NAME,:ID,:TYPE)";

                        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());


                        conn.Open();
                        string a = file.GetName();

                        DataTable DtID = Main.SelectMaxIDinImages();
                        int MaxID = Convert.ToInt32(DtID.Rows[0]["MAXID"]);
                        int NextID = MaxID + 1;
                        string Type = "BRANCH_IMAGE";
                        string Extention = file.GetExtension().ToUpper();

                        if ((Extention == ".TIF") || (Extention == ".TIFF") || (Extention == ".PNG") || (Extention == ".JPEG") || (Extention == ".JPG") || (Extention == ".JIF") || (Extention == ".JFIF") || (Extention == ".MSG") || (Extention == ".XLS") || (Extention == ".XLSX"))
                        {
                            Type = "BRANCH_IMAGE";
                        }
                        else
                        {
                            Type = "BRANCH_DOCS";
                        }
                        using (OracleCommand cmd = new OracleCommand(sql, conn))
                        {

                            cmd.Parameters.Add("JOB_NO", OracleDbType.Varchar2, JobNo, ParameterDirection.Input);
                            cmd.Parameters.Add("IMAGE", OracleDbType.Blob, byteArray, ParameterDirection.Input);
                            cmd.Parameters.Add("ATTATCH_DATE", OracleDbType.Date, System.DateTime.Now, ParameterDirection.Input);
                            cmd.Parameters.Add("IMAGE_NAME", OracleDbType.Varchar2, a, ParameterDirection.Input);
                            cmd.Parameters.Add("ID", OracleDbType.Int32, NextID, ParameterDirection.Input);
                            cmd.Parameters.Add("TYPE", OracleDbType.Varchar2, Type, ParameterDirection.Input);
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                        //Blob END


                        System.IO.File.Delete(savePath);

                    }


                    directory.Delete();



                }
                lblError.Text = "Insert Successfull...Job No : " + JobNo;
                IntimateEmail();
                lbblUserType.Text = "USER";
                //     System.IO.File.Delete(path);
                Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ecode=e_04", false);

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }

            //Thread.Sleep(5000);
            //Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx", false);
        }




        protected void RadAsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {

        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRequestForm.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRequestForm.aspx");
        }

        protected void RadAsyncUpload1_FileUploaded1(object sender, FileUploadedEventArgs e)
        {

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblStatus.Text == "PENDING-CLARIFICATION")
                {
                    Main.UpdateRegisterByBranch(lblRequestID.Text, "", "", txtRemarks.Text, Session["Branch"].ToString(), Session["USER"].ToString(), "PENDING-CLARIFICATION-COMPLETE", ddlPriority.SelectedItem.Text);
                    PendingClarification_CompleteEmail();
                    lblError.Text = "Update Successfull...";

                }
                else
                {
                    Main.UpdateRegisterByBranch(lblRequestID.Text, "", "", txtRemarks.Text, Session["Branch"].ToString(), Session["USER"].ToString(), "REOPEN", ddlPriority.SelectedItem.Text);
                    ReopenedEmail();
                    lblError.Text = "Update Successfull...";
                }

                DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblRequestID.Text, "", "", System.DateTime.Now);
                GrdEvents.DataSource = dtEvents;
                GrdEvents.DataBind();

                lbblUserType.Text = "USER";

                if (RadAsyncUpload1.UploadedFiles.Count > 0)
                {

                    string JobNo = lblRequestID.Text;

                    var path = Server.MapPath("~/UploadDocuments/" + JobNo);
                    var directory = new DirectoryInfo(path);

                    foreach (UploadedFile file in RadAsyncUpload1.UploadedFiles)
                    {
                        //string savePath = System.IO.Path.Combine("~/UploadDocuments/" + Session["USER"].ToString()+ "/", file.GetName());
                        // file.SaveAs(savePath);


                        //New

                        if (directory.Exists == false)
                        {
                            directory.Create();
                        }

                        //New

                        file.SaveAs(Server.MapPath("~/UploadDocuments/" + JobNo + "/" + file.GetName()));
                        string savePath = (Server.MapPath("~/UploadDocuments/" + JobNo + "/" + file.GetName())).ToString();
                        //Blob Begin
                        byte[] byteArray = null;

                        using (FileStream fs = new FileStream(savePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {

                            byteArray = new byte[fs.Length];

                            int iBytesRead = fs.Read(byteArray, 0, (int)fs.Length);
                        }

                        string sql = "INSERT INTO WF_IT_IMAGES (JOB_NO,IMAGE,ATTATCH_DATE,IMAGE_NAME,ID,TYPE) VALUES (:JOB_NO, :IMAGE,:ATTATCH_DATE,:IMAGE_NAME,:ID,:TYPE)";

                        OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());


                        conn.Open();
                        string a = file.GetName();

                        DataTable DtID = Main.SelectMaxIDinImages();
                        int MaxID = Convert.ToInt32(DtID.Rows[0]["MAXID"]);
                        int NextID = MaxID + 1;
                        string Type = "BRANCH_IMAGE";
                        string Extention = file.GetExtension().ToUpper();

                        if ((Extention == ".TIF") || (Extention == ".TIFF") || (Extention == ".PNG") || (Extention == ".JPEG") || (Extention == ".JPG") || (Extention == ".JIF") || (Extention == ".JFIF"))
                        {
                            Type = "BRANCH_IMAGE";
                        }
                        else
                        {
                            Type = "BRANCH_DOCS";
                        }
                        using (OracleCommand cmd = new OracleCommand(sql, conn))
                        {

                            cmd.Parameters.Add("JOB_NO", OracleDbType.Varchar2, JobNo, ParameterDirection.Input);
                            cmd.Parameters.Add("IMAGE", OracleDbType.Blob, byteArray, ParameterDirection.Input);
                            cmd.Parameters.Add("ATTATCH_DATE", OracleDbType.Date, System.DateTime.Now, ParameterDirection.Input);
                            cmd.Parameters.Add("IMAGE_NAME", OracleDbType.Varchar2, a, ParameterDirection.Input);
                            cmd.Parameters.Add("ID", OracleDbType.Int32, NextID, ParameterDirection.Input);
                            cmd.Parameters.Add("TYPE", OracleDbType.Varchar2, Type, ParameterDirection.Input);
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                        //Blob END


                        System.IO.File.Delete(savePath);

                    }

                    directory.Delete();

                    //     System.IO.File.Delete(path);




                }
            }

            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }


        public void PendingClarification_CompleteEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable RequestUser = Main.SelectReferanceData("REQUEST_USER_MAIL", lblRequestID.Text, "");
            string RequestEmail = RequestUser.Rows[0]["REQUEST_USER_EMAIL"].ToString();

            DataTable Reg = Main.SelectJobFromRegister("CASE4", lblRequestID.Text, "", "", System.DateTime.Now);
            string RefNo = Reg.Rows[0]["REF_NO"].ToString();
            string AssignUser = Reg.Rows[0]["ASSIGN_USER"].ToString();
            string BranchRemarks = Reg.Rows[0]["REMARKS_BRANCH"].ToString();
            string Status = Reg.Rows[0]["STATUS"].ToString();

            DataTable RegEmail = Main.SelectJobFromRegister("CASE10", lblRequestID.Text, "", "", System.DateTime.Now);
            string AssignUserEmail = RegEmail.Rows[0]["ASSIGN_USER_EMAIL"].ToString();

            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.Bcc.Add(FromAdd);
            message.Bcc.Add(RequestEmail);
            message.Bcc.Add(AssignUserEmail);

            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();

            message.From = from;
            message.Subject = Prifix + "Pending Clarification -Complete" + "-" + lblRequestID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>Referance No : " + txtRefNo2.Text + " </td>" +
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
                             "             <td class=inner_table_td_green>Job ID : " + lblRequestID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Help Desk Assign User : " + AssignUser + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Status : " + Status + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Remark : " + BranchRemarks + "</td>" +
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + lblRequestID.Text + "> Click Here </a> </td> " +
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

        public void CloseConfirmEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable RequestUser = Main.SelectReferanceData("REQUEST_USER_MAIL", lblRequestID.Text, "");
            string RequestEmail = RequestUser.Rows[0]["REQUEST_USER_EMAIL"].ToString();

            DataTable Reg = Main.SelectJobFromRegister("CASE4", lblRequestID.Text, "", "", System.DateTime.Now);
            string RefNo = Reg.Rows[0]["REF_NO"].ToString();
            string AssignUser = Reg.Rows[0]["ASSIGN_USER"].ToString();
            string BranchRemarks = Reg.Rows[0]["REMARKS_BRANCH"].ToString();
            string Status = Reg.Rows[0]["STATUS"].ToString();

            DataTable RegEmail = Main.SelectJobFromRegister("CASE10", lblRequestID.Text, "", "", System.DateTime.Now);
            string AssignUserEmail = RegEmail.Rows[0]["ASSIGN_USER_EMAIL"].ToString();

            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.Bcc.Add(FromAdd);
            message.Bcc.Add(RequestEmail);
            message.Bcc.Add(AssignUserEmail);

            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();

            message.From = from;
            message.Subject = Prifix + "Job Closed and Confirmed" + "-" + lblRequestID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>Referance No : " + txtRefNo2.Text + " </td>" +
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
                             "             <td class=inner_table_td_green>Job ID : " + lblRequestID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Help Desk Assign User : " + AssignUser + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Status : " + Status + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Remark : " + BranchRemarks + "</td>" +
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + lblRequestID.Text + "> Click Here </a> </td> " +
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



        public void ReopenedEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable RequestUser = Main.SelectReferanceData("REQUEST_USER_MAIL", lblRequestID.Text, "");
            string RequestEmail = RequestUser.Rows[0]["REQUEST_USER_EMAIL"].ToString();

            DataTable Reg = Main.SelectJobFromRegister("CASE4", lblRequestID.Text, "", "", System.DateTime.Now);
            string RefNo = Reg.Rows[0]["REF_NO"].ToString();
            string AssignUser = Reg.Rows[0]["ASSIGN_USER"].ToString();
            string BranchRemarks = Reg.Rows[0]["REMARKS_BRANCH"].ToString();
            string Status = Reg.Rows[0]["STATUS"].ToString();

            DataTable RegEmail = Main.SelectJobFromRegister("CASE10", lblRequestID.Text, "", "", System.DateTime.Now);
            string AssignUserEmail = RegEmail.Rows[0]["ASSIGN_USER_EMAIL"].ToString();

            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.Bcc.Add(FromAdd);
            message.Bcc.Add(RequestEmail);
            message.Bcc.Add(AssignUserEmail);

            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();

            message.From = from;
            message.Subject = Prifix + "Job Re-opened" + "-" + lblRequestID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>Referance No : " + txtRefNo2.Text + " </td>" +
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
                             "             <td class=inner_table_td_green>Job ID : " + lblRequestID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Help Desk Assign User : " + AssignUser + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Status : " + Status + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Remark : " + BranchRemarks + "</td>" +
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + lblRequestID.Text + "> Click Here </a> </td> " +
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


        public void IntimateEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            string RefNo = txtRefNo2.Text;
            string SystemType = ddlSystem.SelectedItem.Text;
            string Branch = Session["Branch"].ToString();
            string RequestUser = Session["USER"].ToString();

            DataTable RegEmail = Main.SelectJobFromRegister("CASE11", lblRequestID.Text, "", "", System.DateTime.Now);
            if (RegEmail.Rows.Count > 0)
            {
                for (int i = 0; i < RegEmail.Rows.Count; i++)
                {
                    string AssignUserEmail = RegEmail.Rows[i]["ASSIGN_USER_EMAIL_SYS"].ToString();
                    message.CC.Add(AssignUserEmail);
                }
            }


            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.CC.Add(FromAdd);

            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();

            message.From = from;
            message.Subject = Prifix + "New Job Request" + "-" + lblRequestID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>Referance No : " + txtRefNo2.Text + " </td>" +
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
                             "             <td class=inner_table_td_green>Job ID : " + lblRequestID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>System Type : " + SystemType + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Branch : " + Branch + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Request User : " + RequestUser + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Priority : " + ddlPriority.SelectedItem.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Remark : " + txtRemarks.Text + "</td>" +
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + lblRequestID.Text + "> Click Here </a> </td> " +
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

        protected void grdRequest_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DataTable Reg = Main.SelectJobFromRegister("CASE1", txtRefNo.Text, "", "", System.DateTime.Now);
            grdRequest.DataSource = Reg;
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

                    BtnUpdate.Enabled = true;
                    BtnInsert.Enabled = false;

                    if (dd.Rows[0]["SYSTEM_TYPE"].ToString() != "")
                    {

                        ddlSystem.Items.Clear();
                        ddlSystem.DataSource = Main.SelectReferanceData("SYSTEM_TYPE", "", "");
                        ddlSystem.DataValueField = "ID";
                        ddlSystem.DataTextField = "DESCRIPTION";
                        ddlSystem.DataBind();
                        ddlSystem.Items.Insert(0, new RadComboBoxItem(dd.Rows[0]["SYSTEM_TYPE"].ToString(), dd.Rows[0]["SYSTEM_TYPE"].ToString()));
                    }

                    if (dd.Rows[0]["PRIORITY"].ToString() != "")
                    {
                        ddlPriority.Items.Clear();
                        ddlPriority.DataSource = Main.SelectReferanceData("PRIORITY", "", "");
                        ddlPriority.DataValueField = "ID";
                        ddlPriority.DataTextField = "DESCRIPTION";
                        ddlPriority.DataBind();
                        ddlPriority.Items.Insert(0, new RadComboBoxItem(dd.Rows[0]["PRIORITY"].ToString(), dd.Rows[0]["PRIORITY"].ToString()));
                    }

                    txtRefNo2.Text = dd.Rows[0]["REF_NO"].ToString();
                    txtRemarks.Text = dd.Rows[0]["REMARKS_BRANCH"].ToString();
                    lblStatus.Text = dd.Rows[0]["STATUS"].ToString();
                    lblRequestID.Text = dd.Rows[0]["REQUEST_ID"].ToString();


                    if (lblStatus.Text == "CLOSE")
                    {
                        LnkBtnClose.Visible = true;
                        lblClose.Visible = true;
                    }
                    if (lblStatus.Text == "UAT RELEASE")
                    {
                        BtnUAT.Visible = true;
                        BtnUATReject.Visible = true;
                        LnkBtnClose.Visible = false;
                        lblClose.Visible = false;
                        BtnUpdate.Enabled = false;
                    }
                    if (lblStatus.Text == "CLOSE-CONFIRM")
                    {
                        LnkBtnClose.Visible = false;
                        lblClose.Visible = false;
                        BtnUpdate.Enabled = false;
                        BtnUAT.Visible = false;
                        BtnUATReject.Visible = false;

                    }

                    DataTable dtEvents = Main.SelectJobFromRegister("CASE16", dataitem["REQUEST_ID"].Text, "", "", System.DateTime.Now);
                    GrdEvents.DataSource = dtEvents;
                    GrdEvents.DataBind();



                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void LnkBtnClose_Click(object sender, EventArgs e)
        {
            try
            {

                LnkBtnClose.Visible = false;
                lblClose.Visible = false;
                BtnUpdate.Enabled = false;

                Main.UpdateRegisterByBranch(lblRequestID.Text, "", "", txtRemarks.Text, Session["Branch"].ToString(), Session["USER"].ToString(), "CLOSE-CONFIRM", ddlPriority.SelectedItem.Text);
                CloseConfirmEmail();

                DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblRequestID.Text, "", "", System.DateTime.Now);
                GrdEvents.DataSource = dtEvents;
                GrdEvents.DataBind();


                lblError.Text = "Close Confirmation Successfull...";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }


        public void UATConfirm()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            //    DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtReqID.Text, "");
            //   string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();




            DataTable dtcon = CM_Main.SelectJob("CASE17", lblRequestID.Text, "", "", "", "", System.DateTime.Now);



            if (dtcon.Rows[0]["MANAGER_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["MANAGER_EMAIL"].ToString());
            }
            if (dtcon.Rows[0]["IMPLEMENTOR_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["IMPLEMENTOR_EMAIL"].ToString());
            }
            if (dtcon.Rows[0]["QA_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["QA_EMAIL"].ToString());
            }

            if (dtcon.Rows[0]["RELEASE_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["RELEASE_EMAIL"].ToString());
            }

            message.To.Add(dtcon.Rows[0]["IT_REQUESTUSER_EMAIL"].ToString());

            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.To.Add(FromAdd);


            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();

            message.From = from;
            message.Subject = Prifix + "CR UAT Confirmed" + "-" + dtcon.Rows[0]["IT_REQUEST_ID"].ToString();
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
                             "    <td align=left valign=middle  class=outer_table_td>" + dtcon.Rows[0]["TITLE"].ToString() + " </td>" +
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
                             "             <td colspan=2 class=txt_normal><strong>" + "CR has been UAT Confirmed by the user. Please log in to the system to Release CR - ID :" + dtcon.Rows[0]["IT_REQUEST_ID"].ToString() + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Ref No : " + dtcon.Rows[0]["REF_NO"].ToString() + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Oraganization : " + dtcon.Rows[0]["COMPANY"].ToString() + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>System : " + dtcon.Rows[0]["SYSTEM"].ToString() + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Description : " + dtcon.Rows[0]["DESCRIPTION"].ToString() + "</td>" +//
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + dtcon.Rows[0]["IT_REQUEST_ID"].ToString() + "> Click Here </a> </td> " +
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


        protected void BtnUAT_Click(object sender, EventArgs e)
        {
            try
            {

                BtnUAT.Visible = false;

                BtnUpdate.Enabled = false;

                Main.UpdateRegisterByBranch(lblRequestID.Text, "", "", txtRemarks.Text, Session["Branch"].ToString(), Session["USER"].ToString(), "CONFIRM UAT", ddlPriority.SelectedItem.Text);
                UATConfirm();

                DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblRequestID.Text, "", "", System.DateTime.Now);
                GrdEvents.DataSource = dtEvents;
                GrdEvents.DataBind();


                lblError.Text = "UAT Confirmation Successfull...";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }


        public void UATReject()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            //    DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtReqID.Text, "");
            //   string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();




            DataTable dtcon = CM_Main.SelectJob("CASE17", lblRequestID.Text, "", "", "", "", System.DateTime.Now);

            if (dtcon.Rows[0]["REQUEST_USER_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["REQUEST_USER_EMAIL"].ToString());
            }

            if (dtcon.Rows[0]["MANAGER_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["MANAGER_EMAIL"].ToString());
            }
            if (dtcon.Rows[0]["IMPLEMENTOR_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["IMPLEMENTOR_EMAIL"].ToString());
            }
            if (dtcon.Rows[0]["QA_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["QA_EMAIL"].ToString());
            }

            if (dtcon.Rows[0]["RELEASE_EMAIL"].ToString() != "")
            {

                message.To.Add(dtcon.Rows[0]["RELEASE_EMAIL"].ToString());
            }

            message.To.Add(dtcon.Rows[0]["IT_REQUESTUSER_EMAIL"].ToString());

            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.To.Add(FromAdd);


            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();

            message.From = from;
            message.Subject = Prifix + "CR Reject in UAT" + "-" + dtcon.Rows[0]["IT_REQUEST_ID"].ToString();
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
                             "    <td align=left valign=middle  class=outer_table_td>" + dtcon.Rows[0]["TITLE"].ToString() + " </td>" +
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
                             "             <td colspan=2 class=txt_normal><strong>" + "CR has been UAT Rejected by the user. Please log in to the system to Implement CR - ID :" + dtcon.Rows[0]["IT_REQUEST_ID"].ToString() + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Ref No : " + dtcon.Rows[0]["REF_NO"].ToString() + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Oraganization : " + dtcon.Rows[0]["COMPANY"].ToString() + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>System : " + dtcon.Rows[0]["SYSTEM"].ToString() + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Description : " + dtcon.Rows[0]["DESCRIPTION"].ToString() + "</td>" +//
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + dtcon.Rows[0]["IT_REQUEST_ID"].ToString() + "> Click Here </a> </td> " +
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
        protected void BtnUATReject_Click(object sender, EventArgs e)
        {
            try
            {

                BtnUATReject.Visible = false;

                BtnUpdate.Enabled = false;

                Main.UpdateRegisterByBranch(lblRequestID.Text, "", "", txtRemarks.Text, Session["Branch"].ToString(), Session["USER"].ToString(), "REJECT UAT", ddlPriority.SelectedItem.Text);
                UATReject();

                DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblRequestID.Text, "", "", System.DateTime.Now);
                GrdEvents.DataSource = dtEvents;
                GrdEvents.DataBind();


                lblError.Text = "UAT Reject Successfull...";
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