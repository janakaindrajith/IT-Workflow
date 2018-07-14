<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IT_Reports.aspx.cs" Inherits="quickinfo_v2.Views.ITWorkflow.IT_Reports" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" class="form-horizontal form-groups-bordered" runat="server">
                        <div style="width: 80%; height: 30px;">
                <h3>IT Reports</h3>            
        </div>
                                                               <div style="width: 100%; height: 20px;">                    
                                               <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                               </div>
              <div class="panel panel-default">

                    <div class="panel-heading">
                    <div class="panel-title">
                        Search Report</div>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
                                       </div>
            <div class="panel-body">
                                    <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">Select Report</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                       <telerik:RadComboBox ID="ddlReportType" Runat="server" Skin="Default" Width="99%" ValidationGroup="IN">
                                                     </telerik:RadComboBox>
                                                     </div>      
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlReportType" ErrorMessage="*Cannot be empty" ForeColor="Red" InitialValue="--Select Report--" ValidationGroup="IN"></asp:RequiredFieldValidator>
                                                </div>

                                      <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">Start Date</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                             <telerik:RadDatePicker ID="DtStartDate" Runat="server" Skin="Default" Width="60%">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="d/M/yyyy" DateFormat="d/M/yyyy"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                     </telerik:RadDatePicker>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DtStartDate" ErrorMessage="*Cannot be empty" ForeColor="Red" ValidationGroup="IN"></asp:RequiredFieldValidator>
                                                     </div>      
                                                </div>
                                      <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">End Date</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                  <telerik:RadDatePicker ID="DtEndDate" Runat="server" Skin="Default" Width="60%">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>

<DateInput DisplayDateFormat="d/M/yyyy" DateFormat="d/M/yyyy"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                     </telerik:RadDatePicker>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DtEndDate" ErrorMessage="*Cannot be empty" ForeColor="Red" ValidationGroup="IN"></asp:RequiredFieldValidator>
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
                                                 <div style="width: 20%; height: 30px;  float: left;">System Type</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                       <telerik:RadComboBox ID="ddlSystemType" Runat="server" Skin="Default" Width="99%">
                                                     </telerik:RadComboBox>
                                                     </div>      
                                                </div>
                                       <div style="width: 100%; height: 40px;">                    
                                                 <div style="width: 20%; height: 30px;  float: left;">Status</div>
                                                 <div style="width: 40%; height: 30px; float: left;">
                                       <telerik:RadComboBox ID="ddlStatus" Runat="server" Skin="Default" Width="99%" >
                                                            <ItemTemplate> 
                            <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("DESCRIPTION") %>' /> 
                        </ItemTemplate> 
                        <CollapseAnimation Type="OutQuint" Duration="200"></CollapseAnimation> 
                                                     </telerik:RadComboBox>
                                                     </div>      
                                                </div>
        
                                                  <div style="width: 100%;height: 40px; ">                    
                                                 <div style="width: 20%;height: 30px;  float: left;"></div>
                                                 <div style="width: 80%;height: 30px;  float: left;">

                            <asp:Button ID="btnSearch1" runat="server" Text="View"
                                CssClass="btn btn-apps" Width="100px" OnClick="btnSearch1_Click" ValidationGroup="IN" />
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

             
                     </div>
                         
                             
                                </div>

         

                

                                                  

        

      
                           
                                          </div>


                    
                    </form>
</asp:Content>
