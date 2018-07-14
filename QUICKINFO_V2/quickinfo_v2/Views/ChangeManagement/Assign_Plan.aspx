﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Assign_Plan.aspx.cs" Inherits="quickinfo_v2.Views.ChangeManagement.Assign_Plan" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" class="form-horizontal form-groups-bordered" runat="server">
        <div style="width: 80%; height: 30px;">
                <h3>Assign & Plan</h3>            
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

                    <telerik:RadGrid ID="grdRequest" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5" OnItemCommand="grdRequest_ItemCommand" OnNeedDataSource="grdRequest_NeedDataSource">
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
                       Plan
                    </div>


                </div>
                <div class="panel-body">

                                                  <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Change ID</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtReqID" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Impact</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtImpact" Runat="server" Skin="Default" Width="90%">
                                                     </telerik:RadTextBox>
                                                     </div>     
                                                </div>
                                        <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Start Date</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadDatePicker ID="Start" Runat="server" Width="50%">
                                                     </telerik:RadDatePicker>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">
                                                         Outage</div>
                                                 <div style="width: 30%; height: 30px; float: left;">

                                                     <telerik:RadComboBox ID="CmbOutage" Runat="server" Skin="Default" Width="90%" MaxHeight="200px">
                                                     </telerik:RadComboBox>

                                                     </div>     
                                                </div>
                    
                    <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">End Date</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadDatePicker ID="End" Runat="server" Width="50%">
                                                     </telerik:RadDatePicker>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">
                    <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                                                 </div>
                                                 <div style="width: 30%; height: 30px; float: left;">

                                                     </div>     
                                                </div>
                                            <div style="width: 100%; ">                    
                                                 <div style="width: 15%;  float: left;">Fallback Plan</div>
                                                 <div style="width: 30%;  float: left;">
                                                     <telerik:RadTextBox ID="txtFallback" Runat="server" Width="90%" TextMode="MultiLine">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%;  float: left;">Reject Reason</div>
                                                 <div style="width: 30%; float: left;">

                                                     <telerik:RadTextBox ID="txtReject" Runat="server" Width="90%" TextMode="MultiLine" ValidationGroup="Re" EmptyMessage="Mandatory Field..">
                                                     </telerik:RadTextBox>

                                                     </div>     
                                                 <div style="width: 10%; float: left;"> 
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReject" ErrorMessage="*Add Reason.." ForeColor="Red" ValidationGroup="Re"></asp:RequiredFieldValidator>
                                                 </div>    
                                                </div>



 
                                

       
                          </div>



                                     <div class="panel-heading">
                    <div class="panel-title">
                        Assign</div>


                </div>
                <div class="panel-body">

                                                  <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Manager</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbUsers1" Runat="server" Width="90%">
                                                     </telerik:RadComboBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;"></div>
                                                 <div style="width: 30%; height: 30px; float: left;">
          
                                                     </div>     
                                                </div>
                                            <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Implementor</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbUsers2" Runat="server" Skin="Default" Width="90%" MaxHeight="200px">
                                                     </telerik:RadComboBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;"></div>
                                                 <div style="width: 30%; height: 30px; float: left;">

                                                     </div>     
                                                </div>

                    <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">QA Agent</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbUsers3" Runat="server" Skin="Default" Width="90%" MaxHeight="200px">
                                                     </telerik:RadComboBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;"></div>
                                                 <div style="width: 30%; height: 30px; float: left;">

                                                     </div>     
                                                </div>

                    <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Release Person</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbUsers4" Runat="server" Skin="Default" Width="90%" MaxHeight="200px">
                                                     </telerik:RadComboBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;"></div>
                                                 <div style="width: 30%; height: 30px; float: left;">

                                                     </div>     
                                                </div>
 
                                

       
                          </div>

                                     <div class="panel-heading">
                    <div class="panel-title">
                        Documentst &amp; Processes</div>


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

                                       <div style="width: 30%; float: left;">
                                                     <telerik:RadTextBox ID="txtOtherDocs" Runat="server" Skin="Default" Width="90%" TextMode="MultiLine" Height="40px">
                                                     </telerik:RadTextBox>


                    </div>
 
  </div>
 
                                

       
                          </div>

  
                           
                                          </div>

                             
             <div class="panel-heading">
                <div class="panel-title">
                    Change Request Details</div>


            </div>
            <div class="panel-body">

                <%--  <a href='<%# Eval("Name","../../Uploads/"+txtReqID.Text+"/{0}")%>' target="_blank" rel="prettyPhoto[pp_gal]" title="HNB Assurance - IT Projects">                                
                                    <img src='<%# Eval("Name","../../Uploads/"+txtReqID.Text +"/{0}")%>' width="50" height="50" alt='<%# Eval("Name") %>' />
                                  </a>--%>

          <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Outlook" MultiPageID="RadMultiPage1"
            SelectedIndex="0" CssClass="tabStrip">
            <Tabs>
                <telerik:RadTab Text="General Information" runat="server" Selected="True">
                </telerik:RadTab>
                <telerik:RadTab Text="Resolution" runat="server">
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
                                        <div style="width: 15%; height: 30px; float: left;">IT Work Flow ID</div>
                  
                      <div style="width: 30%; height: 30px; float: left;">
                          <asp:Label ID="lblITWorkFlowID" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" Height="23px" Width="99%"></asp:Label>
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
                                  <div style="width: 95%; height: 80px;">
                    <div style="width: 15%; height: 50px; float: left;">Description</div>
                    <div style="width: 30%; height: 50px; float: left;">
                        <telerik:RadTextBox ID="lblDescription" Runat="server" Height="40px" ReadOnly="True" TextMode="MultiLine" Width="99%">
                        </telerik:RadTextBox>
                    
                    </div>

                </div>

                
                                             <div class="panel-body">
                                 
                                                                                                      <div style="width: 100%;">                    
                                                 <div style="width: 20%; float: left;">Images Uploded (By Branch )
                                                     
                           
                                                                                                          </div>
                                                 <div style="width: 40%; float: left;">
            

            <asp:DataList ID="galleryDataList" RepeatColumns="5" runat="server" style="z-index: 100;" Height="1px" Width="141px" OnSelectedIndexChanged="galleryDataList_SelectedIndexChanged">
                            <ItemTemplate>
                                    
                                 <%--<asp:Image ID="Image2" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("ID") %>' Height="80px" Width="80px" />--%>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("ID") %>' Height="80px" Width="80px" CommandName="Select" />
                               
                                 <asp:Label ID="Label1" runat="server" Visible="False" Text='<%#Eval("ID") %>'></asp:Label>
                                 <br />
                                 <%--  <a href='<%# Eval("Name","../../Uploads/"+txtReqID.Text+"/{0}")%>' target="_blank" rel="prettyPhoto[pp_gal]" title="HNB Assurance - IT Projects">                                
                                    <img src='<%# Eval("Name","../../Uploads/"+txtReqID.Text +"/{0}")%>' width="50" height="50" alt='<%# Eval("Name") %>' />
                                  </a>--%>
                        
                            </ItemTemplate>
                        </asp:DataList>


                                                      </div>      
                                                </div>
                           
                                          </div>



                                               <div class="panel-body">
                                 
                                                                                                      <div style="width: 100%;">                    
                                                 <div style="width: 20%; float: left;">Documents Uploded (By Branch )
                                                     
                           
                                                                                                          </div>
                                                 <div style="width: 40%; float: left;">
            

            <asp:DataList ID="DataList2" RepeatColumns="1" runat="server" style="z-index: 100;" Height="1px" Width="141px" OnSelectedIndexChanged="DataList2_SelectedIndexChanged">
                            <ItemTemplate>
                                    
                                <%--<asp:Button ID="Button1" runat="server" Text='<%#Eval("IMAGE_NAME") %>' CommandName="Select"/>--%>
                                <asp:LinkButton ID="LinkButton1"  Text='<%#Eval("IMAGE_NAME") %>' CommandName="Select" runat="server"></asp:LinkButton>
                                  <asp:Label ID="Label2" runat="server" Text='<%#Eval("ID") %>' Visible="False"></asp:Label>

                            </ItemTemplate>
                        </asp:DataList>


                                                      </div>      
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

             <telerik:RadPageView ID="RadPageView6" runat="server" Height="500px">
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

                                           <div style="width: 95%; height: 30px;">   </div>

                           <div style="width: 95%; ">
                               <telerik:RadGrid ID="RadGrdEventsITWF" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%">
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
                                   <FilterMenu EnableImageSprites="False">
                                   </FilterMenu>
                                   <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                                   </HeaderContextMenu>
                               </telerik:RadGrid>
               
                 </div>




            </telerik:RadPageView>
        </telerik:RadMultiPage>



            </div>


                                            <div class="panel-body">
                                                                                           <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;"></div>
                                                 <div style="width: 80%; height: 30px; float: left;">
                                                  
                            <asp:Button ID="BtnUpdate" runat="server" Text="Plan & Assign"
                                CssClass="btn btn-apps" Width="120px" OnClick="BtnUpdate_Click" Enabled="False" />
                            <asp:Button ID="BtnReject" runat="server" Text="Reject"
                                CssClass="btn btn-apps" Width="100px" Enabled="False" OnClick="BtnReject_Click" ValidationGroup="Re" />
                            <asp:Button ID="btnCancel" runat="server" Text="Clear"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnCancel_Click" />
                                 

                                                         
                                                 </div>  
                                                          
                                                </div>
             
                                </div>
                                
                    </form>
</asp:Content>
