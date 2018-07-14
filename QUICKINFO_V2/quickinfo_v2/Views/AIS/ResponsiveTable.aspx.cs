using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace quickinfo_v2.Views.AIS
{
    public partial class ResponsiveTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string dynTable = "";

            // start with table tag with following attributes   
            dynTable = "<table>";
            dynTable += "<thead>";
		    dynTable += "<tr>";
			dynTable += "<th>First Name</th>";
			dynTable += "<th>Last Name</th>";
			dynTable += "<th>Job Title</th>";
			dynTable += "<th>Favorite Color</th>";
		    dynTable += "</tr>";
		    dynTable += "</thead>";
		    dynTable += "<tbody>";
            // outer loop to generate table rows  
            for (int tRows = 0; tRows < 5; tRows++)
            {
                //start table row  
                dynTable += "<tr>";

                // inner loop to generate columns  
                for (int tCols = 0; tCols < 4; tCols++)
                {
                    // create column  
                    dynTable += "<td>";
                    dynTable += "Row: " + (tRows + 1) + " Col: " + (tCols + 1);

                    // close td column tag  
                    dynTable += "</td>";
                }

                // close table row  
                dynTable += "</tr>";
            }

            // close the table tag
            dynTable += "</tbody>";
            dynTable += "</table>";

            ltrlTable.Text = dynTable;

            dynTable = "<table>";
            dynTable += "<thead>";
            dynTable += "<tr>";
            dynTable += "<th>Debit No</th>";
            dynTable += "<th>Vehicle No</th>";
            dynTable += "<th>Balance Amt</th>";
            dynTable += "<th>Policy No</th>";
            dynTable += "</tr>";
            dynTable += "</thead>";
            dynTable += "<tbody>";
            // outer loop to generate table rows  
            for (int tRows = 0; tRows < 5; tRows++)
            {
                //start table row  
                dynTable += "<tr>";

                // inner loop to generate columns  
                for (int tCols = 0; tCols < 4; tCols++)
                {
                    // create column  
                    dynTable += "<td>";
                    dynTable += "Row: " + (tRows + 1) + " Col: " + (tCols + 1);

                    // close td column tag  
                    dynTable += "</td>";
                }

                // close table row  
                dynTable += "</tr>";
            }

            // close the table tag
            dynTable += "</tbody>";
            dynTable += "</table>";

            ltrlTable2.Text = dynTable;
        }
    }
}