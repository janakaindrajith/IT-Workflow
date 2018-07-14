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

namespace quickinfo_v2.Views.ChangeManagement
{
   

    public partial class CM_Dashboard : System.Web.UI.Page
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
            FillData();
            FillData_BarChart();
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

                    Chart1.Series["Default"].Points[0].Color = Color.FromArgb(0, 31, 51);
                    Chart1.Series["Default"].Points[1].Color = Color.FromArgb(0, 66, 110);
                    Chart1.Series["Default"].Points[2].Color = Color.FromArgb(0, 114, 188);
                    Chart1.Series["Default"].Points[3].Color = Color.FromArgb(0, 150, 247);
                    Chart1.Series["Default"].Points[4].Color = Color.FromArgb(90, 190, 255);
                    Chart1.Series["Default"].Points[5].Color = Color.FromArgb(208, 236, 255);

                    Chart1.Series["Default"].ChartType = SeriesChartType.Doughnut;
                    Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";
                 //   Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                    Chart1.Legends[0].Enabled = false;
                }

            }

            Chart1.Series["Default"].ToolTip = "#VALX : #VALY";//new
        }


     

        private void FillData_BarChart()
        {




            DataTable dt = CM_Main.GetData("COLUMNCHART1");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Chart2.DataSource = dt;
                    Chart2.Series["Series1"].XValueMember = "FULL_NAME";
                    Chart2.Series["Series1"].YValueMembers = "NUMBEROFJOBS";
                    Chart2.DataBind();


                    Chart2.Series["Series1"].ChartType = SeriesChartType.Column;

                   // Chart2.Series["Series1"]["DrawingStyle"] = "Emboss";
                   // Chart2.ChartAreas["ChartArea2"].Area3DStyle.Enable3D = true;
                 //   Chart2.ChartAreas["ChartArea2"].AxisX.Interval = 1;

                   // Chart2.Series["Series1"].Points[i].Color = Color.FromArgb(48, 54, 65);

                    Chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
                    Chart2.ChartAreas["ChartArea2"].AxisY.MajorGrid.Enabled = false;

                    Chart2.ChartAreas["ChartArea2"].AxisX.LineWidth = 0;
                    Chart2.ChartAreas["ChartArea2"].AxisY.LineWidth = 0;

                    Chart2.ChartAreas["ChartArea2"].AxisX.LabelStyle.Enabled = false;
                    Chart2.ChartAreas["ChartArea2"].AxisY.LabelStyle.Enabled = false;

                    Chart2.ChartAreas["ChartArea2"].AxisY.MajorTickMark.Enabled = false;
                    Chart2.ChartAreas["ChartArea2"].AxisY.MinorTickMark.Enabled = false;
                    Chart2.ChartAreas["ChartArea2"].AxisX.MajorTickMark.Enabled = false;
                    Chart2.ChartAreas["ChartArea2"].AxisX.MinorTickMark.Enabled = false;

                    Chart2.Series["Series1"].IsValueShownAsLabel = false;

                   



                }

             

                Chart2.Series["Series1"].ToolTip = "#VALX : #VALY";//new

                
            }




        }




    }



}