<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MotorPerUnderwritingSearch.aspx.cs" Inherits="quickinfo_v2.Views.CRC.MotorPerUnderwritingSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="panel-body">

        <form role="form" class="form-horizontal form-groups-bordered" runat="server">
            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-heading">
                    <div class="panel-title">
                        Search Motor Pre Under Writing Inspection
                    </div>
                </div>

                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtPURNo" class="col-sm-2 control-label">PUR No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPURNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtVehicleNo" class="col-sm-2 control-label">Vehicle No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtVehicleNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtInsuredName" class="col-sm-2 control-label">Insured Name</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtInsuredName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtBranch" class="col-sm-2 control-label">Branch</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtBranch" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>&nbsp;<div class="form-group">
                        <div class="col-sm-5">
                            <div class="col-sm-5" style="margin-left: auto; margin-right: auto; text-align: center;">
                                <asp:Label ID="lblError" runat="server" Visible="False" Width="600px" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-5">
                            <asp:Button ID="btnSearch" runat="server"
                                Text="Search" CssClass="btn btn-apps" OnClick="btnSearch_Click"  />
                            <asp:Button ID="btnClear" runat="server"
                                Text="Clear" CssClass="btn btn-apps" OnClick="btnClear_Click"  />
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Panel ID="pnlUserGrid" runat="server" Height="213px" ScrollBars="Both" Style="z-index: 102;"
                            Width="100%" BorderColor="#C0C0FF" BorderWidth="1px" Visible ="false">
                            <asp:GridView ID="grdJob" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Bold="False" Font-Names="Tahoma"
                                Font-Size="8pt" Style="z-index: 102;" Width="100%"
                                CssClass="SearchGridView" RowStyle-Wrap="false" OnRowDataBound="grdJob_RowDataBound" >
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Select"/>
                                </Columns>
                                <RowStyle ForeColor="Black" BackColor="White" Height="15px" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" Font-Names="Tahoma" Font-Size="Larger"
                                    ForeColor="White" Height="20px" />
                                <AlternatingRowStyle BackColor="WhiteSmoke" Font-Names="Tahoma" Font-Size="8pt" Height="15px" />
                            </asp:GridView>
                        </asp:Panel>
                     </div>
                 </div>
             </div>


        </form>
    </div>

</asp:Content>
