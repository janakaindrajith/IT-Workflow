<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RuleEngine.aspx.cs" Inherits="quickinfo_v2.Views.Commission.RuleEngine" %>
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
                                                         <asp:Button ID="btnclear1" runat="server" CssClass="btn btn-apps" Text="Clear" Width="100px" OnClick="btnclear1_Click" />
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
            </div>




            <div class="panel-body">

                <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <ClientEvents></ClientEvents>
    <AjaxSettings>

        <telerik:AjaxSetting AjaxControlID="ddlType1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue1" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType2">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue2" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType3">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue3" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType4">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue4" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType5">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue5" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType6">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue6" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType7">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue7" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType8">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue8" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType9">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue9" />
            </UpdatedControls>
        </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="ddlType10">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ddlValue10" />
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>

</telerik:RadAjaxManager>


                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;"></div>
                                     <div style="width: 5%; height: 30px; float: left;"><strong>( / )</strong></div>
                    <div style="width: 25%; height: 30px; float: left;"><strong>Type</strong></div>
                                     <div style="width: 15%; height: 30px; float: left;"><strong>Operator</strong></div>
                                        <div style="width: 25%; height: 30px; float: left;"><strong>Value</strong></div>
                                         <div style="width: 5%; height: 30px; float: left;"><strong>( / )</strong></div>
                                        <div style="width: 15%; height: 30px; float: left;"><strong>Logical Control</strong></div>
                </div>
                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">1</div>
                      <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac1" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType1" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType1_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                      <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp1" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue1" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac1" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon1" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">2</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac2" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType2" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType2_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                                          <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp2" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue2" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac2" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon2" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">3</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac3" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType3" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType3_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                    <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp3" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue3" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac3" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon3" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">4</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac4" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType4" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType4_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                    <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp4" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue4" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac4" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon4" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">5</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac5" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType5" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType5_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                    <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp5" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue5" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac5" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon5" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">6</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac6" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType6" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType6_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                    <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp6" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue6" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac6" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon6" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">7</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac7" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType7" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType7_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                    <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp7" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue7" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac7" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon7" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">8</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac8" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType8" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType8_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                    <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp8" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue8" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac8" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon8" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">9</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac9" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType9" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType9_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                    <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp9" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue9" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac9" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon9" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                </div>
                                <div style="width: 100%; height: 40px;">
                    <div style="width: 5%; height: 30px; float: left;">10</div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlBrac10" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlType10" runat="server" Skin="Default" Width="85%" AutoPostBack="True" OnSelectedIndexChanged="ddlType10_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </div>
                                    <div style="width: 15%; height: 30px; float: left;"><strong>
                        <telerik:RadComboBox ID="ddlOp10" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                          </strong></div>
                                        
                                        <div style="width: 25%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlValue10" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                    </div>
                                         <div style="width: 5%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="ddlRBrac10" runat="server" Skin="Default" Width="85%">
                        </telerik:RadComboBox>
                                    </div>
                    <div style="width: 15%; height: 30px; float: left;">
                        <telerik:RadComboBox ID="DdlCon10" runat="server" Skin="Default"  Width="85%" Visible="False">
                        </telerik:RadComboBox>
                    </div>
                </div>
               

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
                            CssClass="btn btn-apps" Width="100px" OnClick="btnSave_Click" Enabled="False" />
                    </div>
                                              <div style="width: 12%; height: 30px; float: left;">

                                                <asp:Button ID="btnUpdate" runat="server" Text="Update"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnUpdate_Click" Enabled="False" />
                    </div>              

                    <div style="width: 12%; height: 30px; float: left;">
                        <asp:Button ID="btnClear" runat="server" Text="Clear"
                            CssClass="btn btn-apps" Width="100px" OnClick="btnClear_Click" />
                    </div>
                </div>
  


            </div>





        </div>
                                                  </asp:Panel>
    </form>
</asp:Content>