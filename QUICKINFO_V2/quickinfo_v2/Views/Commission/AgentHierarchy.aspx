<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgentHierarchy.aspx.cs" Inherits="quickinfo_v2.Views.Commission.AgentHierarchy" %>

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


                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Agent Code</div>
                    <div style="width: 40%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtAgentCodeSearch" runat="server" Width="99%" EmptyMessage="Enter Code..">
                        </telerik:RadTextBox>
                    </div>

                </div>
                
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="btnSearch1" runat="server" Text="Search"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnSearch1_Click" />
                        <asp:Button ID="Button1" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" OnClick="Button1_Click" />


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

                    <telerik:RadGrid ID="grdAgentSearch" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" OnItemCommand="grdAgentSearch_ItemCommand">
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
                                <telerik:GridBoundColumn DataField="AGENTID" HeaderText="Agent ID" UniqueName="AGENTID" FilterControlAltText="Filter AGENTID column"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AGENT_CODE" FilterControlAltText="Filter column column" HeaderText="Agent Code" UniqueName="AGENT_CODE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AGENT_NAME" FilterControlAltText="Filter column1 column" HeaderText="Agent Name" UniqueName="AGENT_NAME">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PARENT_CODE" FilterControlAltText="Filter column2 column" HeaderText="Parent Code" UniqueName="PARENT_CODE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="COMMISSION" FilterControlAltText="Filter column3 column" HeaderText="Commission" UniqueName="COMMISSION">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="AGENT_LEVEL" FilterControlAltText="Filter column4 column" HeaderText="Level" UniqueName="AGENT_LEVEL">
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
                    Add Parents
                </div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
            <div class="panel-body">


                
                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Agent Code</div>
                    <div style="width: 20%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtAgentCode" runat="server" Width="90%" ReadOnly="True">
                        </telerik:RadTextBox>
                    </div>
                     <div style="width: 3%; height: 30px; float: left;"></div>

                    <div style="width: 12%; height: 30px; float: left;">

                        

                        <asp:Label ID="lblApprove" runat="server" Visible="False"></asp:Label>

                        

                    </div>

                       <div style="width: 20%; height: 30px; float: left;">



                        <asp:Label ID="lblChangeParent" runat="server" Visible="False"></asp:Label>

                        

                    </div>
                    <div style="width: 10%; height: 30px; float: left;">



                    </div>


                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Parent Code</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtNewPArentCode" runat="server" Width="90%">
                        </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPArentCode" ErrorMessage="**" ForeColor="Red" ValidationGroup="IN"></asp:RequiredFieldValidator>
                    </div>
                    <div style="width: 20%; height: 30px; float: left;">Comission</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtNewCommission" runat="server" Width="90%">
                        </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewCommission" ErrorMessage="**" ForeColor="Red" ValidationGroup="IN"></asp:RequiredFieldValidator>
                    </div>
                </div>
                   <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;">Parent Level</div>
                    <div style="width: 25%; height: 30px; float: left;">
                                                     <telerik:RadComboBox ID="CmbNewLevel" Runat="server" Skin="Default" Width="90%" AutoPostBack="True" MaxHeight="200px">
                                                     </telerik:RadComboBox>
                    </div>
                    <div style="width: 20%; height: 30px; float: left;">Calculation End Date</div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadDatePicker ID="dtNewEndDate" Runat="server" Width="90%">
                        </telerik:RadDatePicker>
                    </div>
                </div>
                    <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                        <div style="width: 20%; height: 30px; float: left;">

                        <asp:Button ID="BtnAddParent" runat="server" Text="Add Parent"
                            CssClass="btn btn-apps" Width="100px" OnClick="BtnAddParent_Click1" ValidationGroup="IN" />
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



                    <telerik:RadGrid ID="grdAgentParent" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="70%" OnItemCommand="grdAgentParent_ItemCommand">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="AGENT_CODE" FilterControlAltText="Filter column column" HeaderText="AGENT_CODE" UniqueName="AGENT_CODE" Visible="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="PARENT_CODE" FilterControlAltText="Filter PARENT_CODE1 column" HeaderText="Parent Code" UniqueName="PARENT_CODE" >
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtParentCode" runat="server" Text='<%#Eval("PARENT_CODE") %>' ReadOnly="True" ></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>


                                <telerik:GridTemplateColumn DataField="PARENT_PERCENTAGE" FilterControlAltText="Filter PARENT_PERCENTAGE column" HeaderText="Commission" UniqueName="PARENT_PERCENTAGE">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtParentCom" runat="server" Text='<%#Eval("PARENT_PERCENTAGE") %>' ReadOnly="True" ></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                 <telerik:GridBoundColumn DataField="PARENT_LEVEL" FilterControlAltText="Filter column column" HeaderText="Parent Level" UniqueName="PARENT_LEVEL">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="END_DATE" FilterControlAltText="Filter END_DATE column" HeaderText="End Date" UniqueName="END_DATE">
                                </telerik:GridBoundColumn>

                  <telerik:GridTemplateColumn FilterControlAltText="Filter Select column" HeaderText="Change" UniqueName="Change">
                    <ItemTemplate>
                        <asp:LinkButton  id="LinkButton7" runat="server" CssClass="btn btn-green btn-icon btn-sm icon-left" CommandName="Change"  >Change <i class="entypo-user-add"></i> </asp:LinkButton>  
                    </ItemTemplate>
                </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn FilterControlAltText="Filter Select column" HeaderText="Remove" UniqueName="Remove">
                    <ItemTemplate>
                        <asp:LinkButton  id="LinkButton8" runat="server" CssClass="btn btn-gold btn-icon icon-left btn-sm"  CommandName="Remove" >Remove <i class="entypo-cancel"></i></asp:LinkButton>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
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
   
                          
                <div style="width: 100%; height: 20px;">

                </div>

                <div style="width: 100%; height: 40px;">
                    <div style="width: 20%; height: 30px; float: left;"></div>
                    <div style="width: 80%; height: 30px; float: left;">

                        <asp:Button ID="BtnInsert" runat="server" Text="Save"
                            CssClass="btn btn-apps" Width="100px" OnClick="BtnInsert_Click" />
                        <asp:Button ID="btnClear1" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnClear1_Click" />


                    </div>
                </div>



            </div>



        </div>
    </form>
</asp:Content>

