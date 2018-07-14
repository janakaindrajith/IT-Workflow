﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IT_WF_Dashboard_New.aspx.cs" Inherits="quickinfo_v2.Views.ITWorkflow.IT_WF_Dashboard_New" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript">
        function GridSelectAllColumn(spanChk) {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0]; xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++) {
                if (elm[i].type === 'checkbox' && elm[i].checked != xState)
                    elm[i].click();
            }
        }

    </script>





    <style>
        .page-container .main-content {
            position: relative;
            float: left;
            width: 100%;
            padding: 20px;
            z-index: 2;
            background: white; /*rgba(48, 54, 65, 0.13) !important;*/
            -webkit-box-sizing: border-box;
            -moz-box-sizing: border-box;
            box-sizing: border-box;
        }


        a.list-group-item.active,
        a.list-group-item.active:hover,
        a.list-group-item.active:focus {
            z-index: 2;
            color: #ffffff;
            background-color: #18639b !important;
            border-color: #18639b !important;
        }

        .list-group-item_sm {
            position: relative !important;
            display: block !important;
            padding: 10px 15px !important;
            margin-bottom: -1px !important;
            background-color: #ffffff !important;
            border: 1px solid #dddddd !important;
            width: 120px;
        }

            .list-group-item_sm:hover {
                position: relative !important;
                display: block !important;
                padding: 10px 15px !important;
                margin-bottom: -1px !important;
                background-color: #d3d3d3 !important;
                border: 1px solid #dddddd !important;
                width: 120px;
            }


        a.list-group-item_sm.active,
        a.list-group-item_sm.active:hover,
        a.list-group-item_sm.active:focus {
            z-index: 2;
            color: #ffffff;
            background-color: #ff6a00 !important;
            border-color: #ff6a00 !important;
        }

        .lable_margin_non_IT {
            margin-right: 15px;
            text-align: right;
            font-weight: bold;
            color: #13316f;
            padding: 67px 190px 15px 160px;
            /*padding: 67px 190px 0px 110px;*/
        }

        .lable_margin {
            margin-right: 15px;
            text-align: right;
            font-weight: bold;
            color: #13316f;
            /*padding: 67px 190px 15px 160px;*/
            padding: 67px 190px 0px 110px;
        }

        .lable_margin_lg {
            margin-right: 15px;
            text-align: right;
            font-weight: bold;
            color: #13316f;
            padding: 17px 50px 5px 50px;
        }

        .lable_margin_non_it {
            text-align: right;
            font-weight: bold;
            color: #13316f;
            padding: 67px 190px 0px 110px;
        }

        .outer_div {
            background-color: white;
            width: 170px;
            min-width: 165px;
            height: 60px; /*100px;*/
            float: left;
            margin-left: 20px;
            margin-top: 10px;
        }

        .inner_lable {
            background-color: #18639b;
            width: 120px;
            height: 60px;
            float: left;
            /*padding: 18px 4px 10px 4px;*/
            color: white;
            font-size: 12px;
            text-align: center;
        }

        .inner_value {
            background-color: white;
            width: 45px;
            height: 60px;
            float: left;
            padding: 18px 4px 10px 15px;
            border-style: solid;
            border-width: 1px;
            border-color: #21a9e1;
            font-size: 16px;
            font-weight: 400;
            color: #ff6a00;
        }



        .lb {
            padding: 10px 180px 10px 0px;
            margin-bottom: -1px;
        }

            .lb:hover {
                padding: 10px 180px 10px 0px;
                margin-bottom: -1px;
            }



        /*----------------------------Grid View Style-----------*/

        .HiddenCol {
            display: none;
        }


        .mGrid {
            width: 100%;
            background-color: #fff;
            margin: 2px 0 7px 0;
            border: solid 1px #e0e0e0;
            border-collapse: collapse;
            line-height: 12px;
        }

            .mGrid td {
                padding: 8px;
                border: solid 1px rgba(193, 193, 193, 0.36);
                color: #717171;
                font-size: small;
            }


            .mGrid th {
                padding: 12px 5px;
                color: #fff;
                background: #053b50;
                /*border-left: solid 1px rgba(255, 193, 79, 0.63);
                border-right-color: rgba(255, 193, 79, 0.63);*/
                line-height: 1.5;
                font-size: small;
                /*border-radius:3px;*/
                font-stretch: ultra-expanded;
            }

            .mGrid .alt {
                background: #fcfcfc url(grd_alt.png) repeat-x top;
            }

            .mGrid .pgr {
                background: #424242 url(grd_pgr.png) repeat-x top;
            }

                .mGrid .pgr table {
                    margin: 3px 0;
                }

                .mGrid .pgr td {
                    border-width: 0;
                    padding: 0 3px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .mGrid .pgr a {
                    color: #666;
                    text-decoration: none;
                }

                    .mGrid .pgr a:hover {
                        color: #000;
                        text-decoration: none;
                    }

        /*-----------------------------------------------------------------------------------------*/
        .usr_info_purple {
            border-left: 5px solid #9b00d0;
        }

        .usr_info {
            border-left: 5px solid #42A948;
        }

        .usr_attention {
            border-left: 5px solid #a94442;
        }

        .usr_info_hdr {
            background-color: #a94442;
        }

        .usr_attention_hdr {
            background-color: #a94442;
        }

        .list-group-item {
            position: relative !important;
            display: block !important;
            padding: 10px 15px !important;
            margin-bottom: -1px !important;
            background-color: #ffffff !important;
            border: 1px solid #dddddd !important;
        }

            .list-group-item:hover {
                position: relative !important;
                display: block !important;
                padding: 10px 15px !important;
                margin-bottom: -1px !important;
                background-color: #d3d3d3 !important;
                border: 1px solid #dddddd !important;
            }


        .subTopic {
            margin-left: 100px;
            font-family: 'Bradley Hand ITC';
            font-size: medium;
            text-decoration: underline;
        }

        .grdViewAlignments {
            padding: 10px 10px 10px 10px;
            margin-left: 50px;
            margin-right: 50px;
        }










        /*----------------------------------------------------*/



        .outer_box {
            height: 125px;
            min-height: 100px;
            background-color: #f5f5f5;
            box-shadow: 3px 2px 5px #a09f9f;
            position: relative;
            position: relative;
            margin-right: 100px;
            /*margin-top: -44px;*/
            color: #058196; /*#058196;*/
            font-size: large;
            font-stretch: ultra-expanded;
            font-family: sans-serif;
        }

        .outer_box_md {
            height: 100px;
            min-height: 100px;
            background-color: #f5f5f5;
            box-shadow: 3px 2px 5px #a09f9f;
            position: relative;
            position: relative;
            margin-right: 100px;
            /*margin-top: -44px;*/
            color: #058196; /*#058196;*/
            font-size: large;
            font-stretch: ultra-expanded;
            font-family: sans-serif;
        }

        .box {
            height: 125px;
            min-height: 100px;
            background-color: #f5f5f5;
            padding: 10px 15px 10px 15px;
            text-align: center;
            /*font-weight: 100;*/
            /*font-stretch: normal;*/
            /*box-shadow: 3px 2px 5px #a09f9f;*/
            color: #058196; /*#058196;*/
            font-size: large;
            font-stretch: ultra-expanded;
            font-family: sans-serif;
        }

            .box:hover {
                height: 125px;
                min-height: 100px;
                background-color: #ff6a00;
                padding: 10px 15px 10px 15px;
                text-align: center;
                font-weight: 100;
                font-stretch: normal;
                color: #058196; /*#058196;*/
                font-size: large;
                font-stretch: ultra-expanded;
                font-family: sans-serif;
            }


        .box_summary {
            background-color: #058196;
        }

        .white_lables {
            color: white;
        }

        .verticalLine {
            border-right: 1px solid #c7c7c7;
        }

        hr.style-two {
            border: 0;
            height: 1px;
            background-image: linear-gradient(to right, rgba(0, 0, 0, 0), rgba(0, 0, 0, 0.75), rgba(0, 0, 0, 0));
        }

        hr.style-four {
            border: 0;
            height: 1px;
            background-image: linear-gradient(to right, rgba(0, 0, 0, 0), rgba(253, 95, 2, 0.87), rgba(0, 0, 0, 0));
        }

        hr.style-one {
            border: 0;
            height: 1px;
            background-color: #ff6a00;
        }

        .value_box {
            height: 100px;
            min-height: 40px;
            background-color: #f5f5f5;
            padding: 10px 15px 10px 15px;
            text-align: center;
            font-weight: 100;
            font-stretch: normal;
        }

            .value_box:hover {
                height: 100px;
                min-height: 40px;
                background-color: #ff6a00;
                padding: 10px 15px 10px 15px;
                text-align: center;
                font-weight: 100;
                font-stretch: normal;
            }


        .circleBase {
            border-radius: 50%;
            behavior: url(PIE.htc); /* remove if you don't care about IE8 */
        }



        .circleBase_properties {
            padding: 10px;
            width: 50px;
            height: 50px;
            background: none;
            border: 1px solid #ff6a00;
            text-align: center;
            color: #18639b;
        }

            .circleBase_properties:hover {
                padding: 10px;
                width: 50px;
                height: 50px;
                background: #ff6a00;
                /*border: 1px solid blue;*/
                text-align: center;
            }

        .circleBase_properties_selected {
            padding: 10px;
            width: 50px;
            height: 50px;
            border: 1px solid #ff6a00;
            text-align: center;
            color: #18639b;
            background-color: #ff6a00;
        }





        /*popup*/

        .popup_topic {
            font-family: 'Microsoft JhengHei';
            color: white;
            font-weight: bold;
        }

        .popup_sub_topic {
            font-family: 'Microsoft JhengHei';
            color: #ff6a00;
            font-size: 15px;
            font-weight: bold;
        }

        .modal-backdrop.in {
            -webkit-opacity: 0.5;
            -moz-opacity: 0.5;
            opacity: 0.5;
            -ms-filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=50);
            filter: alpha(opacity=50);
        }

        .modal-backdrop.fade {
            -webkit-opacity: 0;
            -moz-opacity: 0;
            opacity: 0;
            -ms-filter: progid:DXImageTransform.Microsoft.Alpha(Opacity=0);
            filter: alpha(opacity=0);
        }

        .fade.in {
            background-color: rgba(48, 54, 65, 0.73) !important;
            opacity: 1;
        }

        .modal-backdrop {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: -1030 !important;
            background-color: #000000;
            overflow: hidden;
        }

        .fade {
            opacity: 0;
            -webkit-transition: opacity 0.15s linear;
            -moz-transition: opacity 0.15s linear;
            -o-transition: opacity 0.15s linear;
            transition: opacity 0.15s linear;
        }

        .modal.in .modal-dialog {
            width: 1300px !important;
        }

        .modal-header {
            /*#053b50*/
            background: #ff6a00 !important;
            padding: 15px;
            /*border-bottom: 1px solid #ff6a00 !important;*/
            /*min-height: 16px;*/
            color: #ffffff !important;
            font-size: medium !important;
            font-stretch: ultra-expanded !important;
        }

        .modal.gray .modal-dialog .modal-content .modal-header h4 {
            color: #ffffff !important;
        }

        .modal-content {
            position: relative !important;
            /*background-color: #ffffff !important;*/
            border: none !important;
            border-radius: 3px !important;
            background-clip: padding-box !important;
            outline: none !important;
        }





        .table {
            width: 100% !important;
            max-width: 100% !important;
            margin-bottom: 1rem !important;
        }

            .table th,
            .table td {
                padding: 0.75rem !important;
                vertical-align: top !important;
                border-top: 1px solid #eceeef !important;
            }

            .table thead th {
                vertical-align: bottom !important;
                border-bottom: 2px solid #eceeef !important;
            }

            .table tbody + tbody {
                border-top: 2px solid #eceeef !important;
            }

            .table .table {
                background-color: #fff !important;
            }

        .table-sm th,
        .table-sm td {
            padding: 0.3rem !important;
        }

        .table-bordered {
            border: 1px solid #eceeef !important;
        }

            .table-bordered th,
            .table-bordered td {
                border: 1px solid #eceeef !important;
            }

            .table-bordered thead th,
            .table-bordered thead td {
                border-bottom-width: 2px !important;
            }

        .table-striped tbody tr:nth-of-type(odd) {
            background-color: rgba(0, 0, 0, 0.05) !important;
        }

        .table-hover tbody tr:hover {
            background-color: rgba(0, 0, 0, 0.075) !important;
        }

        .table-active,
        .table-active > th,
        .table-active > td {
            background-color: rgba(0, 0, 0, 0.075) !important;
        }

        .table-hover .table-active:hover {
            background-color: rgba(0, 0, 0, 0.075) !important;
        }

            .table-hover .table-active:hover > td,
            .table-hover .table-active:hover > th {
                background-color: rgba(0, 0, 0, 0.075) !important;
            }

        .table-success,
        .table-success > th,
        .table-success > td {
            background-color: #dff0d8 !important;
        }

        .table-hover .table-success:hover {
            background-color: #d0e9c6 !important;
        }

            .table-hover .table-success:hover > td,
            .table-hover .table-success:hover > th {
                background-color: #d0e9c6 !important;
            }

        .table-info,
        .table-info > th,
        .table-info > td {
            background-color: #d9edf7 !important;
        }

        .table-hover .table-info:hover {
            background-color: #c4e3f3 !important;
        }

            .table-hover .table-info:hover > td,
            .table-hover .table-info:hover > th {
                background-color: #c4e3f3 !important;
            }

        .table-warning,
        .table-warning > th,
        .table-warning > td {
            background-color: #fcf8e3 !important;
        }

        .table-hover .table-warning:hover {
            background-color: #faf2cc !important;
        }

            .table-hover .table-warning:hover > td,
            .table-hover .table-warning:hover > th {
                background-color: #faf2cc !important;
            }

        .table-danger,
        .table-danger > th,
        .table-danger > td {
            background-color: #f2dede !important;
        }

        .table-hover .table-danger:hover {
            background-color: #ebcccc !important;
        }

            .table-hover .table-danger:hover > td,
            .table-hover .table-danger:hover > th {
                background-color: #ebcccc !important;
            }

        .thead-inverse th {
            color: #fff !important;
            background-color: #292b2c !important;
        }

        .thead-default th {
            color: #464a4c !important;
            background-color: #eceeef !important;
        }

        .table-inverse {
            color: #fff !important;
            background-color: #292b2c !important;
        }

            .table-inverse th,
            .table-inverse td,
            .table-inverse thead th {
                border-color: #fff !important;
            }

            .table-inverse.table-bordered {
                border: 0 !important;
            }

        .table-responsive {
            display: block !important;
            width: 100% !important;
            overflow-x: auto !important;
            -ms-overflow-style: -ms-autohiding-scrollbar !important;
        }

            .table-responsive.table-bordered {
                border: 0 !important;
            }

        .button_labels {
            color: #058196; /*#058196;*/
            font-size: large;
            font-stretch: ultra-expanded;
            font-family: sans-serif;
        }

        .small_labels {
            color: #058196; /*#058196; 058196*/
            font-size: 12px;
            font-stretch: ultra-expanded;
            font-family: sans-serif;
        }

        .small_value_lables {
            color: #42bb0a; /*#058196; 058196*/
            font-size: 12px;
            font-stretch: ultra-expanded;
            font-family: sans-serif;
            font-weight: bold;
        }

        .controler_alignment {
            margin-top: 15px;
            margin-bottom: 15px;
        }

        .base_btn_hover {
            padding: 10px 0px 10px 0px;
        }

        .button_labels_medium {
            color: #058196; /*#058196;*/
            font-size: medium;
            font-stretch: ultra-expanded;
            font-family: sans-serif;
        }



        .value_box_warning {
            height: 100px;
            min-height: 40px;
            background-color: rgba(255, 162, 0, 0.41);
            padding: 10px 15px 10px 15px;
            text-align: center;
            font-weight: 100;
            font-stretch: normal;
            color: #380c69 !important;
        }

            .value_box_warning:hover {
                height: 100px;
                min-height: 40px;
                background-color: #ff6a00;
                padding: 10px 15px 10px 15px;
                text-align: center;
                font-weight: 100;
                font-stretch: normal;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%--</div>--%>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div id="err_msg_div" runat="server" visible="false">
                    <asp:Label ID="lbl_err_msg" runat="server" Text=""></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <asp:UpdatePanel ID="UpdatePanel_IT_usr_hdr" runat="server">
                <ContentTemplate>
                    <%--<asp:Timer ID="Timer_IT_Panel" runat="server" Interval="55000" OnTick="Timer_IT_Panel_Tick" />--%>



                    <div class="container">
                        <div class="outer_box">
                            <%--Total Job Requests--%>
                            <div class="col-md-2 verticalLine box">
                                <%--<div class="box">--%>
                                <h3>
                                    <asp:Label ID="Label1" runat="server" Text="Jobs Available" CssClass="button_labels"></asp:Label></h3>
                                <hr class="hr.style-two" />
                                <asp:LinkButton ID="lb_notTakenJobs_All" runat="server" OnClick="lb_notTakenJobs_All_Click">
                                    <asp:Label ID="lbl_count_notTaken_jobs" runat="server" Text="0" CssClass="lable_margin_lg button_labels"></asp:Label>
                                </asp:LinkButton>

                            </div>

                            <%--System Wise Job Requests--%>
                            <div class="col-md-2 verticalLine box">
                                <%--<div class="box">--%>
                                <h3>
                                    <asp:Label ID="Label2" runat="server" Text="System Wise" CssClass="button_labels"></asp:Label></h3>
                                <hr class="hr.style-two" />
                                <asp:LinkButton ID="lb_notTakenJobs_systemWise" runat="server" OnClick="lb_notTakenJobs_systemWise_Click">
                                    <asp:Label ID="lbl_jobs_systemwise_count" CssClass="lable_margin_lg button_labels" runat="server" Text="0"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--User Summary--%>
                            <div class="col-md-4 verticalLine box">
                                <%--<div class="box">--%>
                                <asp:Label ID="Label3" runat="server" Text="Dashboard View As" CssClass="button_labels"></asp:Label>
                                <%--<hr class="hr.style-two" />--%>

                                <asp:DropDownList ID="ddl_filter_by_users" runat="server" CssClass="form-control controler_alignment" AutoPostBack="True" OnSelectedIndexChanged="ddl_filter_by_users_SelectedIndexChanged"></asp:DropDownList>

                                <%--Currently Handling Status--%>

                                <div class="row">
                                    <%--Total Jobs--%>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label4" runat="server" Text="Assigned: " CssClass="small_labels"></asp:Label><asp:Label ID="lbl_HANDLING_JOBS" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                    <%--Closed Form IT--%>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label5" runat="server" Text="Closed: " CssClass="small_labels"></asp:Label><asp:Label ID="lbl_CLOSED_FROM_IT" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                    <%--Closed Complete--%>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label7" runat="server" Text="Confirmed: " CssClass="small_labels"></asp:Label><asp:Label ID="lbl_COMPLETED_JOBS" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                </div>

                            </div>

                            <%--IT Division Summary--%>
                            <div class="col-md-4 verticalLine box">
                                <%--<asp:Label ID="Label32" runat="server" Text="IT Division Summary" CssClass="button_labels"></asp:Label>--%>
                                <%-- <hr class="hr.style-two" />--%>

                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label271" runat="server" Text="ER : " CssClass="small_labels"></asp:Label>
                                        <asp:Label ID="lbl_tot_er" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label291" runat="server" Text="SR : " CssClass="small_labels"></asp:Label>
                                        <asp:Label ID="lbl_tot_sr" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label31" runat="server" Text="CR : " CssClass="small_labels"></asp:Label>
                                        <asp:Label ID="lbl_tot_cr" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="lb_tot_processing_jobs" runat="server" CssClass="small_labels" OnClick="lb_tot_processing_jobs_Click">Processing Jobs:</asp:LinkButton>
                                        <asp:Label ID="lbl_tot_processing_jobs" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label ID="Label33" runat="server" Text="Approval Requested : " CssClass="small_labels"></asp:Label><asp:Label ID="lbl_tot_approval_req" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Label ID="Label30" runat="server" Text="Clarification Requested : " CssClass="small_labels"></asp:Label><asp:Label ID="lbl_tot_clarification_req" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:LinkButton ID="lb_tot_closed_confirmed_jobs" runat="server" CssClass="small_labels" OnClick="lb_tot_closed_confirmed_jobs_Click">Close Confirmed:</asp:LinkButton>
                                        <asp:Label ID="lbl_tot_closed_confirm" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>

                                </div>

                                                                <div class="row">
                                    <div class="col-md-8">
                                        <asp:LinkButton ID="lb_tot_closed_jobs" runat="server" CssClass="small_labels" OnClick="lb_tot_closed_jobs_Click">Close Confirmation Pending:</asp:LinkButton>
                                        <asp:Label ID="lbl_tot_closed_jobs_it" runat="server" Text="0" CssClass="small_value_lables"></asp:Label>
                                    </div>
                                </div>
                                <div>
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            &nbsp;
                            <asp:Timer ID="Timer1" runat="server" Interval="10000" OnTick="Timer1_Tick">
                            </asp:Timer>
                        </div>

                        <%--Base Buttons Panel--%>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-lg-1">
                                    <div class="circleBase circleBase_properties" id="div_er_base" runat="server">
                                        <h5>
                                            <asp:LinkButton ID="lb_ER_Base" runat="server" OnClick="lb_ER_Base_Click" CssClass="base_btn_hover">ER</asp:LinkButton>
                                        </h5>
                                    </div>
                                </div>
                                <div class="col-lg-1">
                                    <div class="circleBase circleBase_properties" id="div_sr_base" runat="server">
                                        <h5>
                                            <asp:LinkButton ID="lb_SR_Base" runat="server" OnClick="lb_SR_Base_Click" CssClass="base_btn_hover">SR</asp:LinkButton>
                                            <%--<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#sample-modal-dialog-1">Open Large Modal</button>--%>
                                        </h5>
                                    </div>
                                </div>
                                <div class="col-lg-1">
                                    <div class="circleBase circleBase_properties" id="div_cr_base" runat="server">
                                        <h5>
                                            <asp:LinkButton ID="lb_CR_Base" runat="server" CssClass="base_btn_hover" OnClick="lb_CR_Base_Click">CR</asp:LinkButton>
                                        </h5>
                                    </div>
                                </div>

                                <div class="col-md-1">
                                    &nbsp;
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            &nbsp;
                        </div>



                        <%--Sub Button Panel--%>
                        <div class="outer_box_md">
                            <%--TAKEN AND ASSIGN BASE BUTTON--%>
                            <div class="col-lg-3 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label6" runat="server" Text="Taken And Assign" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <%--ER-VALUE--%>
                                <asp:LinkButton ID="lb_taken_and_assign_ER_IT" runat="server" OnClick="lb_taken_and_assign_ER_IT_Click">
                                    <asp:Label ID="lbl_er_taken_and_assign" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--SR-VALUE--%>
                                <asp:LinkButton ID="lb_taken_and_assign_SR_IT" runat="server" OnClick="lb_taken_and_assign_SR_IT_Click">
                                    <asp:Label ID="lbl_sr_taken_and_assign" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--CR-VALUE--%>
                                <asp:LinkButton ID="lb_taken_and_assign_CR_IT" runat="server" OnClick="lb_taken_and_assign_CR_IT_Click">
                                    <asp:Label ID="lbl_cr_taken_and_assign" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                            </div>

                            <%--CLARIFICATION REQUESTED JOBS BASE BUTTON--%>
                            <div class="col-lg-3 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label8" runat="server" Text="Clarification Requested Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <%--ER-VALUE--%>
                                <asp:LinkButton ID="lb_clarification_requested_ER_IT" runat="server" OnClick="lb_clarification_requested_ER_IT_Click">
                                    <asp:Label ID="lbl_er_pending_clarification" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--SR-VALUE--%>
                                <asp:LinkButton ID="lb_clarification_requested_jobs_SR_IT" runat="server" OnClick="lb_clarification_requested_jobs_SR_IT_Click">
                                    <asp:Label ID="lbl_sr_pending_clarification" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--CR-VALUE--%>
                                <asp:LinkButton ID="lb_clarification_requested_jobs_CR_IT" runat="server" OnClick="lb_clarification_requested_jobs_CR_IT_Click">
                                    <asp:Label ID="lbl_cr_pending_clarification" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--CLARIFICATION COMPLETE JOBS BASE BUTTON--%>
                            <div class="col-lg-3 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label9" runat="server" Text="Clarification Complete Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <%--ER-VALUE--%>
                                <asp:LinkButton ID="lb_clarification_completed_jobs_ER_IT" runat="server" OnClick="lb_clarification_completed_jobs_ER_IT_Click">
                                    <asp:Label ID="lbl_er_clarification_complete" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--SR-VALUE--%>
                                <asp:LinkButton ID="lb_clarification_complete_jobs_SR_IT" runat="server" OnClick="lb_clarification_complete_jobs_SR_IT_Click">
                                    <asp:Label ID="lbl_sr_clarification_complete" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--CR-VALUE--%>
                                <asp:LinkButton ID="lb_clarification_complete_jobs_CR_IT" runat="server" OnClick="lb_clarification_complete_jobs_CR_IT_Click">
                                    <asp:Label ID="lbl_cr_clarification_complete" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--CLOSED JOBS--%>
                            <div class="col-lg-3 value_box">
                                <h4>
                                    <asp:Label ID="Label28" runat="server" Text="Closed Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <%--ER-VALUE--%>
                                <asp:LinkButton ID="lb_closed_by_it_jobs_ER_IT" runat="server" OnClick="lb_closed_by_it_jobs_ER_IT_Click">
                                    <asp:Label ID="lbl_er_closed_by_it" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--SR-VALUE--%>
                                <asp:LinkButton ID="lb_closed_by_it_jobs_SR_IT" runat="server" OnClick="lb_closed_by_it_jobs_SR_IT_Click">
                                    <asp:Label ID="lbl_sr_closed_by_it" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--CR-VALUE--%>
                                <asp:LinkButton ID="lb_closed_by_it_jobs_CR_IT" runat="server" OnClick="lb_closed_by_it_jobs_CR_IT_Click">
                                    <asp:Label ID="lbl_cr_closed_by_it" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>
                        </div>

                        <div class="row">
                            &nbsp;
                        </div>
                        Approval Requested By IT

                        <div class="outer_box_md">
                            <%--APPROVAL REQUESTED JOBS BASE BUTTON--%>
                            <div class="col-lg-3 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label10" runat="server" Text="Approval Requested Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <%--ER-VALUE--%>
                                <asp:LinkButton ID="lb_approval_requested_jobs_ER_IT" runat="server" Enabled="false">
                                    <asp:Label ID="lbl_er_approval_requested" runat="server" Text="N/A" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                                <%--SR-VALUE--%>
                                <asp:LinkButton ID="lb_approval_requested_jobs_SR_IT" runat="server" OnClick="lb_approval_requested_jobs_SR_IT_Click">
                                    <asp:Label ID="lbl_sr_approval_requested" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--CR-VALUE--%>
                                <asp:LinkButton ID="lb_approval_requested_jobs_CR_IT" runat="server" OnClick="lb_approval_requested_jobs_CR_IT_Click">
                                    <asp:Label ID="lbl_cr_approval_requested" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--APPROVED JOBS BASE BUTTON--%>
                            <div class="col-lg-3 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label11" runat="server" Text="Approved Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <%--ER-VALUE--%>
                                <asp:LinkButton ID="lb_approved_jobs_ER_IT" runat="server" Enabled="false">
                                    <asp:Label ID="lbl_er_approved" runat="server" Text="N/A" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                                <%--SR-VALUE--%>
                                <asp:LinkButton ID="lb_approved_jobs_SR_IT" runat="server" OnClick="lb_approved_jobs_SR_IT_Click">
                                    <asp:Label ID="lbl_sr_approved" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--CR-VALUE--%>
                                <asp:LinkButton ID="lb_approved_jobs_CR_IT" runat="server" OnClick="lb_approved_jobs_CR_IT_Click">
                                    <asp:Label ID="lbl_cr_approved" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--RE-OPENED JOBS BASE BUTTON--%>
                            <div class="col-lg-3 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label12" runat="server" Text="Reopened Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <%--ER-VALUE--%>
                                <asp:LinkButton ID="lb_reopened_jobs" runat="server" OnClick="lb_reopened_jobs_Click">
                                    <asp:Label ID="lbl_er_reopen" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--SR-VALUE--%>
                                <asp:LinkButton ID="lb_re_opened_jobs_SR_IT" runat="server" OnClick="lb_re_opened_jobs_SR_IT_Click">
                                    <asp:Label ID="lbl_sr_reopend" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--CR-VALUE--%>
                                <asp:LinkButton ID="lb_re_opened_jobs_CR_IT" runat="server" OnClick="lb_re_opened_jobs_CR_IT_Click">
                                    <asp:Label ID="lbl_cr_reopend" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--RETURN JOBS--%>
                            <div class="col-lg-3 value_box">
                                <h4>
                                    <asp:Label ID="Label25" runat="server" Text="Returnd Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <%--ER-VALUE--%>
                                <asp:LinkButton ID="lb_er_returned_jobs_ER_IT" runat="server" OnClick="lb_er_returned_jobs_ER_IT_Click">
                                    <asp:Label ID="lbl_er_returned" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--SR-VALUE--%>
                                <asp:LinkButton ID="lb_sr_returned_jobs_SR_IT" runat="server" OnClick="lb_sr_returned_jobs_SR_IT_Click">
                                    <asp:Label ID="lbl_sr_returned" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>

                                <%--CR-VALUE--%>
                                <asp:LinkButton ID="lb_cr_returned_jobs_CR_IT" runat="server" OnClick="lb_cr_returned_jobs_CR_IT_Click">
                                    <asp:Label ID="lbl_cr_returned" runat="server" Text="0" CssClass="lable_margin button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>
                        </div>



                        <div class="row">
                            &nbsp;
                        </div>





                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="row" style="display: none">
            <asp:UpdatePanel ID="UpdatePanel_IT_user" runat="server">
                <ContentTemplate>
                    <div class="well well-sm">
                        <h4>Workflow Summary For IT User</h4>
                    </div>
                    <div class="container" style="display: none">

                        <%--<h4>IT Workflow Summary For IT-Users</h4>--%>
                        <div class="row">

                            <%--ER--%>
                            <div class="col-md-3">
                                <%--&PnlH_ID&PnlB_ID--%>

                                <%--data-toggle="modal" data-target="#myModal"--%>
                                <div class="list-group">
                                    <a href="#" class="list-group-item active">ER</a>


                                </div>
                            </div>

                            <%--SR--%>
                            <div class="col-md-3">
                                <div class="list-group">
                                    <a href="#" class="list-group-item active">SR</a>

                                    <a href="#">
                                        <asp:LinkButton ID="lb_complete_jobs_SR_IT" runat="server" class="list-group-item" OnClick="lb_complete_jobs_SR_IT_Click">Complete Jobs :<asp:Label ID="lbl_sr_complete" runat="server" Text="0" CssClass="lable_margin"></asp:Label></asp:LinkButton></a>


                                </div>
                            </div>

                            <%--CR--%>
                            <div class="col-md-3">
                                <div class="list-group">
                                    <a href="#" class="list-group-item active">CR</a>


                                </div>
                            </div>

                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%-- <hr />--%>


        <div class="row">
            <asp:UpdatePanel ID="UpdatePanel_Normal_user" runat="server">
                <ContentTemplate>

                    <div class="container">

                        <div>
                            <asp:Label ID="Label24" runat="server" Text="IT Work Flow Summary" CssClass="button_labels_medium"></asp:Label>
                            <hr class="hr style-four" />
                        </div>
                        <div class="outer_box_md">
                            <%--Total Requested Jobs--%>
                            <div class="col-lg-4 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label13" runat="server" Text="Total Requested Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />

                                <asp:LinkButton ID="lb_all_jobs" runat="server" OnClick="lb_all_jobs_Click">
                                    <asp:Label ID="lbl_all_jobs" runat="server" Text="0" CssClass="lable_margin_non_IT button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--Jobs Not Taken From IT--%>
                            <div class="col-lg-4 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label14" runat="server" Text="Jobs Not Accepted (IT)" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />
                                <asp:LinkButton ID="lb_not_taken_by_it" runat="server" OnClick="lb_not_taken_by_it_Click">
                                    <asp:Label ID="lbl_not_taken_by_it" runat="server" Text="0" CssClass="lable_margin_non_IT button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--Jobs Taken From IT--%>
                            <div class="col-lg-4 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label15" runat="server" Text="Jobs Accepted (IT)" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />

                                <asp:LinkButton ID="lb_taken_by_it" runat="server" OnClick="lb_taken_by_it_Click">
                                    <asp:Label ID="lbl_taken_by_it" runat="server" Text="0" CssClass="lable_margin_non_IT button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>
                        </div>

                        <div class="row">
                            &nbsp;
                        </div>

                        <div>
                            <asp:Label ID="Label22" runat="server" Text="Actions Taken (IT)" CssClass="button_labels_medium"></asp:Label>
                            <hr class="hr style-four" />
                        </div>

                        <%--Actions Taken Panel--%>
                        <div class="outer_box_md">
                            <%--Approval Requested--%>
                            <div class="col-lg-3 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label20" runat="server" Text="Approval Requested" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />

                                <asp:LinkButton ID="lb_pending_approval" runat="server" OnClick="lb_pending_approval_Click">
                                    <asp:Label ID="lbl_pending_approval" runat="server" Text="0" CssClass="lable_margin_non_it button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--Return Jobs--%>
                            <div class="col-lg-3 value_box verticalLine">
                                <h4>
                                    <asp:Label ID="Label21" runat="server" Text="Return Jobs" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />

                                <asp:LinkButton ID="lb_return" runat="server" OnClick="lb_return_Click">
                                    <asp:Label ID="lbl_return_by_it" runat="server" Text="0" CssClass="lable_margin_non_it button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>
                        </div>

                        <div class="row">
                            &nbsp;
                        </div>

                        <div>
                            <asp:Label ID="Label23" runat="server" Text="Actions Required" CssClass="button_labels_medium"></asp:Label>
                            <hr class="hr style-four" />
                        </div>

                        <%--Actions Required Panel--%>
                        <div class="outer_box_md">
                            <%--Close Confirmation--%>
                            <div class="col-lg-3 value_box_warning verticalLine">
                                <h4>
                                    <asp:Label ID="Label16" runat="server" Text="Close Confirmation" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />

                                <asp:LinkButton ID="lb_close_confirmed" runat="server" OnClick="lb_close_confirmed_Click">
                                    <asp:Label ID="lbl_close_confirmed" runat="server" Text="0" CssClass="lable_margin_non_it button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--To Clarify--%>
                            <div class="col-lg-3 value_box_warning verticalLine">
                                <h4>
                                    <asp:Label ID="Label17" runat="server" Text="To Clarify" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />

                                <asp:LinkButton ID="lb_pending_clarification" runat="server" OnClick="lb_pending_clarification_Click">
                                    <asp:Label ID="lbl_pending_clarification" runat="server" Text="0" CssClass="lable_margin_non_it button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--To Approve User Wise--%>
                            <div class="col-lg-3 value_box_warning verticalLine">
                                <h4>
                                    <asp:Label ID="Label18" runat="server" Text="To Approve (User Wise)" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />

                                <asp:LinkButton ID="lb_To_Approve" runat="server" OnClick="lb_To_Approve_Click">
                                    <asp:Label ID="lbl_to_approve" runat="server" Text="0" CssClass="lable_margin_non_it button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>

                            <%--To Approve Common--%>
                            <div class="col-lg-3 value_box_warning verticalLine">
                                <h4>
                                    <asp:Label ID="Label19" runat="server" Text="To Approve (ALL)" CssClass="button_labels_medium"></asp:Label></h4>
                                <hr class="hr.style-two" />

                                <asp:LinkButton ID="lb_To_Approve_Common" runat="server" OnClick="lb_To_Approve_Common_Click">
                                    <asp:Label ID="lbl_to_approve_common" runat="server" Text="0" CssClass="lable_margin_non_it button_labels"></asp:Label>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <!-- Modal (Skin gray) -->
        <div class="modal gray fade" id="sample-modal-dialog-3">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="lbl_main_topic" runat="server" Text="IT WORK FLOW JOB DETAIL" CssClass="popup_topic"></asp:Label></h4>
                    </div>

                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <h3>
                                    <asp:Label ID="lbl_popup_topic" runat="server" Text="" CssClass="popup_sub_topic"></asp:Label></h3>
                                <hr class="hr style-four" />

                                <asp:Panel ID="grd_non_it_user_jobs_Panel" runat="server" Height="300px" ScrollBars="Both">
                                    <asp:GridView ID="grd_non_it_user_jobs" runat="server" OnRowCommand="grd_non_it_user_jobs_RowCommand" OnRowDataBound="grd_non_it_user_jobs_RowDataBound" Width="100%" CssClass="table mGrid">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxselect" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:ButtonField CommandName="Select" Text="Job History" ButtonType="Link"></asp:ButtonField>
                                            <asp:ButtonField CommandName="continue" Text="Continue Process"></asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>

                                    <asp:GridView ID="grd_it_user_jobs" runat="server" CssClass="table mGrid" OnRowCommand="grd_it_user_jobs_RowCommand" OnRowDataBound="grd_it_user_jobs_RowDataBound">
                                        <Columns>
                                            <%--<asp:ButtonField CommandName="Select" Text="Take Job" ButtonType="Link">
                                                <ControlStyle Height="20px" Width="110px" />
                                                <ItemStyle Height="20px" Width="20px" />
                                            </asp:ButtonField>--%>
                                            <asp:TemplateField>
                                                <%--<HeaderTemplate>
                                                    <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick="GridSelectAllColumn(this);" />
                                                </HeaderTemplate>
                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="40px" />
                                                <ItemStyle HorizontalAlign="Left" VerticalASlign="Middle" Width="40px" />--%>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkboxselect" runat="server"></asp:CheckBox>
                                                </ItemTemplate>

                                            </asp:TemplateField>

                                            <asp:ButtonField CommandName="Select_History_For_IT" Text="History" ButtonType="Link"></asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>




                                    <asp:GridView ID="grd_it_user_jobs_historySS" runat="server" CssClass="table mGrid" OnRowCommand="grd_it_user_jobs_history_RowCommand" OnRowDataBound="grd_it_user_jobs_history_RowDataBound">
                                    </asp:GridView>





                                </asp:Panel>



                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <div class="row">
                            <div class="col-md-1">
                                <%--<button onclick="goBack();return false">Go Back</button>--%>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lbl_error" runat="server" Text="" Visible="false"></asp:Label>
                            </div>
                            <%--<div class="col-md-1"> <h5>Select User</h5></div>--%>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddl_reassignUsers" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <div class="col-md-2 pull-right">
                                <asp:Button ID="btn_take_job" runat="server" Text="Take Jobs" class="btn btn-primary" OnClick="btn_take_job_Click" />
                                <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>
                            </div>
                        </div>

                        <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                    </div>
                </div>
            </div>
        </div>

        <%--IT Summary Modal--%>
        <div class="modal gray fade" id="sample-modal-dialog-4">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="Label29" runat="server" Text="IT WORK FLOW DIVISION SUMMARY" CssClass="popup_topic"></asp:Label></h4>
                    </div>

                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>

                                <h3>
                                    <asp:Label ID="lbl_summary_topic" runat="server" Text="" CssClass="popup_sub_topic"></asp:Label></h3>


                                <hr class="hr style-four" />

                                <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Both">
                                    <asp:GridView ID="grd_it_summary" runat="server" Width="100%" CssClass="table mGrid" OnRowDataBound="grd_it_summary_RowDataBound">




                                        <%--janaka--%>
                                        <Columns>
                                            <asp:ButtonField CommandName="test1" Text="Job History" ButtonType="Link"></asp:ButtonField>
                                            <asp:ButtonField CommandName="test2" Text="Continue Process"></asp:ButtonField>
                                        </Columns>




                                    </asp:GridView>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Close</button>



                        <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                    </div>
                </div>
            </div>
        </div>


        <%--IT Summary History Modal--%>
        <div class="modal gray fade" id="sample-modal-dialog-5">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Label ID="Label26" runat="server" Text="JOB - HISTORY" CssClass="popup_topic"></asp:Label></h4>
                    </div>

                    <div class="modal-body">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>

                                <h3>
                                    <asp:Label ID="Label27" runat="server" Text="" CssClass="popup_sub_topic"></asp:Label></h3>
                                <hr class="hr style-four" />

                                <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Both">
                                    <asp:GridView ID="grd_it_user_jobs_history" runat="server" CssClass="table mGrid" OnRowCommand="grd_it_user_jobs_history_RowCommand" OnRowDataBound="grd_it_user_jobs_history_RowDataBound">
                                    </asp:GridView>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </div>
            </div>
        </div>


        <script>
            function error_msg_hidden() {
                document.getElementById("err_msg_div").style.visibility = "hidden";
            }

        </script>
    </form>

</asp:Content>