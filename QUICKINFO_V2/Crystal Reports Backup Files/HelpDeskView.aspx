﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HelpDeskView.aspx.cs" Inherits="quickinfo_v2.Views.ITWorkflow.HelpDeskView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                        Search User Requests
                    </div>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                                       </div>
            <div class="panel-body">

                                                <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">Job No</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtJobNo" Runat="server" Skin="Default" Width="99%" EmptyMessage="Enter Job No..">
                                                     </telerik:RadTextBox>
                                                     </div>      
                                                </div>
                                                 <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">Referance No</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtRefNo" Runat="server" Skin="Default" Width="99%" EmptyMessage="Enter Polycy/Proposal/Receipt or Debit..">
                                                     </telerik:RadTextBox>
                                                     </div>      
                                                </div>
                                                  <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">Branch</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="ddlBranch" Runat="server" Skin="Default" Width="99%">
                                                     </telerik:RadComboBox>
                                                     </div>      
                                                </div>
                                                 <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">Request Date</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadDatePicker ID="DtReqDate" Runat="server" Skin="Default" Width="60%">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="d/M/yyyy" DateFormat="d/M/yyyy"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                     </telerik:RadDatePicker>
                                                     </div>      
                                                </div>

                                                  <div style="width: 100%;height: 40px; ">                    
                                                 <div style="width: 20%;height: 30px;  float: left;"></div>
                                                 <div style="width: 80%;height: 30px;  float: left;">

                            <asp:Button ID="btnSearch1" runat="server" Text="Search" OnClick="btnSearch1_Click"
                                CssClass="btn btn-apps" Width="100px" />
                            <asp:Button ID="btnClear1" runat="server" Text="Clear"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnClear1_Click" />
                                 

                                                 </div>      
                                                </div>
                 <div style="width: 100%; ">

   <style type="text/css">
    .RadGrid_Default th.rgHeader
    {
        background-image: none;
        background-color: #35363A;
      
    }

    .RadGrid_Default  .rgSelectedRow
    {
        background-image: none;
        background-color: white;
        color:black;
      
    }


</style>


                     <telerik:RadGrid ID="grdRequest" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" AllowPaging="True" OnNeedDataSource="grdRequest_NeedDataSource" PageSize="5" OnItemCommand="grdRequest_ItemCommand">
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
                    UniqueName="Take">
                    <ItemTemplate>
                        <asp:LinkButton ID="LnkBtnSelect" runat="server" CommandName="Select" Font-Underline="True">Select</asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="REQUEST_ID" FilterControlAltText="Filter column4 column" HeaderText="ID" UniqueName="REQUEST_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REF_NO" FilterControlAltText="Filter column column" HeaderText="Referance No" UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter column1 column" HeaderText="Requested Date" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SYSTEM_TYPE" FilterControlAltText="Filter column2 column" HeaderText="System Type" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REMARKS_BRANCH" FilterControlAltText="Filter column3 column" HeaderText="Remarks" UniqueName="column3">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                                                  <PagerStyle PageButtonCount="5" />
                    </MasterTableView>

                                              <HeaderStyle ForeColor="White" />

                                              <PagerStyle PageButtonCount="5" BackColor="White" />

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

                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <ClientEvents></ClientEvents>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="CmbJobType">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CmbJobDecsription" />
            </UpdatedControls>
        </telerik:AjaxSetting>

<%--                <telerik:AjaxSetting AjaxControlID="CmbJobDecsription">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtCatCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>--%>
                <telerik:AjaxSetting AjaxControlID="CmbJobType">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CmbStatus" />
            </UpdatedControls>
        </telerik:AjaxSetting>

         <telerik:AjaxSetting AjaxControlID="CmbJobType">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CmbJobHandledBy" />
            </UpdatedControls>
        </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="CmbStatus">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CmbReassgn" />
            </UpdatedControls>
        </telerik:AjaxSetting>


                <telerik:AjaxSetting AjaxControlID="RdBtnLife">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CmbJobDecsription" />
            </UpdatedControls>
        </telerik:AjaxSetting>

           <telerik:AjaxSetting AjaxControlID="RdBtnGen">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="CmbJobDecsription" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                   <telerik:AjaxSetting AjaxControlID="RdBtnGen">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RdBtnLife" />
            </UpdatedControls>
        </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="RdBtnLife">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RdBtnGen" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>

</telerik:RadAjaxManager>






                                                  <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Job No</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtReqID" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Job Type</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbJobType" Runat="server" Skin="Default" Width="90%" OnSelectedIndexChanged="CmbJobType_SelectedIndexChanged" AutoPostBack="True" MaxHeight="200px">
                                                     </telerik:RadComboBox>
                                                     </div>     
                                                </div>
         
                                                   <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Referance No</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtRefNo2" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Company</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <div style="width: 20%; height: 30px; float: left;">
                                                     <asp:RadioButton ID="RdBtnLife" runat="server" Text="Life" AutoPostBack="True" OnCheckedChanged="RdBtnLife_CheckedChanged" />
                                                    </div>    
                                                      <div style="width: 40%; height: 30px; float: left;">
                                                          <asp:RadioButton ID="RdBtnGen" runat="server" Text="General" AutoPostBack="True" OnCheckedChanged="RdBtnGen_CheckedChanged" />
                                                     </div> 
                                                           </div>     
                                                </div>
                                                                      <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Branch</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtReqBranch" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Job Description</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <%--<asp:Image ID="Image2" runat="server" ImageUrl='<%# "ImageHandler.ashx?ImID="+ Eval("ID") %>' Height="80px" Width="80px" />--%>
                                                     <telerik:RadComboBox ID="CmbJobDecsription" Runat="server" Skin="Default" Width="90%" OnSelectedIndexChanged="CmbJobDecsription_SelectedIndexChanged" AutoPostBack="True" MaxHeight="200px">
                                                     </telerik:RadComboBox>
                                                     </div>     
                                                </div>
                                                                      <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Request Date</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtReqDate" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Select Status</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbStatus" Runat="server" Skin="Default" Width="90%" AutoPostBack="True" OnSelectedIndexChanged="CmbStatus_SelectedIndexChanged">
                                                     </telerik:RadComboBox>
                                                     </div>     
                                                </div>
                                                  <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Assign User</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtAssignUser" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Job Handled By</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbJobHandledBy" Runat="server" Skin="Default" Width="90%" MaxHeight="200px">
                                                     </telerik:RadComboBox>
                                                     </div>     
                                                </div>
                                                                      <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Receive Date</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtRecDate" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Reassign</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbReassgn" Runat="server" Skin="Default" Width="90%" Enabled="False" OnSelectedIndexChanged="CmbReassgn_SelectedIndexChanged">
                                                     </telerik:RadComboBox>
                                                     </div>     
                                                </div>
                                                                                          <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">TCS Error No</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtTCSError" Runat="server" Skin="Default" Width="90%">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Complete Date</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtCompDate" Runat="server" Skin="Default" Width="90%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>     
                                                </div>
                                                 <div style="width: 100%;  height: 70px;">                    
                                                 <div style="width: 15%; height: 30px; float: left;">Job Remarks (By Branch)</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtRemarks" Runat="server" Skin="Default" Width="90%" TextMode="MultiLine" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 15%; height: 30px; float: left;">Job Remarks (By Unit)</div>
                                                 <div style="width: 30%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtRemarks1" Runat="server" Skin="Default" Width="90%" TextMode="MultiLine">
                                                     </telerik:RadTextBox>
                                                     </div>
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
            

            <asp:DataList ID="DataList1" RepeatColumns="1" runat="server" style="z-index: 100;" Height="1px" Width="141px" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                            <ItemTemplate>
                                    
                                <%--<asp:Button ID="Button1" runat="server" Text='<%#Eval("IMAGE_NAME") %>' CommandName="Select"/>--%>
                                <asp:LinkButton ID="LinkButton1"  Text='<%#Eval("IMAGE_NAME") %>' CommandName="Select" runat="server"></asp:LinkButton>
                                  <asp:Label ID="Label2" runat="server" Text='<%#Eval("ID") %>' Visible="False"></asp:Label>

                            </ItemTemplate>
                        </asp:DataList>


                                                      </div>      
                                                </div>
                           
                                          </div>


                           <div class="panel-body">
                                 
                                                                                                      <div style="width: 100%;">                    
                                                 <div style="width: 20%; float: left;">Fix File Upload</div>
                                                 <div style="width: 30%; float: left;">
                                                     <%--  <a href='<%# Eval("Name","../../Uploads/"+txtReqID.Text+"/{0}")%>' target="_blank" rel="prettyPhoto[pp_gal]" title="HNB Assurance - IT Projects">                                
                                    <img src='<%# Eval("Name","../../Uploads/"+txtReqID.Text +"/{0}")%>' width="50" height="50" alt='<%# Eval("Name") %>' />
                                  </a>--%>
                                                                <telerik:RadAsyncUpload ID="RadAsyncUpload2" runat="server" OnClientFileSelected="" OnClientFilesSelected="" Skin="Default" Width="290px" TemporaryFileExpiration="00:04:00">
                                                         <Localization Select="Browse"   />
                                                     </telerik:RadAsyncUpload>
                                                          
                                         
                           <%--  <a href='<%# Eval("Name","../../Uploads/"+txtReqID.Text+"/{0}")%>' target="_blank" rel="prettyPhoto[pp_gal]" title="HNB Assurance - IT Projects">                                
                                    <img src='<%# Eval("Name","../../Uploads/"+txtReqID.Text +"/{0}")%>' width="50" height="50" alt='<%# Eval("Name") %>' />
                                  </a>--%>
                                    
                                                      </div>  
                                                      <div style="width: 40%; float: left;">

                                                                                                          </div>    
                                                </div>
                           
                                          </div>

                                            <div class="panel-body">
                                                                                           <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;"></div>
                                                 <div style="width: 80%; height: 30px; float: left;">
                                                  
                            <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click"
                                CssClass="btn btn-apps" Width="100px" />
                            <asp:Button ID="btnClear2" runat="server" Text="Clear"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnClear2_Click" />
                                 

                                                         
                                                 </div>  
                                                          
                                                </div>
             
                                </div>

                            <div class="panel-body">

                           
                                          </div>
                                    </div>  
                    </form>


    


</asp:Content>

