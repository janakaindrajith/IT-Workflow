using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using quickinfo_v2.Connectivity;
using System.Data;

namespace quickinfo_v2.Views.AIS
{
    public partial class ImageUpload : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        AISMain AIS = new AISMain();
        DataTable DtSearch;
        Int32 AccidentAutoIncrementID = 0;
        string Results = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlInspection.Items.Clear();
                ddlInspection.DataSource = Main.SelectReferanceData("AIS_INSP_TYPE", "", "");
                ddlInspection.DataValueField = "ID";
                ddlInspection.DataTextField = "DESCRIPTION";
                ddlInspection.DataBind();
                ddlInspection.Text = "-";

                From_Load();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if ((txtJob.Text.Trim() == "") && (txtAssesorCode.Text.Trim() == "") && (txtVehicleNo.Text.Trim() == ""))
            {
                return;
            }

            DtSearch = AIS.SelectDataCommentAIS(txtJob.Text == "" ? "-" : txtJob.Text, txtVehicleNo.Text == "" ? "-" : txtVehicleNo.Text, txtAssesorCode.Text == "" ? "-" : txtAssesorCode.Text);
            if (DtSearch.Rows.Count > 0)
            {
                pnlUserGrid.Visible = true;
                grdJob.DataSource = DtSearch;
                grdJob.DataBind();
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
                e.Row.Cells[2].Text = "Vehicle No";
                e.Row.Cells[3].Text = "Assesor Code";
                e.Row.Cells[4].Text = "Job Type";
                e.Row.Cells[5].Visible = false;

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Visible = false;
            }
        }

        private void From_Load()
        {
            txtJobNo.Enabled = false;
            ddlInspection.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            pnlUserGrid.Visible = false;
            lblSave.Visible = false;
            ddlInspection.SelectedItem.Text = "-";
            txtJobNo.Text = "";
        }

        private void Click_Add_New()
        {
            txtJobNo.Enabled = false;
            ddlInspection.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            ddlInspection.SelectedItem.Text = "-";
            txtJobNo.Text = "";
            lblSave.Visible = false;
        }

        private void Click_Cancel()
        {
            txtJobNo.Enabled = false;
            ddlInspection.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            lblSave.Visible = false;
            ddlInspection.SelectedItem.Text = "-";
            txtJobNo.Text = "";
        }

        protected void grdJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            Click_Add_New();
            txtJobNo.Text = grdJob.SelectedRow.Cells[1].Text;
            lblJob.Text = grdJob.SelectedRow.Cells[4].Text;
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AIS/ImageUpload.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Click_Cancel();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlInspection.SelectedItem.Text == "-")
                {
                    lblSave.Text = "Please enter the inspection type";
                    lblSave.Visible = true;
                    return;
                }

                DataTable Save = AIS.InsertAccidentData(txtJobNo.Text, ddlInspection.SelectedItem.Text, lblJob.Text, 0, 0, 0, "");

                foreach (DataRow dr in Save.Rows)
                {
                    AccidentAutoIncrementID = Convert.ToInt32(dr[0]);
                    Results = Convert.ToString(dr[1]);
                }

                if (Results.ToString() == "Record sucessfully saved.")
                {
                    Session["imgtype"] = lblJob.Text;
                    Session["inspection"] = ddlInspection.SelectedItem.Text;
                    Session["JobNo"] = txtJobNo.Text;
                    Session["IncrementNo"] = AccidentAutoIncrementID;
                    Response.Redirect("~/Views/AIS/ImageUploadImages.aspx");
                }

            }
            catch (Exception ex)
            {
                lblSave.Text = ex.ToString();
                lblSave.Visible = true;
                return;
            }

          
        }


    }
}