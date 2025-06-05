<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="temperatureMonitoring.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Monitor.temperatureMonitoring" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        // Load the Visualization API and the gauge package.
        google.charts.load('current', { 'packages': ['gauge'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            // Create and populate the data table for each gauge chart.
            var data1 = google.visualization.arrayToDataTable([
                ['Label', 'Value'],
                ['Temp 101', 0] // Initial value for the first gauge
            ]);
            var data2 = google.visualization.arrayToDataTable([
                ['Label', 'Value'],
                ['Temp 102', 0] // Initial value for the second gauge
            ]);
            var data3 = google.visualization.arrayToDataTable([
                ['Label', 'Value'],
                ['Temp 103', 0] // Initial value for the third gauge
            ]);
            var data4 = google.visualization.arrayToDataTable([
                ['Label', 'Value'],
                ['Temp 104', 0] // Initial value for the fourth gauge
            ]);

            // Set chart options (you can customize these options as needed)
            var options = {
                width: 800, height: 240,
                redFrom: 70, redTo: 100,
                yellowFrom: 55, yellowTo: 70,
                minorTicks: 1
            };

            // Instantiate and draw our charts, passing in some options.
            var chart1 = new google.visualization.Gauge(document.getElementById('gauge_chart1'));
            chart1.draw(data1, options);
            var chart2 = new google.visualization.Gauge(document.getElementById('gauge_chart2'));
            chart2.draw(data2, options);
            var chart3 = new google.visualization.Gauge(document.getElementById('gauge_chart3'));
            chart3.draw(data3, options);
            var chart4 = new google.visualization.Gauge(document.getElementById('gauge_chart4'));
            chart4.draw(data4, options);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Container for the Gauge Charts -->
    <div class="main">

         <div class="menu-item">
            <div id="gauge_chart1"></div>
            <div style="text-align: center;">Shredder GearBox</div>
        </div>
         <div class="menu-item">
            <div id="gauge_chart2" ></div>
            <div style="text-align: center;">Temp 2</div>
        </div>
         <div class="menu-item">
            <div id="gauge_chart3" ></div>
            <div style="text-align: center;">Temp 3</div>
        </div>
         <div class="menu-item">
            <div id="gauge_chart4" ></div>
            <div style="text-align: center;">Temp 4</div>
        </div>
    </div>

</asp:Content>
