<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgentHierachySetup.aspx.cs" Inherits="quickinfo_v2.Views.Commission.AgentHierachySetup" %>
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
                    Search Agents
                </div>
            </div>
            <div class="panel-body">


                <div style="width: 100%; ">
                    <div style="width: 45%; height: 30px; float: left;  border-right: 1px #35363A solid; border-bottom : 1px #35363A solid;">
                        <div style="width: 90%; height: 30px; float: left; font-size: medium; text-align: center;"><strong>Agent</strong></div>
                        
                    </div>
                    <div style="width: 45%; height: 30px; float: left;  border-bottom : 1px #35363A solid; ">
                        <div style="width: 90%; height: 30px; float: left; text-align: center;" class="auto-style1"><strong>Parent</strong></div>
                        
                    </div>
                     <div style="width: 45%; height: 20px; float: left; border-right: 1px #35363A solid;">
                     </div>
                    <div style="width: 45%; height: 20px; float: left; ">
                    </div>
                     <div style="width: 45%; height: 30px; float: left; border-right: 1px #35363A solid;">
                                                 <div style="width: 45%; height: 30px; float: left;">Agent Code</div>
                        <div style="width: 45%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="RadTextBox1" runat="server" Width="99%" EmptyMessage="Enter Code..">
                        </telerik:RadTextBox>
                         </div>
                     </div>
                    <div style="width: 45%; height: 30px; float: left;">
                                                <div style="width: 45%; height: 30px; float: right;">
                        <telerik:RadTextBox ID="RadTextBox2" runat="server" Width="99%" EmptyMessage="Enter Code..">
                        </telerik:RadTextBox>
                                                </div>
                        <div style="width: 45%; height: 30px; float: right;">
                            Parent Code</div>
                    </div>
                                         
                                         <div style="width: 45%; height: 30px; float: left; border-right: 1px #35363A solid;">
                                                 <div style="width: 45%; height: 30px; float: left;"></div>
                        <div style="width: 45%; height: 30px; float: left;">

                        <asp:Button ID="BtnSearch1" runat="server" Text="Search"
                            CssClass="btn btn-green btn-sm" Width="80px" ValidationGroup="IN" OnClick="BtnSearch1_Click" />
                         </div>
                     </div>
                    <div style="width: 45%; height: 30px; float: left;">
                                                <div style="width: 45%; height: 30px; float: right;">

                        <asp:Button ID="BtnSearch2" runat="server" Text="Search"
                            CssClass="btn btn-green btn-sm" Width="80px" ValidationGroup="IN" />
                                                </div>
                        <div style="width: 45%; height: 30px; float: right;">
                                                </div>
                    </div>
                                         <div style="width: 45%; height: 20px; float: left; border-right: 1px #35363A solid;">
                     </div>
                    <div style="width: 45%; height: 20px; float: left;">
                    </div>
                                                             <div style="width: 45%;  float: left; border-right: 1px #35363A solid;">
                                                                              <div style="width: 100%; text-align: center;">

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

                    <telerik:RadGrid ID="grdAgentSearch" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" style="text-align: center">
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
<telerik:GridBoundColumn DataField="AGENTID" HeaderText="Agent ID" UniqueName="AGENTID" FilterControlAltText="Filter AGENTID column" Visible="False"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AGENT_CODE" FilterControlAltText="Filter column column" HeaderText="Agent Code" UniqueName="AGENT_CODE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AGENT_NAME" FilterControlAltText="Filter column1 column" HeaderText="Agent Name" UniqueName="AGENT_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PARENT_CODE" FilterControlAltText="Filter STATUS column" HeaderText="Parent Code" UniqueName="PARENT_CODE">
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
                    <div style="width: 45%;  float: left; ">
                                     <div style="width: 100%; text-align: center;">

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

                    <telerik:RadGrid ID="grdAgentSearch2" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" style="text-align: center">
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
                                        <asp:LinkButton ID="LnkBtnSelect0" runat="server" CommandName="Select">Select</asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
<telerik:GridBoundColumn DataField="AGENTID" HeaderText="Agent ID" UniqueName="AGENTID" FilterControlAltText="Filter AGENTID column" Visible="False"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AGENT_CODE" FilterControlAltText="Filter column column" HeaderText="Agent Code" UniqueName="AGENT_CODE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AGENT_NAME" FilterControlAltText="Filter column1 column" HeaderText="Agent Name" UniqueName="AGENT_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PARENT_CODE" FilterControlAltText="Filter STATUS column" HeaderText="Parent Code" UniqueName="PARENT_CODE">
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
                                                             <div style="width: 45%; height: 30px; float: left; border-right: 1px #35363A solid;">
                     </div>
                    <div style="width: 45%; height: 30px; float: left;">
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
                        .auto-style1 {
                            font-size: medium;
                        }
                    </style>

                </div>


            </div>
            <div class="panel-heading">
                <div class="panel-title">
                    Agent Setup
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
            <div class="panel-body">


                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Agent Code</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtAgentCode" runat="server" Width="99%" EmptyMessage="Enter Code..">
                        </telerik:RadTextBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Parent Code 1</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtDes" runat="server" Width="99%" EmptyMessage="Enter Description..">
                        </telerik:RadTextBox>
                    </div>
                </div>

                                                                
                                                
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="BtnInsert" runat="server" Text="Save"
                            CssClass="btn btn-apps" Width="100px" ValidationGroup="IN" />
                        <asp:Button ID="btnClear1" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" />


                    </div>
                </div>



            </div>



        </div>
    </form>
</asp:Content>