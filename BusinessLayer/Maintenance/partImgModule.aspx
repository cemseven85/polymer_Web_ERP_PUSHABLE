<%@ Page Title="" Language="C#" MasterPageFile="~/polymer_ERPV2.0.Master" AutoEventWireup="true" CodeBehind="partImgModule.aspx.cs" Inherits="polymer_Web_ERP_V4.BusinessLayer.Maintenance.partImgModule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="product-type">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <!-- Part Details List -->
        <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Part_List_Panel" runat="server" GroupingText="Part Detail List">
                <asp:GridView ID="gvPart" runat="server" DataKeyNames="part_ID" CssClass="product-type-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvPart_PreRender">
                    <Columns>
                        <asp:TemplateField HeaderText="Part ID">
                            <ItemTemplate>
                                <asp:Label ID="lblPart_ID" runat="server" Text='<%# Bind("part_ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Machine Group">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineGroup" runat="server" Text='<%# Bind("machineGroup_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Machine Name">
                            <ItemTemplate>
                                <asp:Label ID="lblMachineID" runat="server" Text='<%# Bind("machine_Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Part Type">
                            <ItemTemplate>
                                <asp:Label ID="lblPartType" runat="server" Text='<%# Bind("partType_Name") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part Group">
                                <itemtemplate>
                                    <asp:Label ID="lblPartGroupID" runat="server" Text='<%# Bind("partGroup_Name") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part Name">
                                <itemtemplate>
                                    <asp:Label ID="lblPartName" runat="server" Text='<%# Bind("part_Name") %>' style="background-color: lightgreen; font-weight: bold;"></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Part Code">
                                <itemtemplate>
                                    <asp:Label ID="lblPartCode" runat="server" Text='<%# Bind("part_Code") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Barcode">
                                <itemtemplate>
                                    <asp:Label ID="lblBarcode" runat="server" Text='<%# Bind("part_BarCode") %>'></asp:Label>
                                </itemtemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Part Description">
                                <itemtemplate>
                                    <asp:Label ID="lblPartDescription" runat="server" Text='<%# Bind("part_Description") %>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>


        <%--  <div class="menu-item-datalist" style="overflow: scroll">
            <asp:Panel ID="Panel_Img_Panel" runat="server" GroupingText="Edit Part Img">
                <asp:GridView ID="gvImgPart" runat="server" DataKeyNames="part_ID" CssClass="product-typeIMG-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvImgPart_PreRender">
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
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Part Image" >
                            <ItemTemplate>                                
                                <asp:Image ID="imgPartImage" runat="server" ImageUrl='<%# Bind("part_Image_Path_1") %>' Height="100px" Width="100px" CssClass="enlarge-image" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Image 2">
                            <ItemTemplate>
                                <asp:Image ID="imgPartImage2" runat="server" ImageUrl='<%# Bind("part_Image_Path_2") %>' Height="100px" Width="100px" CssClass="enlarge-image" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Image 3">
                            <ItemTemplate>
                                <asp:Image ID="imgPartImage3" runat="server" ImageUrl='<%# Bind("part_Image_Path_3") %>' Height="100px" Width="100px" CssClass="enlarge-image" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Image 4">
                            <ItemTemplate>
                                <asp:Image ID="imgPartImage4" runat="server" ImageUrl='<%# Bind("part_Image_Path_4") %>' Height="100px" Width="100px" CssClass="enlarge-image" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Part Image 5">
                            <ItemTemplate>
                                <asp:Image ID="imgPartImage5" runat="server" ImageUrl='<%# Bind("part_Image_Path_5") %>' Height="100px" Width="100px" CssClass="enlarge-image" />
                            </ItemTemplate>                           
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>--%>

        <asp:GridView ID="gvImgPart" runat="server" DataKeyNames="part_ID" CssClass="product-typeIMG-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvImgPart_PreRender" OnRowDataBound="gvImgPart_RowDataBound" ShowFooter="true">
            <Columns>
                <asp:TemplateField HeaderText="Part ID">
                    <ItemTemplate>
                        <asp:Label ID="lblPart_ID" runat="server" Text='<%# Bind("part_ID") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<FooterTemplate>
                        <asp:Label ID="Label_Emp1" runat="server" Text="Label"></asp:Label>
                    </FooterTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Name">
                    <ItemTemplate>
                        <asp:Label ID="lblPartName" runat="server" Text='<%# Bind("part_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <%-- <FooterTemplate>
                        <asp:Label ID="Label_Emp2" runat="server" Text="Label"></asp:Label>
                    </FooterTemplate>--%>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Part Image">
                    <ItemTemplate>
                        <asp:Image ID="imgPartImage" runat="server" ImageUrl='<%# Bind("part_Image_Path_1") %>' Height="100px" Width="100px" CssClass="enlarge-image" Style="display: block; margin: 0 auto;" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fuPartImage" runat="server" />
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" Style="background-color: forestgreen" OnClick="btnUpload_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Image 2">
                    <ItemTemplate>
                        <asp:Image ID="imgPartImage2" runat="server" ImageUrl='<%# Bind("part_Image_Path_2") %>' Height="100px" Width="100px" CssClass="enlarge-image" Style="display: block; margin: 0 auto;" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fuPartImage2" runat="server" />
                        <asp:Button ID="btnUpload_2" runat="server" Text="Upload" Style="background-color: forestgreen" OnClick="btnUpload_2_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Image 3">
                    <ItemTemplate>
                        <asp:Image ID="imgPartImage3" runat="server" ImageUrl='<%# Bind("part_Image_Path_3") %>' Height="100px" Width="100px" CssClass="enlarge-image" Style="display: block; margin: 0 auto;" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fuPartImage3" runat="server" />
                        <asp:Button ID="btnUpload_3" runat="server" Text="Upload" Style="background-color: forestgreen" OnClick="btnUpload_3_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Image 4">
                    <ItemTemplate>
                        <asp:Image ID="imgPartImage4" runat="server" ImageUrl='<%# Bind("part_Image_Path_4") %>' Height="100px" Width="100px" CssClass="enlarge-image" Style="display: block; margin: 0 auto;" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fuPartImage4" runat="server" />
                        <asp:Button ID="btnUpload_4" runat="server" Text="Upload" Style="background-color: forestgreen" OnClick="btnUpload_4_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Image 5">
                    <ItemTemplate>
                        <asp:Image ID="imgPartImage5" runat="server" ImageUrl='<%# Bind("part_Image_Path_5") %>' Height="100px" Width="100px" CssClass="enlarge-image" Style="display: block; margin: 0 auto;" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:FileUpload ID="fuPartImage5" runat="server" />
                        <asp:Button ID="btnUpload_5" runat="server" Text="Upload" Style="background-color: forestgreen" OnClick="btnUpload_5_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <%--  <asp:GridView ID="gvImgPartUpload" runat="server" DataKeyNames="part_ID" CssClass="product-typeIMG-gridview" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" OnPreRender="gvImgPartUpload_PreRender">
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
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Part Image">

                    <ItemTemplate>
                        <asp:FileUpload ID="fuPartImage" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Image 2">
                    <ItemTemplate>
                        <asp:FileUpload ID="fuPartImage2" runat="server" Height="100px" Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Image 3">
                    <ItemTemplate>
                        <asp:FileUpload ID="fuPartImage3" runat="server" Height="100px" Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Image 4">
                    <ItemTemplate>
                        <asp:FileUpload ID="fuPartImage4" runat="server" Height="100px" Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Part Image 5">
                    <ItemTemplate>
                        <asp:FileUpload ID="fuPartImage5" runat="server" Height="100px" Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>




        </asp:Panel>
    </div>

    </div>


    <%-- <script type="text/javascript">
         $(document).ready(function () {
             $('.enlarge-image').click(function () {
                 var imageUrl = $(this).attr('src');
                 var enlargedImageUrl = imageUrl.replace('100x100', '500x500'); // Replace the image URL with a larger version

                 // Open the enlarged image in a new window or tab
                 window.open(enlargedImageUrl, '_blank');
             });
         });
     </script>--%>



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


</asp:Content>
