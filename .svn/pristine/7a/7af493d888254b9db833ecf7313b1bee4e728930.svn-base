using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace quickinfo_v2.Connectivity
{
    public class AISMain
    {
        public DataTable SelectDataAIS(string Par1, string Par2, string Par3, string Par4)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_PAR1", Par1);
            inputParameter.Add("@V_PAR2", Par2);
            inputParameter.Add("@V_PAR3", Par3);
            inputParameter.Add("@V_DATE", Par4);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataAIS, inputParameter);
            return a;
        }

        public DataTable SelectDataCommentAIS(string Par1, string Par2, string Par3)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_PAR1", Par1);
            inputParameter.Add("@V_PAR2", Par2);
            inputParameter.Add("@V_PAR3", Par3);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataCommentAIS, inputParameter);
            return a;
        }

        public DataTable SelectDataAssesor(string Par1, string Par2, string Par3, string Par4)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("@V_PAR1", Par1);
            inputParameter.Add("@V_PAR2", Par2);
            inputParameter.Add("@V_PAR3", Par3);
            inputParameter.Add("@V_PAR4", Par4);

            DataTable a = DatabaseUtility.SelectDataWithInputParameters(GenericStoredProcedure.SelectDataAssesor, inputParameter);
            return a;
        }

        public DataTable InsertAccidentData(string MOI, string inspection, string imgtype, double lattitude, double longitute, double amount, string paytype)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();


            inputParameter.Add("V_MOI_NO", MOI);
            inputParameter.Add("V_INSPECTION", inspection);
            inputParameter.Add("V_IMG_TYPE", imgtype);
            inputParameter.Add("V_LATTITUDE", Convert.ToDouble(lattitude));
            inputParameter.Add("V_LONGITUDE", Convert.ToDouble(longitute));
            inputParameter.Add("V_AMOUNT", Convert.ToDouble(amount));
            inputParameter.Add("V_PAYTYPE", paytype);


            DataTable a = DatabaseUtility.PopulateDataWithReturn(GenericStoredProcedure.InsertAccidentDetails, inputParameter);
            return a;
        }

        public DataTable InsertImageUploadError(Int32 ID, Int32 IMGID, string imgpath)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();


            inputParameter.Add("V_ID", ID);
            inputParameter.Add("V_IMG_ID", IMGID);
            inputParameter.Add("V_PATH", imgpath);


            DataTable a = DatabaseUtility.PopulateDataWithReturn(GenericStoredProcedure.InsertImageUploadError, inputParameter);
            return a;
        }

        public DataTable AssesorJobTransfer(string MOI, string username, string assesorname)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("V_USERID", username);
            inputParameter.Add("V_NEW_ASSE_CODE", assesorname);
            inputParameter.Add("V_JOB_NO", MOI);

            DataTable a = DatabaseUtility.PopulateDataWithReturn(GenericStoredProcedure.AssesorJobTransfer, inputParameter);
            return a;
        }

        public DataTable InsertAssesorDetails(string assesorname, string contact, string location, string address, string position, string emieno)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("V_ASSESOR_NAME", assesorname);
            inputParameter.Add("V_CONTACT", contact);
            inputParameter.Add("V_LOCATION", location);
            inputParameter.Add("V_ADDRESS", address);
            inputParameter.Add("V_POSITION", position);
            inputParameter.Add("V_EMIE_NO", emieno);

            DataTable a = DatabaseUtility.PopulateDataWithReturn(GenericStoredProcedure.InsertAssesorDetails, inputParameter);
            return a;
        }

        public DataTable UpdateAssesorDetails(string assesorname, string contact, string location, string address, string position, string emieno,string username,string pwd)
        {
            Dictionary<string, object> inputParameter = new Dictionary<string, object>();

            inputParameter.Add("V_ASSESOR_NAME", assesorname);
            inputParameter.Add("V_CONTACT", contact);
            inputParameter.Add("V_LOCATION", location);
            inputParameter.Add("V_ADDRESS", address);
            inputParameter.Add("V_POSITION", position);
            inputParameter.Add("V_EMIE_NO", emieno);
            inputParameter.Add("V_USER_CODE", username);
            inputParameter.Add("V_PWD", pwd);

            DataTable a = DatabaseUtility.PopulateDataWithReturn(GenericStoredProcedure.UpdateAssesorDetails, inputParameter);
            return a;
        }
    }
}