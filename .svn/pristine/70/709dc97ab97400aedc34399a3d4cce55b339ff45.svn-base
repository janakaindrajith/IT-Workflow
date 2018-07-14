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
//using Oracle.DataAccess;
//using Oracle.DataAccess.Client;
//using System.Data.OracleClient;
using quickinfo_v2.Connectivity;
using System.Data.OracleClient;


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
using quickinfo_v2.CommonCLS;


namespace quickinfo_v2.Views.ChangeManagement
{
    public partial class IntimateChange : System.Web.UI.Page
    {
        string UserName = "";
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        ChangeManagementMain CM_Main = new ChangeManagementMain();
        DataTable DtRef;

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

                    ddlRequestUserSch.Items.Clear();
                    ddlRequestUserSch.DataSource = Main.SelectReferanceData("HELPDESK_USERS", "", "");
                    ddlRequestUserSch.DataValueField = "USER_NAME";
                    ddlRequestUserSch.DataTextField = "FULL_NAME";
                    ddlRequestUserSch.DataBind();
                    ddlRequestUserSch.Items.Insert(0, new RadComboBoxItem("--Select Request User--", ""));

                    ddlStatusSch.Items.Clear();
                    ddlStatusSch.DataSource = CM_Main.SelectReferanceData("STATUS", "", "");
                    ddlStatusSch.DataValueField = "DESCRIPTION";
                    ddlStatusSch.DataTextField = "DESCRIPTION";
                    ddlStatusSch.DataBind();
                    ddlStatusSch.Items.Insert(0, new RadComboBoxItem("--Select Status--", ""));

                    if (Request.QueryString["ReqID"] != null)
                    {

                     string   ReqID = Request.QueryString["ReqID"];

                     DataTable dd = Main.SelectJobFromRegister("CASE4", ReqID, "", "", System.DateTime.Now);
                     RadGrid1.DataSource = dd;
                     RadGrid1.DataBind();

                     lblWorkFlowID.Text = dd.Rows[0]["REQUEST_ID"].ToString();

                     lblSystem.Text = dd.Rows[0]["SYSTEM_TYPE"].ToString();
                     lblCompany.Text = dd.Rows[0]["COMPANY"].ToString();


                     DataTable dt = Main.SelectImages(lblWorkFlowID.Text, "BRANCH_IMAGE");
                     galleryDataList.DataSource = dt;
                     galleryDataList.DataBind();

                     DataTable dt33 = Main.SelectImages(lblWorkFlowID.Text, "BRANCH_DOCS");
                     DataList2.DataSource = dt33;
                     DataList2.DataBind();

                     DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblWorkFlowID.Text, "", "", System.DateTime.Now);
                     RadGrdEventsITWF.DataSource = dtEvents;
                     RadGrdEventsITWF.DataBind();
                    }


                

                }
                //if (IsPostBack)
                //{
                //    return;
                //}



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

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
          
            mp1.Show();
            //udpInnerUpdatePanel.Update();
            DataTable Reg = Main.SelectJobFromRegister("CASE9", "", "", "", System.DateTime.Now);
            RadGrid1.DataSource = Reg;
            RadGrid1.DataBind();

            //Panel To Search Work Flow ID
            CmbAssignUser.DataSource = Main.SelectReferanceData("HELPDESK_USERS", "", "");
            CmbAssignUser.DataValueField = "USER_NAME";
            CmbAssignUser.DataTextField = "FULL_NAME";
            CmbAssignUser.DataBind();
            CmbAssignUser.Items.Insert(0, new ListItem("--Select Assign User--", ""));


            CmbSystem.DataSource = Main.SelectReferanceData("SYSTEM_TYPE", "", "");
            CmbSystem.DataValueField = "ID";
            CmbSystem.DataTextField = "DESCRIPTION";
            CmbSystem.DataBind();
            CmbSystem.Items.Insert(0, new ListItem("--Select System--", ""));

            lblSearch.Text = "1";


        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            mp1.Hide();
        }


        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblWorkFlowID.Text != "")
                {
                    CM_Main.InsertRegister(lblWorkFlowID.Text, lblParentChange.Text, Session["USER"].ToString(), txtTitle.Text, lblSystem.Text, txtDesciption.Text, Session["HnbaEmail"].ToString());

                    DataTable dt = CM_Main.MaxJobNo();
                    string JobNo = dt.Rows[0]["JOBS"].ToString();

                    if (RadListBox2.Items.Count >= 1) 
                    { 
                        for (int i = 0; i < RadListBox2.Items.Count; i++)
                         {
                             CM_Main.InsertContacts(JobNo, RadListBox2.Items[i].Value.ToString());
                         }
                    
                    }
                    if (txtPath.Text != "")
                    {
                        CM_Main.InsertPath(JobNo, txtPath.Text);

                    }

                    if (RadAsyncUpload1.UploadedFiles.Count > 0)
                    {
                        var path = Server.MapPath("~/UploadDocuments/" + JobNo);
                        var directory = new DirectoryInfo(path);

                        foreach (UploadedFile file in RadAsyncUpload1.UploadedFiles)
                        {


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

                            string sql = "INSERT INTO WF_CM_IMAGES (JOB_NO,IMAGE,ATTATCH_DATE,IMAGE_NAME,ID,TYPE) VALUES (:JOB_NO, :IMAGE,:ATTATCH_DATE,:IMAGE_NAME,:ID,:TYPE)";

                            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());


                            conn.Open();
                            string a = file.GetName();

                            DataTable DtID = CM_Main.SelectMaxIDinImages();
                            int MaxID = Convert.ToInt32(DtID.Rows[0]["MAXID"]);
                            int NextID = MaxID + 1;
                            string Type = "";
                            string Extention = file.GetExtension().ToUpper();


                            using (Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(sql, conn))
                            {

                                cmd.Parameters.Add("JOB_NO", Oracle.DataAccess.Client.OracleDbType.Varchar2, JobNo, ParameterDirection.Input);
                                cmd.Parameters.Add("IMAGE", Oracle.DataAccess.Client.OracleDbType.Blob, byteArray, ParameterDirection.Input);
                                cmd.Parameters.Add("ATTATCH_DATE", Oracle.DataAccess.Client.OracleDbType.Date, System.DateTime.Now, ParameterDirection.Input);
                                cmd.Parameters.Add("IMAGE_NAME", Oracle.DataAccess.Client.OracleDbType.Varchar2, a, ParameterDirection.Input);
                                cmd.Parameters.Add("ID", Oracle.DataAccess.Client.OracleDbType.Int32, NextID, ParameterDirection.Input);
                                cmd.Parameters.Add("TYPE", Oracle.DataAccess.Client.OracleDbType.Varchar2, Type, ParameterDirection.Input);
                                cmd.ExecuteNonQuery();
                            }
                            conn.Close();
                            //Blob END


                            System.IO.File.Delete(savePath);

                        }

                    
                    }




                    lblError.Text = "Insert Successfull...Job No : " + JobNo;
                    lblID.Text = JobNo;
                    IntimateEmail();

                    string myStringVariable = "Insert Successfull...Job No : " + JobNo;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                
                }
                else
                {
                    string myStringVariable = "Please Add IT Work Flow ID";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
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

            if (lblSystem.Text == "TCS")
            {
                //----Handled User
                DataTable AssignAndPlan = CM_Main.SelectReferanceData("ASSIGN_PLAN_USERS", "TCS", "");
                string AssignAndPlanEmail = AssignAndPlan.Rows[0]["EMAIL"].ToString();
                message.To.Add(AssignAndPlanEmail);
            }
            else if (lblSystem.Text == "HARDWARE")
            {
                DataTable AssignAndPlan = CM_Main.SelectReferanceData("ASSIGN_PLAN_USERS", "HARDWARE", "");
                string AssignAndPlanEmail = AssignAndPlan.Rows[0]["EMAIL"].ToString();
                message.To.Add(AssignAndPlanEmail);
            }
            else if (lblSystem.Text == "IT_SUPPORT")
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
            message.To.Add(FromAdd);
       //     message.To.Add(AssinUserEmail);
         //   message.To.Add(HandledUserEmail);


            string Prifix = WebConfigurationManager.AppSettings["EmailSubjectPrifix"].ToString();



            message.From = from;
            message.Subject = Prifix + "Change Management Request" + "-" + lblID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>" + txtTitle.Text + " </td>" +
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
                             "             <td colspan=2 class=txt_normal><strong>" + "New Job Request has been intimated in the IT Change Management System. Please log in to the system to Assign and Plan - ID :" + lblID.Text + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>IT Work Flow ID : " + lblWorkFlowID.Text + "</td>" +
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
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Description : " + txtDesciption.Text + "</td>" +//
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
                             "       <td class=inner_table_td_red>To view more details and to Assign and Plan : <a href=" + "http://192.168.10.89:82/ITWorkflow/Views/ChangeManagement/Assign_Plan.aspx?ReqID=" + lblID.Text + "> Click Here </a> </td> " +
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


        protected void Button1_Click(object sender, EventArgs e)
        {
          
            DataTable Reg = Main.SelectJobFromRegister("CASE8", txtWFID.Text, CmbSystem.SelectedItem.Value, CmbAssignUser.SelectedItem.Value, System.DateTime.Now);
           
            RadGrid1.DataSource = Reg;
            RadGrid1.DataBind();
            lblSearch.Text = "2";
    
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {

                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dd = Main.SelectJobFromRegister("CASE4", dataitem["REQUEST_ID"].Text, "", "", System.DateTime.Now);
                    RadGrid1.DataSource = dd;
                    RadGrid1.DataBind();

                    lblWorkFlowID.Text = dd.Rows[0]["REQUEST_ID"].ToString();

                    lblSystem.Text = dd.Rows[0]["SYSTEM_TYPE"].ToString();
                    lblCompany.Text = dd.Rows[0]["COMPANY"].ToString();


    

                  //   mp1.Hide();
                 //    txtWorkFlowNO.Text = dd.Rows[0]["REQUEST_ID"].ToString();
                   
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }


        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            if (lblSearch.Text == "1")
            {
                DataTable Reg = Main.SelectJobFromRegister("CASE9", "", "", "", System.DateTime.Now);
                RadGrid1.DataSource = Reg;
                mp1.Show();
            }
            if (lblSearch.Text == "2")
            {
                DataTable Reg = Main.SelectJobFromRegister("CASE8", txtWFID.Text, CmbSystem.SelectedItem.Value, CmbAssignUser.SelectedItem.Value, System.DateTime.Now);
                RadGrid1.DataSource = Reg;
                mp1.Show();
            }
        
        }

        protected void RadAsyncUpload1_FileUploaded1(object sender, FileUploadedEventArgs e)
        {

        }

        protected void BtnSearchContact_Click(object sender, EventArgs e)
        {
            try
            {

            DataTable dtcon = CM_Main.SelectJob("CASE1", txtUserName.Text, txtEPF.Text, "","","", System.DateTime.Now); 
            RadListBox1.DataSource = dtcon;
            RadListBox1.DataTextField = "FULL_NAME";
            RadListBox1.DataValueField = "USER_NAME";
            RadListBox1.DataBind();
            
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }

        }

        protected void BtnSchclear_Click(object sender, EventArgs e)
        {
            try
            {

            txtUserName.Text = "";
            txtEPF.Text = "";
            RadListBox1.Items.Clear();
            RadListBox2.Items.Clear();

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
                    BtnInsert.Enabled = false;
                    BtnUpdate.Enabled = true;


                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dtcon = CM_Main.SelectJob("CASE3", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    grdRequest.DataSource = dtcon;
                    grdRequest.DataBind();

                    lblID.Text = dtcon.Rows[0]["REQUEST_ID"].ToString();
                    lblParentChange.Text = dtcon.Rows[0]["PARENT_ID"].ToString();
                    lblWorkFlowID.Text = dtcon.Rows[0]["IT_REQUEST_ID"].ToString();
                    lblCompany.Text = dtcon.Rows[0]["COMPANY"].ToString();
                    txtStatus.Text = dtcon.Rows[0]["STATUS"].ToString();
                    txtTitle.Text = dtcon.Rows[0]["TITLE"].ToString();
                    lblSystem.Text = dtcon.Rows[0]["SYSTEM"].ToString();
                    txtDesciption.Text = dtcon.Rows[0]["DESCRIPTION"].ToString();


                    RdGrdContacts.DataSource = CM_Main.SelectJob("CASE6", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    RdGrdContacts.DataBind();

                    RdGrdCIPath.DataSource = CM_Main.SelectJob("CASE7", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    RdGrdCIPath.DataBind();

                    RdGrdChildChanges.DataSource = CM_Main.SelectJob("CASE8", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    RdGrdChildChanges.DataBind();


                    DataList1.DataSource = CM_Main.SelectJob("CASE9", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    DataList1.DataBind();

                    RdGrdEvents.DataSource = CM_Main.SelectJob("CASE10", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    RdGrdEvents.DataBind();


                    DataTable dtEvents = Main.SelectJobFromRegister("CASE16", lblWorkFlowID.Text, "", "", System.DateTime.Now);
                    RadGrdEventsITWF.DataSource = dtEvents;
                    RadGrdEventsITWF.DataBind();

                    DataTable dt = Main.SelectImages(lblWorkFlowID.Text, "BRANCH_IMAGE");
                    galleryDataList.DataSource = dt;
                    galleryDataList.DataBind();

                    DataTable dt33 = Main.SelectImages(lblWorkFlowID.Text, "BRANCH_DOCS");
                    DataList2.DataSource = dt33;
                    DataList2.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();

           // Panel To Search Parent ID
            CmbAssignForParent.DataSource = CM_Main.SelectJob("CASE1", "", "", "", "", "", System.DateTime.Now);
            CmbAssignForParent.DataValueField = "USER_NAME";
            CmbAssignForParent.DataTextField = "FULL_NAME";
            CmbAssignForParent.DataBind();
            CmbAssignForParent.Items.Insert(0, new ListItem("--Select Assign User--", ""));

            CmbSystem2.DataSource = Main.SelectReferanceData("SYSTEM_TYPE", "", "");
            CmbSystem2.DataValueField = "ID";
            CmbSystem2.DataTextField = "DESCRIPTION";
            CmbSystem2.DataBind();
            CmbSystem2.Items.Insert(0, new ListItem("--Select System--", ""));

            lblSearch2.Text = "1";
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {


           DataTable Reg = CM_Main.SelectJob("CASE4", txtParent.Text, CmbSystem2.SelectedItem.Text, TxtTitleSch2.Text, CmbAssignForParent.SelectedItem.Value, "", System.DateTime.Now);
            RadGrid7.DataSource = Reg;
            RadGrid7.DataBind();
            lblSearch2.Text = "2";
          
        }


        protected void RadGrid7_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            if (lblSearch2.Text == "2")
            {

                DataTable Reg = CM_Main.SelectJob("CASE4", txtParent.Text, CmbSystem2.SelectedItem.Text, TxtTitleSch2.Text, CmbAssignForParent.SelectedItem.Value, "", System.DateTime.Now);
                RadGrid7.DataSource = Reg;
                ModalPopupExtender1.Show();
            }
        }
        protected void RadGrid7_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {

                    GridDataItem dataitem = e.Item as GridDataItem;

                    DataTable dd = CM_Main.SelectJob("CASE5", dataitem["REQUEST_ID"].Text, "", "", "", "", System.DateTime.Now);
                    RadGrid7.DataSource = dd;
                    RadGrid7.DataBind();

                    lblParentChange.Text = dataitem["REQUEST_ID"].Text;
                        //dd.Rows[0]["REQUEST_ID"].ToString();
                 


                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }
       
        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            
                int idx = DataList1.SelectedIndex;

                Label lbl = (Label)DataList1.Items[idx].FindControl("Label2");

                System.Data.OracleClient.OracleConnection conn = new System.Data.OracleClient.OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                System.Data.OracleClient.OracleCommand myCommand = new System.Data.OracleClient.OracleCommand("SELECT * FROM wf_cm_images WHERE ID = '" + lbl.Text + "'", conn);
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

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblWorkFlowID.Text != "")
                {
                    CM_Main.UpdateRegister(lblID.Text, lblWorkFlowID.Text, lblParentChange.Text, txtTitle.Text, lblSystem.Text, txtDesciption.Text, Session["USER"].ToString());

                    string JobNo = lblID.Text;

                    if (RadListBox2.Items.Count >= 1)
                    {
                        for (int i = 0; i < RadListBox2.Items.Count; i++)
                        {
                            CM_Main.InsertContacts(JobNo, RadListBox2.Items[i].Value.ToString());
                        }

                    }
                    if (txtPath.Text != "")
                    {
                        CM_Main.InsertPath(JobNo, txtPath.Text);

                    }

                    if (RadAsyncUpload1.UploadedFiles.Count > 0)
                    {
                        var path = Server.MapPath("~/UploadDocuments/" + JobNo);
                        var directory = new DirectoryInfo(path);

                        foreach (UploadedFile file in RadAsyncUpload1.UploadedFiles)
                        {


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

                            string sql = "INSERT INTO WF_CM_IMAGES (JOB_NO,IMAGE,ATTATCH_DATE,IMAGE_NAME,ID,TYPE) VALUES (:JOB_NO, :IMAGE,:ATTATCH_DATE,:IMAGE_NAME,:ID,:TYPE)";

                            Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());


                            conn.Open();
                            string a = file.GetName();

                            DataTable DtID = CM_Main.SelectMaxIDinImages();
                            int MaxID = Convert.ToInt32(DtID.Rows[0]["MAXID"]);
                            int NextID = MaxID + 1;
                            string Type = "";
                            string Extention = file.GetExtension().ToUpper();


                            using (Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(sql, conn))
                            {

                                cmd.Parameters.Add("JOB_NO", Oracle.DataAccess.Client.OracleDbType.Varchar2, JobNo, ParameterDirection.Input);
                                cmd.Parameters.Add("IMAGE", Oracle.DataAccess.Client.OracleDbType.Blob, byteArray, ParameterDirection.Input);
                                cmd.Parameters.Add("ATTATCH_DATE", Oracle.DataAccess.Client.OracleDbType.Date, System.DateTime.Now, ParameterDirection.Input);
                                cmd.Parameters.Add("IMAGE_NAME", Oracle.DataAccess.Client.OracleDbType.Varchar2, a, ParameterDirection.Input);
                                cmd.Parameters.Add("ID", Oracle.DataAccess.Client.OracleDbType.Int32, NextID, ParameterDirection.Input);
                                cmd.Parameters.Add("TYPE", Oracle.DataAccess.Client.OracleDbType.Varchar2, Type, ParameterDirection.Input);
                                cmd.ExecuteNonQuery();
                            }
                            conn.Close();
                            //Blob END


                            System.IO.File.Delete(savePath);

                        }


                    }




                    lblError.Text = "Update Successfull...Job No : " + JobNo;
                    string myStringVariable = "Update Successfull...Job No : " + JobNo;
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

                }
                else
                {
                    string myStringVariable = "Please Add IT Work Flow ID";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
                }
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
            Response.Redirect("IntimateChange.aspx");
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("IntimateChange.aspx");
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

        protected void grdRequest_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {

        }

        protected void RdGrdEvents_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            RdGrdEvents.DataSource = CM_Main.SelectJob("CASE10", lblID.Text, "", "", "", "", System.DateTime.Now);
        }
        

    }
}

    