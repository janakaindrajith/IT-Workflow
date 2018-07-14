<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResponsiveTable.aspx.cs" Inherits="quickinfo_v2.Views.AIS.ResponsiveTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta charset='UTF-8'>
	
	<title>Responsive Table</title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0">

	<link href="../../css/style.css" rel="stylesheet" />
	
	<!--[if !IE]><!-->
	<%--<style>
	
	/* 
	Max width before this PARTICULAR table gets nasty
	This query will take effect for any screen smaller than 760px
	and also iPads specifically.
	*/
	@media 
	only screen and (max-width: 760px),
	(min-device-width: 768px) and (max-device-width: 1024px)  {
	
		/* Force table to not be like tables anymore */
		table, thead, tbody, th, td, tr { 
			display: block; 
		}
		
		/* Hide table headers (but not display: none;, for accessibility) */
		thead tr { 
			position: absolute;
			top: -9999px;
			left: -9999px;
		}
		
		tr { border: 1px solid #ccc; }
		
		td { 
			/* Behave  like a "row" */
			border: none;
			border-bottom: 1px solid #eee; 
			position: relative;
			padding-left: 50%; 
		}
		
		td:before { 
			/* Now like a table header */
			position: absolute;
			/* Top/left values mimic padding */
			top: 6px;
			left: 6px;
			width: 45%; 
			padding-right: 10px; 
			white-space: nowrap;
		}
		
		/*
		Label the data
		*/

		td:nth-of-type(1):before { content: "First Name"; }
		td:nth-of-type(2):before { content: "Last Name"; }
		td:nth-of-type(3):before { content: "Job Title"; }
		td:nth-of-type(4):before { content: "Favorite Color"; }
	}
	
	/* Smartphones (portrait and landscape) ----------- */
	@media only screen
	and (min-device-width : 320px)
	and (max-device-width : 480px) {
		body { 
			padding: 0; 
			margin: 0; 
			width: 320px; }
		}
	
	/* iPads (portrait and landscape) ----------- */
	@media only screen and (min-device-width: 768px) and (max-device-width: 1024px) {
		body { 
			width: 495px; 
		}
	}
	
	</style>--%>
	<!--<![endif]-->

</head>
<body>
    <form id="form1" runat="server">
        <div id="page-wrap">

	            <h1>Responsive Table</h1>
<%--	            <table>
		            <thead>
		            <tr>
			            <th>First Name</th>
			            <th>Last Name</th>
			            <th>Job Title</th>
			            <th>Favorite Color</th>
		            </tr>
		            </thead>
		            <tbody>
		            <tr>
			            <td>James</td>
			            <td>Matman</td>
			            <td>Chief Sandwich Eater</td>
			            <td>Lettuce Green</td>
		            </tr>
		            <tr>
		              <td>The</td>
		              <td>Tick</td>
		              <td>Crimefighter Sorta</td>
		              <td>Blue</td>
		            </tr>
		            <tr>
		              <td>Jokey</td>
		              <td>Smurf</td>
		              <td>Giving Exploding Presents</td>
		              <td>Smurflow</td>
		            </tr>
		            <tr>
		              <td>Cindy</td>
		              <td>Beyler</td>
		              <td>Sales Representative</td>
		              <td>Red</td>
		            </tr>
		            <tr>
		              <td>Captain</td>
		              <td>Cool</td>
		              <td>Tree Crusher</td>
		              <td>Blue</td>
		            </tr>
		            </tbody>
	            </table>--%>
                <asp:Literal ID="ltrlTable" runat="server"></asp:Literal>
	    </div>

        <div id="page-wrap">

	            <h1>Responsive Table 2</h1>
                <asp:Literal ID="ltrlTable2" runat="server"></asp:Literal>
	    </div>
    </form>
</body>
</html>
<%--  --%>