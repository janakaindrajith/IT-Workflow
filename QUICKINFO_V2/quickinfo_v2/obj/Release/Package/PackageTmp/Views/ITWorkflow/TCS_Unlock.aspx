<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TCS_Unlock.aspx.cs" Inherits="quickinfo_v2.Views.ITWorkflow.TCS_Unlock" %>
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
                        Search User</div>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                                       </div>
            <div class="panel-body">


                                                 <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">User Code</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtUserID" Runat="server" Width="99%" EmptyMessage="Enter User ID..">
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

                     <telerik:RadGrid ID="grdUsers" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" PageSize="5">
                                             <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                <telerik:GridTemplateColumn AllowFiltering="False" FilterControlAltText="Filter Assign column"
                    HeaderText="Unlock" UniqueName="ChkAssign">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkBxAllocate" runat="server" OnCheckedChanged="ChkBxAllocate_CheckedChanged" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="USER_CODE" FilterControlAltText="Filter REQUEST_ID column" HeaderText="User Code" UniqueName="USER_CODE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ROLE_CODE" FilterControlAltText="Filter column column" HeaderText="Role Code" UniqueName="ROLE_CODE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USER_STARTDATE" FilterControlAltText="Filter column3 column" HeaderText="User Start Date" UniqueName="USER_STARTDATE">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USER_ENDDATE" FilterControlAltText="Filter column4 column" HeaderText="User End Date" UniqueName="column4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PTY_PARTY_STATUS" FilterControlAltText="Filter column column" HeaderText="Status" UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="USER_NAME" FilterControlAltText="Filter column1 column" HeaderText="User Name" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ULE_RLE_ROLE_ID" FilterControlAltText="Filter ULE_RLE_ROLE_ID column" HeaderText="ULE_RLE_ROLE_ID" UniqueName="ULE_RLE_ROLE_ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ULE_PFY_PTY_PARTY_ID" FilterControlAltText="Filter ULE_PFY_PTY_PARTY_ID column" HeaderText="ULE_PFY_PTY_PARTY_ID" UniqueName="ULE_PFY_PTY_PARTY_ID" Visible="False">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ULE_PFY_PARTY_FUNCTION_ID" FilterControlAltText="Filter ULE_PFY_PARTY_FUNCTION_ID column" HeaderText="ULE_PFY_PARTY_FUNCTION_ID" UniqueName="ULE_PFY_PARTY_FUNCTION_ID" Visible="False">
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

         

                

                                                  

        

      
                           
                                          </div>

                                            <div class="panel-body">
                                                                                           <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px; float: left;"></div>
                                                 <div style="width: 80%; height: 30px; float: left;">
                                                  
                            <asp:Button ID="BtnUpdate" runat="server" Text="Unlock"
                                CssClass="btn btn-apps" Width="100px" OnClick="BtnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Clear"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnCancel_Click" />
                                 

                                                         
                                                 </div>  
                                                          
                                                </div>
             
                                </div>
                    
                    </form>
</asp:Content>