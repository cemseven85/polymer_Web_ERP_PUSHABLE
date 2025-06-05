<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="dailyGranuleProduction.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Reports.dailyGranuleProduction" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="product-type">

        <div class="menu-item">
            <asp:Panel ID="Panel1" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="lblMonth" runat="server" Text="Select Month" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtMonth" runat="server" TextMode="Month" CssClass="textBoxM" Font-Size="15pt" AutoPostBack="false"></asp:TextBox>
                        </td>
                    </tr>
                    <%--//add another row with the button with the text "Show" and OnClick="btnShow_Click" and runat server--%>
                    <tr>
                        <td>
                            <asp:Button ID="btnShow" runat="server" Text="Show Daily Production List" OnClick="btnShow_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnShowChart" runat="server" Text="Show Daily Production Chart" OnClick="btnShowChart_Click" />
                        </td>
                    </tr>


                </table>
            </asp:Panel>
            <asp:Panel ID="DataPanel" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:GridView ID="jQueryListDailyGranuleProductionGridview" runat="server" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="TotalProduction" HeaderText="TotalProduction" DataFormatString="{0:0.00}" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:Button ID="btnExportToExcel" runat="server" Text="Export to Excel" OnClick="btnExportToExcel_Click" />
                        </td>
                    </tr>

                </table>
            </asp:Panel>
            <div class="chart-container">
                <asp:Panel ID="ChartPanel" runat="server">
                    <asp:Chart ID="Chart1" runat="server" Width="1400px" Height="700px">
                        <Series>
                            <asp:Series Name="Series1" Color="LightGreen"></asp:Series>
                            <asp:Series Name="Series2" Color="Red"></asp:Series>
                            <asp:Series Name="Series3"></asp:Series>
                            <asp:Series Name="Series4"></asp:Series>
                            
                            <asp:Series Name="Series5"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>

                        <Legends>
                            <asp:Legend Name="Legend1"></asp:Legend>
                        </Legends>
                    </asp:Chart>
                </asp:Panel>
            </div>

        </div>

    </div>



    <script type="text/javascript">

        function pageLoad() {
            createDataTable();
        };


        function createDataTable() {
            var table = $('#<%=jQueryListDailyGranuleProductionGridview.ClientID%>').DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[31, -1], [31, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    retrieve: true,
                    stateSave: false,
                    order: [[0, 'asc']],

                });



        }

    </script>





</asp:Content>
