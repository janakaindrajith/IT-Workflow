﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Approval.aspx.cs" Inherits="quickinfo_v2.Views.ChangeManagement.Approval" %>
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
                        Approve</div>


                </div>
                <div class="panel-body">

                                                  <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Change ID</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtReqID" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;"></div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     </div>     
                                                </div>
                
                    
          
                                            <div style="width: 100%; ">                    
                                                 <div style="width: 15%;  float: left;">Approval Comment</div>
                                                 <div style="width: 30%;  float: left;">
                                                     <telerik:RadTextBox ID="txtApproveComment" Runat="server" Skin="Default" Width="90%" TextMode="MultiLine">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%;  float: left;">Reject Reason</div>
                                                 <div style="width: 30%; float: left;">

                                                     <telerik:RadTextBox ID="txtReject" Runat="server" Skin="Default" Width="90%" TextMode="MultiLine" ValidationGroup="Re">
                                                     </telerik:RadTextBox>

                                                     </div>     
                                                 <div style="width: 10%; float: left;"> 
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReject" ErrorMessage="*Add Reason.." ForeColor="Red" ValidationGroup="Re"></asp:RequiredFieldValidator>
                                                 </div>    
                                                </div>



 
                                

       
                          </div>



                     
             <div class="panel-heading">
                <div class="panel-title">
                    Change Request Details</div>


            </div>
            <div class="panel-body">

                <%--<asp:Button ID="Button1" runat="server" Text='<%#Eval("IMAGE_NAME") %>' CommandName="Select"/>--%>

          <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Outlook" MultiPageID="RadMultiPage1"
            SelectedIndex="0" CssClass="tabStrip">
            <Tabs>
                <telerik:RadTab Text="General Information" runat="server" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab Text="Contacts" runat="server">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Resolution">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Relations">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Dates">
                </telerik:RadTab>
                 <telerik:RadTab runat="server" Text="Events" Selected="True">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="multiPage" Width="100%" >
            <telerik:RadPageView ID="RadPageView1" runat="server" Height="320px">
                <div style="width: 95%; height: 30px;">   
                </div>

                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Oraganization</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                          <asp:Label ID="lblCompany" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    </div>

                </div>
                     <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Status</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblStatus" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Title</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblTitle" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
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
                        <asp:Label ID="lblDescription" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
          
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView2" runat="server" CssClass="pageViewEducation" Height="320px">
                  <div style="width: 95%; height: 30px;">   
                </div>

                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Request User</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                          <asp:Label ID="lblRequestUser" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    </div>

                </div>
                     <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Manager</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblManager" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Implementor</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblImplement" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>

                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">QA Agent</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblQA" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
                                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Release Team</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblRelease" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
            </telerik:RadPageView>

            <telerik:RadPageView ID="RadPageView3" runat="server" >
              <div style="width: 95%; height: 30px;">   
                </div>

                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Reject Reason</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                          <asp:Label ID="lblRejectRea" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    </div>

                </div>
                     <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Impact</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblImpact" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Outage</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblOutage" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>

                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Fallback Plan</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblFallBack" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>

            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView4" runat="server" Height="320px">
                      <div style="width: 95%; height: 30px;">   
                </div>

                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Parent Change</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                          <asp:Label ID="lblParent" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    </div>

                </div>




            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView5" runat="server" Height="320px">
   <div style="width: 95%; height: 30px;">   
                </div>

                <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Creation Date</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                          <asp:Label ID="lblCreation" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    </div>

                </div>
                     <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Start Date</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblStart" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">End Date</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblEnd" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>

                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Last Update</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblLastUpdate" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

                </div>
                                  <div style="width: 95%; height: 40px;">
                    <div style="width: 15%; height: 30px; float: left;">Plan and Assign Date</div>
                    <div style="width: 30%; height: 30px; float: left;">
                        <asp:Label ID="lblAssign" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
                    
                    </div>

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




  
                           
                                          </div>

                                            <div class="panel-body">
                                                                                           <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;"></div>
                                                 <div style="width: 80%; height: 30px; float: left;">
                                                  
                            <asp:Button ID="BtnUpdate" runat="server" Text="Approve"
                                CssClass="btn btn-apps" Width="100px" OnClick="BtnUpdate_Click" Enabled="False" />
                            <asp:Button ID="BtnReject" runat="server" Text="Reject"
                                CssClass="btn btn-apps" Width="100px" Enabled="False" OnClick="BtnReject_Click" ValidationGroup="Re" />
                            <asp:Button ID="btnCancel" runat="server" Text="Clear"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnCancel_Click" />
                                 

                                                         
                                                 </div>  
                                                          
                                                </div>
             
                                </div>
                                
                    </form>
</asp:Content>
