using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace quickinfo_v2.Connectivity
{
    public class CRCMain
    {
        public DataTable SelectDataCRCMotor(string policy, string vehicleno, string proposal, string engine,string chassi,string contact,string nic,string insured)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_POLICY_NO", policy);
            inputParameter.Add("@V_VEHICLE_NO", vehicleno);
            inputParameter.Add("@V_PROPOSAL_NO", proposal);
            inputParameter.Add("@V_ENGINE_NO", engine);
            inputParameter.Add("@V_CHASSI_NO", chassi);
            inputParameter.Add("@V_CONTACT_NO", contact);
            inputParameter.Add("@V_NIC", nic);
            inputParameter.Add("@V_INSURED", insured);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataCRCMotor, inputParameter);
            return a;
        }

        public DataTable SelectDataCRCMotorBiS(string policy, string vehicleno, string proposal, string engine, string chassi, string contact, string insured)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_POLICY_NO", policy);
            inputParameter.Add("@V_VEHICLE_NO", vehicleno);
            inputParameter.Add("@V_PROPOSAL_NO", proposal);
            inputParameter.Add("@V_ENGINE_NO", engine);
            inputParameter.Add("@V_CHASSI_NO", chassi);
            inputParameter.Add("@V_CONTACT_NO", contact);
            inputParameter.Add("@V_INSURED", insured);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataCRCMotorBiS, inputParameter);
            return a;
        }

        public DataTable SelectDataCRCNonMotor(string policy, string proposal, string insured,string nic)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_POLICY_NO", policy);
            inputParameter.Add("@V_PROPOSAL_NO", proposal);
            inputParameter.Add("@V_INSURED", insured);
            inputParameter.Add("@V_NIC", nic);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataCRCNonMotor, inputParameter);
            return a;
        }

        public DataTable SelectDataCRCLife(string policy, string proposal, string insured, string nic,string contact)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_POLICY_NO", policy);
            inputParameter.Add("@V_PROPOSAL_NO", proposal);
            inputParameter.Add("@V_INSURED", insured);
            inputParameter.Add("@V_NIC", nic);
            inputParameter.Add("@V_CONTACT", contact);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataCRCLife, inputParameter);
            return a;
        }

        public DataTable SelectDataMotorIntimation(string moi,string policy, string vehicleno,string contact, string insured)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_MOI_NO", moi);
            inputParameter.Add("@V_POLICY_NO", policy);
            inputParameter.Add("@V_VEHICLE_NO", vehicleno);
            inputParameter.Add("@V_CONTACT_NO", contact);
            inputParameter.Add("@V_INSURED", insured);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataMotorIntimation, inputParameter);
            return a;
        }

        public DataTable SelectDataMotorInspection(string pur, string vehicleno, string insured, string branch)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_PUR_NO", pur);
            inputParameter.Add("@V_VEHICLE_NO", vehicleno);
            inputParameter.Add("@V_INSURED", insured);
            inputParameter.Add("@V_BRANCH", branch);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataMotorInspection, inputParameter);
            return a;
        }
    }
}