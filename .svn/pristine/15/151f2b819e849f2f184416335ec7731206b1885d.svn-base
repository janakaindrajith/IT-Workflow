<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HandlerForm.aspx.cs" Inherits="quickinfo_v2.Views.ITWorkflow.HandlerForm" %>


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
                        Search Requests
                    </div>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                                       </div>
            <div class="panel-body">


                                                 <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">Request ID</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtReqNo" Runat="server" Width="99%" EmptyMessage="Enter Request ID..">
                                                     </telerik:RadTextBox>
                                                     </div>      
                                                </div>
                                                  <div style="width: 100%;height: 40px; ">                    
                                                 <div style="width: 20%;height: 30px;  float: left;"></div>
                                                 <div style="width: 80%;height: 30px;  float: left;">

                            <asp:Button ID="btnSearch1" runat="server" Text="Search"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnSearch1_Click" />
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

                     <telerik:RadGrid ID="grdRequest" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" OnItemCommand="grdRequest_ItemCommand" OnNeedDataSource="grdRequest_NeedDataSource" PageSize="5">
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
                            <telerik:GridBoundColumn DataField="REQUEST_ID" FilterControlAltText="Filter REQUEST_ID column" HeaderText="Request ID" UniqueName="REQUEST_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REF_NO" FilterControlAltText="Filter column column" HeaderText="Referance No" UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column3 column" HeaderText="Status" UniqueName="column3">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ASSIGN_USER" FilterControlAltText="Filter column4 column" HeaderText="Assign User" UniqueName="column4">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>

                                             <HeaderStyle ForeColor="White" />

                                             <PagerStyle PageButtonCount="5" />

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
                                                 <div style="width: 20%; height: 30px; float: left;">Request ID</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtRequestID" Runat="server" Width="99%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>      
                                                </div>
                                                 <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;">Job Description</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtJobDes" Runat="server" Width="99%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>      
                                                </div>
 <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;">Status</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtStatus" Runat="server" Width="99%" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                     </div>      
                                                </div>
                                                  <div style="width: 100%; height: 70px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;">Job Remarks(By Unit)</div>
                                                 <div style="width: 40%;height: 60px;  float: left;">
                                                     <telerik:RadTextBox ID="txtRemarks" Runat="server" Skin="Default" Width="99%" TextMode="MultiLine" ReadOnly="True">
                                                     </telerik:RadTextBox>
                                                      </div>      
                                                </div>
                                                <div style="width: 100%; height: 70px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;">Job Remarks(By Branch)</div>
                                                 <div style="width: 40%;height: 60px;  float: left;">
                                                     <telerik:RadTextBox ID="txtRemarksBranch" Runat="server" Skin="Default" Width="99%" TextMode="MultiLine" ReadOnly="True">
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
                                <asp:LinkButton ID="LinkButton1"  Text='<%#Eval("IMAGE_NAME") %>' CommandName="Select"  runat="server"></asp:LinkButton>
                                  <asp:Label ID="Label2" runat="server" Text='<%#Eval("ID") %>' Visible="False"></asp:Label>

                            </ItemTemplate>
                        </asp:DataList>


                                                      </div>      
                                                </div>
                           
                                          </div>

                  <div class="panel-body">
                                 
                                                                                                      <div style="width: 100%;">                    
                                                 <div style="width: 20%; float: left;">Log File Upload</div>
                                                 <div style="width: 30%; float: left;">
                                                     <%--  <a href='<%# Eval("Name","../../Uploads/"+txtReqID.Text+"/{0}")%>' target="_blank" rel="prettyPhoto[pp_gal]" title="HNB Assurance - IT Projects">                                
                                    <img src='<%# Eval("Name","../../Uploads/"+txtReqID.Text +"/{0}")%>' width="50" height="50" alt='<%# Eval("Name") %>' />
                                  </a>--%>
                                                                <telerik:RadAsyncUpload ID="RadAsyncUpload2" runat="server" OnClientFileSelected="" OnClientFilesSelected="" Skin="Default" Width="290px">
                                                         <Localization Select="Browse" />
                                                     </telerik:RadAsyncUpload>
                                         
                           <%--                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           <contenttemplate>--%>
                                    
                                                      </div>  
                                                      <div style="width: 40%; float: left;">
            


                                                                                                          </div>    
                                                </div>
                           
                                          </div>

                  <div class="panel-body">


                                          <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <ClientEvents></ClientEvents>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="CmbStatus">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtRejectReason" />
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>

</telerik:RadAjaxManager>
                                 
                    <div style="width: 100%;">                    
                                                 <div style="width: 20%; float: left;">Select Status</div>
                                                 <div style="width: 20%; float: left;">
                                                     <telerik:RadComboBox ID="CmbStatus" Runat="server" Skin="Default" Width="90%" OnSelectedIndexChanged="CmbStatus_SelectedIndexChanged" AutoPostBack="True" >
                                                     </telerik:RadComboBox>
                                                      </div>  
                                              <div style="width: 30%; float: left;">
                                                     <telerik:RadTextBox ID="txtRejectReason" Runat="server" Width="90%" Visible="False" EmptyMessage="Enter Reject Reason..">
                                                     </telerik:RadTextBox>
                                                      </div>  
                                               
                               
                                   
                                               
                                    
                                                      </div>  
     
                                                </div>
                           
                                          </div>

                                            <div class="panel-body">
                                                                                           <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;"></div>
                                                 <div style="width: 80%; height: 30px; float: left;">
                                                  
                            <asp:Button ID="BtnUpdate" runat="server" Text="Update"
                                CssClass="btn btn-apps" Width="100px" OnClick="BtnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Clear"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnCancel_Click" />
                                 

                                                         
                                                 </div>  
                                                          
                                                </div>
             
                                </div>
                                    </div>  
                    </form>
</asp:Content>
