using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using quickinfo_v2.Connectivity;
using System.Data;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;

namespace quickinfo_v2.Views.AIS
{
    public partial class ImageSearch : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        AISMain AIS = new AISMain();
        DataTable DtSearch;
        string imageGalleryText = "";
        string albumId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlSearchType.Items.Clear();
                ddlSearchType.DataSource = Main.SelectReferanceData("AIS_INSP_TYPE","","");
                ddlSearchType.DataValueField = "ID";
                ddlSearchType.DataTextField = "DESCRIPTION";
                ddlSearchType.DataBind();
                ddlSearchType.Text = "-";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if ((txtJob.Text.Trim() == "") && (txtAssesorCode.Text.Trim() == "") && (txtVehicleNo.Text.Trim() == "") && (ddlSearchType.SelectedItem.Text == "-"))
            {
                return;
            }

            DtSearch = AIS.SelectDataAIS(txtJob.Text == "" ? "-" : txtJob.Text, txtVehicleNo.Text == "" ? "-" : txtVehicleNo.Text, txtAssesorCode.Text == "" ? "-" : txtAssesorCode.Text, ddlSearchType.SelectedItem.Text);
            grdJob.DataSource = DtSearch;
            grdJob.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }


        protected void grdJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            albumId = grdJob.SelectedRow.Cells[5].Text;
            imageGalleryText = "~/Views/AIS/ImageViewer.aspx?albumId=" + albumId;
            Response.Redirect(imageGalleryText);
            
            //imageGalleryText = imageGalleryText + "<a href='ImageViewer.aspx?albumId=" + albumId + "' >" + "</a>";

            //ltrlImageGallery.Text = imageGalleryText;

            
        }

        protected void grdJob_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Job No";
                e.Row.Cells[2].Text = "Vehicle No";
                e.Row.Cells[3].Text = "Assesor Code";
                e.Row.Cells[4].Text = "Inspection Type";
                e.Row.Cells[5].Visible = false;

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Visible = false;
            }
        }
    }
}