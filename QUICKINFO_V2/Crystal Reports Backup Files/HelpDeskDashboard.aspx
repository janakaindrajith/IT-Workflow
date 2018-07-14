﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HelpDeskDashboard.aspx.cs" Inherits="quickinfo_v2.Views.ITWorkflow.HelpDeskDashboard" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <form role="form" class="form-horizontal form-groups-bordered" runat="server">

                                                               <div style="width: 100%; height: 35px;">  
                                              <div style="width: 89%; height: 35px; float: left;">                   
                                               <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                                              </div>
                                               <div style="width: 9%; height: 35px;float: right; ">   
                   <a href="HelpDeskView.aspx">                   
    <%--                                              <button class="btn btn-gold btn-icon icon-left btn-sm"  type="button">
                                                    Close
                                                <i class="entypo-cancel"></i>
                                                </button>--%>
                      
                   <asp:LinkButton ID="LnkBtnSelect" runat="server" CommandName="Select" CssClass="btn btn-gold btn-icon icon-left btn-sm" OnClick="LnkBtnSelect_Click">
                       <i class="entypo-cancel"></i>&nbsp;Close

                   </asp:LinkButton>
                               
                        </a>
                                                                              </div>
                                               </div>
                          
              <div class="panel panel-default">

                    <div class="panel-heading">
                    <div class="panel-title">
                        Pending Jobs
                    </div>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                                       </div>
            <div class="panel-body">

                 <div style="width: 100%; ">
                     
<style type="text/css">
    .RadGrid_Default th.rgHeader
    {
        background-image: none;
        background-color: #3C454F;
      
    }


</style>


                     <telerik:RadGrid ID="grdRequest" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnNeedDataSource="grdRequest_NeedDataSource" PageSize="5" Width="99%" OnItemCommand="grdRequest_ItemCommand" CssClass="table table-bordered datatable dataTable">
                                             <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="REQUEST_ID" FilterControlAltText="Filter column4 column" HeaderText="ID" UniqueName="REQUEST_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REF_NO" FilterControlAltText="Filter column column" HeaderText="Referance No" UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REQUEST_USER" FilterControlAltText="Filter REQUEST_USER column" HeaderText="Request User" UniqueName="REQUEST_USER">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter column1 column" HeaderText="Requested Date" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SYSTEM_TYPE" FilterControlAltText="Filter column2 column" HeaderText="System Type" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REMARKS_BRANCH" FilterControlAltText="Filter column3 column" HeaderText="Remarks" UniqueName="column3">
                            </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter Select column" HeaderText="Take"
                    UniqueName="Take">
                    <ItemTemplate>
                  <%--      <asp:LinkButton ID="LnkBtnSelect" runat="server" CommandName="Select" Font-Underline="True">Take</asp:LinkButton>--%>
        <%--                entypo-check--%>
                        <asp:LinkButton ID="LnkBtnSelect" runat="server" CommandName="Select" CssClass="btn btn-info btn-sm btn-icon icon-left"><i class="entypo-check"></i>&nbsp;Take</asp:LinkButton>
                                
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>

                                             <HeaderStyle ForeColor="White" />

                                             <FilterItemStyle BackColor="White" />
                                             <PagerStyle BackColor="White" />

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Office2007"></HeaderContextMenu>
                     </telerik:RadGrid>
                     </div>
                         
                             
                                </div>
            <div class="panel-heading">
                    <div class="panel-title">
                        Assigned Jobs
                    </div>


                </div>
                        <div class="panel-body">

                 <div style="width: 100%; ">

                     <telerik:RadGrid ID="GrdRequestUserWise" runat="server" Width="99%" AllowPaging="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" OnNeedDataSource="GrdRequestUserWise_NeedDataSource" PageSize="5" OnItemCommand="GrdRequestUserWise_ItemCommand">
                                   <MasterTableView>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="REQUEST_ID" FilterControlAltText="Filter column4 column" HeaderText="ID" UniqueName="REQUEST_ID">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REF_NO" FilterControlAltText="Filter column column" HeaderText="Referance No" UniqueName="column">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REQUEST_USER" FilterControlAltText="Filter column4 column" HeaderText="Request User" UniqueName="column4">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter column1 column" HeaderText="Requested Date" UniqueName="column1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SYSTEM_TYPE" FilterControlAltText="Filter column2 column" HeaderText="System Type" UniqueName="column2">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="REMARKS_BRANCH" FilterControlAltText="Filter column3 column" HeaderText="Remarks" UniqueName="column3">
                            </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn FilterControlAltText="Filter Select column" HeaderText="Complete"
                    UniqueName="Take">
                    <ItemTemplate>
                       <asp:LinkButton ID="LnkBtnSelect" runat="server" CommandName="Select" CssClass="btn btn-green btn-icon btn-sm icon-left"><i class="entypo-forward"></i>&nbsp;Update</asp:LinkButton>
                         </ItemTemplate>
                </telerik:GridTemplateColumn>
                        </Columns>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>

                                   <HeaderStyle ForeColor="White" />

                                   <FilterItemStyle BackColor="White" />
                                   <PagerStyle BackColor="White" />

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Office2007"></HeaderContextMenu>
                     </telerik:RadGrid>
                     </div>
                         
                             
                                </div>
 
                                    </div>  
                    </form>
</asp:Content>