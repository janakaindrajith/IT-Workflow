<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ApproveRelease.aspx.cs" Inherits="quickinfo_v2.Views.ChangeManagement.ApproveRelease" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" class="form-horizontal form-groups-bordered" runat="server">
                        <div style="width: 80%; height: 30px;">
                <h3>Release Approval</h3>            
        </div>
        <div style="width: 100%; height: 20px;">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="panel panel-default">

            <div class="panel-heading">
                <div class="panel-title">
                    Search Change Requests
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
            <div class="panel-body">


                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Change ID</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtChangeID" runat="server" Width="99%" EmptyMessage="Enter Change ID...">
                        </telerik:RadTextBox>
                    </div>
                                        <div style="width: 15%; height: 30px; float: left;">Title</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="TxtTitleSch" runat="server" Width="99%" EmptyMessage="Enter Title...">
                        </telerik:RadTextBox>
                    </div>
                </div>
                                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Status</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlStatusSch" runat="server" Skin="Default" Width="99%">
                        </telerik:RadComboBox>
                    </div>
                                        <div style="width: 15%; height: 30px; float: left;">Request User</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRequestUserSch" runat="server" Skin="Default" Width="99%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="btnSearch1" runat="server" Text="Search"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnSearch1_Click" />
                        <asp:Button ID="btnClear1" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnClear1_Click" />


                    </div>
                </div>
                <div style="width: 100%;">

                    <style type="text/css">
                        .RadGrid_Default th.rgHeader {
                            background-image: none;
                            background-color: #35363A;
                        }

                        .RadGrid_Default .rgSelectedRow {
                            background-image: none;
                            background-color: white;
                            color: black;
                        }
                    </style>

                    <telerik:RadGrid ID="grdRequest" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" PageSize="5" OnItemCommand="grdRequest_ItemCommand" OnNeedDataSource="grdRequest_NeedDataSource">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter Select column" HeaderText="Select"
                                    UniqueName="Select">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkBtnSelect1" runat="server" CommandName="Select">Select</asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="REQUEST_ID" FilterControlAltText="Filter column5 column" HeaderText="Job Id" UniqueName="REQUEST_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter column column" HeaderText="Request Date" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REQUEST_USER" FilterControlAltText="Filter column1 column" HeaderText="Request User" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column2 column" HeaderText="Status" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TITLE" FilterControlAltText="Filter column3 column" HeaderText="Title" UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SYSTEM" FilterControlAltText="Filter column4 column" HeaderText="System" UniqueName="column4">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle AlwaysVisible="True" />
                        </MasterTableView>

                        <HeaderStyle ForeColor="White" />

                        <PagerStyle AlwaysVisible="True" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>

                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                    </telerik:RadGrid>
                </div>


            </div>


        </div>
        
<style type="text/css">
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 300px;
        height: 140px;
    }
</style>


    </form>
</asp:Content>
