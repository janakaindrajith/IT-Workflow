using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using quickinfo_v2.Connectivity;

namespace quickinfo_v2.Views.CRC
{
    public partial class MotorPerUnderwritingSearch : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        CRCMain CRC = new CRCMain();
        DataTable DtSearch;
        string Results;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DtSearch = CRC.SelectDataMotorInspection(txtPURNo.Text.Trim() == "" ? "-" : txtPURNo.Text, txtVehicleNo.Text.Trim() == "" ? "-" : txtVehicleNo.Text, txtInsuredName.Text.Trim() == "" ? "-" : txtInsuredName.Text, txtBranch.Text.Trim() == "" ? "-" : txtBranch.Text);
            if (DtSearch.Rows.Count > 0)
            {
                foreach (DataRow dr in DtSearch.Rows)
                {
                    Results = Convert.ToString(dr[0]);
                }

                if (Results == "Search text can not be blank")
                {
                    lblError.Visible = true;
                    lblError.Text = Results.ToString();
                    pnlUserGrid.Visible = false;
                    grdJob.DataSource = "";
                    grdJob.DataBind();
                }
                else
                {
                    lblError.Visible = false;
                    lblError.Text = "";
                    pnlUserGrid.Visible = true;
                    grdJob.DataSource = DtSearch;
                    grdJob.DataBind();
                }
            }
            else
            {
                pnlUserGrid.Visible = false;
                grdJob.DataSource = DtSearch;
                grdJob.DataBind();
            }
        }

        protected void grdJob_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Job No";
                e.Row.Cells[2].Text = "Vehcile No";
                e.Row.Cells[3].Text = "Insured Name";
                e.Row.Cells[4].Text = "Assesor Name";
                e.Row.Cells[5].Text = "Branch";
                e.Row.Cells[6].Text = "User";
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CRC/MotorPerUnderwritingSearch.aspx");
        }
    }
}