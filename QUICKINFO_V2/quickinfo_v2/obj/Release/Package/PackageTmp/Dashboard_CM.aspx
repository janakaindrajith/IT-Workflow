<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard_CM.aspx.cs" Inherits="quickinfo_v2.Dashboard_CM" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" class="form-horizontal form-groups-bordered" runat="server">
        
                <script type="text/javascript" src="jquery-1.11.2.min.js"></script>
 


        
         <div class="row">

	<div class="col-sm-3">
	
		<div class="tile-stats tile-red">
			<div class="icon"><i class="entypo-users"></i></div>
     
<div >

    <asp:Label ID="lblTotal" runat="server" class="num" data-start="0" data-end="" data-postfix="" data-duration="1500" data-delay="0"></asp:Label>
</div>
	
			
			<h3>Total Count</h3>
			<p>Total Requests Received for this month.</p>
		</div>
		
	</div>
	
	<div class="col-sm-3">
	
		<div class="tile-stats tile-green">
			<div class="icon"><i class="entypo-chart-bar"></i></div>
			<div class="num" data-start="0" data-end="135" data-postfix="" data-duration="1500" data-delay="600">135</div>
			
			<h3>Closed Requests</h3>
			<p>All Closed Requests for this month</p>
		</div>
		
	</div>
	
	<div class="col-sm-3">
	
		<div class="tile-stats tile-aqua">
			<div class="icon"><i class="entypo-mail"></i></div>
			<div class="num" data-start="0" data-end="23" data-postfix="" data-duration="1500" data-delay="1200">23</div>
			
			<h3>Open Requests</h3>
			<p>Still on Progress..</p>
		</div>
		
	</div>
	
	<div class="col-sm-3">
	
		<div class="tile-stats tile-blue">
			<div class="icon"><i class="entypo-rss"></i></div>
			<div class="num" data-start="0" data-end="52" data-postfix="" data-duration="1500" data-delay="1800">52</div>
			
			<h3>Rejected Requests</h3>
			<p>Jobs Rejected for this month</p>
		</div>
		
	</div>

 
	</div>

        <br>
            <div class="row">
       

		
			<div class="col-sm-6">
			
				<div class="panel panel-default">
					<div class="panel-heading">
						<div class="panel-title">Status Wise Chart</div>
						
						<div class="panel-options">
							<a href="#sample-modal" data-toggle="modal" data-target="#sample-modal-dialog-1" class="bg"><i class="entypo-cog"></i></a>
							<a href="#" data-rel="collapse"><i class="entypo-down-open"></i></a>
							<a href="#" data-rel="reload"><i class="entypo-arrows-ccw"></i></a>
							<a href="#" data-rel="close"><i class="entypo-cancel"></i></a>
						</div>
					</div>
					<div class="panel-body">
						<center><span class="chart">
                            <canvas height="110" width="110" style="display: inline-block; width: 110px; height: 110px; vertical-align: top;">
<asp:chart id="Chart1" runat="server" class="chart" Height="300px" Width="415px">
  <titles> <asp:Title ShadowOffset="3" Name="Title1" /> </titles>
  <legends>
    <asp:Legend  Docking="Right"
                IsTextAutoFit="False" Name="Default"  />
  </legends>
  <series>
    <asp:Series Name="Default" />
  </series>
  <chartareas>
    <asp:ChartArea Name="ChartArea1"
                     BorderWidth="0" />
  </chartareas>
</asp:chart>
                            </canvas></span>

						</center>

                    
                    </div>	
				</div>
				
			</div>
		
			<div class="col-sm-6">
			
				<div class="panel panel-default">
					<div class="panel-heading">
						<div class="panel-title">Count For the Month</div>
						
						<div class="panel-options">
							<a href="#sample-modal" data-toggle="modal" data-target="#sample-modal-dialog-1" class="bg"><i class="entypo-cog"></i></a>
							<a href="#" data-rel="collapse"><i class="entypo-down-open"></i></a>
							<a href="#" data-rel="reload"><i class="entypo-arrows-ccw"></i></a>
							<a href="#" data-rel="close"><i class="entypo-cancel"></i></a>
						</div>
					</div>
						
					<table class="table table-bordered table-responsive">
						<thead>
							<tr>
								<th>#</th>
								<th>Status</th>
								<th>Count</th>
								<th>Percentage</th>
							</tr>
						</thead>
						
						<tbody>
							<tr>
								<td>1</td>
								<td>Intimate</td>
								<td>125</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>
							
							<tr>
								<td>2</td>
								<td>Assign</td>
								<td>12</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>
							
							<tr>
								<td>3</td>
								<td>Approve</td>
								<td>14</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>

                            <tr>
								<td>4</td>
								<td>Reject</td>
								<td>3</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>

                          <tr>
								<td>5</td>
								<td>Implemented</td>
								<td>18</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>
                                 <tr>
								<td>6</td>
								<td>Release</td>
								<td>8</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>
		
						</tbody>
					</table>
				</div>
				
			</div>
			
		



                 </div>
                    
                    </form>
</asp:Content>
