<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RuleGeneration.aspx.cs" Inherits="quickinfo_v2.Views.Commission.RuleGeneration" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" class="form-horizontal form-groups-bordered" runat="server">
                                <asp:Panel ID="Panel2" runat="server" >
          
        <div style="width: 100%; height: 20px;">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </div>


<%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <ClientEvents></ClientEvents>
    <AjaxSettings>

        <telerik:AjaxSetting AjaxControlID="btnaddnew">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdRuleRowByRow" />
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>

</telerik:RadAjaxManager>--%>

        <div class="panel panel-default">

                                <div class="panel-heading">
                    <div class="panel-title">
                        Search Rule
                    </div>
                                       </div>
            <div class="panel-body">

                                                <div style="width: 100%; height: 45px;">                    
                                                 <div style="width: 10%; height: 30px;  float: left;">Rule ID</div>
                                                 <div style="width: 25%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtRuleID" runat="server" Width="85%">
                                                     </telerik:RadTextBox>
                                                     </div>    
                                                 <div style="width: 10%; height: 30px;  float: left;">Description</div>
                                                 <div style="width: 25%; height: 30px; float: left;">
                                                     <telerik:RadTextBox ID="txtDesSearch" runat="server" Width="85%">
                                                     </telerik:RadTextBox>
                                                     </div>   
                                                     <div style="width: 10%; height: 30px;  float: left;">
                                                         <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-apps" Text="Search Rule" Width="100px" OnClick="btnSearch_Click" />
                                                    </div>  
                                                                                                         <div style="width: 10%; height: 30px;  float: left;">
                                                         <asp:Button ID="btnclear1" runat="server" CssClass="btn btn-apps" Text="Clear" Width="100px" />
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

                    <telerik:RadGrid ID="grdRuleSearch" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" AllowPaging="True" OnItemCommand="grdRuleSearch_ItemCommand" OnNeedDataSource="grdRuleSearch_NeedDataSource">
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
                                <telerik:GridBoundColumn DataField="RULE_ID" FilterControlAltText="Filter column column" HeaderText="Rule ID" UniqueName="RULE_ID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter column1 column" HeaderText="Status" UniqueName="STATUS">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RULE_DES" FilterControlAltText="Filter column2 column" HeaderText="Description" UniqueName="RULE_DES">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TYPE" FilterControlAltText="Filter column3 column" HeaderText="Type" UniqueName="TYPE">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PERCENTAGE" FilterControlAltText="Filter column4 column" HeaderText="Percentage" UniqueName="PERCENTAGE">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>

                        <HeaderStyle ForeColor="White" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>

                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                    </telerik:RadGrid>
                </div>
                  </div>

                                    <div class="panel-heading">
                                       


                    <div class="panel-title">
                    Define Rules</div>
                                                       
                                         <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                                        <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="lblRowID" runat="server" Visible="False">0</asp:Label>
            </div>




            <div class="panel-body">

                     <div style="width: 100%;" >
                         <div style="width: 5%;  float: left;"   >                       
                              <asp:Button ID="btnaddnew" runat="server" CssClass="btn btn-apps" Text="Add" Width="50px" OnClick="btnaddnew_Click" />
                                                   </div>
                   <div style="width: 94%; float: right;" >

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
                      
<script type="text/javascript">
    function OnClientSelectedIndexChanged(sender, args) {
        __doPostBack('ddlType', '');
    }
</script>

                    <telerik:RadGrid ID="grdRuleRowByRow" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" Width="99%" OnItemDataBound="grdRuleRowByRow_ItemDataBound">
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridBoundColumn DataField="LINE_NO" FilterControlAltText="Filter ROWID column" HeaderText="Row Number" UniqueName="LINE_NO">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" HeaderText="( / )"
                                    UniqueName="TemplateColumn">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="ddlBrac" runat="server" Skin="Default" Width="85%">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column" HeaderText="Type" UniqueName="TemplateColumn1">
                                    <ItemTemplate>
                                
                                        <telerik:RadComboBox ID="ddlType" runat="server" Skin="Default" Width="85%" AutoPostBack="false"   OnSelectedIndexChanged="ddlType_SelectedIndexChanged" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged">
                                        </telerik:RadComboBox>
                                          
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn2 column" HeaderText="Operator" UniqueName="TemplateColumn2">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="ddlOp" runat="server" Skin="Default" Width="85%">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn3 column" HeaderText="Value" UniqueName="TemplateColumn3">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="ddlValue" runat="server" Skin="Default" Width="85%">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn4 column" HeaderText="( / )" UniqueName="TemplateColumn4">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="ddlRBrac" runat="server" Skin="Default" Width="85%">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn5 column" HeaderText="Logical Control" UniqueName="TemplateColumn5">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="DdlCon" runat="server" Skin="Default" Width="85%">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>

                        <HeaderStyle ForeColor="White" />

                        <FilterMenu EnableImageSprites="False"></FilterMenu>

                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                    </telerik:RadGrid>

                </div>
                          </div>
                </div>
                            <div class="panel-body">

                                 <div style="width: 100%; height: 20px;">   </div>

                               <div style="width: 100%; height: 45px;">
                    <div style="width: 12%; height: 30px; float: left;">Description</div>
                    <div style="width: 52%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtRuleDes" runat="server" Width="94%" EmptyMessage="Enter Rule Description.." Text="Description">
                        </telerik:RadTextBox>
                    </div>
                                        

                    <div style="width: 15%; height: 30px; float: left;">
                    </div>
                </div>

               <div style="width: 100%; height: 45px;">
                    <div style="width: 12%; height: 30px; float: left;">Percentage</div>
                    <div style="width: 20%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtPercentage" runat="server" Width="85%" EmptyMessage="Enter Comission Percentage..">
                        </telerik:RadTextBox>
                    </div>
                                        
                                        <div style="width: 12%; height: 30px; float: left;">


                                            Commission Type</div>
                                       <div style="width: 20%; height: 30px; float: left;">
                                           <strong>
                                           <telerik:RadComboBox ID="ddlComType" runat="server" Skin="Default" Width="85%">
                                           </telerik:RadComboBox>
                                           </strong>
                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                                                <asp:Button ID="btnCreateRule" runat="server" Text="Create Rule"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnCreateRule_Click" />
                    </div>
                </div>

                 <div style="width: 100%; height: 65px;">
                    <div style="width: 12%; height: 30px; float: left;">Query</div>
                    <div style="width: 75%; height: 30px; float: left;">
                        <telerik:RadTextBox ID="txtQuery" runat="server" Width="99%" TextMode="MultiLine" ReadOnly="True">
                        </telerik:RadTextBox>
                    </div>
                                        

                    <div style="width: 10%; height: 30px; float: left;">
                    </div>
                </div>

                                 <div style="width: 100%; height: 40px;">
                    <div style="width: 12%; height: 30px; float: left;"></div>
                    <div style="width: 12%; height: 30px; float: left;">

                        <asp:Button ID="btnSave" runat="server" Text="Save Rule"
                            CssClass="btn btn-apps" Width="100px" Enabled="False" OnClick="btnSave_Click" />
                    </div>
                                              <div style="width: 12%; height: 30px; float: left;">

                                                <asp:Button ID="btnUpdate" runat="server" Text="Update"
                            CssClass="btn btn-apps" Width="100px" Enabled="False" OnClick="btnUpdate_Click" />
                    </div>              

                    <div style="width: 12%; height: 30px; float: left;">
                        <asp:Button ID="btnClear" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" />
                    </div>
                </div>
  


            </div>





        </div>
                                                  </asp:Panel>
    </form>
</asp:Content>
