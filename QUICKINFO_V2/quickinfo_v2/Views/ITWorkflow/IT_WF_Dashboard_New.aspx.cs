﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;
using quickinfo_v2.CommonCLS;
using System.Web.Configuration;
using System.DirectoryServices;
using quickinfo_v2.Connectivity;
using System.Transactions;
using System.Drawing;


namespace quickinfo_v2.Views.ITWorkflow
{
    public partial class IT_WF_Dashboard_New : System.Web.UI.Page
    {
        string myConn = ConfigurationManager.ConnectionStrings["ORAWF"].ToString();
        string not_taken_jobs, er_pending_clarification, er_taken_and_assign, er_reopen, er_clarification_complete, er_returnd, er_close_by_it,
            sr_pending_clarification, sr_clarification_complete, sr_taken_and_assign, sr_approved, sr_approval_requested, sr_reopend, sr_complete, sr_returned, sr_close_by_it,
            cr_pending_clarification, cr_clarification_complete, cr_taken_and_assign, cr_approved, cr_approval_requested, cr_reopend, cr_complete, cr_returned, cr_close_by_it,
            all_jobs, taken_by_it, not_taken_by_it, non_it_pending_clarification, non_it_pending_approval, return_by_it, non_it_close_confirm, approve_usr_pendings, approve_usr_pendings_common;

        string ActiveUser = "";//AD
        string temp_ActiveUser = "";//Selected User
        string Company = "";
        string UserRoleCode = "";
        string userType = "";
        string userDepartment = "";
        string err_code = "";
        bool gridView_select_command = false;
        bool Action_To_Take = false;
        bool Approve_Another_UsersJob = false;
        bool Authentication_fail = true;


        bool SR_Clicked = false;
        bool ER_Clicked = false;
        bool CR_Clicked = false;

        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    getADUser();
                    get_IT_users();
                    setActiveUserType(ActiveUser);
                    get_reassign_users();
                    getActiveUser_Department(ActiveUser);
                    function_execute_user_type_wise(ActiveUser);


                    if ((SR_Clicked == false) && (ER_Clicked == false) && (CR_Clicked == false))
                    {
                        lb_ER_Base_Click(null, null);
                        //div_er_base.CssClass = "circleBase_properties_selected";
                        div_er_base.Attributes["class"] = "circleBase circleBase_properties_selected";
                    }
                    //Label1.Text = ActiveUser;
                    if (Request.QueryString["ecode"] != null)
                    {
                        err_code = Request.QueryString["ecode"];
                        error_msg_handing(err_code);
                    }
                    else
                    {
                        error_msg_visibility();
                    }

                    if(Authentication_fail == true)
                    {
                        err_msg_div.Attributes["class"] = "alert alert-danger";//warning danger success
                        err_msg_div.Visible = true;
                        lbl_err_msg.Text = "Current user doesn't have required permission to continue the precess...!";
                    }


                }
            }
            catch (Exception ex)
            {
                err_msg_div.Attributes["class"] = "alert alert-danger";//warning danger success
                err_msg_div.Visible = true;
                lbl_err_msg.Text = ex.ToString();
            }
        }

        //------------------------------------------------------------------Common Data Bindings-------------------------------------------------------------------------//

        public void getADUser()//Get AD Loging Details
        {
            CommonFunctions cmnFunctions = new CommonFunctions();

            ActiveUser = Context.User.Identity.Name;//Get AD Name

            if (ActiveUser.Contains("HNBGI"))
            {
                ActiveUser = cmnFunctions.Right(ActiveUser, (ActiveUser.Length) - 6);
                Company = "GENERAL";
            }
            else
            {
                ActiveUser = cmnFunctions.Right(ActiveUser, (ActiveUser.Length) - 5);
                Company = "LIFE";
            }

            Session["WF_User"] = ActiveUser;
            Session["Temp_ActiveUser"] = ActiveUser;
            temp_ActiveUser = Session["Temp_ActiveUser"].ToString();
        }

        public void UpdateADDetails()
        {
            CommonFunctions clsCom = new CommonFunctions();
            String LDAP = clsCom.getADIPAddress("LIFE");

            System.DirectoryServices.DirectoryEntry dirEntry;
            System.DirectoryServices.DirectorySearcher dirSearcher;
            dirEntry = new System.DirectoryServices.DirectoryEntry("");

            dirSearcher = new System.DirectoryServices.DirectorySearcher("LIFE");

            string[] names = { "tharangani.fernando" };

//            string[] names = { 
//                                 "lahiru.pinnaduwa",
//"tharangani.fernando",
//"shashinika.perera",
//"limeshika.fernando",
//"sahan.511",
//"thilini.ishanka",
//"neranjan.desilva",
//"gimhara.gunathilake",
//"swarnamali.perera",
//"suresh.mahawaththage",
//"pushpakumari.perera",
//"lahiru.samaraweera",
//"venuri.ekanayake",
//"gangani.upeksha",
//"kasun.gunawardena",
//"hansani.amanda",
//"nadeesha.sandamali",
//"elka.baby",
//"sellathurai.pradheep",
//"saumya.tharanga",
//"subhashini.0033",
//"isuri.priyadarshani",
//"hasintha.himali",
//"lahiru.samaraweera",
//"resha.amali",
//"oshan.marasinghe",
//"gehan.dodangoda",
//"dilani.ranasinghe",
//"ayodhya.perera",
//"ruvini.desoysa",
//"ann.rajendran",
//"tuan.ossan",
//"gangani.upeksha",
//"shyanima.madhurangi",
//"chamath.deshan",
//"harith.perera",
//"gayan.udugampala",
//"roshan.kularathne",
//"shithila.555",
//"yoginda.wijesuriya",
//"rushani.fernando",
//"thameera.walpita",
//"swarnamali.perera"


// };

            String SQL = "";

            foreach (string i in names)
            {
                System.Console.Write("{0} ", i);

                if (i == "")
                {
                    continue;
                }

                dirSearcher.Filter = "(&(objectClass=user)(SAMAccountName=" + i + "))";
                SearchResult sr = dirSearcher.FindOne();

                if (sr == null)
                {
                    continue;
                }

                System.DirectoryServices.DirectoryEntry de = sr.GetDirectoryEntry();

                userDepartment = de.Properties["Department"].Value.ToString();

                SQL = "UPDATE wf_it_request_register R SET R.REQUEST_USER_DEPT = '" + userDepartment + "' WHERE R.REQUEST_USER = '" + i + "' AND R.REQUEST_USER_DEPT IS NULL";

                OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ORAWF"].ToString());
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = SQL;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();


            }
        }

        private void getActiveUser_Department(string usr)//Get Acetive User's Department
        {
            //30-10-2017 - JANAKA TO UPDATE USER DEPARTMENT BY GETTING DATA FROM ACTIVE DIRECTLY
            //UpdateADDetails();

            CommonFunctions clsCom = new CommonFunctions();
            String LDAP = clsCom.getADIPAddress(Company);

            System.DirectoryServices.DirectoryEntry dirEntry;
            System.DirectoryServices.DirectorySearcher dirSearcher;
            dirEntry = new System.DirectoryServices.DirectoryEntry(LDAP);

            dirSearcher = new System.DirectoryServices.DirectorySearcher(Company);
            dirSearcher.Filter = "(&(objectClass=user)(SAMAccountName=" + usr + "))";


            SearchResult sr = dirSearcher.FindOne();

            System.DirectoryServices.DirectoryEntry de = sr.GetDirectoryEntry();

            if (sr == null)
            {
                return;
            }
            else
            {
                userDepartment = de.Properties["Department"].Value.ToString();
                Session["User_Department"] = userDepartment;
            }



            string SQL = "UPDATE wf_it_request_register R SET R.REQUEST_USER_DEPT = '" + userDepartment + "' WHERE R.REQUEST_USER = '" + usr + "' AND R.REQUEST_USER_DEPT IS NULL";
            OracleConnection conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ORAWF"].ToString());
            conn.Open();
            OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = SQL;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();




        }

        public void setActiveUserType(string usr)//SET Active User Type (IT /NON IT/ APPROVAL)
        {
            if (ActiveUser == "")
            {
                ActiveUser = Session["WF_User"].ToString();
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();
            try
            {
                int IT_UserRoleCode_Count = 0;
                int Non_IT_UserRoleCode_Count = 0;
                int Approval_UserRoleCode_Count = 0;

                OracleCommand cmd_get_roleID = conn.CreateCommand();
                cmd_get_roleID.CommandText = "SELECT DISTINCT(R.USER_ROLE_NAME) FROM WF_ADMIN_USER_ROLES R INNER JOIN WF_ADMIN_USERS U ON U.USER_ROLE_CODE = R.USER_ROLE_CODE " +
                                                "WHERE U.USER_CODE = '" + usr + "'";

                OracleDataReader odr_get_role_id = cmd_get_roleID.ExecuteReader();
                while (odr_get_role_id.Read())
                {
                    UserRoleCode = odr_get_role_id[0].ToString();
                }


                //----------------------------IT Users---------------------------//
                string active_user_roles_IT = WebConfigurationManager.AppSettings["IT_UserRoleCode"].ToString();
                string[] tokens_IT = active_user_roles_IT.Split(',');

                foreach (string t in tokens_IT)
                {
                    if (UserRoleCode == t)
                    {
                        IT_UserRoleCode_Count++;
                    }
                }

                //---------------------------NON_IT_Users---------------------------------//

                string active_user_roles_Non_IT = WebConfigurationManager.AppSettings["Non_IT_UserRoleCode"].ToString();
                string[] tokens_NON_IT = active_user_roles_Non_IT.Split(',');

                foreach (string t in tokens_NON_IT)
                {
                    if (UserRoleCode == t)
                    {
                        Non_IT_UserRoleCode_Count++;
                    }
                }

                //----------------------------Approval_Users-------------------------------------------//


                string active_user_roles_Approval = WebConfigurationManager.AppSettings["Approval_UserRoleCode"].ToString();
                string[] tokens_Approval = active_user_roles_Approval.Split(',');

                foreach (string t in tokens_Approval)
                {
                    if (UserRoleCode == t)
                    {
                        Approval_UserRoleCode_Count++;
                    }
                }

                if ((IT_UserRoleCode_Count != 0) || (IT_UserRoleCode_Count > 1))
                {
                    userType = "IT_User";
                }
                if ((Non_IT_UserRoleCode_Count != 0) || (Non_IT_UserRoleCode_Count > 1))
                {
                    userType = "NON_IT_User";
                }
                if ((Approval_UserRoleCode_Count != 0) || (Approval_UserRoleCode_Count > 1))
                {
                    userType = "Approval_User";
                }
                if (Approval_UserRoleCode_Count == 0)
                {
                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public void get_IT_users()//Get IT Users
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {               
                OracleCommand cmd_get_it_users = conn.CreateCommand();
                cmd_get_it_users.CommandText = "select distinct(u.user_name) from wf_it_ref_users_systemwise u, wf_admin_users usr where u.user_name = usr.user_code and usr.status = 1";

                OracleDataReader odr_get_it_users = cmd_get_it_users.ExecuteReader();

                DataTable dt_get_it_users = new DataTable();
                dt_get_it_users.Load(odr_get_it_users);

                ddl_filter_by_users.DataTextField = "user_name";
                ddl_filter_by_users.DataValueField = "user_name";
                ddl_filter_by_users.DataSource = dt_get_it_users;

                ddl_filter_by_users.DataBind();
                //ddl_filter_by_users.Items.Insert(0, new ListItem("--Dashboard View As--", "-1"));

                ddl_filter_by_users.ClearSelection();


                if (ddl_filter_by_users.Items.FindByValue(ActiveUser)  != null)
                {
                    ddl_filter_by_users.Items.FindByValue(ActiveUser).Selected = true;
                }


                

                odr_get_it_users.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }


        }

        public void get_reassign_users()//Data Bind For Re Assign Users Dropdown List (IT Users And Approval Users)
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                string sql_where = "";

                if (userType == "IT_User")
                {
                    sql_where = "HELP_DESK','IN_HOUSE_DEV";

                    OracleCommand cmd_get_it_users = conn.CreateCommand();
                    cmd_get_it_users.CommandText = "select t.user_name, t.full_name from wf_it_ref_handled_users t where t.user_type in ('" + sql_where + "')";

                    OracleDataReader odr_get_it_users = cmd_get_it_users.ExecuteReader();

                    DataTable dt_get_it_users = new DataTable();
                    dt_get_it_users.Load(odr_get_it_users);

                    ddl_reassignUsers.DataTextField = "full_name";
                    ddl_reassignUsers.DataValueField = "user_name";
                    ddl_reassignUsers.DataSource = dt_get_it_users;

                    ddl_reassignUsers.DataBind();
                    ddl_reassignUsers.Items.Insert(0, new ListItem("--Re Assign User--", "-1"));
                }
                else if (userType == "Approval_User")
                {
                    sql_where = "APPROVAL";

                    OracleCommand cmd_get_it_users = conn.CreateCommand();
                    cmd_get_it_users.CommandText = "select t.user_name, t.full_name from wf_it_ref_handled_users t where t.user_type in ('" + sql_where + "')";

                    OracleDataReader odr_get_it_users = cmd_get_it_users.ExecuteReader();

                    DataTable dt_get_it_users = new DataTable();
                    dt_get_it_users.Load(odr_get_it_users);

                    ddl_reassignUsers.DataTextField = "full_name";
                    ddl_reassignUsers.DataValueField = "user_name";
                    ddl_reassignUsers.DataSource = dt_get_it_users;

                    ddl_reassignUsers.DataBind();
                    ddl_reassignUsers.Items.Insert(0, new ListItem("--Re Assign User--", "-1"));
                }
                else
                {
                    ddl_reassignUsers.Enabled = false;
                    return;
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }

        public void function_execute_user_type_wise(string usr)//Main Function Exection Flow
        {
            if (userType == "")
            {
                UpdatePanel_Normal_user.Visible = false;
                UpdatePanel_IT_user.Visible = false;
                UpdatePanel_IT_usr_hdr.Visible = false;
                Authentication_fail = true;
            }
            else if (userType == "IT_User")
            {
                Authentication_fail = false;
                UpdatePanel_Normal_user.Visible = false;
                UpdatePanel_IT_user.Visible = true;
                get_not_takenJobs_count();
                get_not_takenJobs_systemwise_count(usr);
                get_er_summary(usr);
                get_sr_summary(usr);
                get_cr_summary(usr);
                get_current_handling_status(usr);
                get_it_division_summary();
            }
            else if (userType == "NON_IT_User")
            {
                Authentication_fail = false;
                UpdatePanel_Normal_user.Visible = true;
                UpdatePanel_IT_user.Visible = false;
                UpdatePanel_IT_usr_hdr.Visible = false;
                get_normal_user_summary(usr);
            }
            else if (userType == "Approval_User")
            {
                Authentication_fail = false;
                UpdatePanel_Normal_user.Visible = true;
                UpdatePanel_IT_user.Visible = false;
                UpdatePanel_IT_usr_hdr.Visible = false;
                get_normal_user_summary(usr);
                get_approval_user_summary(usr);
            }
            else
            {
                Authentication_fail = true;
                UpdatePanel_Normal_user.Visible = false;
                UpdatePanel_IT_user.Visible = false;
                UpdatePanel_IT_usr_hdr.Visible = false;
                //Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ecode=e_07", false);
                return;
            }
        }


        //---------------------------------------------------------------Dashboard Get Data Functions For IT And Non IT Users--------------------------------------------//

        public void get_not_takenJobs_count()//Not Taken Jobs
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();
            try
            {
                OracleCommand cmd_notTakenJobs = conn.CreateCommand();
                //JANAKA-30-10-2017
                //cmd_notTakenJobs.CommandText = "SELECT COUNT(*) AS TOTAL_NOT_TAKEN_JOBS FROM (SELECT RR.* FROM WF_IT_REQUEST_REGISTER RR WHERE RR.STATUS = 'INTIMATE')";

                cmd_notTakenJobs.CommandText = "SELECT count(T.REQUEST_ID) as TOTAL_NOT_TAKEN_JOBS  FROM WF_IT_REQUEST_REGISTER T  WHERE (T.STATUS = 'TAKEN & ASSIGN' OR T.STATUS = 'INTIMATE') AND T.ASSIGN_USER IS NULL  ORDER BY  T.REQUEST_DATE DESC";


                OracleDataReader odr_notTakenJobs = cmd_notTakenJobs.ExecuteReader();
                while (odr_notTakenJobs.Read())
                {
                    not_taken_jobs = odr_notTakenJobs["TOTAL_NOT_TAKEN_JOBS"].ToString();
                }
                lbl_count_notTaken_jobs.Text = not_taken_jobs;
                odr_notTakenJobs.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void get_not_takenJobs_systemwise_count(string usr)//Not Taken Jobs (System Wise)
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_usr_systems = conn.CreateCommand();

                cmd_usr_systems.CommandText = "SELECT TT.USER_NAME, TT.SYSTEM FROM WF_IT_REF_USERS_SYSTEMWISE TT WHERE TT.USER_NAME = '" + usr + "'";

                DataTable dt_systems = new DataTable();//Assigned systems for active user 

                OracleDataReader odr_usr_systems = cmd_usr_systems.ExecuteReader();
                dt_systems.Load(odr_usr_systems);

                int req_count_temp = 0;
                int final_req_count = 0;

                if (dt_systems.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt_systems.Rows)
                    {
                        string sys_name = dr["SYSTEM"].ToString();

                        OracleCommand cmd_jobs_sys_wise = conn.CreateCommand();
                        
                        //31-10-2017 - janaka
                        //cmd_jobs_sys_wise.CommandText = "SELECT COUNT(*) AS REQ_COUNT FROM WF_IT_REQUEST_REGISTER RR WHERE RR.STATUS = 'INTIMATE' AND RR.SYSTEM_TYPE = '" + sys_name + "'";
                        cmd_jobs_sys_wise.CommandText = " SELECT COUNT(T.REQUEST_ID) AS REQ_COUNT  FROM WF_IT_REQUEST_REGISTER T  ,wf_it_ref_users_systemwise U " +
                                                      " WHERE T.STATUS = 'INTIMATE' " +
                                                      " AND T.ASSIGN_USER IS NULL " +
                                                      //" AND T.System_Type=U.SYSTEM " +
                                                      " AND T.System_Type='" + sys_name + "' " +
                                                      " AND U.USER_NAME= '" + usr + "' " +
                                                      " ORDER BY  T.REQUEST_DATE DESC ";


                        OracleDataReader odr_jobs_sys_wise = cmd_jobs_sys_wise.ExecuteReader();

                        while (odr_jobs_sys_wise.Read())
                        {
                            req_count_temp = int.Parse(odr_jobs_sys_wise["REQ_COUNT"].ToString());
                        }

                        final_req_count = final_req_count + req_count_temp;
                        req_count_temp = 0;
                    }

                    lbl_jobs_systemwise_count.Text = final_req_count.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public void get_er_summary(string usr)//er summary
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_get_er_summary = conn.CreateCommand();
                cmd_get_er_summary.CommandText = "SELECT " +
                                                    "COUNT (*)AS TOTAL_COUNT, " +
                                                    "COUNT (CASE when K.STATUS ='PENDING-CLARIFICATION' then K.REQUEST_ID ELSE null END)AS PENDING_CLARIFICATION, " +
                                                    "COUNT (CASE when K.STATUS ='REOPEN' then K.REQUEST_ID ELSE null END)AS REOPEN, " +
                                                    "COUNT (CASE when K.STATUS ='TAKEN & ASSIGN' then K.REQUEST_ID ELSE null END)AS TAKEN_AND_ASSIGN, " +
                                                    "COUNT (CASE when K.STATUS ='PENDING-CLARIFICATION-COMPLETE' then K.REQUEST_ID ELSE null END)AS CLARIFICATION_COMPLETE, " +
                                                    "COUNT (CASE when K.STATUS ='CLOSE' then K.REQUEST_ID ELSE null END)AS CLOSE_BY_IT, " +
                                                    "COUNT (CASE when K.STATUS ='RETURN' then K.REQUEST_ID ELSE null END)AS RETURND " +
                                                    "FROM( " +
                                                    "SELECT * FROM WF_IT_REQUEST_REGISTER TT " +
                                                    "WHERE TT.STATUS <> 'INTIMATE' AND TT.STATUS <> 'CLOSE-CONFIRM' " +
                                                    "AND TT.JOB_TYPE = 'ER' AND TT.ASSIGN_USER = '" + usr + "')K ";

                OracleDataReader odr_get_er_summary = cmd_get_er_summary.ExecuteReader();

                while (odr_get_er_summary.Read())
                {
                    er_pending_clarification = odr_get_er_summary["PENDING_CLARIFICATION"].ToString();
                    er_reopen = odr_get_er_summary["REOPEN"].ToString();
                    er_taken_and_assign = odr_get_er_summary["TAKEN_AND_ASSIGN"].ToString();
                    er_clarification_complete = odr_get_er_summary["CLARIFICATION_COMPLETE"].ToString();
                    er_returnd = odr_get_er_summary["RETURND"].ToString();
                    er_close_by_it = odr_get_er_summary["CLOSE_BY_IT"].ToString();
                }

                lbl_er_pending_clarification.Text = er_pending_clarification;
                lbl_er_reopen.Text = er_reopen;
                lbl_er_taken_and_assign.Text = er_taken_and_assign;
                lbl_er_clarification_complete.Text = er_clarification_complete;
                lbl_er_closed_by_it.Text = er_close_by_it;
                lbl_er_returned.Text = er_returnd;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void get_sr_summary(string usr)//sr summary
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_get_sr_summary = conn.CreateCommand();
                cmd_get_sr_summary.CommandText = "SELECT " +
                                                    "COUNT (CASE when K.STATUS ='PENDING-CLARIFICATION' then K.REQUEST_ID ELSE null END)AS PENDING_CLARIFICATION, " +
                                                    "COUNT (CASE when K.STATUS ='PENDING-CLARIFICATION-COMPLETE' then K.REQUEST_ID ELSE null END)AS CLARIFICATION_COMPLETE, " +
                                                    "COUNT (CASE when K.STATUS ='PENDING-APPROVAL' then K.REQUEST_ID ELSE null END)AS APPROVAL_REQUESTED, " +
                                                    "COUNT (CASE when K.STATUS ='APPROVE' then K.REQUEST_ID ELSE null END)AS APPROVED, " +
                                                    "COUNT (CASE when K.STATUS ='REOPEN' then K.REQUEST_ID ELSE null END)AS REOPEN, " +
                                                    "COUNT (CASE when K.STATUS ='COMPLETE' then K.REQUEST_ID ELSE null END)AS COMPLETE, " +
                                                    "COUNT (CASE when K.STATUS ='TAKEN & ASSIGN' then K.REQUEST_ID ELSE null END)AS TAKEN_AND_ASSIGN, " +
                                                    "COUNT (CASE when K.STATUS ='CLOSE' then K.REQUEST_ID ELSE null END)AS CLOSE_BY_IT, " +
                                                    "COUNT (CASE when K.STATUS ='RETURN' then K.REQUEST_ID ELSE null END)AS RETURND " +
                                                    "FROM( " +
                                                    "SELECT * FROM WF_IT_REQUEST_REGISTER TT  " +
                                                    "WHERE TT.STATUS <> 'INTIMATE' AND TT.STATUS <> 'CLOSE-CONFIRM'  " +
                                                    "AND TT.JOB_TYPE = 'SR' AND TT.ASSIGN_USER = '" + usr + "')K ";

                OracleDataReader odr_get_sr_summary = cmd_get_sr_summary.ExecuteReader();

                while (odr_get_sr_summary.Read())
                {
                    sr_pending_clarification = odr_get_sr_summary["PENDING_CLARIFICATION"].ToString();
                    sr_approval_requested = odr_get_sr_summary["APPROVAL_REQUESTED"].ToString();
                    sr_approved = odr_get_sr_summary["APPROVED"].ToString();
                    sr_reopend = odr_get_sr_summary["REOPEN"].ToString();
                    sr_complete = odr_get_sr_summary["COMPLETE"].ToString();
                    sr_taken_and_assign = odr_get_sr_summary["TAKEN_AND_ASSIGN"].ToString();
                    sr_clarification_complete = odr_get_sr_summary["CLARIFICATION_COMPLETE"].ToString();
                    sr_close_by_it = odr_get_sr_summary["CLOSE_BY_IT"].ToString();
                    sr_returned = odr_get_sr_summary["RETURND"].ToString();
                }

                lbl_sr_pending_clarification.Text = sr_pending_clarification;
                lbl_sr_clarification_complete.Text = sr_clarification_complete;
                lbl_sr_taken_and_assign.Text = sr_taken_and_assign;
                lbl_sr_approval_requested.Text = sr_approval_requested;
                lbl_sr_approved.Text = sr_approved;
                lbl_sr_reopend.Text = sr_reopend;
                lbl_sr_complete.Text = sr_complete;
                lbl_sr_closed_by_it.Text = sr_close_by_it;
                lbl_sr_returned.Text = sr_returned;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void get_cr_summary(string usr)//cr summary
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_get_cr_summary = conn.CreateCommand();
                cmd_get_cr_summary.CommandText = "SELECT " +
                                                    "COUNT (CASE when K.STATUS ='PENDING-CLARIFICATION' then K.REQUEST_ID ELSE null END)AS PENDING_CLARIFICATION, " +
                                                    "COUNT (CASE when K.STATUS ='PENDING-CLARIFICATION-COMPLETE' then K.REQUEST_ID ELSE null END)AS CLARIFICATION_COMPLETE, " +
                                                    "COUNT (CASE when K.STATUS ='TAKEN & ASSIGN' then K.REQUEST_ID ELSE null END)AS TAKEN_AND_ASSIGN, " +
                                                    "COUNT (CASE when K.STATUS ='PENDING-APPROVAL' then K.REQUEST_ID ELSE null END)AS APPROVAL_REQUESTED, " +
                                                    "COUNT (CASE when K.STATUS ='APPROVE' then K.REQUEST_ID ELSE null END)AS APPROVED, " +
                                                    "COUNT (CASE when K.STATUS ='REOPEN' then K.REQUEST_ID ELSE null END)AS REOPEN, " +
                                                    "COUNT (CASE when K.STATUS ='RETURN' then K.REQUEST_ID ELSE null END)AS RETURND, " +
                                                    "COUNT (CASE when K.STATUS ='CLOSE' then K.REQUEST_ID ELSE null END)AS CLOSE_BY_IT, " +
                                                    "COUNT (CASE when K.STATUS ='COMPLETE' then K.REQUEST_ID ELSE null END)AS COMPLETE " +
                                                    "FROM( " +
                                                    "SELECT * FROM WF_IT_REQUEST_REGISTER TT  " +
                                                    "WHERE TT.STATUS <> 'INTIMATE' AND TT.STATUS <> 'CLOSE-CONFIRM'  " +
                                                    "AND TT.JOB_TYPE = 'CR' AND TT.ASSIGN_USER = '" + usr + "')K ";

                OracleDataReader odr_get_cr_summary = cmd_get_cr_summary.ExecuteReader();

                while (odr_get_cr_summary.Read())
                {
                    cr_pending_clarification = odr_get_cr_summary["PENDING_CLARIFICATION"].ToString();
                    cr_approval_requested = odr_get_cr_summary["APPROVAL_REQUESTED"].ToString();
                    cr_approved = odr_get_cr_summary["APPROVED"].ToString();
                    cr_reopend = odr_get_cr_summary["REOPEN"].ToString();
                    cr_complete = odr_get_cr_summary["COMPLETE"].ToString();
                    cr_taken_and_assign = odr_get_cr_summary["TAKEN_AND_ASSIGN"].ToString();
                    cr_clarification_complete = odr_get_cr_summary["CLARIFICATION_COMPLETE"].ToString();
                    cr_returned = odr_get_cr_summary["RETURND"].ToString();
                    cr_close_by_it = odr_get_cr_summary["CLOSE_BY_IT"].ToString();
                }

                lbl_cr_pending_clarification.Text = cr_pending_clarification;
                lbl_cr_taken_and_assign.Text = cr_taken_and_assign;
                lbl_cr_approval_requested.Text = cr_approval_requested;
                lbl_cr_approved.Text = cr_approved;
                lbl_cr_reopend.Text = cr_reopend;
                //lbl_cr_complete.Text = cr_complete;
                lbl_cr_clarification_complete.Text = cr_clarification_complete;
                lbl_cr_returned.Text = cr_returned;
                lbl_cr_closed_by_it.Text = cr_close_by_it;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public void get_normal_user_summary(string usr)//Normal User (NON IT User) Summary
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_get_normal_user_summary = conn.CreateCommand();
                cmd_get_normal_user_summary.CommandText = "SELECT " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'CLOSE-CONFIRM' THEN K.REQUEST_ID ELSE NULL END) AS ALL_JOBS, " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS <> 'CLOSE-CONFIRM' THEN K.REQUEST_ID ELSE NULL END) AS TAKEN_BY_IT, " +
                                                            "COUNT (CASE WHEN K.STATUS = 'INTIMATE' THEN K.REQUEST_ID ELSE NULL END) AS NOT_TAKEN_BY_IT, " +
                                                            "COUNT (CASE WHEN K.STATUS = 'PENDING-CLARIFICATION' THEN K.REQUEST_ID ELSE NULL END) AS PENDING_CLARIFICATION, " +
                                                            "COUNT (CASE WHEN K.STATUS = 'PENDING-APPROVAL' THEN K.REQUEST_ID ELSE NULL END) AS PENDING_APPROVAL, " +
                                                            "COUNT (CASE WHEN K.STATUS = 'RETURN' THEN K.REQUEST_ID ELSE NULL END) AS RETURN, " +
                                                            "COUNT (CASE WHEN K.STATUS = 'CLOSE' THEN K.REQUEST_ID ELSE NULL END) AS CLOSE_BY_IT " +
                                                            "FROM " +
                                                            "(SELECT * FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + usr + "')K";
                OracleDataReader odr_get_normal_user_summary = cmd_get_normal_user_summary.ExecuteReader();

                while (odr_get_normal_user_summary.Read())
                {
                    all_jobs = odr_get_normal_user_summary["ALL_JOBS"].ToString();
                    taken_by_it = odr_get_normal_user_summary["TAKEN_BY_IT"].ToString();
                    not_taken_by_it = odr_get_normal_user_summary["NOT_TAKEN_BY_IT"].ToString();
                    non_it_pending_clarification = odr_get_normal_user_summary["PENDING_CLARIFICATION"].ToString();
                    non_it_pending_approval = odr_get_normal_user_summary["PENDING_APPROVAL"].ToString();
                    non_it_close_confirm = odr_get_normal_user_summary["CLOSE_BY_IT"].ToString();
                    return_by_it = odr_get_normal_user_summary["RETURN"].ToString();
                }


                lbl_all_jobs.Text = all_jobs;
                lbl_taken_by_it.Text = taken_by_it;
                lbl_not_taken_by_it.Text = not_taken_by_it;
                lbl_pending_clarification.Text = non_it_pending_clarification;
                lbl_pending_approval.Text = non_it_pending_approval;
                lbl_close_confirmed.Text = non_it_close_confirm;
                lbl_return_by_it.Text = return_by_it;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        public void get_approval_user_summary(string usr)//Approval User Summary
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_get_approve_user_summary = conn.CreateCommand();
                cmd_get_approve_user_summary.CommandText = "SELECT " +
                                                            "COUNT (CASE WHEN K.STATUS = 'PENDING-APPROVAL' THEN K.REQUEST_ID ELSE NULL END) AS PENDING_APPROVAL " +
                                                            "FROM " +
                                                            "(SELECT * FROM WF_IT_REQUEST_REGISTER TT WHERE TT.JOB_HANDLED_BY = '" + usr + "')K";

                OracleDataReader odr_get_approve_user_summary = cmd_get_approve_user_summary.ExecuteReader();

                while (odr_get_approve_user_summary.Read())
                {
                    approve_usr_pendings = odr_get_approve_user_summary["PENDING_APPROVAL"].ToString();
                }

                lbl_to_approve.Text = approve_usr_pendings;

                //----------------ALL PENDING APPROVALS-----------------//

                OracleCommand cmd_get_common_approve_summary = conn.CreateCommand();
                cmd_get_common_approve_summary.CommandText = "SELECT COUNT (CASE WHEN K.STATUS = 'PENDING-APPROVAL' THEN K.REQUEST_ID ELSE NULL END) AS ALL_PENDING_APPROVAL " +
                                                            "FROM (SELECT * FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER_DEPT = '" + userDepartment + "')K";

                OracleDataReader odr_get_common_approve_summary = cmd_get_common_approve_summary.ExecuteReader();
                while (odr_get_common_approve_summary.Read())
                {
                    approve_usr_pendings_common = odr_get_common_approve_summary["ALL_PENDING_APPROVAL"].ToString();
                }

                lbl_to_approve_common.Text = approve_usr_pendings_common;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void get_current_handling_status(string usr)//Current Handling Jobs Status For Specific User
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_get_current_handling_status = conn.CreateCommand();
                cmd_get_current_handling_status.CommandText = "SELECT COUNT (case when t.status <> 'intimate' and t.status <> 'CLOSE-CONFIRM' and t.status <> 'RETURN' then t.request_id ELSE null END)HANDLING_JOBS, " +
                                                                "COUNT (case when t.status <> 'intimate' and t.status = 'CLOSE' then t.request_id ELSE null END) CLOSED_FROM_IT, " +
                                                                "COUNT (case when t.status = 'CLOSE-CONFIRM' then t.request_id ELSE null END)COMPLETED_JOBS " +
                                                                "FROM wf_it_request_register t where t.assign_user = '" + usr + "'";

                OracleDataReader odr_get_current_handling_status = cmd_get_current_handling_status.ExecuteReader();

                int HANDLING_JOBS = 0;
                int CLOSED_FROM_IT = 0;
                int COMPLETED_JOBS = 0;

                while (odr_get_current_handling_status.Read())
                {
                    HANDLING_JOBS = int.Parse(odr_get_current_handling_status["HANDLING_JOBS"].ToString());
                    CLOSED_FROM_IT = int.Parse(odr_get_current_handling_status["CLOSED_FROM_IT"].ToString());
                    COMPLETED_JOBS = int.Parse(odr_get_current_handling_status["COMPLETED_JOBS"].ToString());
                }

                lbl_HANDLING_JOBS.Text = HANDLING_JOBS.ToString();
                lbl_CLOSED_FROM_IT.Text = CLOSED_FROM_IT.ToString();
                lbl_COMPLETED_JOBS.Text = COMPLETED_JOBS.ToString();

                odr_get_current_handling_status.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        public void get_common_jobs_for_approval_user()//Common Jobs For Approval Users
        {
            if (userDepartment == "")
            {
                userDepartment = Session["User_Department"].ToString();//Session["User_Department"]
            }


            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            if (Session["WF_User"] == null)
            {
                return;
            }
            else
            {
                OracleCommand cmd_get_common_jobs_for_approval_user = conn.CreateCommand();

                cmd_get_common_jobs_for_approval_user.CommandText = "SELECT TT.REQUEST_ID, TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                                                    "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                                                    "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.STATUS = 'PENDING-APPROVAL' AND TT.REQUEST_USER_DEPT = '" + userDepartment + "'";


                //cmd_get_common_jobs_for_approval_user.CommandText = "SELECT * FROM (SELECT TT.REQUEST_ID, TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, TT.JOB_HANDLED_BY, " +
                //                                                    "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                //                                                    "FROM WF_IT_REQUEST_REGISTER TT " +
                //                                                    "WHERE TT.STATUS = 'PENDING-APPROVAL' AND TT.REQUEST_USER_DEPT = 'IT') K WHERE K.ASSIGN_USER <> '" + Session["WF_User"].ToString() + "'";
                OracleDataReader odr_get_common_jobs_for_approval_user = cmd_get_common_jobs_for_approval_user.ExecuteReader();
                DataTable dt_get_common_jobs_for_approval_user = new DataTable();

                dt_get_common_jobs_for_approval_user.Load(odr_get_common_jobs_for_approval_user);
                grd_non_it_user_jobs.DataSource = dt_get_common_jobs_for_approval_user;
                grd_non_it_user_jobs.DataBind();
                //grd_approval_common.DataSource = dt_get_common_jobs_for_approval_user;
                //grd_approval_common.DataBind();


                foreach (GridViewRow row in grd_non_it_user_jobs.Rows)
                {
                    row.Cells[1].Enabled = false;
                    row.Cells[2].Enabled = false;
                }
            }



        }

        public void get_it_division_summary()//IT Division Summary For All Users
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_get_it_division_summary = conn.CreateCommand();
                cmd_get_it_division_summary.CommandText = "SELECT " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS <> 'CLOSE-CONFIRM' AND K.STATUS <> 'RETURN' THEN K.REQUEST_ID ELSE NULL END)AS PROCESSING_JOBS_AT_IT, " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS <> 'CLOSE-CONFIRM' AND K.JOB_TYPE = 'ER' THEN K.REQUEST_ID ELSE NULL END)AS PROCESSING_ER, " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS <> 'CLOSE-CONFIRM' AND K.JOB_TYPE = 'SR' THEN K.REQUEST_ID ELSE NULL END)AS PROCESSING_SR, " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS <> 'CLOSE-CONFIRM' AND K.JOB_TYPE = 'CR' THEN K.REQUEST_ID ELSE NULL END)AS PROCESSING_CR, " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS = 'PENDING-APPROVAL' THEN K.REQUEST_ID ELSE NULL END)AS APPROVAL_REQUESTED_JOBS, " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS = 'PENDING-CLARIFICATION' THEN K.REQUEST_ID ELSE NULL END)AS CLARIFICATION_REQUESTED_JOBS, " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS = 'CLOSE' THEN K.REQUEST_ID ELSE NULL END)AS CLOSE_JOBS_IT, " +
                                                            "COUNT (CASE WHEN K.STATUS <> 'INTIMATE' AND K.STATUS = 'CLOSE-CONFIRM' THEN K.REQUEST_ID ELSE NULL END)AS CLOSE_CONFIRM_JOBS " +
                                                            "FROM WF_IT_REQUEST_REGISTER K ";

                OracleDataReader odr_get_it_division_summary = cmd_get_it_division_summary.ExecuteReader();

                int tot_processing_jobs = 0;
                int tot_er = 0;
                int tot_sr = 0;
                int tot_cr = 0;
                int tot_clarification_req = 0;
                int tot_approval_req = 0;
                int tot_closed_jobs_it = 0;
                int tot_closed_confirm_jobs = 0;


                while (odr_get_it_division_summary.Read())
                {
                    tot_processing_jobs = int.Parse(odr_get_it_division_summary["PROCESSING_JOBS_AT_IT"].ToString());
                    tot_er = int.Parse(odr_get_it_division_summary["PROCESSING_ER"].ToString());
                    tot_sr = int.Parse(odr_get_it_division_summary["PROCESSING_SR"].ToString());
                    tot_cr = int.Parse(odr_get_it_division_summary["PROCESSING_CR"].ToString());
                    tot_clarification_req = int.Parse(odr_get_it_division_summary["CLARIFICATION_REQUESTED_JOBS"].ToString());
                    tot_approval_req = int.Parse(odr_get_it_division_summary["APPROVAL_REQUESTED_JOBS"].ToString());
                    tot_closed_jobs_it = int.Parse(odr_get_it_division_summary["CLOSE_JOBS_IT"].ToString());
                    tot_closed_confirm_jobs = int.Parse(odr_get_it_division_summary["CLOSE_CONFIRM_JOBS"].ToString());
                }

                

                lbl_tot_processing_jobs.Text = tot_processing_jobs.ToString();
                lbl_tot_er.Text = tot_er.ToString();
                lbl_tot_sr.Text = tot_sr.ToString();
                lbl_tot_cr.Text = tot_cr.ToString();
                lbl_tot_clarification_req.Text = tot_clarification_req.ToString();
                lbl_tot_approval_req.Text = tot_approval_req.ToString();
                lbl_tot_closed_jobs_it.Text = tot_closed_jobs_it.ToString();
                lbl_tot_closed_confirm.Text = tot_closed_confirm_jobs.ToString();

                odr_get_it_division_summary.Close();
                conn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void ddl_filter_by_users_SelectedIndexChanged(object sender, EventArgs e)//View Another Users Dashboard
        {
            //ActiveUser = ddl_filter_by_users.SelectedItem.Text;
            //Session["Temp_ActiveUser"] = ActiveUser;

            temp_ActiveUser = ddl_filter_by_users.Text;
            Session["Temp_ActiveUser"] = temp_ActiveUser;

            setActiveUserType(temp_ActiveUser);
            get_reassign_users();
            getActiveUser_Department(temp_ActiveUser);
            function_execute_user_type_wise(temp_ActiveUser);

            if ((SR_Clicked == false) && (ER_Clicked == false) && (CR_Clicked == false))
            {
                //janaka
                //lb_ER_Base_Click(null, null);


                if (Session["ER_SR_CR"].ToString() == "ER")
                {
                    lb_ER_Base_Click(sender, e);
                }
                if (Session["ER_SR_CR"].ToString() == "SR")
                {
                    lb_SR_Base_Click(sender, e);
                }
                if (Session["ER_SR_CR"].ToString() == "CR")
                {
                    lb_CR_Base_Click(sender, e);
                }



                //div_er_base.CssClass = "circleBase_properties_selected";
                div_er_base.Attributes["class"] = "circleBase circleBase_properties_selected";
            }

            error_msg_visibility();


        }                       



        //--------------------------------------------------------------Button Click Events IT Users---------------------------------------------------------------------//

        protected void lb_notTakenJobs_All_Click(object sender, EventArgs e)
        {
            error_msg_visibility();
            Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_all_pendingJobs&PnlB_ID=pnlBdy_all_pendingJobs", false);
        }

        protected void lb_notTakenJobs_systemWise_Click(object sender, EventArgs e)
        {
            error_msg_visibility();
            Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_systemWisePendingJobs&PnlB_ID=pnlBdy_systemWisePendingJobs", false);
        }

        //IT Division Summary Button Click Events        

        protected void lb_tot_processing_jobs_Click(object sender, EventArgs e)//Total Processing Jobs
        {
            error_msg_visibility();

            if (lbl_tot_processing_jobs.Text == "0")
            {
                return;
            }


            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();
            try
            {


                OracleCommand cmd_total_processing_jobs = conn.CreateCommand();
                cmd_total_processing_jobs.CommandText = "SELECT RR.REQUEST_ID, RR.SYSTEM_TYPE, RR.REQUEST_USER,RR.ASSIGN_USER, RR.JOB_TYPE, RR.JOB_DESCRIPTION " +
                                                        "FROM WF_IT_REQUEST_REGISTER RR WHERE RR.STATUS <> 'INTIMATE' AND RR.STATUS <> 'CLOSE-CONFIRM' AND RR.STATUS <> 'RETURN' " +
                                                        "ORDER BY RR.ASSIGN_USER";

                DataTable dt_total_processing_jobs = new DataTable();
                OracleDataReader odr_total_processing_jobs = cmd_total_processing_jobs.ExecuteReader();

                dt_total_processing_jobs.Load(odr_total_processing_jobs);

                grd_it_summary.DataSource = dt_total_processing_jobs;
                grd_it_summary.DataBind();

                odr_total_processing_jobs.Close();
                conn.Close();


                lbl_summary_topic.Text = "Total Processing Jobs";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-4", "$('#sample-modal-dialog-4').modal();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        protected void lb_tot_closed_jobs_Click(object sender, EventArgs e)//Total Closed Jobs
        {
            error_msg_visibility();

            if (lbl_tot_closed_jobs_it.Text == "0")
            {
                return;
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_total_closed_by_it = conn.CreateCommand();
                cmd_total_closed_by_it.CommandText = "SELECT RR.REQUEST_ID, RR.SYSTEM_TYPE, RR.REQUEST_USER,RR.ASSIGN_USER, RR.JOB_TYPE, RR.JOB_DESCRIPTION " +
                                                        "FROM WF_IT_REQUEST_REGISTER RR WHERE RR.STATUS = 'CLOSE' " +
                                                        "ORDER BY RR.ASSIGN_USER";

                DataTable dt_total_closed_by_it = new DataTable();
                OracleDataReader odr_total_closed_by_it = cmd_total_closed_by_it.ExecuteReader();

                dt_total_closed_by_it.Load(odr_total_closed_by_it);

                grd_it_summary.DataSource = dt_total_closed_by_it;
                grd_it_summary.DataBind();

                odr_total_closed_by_it.Close();
                conn.Close();


                lbl_summary_topic.Text = "Closed Confirmation Pending";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-4", "$('#sample-modal-dialog-4').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        protected void lb_tot_closed_confirmed_jobs_Click(object sender, EventArgs e)//Total Closed Confirmed Jobs
        {
            error_msg_visibility();

            if (lbl_tot_closed_confirm.Text == "0")
            {
                return;
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleCommand cmd_total_close_confirm = conn.CreateCommand();
                cmd_total_close_confirm.CommandText = "SELECT RR.REQUEST_ID, RR.SYSTEM_TYPE, RR.REQUEST_USER,RR.ASSIGN_USER, RR.JOB_TYPE, RR.JOB_DESCRIPTION " +
                                                        "FROM WF_IT_REQUEST_REGISTER RR WHERE RR.STATUS = 'CLOSE-CONFIRM' " +
                                                        "ORDER BY RR.ASSIGN_USER";

                DataTable dt_total_close_confirm = new DataTable();
                OracleDataReader odr_total_close_confirm = cmd_total_close_confirm.ExecuteReader();

                dt_total_close_confirm.Load(odr_total_close_confirm);

                grd_it_summary.DataSource = dt_total_close_confirm;
                grd_it_summary.DataBind();

                odr_total_close_confirm.Close();
                conn.Close();


                lbl_summary_topic.Text = "Closed Jobs";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-4", "$('#sample-modal-dialog-4').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        //-----------------------------------------------------------ER--------------------------------------------------------------------------//

        protected void lb_ER_Base_Click(object sender, EventArgs e)//ER Base Button Click Event
        {
            error_msg_visibility();

            ER_Clicked = true;
            SR_Clicked = false;
            CR_Clicked = false;

            Session["ER_SR_CR"] = "ER";

            if (ER_Clicked == true)
            {
                div_er_base.Attributes["class"] = "circleBase circleBase_properties_selected";
                div_sr_base.Attributes["class"] = "circleBase circleBase_properties";
                div_cr_base.Attributes["class"] = "circleBase circleBase_properties";

                //SR
                lb_taken_and_assign_SR_IT.Visible = false;
                lb_clarification_requested_jobs_SR_IT.Visible = false;
                lb_clarification_complete_jobs_SR_IT.Visible = false;
                lb_approval_requested_jobs_SR_IT.Visible = false;
                lb_approved_jobs_SR_IT.Visible = false;
                lb_re_opened_jobs_SR_IT.Visible = false;
                lb_closed_by_it_jobs_SR_IT.Visible = false;
                lb_sr_returned_jobs_SR_IT.Visible = false;

                //CR
                lb_taken_and_assign_CR_IT.Visible = false;
                lb_clarification_requested_jobs_CR_IT.Visible = false;
                lb_clarification_complete_jobs_CR_IT.Visible = false;
                lb_closed_by_it_jobs_CR_IT.Visible = false;
                lb_approval_requested_jobs_CR_IT.Visible = false;
                lb_approved_jobs_CR_IT.Visible = false;
                lb_re_opened_jobs_CR_IT.Visible = false;
                lb_cr_returned_jobs_CR_IT.Visible = false;

                //ER
                lb_taken_and_assign_ER_IT.Visible = true;
                lb_clarification_requested_ER_IT.Visible = true;
                lb_clarification_completed_jobs_ER_IT.Visible = true;
                lb_reopened_jobs.Visible = true;
                lb_closed_by_it_jobs_ER_IT.Visible = true;
                lb_er_returned_jobs_ER_IT.Visible = true;
                lb_approval_requested_jobs_ER_IT.Visible = true;
                lb_approved_jobs_ER_IT.Visible = true;


            }
        }

        protected void lb_taken_and_assign_ER_IT_Click(object sender, EventArgs e)//ER Taken And Assigned
        {
            error_msg_visibility();

            if (lbl_er_taken_and_assign.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_job_type_wise_er&PnlB_ID=pnlBdy_job_type_wise_er", false);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE3", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();

                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);
                lbl_popup_topic.Text = "Taken And Assigned Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }

        }

        protected void lb_clarification_requested_ER_IT_Click(object sender, EventArgs e)//ER Clarification Requested
        {
            error_msg_visibility();

            if (lbl_er_pending_clarification.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_clarification_req_ER&PnlB_ID=pnlBdy_clarification_req_ER", false);
                DataTable RegUser = Main.SelectJobFromRegister("CASE20", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                //this.SetFocus(lbtn_setFocus);
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Clarification Requested Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE20", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                //this.SetFocus(lbtn_setFocus);

                Session["Temp_DataTable"] = dt_new;
                lbl_popup_topic.Text = "Clarification Requested Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }

        }

        protected void lb_clarification_completed_jobs_ER_IT_Click(object sender, EventArgs e)//ER Clarification Complete
        {
            error_msg_visibility();

            if (lbl_er_clarification_complete.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_pendingClarificationPendingJobs_ER&PnlB_ID=pnlBdy_pendingClarificationPendingJobs_ER", false);
            }
            else
            {
                DataTable RegUserPendingClarification = Main.SelectJobFromRegister("CASE13", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);
                DataView dv = new DataView(RegUserPendingClarification);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                //this.SetFocus(lbtn_setFocus);
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Clarification Completed Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }

        }

        protected void lb_reopened_jobs_Click(object sender, EventArgs e)//ER RE-OPENED JOBS
        {
            error_msg_visibility();

            if (lbl_er_reopen.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_reopendJobs&PnlB_ID=pnlBdy_reopendJobs", false);
            }
            else
            {
                DataTable RegUserReopend = Main.SelectJobFromRegister("CASE14", Session["USER"].ToString(), "", "", System.DateTime.Now);
                DataView dv = new DataView(RegUserReopend);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                //this.SetFocus(lbtn_setFocus);
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Re Opened Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }

        }

        protected void lb_er_returned_jobs_ER_IT_Click(object sender, EventArgs e)//ER Returned Jobs
        {
            error_msg_visibility();

            if (lbl_er_returned.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE30", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Closed Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE30", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Clarification Requested Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_closed_by_it_jobs_ER_IT_Click(object sender, EventArgs e)//ER Closed Jobs
        {
            error_msg_visibility();

            if (lbl_er_closed_by_it.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE29", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Closed Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE29", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Clarification Requested Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }


        //-----------------------------------------------------------SR-------------------------------------------------------------------------//

        protected void lb_SR_Base_Click(object sender, EventArgs e)//SR Base Button Click Event
        {
            //this.Master.FindControl("MainContent").FindControl("mpe2.Show();");//mpe2.Show();
            error_msg_visibility();

            ER_Clicked = false;
            SR_Clicked = true;
            CR_Clicked = false;

            Session["ER_SR_CR"] = "SR";

            if (SR_Clicked == true)
            {
                div_sr_base.Attributes["class"] = "circleBase circleBase_properties_selected";
                div_er_base.Attributes["class"] = "circleBase circleBase_properties";
                div_cr_base.Attributes["class"] = "circleBase circleBase_properties";

                //SR
                lb_taken_and_assign_SR_IT.Visible = true;
                lb_clarification_requested_jobs_SR_IT.Visible = true;
                lb_clarification_complete_jobs_SR_IT.Visible = true;
                lb_approval_requested_jobs_SR_IT.Visible = true;
                lb_approved_jobs_SR_IT.Visible = true;
                lb_re_opened_jobs_SR_IT.Visible = true;
                lb_closed_by_it_jobs_SR_IT.Visible = true;
                lb_sr_returned_jobs_SR_IT.Visible = true;

                //ER
                lb_taken_and_assign_ER_IT.Visible = false;
                lb_clarification_requested_ER_IT.Visible = false;
                lb_clarification_completed_jobs_ER_IT.Visible = false;
                lb_reopened_jobs.Visible = false;
                lb_closed_by_it_jobs_ER_IT.Visible = false;
                lb_er_returned_jobs_ER_IT.Visible = false;
                lb_approval_requested_jobs_ER_IT.Visible = false;
                lb_approved_jobs_ER_IT.Visible = false;

                //CR
                lb_taken_and_assign_CR_IT.Visible = false;
                lb_clarification_requested_jobs_CR_IT.Visible = false;
                lb_clarification_complete_jobs_CR_IT.Visible = false;
                lb_closed_by_it_jobs_CR_IT.Visible = false;
                lb_approval_requested_jobs_CR_IT.Visible = false;
                lb_approved_jobs_CR_IT.Visible = false;
                lb_re_opened_jobs_CR_IT.Visible = false;
                lb_cr_returned_jobs_CR_IT.Visible = false;
            }

        }

        protected void lb_taken_and_assign_SR_IT_Click(object sender, EventArgs e)//SR Taken And Assign
        {
            error_msg_visibility();

            if (lbl_sr_taken_and_assign.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_job_type_wise_sr&PnlB_ID=pnlBdy_job_type_wise_sr", false);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE3", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Taken And Assigned Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_clarification_requested_jobs_SR_IT_Click(object sender, EventArgs e)//SR Clarification Requested
        {
            error_msg_visibility();

            if (lbl_sr_pending_clarification.Text == "0")
            {
                return;
            }
            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_reopendJobs&PnlB_ID=pnlBdy_reopendJobs", false);

                DataTable RegUser = Main.SelectJobFromRegister("CASE22", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Clarification Requested Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE22", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Clarification Requested Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_clarification_complete_jobs_SR_IT_Click(object sender, EventArgs e)//SR Clarification Completed
        {
            error_msg_visibility();

            if (lbl_sr_clarification_complete.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_pendingClarificationPendingJobs&PnlB_ID=pnlBdy_pendingClarificationPendingJobs", false);
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_pendingClarificationPendingJobs_SR&PnlB_ID=pnlBdy_pendingClarificationPendingJobs_SR", false);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE23", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Clarification Completed Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);

                //DataTable RegUserPendingClarification = Main.SelectJobFromRegister("CASE13", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);
                //DataView dv = new DataView(RegUserPendingClarification);
                //DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                //grd_it_user_jobs.DataSource = dt_new;
                //grd_it_user_jobs.DataBind();
            }


        }

        protected void lb_approval_requested_jobs_SR_IT_Click(object sender, EventArgs e)//SR Approval Requested
        {
            error_msg_visibility();

            if (lbl_sr_approval_requested.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_pendingClarificationPendingJobs&PnlB_ID=pnlBdy_pendingClarificationPendingJobs", false);
                DataTable RegUser = Main.SelectJobFromRegister("CASE24", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Approval Requested Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE24", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Approval Requested Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_reopendJobs&PnlB_ID=pnlBdy_reopendJobs", false);
        }

        protected void lb_approved_jobs_SR_IT_Click(object sender, EventArgs e)//SR Approved Jobs
        {
            error_msg_visibility();

            if (lbl_sr_approved.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_approvedJobsSR&PnlB_ID=pnlBdy_approvedJobsSR", false);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE25", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Approved Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }

        }

        protected void lb_re_opened_jobs_SR_IT_Click(object sender, EventArgs e)//SR Reopened Jobs
        {
            error_msg_visibility();

            Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_reopendJobs&PnlB_ID=pnlBdy_reopendJobs", false);
        }

        protected void lb_complete_jobs_SR_IT_Click(object sender, EventArgs e)//SR Complete Jobs
        {
            error_msg_visibility();
            //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_reopendJobs&PnlB_ID=pnlBdy_reopendJobs", false);
        }

        protected void lb_sr_returned_jobs_SR_IT_Click(object sender, EventArgs e)//SR Returned Jobs
        {
            error_msg_visibility();

            if (lbl_sr_returned.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE32", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Returned Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE32", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Returned Jobs For SR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_closed_by_it_jobs_SR_IT_Click(object sender, EventArgs e)//SR Closed Jobs
        {
            error_msg_visibility();

            if (lbl_sr_closed_by_it.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE31", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Closed Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE31", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Closed Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }


        //-----------------------------------------------------------CR-------------------------------------------------------------------------//

        protected void lb_CR_Base_Click(object sender, EventArgs e)//CR Base Button Click Event
        {
            error_msg_visibility();

            ER_Clicked = false;
            SR_Clicked = false;
            CR_Clicked = true;

            Session["ER_SR_CR"] = "CR";

            if (CR_Clicked == true)
            {
                div_sr_base.Attributes["class"] = "circleBase circleBase_properties";
                div_er_base.Attributes["class"] = "circleBase circleBase_properties";
                div_cr_base.Attributes["class"] = "circleBase circleBase_properties_selected";

                //SR
                lb_taken_and_assign_SR_IT.Visible = false;
                lb_clarification_requested_jobs_SR_IT.Visible = false;
                lb_clarification_complete_jobs_SR_IT.Visible = false;
                lb_approval_requested_jobs_SR_IT.Visible = false;
                lb_approved_jobs_SR_IT.Visible = false;
                lb_re_opened_jobs_SR_IT.Visible = false;
                lb_closed_by_it_jobs_SR_IT.Visible = false;
                lb_sr_returned_jobs_SR_IT.Visible = false;

                //ER
                lb_taken_and_assign_ER_IT.Visible = false;
                lb_clarification_requested_ER_IT.Visible = false;
                lb_clarification_completed_jobs_ER_IT.Visible = false;
                lb_reopened_jobs.Visible = false;
                lb_closed_by_it_jobs_ER_IT.Visible = false;
                lb_er_returned_jobs_ER_IT.Visible = false;
                lb_approval_requested_jobs_ER_IT.Visible = false;
                lb_approved_jobs_ER_IT.Visible = false;

                //CR
                lb_taken_and_assign_CR_IT.Visible = true;
                lb_clarification_requested_jobs_CR_IT.Visible = true;
                lb_clarification_complete_jobs_CR_IT.Visible = true;
                lb_closed_by_it_jobs_CR_IT.Visible = true;
                lb_approval_requested_jobs_CR_IT.Visible = true;
                lb_approved_jobs_CR_IT.Visible = true;
                lb_re_opened_jobs_CR_IT.Visible = true;
                lb_cr_returned_jobs_CR_IT.Visible = true;

            }
        }

        protected void lb_taken_and_assign_CR_IT_Click(object sender, EventArgs e)//CR Taken And Assign
        {
            error_msg_visibility();

            if (lbl_cr_taken_and_assign.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_job_type_wise_cr&PnlB_ID=pnlBdy_job_type_wise_cr", false);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE3", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Taken And Assigned Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_clarification_requested_jobs_CR_IT_Click(object sender, EventArgs e)//CR Clarification Requested
        {
            error_msg_visibility();

            if (lbl_cr_pending_clarification.Text == "0")
            {
                return;
            }
            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_reopendJobs&PnlB_ID=pnlBdy_reopendJobs", false);

                DataTable RegUser = Main.SelectJobFromRegister("CASE33", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Clarification Requested Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE33", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Clarification Requested Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_clarification_complete_jobs_CR_IT_Click(object sender, EventArgs e)//CR Clarification Complete
        {
            error_msg_visibility();

            if (lbl_cr_clarification_complete.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_pendingClarificationPendingJobs&PnlB_ID=pnlBdy_pendingClarificationPendingJobs", false);
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_pendingClarificationPendingJobs_CR&PnlB_ID=pnlBdy_pendingClarificationPendingJobs_CR", false);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE34", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Clarification Completed Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }        

        protected void lb_approval_requested_jobs_CR_IT_Click(object sender, EventArgs e)//CR Approval Requested
        {
            error_msg_visibility();

            if (lbl_cr_approval_requested.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                //Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_pendingClarificationPendingJobs&PnlB_ID=pnlBdy_pendingClarificationPendingJobs", false);
                DataTable RegUser = Main.SelectJobFromRegister("CASE35", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Approval Requested Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE35", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Approval Requested Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_approved_jobs_CR_IT_Click(object sender, EventArgs e)//CR Approved
        {
            error_msg_visibility();

            if (lbl_cr_approved.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_approvedJobsCR&PnlB_ID=pnlBdy_approvedJobsCR", false);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE36", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Approved Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_re_opened_jobs_CR_IT_Click(object sender, EventArgs e)//CR Re Opened
        {
            error_msg_visibility();

            if (lbl_cr_reopend.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                Response.Redirect("~/Views/ITWorkflow/HelpDeskDashboard.aspx?pagecode=129&PnlH_ID=pnl_reopendJobs&PnlB_ID=pnlBdy_reopendJobs", false);
            }
            else
            {
                DataTable RegUserReopend = Main.SelectJobFromRegister("CASE14", Session["USER"].ToString(), "", "", System.DateTime.Now);
                DataView dv = new DataView(RegUserReopend);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                //this.SetFocus(lbtn_setFocus);
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Re Opened Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_cr_returned_jobs_CR_IT_Click(object sender, EventArgs e)//CR Returned
        {
            error_msg_visibility();

            if (lbl_cr_returned.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE38", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Returned Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE38", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Returned Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }

        protected void lb_closed_by_it_jobs_CR_IT_Click(object sender, EventArgs e)//CR Closed 
        {
            error_msg_visibility();

            if (lbl_cr_closed_by_it.Text == "0")
            {
                return;
            }

            if (Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString())
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE37", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;

                lbl_popup_topic.Text = "Closed Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                DataTable RegUser = Main.SelectJobFromRegister("CASE37", Session["Temp_ActiveUser"].ToString(), "", "", System.DateTime.Now);

                DataView dv = new DataView(RegUser);
                DataTable dt_new = dv.ToTable(true, "REQUEST_ID", "REF_NO", "REQUEST_DATE", "REQUEST_USER", "STATUS", "JOB_TYPE", "ASSIGN_USER", "JOB_DESCRIPTION");
                grd_it_user_jobs.DataSource = dt_new;
                grd_it_user_jobs.DataBind();
                Session["Temp_DataTable"] = dt_new;
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Closed Jobs For CR";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
        }



        //-----------------------------------------------------------Non IT User Button Click Events------------------------------------------------------------------//

        protected void lb_all_jobs_Click(object sender, EventArgs e)//All Jobs
        {
            error_msg_visibility();

            if (lbl_all_jobs.Text == "0")
            {
                return;
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                Action_To_Take = false;
                OracleCommand cmd_get_all_jobs = conn.CreateCommand();

                if (ActiveUser == "")
                {
                    ActiveUser = Session["WF_User"].ToString();
                }
                cmd_get_all_jobs.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                                "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                                "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + ActiveUser + "' " +
                                                "AND TT.STATUS <> 'CLOSE-CONFIRM'";

                OracleDataReader odr_get_get_all_jobs = cmd_get_all_jobs.ExecuteReader();
                DataTable dt_get_all_jobs = new DataTable();

                dt_get_all_jobs.Load(odr_get_get_all_jobs);
                grd_non_it_user_jobs.DataSource = dt_get_all_jobs;
                grd_non_it_user_jobs.DataBind();

                odr_get_get_all_jobs.Close();
                conn.Close();

                Approve_Another_UsersJob = false;
                grd_non_it_user_chkBox_disable();
                //lbl_jobsHeader.Text = "Available Jobs";
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "All Requested Jobs";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void lb_taken_by_it_Click(object sender, EventArgs e)//Jobs Taken By IT
        {
            error_msg_visibility();

            if (lbl_taken_by_it.Text == "0")
            {
                return;
            }
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                Action_To_Take = false;

                if (ActiveUser == "")
                {
                    ActiveUser = Session["WF_User"].ToString();
                }

                OracleCommand cmd_get_jobsTaken_By_IT = conn.CreateCommand();
                cmd_get_jobsTaken_By_IT.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                                            "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                                            "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + ActiveUser + "' " +
                                                            "AND TT.STATUS <> 'INTIMATE' AND TT.STATUS <> 'CLOSE-CONFIRM'";

                OracleDataReader odr_get_jobsTaken_By_IT = cmd_get_jobsTaken_By_IT.ExecuteReader();
                DataTable dt_get_jobsTaken_By_IT = new DataTable();

                dt_get_jobsTaken_By_IT.Load(odr_get_jobsTaken_By_IT);
                grd_non_it_user_jobs.DataSource = dt_get_jobsTaken_By_IT;
                grd_non_it_user_jobs.DataBind();

                odr_get_jobsTaken_By_IT.Close();
                conn.Close();


                Approve_Another_UsersJob = false;
                grd_non_it_user_chkBox_disable();

                //lbl_jobsHeader.Text = "Available Jobs";
                //this.SetFocus(lbtn_setFocus);

                lbl_popup_topic.Text = "Accepted Jobs From IT Division";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void lb_not_taken_by_it_Click(object sender, EventArgs e)//Jobs Not Taken By IT
        {
            error_msg_visibility();

            if (lbl_not_taken_by_it.Text == "0")
            {
                return;
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                Action_To_Take = false;

                if (ActiveUser == "")
                {
                    ActiveUser = Session["WF_User"].ToString();
                }

                OracleCommand cmd_get_jobs_Not_Taken_By_IT = conn.CreateCommand();
                cmd_get_jobs_Not_Taken_By_IT.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                                            "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                                            "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + ActiveUser + "' " +
                                                            "AND TT.STATUS = 'INTIMATE'";

                OracleDataReader odr_get_jobs_Not_Taken_By_IT = cmd_get_jobs_Not_Taken_By_IT.ExecuteReader();
                DataTable dt_get_jobs_Not_Taken_By_IT = new DataTable();

                dt_get_jobs_Not_Taken_By_IT.Load(odr_get_jobs_Not_Taken_By_IT);
                grd_non_it_user_jobs.DataSource = dt_get_jobs_Not_Taken_By_IT;
                grd_non_it_user_jobs.DataBind();

                odr_get_jobs_Not_Taken_By_IT.Close();
                conn.Close();

                //lbl_jobsHeader.Text = "Available Jobs";
                //this.SetFocus(lbtn_setFocus);
                Approve_Another_UsersJob = false;
                grd_non_it_user_chkBox_disable();

                lbl_popup_topic.Text = "Not Accepted Jobs";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void lb_pending_clarification_Click(object sender, EventArgs e)//Pending Clarification Jobs
        {
            error_msg_visibility();

            if (lbl_pending_clarification.Text == "0")
            {
                return;
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                Action_To_Take = true;

                if (ActiveUser == "")
                {
                    ActiveUser = Session["WF_User"].ToString();
                }

                OracleCommand cmd_get_pending_clarification_jobs = conn.CreateCommand();
                //cmd_get_pending_clarification_jobs.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                //                                                 "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +  
                //                                            "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + ActiveUser + "' " +
                //                                            "AND TT.STATUS = 'PENDING-CLARIFICATION'";

                cmd_get_pending_clarification_jobs.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                                                 "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                                            "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + ActiveUser + "' " +
                                                            "AND TT.STATUS = 'PENDING-CLARIFICATION'";

                OracleDataReader odr_get_pending_clarification_jobs = cmd_get_pending_clarification_jobs.ExecuteReader();
                DataTable dt_get_pending_clarification_jobs = new DataTable();

                dt_get_pending_clarification_jobs.Load(odr_get_pending_clarification_jobs);
                grd_non_it_user_jobs.DataSource = dt_get_pending_clarification_jobs;
                grd_non_it_user_jobs.DataBind();

                odr_get_pending_clarification_jobs.Close();
                conn.Close();

                //lbl_jobsHeader.Text = "Available Jobs";
                //this.SetFocus(lbtn_setFocus);
                Approve_Another_UsersJob = false;
                grd_non_it_user_chkBox_disable();

                lbl_popup_topic.Text = "Pending Clarification Jobs";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void lb_pending_approval_Click(object sender, EventArgs e)//Pending Approval Jobs (Approval Requested By IT)
        {
            error_msg_visibility();

            if (lbl_pending_approval.Text == "0")
            {
                return;
            }



            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                Action_To_Take = false;

                if (ActiveUser == "")
                {
                    ActiveUser = Session["WF_User"].ToString();
                }

                setActiveUserType(ActiveUser);

                OracleCommand cmd_get_pending_approval_jobs = conn.CreateCommand();

                if (userType == "NON_IT_User")
                {
                    cmd_get_pending_approval_jobs.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE,TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                             "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                             "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + ActiveUser + "' " +
                                             "AND TT.STATUS = 'PENDING-APPROVAL'";

                }
                else
                {
                    cmd_get_pending_approval_jobs.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE,TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                            "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                            "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.Job_Handled_By = '" + ActiveUser + "' " +
                                            "AND TT.STATUS = 'PENDING-APPROVAL'";
                }   
 
                OracleDataReader odr_get_pending_approval_jobs = cmd_get_pending_approval_jobs.ExecuteReader();
                DataTable dt_get_pending_approval_jobs = new DataTable();

                dt_get_pending_approval_jobs.Load(odr_get_pending_approval_jobs);
                grd_non_it_user_jobs.DataSource = dt_get_pending_approval_jobs;
                grd_non_it_user_jobs.DataBind();

                odr_get_pending_approval_jobs.Close();
                conn.Close();

                //lbl_jobsHeader.Text = "Available Jobs";

                Approve_Another_UsersJob = false;
                grd_non_it_user_chkBox_disable();

                lbl_popup_topic.Text = "Approval Requested By IT";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void lb_To_Approve_Common_Click(object sender, EventArgs e)//Pending Approval Jobs (Approve Another Users Job)
        {
            error_msg_visibility();

            if(lbl_to_approve_common.Text == "0")
            {
                return;
            }

            if (ActiveUser == "")
            {
                ActiveUser = Session["WF_User"].ToString();
            }

            setActiveUserType(ActiveUser);


            if (userType == "Approval_User")
            {
                //Response.Redirect("~/Views/ITWorkflow/ChangeAssignUsers.aspx", false);
                //Session["UserType"] = "Approval_User";
                //Action_To_Take = true;
                
                get_common_jobs_for_approval_user();
                Approve_Another_UsersJob = true;
                grd_non_it_user_chkBox_disable();
                lbl_popup_topic.Text = "Requests For Approval (All Users)";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            else
            {
                return;
            }
        }

        protected void lb_return_Click(object sender, EventArgs e)//Jobs Return By IT
        {
            error_msg_visibility();

            if (lbl_return_by_it.Text == "0")
            {
                return;
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                Action_To_Take = false;

                if (ActiveUser == "")
                {
                    ActiveUser = Session["WF_User"].ToString();
                }

                OracleCommand cmd_get_return_jobs = conn.CreateCommand();
                cmd_get_return_jobs.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                                    "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                                            "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + ActiveUser + "' " +
                                                            "AND TT.STATUS = 'RETURN'";

                OracleDataReader odr_get_return_jobs = cmd_get_return_jobs.ExecuteReader();
                DataTable dt_get_return_jobs = new DataTable();

                dt_get_return_jobs.Load(odr_get_return_jobs);
                grd_non_it_user_jobs.DataSource = dt_get_return_jobs;
                grd_non_it_user_jobs.DataBind();

                odr_get_return_jobs.Close();
                conn.Close();

                //lbl_jobsHeader.Text = "Available Jobs";
                Approve_Another_UsersJob = false;
                grd_non_it_user_chkBox_disable();

                lbl_popup_topic.Text = "Jobs Returns By IT";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void lb_close_confirmed_Click(object sender, EventArgs e)//Close Confirm Jobs
        {
            error_msg_visibility();

            if (lbl_close_confirmed.Text == "0")
            {
                return;
            }
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                Action_To_Take = true;

                if (ActiveUser == "")
                {
                    ActiveUser = Session["WF_User"].ToString();
                }

                OracleCommand cmd_get_close_confirm_jobs = conn.CreateCommand();
                cmd_get_close_confirm_jobs.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE, TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                                            "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                                            "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.REQUEST_USER = '" + ActiveUser + "' " +
                                                            "AND TT.STATUS = 'CLOSE'";

                OracleDataReader odr_get_close_confirm_jobs = cmd_get_close_confirm_jobs.ExecuteReader();
                DataTable dt_get_close_confirm_jobs = new DataTable();

                dt_get_close_confirm_jobs.Load(odr_get_close_confirm_jobs);
                grd_non_it_user_jobs.DataSource = dt_get_close_confirm_jobs;
                grd_non_it_user_jobs.DataBind();

                odr_get_close_confirm_jobs.Close();
                conn.Close();

                //lbl_jobsHeader.Text = "Available Jobs";
                //this.SetFocus(lbtn_setFocus);
                Approve_Another_UsersJob = false;
                grd_non_it_user_chkBox_disable();

                lbl_popup_topic.Text = "Close Confirm Jobs";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        protected void lb_To_Approve_Click(object sender, EventArgs e)//Approve Jobs (User Wise)
        {
            error_msg_visibility();

            if (lbl_to_approve.Text == "0")
            {
                return;
            }

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                Action_To_Take = true;

                if (ActiveUser == "")
                {
                    ActiveUser = Session["WF_User"].ToString();
                }

                OracleCommand cmd_get_pending_approval_jobs = conn.CreateCommand();
                cmd_get_pending_approval_jobs.CommandText = "SELECT TT.REQUEST_ID,TT.REF_NO, TT.REQUEST_DATE,TT.JOB_TYPE, TT.PRIORITY, TT.STATUS, " +
                                                            "CASE WHEN (TT.STATUS = 'PENDING-APPROVAL' OR TT.STATUS = 'PENDING-CLARIFICATION')THEN TT.JOB_HANDLED_BY ELSE TT.ASSIGN_USER END AS ASSIGN_USER " +
                                                            "FROM WF_IT_REQUEST_REGISTER TT WHERE TT.Job_Handled_By = '" + ActiveUser + "' " +
                                                            "AND TT.STATUS = 'PENDING-APPROVAL'";

                OracleDataReader odr_get_pending_approval_jobs = cmd_get_pending_approval_jobs.ExecuteReader();
                DataTable dt_get_pending_approval_jobs = new DataTable();

                dt_get_pending_approval_jobs.Load(odr_get_pending_approval_jobs);
                grd_non_it_user_jobs.DataSource = dt_get_pending_approval_jobs;
                grd_non_it_user_jobs.DataBind();

                odr_get_pending_approval_jobs.Close();
                conn.Close();

                Approve_Another_UsersJob = false;
                grd_non_it_user_chkBox_disable();

                lbl_popup_topic.Text = "To Approve (User Wise)";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-3", "$('#sample-modal-dialog-3').modal();", true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }


        //-----------------------------------------------------------Grid View Events--------------------------------------------------------------------------------//

        protected void grd_it_user_jobs_RowCommand(object sender, GridViewCommandEventArgs e)//IT User's Jobs Grid View Row Command
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            if (e.CommandName == "Select")//Take Job
            {
                gridView_select_command = true;

                string selected_req_id = "";

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                selected_req_id = grd_it_user_jobs.Rows[rowIndex].Cells[1].Text;

                Response.Redirect("~/Views/ITWorkflow/ChangeAssignUsers.aspx?ReqID=" + selected_req_id, false);
            }
            if (e.CommandName == "Select_History_For_IT")//Take Job
            {

                string selected_req_id = "";

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                selected_req_id = grd_it_user_jobs.Rows[rowIndex].Cells[2].Text;

                OracleCommand cmd_getJobHistory = conn.CreateCommand();
                //cmd_getJobHistory.CommandText = "SELECT EE.JOB_NO ,EE.STATUS,EE.EVENT_DATE,EE.USER_NAME,EE.REMARKS_UNIT,EE.REMARKS_BRANCH " +
                //                                "FROM WF_IT_EVENTS EE WHERE EE.JOB_NO ='" + selected_req_id + "' ORDER BY EE.EVENT_DATE ASC";

                cmd_getJobHistory.CommandText = "SELECT EE.JOB_NO ,EE.STATUS,EE.EVENT_DATE,EE.USER_NAME,EE.REMARKS_UNIT,EE.REMARKS_BRANCH " +
                                        "FROM WF_IT_EVENTS EE WHERE EE.JOB_NO ='" + selected_req_id + "' ORDER BY EE.EVENT_DATE ASC";


                OracleDataReader odr_getJobHistory = cmd_getJobHistory.ExecuteReader();
                DataTable dt_getJobHistory = new DataTable();

                dt_getJobHistory.Load(odr_getJobHistory);

                grd_it_user_jobs_history.DataSource = dt_getJobHistory;
                grd_it_user_jobs_history.DataBind();

                odr_getJobHistory.Close();

                lbl_popup_topic.Text = "Clarification Requested Jobs For ER";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "sample-modal-dialog-5", "$('#sample-modal-dialog-5').modal();", true);

  
            }
            else
            {
                return;
            }
        }

        protected void grd_it_user_jobs_RowDataBound(object sender, GridViewRowEventArgs e)//IT User's Jobs Grid View Row Command
        {

            grd_it_user_jobs_history.DataSource = null;
            grd_it_user_jobs_history.DataBind();


            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Text = "Request ID";
                e.Row.Cells[3].Text = "Referance No";
                e.Row.Cells[4].Text = "Request Date";
                e.Row.Cells[5].Text = "Request User";
                e.Row.Cells[6].Text = "Current Status";
                e.Row.Cells[7].Text = "Job Type";
                e.Row.Cells[8].Text = "Assigned User";
                e.Row.Cells[9].Text = "Job Description";//janaka
                //e.Row.Cells[0].Attributes["width"] = "50px";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton lbtn_ContinueProcess = (LinkButton)e.Row.Cells[0].Controls[0];

                CheckBox chk_box = e.Row.FindControl("chkboxselect") as CheckBox; //e.Row.Cells[0].Controls[0] as CheckBox ;


                //if ((e.Row.Cells[5].Text == "PENDING-CLARIFICATION") || (e.Row.Cells[5].Text == "PENDING-APPROVAL"))//Original
                if ((e.Row.Cells[6].Text == "PENDING-CLARIFICATION") || (e.Row.Cells[6].Text == "PENDING-APPROVAL") || (e.Row.Cells[6].Text == "CLOSE") || (e.Row.Cells[6].Text == "RETURN"))
                {
                    //lbtn_ContinueProcess.Enabled = false;
                    chk_box.Enabled = false;
                }
                else
                {
                    //lbtn_ContinueProcess.Enabled = true;
                    chk_box.Enabled = true;
                }

            }

        }

        protected void grd_non_it_user_jobs_RowCommand(object sender, GridViewCommandEventArgs e)//Non IT Grid View Row Command
        {
            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                if (e.CommandName == "Select")//View History
                {
                    gridView_select_command = true;

                    string selected_req_id = "";

                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    selected_req_id = grd_non_it_user_jobs.Rows[rowIndex].Cells[3].Text;

                    OracleCommand cmd_getJobHistory = conn.CreateCommand();
                    cmd_getJobHistory.CommandText = "SELECT EE.JOB_NO ,EE.STATUS,EE.EVENT_DATE,EE.USER_NAME,EE.REMARKS_UNIT,EE.REMARKS_BRANCH " +
                                                    "FROM WF_IT_EVENTS EE WHERE EE.JOB_NO ='" + selected_req_id + "' ORDER BY EE.EVENT_DATE ASC";

                    OracleDataReader odr_getJobHistory = cmd_getJobHistory.ExecuteReader();
                    DataTable dt_getJobHistory = new DataTable();

                    dt_getJobHistory.Load(odr_getJobHistory);

                    grd_non_it_user_jobs.DataSource = dt_getJobHistory;
                    grd_non_it_user_jobs.DataBind();

                    odr_getJobHistory.Close();

                    foreach (GridViewRow row in grd_non_it_user_jobs.Rows)
                    {
                        CheckBox chk = (row.Cells[0].FindControl("chkboxselect") as CheckBox);
                        if (chk != null)// && chk.Checked)
                        {
                            chk.Enabled = false;
                        }
                    }

                    //lbl_jobsHeader.Text = "Job History";
                }
                else//Continue Process
                {
                    gridView_select_command = false;

                    string selected_req_id = "";

                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    selected_req_id = grd_non_it_user_jobs.Rows[rowIndex].Cells[3].Text;
                    string current_status = grd_non_it_user_jobs.Rows[rowIndex].Cells[8].Text;


                    if (ActiveUser == "")
                    {
                        ActiveUser = Session["WF_User"].ToString();
                    }

                    if (userType == "")
                    {
                        setActiveUserType(ActiveUser);
                    }


                    if ((current_status == "PENDING-CLARIFICATION") && ((userType == "NON_IT_User") || (userType == "Approval_User")))
                    {
                        Response.Redirect("~/Views/ITWorkflow/UserRequestForm.aspx?ReqID=" + selected_req_id, false);
                    }
                    else if ((current_status == "PENDING-APPROVAL") && (userType == "Approval_User"))
                    {
                        Response.Redirect("~/Views/ITWorkflow/HandlerForm.aspx?ReqID=" + selected_req_id, false);
                    }
                    else if ((current_status == "APPROVE") && (userType == "IT_User"))
                    {
                        Response.Redirect("~/Views/ITWorkflow/HelpDeskView.aspx?ReqID=" + selected_req_id, false);
                    }
                    else if ((current_status == "RETURN") && (userType == "NON_IT_User") || (userType == "Approval_User"))
                    {
                        Response.Redirect("~/Views/ITWorkflow/UserRequestForm.aspx?ReqID=" + selected_req_id, false);
                    }
                    else if ((current_status == "CLOSE") && ((userType == "NON_IT_User") || (userType == "Approval_User")))
                    {
                        Response.Redirect("~/Views/ITWorkflow/UserRequestForm.aspx?ReqID=" + selected_req_id, false);
                    }
                    else
                    {

                        //lbtn_ContinueProcess.Enabled = false;
                    }


                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

        protected void grd_non_it_user_jobs_RowDataBound(object sender, GridViewRowEventArgs e)//Non IT Grid View Row Data Bound
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (gridView_select_command == true)
                {
                    //Set Headers
                    //e.Row.Cells[3].Text = "Account No";

                    //Hidden Columns
                    e.Row.Cells[1].CssClass = "HiddenCol";
                    e.Row.Cells[2].CssClass = "HiddenCol";

                    //Active Columns Width
                    e.Row.Cells[3].Attributes["width"] = "170px";//Request ID
                    e.Row.Cells[4].Attributes["width"] = "600px";//Status
                    e.Row.Cells[5].Attributes["width"] = "550px";//Event Date
                    e.Row.Cells[6].Attributes["width"] = "170px";//User Name
                    e.Row.Cells[7].Attributes["width"] = "380px";//Remarks Unit
                    e.Row.Cells[8].Attributes["width"] = "380px";//Remaks Branch

                    e.Row.Cells[3].Text = "Request ID";
                    e.Row.Cells[4].Text = "Status";
                    e.Row.Cells[5].Text = "Event Date";
                    e.Row.Cells[6].Text = "User Name";
                    e.Row.Cells[7].Text = "Remarks Unit";
                    e.Row.Cells[8].Text = "Remaks Branch";
                }
                else
                {
                    //Hidden Columns
                    e.Row.Cells[8].CssClass = "HiddenCol";

                    //Column Headers
                    e.Row.Cells[3].Text = "Job ID";
                    e.Row.Cells[4].Text = "Referance No";
                    e.Row.Cells[5].Text = "Request Date";
                    e.Row.Cells[6].Text = "Job Type";
                    e.Row.Cells[7].Text = "Priority";
                    e.Row.Cells[9].Text = "Assign User";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtn_ContinueProcess = (LinkButton)e.Row.Cells[2].Controls[0];
                //CheckBox chk_box = e.Row.FindControl("chkboxselect") as CheckBox;


                if (gridView_select_command == true)
                {
                    //Hidden Columns
                    e.Row.Cells[1].CssClass = "HiddenCol";
                    e.Row.Cells[2].CssClass = "HiddenCol";

                    if ((e.Row.Cells[4].Text == "PENDING-APPROVAL") || (e.Row.Cells[4].Text == "PENDING-CLARIFICATION") || (e.Row.Cells[4].Text == "CLOSE") || ((e.Row.Cells[4].Text == "RETURN")))
                    {
                        if (Action_To_Take == true)
                        {
                            lbtn_ContinueProcess.Enabled = true;                            
                        }
                        else
                        {
                            lbtn_ContinueProcess.Enabled = false;
                        }
                    }
                    else
                    {
                        lbtn_ContinueProcess.Enabled = false;
                    }
                }
                else
                {
                    //Hidden Columns
                    e.Row.Cells[8].CssClass = "HiddenCol";

                    if ((e.Row.Cells[8].Text == "PENDING-APPROVAL") || (e.Row.Cells[8].Text == "PENDING-CLARIFICATION") || (e.Row.Cells[8].Text == "CLOSE") || ((e.Row.Cells[8].Text == "RETURN")))
                    {
                        if (Action_To_Take == true)
                        {
                            lbtn_ContinueProcess.Enabled = true;
                        }
                        else
                        {
                            lbtn_ContinueProcess.Enabled = false;
                            //chk_box.Enabled = false;
                        }
                    }
                    else
                    {
                        lbtn_ContinueProcess.Enabled = false;
                    }
                }
            }
        }

        protected void grd_it_summary_RowDataBound(object sender, GridViewRowEventArgs e)//Grid View Row Data Bound
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Request ID";
                e.Row.Cells[1].Text = "System Type";
                e.Row.Cells[2].Text = "Request User";
                e.Row.Cells[3].Text = "Assigned User";
                e.Row.Cells[4].Text = "Job Type";
                e.Row.Cells[5].Text = "Job Description";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string job_type_info = e.Row.Cells[4].Text;

                if(job_type_info == "ER")
                {
                    e.Row.Cells[4].BackColor = Color.Gainsboro;//PapayaWhip;
                }
                else if(job_type_info == "SR")
                {
                    e.Row.Cells[4].BackColor = Color.MistyRose;
                }
                else if(job_type_info == "CR")
                {
                    e.Row.Cells[4].BackColor = Color.LemonChiffon;
                }
                else
                {
                    e.Row.Cells[4].BackColor = Color.White;
                }
            }
        }

        private void grd_non_it_user_chkBox_disable()//Non IT User Grid View Check Box Disable
        {
            setActiveUserType(Session["WF_User"].ToString());

            if ((Approve_Another_UsersJob == true) && (userType == "Approval_User"))
            {
                foreach (GridViewRow row in grd_non_it_user_jobs.Rows)
                {
                    CheckBox chk = (row.Cells[0].FindControl("chkboxselect") as CheckBox);
                    if (chk != null)
                    {
                        chk.Enabled = true;
                    }
                }
            }
            else
            {
                foreach (GridViewRow row in grd_non_it_user_jobs.Rows)
                {
                    CheckBox chk = (row.Cells[0].FindControl("chkboxselect") as CheckBox);
                    if (chk != null)
                    {
                        chk.Enabled = false;
                    }
                }
            }
        }


        //------------------------------------------------------------Re Assigning---------------------------------------------------------------------------------//

        protected void btn_take_job_Click(object sender, EventArgs e)//Take Another User's Job Or Re Assign User
        {
            error_msg_visibility();

            if (ddl_reassignUsers.SelectedIndex == 0)
            {
                Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ecode=e_07", false);
                return;
            }


            string temp_jobID = "";
            string temp_usr = "";
            string active_usr = "";
            string user_type = "";

            DataTable dt_temp_data = (DataTable)Session["Temp_DataTable"];

            OracleConnection conn = new OracleConnection(myConn);
            conn.Open();

            try
            {
                OracleTransaction transaction;
                transaction = conn.BeginTransaction(System.Data.IsolationLevel.Serializable);
                OracleCommand command = conn.CreateCommand();
                command.Transaction = transaction;


                setActiveUserType(Session["WF_User"].ToString());


                if (Session["WF_User"].ToString() != Session["Temp_ActiveUser"].ToString())
                {
                    temp_usr = Session["Temp_ActiveUser"].ToString();
                    active_usr = Session["WF_User"].ToString();

                    if (userType == "IT_User")
                    {
                        user_type = userType;
                    }
                    else if (userType == "Approval_User")
                    {
                        user_type = userType;
                    }
                    else
                    {
                        user_type = userType;
                        //return;
                    }
                }
                else if ((Session["WF_User"].ToString() == Session["Temp_ActiveUser"].ToString()) && (userType == "Approval_User"))
                {
                    temp_usr = Session["WF_User"].ToString();
                    active_usr = Session["WF_User"].ToString();
                }
                else
                {
                    ddl_reassignUsers.Enabled = false;
                    //btn_take_job.Enabled = false;
                }

                if (temp_usr != "")
                {
                    if (userType == "Approval_User")
                    {
                        user_type = userType;

                        foreach (GridViewRow row in grd_non_it_user_jobs.Rows)
                        {
                            CheckBox chk = (row.Cells[1].FindControl("chkboxselect") as CheckBox);
                            if (chk != null && chk.Checked)
                            {
                                temp_jobID = row.Cells[3].Text.ToString();
                                OracleCommand cmd_getData = conn.CreateCommand();

                                cmd_getData.CommandText = "WF_IT_TAKE_ANOTHER_USERS_JOB";
                                cmd_getData.CommandType = CommandType.StoredProcedure;

                                cmd_getData.Parameters.Add("V_JOB_NO", OracleType.VarChar).Value = temp_jobID;//row.Cells[6].Text.ToString();
                                cmd_getData.Parameters.Add("V_USER", OracleType.VarChar).Value = ddl_reassignUsers.SelectedValue.ToString();//active_usr;
                                cmd_getData.Parameters.Add("V_ACTIVE_USER", OracleType.VarChar).Value = active_usr;
                                cmd_getData.Parameters.Add("V_USER_TYPE", OracleType.VarChar).Value = user_type;

                                cmd_getData.Transaction = transaction;
                                cmd_getData.ExecuteNonQuery();

                                Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ecode=e_05", false);
                            }
                            else
                            {
                                Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ecode=e_06", false);
                            }
                        }
                    }
                    else
                    {
                        foreach (GridViewRow row in grd_it_user_jobs.Rows)
                        {
                            CheckBox chk = (row.Cells[1].FindControl("chkboxselect") as CheckBox);
                            if (chk != null && chk.Checked)
                            {
                                temp_jobID = row.Cells[1].Text.ToString();
                                OracleCommand cmd_getData = conn.CreateCommand();

                                cmd_getData.CommandText = "WF_IT_TAKE_ANOTHER_USERS_JOB";
                                cmd_getData.CommandType = CommandType.StoredProcedure;

                                cmd_getData.Parameters.Add("V_JOB_NO", OracleType.VarChar).Value = temp_jobID;//row.Cells[6].Text.ToString();
                                cmd_getData.Parameters.Add("V_USER", OracleType.VarChar).Value = ddl_reassignUsers.SelectedValue.ToString();//active_usr;
                                cmd_getData.Parameters.Add("V_ACTIVE_USER", OracleType.VarChar).Value = active_usr;
                                cmd_getData.Parameters.Add("V_USER_TYPE", OracleType.VarChar).Value = user_type;

                                cmd_getData.Transaction = transaction;
                                cmd_getData.ExecuteNonQuery();

                                Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ecode=e_05", false);
                            }
                            else
                            {
                                Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ecode=e_06", false);
                            }
                        }
                    }

                    

                    transaction.Commit();
                    conn.Close();

                    
                }
                else
                {
                    //ddl_reassignUsers.Enabled = false;
                    lbl_error.Text = "Please Select A Job And Try Again...!";
                    //return;                
                    Response.Redirect("~/Views/ITWorkflow/IT_WF_Dashboard_New.aspx?ecode=e_07", false);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        private void error_msg_handing(string err_no)//Error Messeges Hadling
        {
            if(err_no == "e_01")//Already Implemented CR
            {
                err_msg_div.Attributes["class"] = "alert alert-danger";//warning danger success
                err_msg_div.Visible = true;
                lbl_err_msg.Text = "Job Already Implemented In Change Management System...!";
            }
            else if (err_no == "e_02")
            {
                err_msg_div.Attributes["class"] = "alert alert-danger";//warning danger success
                err_msg_div.Visible = true;
                lbl_err_msg.Text = "Job Already Implemented In Change Management System...!";
            }
            else if (err_no == "e_03")
            {
                err_msg_div.Attributes["class"] = "alert alert-danger";//warning danger success
                err_msg_div.Visible = true;
                lbl_err_msg.Text = "You have to send the job to 'Change Management' system first...!";
            }
            else if (err_no == "e_04")
            {
                err_msg_div.Attributes["class"] = "alert alert-success";//warning danger success
                err_msg_div.Visible = true;
                lbl_err_msg.Text = "Job Request Successfully Added to the IT-Work Flow System...!";
            }
            else if (err_no == "e_05")
            {
                err_msg_div.Attributes["class"] = "alert alert-success";//warning danger success
                err_msg_div.Visible = true;
                lbl_err_msg.Text = "Job Reassigning Successfull...!";
            }
            else if (err_no == "e_06")
            {
                err_msg_div.Attributes["class"] = "alert alert-danger";//warning danger success
                err_msg_div.Visible = true;
                lbl_err_msg.Text = "You must select at least one job request, before the reassigning...!";
            }
            else if (err_no == "e_07")
            {
                err_msg_div.Attributes["class"] = "alert alert-danger";//warning danger success
                err_msg_div.Visible = true;
                lbl_err_msg.Text = "Current user doesn't have required permission to continue the precess...!";
            }
            else
            {
                error_msg_visibility();
            }
        }

        private void error_msg_visibility()
        {
            lbl_err_msg.Text = "";
            err_msg_div.Visible = false;
            //ScriptManager.RegisterStartupScript(this, GetType(), "error_msg_hidden();", "error_msg_hidden();", true);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            ddl_filter_by_users_SelectedIndexChanged(null, null);
            
            if (Session["ER_SR_CR"].ToString() == "ER")
            {
                lb_ER_Base_Click(sender, e);
            }
            if (Session["ER_SR_CR"].ToString() == "SR")
            {
                lb_SR_Base_Click(sender, e);
            }
            if (Session["ER_SR_CR"].ToString() == "CR")
            {
                lb_CR_Base_Click(sender, e);
            }
        }



        //protected void Timer_IT_Panel_Tick(object sender, EventArgs e)
        //{
        //    ddl_filter_by_users_SelectedIndexChanged(null, null);
        //}



        protected void grd_it_user_jobs_history_RowCommand(object sender, GridViewCommandEventArgs e)//IT User's Jobs Grid View Row Command
        {

        }


        protected void grd_it_user_jobs_history_RowDataBound(object sender, GridViewRowEventArgs e)//IT User's Jobs Grid View Row Command
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (gridView_select_command == true)
                {

                    //Active Columns Width
                    e.Row.Cells[1].Attributes["width"] = "170px";//Request ID
                    e.Row.Cells[2].Attributes["width"] = "600px";//Status
                    e.Row.Cells[3].Attributes["width"] = "550px";//Event Date
                    e.Row.Cells[4].Attributes["width"] = "170px";//User Name
                    e.Row.Cells[5].Attributes["width"] = "380px";//Remarks Unit
                    e.Row.Cells[6].Attributes["width"] = "380px";//Remaks Branch

                    e.Row.Cells[1].Text = "Request ID";
                    e.Row.Cells[2].Text = "Status";
                    e.Row.Cells[3].Text = "Event Date";
                    e.Row.Cells[4].Text = "User Name";
                    e.Row.Cells[5].Text = "Remarks Unit";
                    e.Row.Cells[6].Text = "Remaks Branch";
                }

            }
        }














    }
}