<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IntimateChange.aspx.cs" Inherits="quickinfo_v2.Views.ChangeManagement.IntimateChange" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

                    <telerik:RadGrid ID="grdRequest" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5" OnItemCommand="grdRequest_ItemCommand">
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
            <div class="panel-heading">
                <div class="panel-title">
                    Create Change Request
                </div>


            </div>
            <div class="panel-body">

                <%--                            <telerik:RadComboBox ID="CmbSystem" runat="server" Skin="Default" Width="99%">
                        </telerik:RadComboBox>--%>

          <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Outlook" MultiPageID="RadMultiPage1"
            SelectedIndex="0" CssClass="tabStrip">
            <Tabs>
                <telerik:RadTab Text="Properties" runat="server" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab Text="CIs" runat="server">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Contacts">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Child Changes">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Attatchments">
                </telerik:RadTab>
                 <telerik:RadTab runat="server" Text="Events" Selected="True">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="multiPage" Width="100%" >
            <telerik:RadPageView ID="RadPageView1" runat="server" Height="320px">
                <div style="width: 95%; height: 30px;">   
                    <asp:Label ID="lblSearch" runat="server" Text="0" Visible="false"></asp:Label>
                    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                      <asp:Label ID="lblSearch2" runat="server" Text="0" Visible="false"></asp:Label>
                </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Add Work flow ID</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <asp:Label ID="lblWorkFlowID" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    </div>
                     <div style="width: 5%; height: 30px; float: left;">
                       <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Select" CssClass="btn btn-info" OnClick="LinkButton2_Click">
                      <i class="entypo-search"></i>

                   </asp:LinkButton>
                     </div>
                                        <div style="width: 15%; height: 30px; float: left;">Parent Change</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <asp:Label ID="lblParentChange" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    </div>
                     <div style="width: 5%; height: 30px; float: left;">
                       <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" CssClass="btn btn-info" OnClick="LinkButton1_Click">
                      <i class="entypo-search"></i>

                   </asp:LinkButton>
                     </div>
                </div>
                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Select Oraganization</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                          <asp:Label ID="lblCompany" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    </div>
                       <div style="width: 15%; height: 30px; float: left;"> 
                    </div>

                </div>
                     <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Status</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtStatus" runat="server" Width="99%" ReadOnly="True" Text="INTIMATE">
                        </telerik:RadTextBox>
                    
                    </div>
                         <div style="width: 15%; height: 30px; float: left;"> 
                    </div>

                </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Title</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtTitle" runat="server" Width="99%" ValidationGroup="UP">
                        </telerik:RadTextBox>
                    
                    </div>
                      <div style="width: 15%; height: 30px; float: left;"> 
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="**Null" ForeColor="Red" ValidationGroup="UP"></asp:RequiredFieldValidator>
                    </div>

                </div>

                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">System</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblSystem" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
                                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Description</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtDesciption" runat="server" Width="99%" TextMode="MultiLine">
                        </telerik:RadTextBox>
                    
                    </div>

                </div>
          
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" CssClass="pageViewEducation" Height="320px">
                  <div style="width: 95%; height: 30px;">   </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Add Path</div>
                    <div style="width: 50%; height: 30px; float: left;">
                                   <telerik:RadTextBox ID="txtPath" runat="server" Width="99%">
                                   </telerik:RadTextBox>
                    </div>

 

                </div>
                           <div style="width: 95%;">
                       <telerik:RadGrid ID="RdGrdCIPath" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="PATH" FilterControlAltText="Filter column5 column" HeaderText="Path" UniqueName="PATH">
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
            </telerik:RadPageView>

            <telerik:RadPageView ID="RadPageView3" runat="server" >
                     <asp:UpdatePanel id="UpdatePanel1" runat="server">
         <contenttemplate>
                 <div style="width: 95%; height: 30px;">   </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">User Name</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtUserName" runat="server" Width="99%">
                        </telerik:RadTextBox>
                    </div>
                                 <div style="width: 15%; height: 30px; float: left;">EPF No</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtEPF" runat="server" Width="99%">
                        </telerik:RadTextBox>
                    </div>
 

                </div>
              <div style="width: 95%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="BtnSearchContact" runat="server" Text="Search"
                            CssClass="btn btn-apps" Width="100px" OnClick="BtnSearchContact_Click" />
                        <asp:Button ID="BtnSchclear" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" OnClick="BtnSchclear_Click" />


                    </div>
                </div>
                   <div class="panel-body">
               <div style="width: 95%;">
                    <div style="width: 30%;  float: left;">

                        <telerik:RadListBox ID="RadListBox1" runat="server" AllowReorder="True" AllowTransfer="True" AutoPostBackOnReorder="True" AutoPostBackOnTransfer="True" CssClass="RadListBox1" EnableDragAndDrop="True" SelectionMode="Multiple" TransferToID="RadListBox2" Width="95%">
                            <ButtonSettings TransferButtons="All" />
                        </telerik:RadListBox>

                    </div>
                    <div style="width: 30%; float: left;">

                        <telerik:RadListBox ID="RadListBox2" runat="server" AllowReorder="True" AllowTransfer="True" AutoPostBackOnReorder="True" CssClass="RadListBox2" EnableDragAndDrop="True" SelectionMode="Multiple" TransferToID="RadListBox1" Width="95%">
                            <ButtonSettings TransferButtons="All" />
                        </telerik:RadListBox>

                    </div>
 
  </div>
                </div>
                <div style="width: 95%; height: 20px;">   </div>
                   <div class="panel-body">
             <div style="width: 95%;">
                       <telerik:RadGrid ID="RdGrdContacts" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5">
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
                                <telerik:GridBoundColumn DataField="FULL_NAME" FilterControlAltText="Filter column1 column" HeaderText="Full Name" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USER_NAME" FilterControlAltText="Filter column5 column" HeaderText="User Name" UniqueName="REQUEST_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EPF" FilterControlAltText="Filter column column" HeaderText="EPF" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USER_LEVEL" FilterControlAltText="Filter column2 column" HeaderText="User Level" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column3 column" HeaderText="Status" UniqueName="column3">
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
             </contenttemplate>
     </asp:UpdatePanel>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView4" runat="server" Height="320px">
                  <div style="width: 95%; height: 30px;">   </div>

                           <div style="width: 95%; height: 40px;">
                       <telerik:RadGrid ID="RdGrdChildChanges" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
 <%--                               <telerik:GridTemplateColumn FilterControlAltText="Filter Select column" HeaderText="Select"
                                    UniqueName="Select">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkBtnSelect" runat="server" CommandName="Select">Select</asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                                <telerik:GridBoundColumn DataField="REQUEST_ID" FilterControlAltText="Filter column5 column" HeaderText="Request Id" UniqueName="REQUEST_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column column" HeaderText="Status" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter column1 column" HeaderText="Requested Date" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SYSTEM" FilterControlAltText="Filter column2 column" HeaderText="System Type" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REQUEST_USER" FilterControlAltText="Filter column3 column" HeaderText="Request User" UniqueName="column3">
                                </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="ASSIGN_USER" FilterControlAltText="Filter column3 column" HeaderText="Assign User" UniqueName="col">
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
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView5" runat="server" Height="320px">
                  <div style="width: 95%; height: 30px;">   </div>
                  <div class="panel-body">
                   <div style="width: 95%; ">
                    <div style="width: 15%;  float: left;">Upload Document</div>
                    <div style="width: 50%;  float: left;">
                        <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" OnFileUploaded="RadAsyncUpload1_FileUploaded1"></telerik:RadAsyncUpload>
                    </div>
                </div>
   </div>
                   <div style="width: 95%; ">
                       
            <asp:DataList ID="DataList1" RepeatColumns="1" runat="server" style="z-index: 100;" Height="1px" Width="80%" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                            <ItemTemplate>
                                    
                                <%--<asp:Button ID="Button1" runat="server" Text='<%#Eval("IMAGE_NAME") %>' CommandName="Select"/>--%>
                                <asp:LinkButton ID="LinkButton1"  Text='<%#Eval("IMAGE_NAME") %>' CommandName="Select" runat="server"></asp:LinkButton>
                                  <asp:Label ID="Label2" runat="server" Text='<%#Eval("ID") %>' Visible="False"></asp:Label>

                            </ItemTemplate>
                        </asp:DataList>
               
                 </div>
            </telerik:RadPageView>

             <telerik:RadPageView ID="RadPageView6" runat="server" Height="320px">
                   <div style="width: 95%; height: 30px;">   </div>

                           <div style="width: 95%; ">
                       <telerik:RadGrid ID="RdGrdEvents" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="EVENT_DATE" FilterControlAltText="Filter column5 column" HeaderText="Event Date" UniqueName="REQUEST_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column column" HeaderText="Event" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="USER_NAME" FilterControlAltText="Filter column1 column" HeaderText="User" UniqueName="column1">
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
            </telerik:RadPageView>
        </telerik:RadMultiPage>



            </div>

  <%--    <cc1:DropDownExtender ID="CmbSystemExt" TargetControlID="CmbSystem" runat="server">  </cc1:DropDownExtender>--%>

            <div class="panel-body">
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="BtnInsert" runat="server" Text="Submit"
                            CssClass="btn btn-apps" Width="100px" OnClick="BtnInsert_Click" />
                        <asp:Button ID="BtnUpdate" runat="server" Text="Update"
                            CssClass="btn btn-apps" Width="100px" Enabled="False" OnClick="BtnUpdate_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnCancel_Click" />



                    </div>

                </div>
                <div style="width: 100%;">
                    <div style="width: 99%; float: left;">
        <asp:HiddenField ID="hidForModel" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
 <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="hidForModel"
    CancelControlID="HiddenField2" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
              
    <%--Panel- End --%>    
 <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style="display:none; z-index: 106; left: 86px; position: absolute; top: 642px;" Height="420px" Width="80%" BackColor="White" BorderColor="#7F8B9C" BorderStyle="Solid" BorderWidth="1px">
            
      <div class="panel-body">
                 <div style="width: 95%; height: 40px;">
                <div style="width:95%; height: 40px; float: left;">     </div>
                <div style="width:5%; height: 40px; float: right;">
                       <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Select" CssClass="btn btn-info" OnClick="LinkButton3_Click">
                      <i class="entypo-cancel"></i>
                   </asp:LinkButton>
           
                </div>
                      
                 </div>
                         <asp:UpdatePanel ID="udpInnerUpdatePanel" runat="Server" >
                        <ContentTemplate> 
                          
                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">IT Work Flow ID</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtWFID" runat="server" Width="99%">
                        </telerik:RadTextBox>
                    </div>
                     <div style="width: 15%; height: 30px; float: left;">Assign User</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">


                          <asp:DropDownList ID="CmbAssignUser" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">System Type</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">


               <%--    <cc1:DropDownExtender ID="CmbSystemExt" TargetControlID="CmbSystem" runat="server">  </cc1:DropDownExtender>--%>
                   <asp:DropDownList ID="CmbSystem" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                     <div style="width: 15%; height: 30px; float: left;"></div>
                  
                      <div style="width: 30%; height: 30px; float: left;">

                    </div>
                </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;"></div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                           
                        <asp:Button ID="Button1" runat="server" Text="Search"
                            CssClass="btn btn-apps" Width="100px" OnClick="Button1_Click" />
                                   
                            <asp:Button ID="Button2" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" />

                         
                    </div>
                </div>
           <div style="width: 95%; height: 40px;">
                       <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5" OnItemCommand="RadGrid1_ItemCommand" OnNeedDataSource="RadGrid1_NeedDataSource">
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
                                <telerik:GridBoundColumn DataField="REF_NO" FilterControlAltText="Filter column column" HeaderText="Referance No" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter column1 column" HeaderText="Requested Date" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SYSTEM_TYPE" FilterControlAltText="Filter column2 column" HeaderText="System Type" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column3 column" HeaderText="Status" UniqueName="column3">
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
                                  </ContentTemplate>  
  
   </asp:UpdatePanel> 
            </div>

     </asp:Panel>

                           <%--Panel- End --%>    

                    </div>

                </div>





                <%-- Panel 2 end --%>
                              <div style="width: 100%;">
                    <div style="width: 99%; float: left;">
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
 <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel2" TargetControlID="HiddenField1"
    CancelControlID="HiddenField2" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
              
 
 <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center" style="display:none; z-index: 106; left: 86px; position: absolute; top: 642px;" Height="420px" Width="80%" BackColor="White" BorderColor="#7F8B9C" BorderStyle="Solid" BorderWidth="1px">
            
      <div class="panel-body">
                 <div style="width: 95%; height: 40px;">
                <div style="width:95%; height: 40px; float: left;">     </div>
                <div style="width:5%; height: 40px; float: right;">
                       <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Select" CssClass="btn btn-info" OnClick="LinkButton4_Click">
                      <i class="entypo-cancel"></i>
                   </asp:LinkButton>
           
                </div>
                      
                 </div>
                         <asp:UpdatePanel ID="UpdatePanel2" runat="Server" >
                        <ContentTemplate> 
                          
                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Parent ID</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtParent" runat="server" Width="99%">
                        </telerik:RadTextBox>
                    </div>
                     <div style="width: 15%; height: 30px; float: left;">Assign User</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="TxtTitleSch2" runat="server" Width="99%">
                        </telerik:RadTextBox>
                    </div>
                </div>
                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">System Type</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">

                   <asp:DropDownList ID="CmbSystem2" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                     <div style="width: 15%; height: 30px; float: left;">Assign User</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">


                          <asp:DropDownList ID="CmbAssignForParent" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;"></div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                           
                        <asp:Button ID="Button3" runat="server" Text="Search"
                            CssClass="btn btn-apps" Width="100px" OnClick="Button3_Click" />
                                   
                            <asp:Button ID="Button4" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" />

                         
                    </div>
                </div>
           <div style="width: 95%; height: 40px;">
                       <telerik:RadGrid ID="RadGrid7" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5" OnItemCommand="RadGrid7_ItemCommand" OnNeedDataSource="RadGrid7_NeedDataSource">
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
                                <telerik:GridBoundColumn DataField="REF_NO" FilterControlAltText="Filter column column" HeaderText="Referance No" UniqueName="column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter column1 column" HeaderText="Requested Date" UniqueName="column1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="SYSTEM_TYPE" FilterControlAltText="Filter column2 column" HeaderText="System Type" UniqueName="column2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column3 column" HeaderText="Status" UniqueName="column3">
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
                                  </ContentTemplate>  
  
   </asp:UpdatePanel> 
            </div>

     </asp:Panel>

                           <%--Panel- End --%>    

                    </div>

                </div>
                <%-- Panel 2 end --%>




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

