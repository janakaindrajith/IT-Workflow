using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace HNBAPhotoGallery
{
    public partial class ImageThumb : System.Web.UI.Page
    {
        OracleConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());

            }
            if (Request.Params["albumId"] != null || Request.Params["imageId"] != null)
            {
                if (Request.Params["albumId"] != "" || Request.Params["imageId"] != "")
                {
                    loadImage(Request.Params["albumId"].ToString(), Request.Params["imageId"].ToString());
                }
            }


        }

        private void loadImage(string albumId, string imageId)
        {
            try
            {
               // con = new OracleConnection(ConfigurationManager.ConnectionStrings["ORAWF"].ToString());


                con.Open();
                OracleDataReader dr;

                //con.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                String selectQuery = "";
                selectQuery = "SELECT AA.THUMBNAIL FROM AIS_IMAGES AA " +
                          " WHERE AA.ACCID=" + albumId + " AND AA.ID=" + imageId;

                cmd.CommandText = selectQuery;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["THUMBNAIL"] != System.DBNull.Value)
                    {
                        OracleBlob blob = dr.GetOracleBlob(0);
                        Response.ContentType = "image/jpeg";
                        Response.BinaryWrite(blob.Value);
                        Response.End();
                    }
                }

                dr.Close();
                dr.Dispose();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ee)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}