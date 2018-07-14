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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
//using System.Data.OracleClient;
using quickinfo_v2.Connectivity;

using CrystalDecisions.Web;


namespace quickinfo_v2.Views.ITWorkflow
{
    public partial class TotalRecord_Report : System.Web.UI.Page
    {
        TableLogOnInfo crTableLogOnInfo = new TableLogOnInfo();
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        CrystalDecisions.CrystalReports.Engine.Database crDatabase;
        CrystalDecisions.CrystalReports.Engine.Tables crTables;
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime Start = Convert.ToDateTime(Request.QueryString["Start"]);
                DateTime End = Convert.ToDateTime(Request.QueryString["End"]);
                string Branch = Request.QueryString["Branch"].ToString();
                string SystemType = Request.QueryString["SystemType"].ToString();
                string Status = Request.QueryString["Status"].ToString();
                //  string Company = Request.QueryString["Company"].ToString();


                DataTable quesdt = Main.SelectTotalRecords(Start, End, Branch, SystemType, Status, "");

                ReportDocument rep = new ReportDocument();
                rep.Load(Server.MapPath(@"Rpt_Total_Records.rpt"));
                rep.SetDataSource(quesdt);
                CrystalReportViewer1.ReportSource = rep;
                CrystalReportViewer1.DataBind();

                CrystalReportViewer1.RefreshReport();
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