<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="euCertReports-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.euCertReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
        <asp:ScriptManager runat="server" />



        <div class="menu-item">
            <asp:Panel ID="Panel2" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Report Start Date &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp" Font-Size="15pt"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text="Report Finish Date " Font-Size="15pt"></asp:Label>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="StartDate_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt"></asp:TextBox>
                            <asp:TextBox ID="FinishDate_TextBox" runat="server" CssClass="textBoxM" TextMode="date" Font-Size="15pt"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>

                    <tr>
                        <td>
                            <asp:RadioButtonList ID="EUCertReportsRadioButtonList" runat="server" RepeatLayout="Table"
                                RepeatColumns="2">
                                <asp:ListItem Text="Purchased Scrap Detailed" Value="1" />
                                <%--euCertPlastPurchaseList--%>
                                <asp:ListItem Text="Purchased Scrap Summary" Value="2" />
                                <%--euCertPlastPurchaseSummary--%>
                                <asp:ListItem Text="Production InPut Detailed" Value="3" />
                                <%-- euCertPlastProductionInPutList--%>
                                <asp:ListItem Text="Production InPut Purchased Summary" Value="4" />
                                <%--euCertPlastProductionInPutListSummeryWout4PolyScrp--%>
                                <asp:ListItem Text="Production InPut Purchased and 4Polymer Separated Total Summary" Value="5" />
                                <%--euCertPlastProductionInPutListSummeryWitht4PolyScrp--%>
                                <asp:ListItem Text="Granule Production Detailed" Value="6" />
                                <%--euCertPlastGranuleProductionList--%>
                                <asp:ListItem Text="Semi Product Detailed (Separated Scrap/ Plastic Lump /etc.)" Value="7" />
                                <%--euCertPlastSemiProdProductionList--%>
                                <asp:ListItem Text="Waste Detailed (Paper/Iron Scrap/ Pet Bottle etc.)" Value="8" />
                                <%--euCertPlastWasteProductionList--%>
                                <asp:ListItem Text="Production OutPut Detailed" Value="9" />
                                <%--euCertPlastProductionOutPutList--%>
                                <asp:ListItem Text="Production OutPut Total Summary" Value="10" />
                                <%--euCertPlastProductionOutPutSummary--%>
                                <asp:ListItem Text="Purchase Scrap Stock" Value="11" />
                                <%--euCertPlastStockOfPurchaseScrap--%>
                                <asp:ListItem Text="4Polymer Separated Scrap Stock" Value="12" />
                                <%--euCertPlastStockOf4PolyScrap--%>
                                <asp:ListItem Text="4Polymer Mass Balance Grand" Value="13" />
                                <%--euCertMassBalanceGrand--%>
                                <asp:ListItem Text="4Polymer Mass Balance Grand Ratio" Value="14" />
                                <%--euCertMassBalanceGrandRatio--%>
                                <asp:ListItem Text="4Polymer Mass Balance Total" Value="15" />
                                <%--euCertMassBalanceTotal--%>
                                <asp:ListItem Text="4Polymer Mass Balance Total Ratio" Value="16" />
                                <%--euCertMassBalanceTotalRatio--%>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Please select Report.<br />"
                                ControlToValidate="EUCertReportsRadioButtonList" runat="server" ForeColor="Red" Display="Dynamic"  ValidationGroup="myValidator"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnReport" Text="Report" runat="server" OnClick="report_Click" ValidationGroup="myValidator" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Panel_4" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Description_Label" runat="server" Text="Report Description "></asp:Label>
                            <br />
                            <asp:TextBox ID="Description_TextBox" runat="server" TextMode="multiline"  style="min-width:900px;"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                         <!--BEcause of the pre render problem I cancel the Prerender -->
                        <td>
                            <asp:GridView ID="jQueryeuCertReportsGridView" runat="server" CssClass="product-type-gridviewS" ShowHeaderWhenEmpty="true"  >
                                                                                                                 
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ExcelButton" runat="server" Text="EXCEL" ClientIDMode="Static"  OnClick="ExcelButton_Click"  />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

        </div>

    </div>


    <script type="text/javascript">

        function pageLoad() {
            createDataTable();

        };


        function createDataTable() {
            var table = $('#<%=jQueryeuCertReportsGridView.ClientID%>').DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[25, -1], [25, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    retrieve: true,
                    stateSave: false,
                    order: [[0, 'DESC']],

                });

        }




    </script>


</asp:Content>
