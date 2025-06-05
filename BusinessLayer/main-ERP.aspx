<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="main-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.main_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/StyleSheet-ERPV2.0.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="MainPage" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main">
        <div class="menu-item">
            <asp:Panel ID="employee_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="employeeButton" runat="server" ImageUrl="~/images/employeePanel.png" OnClick="employeeButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Employee Panel</p>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="product_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="productButton" runat="server" ImageUrl="~/images/productPanel.png" OnClick="productButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Product Panel</p>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="purchase_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="purchaseButton" runat="server" ImageUrl="~/images/purchasePanel.png" OnClick="purchaseButton_Click" /></td>
                    </tr>
                    <tr>
                        <td>
                            <p>Purchase Panel</p>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="sales_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="saleseButton" runat="server" ImageUrl="~/images/salesPanel.png" OnClick="saleseButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Sales Panel</p>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="production_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="productionButton" runat="server" ImageUrl="~/images/productionPanel.png" OnClick="productionButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Production Panel</p>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="stock_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="stockButton" runat="server" ImageUrl="~/images/stockPanel.png" OnClick="stockButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Stock Panel</p>
                        </td>
                    </tr>
                </table>


            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="fault_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="faultButton" runat="server" ImageUrl="~/images/faultPanel.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Fault Panel</p>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="request_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="requestButton" runat="server" ImageUrl="~/images/requestPanel.png" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Request Panel</p>
                        </td>
                    </tr>
                </table>


            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="accounting_Panel" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="accounting_Button" runat="server" ImageUrl="~/images/cash-machine.png" OnClick="accounting_Button_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Accounting Panel</p>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="report_Panel_" runat="server">
                <table class="item-table">
                    <tr>
                        <td>
                            <asp:ImageButton ID="reportButton" runat="server" ImageUrl="~/images/reportPanel.png" OnClick="reportButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p>Report Panel</p>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </div>

    </div>
</asp:Content>
