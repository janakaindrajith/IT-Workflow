<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReferanceData.aspx.cs" Inherits="quickinfo_v2.Views.Commission.ReferanceData" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" class="form-horizontal form-groups-bordered" runat="server">

        <div style="width: 100%; height: 20px;">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="panel panel-default">
                                    <div class="panel-heading">
                <div class="panel-title">
                    Search Rferarance</div>
            </div>
            <div class="panel-body">

                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Referance Type.</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="CmbRefTypeSrch" runat="server" Skin="Default" Width="99%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Code.</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtCodeSrch" runat="server" Width="99%" EmptyMessage="Enter Code..">
                        </telerik:RadTextBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Description.</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtDesSearch" runat="server" Width="99%" EmptyMessage="Enter Description..">
                        </telerik:RadTextBox>
                    </div>
                </div>
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="btnSearch1" runat="server" Text="Search"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnSearch1_Click" />
                        <asp:Button ID="Button1" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" OnClick="Button1_Click" />


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

                    <telerik:RadGrid ID="grdRefSearch" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" OnItemCommand="grdRefSearch_ItemCommand">
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
                                        <asp:LinkButton ID="LnkBtnSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="ID" FilterControlAltText="Filter column column" HeaderText="ID" UniqueName="ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CODE" FilterControlAltText="Filter column1 column" HeaderText="Code" UniqueName="CODE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DESCRIPTION" FilterControlAltText="Filter column2 column" HeaderText="Descrption" UniqueName="DESCRIPTION">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USER_INFO" FilterControlAltText="Filter column3 column" HeaderText="User" UniqueName="USER_INFO">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REF_TYPE" FilterControlAltText="Filter column4 column" HeaderText="Type" UniqueName="REF_TYPE">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle AlwaysVisible="True" />
                        </MasterTableView>

                        <HeaderStyle ForeColor="White" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>

                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                    </telerik:RadGrid>
                </div>


            </div>
            <div class="panel-heading">
                <div class="panel-title">
                    Parameter Setup
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
            <div class="panel-body">


                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Code.</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtCode" runat="server" Width="99%" EmptyMessage="Enter Code..">
                        </telerik:RadTextBox>
                    </div>
                    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Description.</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtDes" runat="server" Width="99%" EmptyMessage="Enter Description..">
                        </telerik:RadTextBox>
                    </div>
                </div>
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Referance Type.</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="CmbRefType" runat="server" Skin="Default" Width="99%">
                        </telerik:RadComboBox>
                    </div>
                </div>

                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="BtnInsert" runat="server" Text="Insert"
                            CssClass="btn btn-apps" Width="100px" OnClick="BtnInsert_Click" />
                                               <asp:Button ID="BtnUpdate" runat="server" Text="Update"
                            CssClass="btn btn-apps" Width="100px" OnClick="BtnUpdate_Click" />
                        <asp:Button ID="btnClear1" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnClear1_Click" />


                    </div>
                </div>



            </div>



        </div>
    </form>
</asp:Content>
