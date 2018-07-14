using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;
using quickinfo_v2.Connectivity;

namespace quickinfo_v2.Views.AIS
{

    public partial class ImageUploadImages : System.Web.UI.Page
    {
        IT_WrokflowMainClass Main = new IT_WrokflowMainClass();
        AISMain AIS = new AISMain();
        Int32 AccidentAutoIncrementID = 0;
        string Results;
        Int32 record = 0;
        string imagetype;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblJobNo.Text = Session["JobNo"].ToString();
                lblimgtype.Text = Session["imgtype"].ToString();
                lblInspection.Text = Session["inspection"].ToString();
                lblIncrement.Text = Session["IncrementNo"].ToString();
                AccidentAutoIncrementID = Convert.ToInt32(lblIncrement.Text);
                imagetype = lblimgtype.Text;

                if (Request.QueryString["tid"] != null)
                {       
                    foreach (string s in Request.Files)
                    {
                        record = record + 1;
                        HttpPostedFile file = Request.Files[s];

                        int fileSizeInBytes = file.ContentLength;
                        string fileName = file.FileName;// Request.Headers["X-File-Name"];
                        string fileExtension = "";

                        if (!string.IsNullOrEmpty(fileName))
                            fileExtension = Path.GetExtension(fileName);

                        // IMPORTANT! Make sure to validate uploaded file contents, size, etc. to prevent scripts being uploaded into your web app directory
                        string savedFileName = Guid.NewGuid().ToString() + fileExtension;

                        BinaryReader bindata = new BinaryReader(file.InputStream);
                        byte[] thumbnail = null;
                        byte[] image = null;

                        thumbnail = getResizedImage(file, 0, 65);
                        image = getResizedImage(file, 0, 425);
                        saveImage(AccidentAutoIncrementID, imagetype, thumbnail, image);
                    }

                }

            }
        }

        private void saveImage(Int32 newAlbumId, string imagetype, byte[] thumbnail, byte[] image)
        {

            try
            {
                OracleConnection conProcess = new OracleConnection(ConfigurationManager.ConnectionStrings["CGConnectionString"].ToString());
                conProcess.Open();
                OracleCommand spProcess = null;
                int AppCode = 0;
                string strQuery = "";

                OracleParameter blobParameterThumb = new OracleParameter();
                OracleParameter blobParameterPhoto = new OracleParameter();

                strQuery = "INSERT INTO AIS_IMAGES(ID, ACCID, CREATED_DATE, TYPE, THUMBNAIL, PHOTO) VALUES (AIS_IMAGES_SEQ.NEXTVAL,";
                strQuery += "" + newAlbumId + ", ";
                strQuery += "SYSDATE, ";
                strQuery += "'" + imagetype + "', ";
                strQuery += ":thumb,";
                strQuery += ":photo)";

                blobParameterThumb.ParameterName = "thumb";
                blobParameterThumb.Direction = ParameterDirection.Input;

                blobParameterPhoto.ParameterName = "photo";
                blobParameterPhoto.Direction = ParameterDirection.Input;


                blobParameterThumb.Value = thumbnail;
                blobParameterPhoto.Value = image;



                spProcess = new OracleCommand(strQuery, conProcess);
                spProcess.Parameters.Add(blobParameterThumb);
                spProcess.Parameters.Add(blobParameterPhoto);


                spProcess.ExecuteNonQuery();
                conProcess.Close();
                conProcess.Dispose();
            }
            catch (Exception ex)
            {

            }

        }

        byte[] getResizedImage(HttpPostedFile uploaded, int width, int height)
        {
            Bitmap imgIn = new Bitmap(uploaded.InputStream);
            double y = imgIn.Height;
            double x = imgIn.Width;

            double factor = 1;
            if (width > 0)
            {
                factor = width / x;
            }
            else if (height > 0)
            {
                factor = height / y;
            }
            System.IO.MemoryStream outStream = new System.IO.MemoryStream();
            Bitmap imgOut = new Bitmap((int)(x * factor), (int)(y * factor));

            // Set DPI of image (xDpi, yDpi)
            imgOut.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(imgOut);
            g.Clear(Color.White);
            g.DrawImage(imgIn, new Rectangle(0, 0, (int)(factor * x), (int)(factor * y)),
              new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);

            imgOut.Save(outStream, getImageFormat(uploaded.FileName));

            imgIn.Dispose();
            return outStream.ToArray();
        }

        string getContentType(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp": return "Image/bmp";
                case ".gif": return "Image/gif";
                case ".jpg": return "Image/jpeg";
                case ".png": return "Image/png";
                default: break;
            }
            return "";
        }

        ImageFormat getImageFormat(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp": return ImageFormat.Bmp;
                case ".gif": return ImageFormat.Gif;
                case ".jpg": return ImageFormat.Jpeg;
                case ".png": return ImageFormat.Png;
                default: break;
            }
            return ImageFormat.Jpeg;
        }

    }
}