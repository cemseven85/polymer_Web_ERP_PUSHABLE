<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="partModulWImg.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.partModulWImg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <!-- Add Part -->
        <div class="menu-item">
            <asp:Panel ID="Panel1" runat="server">

                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Select Machine Group :" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlMachineGroupID" runat="server" CssClass="product-type-modify-dropdown" DataSourceID="dsMachineGroup" DataValueField="machineGroup_ID" DataTextField="machineGroup_Name" AutoPostBack="True" OnSelectedIndexChanged="ddlMachineGroupID_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource ID="dsMachineGroup" runat="server" ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>" SelectCommand="SELECT machineGroup_ID, machineGroup_Name FROM tbl_machineGroup"></asp:SqlDataSource>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlMachineGroupID" ErrorMessage="Machine Group ID is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="menu-item">
            <asp:Panel ID="Panel2" runat="server">

                <table class="item-table">
                    <tr>
                        <td>


                            <asp:Label ID="Label3" runat="server" Text="Select Machine :" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlMachineID" runat="server" CssClass="product-type-modify-dropdown" DataSourceID="dsMachine" DataValueField="machine_ID" DataTextField="machine_Name"></asp:DropDownList>
                            <asp:SqlDataSource ID="dsMachine" runat="server" ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>" SelectCommand="SELECT machine_ID, machine_Name FROM tbl_machine WHERE machineGroup_ID = @machineGroup_ID">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlMachineGroupID" PropertyName="SelectedValue" Name="machineGroup_ID" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlMachineID" ErrorMessage="Machine ID is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Panel3" runat="server">

                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="Select Part Type :" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlPartTypeID" runat="server" CssClass="product-type-modify-dropdown" DataSourceID="dsPartType" DataValueField="partType_ID" DataTextField="partType_Name" AutoPostBack="True" OnSelectedIndexChanged="ddlPartTypeID_SelectedIndexChanged"></asp:DropDownList>
                            <asp:SqlDataSource ID="dsPartType" runat="server" ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>" SelectCommand="SELECT partType_ID, partType_Name FROM tbl_partType"></asp:SqlDataSource>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlPartTypeID" ErrorMessage="Part Type ID is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Panel4" runat="server">

                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Select Part Group :" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlPartGroupID" runat="server" CssClass="product-type-modify-dropdown" DataSourceID="dsPartGroup" DataValueField="partGroup_ID" DataTextField="partGroup_Name"></asp:DropDownList>
                            <asp:SqlDataSource ID="dsPartGroup" runat="server" ConnectionString="<%$ ConnectionStrings:polymerConnectionString %>" SelectCommand="SELECT partGroup_ID, partGroup_Name FROM tbl_partGroup WHERE partType_ID = @partType_ID">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlPartTypeID" PropertyName="SelectedValue" Name="partType_ID" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPartGroupID" ErrorMessage="Part Group ID is required." ForeColor="Red"></asp:RequiredFieldValidator>


                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Panel5" runat="server">

                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Part Name :" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPartName" CssClass="textBoxL" runat="server" Font-Size="20pt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPartName" ErrorMessage="Part Name is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Part Code :" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPartCode" CssClass="textBox" runat="server" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Barcode :" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPartBarCode" CssClass="textBox" runat="server" Font-Size="20pt"></asp:TextBox>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Panel6" runat="server">

                <table class="item-table">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Part Description :" Font-Size="20pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtPartDescription" CssClass="textBox" runat="server" Font-Size="20pt" Max-Width="650px" Width="98%" Height="200px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <div class="menu-item">
            <asp:Panel ID="Panel7" runat="server">

                <table class="item-table">
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label13" runat="server" Text=" Select Part Image  From Data Base" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label5" runat="server" Text=" Select Part Image  1 =" Font-Size="15pt"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="fuPartImage_1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label10" runat="server" Text=" Select Part Image 2 =" Font-Size="15pt"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="fuPartImage_2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label11" runat="server" Text=" Select Part Image  3 =" Font-Size="15pt"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="fuPartImage_3" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label12" runat="server" Text=" Select Part Image 4 =" Font-Size="15pt"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="fuPartImage_4" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="part_Image_5_Label" runat="server" Text=" Select Part Image 5 =" Font-Size="15pt"></asp:Label>
                        </td>
                        <td>
                            <asp:FileUpload ID="fuPartImage_5" runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Text="UpLoad New Image To Data Base" Font-Size="15pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="Button1" runat="server" Text="Upload Image" OnClick="Button1_Click" />
                        </td>
                    </tr>

                    
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td style="display: flex; justify-content: flex-start;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to save this part?');" OnClick="btnSave_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Font-Size="20pt" OnClientClick="return confirm('Are you sure you want to cancel this part?');" OnClick="btnCancel_Click" />
                        </td>
                    </tr>

                </table>
            </asp:Panel>
        </div>

        <!-- Edit & Delete Part List -->
        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Part_List_Panel" runat="server" GroupingText="Edit & Delete Part List">
                <asp:GridView ID="gvPart" runat="server" DataKeyNames="part_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvPart_PreRender" OnRowEditing="gvPart_RowEditing" OnRowCancelingEdit="gvPart_RowCancelingEdit" OnRowUpdating="gvPart_RowUpdatig" OnRowDataBound="gvPart_RowDataBound" OnRowDeleting="gvPart_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="Part ID">
                            <ItemTemplate>
                                <asp:Label ID="lblPart_ID" runat="server" Text='<%# Bind("part_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Name">
                            <ItemTemplate>
                                <asp:Label ID="lblPartName" runat="server" Text='<%# Bind("part_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPart_Name" runat="server" Text='<%# Bind("part_Name") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Code">
                            <ItemTemplate>
                                <asp:Label ID="lblPartCode" runat="server" Text='<%# Bind("part_Code") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPart_Code" runat="server" Text='<%# Bind("part_Code") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Barcode">
                            <ItemTemplate>
                                <asp:Label ID="lblBarcode" runat="server" Text='<%# Bind("part_BarCode") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPart_BarCode" runat="server" Text='<%# Bind("part_BarCode") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Description">
                            <ItemTemplate>
                                <asp:Label ID="lblPartDescription" runat="server" Text='<%# Bind("part_Description") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPart_Description" runat="server" Text='<%# Bind("part_Description") %>'></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Machine ID">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineID" runat="server" Text='<%# Bind("machine_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlMachine_ID" runat="server" DataTextField="machine_Name" DataValueField="machine_ID"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Group ID">
                            <ItemTemplate>
                                <asp:Label ID="lblPartGroupID" runat="server" Text='<%# Bind("partGroup_Name") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlPartGroup_ID" runat="server" DataTextField="partGroup_Name" DataValueField="partGroup_ID"></asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Image">
                            <ItemTemplate>
                                <asp:Image ID="imgPartImage" runat="server" ImageUrl='<%# Bind("part_Image_Path_1") %>' Height="100px" Width="100px" CssClass="enlarge-image" style="display: block; margin: 0 auto;"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CausesValidation="false"  style="background-color: forestgreen"/>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CausesValidation="false" style="background-color: red" OnClientClick="return confirm('Are you sure you want to delete this part?');" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" CausesValidation="false"  style="background-color: forestgreen" OnClientClick="return confirm('Are you sure you want to update this part?');" />
                                <asp:Button ID="Button1" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false"  style="background-color: lightsalmon"/>
                                
                                <asp:Button ID="btnUpdateImage" runat="server" Text="Update Part Images" CausesValidation="false" OnClick="btnUpdateImage_Click" style="background-color: lightgreen; float: right;" />

                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>


    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvPart.ClientID %>').DataTable();
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.enlarge-image').click(function () {
                var imageUrl = $(this).attr('src');
                var enlargedImageUrl = imageUrl.replace('100x100', '500x500'); // Replace the image URL with a larger version

                //// Open the enlarged image in a new window or tab
                //window.open(enlargedImageUrl, '_blank');

                //// Open the enlarged image in the same tab
                //window.location.href = enlargedImageUrl;

                // Open the enlarged image in the same tab with a close button
                var closeButton = '<button id="closeButton" style="position: absolute; top: 10%; right: 10%; transform: scale(2);">Close</button>';
                var imageContainer = '<div id="imageContainer" style="position: fixed; top: 0; left: 0; width: 100%; height: 100%; background-color: rgba(0, 0, 0, 0.8); display: flex; justify-content: center; align-items: center;">' +
                    '<img src="' + enlargedImageUrl + '" style="max-width: 90%; max-height: 90%;" />' +
                    closeButton +
                    '</div>';

                $('body').append(imageContainer);

                $('#closeButton').click(function () {
                    $('#imageContainer').remove();
                });

            });
        });
    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            $('.product-type-modify-dropdown').chosen();
        });
    </script>




</asp:Content>
