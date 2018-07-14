<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MotorPolicySearch.aspx.cs" Inherits="quickinfo_v2.Views.CRC.MotorPolicySearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-body">

        <form role="form" class="form-horizontal form-groups-bordered" runat="server">
            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-heading">
                    <div class="panel-title">
                        Search Motor Policy
                    </div>
                </div>

                <div class="panel-body">

                    <div class="form-group">
                        <label for="txtPolicyNo" class="col-sm-2 control-label">Policy No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtPolicyNo" CssClass="form-control" runat="server"></asp:TextBox>
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
                        <label for="txtProposalNo" class="col-sm-2 control-label">Proposal No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtProposalNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtEngineNo" class="col-sm-2 control-label">Engine No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtEngineNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtChassiNo" class="col-sm-2 control-label">Chassi No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtChassiNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtContactNo" class="col-sm-2 control-label">Contact No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtNIC" class="col-sm-2 control-label">NIC</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtNIC" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-5" style="margin-left: auto; margin-right: auto; text-align: center;">
                            <asp:Label ID="lblError" runat="server" Visible="False" Width="600px" ForeColor="Red"></asp:Label>
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
