<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ImageUploadImages.aspx.cs" Inherits="quickinfo_v2.Views.AIS.ImageUploadImages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>

       
        <script src="../../javascripts/dropzone.js"></script>
        <script src="../../javascripts/dropzone-amd-module.js"></script>
        <link href="../../Styles/ImageUploaderStyle.css" rel="stylesheet" />
        <link href="../../Styles/basic.css" rel="stylesheet" />
        <link href="../../Styles/dropzone.css" rel="stylesheet" />

        <script type="text/javascript">
            Dropzone.options.myDropzone = {
                url: "ImageUploadImages.aspx?tid=<%=Request.QueryString["tid"]%>",
                // Prevents Dropzone from uploading dropped files immediately
                autoProcessQueue: false,

                init: function () {
                    var submitButton = document.querySelector("#submit-all")
                    myDropzone = this; // closure

                    submitButton.addEventListener("click", function () {

                        myDropzone.processQueue(); // Tell Dropzone to process all queued files.
                    });

                    // You might want to show the submit button only when 
                    // files are dropped here:
                    this.on("addedfile", function () {
                        // Show submit button here and/or inform user to click it.
                    });
                    this.on("processing", function () {
                        this.options.autoProcessQueue = true;
                    });

                    myDropzone.on("totaluploadprogress", function (totalPercentage, totalBytesToBeSent, totalBytesSent) {
                        if (totalPercentage >= 100 && totalBytesSent) {
                            alert('Photo upload successfully completed...');
                           
                            window.location.href = "ImageUpload.aspx";
                        }
                    });
                }

            };
        </script>

    </head>
    <body>


        <div id="wrapper" class="panel-body">
                <div style="padding: 5px" class="panel-body">
                    <div class="panel-body">
                        <div class="form-group">
                            <button id="submit-all" class="button">Upload Photos</button>
                        </div>

                        <div class="panel panel-primary" data-collapsed="0">
                            <div class="panel-heading">
                                <div class="panel-title">
                                    Upload Details
                                </div>
                            </div>

                            <div>
                                <a href="ImageUpload.aspx">                   
                                <button class="btn btn-gold btn-icon btn-sm" type="button">
                                Close
                                <i class="entypo-cancel"></i>
                                </button></a>
                            </div>


                            <div class="panel-body">
                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblJobNo" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-sm-3">
                                        <asp:Label ID="lblInspection" runat="server" ForeColor="Red" Visible="true"></asp:Label>
                                    
                                    </div>


                                </div>

                                <div class="form-group">
                                    <asp:Label ID="lblimgtype" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                    <asp:Label ID="lblIncrement" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <form action="/target" class="dropzone" id="my-dropzone">
                        </form>



                    </div>
                </div>
        </div>

    </body>
    </html>
</asp:Content>
