    <%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="ListaProductos.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.Formulario_web11" %>
<%@ MasterType VirtualPath="~/Placa.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="Estilos%20CSS/EstilosGridViews.css" type="text/css" rel="stylesheet" media="screen"/>
    <link href="Estilos%20CSS/EstiloCarrito.css" type="text/css" rel="stylesheet" media="screen"/>

    <style type="text/css"> .hiddencol { display: none; } </style>

    <div id="barraDerecha">

        Eliga un categoria
        <br />
        <asp:DropDownList ID="ListaCategorias" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListaCategorias_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Eliga una marca<br />
        <asp:DropDownList ID="ListaMarcas" runat="server" AutoPostBack="true" Visible="false">
        </asp:DropDownList>
        <br />
        <br />
        Rango de precios:<br />
        Desde:<br />
        <asp:TextBox ID="PrecioMin" onkeypress="return justNumbers(event);" runat="server"></asp:TextBox>
        <br />
        A<br />
        <asp:TextBox ID="PrecioMax" onkeypress="return justNumbers(event);" runat="server"></asp:TextBox>

        <br />
        <br />
        <asp:Button ID="BotonAceptar" runat="server" Text="Aceptar" OnClick="Aceptar_Click" />

    </div>
    <div id = "testo">
        <asp:GridView ID="GridListado" runat="server" AutoGenerateColumns="False" AllowPaging="True" BorderColor="Black" BorderWidth="3px" PageSize="3" Width="658px"
            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" OnPageIndexChanging="GridListado_PageIndexChanging"  >
            <Columns>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />

                <asp:BoundField DataField="IdProducto_p" HeaderText ="Id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />

                <asp:BoundField DataField="NombreProducto_p" HeaderText ="Producto"  />
                <asp:BoundField DataField="Descripcion_p" HeaderText ="Detalles" />
                <asp:BoundField DataField="PrecioUnitario_p" HeaderText ="Precio por unidad" />


                <asp:TemplateField HeaderText="Imagen" HeaderStyle-CssClass="hiddencol">
                    <ItemTemplate>
                            <asp:Image runat ="server" Imageurl='<%# Eval("Imagen_p") %>' Height="100px" Width="100px" ID="Image"  />
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>

       

<HeaderStyle CssClass="header"></HeaderStyle>

<RowStyle CssClass="rows"></RowStyle>
        </asp:GridView>
    </div>

    <div id="carrito">
        <div id="carritoContenido">
                <asp:GridView id="GridCarro" runat="server" Width="50%" AllowPaging="True" AutoGenerateColumns="False" PageSize="3" OnPageIndexChanging="GridCarro_PageIndexChanging">
                    <Columns>
                        <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" />  

                        <asp:BoundField DataField="ProductoNombre" HeaderText ="Producto" />
                        <asp:BoundField DataField="ProductoPrecio" HeaderText ="Precio" />


                        <asp:TemplateField HeaderText="Cantidad" >
                            <ItemTemplate>
                                <asp:TextBox id="cantidad" runat="server" onkeypress="return justNumbers(event);" OnTextChanged="cantidad_TextChanged" Text='<%#Bind("ProductoCantidad") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Subtotal">
                            <ItemTemplate>
                                <asp:Label id="subtotal"  AutoPostBack="true" Text='<%#Bind("ProductoSubTotal") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        
        
        
        <div id="carritoTotal">
        <asp:Button ID="Button1" runat="server" Text="Confirmar Compra" OnClick="Button1_Click" />
        </div>
        
        

    </div>


</asp:Content>
