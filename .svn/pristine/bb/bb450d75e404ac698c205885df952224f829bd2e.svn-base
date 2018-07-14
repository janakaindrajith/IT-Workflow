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

    public partial class AssesorInsert : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        AISMain AIS = new AISMain();
        DataTable DtSearch;
        string Results;
        string AssesorCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                From_Load();
                ddlPosition.Items.Clear();
                ddlPosition.DataSource = Main.SelectReferanceData("AIS_ASSE_POSITION", "", "");
                ddlPosition.DataValueField = "POS_CODE";
                ddlPosition.DataTextField = "POS_DESCRIP";
                ddlPosition.DataBind();
                ddlPosition.Text = "-";
            }
        }

        protected void btnAddnew_Click(object sender, EventArgs e)
        {
            Click_Add_New();
        }

        private void Click_Add_New()
        {
            btnAddnew.Enabled = false;
            btnAlter.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtAsseName.Enabled = true;
            txtContact.Enabled = true;
            txtAddress.Enabled = true;
            txtLocation.Enabled = true;
            ddlPosition.Enabled = true;
            txtEmiNo.Enabled = true;
            txtPWD.Enabled = false;
            txtPWD.Visible = false;
            lblJob.Text = "AddNew";
            Object_Clear();
        }

        private void Click_Cancel()
        {
            btnAddnew.Enabled = true;
            btnAlter.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = true;
            txtAsseName.Enabled = false;
            txtContact.Enabled = false;
            txtAddress.Enabled = false;
            txtLocation.Enabled = false;
            ddlPosition.Enabled = false;
            txtEmiNo.Enabled = false;
            txtPWD.Enabled = false;
            txtPWD.Visible = false;
            lblPWD.Visible = false;
            Object_Clear();

        }

        private void Object_Clear()
        {
            txtAsseName.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtLocation.Text = "";
            ddlPosition.Text = "-";
            txtEmiNo.Text = "";
            grdJob.DataSource = "";
            grdJob.DataBind();
            lblUser.Text = "";
            lblSave.Text = "";
        }

        private void From_Load()
        {
            btnAddnew.Enabled = true;
            btnAlter.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = true;
            txtAsseName.Enabled = false;
            txtContact.Enabled = false;
            txtAddress.Enabled = false;
            txtLocation.Enabled = false;
            ddlPosition.Enabled = false;
            txtEmiNo.Enabled = false;
            txtPWD.Enabled = false;
            txtPWD.Visible = false;
            lblPWD.Visible = false;
            Object_Clear();
        }

        private void Click_Alter()
        {
            btnAddnew.Enabled = false;
            btnAlter.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtAsseName.Enabled = true;
            txtContact.Enabled = true;
            txtAddress.Enabled = true;
            txtLocation.Enabled = true;
            ddlPosition.Enabled = true;
            txtEmiNo.Enabled = true;
            txtPWD.Enabled = true;
            txtPWD.Visible = true;
            lblPWD.Visible = true;
            lblJob.Text = "Alter";
            lblSave.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Click_Cancel();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if ((txtAssesorCode.Text.Trim() == "") && (txtAssesorName.Text.Trim() == "") && (txtAssesorLocation.Text.Trim() == ""))
            {
                return;
            }

            DtSearch = AIS.SelectDataAssesor(txtAssesorCode.Text.Trim() == "" ? "-" : txtAssesorCode.Text, txtAssesorName.Text.Trim() == "" ? "-" : txtAssesorName.Text, txtAssesorLocation.Text.Trim() == "" ? "-" : txtAssesorLocation.Text, "SEARCH");
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssesorInsert.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (lblJob.Text == "AddNew")
            {
                DataTable Save = AIS.InsertAssesorDetails(txtAsseName.Text.Trim() == "" ? "-" : txtAsseName.Text, txtContact.Text.Trim() == "" ? "-" : txtContact.Text, txtLocation.Text.Trim() == "" ? "-" : txtLocation.Text, txtAddress.Text.Trim() == "" ? "-" : txtAddress.Text, ddlPosition.SelectedItem.Text, txtEmiNo.Text.Trim() == "" ? "-" : txtEmiNo.Text);
                foreach (DataRow dr in Save.Rows)
                {
                    AssesorCode = Convert.ToString(dr[0]);
                    Results = Convert.ToString(dr[1]);
                }

                if (Results.ToString() == "Record sucessfully saved.")
                {
                    lblSave.Visible = true;
                    From_Load();
                    lblSave.Text = "User Code & Passowrd is : " + AssesorCode ;
                }
                else
                {
                    lblSave.Visible = true;
                    lblSave.Text = Results.ToString();
                    return;
                }
            }
            else
            {
                DataTable Alter = AIS.UpdateAssesorDetails(txtAsseName.Text.Trim() == "" ? "-" : txtAsseName.Text, txtContact.Text.Trim() == "" ? "-" : txtContact.Text, txtLocation.Text.Trim() == "" ? "-" : txtLocation.Text, txtAddress.Text.Trim() == "" ? "-" : txtAddress.Text, ddlPosition.SelectedItem.Text, txtEmiNo.Text.Trim() == "" ? "-" : txtEmiNo.Text, lblUser.Text, txtPWD.Text.Trim() == "" ? "-" : txtPWD.Text);
                foreach (DataRow dr in Alter.Rows)
                {
                    AssesorCode = Convert.ToString(dr[0]);
                    Results = Convert.ToString(dr[1]);
                }

                if (Results.ToString() == "Record sucessfully updated.")
                {
                    lblSave.Visible = true;
                    From_Load();
                    lblSave.Text = Results.ToString();
                }
                else
                {
                    lblSave.Visible = true;
                    lblSave.Text = Results.ToString();
                    return;
                }
            }
        }

        protected void grdJob_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Assesor Code";
                e.Row.Cells[2].Text = "Assesor Name";
                e.Row.Cells[3].Text = "Contact";
                e.Row.Cells[4].Text = "Location";

            }

        }

        protected void grdJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblUser.Text = grdJob.SelectedRow.Cells[1].Text;
            txtAsseName.Text = grdJob.SelectedRow.Cells[2].Text;
            txtContact.Text = grdJob.SelectedRow.Cells[3].Text;
            txtLocation.Text = grdJob.SelectedRow.Cells[4].Text;

            DtSearch = AIS.SelectDataAssesor(grdJob.SelectedRow.Cells[1].Text, "", "", "NON SEARCH");

            foreach (DataRow dr in DtSearch.Rows)
            {
                txtEmiNo.Text = Convert.ToString(dr[7]);
                txtPWD.Text = Convert.ToString(dr[4]);
                txtAddress.Text = Convert.ToString(dr[5]);
                ddlPosition.Text = Convert.ToString(dr[6]);
            }

            Click_Alter();
        }
    }
}