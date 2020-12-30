<%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="PaginaUsuario.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos%20CSS/Estilos%20Usuario.css" rel="stylesheet" type="text/css" runat="server"/>
    <link href="Estilos%20CSS/PaginaCarrito.css" rel="stylesheet" type="text/css" runat="server"/>
    <style type="text/css"> .hiddencol { display: none; } 
        </style>

        <div class="ventana">
            <div class="botones">
                <asp:Button ID="btnCompras" Text="Compras" runat="server" CssClass="Initial" OnClick="btnCompras_Click"/>
                <asp:Button ID="btnPerfil" Text="Perfil" runat="server" CssClass="Initial" OnClick="btnPerfil_Click"/>
            </div>
            <div class="solapas">
                <asp:MultiView ActiveViewIndex="1" id="MultiView1" runat="server" >
                    <asp:View runat="server" ID="VistaCompras">
                        <asp:Label Text="Pedidos" runat="server" class="labels"/>
                        
                        <br />
                        <asp:DropDownList ID="ListaFechaVenta" runat="server" style="margin-left: 50px;" AutoPostBack="True" OnSelectedIndexChanged="ListaFechaVenta_SelectedIndexChanged">
                        </asp:DropDownList>
                      <div class="grid_scroll">       
                          
                          <asp:GridView ID="GridRecompras" runat="server" AutoGenerateColumns="false" Width="780px" >
                              <AlternatingRowStyle VerticalAlign="Middle" Wrap="False" />
                              <Columns>

                                  <asp:BoundField DataField="IdVenta_dv" HeaderText="Id Venta" HeaderStyle-CssClass="hiddencol"  ItemStyle-CssClass="hiddencol"/>
                                  <asp:BoundField DataField="IdProducto_dv" HeaderText="Id Producto" HeaderStyle-CssClass="hiddencol"  ItemStyle-CssClass="hiddencol"/>
                                  <asp:BoundField DataField="NombreProducto_p" HeaderText="Producto" />
                                  <asp:BoundField DataField="PrecioUnitario_p" HeaderText="Precio" />
                                  <asp:BoundField DataField="Cantidad_dv" HeaderText="Cantidad Comprada" />
                                  <asp:BoundField DataField="SubTotal_dv" HeaderText="Total de la Compra" />

                                  <asp:TemplateField HeaderStyle-CssClass="hiddencol" HeaderText="Imagen">
                                      <ItemTemplate>
                                          <asp:Image ID="Image" runat="server" Height="100px" Imageurl='<%# Eval("Imagen_p") %>' Width="100px" />
                                      </ItemTemplate>
                                  </asp:TemplateField>

                              </Columns>
                        </asp:GridView>

                          

                        </div>  
                    <asp:Button ID="BotonRecompra" runat="server" Text="Agregar Compra a Carrito" OnClick="BotonRecompra_Click" />
                        <br />
                        <br />
                        <br />

                        <div class="grid_scroll">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" width="780px" >
                            <AlternatingRowStyle VerticalAlign="Middle" Wrap="False" />
                              <Columns>
                                  <asp:CommandField SelectText="Eliminar" ShowSelectButton="True"></asp:CommandField>

                                  <asp:BoundField DataField="ProductoId" HeaderText="Id Producto" HeaderStyle-CssClass="hiddencol"  ItemStyle-CssClass="hiddencol"/>
                                  <asp:BoundField DataField="ProductoNombre" HeaderText="Producto" />
                                  <asp:BoundField DataField="ProductoPrecio" HeaderText="Precio" />
                                  <asp:BoundField DataField="ProductoCantidad" HeaderText="Cantidad" />
                                  <asp:BoundField DataField="ProductoSubTotal" HeaderText="SubTotal" />

                                  <asp:TemplateField HeaderStyle-CssClass="hiddencol" HeaderText="Imagen">
                                      <ItemTemplate>
                                          <asp:Image ID="Image" runat="server" Height="100px" Imageurl='<%# Eval("ProductoImg") %>' Width="100px" />
                                      </ItemTemplate>
                                  </asp:TemplateField>

                              </Columns>
                        </asp:GridView>
                            </div>
                        <asp:Button Text="Comprar" runat="server" OnClick="Unnamed4_Click" />
                        <asp:Button Text="Continuar Browsing" runat="server" OnClick="Unnamed5_Click" />
                    </asp:View>
                        
                        
                    <asp:View runat="server" ID="VistaPerfil">
                        <asp:Label Text="Informacion Personal" runat="server" class="labels"/>
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:Label id="lblDni" Text="text" runat="server" class="labels"/>
                        <br />
                        <asp:Label id="lblNombre" Text="text" runat="server" class="labels"/>
                        <br />
                        <asp:Label id="lblApellido" Text="text" runat="server" class="labels" />
                        <br />
                        <asp:Label id="lblEmail" Text="text" runat="server" class="labels"/>

                        <br />
                        <br />

                        <asp:Button ID="btnEditarPerfil" runat="server" Text="Editar Perfil" EnableTheming="True" OnClick="btnEditarPerfil_Click" />
                    </asp:View>

                </asp:MultiView>
            </div>
        </div>

</asp:Content>
