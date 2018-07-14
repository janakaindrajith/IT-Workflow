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
using System.Linq;

using quickinfo_v2.Connectivity;
using quickinfo_v2.CommonCLS;




namespace quickinfo_v2.Views.ITWorkflow
{
    public partial class HelpDeskView : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        DataTable DtRef;
        string UserName = "";
        string ReqID = "";
        StringBuilder sb = new StringBuilder();

        string myConn = ConfigurationManager.ConnectionStrings["ORAWF"].ToString();

        bool manual_search = false;




        private void GetData()
        {
            //if ((manual_search == true) && (Session["searched_id"] != null))
            //{
            //    ReqID = Session["searched_id"].ToString();


            //    DataTable Reg = Main.SelectJobFromRegister("CASE4", ReqID, "", "", System.DateTime.Now);
            //    grdRequest.DataSource = Reg;
            //    grdRequest.DataBind();

            //    txtReqID.Text = Reg.Rows[0]["REQUEST_ID"].ToString();
            //    txtRefNo2.Text = Reg.Rows[0]["REF_NO"].ToString();
            //    txtReqBranch.Text = Reg.Rows[0]["BRANCH"].ToString();
            //    txtReqDate.Text = Reg.Rows[0]["REQ_DATE1"].ToString();
            //    txtRecDate.Text = Reg.Rows[0]["RECEVE_DATE1"].ToString();
            //    txtRemarks.Text = Reg.Rows[0]["REMARKS_BRANCH"].ToString();
            //    txtAssignUser.Text = Reg.Rows[0]["ASSIGN_USER"].ToString();
            //    txtCompDate.Text = Reg.Rows[0]["COMP_DATE1"].ToString();
            //    txtRemarks1.Text = Reg.Rows[0]["REMARKS_UNIT"].ToString();
            //    txtTCSError.Text = Reg.Rows[0]["TCS_ERROR_NO"].ToString();

            //    string JOB_TYPE = Reg.Rows[0]["JOB_TYPE"].ToString();
            //    string ASSIGN_USER = Reg.Rows[0]["ASSIGN_USER"].ToString();
            //    string SYSTEM_TYPE = Reg.Rows[0]["SYSTEM_TYPE"].ToString();
            //    string JOB_DESCRIPTION = Reg.Rows[0]["JOB_DESCRIPTION"].ToString();
            //    string JOB_HANDLED_BY = Reg.Rows[0]["JOB_HANDLED_BY"].ToString();
            //    string STATUS = Reg.Rows[0]["STATUS"].ToString();
            //    string company = "";

            //    if (Reg.Rows[0]["COMPANY"].ToString() == "LIFE")
            //    {
            //        company = "LIFE";
            //        RdBtnLife.Checked = true;
            //    }
            //    if (Reg.Rows[0]["COMPANY"].ToString() == "GENERAL")
            //    {
            //        RdBtnGen.Checked = true;
            //        company = "GENERAL";
            //    }

            //    if (JOB_TYPE != "")
            //    {
            //        ddl_dataBindings("");
            //        ddl_jobDescription_dataBind(JOB_TYPE, company);
            //    }
            //}
            //else
            //{
                ReqID = Request.QueryString["ReqID"];

                if (Request.QueryString["ReqID"] != null)
                {
                    ReqID = Request.QueryString["ReqID"];
                    DataTable Reg = Main.SelectJobFromRegister("CASE4", ReqID, "", "", System.DateTime.Now);
                    grdRequest.DataSource = Reg;
                    grdRequest.DataBind();

                    txtReqID.Text = Reg.Rows[0]["REQUEST_ID"].ToString();
                    txtRefNo2.Text = Reg.Rows[0]["REF_NO"].ToString();
                    txtReqBranch.Text = Reg.Rows[0]["BRANCH"].ToString();
                    txtReqDate.Text = Reg.Rows[0]["REQ_DATE1"].ToString();
                    txtRecDate.Text = Reg.Rows[0]["RECEVE_DATE1"].ToString();
                    txtRemarks.Text = Reg.Rows[0]["REMARKS_BRANCH"].ToString();
                    txtAssignUser.Text = Reg.Rows[0]["ASSIGN_USER"].ToString();
                    txtCompDate.Text = Reg.Rows[0]["COMP_DATE1"].ToString();
                    txtRemarks1.Text = Reg.Rows[0]["REMARKS_UNIT"].ToString();
                    txtTCSError.Text = Reg.Rows[0]["TCS_ERROR_NO"].ToString();

                    string JOB_TYPE = Reg.Rows[0]["JOB_TYPE"].ToString();
                    string ASSIGN_USER = Reg.Rows[0]["ASSIGN_USER"].ToString();
                    string SYSTEM_TYPE = Reg.Rows[0]["SYSTEM_TYPE"].ToString();
                    string JOB_DESCRIPTION = Reg.Rows[0]["JOB_DESCRIPTION"].ToString();
                    string JOB_HANDLED_BY = Reg.Rows[0]["JOB_HANDLED_BY"].ToString();
                    string STATUS = Reg.Rows[0]["STATUS"].ToString();
                    string company = "";

                    if (Reg.Rows[0]["COMPANY"].ToString() == "LIFE")
                    {
                        company = "LIFE";
                        RdBtnLife.Checked = true;
                    }
                    if (Reg.Rows[0]["COMPANY"].ToString() == "GENERAL")
                    {
                        RdBtnGen.Checked = true;
                        company = "GENERAL";
                    }

                    if (JOB_TYPE != "")
                    {
                        ddl_dataBindings("");
                        ddl_jobDescription_dataBind(JOB_TYPE, company);
                    }

                    DataTable dt = Main.SelectImages(txtReqID.Text, "BRANCH_IMAGE");
                    galleryDataList.DataSource = dt;
                    galleryDataList.DataBind();
                }
                else
                {
                    return;
                }
            
        }

        public void disable_controls()
        {
            //if ((manual_search == true) && (Session["searched_id"] != null))
            //{
            //    ReqID = Session["searched_id"].ToString();
            //}
            //else
            //{
            //    ReqID = Request.QueryString["ReqID"];
            //}

            ReqID = Request.QueryString["ReqID"];

            
            if(ReqID!="")
            {
                OracleConnection conn = new OracleConnection(myConn);
                conn.Open();

                OracleCommand cmd_get_details = conn.CreateCommand();
                cmd_get_details.CommandText = "SELECT R.STATUS, R.JOB_TYPE, R.COMPANY FROM WF_IT_REQUEST_REGISTER R WHERE R.REQUEST_ID = '"+ ReqID +"'";

                OracleDataReader odr_get_details = cmd_get_details.ExecuteReader();
                 
                string jobType = "";
                string jobStatus = "";

                while(odr_get_details.Read())
                {
                    jobType = odr_get_details["JOB_TYPE"].ToString();
                    jobStatus = odr_get_details["STATUS"].ToString();
                }
 

                if(jobStatus != "INTIMATE")
                {
                    CmbJobType.Enabled = false;
                    RdBtnLife.Enabled = false;
                    RdBtnGen.Enabled = false;
                    CmbJobDecsription.Enabled = false;
                }
                else
                {
                    CmbJobType.Enabled = true;
                    RdBtnLife.Enabled = true;
                    RdBtnGen.Enabled = true;
                    CmbJobDecsription.Enabled = true;

                    if (jobStatus == "INTIMATE")
                    {
                        CmbStatus.DataSource = null;
                        CmbStatus.DataBind();
                        //CmbStatus.Items.Clear();
                    }
                    

                    
                }

                JobHandleUsers_Validate();

                odr_get_details.Close();
                conn.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddl_dataBindings("");
                    GetData();
                    disable_controls();


                    //return;
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


                    ddlBranch.Items.Clear();
                    ddlBranch.DataSource = Main.GetBranchesRef();
                    ddlBranch.DataValueField = "CODE";
                    ddlBranch.DataTextField = "CODE";
                    ddlBranch.DataBind();
                    ddlBranch.Items.Insert(0, new RadComboBoxItem("--Select Branch--", ""));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void JobHandleUsers_Validate()
        {
            CmbReassgn.Enabled = false;

            if ((CmbStatus.SelectedItem == null) || (CmbStatus.SelectedIndex == 0))
            {
                return;
            }
            else if (CmbStatus.SelectedItem.Text == "PENDING-APPROVAL")
            {
                OracleConnection conn = new OracleConnection(myConn);
                conn.Open();

                OracleCommand cmd_get_jobHandleBy = conn.CreateCommand();
                cmd_get_jobHandleBy.CommandText = "SELECT TT.USER_NAME, TT.FULL_NAME FROM WF_IT_REF_HANDLED_USERS TT  WHERE TT.USER_TYPE = 'APPROVAL' ";
                OracleDataReader odr_get_jobHandleBy = cmd_get_jobHandleBy.ExecuteReader();

                DataTable dt_jobHandleBy = new DataTable();
                dt_jobHandleBy.Load(odr_get_jobHandleBy);

                CmbJobHandledBy.DataTextField = "FULL_NAME";
                CmbJobHandledBy.DataValueField = "USER_NAME";

                CmbJobHandledBy.DataSource = dt_jobHandleBy;
                CmbJobHandledBy.DataBind();

                CmbJobHandledBy.Enabled = true;
            }
            else
            {

                CmbJobHandledBy.Enabled = false;
                //CmbJobHandledBy.SelectedValue = "-1";
                //CmbReassgn.Enabled = true;


                CmbReassgn.Enabled = true;
                //CmbReassgn.Items.Clear();
                //CmbReassgn.DataSource = Main.SelectReferanceData("HELPDESK_USERS", "", "");
                //CmbReassgn.DataValueField = "USER_NAME";
                //CmbReassgn.DataTextField = "FULL_NAME";
                //CmbReassgn.DataBind();
                //CmbReassgn.Items.Insert(0, new RadComboBoxItem("--Select Reassign--", ""));



                OracleConnection conn = new OracleConnection(myConn);
                conn.Open();

                OracleCommand cmd_get_jobHandleBy = conn.CreateCommand();
                cmd_get_jobHandleBy.CommandText = "SELECT TT.USER_NAME, TT.FULL_NAME FROM WF_IT_REF_HANDLED_USERS TT";//  WHERE TT.USER_TYPE = 'APPROVAL' ";
                OracleDataReader odr_get_jobHandleBy = cmd_get_jobHandleBy.ExecuteReader();

                DataTable dt_jobHandleBy = new DataTable();
                dt_jobHandleBy.Load(odr_get_jobHandleBy);

                CmbJobHandledBy.DataTextField = "FULL_NAME";
                CmbJobHandledBy.DataValueField = "USER_NAME";

                CmbJobHandledBy.DataSource = dt_jobHandleBy;
                CmbJobHandledBy.DataBind();

                CmbJobHandledBy.Items.Insert(0, new RadComboBoxItem("--Please Select---", "-1"));


            }


        }


        private void ddl_dataBindings(string job_type)//Data Bindings For Dropdown Lists
        {
            ddl_status_dataBind("");
            ddl_jobDescription_dataBind("", "");

            string SQL_WHERE = "";

            if (job_type == "")
            {
                SQL_WHERE = "WHERE 1=1 and T.TYPE = 'JOB_TYPE'";
            }
            else
            {
                SQL_WHERE = "WHERE T.TYPE = 'JOB_TYPE' AND T.DESCRIPTION  ='" + job_type + "'";
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            //get job types==============================================================================================//

            OracleCommand cmd_get_job_types = conn.CreateCommand();
            cmd_get_job_types.CommandText = "SELECT T.ID, T.DESCRIPTION FROM WF_IT_REFERANCE_DATA T " + SQL_WHERE;
            OracleDataReader odr_get_job_types = cmd_get_job_types.ExecuteReader();

            DataTable dt_job_types = new DataTable();
            dt_job_types.Load(odr_get_job_types);

            CmbJobType.DataSource = null;
            CmbJobType.DataSource = dt_job_types;


            CmbJobType.DataTextField = "DESCRIPTION";
            CmbJobType.DataValueField = "DESCRIPTION";// "ID";            
            CmbJobType.DataBind();
            CmbJobType.Items.Insert(0, new RadComboBoxItem("--Please Select---", "-1"));

            odr_get_job_types.Close();

            string current_jobType = "";
            string current_jobHandleBy = "";
            string current_assignedUser = "";


            if (ReqID != "")
            {
                OracleCommand cmd_get_current_jobType = conn.CreateCommand();
                cmd_get_current_jobType.CommandText = "SELECT * FROM WF_IT_REQUEST_REGISTER R WHERE R.REQUEST_ID = '" + ReqID + "'";

                OracleDataReader odr_get_current_jobType = cmd_get_current_jobType.ExecuteReader();

                while (odr_get_current_jobType.Read())
                {
                    current_jobType = odr_get_current_jobType["JOB_TYPE"].ToString();
                    current_jobHandleBy = odr_get_current_jobType["JOB_HANDLED_BY"].ToString();
                    current_assignedUser = odr_get_current_jobType["ASSIGN_USER"].ToString();
                }


                odr_get_current_jobType.Close();
                if(current_jobType!="")
                {
                    CmbJobType.Items.FindItemByText(current_jobType).Selected = true;
                }
                
            }

            


            //get job handle by=========================================================================================//

            OracleCommand cmd_get_jobHandleBy = conn.CreateCommand();
            //Janaka 22-08-2017
            cmd_get_jobHandleBy.CommandText = "SELECT TT.USER_NAME, TT.FULL_NAME FROM WF_IT_REF_HANDLED_USERS TT ";// WHERE TT.USER_TYPE = 'APPROVAL' ";

            //02-10-2017
            //cmd_get_jobHandleBy.CommandText = "SELECT TT.USER_NAME, TT.FULL_NAME FROM WF_IT_REF_HANDLED_USERS TT WHERE TT.USER_TYPE = 'APPROVAL' ";

            
            OracleDataReader odr_get_jobHandleBy = cmd_get_jobHandleBy.ExecuteReader();

            DataTable dt_jobHandleBy = new DataTable();
            dt_jobHandleBy.Load(odr_get_jobHandleBy);

            CmbJobHandledBy.DataTextField = "FULL_NAME";
            CmbJobHandledBy.DataValueField = "USER_NAME";

            CmbJobHandledBy.DataSource = dt_jobHandleBy;
            CmbJobHandledBy.DataBind();

            CmbJobHandledBy.Items.Insert(0, new RadComboBoxItem("--Please Select--", "-1"));

            odr_get_jobHandleBy.Close();

            if(current_jobHandleBy == "")
            {
                //CmbJobHandledBy.Items.FindItemByText("--Please Select--").Selected = true;//Deshapriya
                CmbJobHandledBy.Items.FindItemByValue(Session["USER"].ToString()).Selected = true; //janaka - working 26-09-2017
            }
            else
            {
                if ((ReqID != "") && (current_jobHandleBy != ""))
                {
                    CmbJobHandledBy.Items.FindItemByValue(current_jobHandleBy).Selected = true;
                }
                else
                {
                    CmbJobHandledBy.Items.FindItemByValue(Session["USER"].ToString()).Selected = true;
                }
            }




            //get help desk users=====================================================================================//

            OracleCommand cmd_get_helpdeskUsers = conn.CreateCommand();
            cmd_get_helpdeskUsers.CommandText = "SELECT DD.USER_NAME, DD.FULL_NAME FROM WF_IT_REF_HELPDESK_USERS DD";

            OracleDataReader odr_get_helpdeskUsers = cmd_get_helpdeskUsers.ExecuteReader();
            DataTable dt_helpdeskUsers = new DataTable();

            dt_helpdeskUsers.Load(odr_get_helpdeskUsers);

            CmbReassgn.DataTextField = "FULL_NAME";
            CmbReassgn.DataValueField = "USER_NAME";

            CmbReassgn.DataSource = dt_helpdeskUsers;
            CmbReassgn.DataBind();
            CmbReassgn.Items.Insert(0, new RadComboBoxItem("--Please Select--", "0"));

            odr_get_helpdeskUsers.Close();

            if ((ReqID != "") && (current_assignedUser!=""))
            {
                CmbReassgn.Items.FindItemByValue(current_assignedUser).Selected = true;
            }

            //02/10/2017 - Janaka
            if (CmbReassgn.SelectedItem.Text.ToString() == "--Please Select--" )
            {                        
                CmbReassgn.Items.FindItemByValue(Session["USER"].ToString()).Selected = true; 
            }

        }

        public void ddl_jobDescription_dataBind(string job_type, string company)
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            //get job description=====================================================================================//
            if (job_type == "")
            {
                CmbJobDecsription.DataSource = null;
                CmbJobDecsription.DataBind();
                CmbJobDecsription.Items.Insert(0, new RadComboBoxItem("--Please Select--", "-1"));
                //CmbJobDecsription.Enabled = false;
            }
            else
            {
                OracleCommand cmd_get_jobDescription = conn.CreateCommand();
                cmd_get_jobDescription.CommandText = "SELECT JJ.ID,JJ.JOB_CAT_CODE, JJ.JOB_DESCRIPTION FROM WF_IT_REF_JOB_DESCRIPTION JJ " +
                                                        "WHERE JJ.JOB_TYPE = '" + job_type + "' AND (JJ.COMPANY ='" + company + "'OR JJ.COMPANY = 'LIFE_GEN') ORDER BY JJ.JOB_DESCRIPTION";

                OracleDataReader odr_getJobDescription = cmd_get_jobDescription.ExecuteReader();
                DataTable dt_jobDescriptions = new DataTable();
                dt_jobDescriptions.Load(odr_getJobDescription);

                CmbJobDecsription.DataTextField = "JOB_DESCRIPTION";
                CmbJobDecsription.DataValueField = "ID";

                CmbJobDecsription.DataSource = dt_jobDescriptions;
                CmbJobDecsription.DataBind();
                CmbJobDecsription.Items.Insert(0, new RadComboBoxItem("--Please Select--", "-1"));


                string current_jobDescription = "";

                if (ReqID != "")
                {
                    OracleCommand cmd_get_current_jobDescription = conn.CreateCommand();
                    cmd_get_current_jobDescription.CommandText = "SELECT * FROM WF_IT_REQUEST_REGISTER R WHERE R.REQUEST_ID = '" + ReqID + "'";

                    OracleDataReader odr_get_current_jobDescription = cmd_get_current_jobDescription.ExecuteReader();

                    while (odr_get_current_jobDescription.Read())
                    {
                        current_jobDescription = odr_get_current_jobDescription["JOB_DESCRIPTION"].ToString();
                    }


                    odr_get_current_jobDescription.Close();


                    if(current_jobDescription!="")
                    {
                        CmbJobDecsription.Items.FindItemByText(current_jobDescription).Selected = true;
                    }
                    
                }



            }

        }//JOB DESCRIPTION DATA BIND

        public void ddl_status_dataBind(string job_type)//STATUS DROPDOWNLIST DATA BIND
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            //get status==============================================================================================//

            OracleCommand cmd_get_status = conn.CreateCommand();
            cmd_get_status.CommandText = "SELECT D.ID, D.DESCRIPTION FROM WF_IT_REFERANCE_DATA D WHERE " +
                                            "D.TYPE = 'STATUS' AND D.DESCRIPTION <> 'APPROVE' AND D.DESCRIPTION <> 'PENDING-CLARIFICATION-COMPLETE' AND D.DESCRIPTION <> 'REOPEN'";

            OracleDataReader odr_get_status = cmd_get_status.ExecuteReader();

            DataTable dt_status = new DataTable();
            dt_status.Load(odr_get_status);

            int[] cr_array = new int[] { 18 };//19
            int[] er_array = new int[] { 5 }; //int[] er_array = new int[] { 4, 5 };
            //int[] sr_array = new int[] { 17, 18, 19 };

            if ((job_type == "CR") || (job_type == "SR"))
            {
                foreach (int ers in er_array)
                {
                    DataRow drow = dt_status.Select("ID ='" + ers + "'").First();
                    drow.Delete();
                }
            }

            else if (job_type == "ER")
            {
                foreach (int crs in cr_array)
                {
                    DataRow drow = dt_status.Select("ID ='" + crs + "'").First();
                    drow.Delete();
                }
            }
            else
            {
                //return;
            }

            //DataRow drow = dt_status.Select("ID = 31").First();
            //drow.Delete();

            //   Array department_id = dataCat_data.ToArray();

            OracleCommand cmd_get_current_status = conn.CreateCommand();


            string current_status = "";

            //-------------------------------REQ ID VALIDATION-------------------------//
            
            //if ((manual_search == true) && (Session["searched_id"] != null))
            //{
            //    ReqID = Session["searched_id"].ToString();
            //}
            //else
            //{
            //    ReqID = Request.QueryString["ReqID"];
            //}
            ReqID = Request.QueryString["ReqID"];
            //-------------------------------------------------------------------------//
           
            if(ReqID != "")
            {
                cmd_get_current_status.CommandText = "SELECT * FROM WF_IT_REQUEST_REGISTER R WHERE R.REQUEST_ID = '" + ReqID +"'";

                OracleDataReader odr_get_current_status = cmd_get_current_status.ExecuteReader();

                while(odr_get_current_status.Read())
                {
                    current_status = odr_get_current_status["STATUS"].ToString();
                }


               odr_get_current_status.Close();
             
               
            }
           

      



            CmbStatus.DataTextField = "DESCRIPTION";
            CmbStatus.DataValueField = "ID";

            CmbStatus.DataSource = dt_status;
            CmbStatus.DataBind();
            CmbStatus.Items.Insert(0, new RadComboBoxItem("--Please Select--", "-1"));

            if (current_status == "APPROVE")
            {
                CmbStatus.Items.Insert(1, new RadComboBoxItem("APPROVE", "-2"));
            }
            if (current_status == "PENDING-CLARIFICATION-COMPLETE")
            {
                CmbStatus.Items.Insert(2, new RadComboBoxItem("PENDING-CLARIFICATION-COMPLETE", "-3"));
            }
            if (current_status == "REOPEN")
            {
                CmbStatus.Items.Insert(3, new RadComboBoxItem("REOPEN", "-4"));
            }


            foreach (RadComboBoxItem item in CmbStatus.Items)
            {
                if ((item.Value == "-2") || (item.Value == "-3") || (item.Value == "-4"))
                {
                    item.Enabled = false;
                }

                if (item.Value == "31" || item.Value == "30")
                {
                    //item.Enabled = false;//.Attributes.Add("disabled", "true");
                    item.Visible = false;//.Attributes.Add("disabled", "true");
                }
            }

            
            odr_get_status.Close();
            conn.Close();
            

            if(ReqID != "")
            {
                CmbStatus.Items.FindItemByText(current_status).Selected = true;
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

                DataTable Reg = Main.SelectJobFromRegister("CASE5", txtJobNo.Text, txtRefNo.Text, ddlBranch.SelectedItem.Value, DtReqDate.SelectedDate.ToString() == "" ? null : DtReqDate.SelectedDate);
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

        public void DownloadBlob()
        {
            // int a = 7;
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            OracleCommand myCommand = new OracleCommand("SELECT * FROM wf_it_images WHERE ID = '" + txtReqID.Text + "'", conn);
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

        protected void galleryDataList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = galleryDataList.SelectedIndex;

            Label lbl = (Label)galleryDataList.Items[idx].FindControl("Label1");


            string URL = "Image.aspx?ImID=" + lbl.Text;
            sb.Append("<script>");
            sb.Append("window.open('" + URL + "', '','left=50, top=50, height=600, width= 900, status=no, resizable= yes, scrollbars= yes, toolbar= no,location= no, menubar= no');");
            sb.Append("</script>");
            Page.RegisterStartupScript("test", sb.ToString());



            //OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
            // OracleCommand myCommand = new OracleCommand("SELECT * FROM wf_it_images WHERE ID = '" + lbl.Text + "'", conn);
            // conn.Open();
            // OracleDataReader myReader = myCommand.ExecuteReader(System.Data.CommandBehavior.Default);
            // try
            // {
            //     while (myReader.Read())
            //     {

            //         OracleLob myLob = myReader.GetOracleLob(myReader.GetOrdinal("IMAGE"));
            //         if (!myLob.IsNull)
            //         {
            //             string FN = myReader.GetString(myReader.GetOrdinal("IMAGE_NAME"));


            //             //Use buffer to transfer data
            //             byte[] b = new byte[myLob.Length];
            //             //Read data from database
            //             myLob.Read(b, 0, (int)myLob.Length);


            //             Response.AddHeader("content-disposition", "attachment;filename=" + FN);
            //             Response.ContentType = "application/octectstream";
            //             Response.BinaryWrite(b);
            //             Response.End();
            //         }
            //     }
            // }
            // finally
            // {
            //     myReader.Close();
            //     conn.Close();
            // }



        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string JobDes = "";
                if(CmbStatus.SelectedIndex == -1)
                {
                    lblError.Text = "Please check the status.......";
                    return;
                }

                if (CmbJobDecsription.SelectedItem.Text == "--Select Job Description--")
                {
                    JobDes = "";
                }
                else
                {
                    JobDes = CmbJobDecsription.SelectedItem.Text;
                }

                string Reassign = "";
                if (CmbReassgn.Enabled == true)
                {
                    Reassign = CmbReassgn.SelectedItem.Value;

                }
                else
                {
                    Reassign = "";
                }

                string Company = "";
                if (RdBtnLife.Checked == true)
                {
                    Company = "LIFE";

                }
                if (RdBtnGen.Checked == true)
                {
                    Company = "GENERAL";

                }


                //janaka
                CommonCLS.CommonFunctions cmn = new CommonFunctions();
                Boolean isPossible = cmn.ValidatePossibleStatus(txtReqID.Text, CmbStatus.SelectedItem.Text);
                if (!isPossible)
                {
                    lblError.Text = "Please check the status.......";
                    return;
                }



                if ((CmbStatus.SelectedItem.Text == "TAKEN & ASSIGN") && (CmbReassgn.SelectedIndex == 0))
                {
                    lblError.Text = "Please Check Assign User.......!";
                    return;
                }






                //------Auto Generated event "TAKEN & ASSIGN"

                Boolean IsExists = cmn.ValidateStatusExists(txtReqID.Text, "TAKEN & ASSIGN");
                if (!IsExists)
                {
                    IsExists = cmn.ValidateStatusExists(txtReqID.Text, "TAKEN & ASSIGN");
                    if (!IsExists)
                    {
                        if (CmbStatus.SelectedItem.Text != "TAKEN & ASSIGN")
                        {
                            Main.UpdateRegister(txtReqID.Text, CmbJobType.SelectedItem.Value, "System Generated", JobDes, "TAKEN & ASSIGN", Session["USER"].ToString(),
                            Reassign, CmbJobHandledBy.SelectedItem.Value, txtTCSError.Text, Company);
                        }

                    }

                    Main.UpdateRegister(txtReqID.Text, CmbJobType.SelectedItem.Value, txtRemarks1.Text, JobDes, CmbStatus.SelectedItem.Text, Session["USER"].ToString(),
                    Reassign, CmbJobHandledBy.SelectedItem.Value, txtTCSError.Text, Company);

                }
                else
                {
                    Main.UpdateRegister(txtReqID.Text, CmbJobType.SelectedItem.Value, txtRemarks1.Text, JobDes, CmbStatus.SelectedItem.Text, Session["USER"].ToString(),
                    Reassign, CmbJobHandledBy.SelectedItem.Value, txtTCSError.Text, Company);
                }



                if (txtAssignUser.Text == "")
                {
                    //Main.UpdateAssignUser(ReqID, Session["USER"].ToString());

                    Main.UpdateAssignUser(ReqID, CmbReassgn.SelectedItem.Value);
                    
                }

                lblError.Text = "Update Successful..";

                if ((CmbJobHandledBy.SelectedItem.Value != "TCS") && (CmbStatus.SelectedItem.Text == "PENDING") && (JobDes != ""))
                {
                    PendingEmail();
                }

                if ((CmbStatus.SelectedItem.Text == "PENDING-APPROVAL") && (JobDes != ""))
                {
                    PendingApprovalEmail();
                }

                if ((CmbStatus.SelectedItem.Text == "CLOSE") && (JobDes != ""))
                {
                    CloseEmail();
                }

                if (CmbStatus.SelectedItem.Text == "RETURN")
                {
                    ReturnEmail();
                }
                if (CmbStatus.SelectedItem.Text == "PENDING-CLARIFICATION")
                {
                    PendingClarificationEmail();
                }

                DataTable dtEvents = Main.SelectJobFromRegister("CASE16", txtReqID.Text, "", "", System.DateTime.Now);
                GrdEvents.DataSource = dtEvents;
                GrdEvents.DataBind();

                if (Reassign != "")
                {
                    PendingEmail();
                }

                //--------------------------Deshapriya------------------------//

                Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx", false);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }



        }

        public void PendingApprovalEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtReqID.Text, "");
            string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();

            //----Handled User
            DataTable HandledUser = Main.SelectReferanceData("HANDLED_FOREMAIL", txtReqID.Text, "");
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
            message.Subject = Prifix + "Pending Approval" + "-" + txtReqID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>" + CmbJobDecsription.SelectedItem.Text + " </td>" +
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
                             "             <td colspan=2 class=txt_normal><strong>" + txtRemarks1.Text + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Job ID : " + txtReqID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Help Desk Assign User : " + txtAssignUser.Text + "</td>" +
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
                             "       <td class=inner_table_td_red>To view more details and approve: <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + txtReqID.Text + "> Click Here </a> </td> " +
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

        public void PendingEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable AssignUser = Main.SelectReferanceData("HELPDESK_FOREMAIL", txtReqID.Text, "");
            string AssinUserEmail = AssignUser.Rows[0]["EMAIL_ADDRESS"].ToString();

            //----Handled User
            DataTable HandledUser = Main.SelectReferanceData("HANDLED_FOREMAIL", txtReqID.Text, "");
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
            message.Subject = Prifix + "Help Desk Request" + "-" + txtReqID.Text;
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
                             "    <td align=left valign=middle  class=outer_table_td>" + CmbJobDecsription.SelectedItem.Text + " </td>" +
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
                             "             <td colspan=2 class=txt_normal><strong>" + txtRemarks1.Text + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Job ID : " + txtReqID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Help Desk Assign User : " + txtAssignUser.Text + "</td>" +
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + txtReqID.Text + "> Click Here </a> </td> " +
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
            DataTable RequestUser = Main.SelectReferanceData("REQUEST_USER_MAIL", txtReqID.Text, "");
            string RequestEmail = RequestUser.Rows[0]["REQUEST_USER_EMAIL"].ToString();



            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.Bcc.Add(FromAdd);
            message.Bcc.Add(RequestEmail);


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
            message.Subject = Prifix + "Job Returned " + "-" + txtReqID.Text;
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
                             "             <td colspan=2 class=txt_normal><strong>" + "Your request has been Retuned. Request ID : " + txtReqID.Text + ". Please use the Job Request Page for all future correspondence." + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Job ID : " + txtReqID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Help Desk Assign User : " + txtAssignUser.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Status : " + CmbStatus.SelectedItem.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Remark : " + txtRemarks1.Text + "</td>" +
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + txtReqID.Text + "> Click Here </a> </td> " +
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

        public void PendingClarificationEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable RequestUser = Main.SelectReferanceData("REQUEST_USER_MAIL", txtReqID.Text, "");
            string RequestEmail = RequestUser.Rows[0]["REQUEST_USER_EMAIL"].ToString();



            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.Bcc.Add(FromAdd);
            message.Bcc.Add(RequestEmail);


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
            message.Subject = Prifix + "Pending Clarification " + "-" + txtReqID.Text;
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
                             "             <td colspan=2 class=txt_normal><strong>" + "Your request has been called for Pending Clarification. Request ID : " + txtReqID.Text + ". Please use the Job Request Page for all future correspondence." + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Job ID : " + txtReqID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Help Desk Assign User : " + txtAssignUser.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Status : " + CmbStatus.SelectedItem.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Remark : " + txtRemarks1.Text + "</td>" +
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
                             "       <td class=inner_table_td_red>To view more details : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + txtReqID.Text + "> Click Here </a> </td> " +
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

        public void CloseEmail()
        {
            MailMessage message = new MailMessage();

            string FromAdd = "", FromName = "";
            FromAdd = Session["HnbaEmail"].ToString();
            FromName = Session["DisplayName"].ToString();

            MailAddress from = new MailAddress(FromAdd, FromName);

            //----Assigned User
            DataTable RequestUser = Main.SelectReferanceData("REQUEST_USER_MAIL", txtReqID.Text, "");
            string RequestEmail = RequestUser.Rows[0]["REQUEST_USER_EMAIL"].ToString();



            //-----Uncomment
            //message.Bcc.Add("janaka.indrajith@hnbassurance.com");
            //message.Bcc.Add("deshapriya.sooriya@hnbassurance.com");
            message.Bcc.Add(FromAdd);
            message.Bcc.Add(RequestEmail);


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
            message.Subject = Prifix + "Job Competed " + "-" + txtReqID.Text;
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
                             "             <td colspan=2 class=txt_normal><strong>" + "Your request has been completed. Include the Request ID : " + txtReqID.Text + " in the subject line for all future correspondence about this request. Please close the job after testing using the below link" + "</strong> " +
                             "       </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Job ID : " + txtReqID.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr >" +
                             "             <td class=inner_table_td_green>Help Desk Assign User : " + txtAssignUser.Text + "</td>" +
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Status : " + CmbStatus.SelectedItem.Text + "</td>" +//
                             "             <td class=inner_table_td_blue></td>" +
                             "           </tr>" +
                             "           <tr>" +
                             "             <td width=" + @"100%" + " class=inner_table_td_green>Remark : " + txtRemarks1.Text + "</td>" +//
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
                             "       <td class=inner_table_td_red>To close the Job or Reopen : <a href=" + " http://192.168.10.54:82/ITWorkflow-new/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ReqID=" + txtReqID.Text + "> Click Here </a> </td> " +
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
            DataTable Reg = Main.SelectJobFromRegister("CASE5", txtJobNo.Text, txtRefNo.Text, "HDO", DtReqDate.SelectedDate.ToString() == "" ? null : DtReqDate.SelectedDate);
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

                    txtReqID.Text = dd.Rows[0]["REQUEST_ID"].ToString();




                    //txtRefNo2.Text = dd.Rows[0]["REF_NO"].ToString();
                    //txtReqBranch.Text = dd.Rows[0]["BRANCH"].ToString();
                    //txtReqDate.Text = dd.Rows[0]["REQ_DATE1"].ToString();
                    //txtRecDate.Text = dd.Rows[0]["RECEVE_DATE1"].ToString();
                    //txtRemarks.Text = dd.Rows[0]["REMARKS_BRANCH"].ToString();
                    //txtAssignUser.Text = dd.Rows[0]["ASSIGN_USER"].ToString();
                    //txtCompDate.Text = dd.Rows[0]["COMP_DATE1"].ToString();
                    //txtRemarks1.Text = dd.Rows[0]["REMARKS_UNIT"].ToString();
                    //txtTCSError.Text = dd.Rows[0]["TCS_ERROR_NO"].ToString();

                    //Session["searched_id"] = dd.Rows[0]["REQUEST_ID"].ToString();
                    //manual_search = true;

                    //   DirectoryInfo myImageDir = new DirectoryInfo(MapPath("~/Uploads/"+ txtReqID.Text + "/"));
                    //if (dd.Rows[0]["COMPANY"].ToString() == "LIFE")
                    //{
                    //    RdBtnLife.Checked = true;
                    //}
                    //if (dd.Rows[0]["COMPANY"].ToString() == "GENERAL")
                    //{
                    //    RdBtnGen.Checked = true;
                    //}





                    //ddl_dataBindings("");
                    //GetData();
                    //disable_controls();


                    //DataTable dt = Main.SelectImages(txtReqID.Text, "BRANCH_IMAGE");
                    //galleryDataList.DataSource = dt;
                    //galleryDataList.DataBind();

                    //DataTable dt33 = Main.SelectImages(txtReqID.Text, "BRANCH_DOCS");
                    //DataList1.DataSource = dt33;
                    //DataList1.DataBind();


                    //Reopen Cases
                    //if (dd.Rows[0]["STATUS"].ToString() == "REOPEN")
                    //{
                    //    if ((CmbJobType.SelectedItem.Text == "SR") || (CmbJobType.SelectedItem.Text == "CR"))
                    //    {
                    //        CmbStatus.Items.Clear();
                    //        CmbStatus.Items.Insert(0, new RadComboBoxItem("PENDING-APPROVAL", "PENDING-APPROVAL"));
                    //        CmbStatus.Items.Insert(1, new RadComboBoxItem("RETURN", "RETURN"));
                    //        CmbStatus.Items.Insert(2, new RadComboBoxItem("PENDING-CLARIFICATION", "PENDING-CLARIFICATION"));
                    //        //    CmbStatus.Enabled = false;


                    //        CmbJobHandledBy.Items.Clear();
                    //        CmbJobHandledBy.DataSource = Main.SelectReferanceData("HANDLED_USERS_APPROVAL", "", "");
                    //        CmbJobHandledBy.DataValueField = "USER_NAME";
                    //        CmbJobHandledBy.DataTextField = "FULL_NAME";
                    //        CmbJobHandledBy.DataBind();
                    //        //CmbJobHandledBy.Enabled = false;
                    //    }


                    //}


                    //DataTable dtEvents = Main.SelectJobFromRegister("CASE16", txtReqID.Text, "", "", System.DateTime.Now);
                    //GrdEvents.DataSource = dtEvents;
                    //GrdEvents.DataBind();

                    ////if (txtAssignUser.Text == "")
                    ////{
                    ////    BtnUpdate.Enabled = false;
                    ////}

                    //if (txtAssignUser.Text != "")
                    //{
                    //    if (BtnUpdate.Enabled == true)
                    //    {
                    //        if ((dd.Rows[0]["STATUS"].ToString() == "APPROVE") && (dd.Rows[0]["JOB_TYPE"].ToString() == "CR"))
                    //        {
                    //            BtnUpdate.Enabled = false;
                    //            lblError.Text = "Intimate CR in Change Management..";
                    //        }

                    //    }
                    //}


                    //Session["searched_id"] = null;
                    //manual_search = false;
                    Response.Redirect("~/Views/ITWorkflow/HelpDeskView.aspx?ReqID=" + txtReqID.Text, false);

                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
                return;
            }
        }

        protected void CmbJobType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string company = "";

            if(RdBtnGen.Checked == true)
            {
                company = "GENERAL";
                RdBtnGen_CheckedChanged(null, null);
            }

            if(RdBtnLife.Checked == true)
            {
                company = "LIFE";
                RdBtnLife_CheckedChanged(null, null);
            }

            if(CmbJobType.SelectedIndex == 0)
            {
                return;
            }
            else
            {
                string selected_joBtype = CmbJobType.SelectedItem.Text;

                if (selected_joBtype == "ER")
                {
                    ddl_jobDescription_dataBind(selected_joBtype, company);
                    ddl_status_dataBind(selected_joBtype);
                }
                else if (selected_joBtype == "SR")
                {
                    ddl_jobDescription_dataBind(selected_joBtype, company);
                    ddl_status_dataBind(selected_joBtype);
                }
                else if (selected_joBtype == "")
                {
                    return;
                }
                else
                {
                    ddl_jobDescription_dataBind(selected_joBtype, company);
                    ddl_status_dataBind(selected_joBtype);
                }
            }
           


        }

        protected void CmbJobDecsription_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //try
            //{
            //    if (CmbJobDecsription.SelectedIndex != 0)
            //    {
            //        DataTable FilTxt = Main.SelectReferanceData("JOBCATCODE", CmbJobDecsription.SelectedItem.Value, "");
            //        txtCatCode.Text = FilTxt.Rows[0]["JOB_CAT_CODE"].ToString();
            //    }
            //    elseI
            //    {
            //        txtCatCode.Text = string.Empty;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblError.Text = ex.Message;
            //    lblError.Visible = true;
            //    return;
            //}

        }

        protected void CmbReassgn_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void CmbStatus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            CmbReassgn.Enabled = true;
            CmbReassgn.Items.Clear();
            CmbReassgn.DataSource = Main.SelectReferanceData("HELPDESK_USERS", "", "");
            CmbReassgn.DataValueField = "USER_NAME";
            CmbReassgn.DataTextField = "FULL_NAME";
            CmbReassgn.DataBind();
            CmbReassgn.Items.Insert(0, new RadComboBoxItem("--Select Reassign--", ""));

            //if (CmbStatus.SelectedItem.Text != "TAKEN & ASSIGN")
            //{
            //    //CmbReassgn.Items.Clear();
            //    //CmbReassgn.Items.Insert(0, new RadComboBoxItem("--Select Reassign--", ""));
            //    //CmbReassgn.Enabled = false;
            //}
            //else
            //{

            //}

            JobHandleUsers_Validate();//Deshapriya
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HelpDeskView.aspx");
        }

        protected void btnClear2_Click(object sender, EventArgs e)
        {
            //    var path = Server.MapPath("~/UploadDocuments/" + txtReqID.Text);
            //    var directory = new DirectoryInfo(path);
            //    //Response.Redirect("HelpDeskView.aspx");

            ////    string savePath = (Server.MapPath("~/UploadDocuments/" + txtReqID.Text ).ToString());
            //    foreach (FileInfo file in directory.GetFiles())
            //    {
            //        file.Delete();
            //    }
            //    directory.Delete();
            Response.Redirect("HelpDeskView.aspx");
        }

        protected void RdBtnLife_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtnLife.Checked == true)
            {
                RdBtnGen.Checked = false;

                if (CmbJobType.SelectedIndex != 0)
                {


                    CmbJobDecsription.Items.Clear();
                    CmbJobDecsription.DataSource = Main.SelectReferanceData("JOBDES_LIFE", CmbJobType.SelectedItem.Text, "");
                    CmbJobDecsription.DataValueField = "ID";
                    CmbJobDecsription.DataTextField = "JOB_DESCRIPTION";
                    CmbJobDecsription.DataBind();
                    CmbJobDecsription.Items.Insert(0, new RadComboBoxItem("--Select Job Description--", ""));
                }
            }

        }

        protected void RdBtnGen_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtnGen.Checked == true)
            {
                RdBtnLife.Checked = false;


                if (CmbJobType.SelectedIndex != 0)
                {

                    CmbJobDecsription.Items.Clear();
                    CmbJobDecsription.DataSource = Main.SelectReferanceData("JOBDES_GEN", CmbJobType.SelectedItem.Text, "");
                    CmbJobDecsription.DataValueField = "ID";
                    CmbJobDecsription.DataTextField = "JOB_DESCRIPTION";
                    CmbJobDecsription.DataBind();
                    CmbJobDecsription.Items.Insert(0, new RadComboBoxItem("--Select Job Description--", ""));
                }
            }
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