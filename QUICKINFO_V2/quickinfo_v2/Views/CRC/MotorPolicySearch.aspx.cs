using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using quickinfo_v2.Connectivity;
using System.Data;

namespace quickinfo_v2.Views.CRC
{
    public partial class MotorPolicySearch : System.Web.UI.Page
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
            DtSearch = CRC.SelectDataCRCMotor(txtPolicyNo.Text.Trim() == "" ? "-" : txtPolicyNo.Text, txtVehicleNo.Text.Trim() == "" ? "-" : txtVehicleNo.Text, txtProposalNo.Text.Trim() == "" ? "-" : txtProposalNo.Text, txtEngineNo.Text.Trim() == "" ? "-" : txtEngineNo.Text, txtChassiNo.Text.Trim() == "" ? "-" : txtChassiNo.Text, txtContactNo.Text.Trim() == "" ? "-" : txtContactNo.Text, txtNIC.Text.Trim() == "" ? "-" : txtNIC.Text, txtInsuredName.Text.Trim() == "" ? "-" : txtInsuredName.Text);
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
                e.Row.Cells[1].Text = "Policy No";
                e.Row.Cells[2].Text = "Proposal No";
                e.Row.Cells[3].Text = "Vehcile No";
                e.Row.Cells[4].Text = "Insured Name";
                e.Row.Cells[5].Text = "Effective Date";
                e.Row.Cells[6].Text = "Expiry Date";
                e.Row.Cells[7].Text = "Policy ID";

                e.Row.Cells[7].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[7].Visible = false;

                e.Row.Cells[5].Text = e.Row.Cells[5].Text.Remove(10);
                e.Row.Cells[6].Text = e.Row.Cells[6].Text.Remove(10);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CRC/MotorPolicySearch.aspx");
        }

    }
}