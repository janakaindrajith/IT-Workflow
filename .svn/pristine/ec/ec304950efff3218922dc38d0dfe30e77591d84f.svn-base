<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssesorInsert.aspx.cs" Inherits="quickinfo_v2.Views.AIS.AssesorInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="panel-body">

        <form role="form" class="form-horizontal form-groups-bordered" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="panel panel-primary" data-collapsed="0">
                <div class="panel-heading">
                    <div class="panel-title">
                        Search Assesor
                    </div>
                </div>

                <div class="panel-body">

                    <div class="form-group">
                        <label for="txtAssesorCode" class="col-sm-3 control-label">Assesor Code</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtAssesorCode" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtAssesorName" class="col-sm-3 control-label">Assesor Name</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtAssesorName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtAssesorLocation" class="col-sm-3 control-label">Assesor Location</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtAssesorLocation" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-5">
                            <asp:Button ID="btnSearch" runat="server"
                                Text="Search" CssClass="btn btn-apps" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnClear" runat="server"
                                Text="Clear" CssClass="btn btn-apps" OnClick="btnClear_Click" />
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
                        Insert Assesor
                    </div>
                </div>

                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtAsseName" class="col-sm-3 control-label">Assesor Name</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtAsseName" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="txtContact" class="col-sm-3 control-label">Contact No</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtContact" CssClass="form-control" runat="server" MaxLength ="10" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="txtLocation" class="col-sm-3 control-label">Location</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server"  Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="txtAddress" class="col-sm-3 control-label">Address</label>
                        <div class="col-sm-5">
                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="field-121" class="col-sm-3 control-label">Position</label>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="ddlPosition" runat="server" CssClass="form-control" Enabled="false">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="txtEmiNo" class="col-sm-3 control-label">Mobile Imie No</label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtEmiNo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblPWD" CssClass ="col-sm-3 control-label" runat="server" Text="Password"></asp:Label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="txtPWD" CssClass="form-control" runat="server" Enabled="false" Visible="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-sm-5">
                            <asp:Label ID="lblSave" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                            <asp:Label ID="lblJob" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                            <asp:Label ID="lblUser" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                        </div>
                    </div>


                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-5">
                            <asp:Button ID="btnAddnew" runat="server"
                                Text="Add New" CssClass="btn btn-apps" Enabled="true" OnClick="btnAddnew_Click"  />
                            <asp:Button ID="btnAlter" runat="server"
                                Text="Alter" CssClass="btn btn-apps" Enabled="false"  />
                            <asp:Button ID="btnSave" runat="server"
                                Text="Save" CssClass="btn btn-apps" Enabled="false" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server"
                                Text="Cancel" CssClass="btn btn-apps" Enabled="true" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </form>
    </div>
</asp:Content>
