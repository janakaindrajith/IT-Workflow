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
    public class ChangeManagementMain
    {

        public void InsertRegister(string IT_WF_ID, string ParentChangeID, string RequestUser, string Title, string System,string Description, string RequestUser_Email)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_ITWF_ID", IT_WF_ID);
            inputParameter.Add("V_PARENTCHANGE", ParentChangeID);
            inputParameter.Add("V_REQUEST_USER", RequestUser);
            inputParameter.Add("V_TITLE", Title);
            inputParameter.Add("V_SYSTEM", System);
            inputParameter.Add("V_DESCRIPTION", Description);
            inputParameter.Add("V_REQUEST_USER_EMAIL", RequestUser_Email);


            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_InsertRegister, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateRegister(string CM_ID, string IT_WF_ID, string ParentChangeID, string Title, string System, string Description, string RequestUser)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CM_ID", CM_ID);
            inputParameter.Add("V_ITWF_ID", IT_WF_ID);
            inputParameter.Add("V_PARENTCHANGE", ParentChangeID);
              inputParameter.Add("V_TITLE", Title);
            inputParameter.Add("V_SYSTEM", System);
            inputParameter.Add("V_DESCRIPTION", Description);
            inputParameter.Add("V_REQUEST_USER", RequestUser);


            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_UpdateRegister, inputParameter, outputParameter, outputParameterValues);
        }

        //GetMax Job No
        public DataTable MaxJobNo()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.CM_GetMaxJobNo);
            return dataTable;
        }


        public DataTable SelectJob(string Case, string Par1, string Par2, string Par3, string Par4, string Par5, DateTime? Date)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_CASE_NO", Case);
            inputParameter.Add("@V_PAR1", Par1);
            inputParameter.Add("@V_PAR2", Par2);
            inputParameter.Add("@V_PAR3", Par3);
            inputParameter.Add("@V_PAR4", Par4);
            inputParameter.Add("@V_PAR5", Par5);
            inputParameter.Add("@V_DATE", Date);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.CM_SelectJob, inputParameter);
            return a;

        }

        public void InsertContacts(string JOBNO,string User)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_JOBNO", JOBNO);
            inputParameter.Add("V_USERNAME", User);



            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_InsertContactsToJobNo, inputParameter, outputParameter, outputParameterValues);
        }

        public void InsertPath(string JOBNO,string Path)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_JOBNO", JOBNO);
            inputParameter.Add("V_PATH", Path);



            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_InsertCIPath, inputParameter, outputParameter, outputParameterValues);
        }

        public DataTable SelectMaxIDinImages()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.CM_MaxIDinImages);
            return dataTable;
        }

        public DataTable SelectReferanceData(string RefType, string par1, string par2)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_TYPE", RefType);
            inputParameter.Add("@PAR1", par1);
            inputParameter.Add("@PAR2", par2);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.CM_SelectRefData, inputParameter);
            return a;
        }

        public void UpdateRegister_Plan(string CM_ID, string Impact, string Outage, DateTime Start, DateTime End,string Fallback, string Manager, string Implementor, string QA, 
            string ReleasePerson, string UpdateUser)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CM_ID", CM_ID);
            inputParameter.Add("V_IMPACT", Impact);
            inputParameter.Add("V_OUTAGE", Outage);
            inputParameter.Add("V_START_DATE", Start);
            inputParameter.Add("V_END_DATE", End);
            inputParameter.Add("V_FALLBACK_PLAN", Fallback);
            inputParameter.Add("V_MANAGER", Manager);
            inputParameter.Add("V_IMPLEMENTOR", Implementor);
            inputParameter.Add("V_QAAGENT", QA);
            inputParameter.Add("V_RELEASE_PERSN", ReleasePerson);
            inputParameter.Add("V_USER", UpdateUser);


            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_UpdateRegister_PlanandAssign, inputParameter, outputParameter, outputParameterValues);
        }


        public void UpdateRegister_Reject(string CM_ID, string RejectReason, string RejectUser)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CM_ID", CM_ID);
            inputParameter.Add("V_REJECT_REASON", RejectReason);
            inputParameter.Add("V_USER", RejectUser);

            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_UpdateRegister_Reject, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateRegister_Approve(string CM_ID, string ApproveReason, string ApproveUser)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CM_ID", CM_ID);
            inputParameter.Add("V_APPROVE_REASON", ApproveReason);
            inputParameter.Add("V_USER", ApproveUser);

            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_UpdateRegister_Approve, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateRegister_Implement(string CM_ID, string ImplementationComment,string CIAttatched,string SVN_Attatched,string DeploymentPlan, string CheckList,
          string Prerequisites,   string ApproveUser)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CM_ID", CM_ID);
            inputParameter.Add("V_IMPLEMENTATION", ImplementationComment);
            inputParameter.Add("V_CI_ATTATCHED", CIAttatched);
            inputParameter.Add("V_SVN_ATTATCHED", SVN_Attatched);
            inputParameter.Add("V_DEPLOYMENT_PLAN", DeploymentPlan);
            inputParameter.Add("V_CHECKLIST_FORTEST", CheckList);
            inputParameter.Add("V_PREREQUISITES", Prerequisites);
            inputParameter.Add("V_USER", ApproveUser);


            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_UpdateRegister_Implement, inputParameter, outputParameter, outputParameterValues);
        }


        public void InsertDocsToJobNo(string JOBNO, string DocumentName)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_JOBNO", JOBNO);
            inputParameter.Add("V_DOC_NAME", DocumentName);



            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_InsertDocumentsToJobNo, inputParameter, outputParameter, outputParameterValues);
        }


        public DataTable CM_SelectMaxIDinDocuments()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.CM_MaxIDinDocuments);
            return dataTable;
        }

        public void UpdateRegister_Release(string CM_ID, string Release,  string ApproveUser)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CM_ID", CM_ID);
            inputParameter.Add("V_RELEASE", Release);
            inputParameter.Add("V_USER", ApproveUser);


            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_UpdateRegister_Release, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateRegister_ReleaseUAT(string CM_ID, string Release,  string ApproveUser)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CM_ID", CM_ID);
            inputParameter.Add("V_RELEASE", Release);
            inputParameter.Add("V_USER", ApproveUser);


            DatabaseUtility.PopulateData(GenericStoredProcedure.CM_UpdateRegister_Release_UAT, inputParameter, outputParameter, outputParameterValues);
        }
        public DataTable CM_SelectTotalRecords(DateTime StartDate, DateTime EndDate, string Branch, string SystemType, string status, string company)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_STATRDATE", StartDate);
            inputParameter.Add("@V_ENDDATE", EndDate);
            inputParameter.Add("@V_BRANCH", Branch);
            inputParameter.Add("@V_SYSTEM_TYPE", SystemType);
            inputParameter.Add("@V_STATUS", status);
            inputParameter.Add("@V_COMPANY", company);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.CM_SelectTotalRecords, inputParameter);
            return a;

        }

        //Reports Table
        public DataTable GetData(string type)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_TYPE", type);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.CM_SelectTotalRecords_ForChart, inputParameter);
            return a;
        }

        


    }
}