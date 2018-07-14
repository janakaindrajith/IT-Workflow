<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserRequestForm.aspx.cs" Inherits="quickinfo_v2.Views.ITWorkflow.UserRequestForm" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" class="form-horizontal form-groups-bordered" runat="server">
                <div style="width: 80%; height: 30px;">
                <h3>User Request Form</h3>            
        </div>
        <div style="width: 100%; height: 20px;">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="panel panel-default">

            <div class="panel-heading">
                <div class="panel-title">
                    Search User Requests
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
            <div class="panel-body">

                                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Request ID</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtRequestID" runat="server" Skin="Default" Width="99%" EmptyMessage="Enter Request ID">
                        </telerik:RadTextBox>
                    </div>
                </div>
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Referance No</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtRefNo" runat="server" Skin="Default" Width="99%" EmptyMessage="Enter Polycy/Proposal/Receipt or Debit..">
                        </telerik:RadTextBox>
                    </div>
                </div>

                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="btnSearch1" runat="server" Text="Search" OnClick="btnSearch1_Click"
                            CssClass="btn btn-apps" Width="100px" />
                        <asp:Button ID="btnClear1" runat="server" Text="Clear" OnClick="btnClear1_Click"
                            CssClass="btn btn-apps" Width="100px" />


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

                    <telerik:RadGrid ID="grdRequest" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" OnItemCommand="grdRequest_ItemCommand" OnNeedDataSource="grdRequest_NeedDataSource">
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
                                <telerik:GridBoundColumn DataField="REQUEST_ID" FilterControlAltText="Filter column5 column" HeaderText="Job Id" UniqueName="REQUEST_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REF_NO" FilterControlAltText="Filter column column" HeaderText="Referance No" UniqueName="REF_NO">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter column1 column" HeaderText="Requested Date" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SYSTEM_TYPE" FilterControlAltText="Filter column2 column" HeaderText="System Type" UniqueName="SYSTEM_TYPE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column3 column" HeaderText="Status" UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REMARKS_BRANCH" FilterControlAltText="Filter column4 column" HeaderText="Remarks" UniqueName="REMARKS_BRANCH">
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
                    Manage User Requests
                </div>


            </div>
            <div class="panel-body">

                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Select System</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlSystem" runat="server" Skin="Default" Width="99%">
                        </telerik:RadComboBox>
                    </div>
                       <div style="width: 20%; height: 30px; float: left;">

                    </div>
                </div>
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Referance No</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtRefNo2" runat="server" Skin="Default" Width="99%" EmptyMessage="Enter Polycy/Proposal/Receipt or Debit.." ValidationGroup="INSERT">
                        </telerik:RadTextBox>
                    </div>
                  <div style="width: 20%; height: 30px; float: left;">

                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRefNo2" ErrorMessage="Cannot Be Empty" ForeColor="#FF3300" ValidationGroup="INSERT"></asp:RequiredFieldValidator>

                    </div>
                </div>

                                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Priority</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlPriority" runat="server" Skin="Default" Width="99%">
                        </telerik:RadComboBox>
                    </div>
                  <div style="width: 20%; height: 30px; float: left;">


                      <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>

                      <asp:Label ID="lbblUserType" runat="server" Visible="False"></asp:Label>

                           <asp:Label ID="lblRequestID" runat="server" Visible="False"></asp:Label>


                    </div>
                </div>

                <div style="width: 100%; height: 70px;">
                    <div style="width: 20%; height: 30px; float: left;">Job Remarks</div>
                    <div style="width: 40%; height: 80px; float: left;">
                        <telerik:RadTextBox ID="txtRemarks" runat="server" Skin="Default" Width="99%" TextMode="MultiLine">
                        </telerik:RadTextBox>
                    </div>
                    <div style="width: 30%; height: 30px; float: left;">
                  <asp:LinkButton ID="LnkBtnClose" runat="server" CommandName="Select" CssClass="btn btn-green btn-icon icon-left" OnClick="LnkBtnClose_Click" Visible="False" >
                      <i class="entypo-check"></i>&nbsp;Close

                   </asp:LinkButton>
                          <asp:Label ID="lblClose" runat="server" CssClass="text-danger" Font-Bold="True" Text="*For Close Confirmation" Visible="False"></asp:Label>
                    </div>
                    <div style="width: 40%; height: 30px; float: left;">
                
                    </div>

                </div>


            </div>
            <div class="panel-body">

                <div style="width: 100%;">
                    <div style="width: 20%; float: left;">Image Upload</div>
                    <div style="width: 40%; float: left;">
                        <%--                        <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" Skin="Default" AllowedFileExtensions=".bmp,.gif ,.jpg,.png,.psd ,.pspimage ,.thm ,.tif ,.yuv,.jpeg " OnFileUploaded="RadAsyncUpload1_FileUploaded1">--%>

                        <%--                                    </contenttemplate>
                                                     </asp:UpdatePanel>--%>

                                    
                                                      <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" Skin="Default" OnFileUploaded="RadAsyncUpload1_FileUploaded1">


<%--                        <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" Skin="Default" AllowedFileExtensions=".bmp,.gif ,.jpg,.png,.psd ,.pspimage ,.thm ,.tif ,.yuv,.jpeg " OnFileUploaded="RadAsyncUpload1_FileUploaded1">--%>
                        </telerik:RadAsyncUpload>

                    </div>
                </div>

            </div>
            <div class="panel-body">
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="BtnInsert" runat="server" Text="Insert" OnClick="btnAddNew_Click"
                            CssClass="btn btn-apps" Width="100px" ValidationGroup="INSERT" />

                        <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click"
                            CssClass="btn btn-apps" Width="100px" Enabled="False" />
                        <asp:Button ID="btnCancel" runat="server" Text="Clear" OnClick="btnCancel_Click"
                            CssClass="btn btn-apps" Width="100px" />

                          <asp:LinkButton ID="BtnUAT" runat="server" CommandName="Select" CssClass="btn btn-blue btn-icon icon-left" OnClick="BtnUAT_Click" Visible="False" >
                      <i class="entypo-check"></i>&nbsp;UAT Confirm

                   </asp:LinkButton> 

                          <asp:LinkButton ID="BtnUATReject" runat="server" CommandName="Select" CssClass="btn btn-gold btn-icon icon-left" OnClick="BtnUATReject_Click" Visible="False" >
                      <i class="entypo-cancel"></i>&nbsp;UAT Reject

                   </asp:LinkButton> 

                    </div>

                </div>

            </div>

                        <div class="panel-body">
                <div style="width: 100%; ">
       
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

                    <telerik:RadGrid ID="GrdEvents" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="EVENT_DATE" FilterControlAltText="Filter column column" HeaderText="Event Date" UniqueName="EVENT_DATE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column1 column" HeaderText="Status" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USER_NAME" FilterControlAltText="Filter column2 column" HeaderText="User" UniqueName="SYSTEM_TYPE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REMARKS_UNIT" FilterControlAltText="Filter column3 column" HeaderText="Remarks_IT_Dept" UniqueName="column3">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REMARKS_BRANCH" FilterControlAltText="Filter column4 column" HeaderText="Remarks_Branch" UniqueName="REMARKS_BRANCH">
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

            </div>
        </div>
    </form>
</asp:Content>
