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
    public class CommissionClass
    {


        public DataTable SelectType(string RefType)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_TYPE", RefType);


            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.COM_SelectRefData, inputParameter);
            return a;

        }

        public void InsertParameters( string Description,string Status, string UserInfo,string valueType,string ParamLength)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_DES", Description);
            inputParameter.Add("V_STATUS", Status);
            inputParameter.Add("V_USERINFO", UserInfo);
            inputParameter.Add("V_VALUETYPE", valueType);
            inputParameter.Add("V_PARAMLENGTH", ParamLength);


            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_InsertParameters, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateParameters(string ParamID,string Description,  string UserInfo, string valueType, string ParamLength)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_PARAMID", ParamID);
            inputParameter.Add("V_DES", Description);
            inputParameter.Add("V_USERINFO", UserInfo);
            inputParameter.Add("V_VALUETYPE", valueType);
            inputParameter.Add("V_PARAMLENGTH", ParamLength);


            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_UpdateParameters, inputParameter, outputParameter, outputParameterValues);
        }


        public DataTable SelectParamData(string Case,string ID,string des, string para1,string para2)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_CASE", Case);
            inputParameter.Add("@V_ID", ID);
            inputParameter.Add("@V_DES", des);
            inputParameter.Add("@V_PARA1", para1);
            inputParameter.Add("@V_PARA2", para2);


            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.COM_SelectParamData, inputParameter);
            return a;

        }

        public DataTable MaxJobNo_Param()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.COM_GetParamMaxNo);
            return dataTable;
        }


        public void InsertReferanceData(string code,string Description, string Status, string UserInfo, string RefType)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CODE", code);
            inputParameter.Add("V_DES", Description);
            inputParameter.Add("V_STATUS", Status);
            inputParameter.Add("V_USERINFO", UserInfo);
            inputParameter.Add("V_REFTYPE", RefType);


            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_InsertReferance, inputParameter, outputParameter, outputParameterValues);
        }


        public void UpdateReferance(string ID, string code, string Description,  string UserInfo, string RefType)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_ID", ID);
            inputParameter.Add("V_CODE", code);
            inputParameter.Add("V_DES", Description);
            inputParameter.Add("V_USERINFO", UserInfo);
            inputParameter.Add("V_REFTYPE", RefType);


            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_UpdateReferance, inputParameter, outputParameter, outputParameterValues);
        }

        public void InsertRule(string RuleDes, string Status, string User, string Definition, string Type,string Percentage)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_RULE_DES", RuleDes);
            inputParameter.Add("V_STATUS", Status);
            inputParameter.Add("V_CREATED_USER", User);
            inputParameter.Add("V_RULE_DEFINITION", Definition);
            inputParameter.Add("V_TYPE", Type);
            inputParameter.Add("V_PERCENTAGE", Percentage);

            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_InsertRules, inputParameter, outputParameter, outputParameterValues);
        }

        public DataTable MaxJobNo_Rule()
        {
            DataTable dataTable = DatabaseUtility.SelectData(GenericStoredProcedure.COM_GetMaxRuleID);
            return dataTable;
        }

        public void InsertRule_RowByRow(string RuleID, string LineNo, string Col1, string Col2, string Col3, string Col4,string Col5,string Col6)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_RULE_ID", RuleID);
            inputParameter.Add("V_LINE_NO", LineNo);
            inputParameter.Add("V_COL1", Col1);
            inputParameter.Add("V_COL2", Col2);
            inputParameter.Add("V_COL3", Col3);
            inputParameter.Add("V_COL4", Col4);
            inputParameter.Add("V_COL5", Col5);
            inputParameter.Add("V_COL6", Col6);


            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_InsertRules_rowByrow, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateRule(string RuleID,string RuleDes, string Status, string User, string Definition, string Type, string Percentage)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_RULE_ID", RuleID);
            inputParameter.Add("V_RULE_DES", RuleDes);
            inputParameter.Add("V_STATUS", Status);
            inputParameter.Add("V_MODIFIED_USER", User);
            inputParameter.Add("V_RULE_DEFINITION", Definition);
            inputParameter.Add("V_TYPE", Type);
            inputParameter.Add("V_PERCENTAGE", Percentage);

            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_UpdateRules, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateRule_RowByRow(string RuleID, string LineNo, string Col1, string Col2, string Col3, string Col4, string Col5, string Col6)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_RULE_ID", RuleID);
            inputParameter.Add("V_LINE_NO", LineNo);
            inputParameter.Add("V_COL1", Col1);
            inputParameter.Add("V_COL2", Col2);
            inputParameter.Add("V_COL3", Col3);
            inputParameter.Add("V_COL4", Col4);
            inputParameter.Add("V_COL5", Col5);
            inputParameter.Add("V_COL6", Col6);


            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_UpdateRules_rowByrow, inputParameter, outputParameter, outputParameterValues);
        }

        public void InsertAgentRef(string Code, string Des, string Status,string Level, string User)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_CODE", Code);
            inputParameter.Add("V_DES", Des);
            inputParameter.Add("V_STATUS", Status);
            inputParameter.Add("V_LEVEL", Level);
            inputParameter.Add("V_USER", User);

            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_InsertAgentRef, inputParameter, outputParameter, outputParameterValues);
        }

        public void UpdateAgentRef(string ID,string Code, string Des, string Status, string Level, string User)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_ID", ID);
            inputParameter.Add("V_CODE", Code);
            inputParameter.Add("V_DES", Des);
            inputParameter.Add("V_STATUS", Status);
            inputParameter.Add("V_LEVEL", Level);
            inputParameter.Add("V_USER", User);

            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_UpdateAgentRef, inputParameter, outputParameter, outputParameterValues);
        }

        public DataTable SelectAgentData(string Case, string par1, string par2, string par3)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_TYPE", Case);
            inputParameter.Add("@V_PAR1", par1);
            inputParameter.Add("@V_PAR2", par2);
            inputParameter.Add("@V_PAR3", par3);


            DataTable a = DatabaseUtilityForSearch.SelectDataWithInputParameters(GenericStoredProcedure.COM_SelectAgentData, inputParameter);
            return a;

        }

        public DataTable SelectAgentHierarchyData(string Case, string par1, string par2, string par3)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_TYPE", Case);
            inputParameter.Add("@V_PAR1", par1);
            inputParameter.Add("@V_PAR2", par2);
            inputParameter.Add("@V_PAR3", par3);


            DataTable a = DatabaseUtilityForSearch.SelectDataWithInputParameters(GenericStoredProcedure.COM_SelectAgentHierarchy, inputParameter);
            return a;
        }


        public void InsertAgentHierarchy(string Code, string ParentCode, decimal Percentage,string Level, string Statue, string User,DateTime? EndDate)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameter = new Dictionary<string, object>();
            Dictionary<string, object> outputParameterValues = new Dictionary<string, object>();

            inputParameter.Add("V_AGENT_CODE", Code);
            inputParameter.Add("V_PARENT_CODE", ParentCode);
            inputParameter.Add("V_PARENT_PERCENTAGE", Percentage);
            inputParameter.Add("V_PARENT_LEVEL", Level);
            inputParameter.Add("V_STATUS", Statue);
            inputParameter.Add("V_USER_NAME", User);
            inputParameter.Add("V_END_DATE", EndDate);


            DatabaseUtility.PopulateData(GenericStoredProcedure.COM_InsertAgentHierarchy, inputParameter, outputParameter, outputParameterValues);
        }
    }
}