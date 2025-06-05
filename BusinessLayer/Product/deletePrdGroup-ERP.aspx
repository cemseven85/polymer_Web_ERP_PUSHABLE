<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="deletePrdGroup-ERP.aspx.cs" Inherits="polymer_Web_ERP_V4.deletePrdGroup_ERP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">
        <asp:ScriptManager runat="server" />


        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Product_Group_Panel_2" runat="server" GroupingText="PRODUCT GROUP LIST">
                <!--   style="overflow: scroll" -->
                <table class="item-table">
                    <tr>
                        <!-- Because layout is same I use the same class with product Type page same css   CssClass="product-type-gridview" -->
                        <td>
                            <asp:GridView ID="jQueryProductGroupGridView" runat="server" CssClass="product-type-gridview" OnPreRender="jQueryProductGroupGridView_PreRender"  ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" SelectText="Delete" />
                                </Columns>
                                <SelectedRowStyle BackColor="#3333CC" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <table class="item-table">

                <tr>
                    <td>
                        <asp:Button ID="prdGroupDeleteButton" runat="server" Text="DELETE" Height="50px" Width="300" Font-Size="20pt" Visible="True" OnClick="prdGroupDeleteButton_Click" OnClientClick="return confirm('Are you sure you want to delete this item?');" />
                    </td>
                </tr>

            </table>
        </div>

    </div>



    <!-- CssClass="display compact" -->



    <script type="text/javascript">

        //On Page Load
        $(function () {
            createDataTable()
           

        });


        //On UpdatePanel Refresh
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    createDataTable();
                }
            });
        };

        function createDataTable() {
            $('#<%=jQueryProductGroupGridView.ClientID%>').DataTable(
                {
                    bLengthChange: true,
                    lengthMenu: [[5, 10, -1], [5, 10, "All"]],
                    bFilter: true,
                    bSort: true,
                    bPaginate: true,
                    retrieve: true,
                    stateSave: false,


                    // sScrollX: "100%",
                    // sScrollXInner: "100%",


                    //  scrollY: '50vh',
                    // scrollCollapse: true,
                    // responsive:true,
                    // bAutoWidth: false,
                    //  scrollY: 200,
                    //  scroller: true

                });

        }


        

    </script>

</asp:Content>
