<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="ImageUpload.aspx.cs" Inherits="quickinfo_v2.Views.AIS.ImageUpload"  Title ="Image Upload"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel-body">

        <form role="form" class="form-horizontal form-groups-bordered" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-heading">
                    <div class="panel-title">
                        Search Jobs
                    </div>
                </div>

                <div class="panel-body">

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
                            Width="100%" BorderColor="#C0C0FF" BorderWidth="1px" Visible ="false">
                            <asp:GridView ID="grdJob" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Bold="False" Font-Names="Tahoma"
                                Font-Size="8pt" Style="z-index: 102;" Width="100%"
                                CssClass="SearchGridView" RowStyle-Wrap="false" OnRowDataBound="grdJob_RowDataBound" OnSelectedIndexChanged="grdJob_SelectedIndexChanged" >
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

            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-heading">
                    <div class="panel-title">
                        Insert Job
                    </div>
                </div>

                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtJobNo" class="col-sm-3 control-label">Job No</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtJobNo" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="field-121" class="col-sm-3 control-label">Type Of Inspection</label>

                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddlInspection" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-5">
                            <asp:Label ID="lblSave" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                            <asp:Label ID="lblJob" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-5">
                            <asp:Button ID="btnSave" runat="server"
                                Text="Save" CssClass="btn btn-apps" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server"
                                Text="Cancel" CssClass="btn btn-apps" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </form>
    </div>
</asp:Content>

