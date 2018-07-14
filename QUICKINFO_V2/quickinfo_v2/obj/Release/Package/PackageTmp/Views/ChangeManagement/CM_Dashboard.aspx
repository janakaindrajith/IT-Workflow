<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CM_Dashboard.aspx.cs" Inherits="quickinfo_v2.Views.ChangeManagement.CM_Dashboard" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type ="text/css">
 
         .animated {
            background-image: url(/css/images/logo.png);
            background-repeat: no-repeat;
            background-position: left top;
            padding-top:10px;
            margin-bottom:24px;
            -webkit-animation-duration: 3s;
            animation-duration: 3s;
            -webkit-animation-fill-mode: both;
            animation-fill-mode: both;
         }
         
         @-webkit-keyframes bounceInDown {
            0% {
               opacity: 0;
               -webkit-transform: translateY(100px);
            }
            60% {
               opacity: 1;
               -webkit-transform: translateY(30px);
            }
            80% {
               -webkit-transform: translateY(-10px);
            }
            100% { 
               -webkit-transform: translateY(0);
            }
         }
         
         @keyframes bounceInDown {
            0% {
               opacity: 0;
               transform: translateY(100px);
            }
            60% {
               opacity: 1;
               transform: translateY(30px);
            }
            80% {
               transform: translateY(-10px);
            }
            100% {
               transform: translateY(0);
            }
         }

         
         .bounceInDown {
            -webkit-animation-name: bounceInDown;
            animation-name: bounceInDown;
         }



        </style>

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
       

		
			<div class="col-sm-5">
			
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
			
				
                  
						<center>
                   
                <div class="animated bounceInDown">
   <asp:chart id="Chart1" runat="server"  Height="238px" Width="225px" >
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
                      
                          
               </div>

						</center>
					
                     
               
				</div>
				
			</div>
		
			<div class="col-sm-7">
			
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
								
                                <td><asp:Label ID="Label1" runat="server" BackColor="#001F33" Height="12px" Width="12px" ></asp:Label></td>
								<td>Intimate</td>
								<td>125</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>
							
							<tr>
								  <td><asp:Label ID="Label2" runat="server" BackColor="#00426E" Height="12px" Width="12px" ></asp:Label></td>
								<td>Assign</td>
								<td>12</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>
							
							<tr>
								<td><asp:Label ID="Label3" runat="server" BackColor="#0072BC" Height="12px" Width="12px" ></asp:Label></td>
								<td>Approve</td>
								<td>14</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>

                            <tr>
								<td><asp:Label ID="Label4" runat="server" BackColor="#4696F7" Height="12px" Width="12px" ></asp:Label></td>
								<td>Reject</td>
								<td>3</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>

                          <tr>
								<td><asp:Label ID="Label5" runat="server" BackColor="#5ABEFF" Height="12px" Width="10px" ></asp:Label></td>
								<td>Implemented</td>
								<td>18</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>
                                 <tr>
								<td><asp:Label ID="Label6" runat="server" BackColor="#D0ECFF" Height="12px" Width="12px" ></asp:Label></td>
								<td>Release</td>
								<td>8</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>

                             <tr>
								<td></td>
								<td style="font-weight:bold">Total</td>
								<td style="font-weight:bold">8</td>
								<td class="text-center"><span class="pie"><canvas height="17" width="17" style="display: inline-block; width: 17px; height: 17px; vertical-align: top;"></canvas></span></td>
							</tr>
		
						</tbody>
					</table>
				</div>
				
			</div>
			
		



                 </div>


	<div class="row">
	<div class="col-sm-7">
		
		<div class="panel panel-primary">
			<table class="table table-bordered table-responsive">
				<thead>
					<tr>
						<th class="padding-bottom-none text-center">
							<br>
							<br>
							
            <asp:Chart ID="Chart2" runat="server" Height="270px" Width="500px" BackColor="245, 245, 246" BorderlineColor="Transparent" Palette="Grayscale">
            
<Series>
<asp:series Name="Series1" ></asp:series>
</Series>
<ChartAreas>
<asp:ChartArea Name="ChartArea2" BackColor="245, 245, 246">
</asp:ChartArea>
</ChartAreas>
</asp:Chart>

						
						</th>
					</tr>
				</thead>
				<tbody>
					<tr>
						<td class="panel-heading">
							<h4>Implemented CR's Monthly</h4>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
		
	</div>
	
	<div class="col-sm-5">
		
		<div class="panel panel-primary">
			<div class="panel-heading">
				<div class="panel-title">Implemented CR Count</div>
				
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
						<th>Month</th>
						<th>Count</th>
						<th>Percentage</th>
					</tr>
				</thead>
				
				<tbody>
					<tr>
						<td>1</td>
						<td>January</td>
						<td></td>
						<td class="text-center"><span class="inlinebar"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
					
					<tr>
						<td>2</td>
						<td>February</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-2"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
					
					<tr>
						<td>3</td>
						<td>March</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
                    					<tr>
						<td>4</td>
						<td>April</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
                    					<tr>
						<td>5</td>
						<td>May</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
                    					<tr>
						<td>6</td>
						<td>June</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
                    					<tr>
						<td>7</td>
						<td>July</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
                    					<tr>
						<td>8</td>
						<td>August</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
                    					<tr>
						<td>9</td>
						<td>September</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
                    					<tr>
						<td>10</td>
						<td>October</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>
                    					<tr>
						<td>11</td>
						<td>November</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>

                                        					<tr>
						<td>12</td>
						<td>December</td>
						<td></td>
						<td class="text-center"><span class="inlinebar-3"><canvas height="17" width="29" style="display: inline-block; width: 29px; height: 17px; vertical-align: top;"></canvas></span></td>
					</tr>


				</tbody>
			</table>
		</div>
		
	</div>
	

        	</div>
                    
                    </form>
</asp:Content>
