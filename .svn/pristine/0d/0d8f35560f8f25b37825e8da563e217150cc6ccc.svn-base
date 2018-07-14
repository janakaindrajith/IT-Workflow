using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quickinfo_v2.Connectivity
{
    public class IT_WrokflowMainClass
    {
        public DataTable SelectReferanceData(string RefType, string par1, string par2)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_TYPE", RefType);
            inputParameter.Add("@PAR1", par1);
            inputParameter.Add("@PAR2", par2);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.IT_SelectRefData, inputParameter);
            return a;

        }

        //Insert Register
        public void InsertRegisterBranch(string RefNo, string System, string Remarks, string Branch, string RequestUser, string RequestUser_Email, string Priority,string Company,string Department)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_REF_NO", RefNo);
            inputParameter.Add("V_SYSTEM", System);
            inputParameter.Add("V_REMARKS", Remarks);
            inputParameter.Add("V_BRANCH", Branch);
            inputParameter.Add("V_REQUEST_USER", RequestUser);
            inputParameter.Add("V_REQUEST_USER_EMAIL", RequestUser_Email);
            inputParameter.Add("V_PRIORITY", Priority);
            inputParameter.Add("V_COMPANY", Company);
            inputParameter.Add("V_DEPARTMENT", Department);


            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_InsertRegisterBranch, inputParameter, outputParameter, outputParameterValues);
        }



        //Insert Documents
        public void InsertDocuments(string JobNo, OracleDbType DocName, string DocPath)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_JOB_NO", JobNo);
            inputParameter.Add("V_DOCNAME", DocName);
            inputParameter.Add("V_DOCPATH", DocPath);


            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_InsertDocsToJobNo, inputParameter, outputParameter, outputParameterValues);
        }

        //GetMax Job No
        public DataTable MaxJobNo()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.IT_GetMaxJobNo);
            return dataTable;
        }

        public DataTable SelectJobFromRegister(string Case, string Par1, string Par2, string Par3, DateTime? Date)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_CASE_NO", Case);
            inputParameter.Add("@V_PAR1", Par1);
            inputParameter.Add("@V_PAR2", Par2);
            inputParameter.Add("@V_PAR3", Par3);
            inputParameter.Add("@V_DATE", Date);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.IT_SelectJobFromRegister, inputParameter);
            return a;

        }
        public DataTable GetBranchesRef()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.IT_SelectBranchEmail);
            return dataTable;
        }


        public void UpdateAssignUser(string JobNo, string User)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_JOB_NO", JobNo);
            inputParameter.Add("V_USER", User);

            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_UpdateAssignUser, inputParameter, outputParameter, outputParameterValues);
        }


        public DataTable SelectImages(string JobNo, string DocType)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_JOB_NO", JobNo);
            inputParameter.Add("@V_TYPE", DocType);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.IT_SelectImages, inputParameter);
            return a;

        }


        public DataTable SelectMaxIDinImages()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.IT_MaxIDinImages);
            return dataTable;
        }

        public void UpdateRegister(string ReqID, string JobType, string UnitRemark, string DesID, string Status, string User,
            string ReassignUser, string HandledUser, string TcsErrorNo, string Company)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add(@"V_REQ_ID", ReqID);
            inputParameter.Add(@"V_JOB_TYPE", JobType);
            inputParameter.Add(@"V_REMARKS_UNIT", UnitRemark);
            inputParameter.Add(@"V_JOB_DES", DesID);
            inputParameter.Add(@"V_STATUS", Status);
            inputParameter.Add(@"V_USER", User);
            inputParameter.Add(@"V_REASSIGN_USER", ReassignUser);
            inputParameter.Add(@"V_HANDLED_USER", HandledUser);
            inputParameter.Add(@"V_TCS_NO", TcsErrorNo);
            inputParameter.Add(@"V_COMPANY", Company);

            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_UpdateRegister, inputParameter, outputParameter, outputParameterValues);
        }

        //Update Register By Branch(Re-open)
        public void UpdateRegisterByBranch(string ReqID, string RefNo, string System, string Remarks, string Branch, string User, string Status, string Priority)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add(@"V_REQ_ID", ReqID);
            inputParameter.Add(@"V_REF_NO", RefNo);
            inputParameter.Add(@"V_SYSTEM", System);
            inputParameter.Add(@"V_REMARKS", Remarks);
            inputParameter.Add(@"V_BRANCH", Branch);
            inputParameter.Add(@"V_USER", User);
            inputParameter.Add(@"V_STATUS", Status);
            inputParameter.Add(@"V_PRIORITY", Priority);

            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_UpdateRegisterByBranch, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateRegister_StatusByHandler(string ReqID, string Status, string User)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add(@"V_REQ_ID", ReqID);
            inputParameter.Add(@"V_STATUS", Status);
            inputParameter.Add(@"V_USER", User);

            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_UpdateHandlerStatus, inputParameter, outputParameter, outputParameterValues);
        }

        //----TCS User Unlock
        //----Select TCS Locked Users
        public DataTable SelectTCSLockedUsers(string UserCode )
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_USERCODE", UserCode);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.IT_SelectLockedUser, inputParameter);
            return a;

        }

        public void Update_IT_UnlockUser(string UserCode, string RoleID, DateTime StartDate, string PartyID, string PartyFunction)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add(@"V_USER_CODE", UserCode);
            inputParameter.Add(@"V_ROLE_ID", RoleID);
            inputParameter.Add(@"V_START_DATE", StartDate);
            inputParameter.Add(@"V_PARTY_ID", PartyID);
            inputParameter.Add(@"V_PARTY_FUNCTION", PartyFunction);



            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_UnlockUser, inputParameter, outputParameter, outputParameterValues);
        }


        //----TCS User Unlock-End


        //-----TCS Cancel/Expire Policies
        public DataTable SelectCancelExpirePolicies(string PolicyNo)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_POLYCY_NO", PolicyNo);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.IT_SelectCancelExpirePolicies, inputParameter);
            return a;

        }

        public DataTable GetPolicyCancelUsers()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.GetUsersCancelExpirePolicies);
            return dataTable;
        }

        public void Update_IT_Cancel_Expire(string Case, string PolicyNo)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add(@"V_CASE", Case);
            inputParameter.Add(@"V_POL_NO", PolicyNo);

            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_UpdateCancelExpirePolicies, inputParameter, outputParameter, outputParameterValues);
        }

        //-----TCS Cancel/Expire Policies-End


        //-----------------Reports



        public DataTable SelectTotalRecords(DateTime StartDate,DateTime EndDate,string Branch,string SystemType,string status,string company)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

             inputParameter.Add("@V_STATRDATE", StartDate);
             inputParameter.Add("@V_ENDDATE", EndDate);
             inputParameter.Add("@V_BRANCH", Branch);
             inputParameter.Add("@V_SYSTEM_TYPE", SystemType);
             inputParameter.Add("@V_STATUS", status);
             inputParameter.Add("@V_COMPANY", company);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.IT_SelectTotalRecords, inputParameter);
            return a;

        }

        //--------Report---




        public void UpdateRegister_FromChangeManagement(string ReqID,  string UnitRemark, string Status, string User)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add(@"V_REQ_ID", ReqID);
            inputParameter.Add(@"V_REMARKS_UNIT", UnitRemark);
            inputParameter.Add(@"V_STATUS", Status);
            inputParameter.Add(@"V_USER", User);


            DatabaseUtility.PopulateData(GenericStoredProcedure.IT_UpdateRegister_ByChangeManagement, inputParameter, outputParameter, outputParameterValues);
        }
    }
}