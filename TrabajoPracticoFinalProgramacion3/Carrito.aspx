<%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos%20CSS/PaginaCarrito.css" rel="stylesheet" type="text/css" runat="server"/>
    <style type="text/css"> .hiddencol { display: none; } </style>
    <div class="bodygrill">
        <div class="items">
            <div class="grid_scroll">
            <asp:GridView ID="GridCompra" runat="server" AutoGenerateColumns="False" Height="300px" >
                <Columns>
                        <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />

                        <asp:BoundField DataField="ProductoNombre" headertext="Producto" ItemStyle-CssClass="rows"/>
                        <asp:BoundField DataField="ProductoPrecio" headertext="Precio" ItemStyle-CssClass="rows"/>

                        <asp:TemplateField ItemStyle-CssClass="rows" headertext="Cantidad">
                            <ItemTemplate>
                                <asp:Label id="cantidadCompra" runat="server" Text='<%#Bind("ProductoCantidad") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="rows" headertext="SubTotal">
                            <ItemTemplate>
                                <asp:Label id="subtotal"  AutoPostBack="true" Text='<%#Bind("ProductoSubTotal") %>' runat="server"  />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ItemStyle-CssClass="rows" headertext="Imagen">
                            <ItemTemplate>
                                    <asp:Image runat ="server" Imageurl='<%# Eval("ProductoImg") %>' Height="100px" Width="100px" ID="Image"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>
                
                </div>
            <asp:Button Text="Confirmar Compra" runat="server" OnClick="Unnamed1_Click" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    



    </div>
</asp:Content>
