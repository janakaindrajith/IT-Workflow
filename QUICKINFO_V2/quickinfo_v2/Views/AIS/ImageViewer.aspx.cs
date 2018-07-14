using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using quickinfo_v2.Connectivity;
using System.Data;

namespace HNBAPhotoGallery
{
    public partial class ImageViewer : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        DataTable Data;
        OracleConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                lblAlbumID.Text = Request.Params["albumId"].ToString();

            }

            if (Request.Params["albumId"] != null)
            {
                if (Request.Params["albumId"] != "")
                {
                    loadAlbumDetails(Request.Params["albumId"].ToString());
                    loadImageGallery(Request.Params["albumId"].ToString());
                }
            }

        }

        private void loadAlbumDetails(string albumId)
        {
            try
            {
                Data = Main.SelectReferanceData("AIS_LOAD_IMAGE_DETAIL", albumId, "");

                foreach (DataRow dr in Data.Rows)
                {
                    lblAlbumTitle.Text = "Job No - " + dr[0].ToString();
                    lblAlbumDescription.Text = "Inspection Type - " + dr[1].ToString();
                }

            }
            catch (Exception ee)
            {

            }
            finally
            {

            }
        }
        private void loadImageGallery(string albumId)
        {
            try
            {
                string imageGalleryText = "";

                Data = Main.SelectReferanceData("AIS_LOAD_IMAGE_GALLERY", albumId, "");

                foreach (DataRow dr in Data.Rows)
                {
                    string imageId = "";
                    imageId = dr[0].ToString();
                    imageGalleryText = imageGalleryText + " <li><a href=\"#\">    <img src='ImageThumb.aspx?albumId=" + albumId + "&imageId=" + imageId + "' data-large='GalleryImage.aspx?albumId=" + albumId + "&imageId=" + imageId + "' /></a></li>";
                }

                ltrlImageGallery.Text = imageGalleryText;
            }
            catch (Exception ee)
            {

            }
            finally
            {

            }
        }

    }
}