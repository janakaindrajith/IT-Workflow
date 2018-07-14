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
using System.Web.UI.DataVisualization.Charting;
using System.Net;
using System.Text;
using System.IO;
using System.DirectoryServices;


using quickinfo_v2.Connectivity;

namespace quickinfo_v2
{
    public partial class Dashboard_CM : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        ChangeManagementMain CM_Main = new ChangeManagementMain();
        DataTable DtRef;
        string UserName = "";
        string ReqID = "";
        StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Label1.Text = "50";
            string a = "123";
            lblTotal.Attributes.Add("data-end", a);
        }



        private void FillData()
        {

            DataTable dt1 = CM_Main.GetData("PIECHART1");
            double col1, col2, col3, col4, col5, col6;

            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    col1 = Convert.ToDouble(dt1.Rows[i]["INTIMATE"]);
                    col2 = Convert.ToDouble(dt1.Rows[i]["ASSIGN"]);
                    col3 = Convert.ToDouble(dt1.Rows[i]["APPROVE"]);
                    col4 = Convert.ToDouble(dt1.Rows[i]["REJECT"]);
                    col5 = Convert.ToDouble(dt1.Rows[i]["IMPLEMENTED"]);
                    col6 = Convert.ToDouble(dt1.Rows[i]["RELEASE"]);

                    double[] yValues = { col1, col2, col3, col4, col5, col6 };
                    string[] xValues = { "INTIMATE", "ASSIGN", "APPROVE", "REJECT", "IMPLEMENTED", "RELEASE" };
                    Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

                    //Chart1.Series["Default"].Points[0].Color = Color.MediumSlateBlue;
                    //Chart1.Series["Default"].Points[1].Color = Color.CornflowerBlue;
                    //Chart1.Series["Default"].Points[2].Color = Color.DarkBlue;
                    //Chart1.Series["Default"].Points[3].Color = Color.LightBlue;
                    //Chart1.Series["Default"].Points[4].Color = Color.Lavender;
                    //Chart1.Series["Default"].Points[5].Color = Color.Teal;

                    Chart1.Series["Default"].ChartType = SeriesChartType.Pie;
                    Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";
                    Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    Chart1.Legends[0].Enabled = true;
                }

            }
        }
    }



}