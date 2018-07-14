<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ImageViewer.aspx.cs" Inherits="HNBAPhotoGallery.ImageViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <link href="../../Styles/demo.css" rel="stylesheet" />
        <link href="../../Styles/elastislide.css" rel="stylesheet" />
        <link href="../../Styles/reset.css" rel="stylesheet" />
        <link href="../../Styles/style.css" rel="stylesheet" />

        <script src="../../javascripts/gallery.js"></script>
        <script src="../../javascripts/jquery.easing.1.3.js"></script>
        <script src="../../javascripts/jquery.elastislide.js"></script>
        <script src="../../javascripts/jquery.tmpl.min.js"></script>
        <script src="../../javascripts/jquery.easing.1.3.js"></script>

        <title>Responsive AIS Gallery</title>

        <meta charset="UTF-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
        <meta name="description" content="Responsive Image Gallery with jQuery" />
        <meta name="keywords" content="jquery, carousel, image gallery, slider, responsive, flexible, fluid, resize, css3" />
        <meta name="author" content="Codrops" />
        <link rel="shortcut icon" href="../favicon.ico">
        <noscript>
			<style>
			    .es-carousel ul {
			        display: block;
			    }
			</style>
		</noscript>
        <script id="img-wrapper-tmpl" type="text/x-jquery-tmpl">
            <div class="rg-image-wrapper">
                {{if itemsCount > 1}}
					<div class="rg-image-nav">
                        <a href="#" class="rg-image-nav-prev">Previous Image</a>
                        <a href="#" class="rg-image-nav-next">Next Image</a>
                    </div>
                {{/if}}
				<div class="rg-image"></div>
                <div class="rg-loading"></div>
                <div class="rg-caption-wrapper">
                    <div class="rg-caption" style="display: none;">
                        <p></p>
                    </div>
                </div>
            </div>
        </script>
    </head>
    <body>
        <div class="panel-body">
            <div class="panel-heading">
                <div class="clr"></div>
            </div>
            <!-- header -->

            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-body">
                    <h1>
                    <asp:Label ID="lblAlbumID" runat="server" Text="" Visible="false"></asp:Label>
                    <div class="form-group">
                        <div class="col-sm-5">
                                <asp:Label ID="lblAlbumTitle" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-5">
                                <asp:Label ID="lblAlbumDescription" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    </h1>
                    <a href="ImageSearch.aspx">                   
                    <button  class="btn btn-gold btn-icon icon-left btn-sm"  type="button" >
                    Close
                    <i class="entypo-cancel"></i>
                    </button>
                    </a>
                </div>
            </div>

            <div class="content">
                <div id="rg-gallery" class="rg-gallery">
                    <div class="rg-thumbs">
                        <!-- Elastislide Carousel Thumbnail Viewer -->
                        <div class="es-carousel-wrapper">
                            <div class="es-nav">
                                <span class="es-nav-prev">Previous</span>
                                <span class="es-nav-next">Next</span>
                            </div>
                            <div class="es-carousel">
                                <ul>
                                    <asp:Literal ID="ltrlImageGallery" runat="server"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                        <!-- End Elastislide Carousel Thumbnail Viewer -->
                    </div>
                    <!-- rg-thumbs -->
                </div>
                <!-- rg-gallery -->
                <p class="sub"><%-- TDA Powehttp--%></p>
            </div>
            <!-- content -->
        </div>
        <!-- container -->


        <script src='<%= Page.ResolveUrl("~/javascripts/jquery.min.js") %>'></script>
        <script src='<%= Page.ResolveUrl("~/javascripts/gallery.js") %>'></script>
        <script src='<%= Page.ResolveUrl("~/javascripts/jquery.easing.1.3.js") %>'></script>
        <script src='<%= Page.ResolveUrl("~/javascripts/jquery.elastislide.js") %>'></script>
        <script src='<%= Page.ResolveUrl("~/javascripts/jquery.tmpl.min.js") %>'></script>


    </body>
</asp:Content>
