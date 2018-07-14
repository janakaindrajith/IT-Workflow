<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TCS_PolicyCancelation_GI.aspx.cs" Inherits="quickinfo_v2.Views.ITWorkflow.TCS_PolicyCancelation_GI" %>
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
                                                 <div style="width: 20%; height: 30px;  float: left;">Policy No</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtUserID" Runat="server" Width="99%" EmptyMessage="Enter Policy No..">
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
                    HeaderText="Select" UniqueName="ChkAssign">
                    <ItemTemplate>
                        <asp:CheckBox ID="ChkBxAllocate" runat="server" OnCheckedChanged="ChkBxAllocate_CheckedChanged" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="POL_POLICY_NUMBER" HeaderText="Policy No" UniqueName="POLICY_NUMBER">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="POL_POLICY_ID" FilterControlAltText="Filter column column" HeaderText="Policy ID" UniqueName="POL_POLICY_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="POL_PROPOSAL_NUMBER" FilterControlAltText="Filter column3 column" HeaderText="Proposal No" UniqueName="POL_PROPOSAL_NUMBER">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="POL_POLICY_STATUS" FilterControlAltText="Filter column4 column" HeaderText="Policy Status" UniqueName="POL_POLICY_STATUS">
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
                                                  
                            <asp:Button ID="BtnUpdate" runat="server" Text="Cancel Policy"
                                CssClass="btn btn-apps" Width="100px" OnClick="BtnUpdate_Click" />
                                                           <asp:Button ID="Button1" runat="server" Text="Expire Policy"
                                CssClass="btn btn-apps" Width="100px" OnClick="Button1_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Clear"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnCancel_Click" />
                                 

                                                         
                                                 </div>  
                                                          
                                                </div>
             
                                </div>
                    
                    </form>
</asp:Content>
