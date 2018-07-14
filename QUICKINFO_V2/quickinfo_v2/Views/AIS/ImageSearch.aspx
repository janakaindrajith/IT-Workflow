<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ImageSearch.aspx.cs" Inherits="quickinfo_v2.Views.AIS.ImageSearch" Title ="Image Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function jsValidateNum(obj) {
            if (isNaN(obj.value)) {
                alert('Numeric Expected');
                obj.value = ''
                obj.focus()
            }
        }
    </script>


    <div class="panel-body">
        <form role="form" class="form-horizontal form-groups-bordered" runat="server">
            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-heading">
                    <div class="panel-title">
                        Search Jobs
                    </div>
                </div>

                <div class="panel-body">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">

                    </asp:ScriptManager>
                    <div class="form-group">
                        <label for="txtJob" class="col-sm-3 control-label">Job No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtJob" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtVehicleNo" class="col-sm-3 control-label">Vehicle No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtVehicleNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtAssesorCode" class="col-sm-3 control-label">Assesor Code</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtAssesorCode" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="field-121" class="col-sm-3 control-label">Type Of Inspection</label>

                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlSearchType" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-5">
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click"
                                Text="Search" CssClass="btn btn-apps" />
                            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click"
                                Text="Clear" CssClass="btn btn-apps" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Panel ID="pnlUserGrid" runat="server" Height="213px" ScrollBars="Both" Style="z-index: 102;"
                            Width="100%" BorderColor="#C0C0FF" BorderWidth="1px">
                            <asp:GridView ID="grdJob" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Bold="False" Font-Names="Tahoma"
                                Font-Size="8pt" Style="z-index: 102;" Width="100%"
                                CssClass="SearchGridView" RowStyle-Wrap="false" OnSelectedIndexChanged="grdJob_SelectedIndexChanged" OnRowDataBound="grdJob_RowDataBound">
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="View"/>
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
                        <div class="es-carousel">
                                <ul>
                                    <asp:Literal ID="ltrlImageGallery" runat="server"></asp:Literal>
                                </ul>
                        </div>
        </form>
    </div>
</asp:Content>
