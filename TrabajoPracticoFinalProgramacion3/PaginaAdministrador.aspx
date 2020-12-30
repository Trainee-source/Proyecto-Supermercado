<%@ Page Title="" Language="C#" MasterPageFile="~/Placa.Master" AutoEventWireup="true" CodeBehind="PaginaAdministrador.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.Formulario_web15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Estilos%20CSS/Estilo%20Administrador.css" rel="stylesheet" type="text/css" runat="server"/>
    <style type="text/css"> .hiddencol { display: none; } </style>

    <div class="ventanaAdmin">
                <div class="botones">
                    <asp:Button ID="btnAgregarProducto" Text="Agregar Producto" runat="server" CssClass="Initial" OnClick="btnAgregarProducto_Click"/>
                    <asp:Button ID="btnEditarProductos" Text="Editar Productos" runat="server" CssClass="Initial" OnClick="btnEditarProductos_Click"/>
                    <asp:Button ID="btnReportes" Text="Reportes Ventas" runat="server" CssClass="Initial" OnClick="btnReportes_Click"/>
                    <asp:Button ID="btnProductos" Text="Reportes Productos" runat="server" CssClass="Initial" OnClick="btnProductos_Click" />
                    <asp:Button ID="btnStock" Text="Reportes Stock" runat="server" CssClass="Initial" OnClick="btnStock_Click" />
                    <asp:Button ID="btnMarcas" Text="Editar Marcas" runat="server" CssClass="Initial" OnClick="btnMarcas_Click" />
                </div>
                
               
                <div class="solapasAdmin">
                    <asp:MultiView ID="Grilla" ActiveViewIndex="0" runat="server">

                        <asp:View runat="server">

                            <div class="grid_scroll">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="99%" OnRowCommand="GridView1_RowCommand">
                                <Columns>

                                    <asp:CommandField SelectText="Editar" ShowSelectButton="True" ButtonType="Link" />

                                    <asp:BoundField DataField="IdProducto_p" HeaderText ="Id" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
                                    <asp:BoundField DataField="NombreProducto_p" HeaderText="Nombre del Producto" SortExpression="NombreProducto_p"/>
                                    <asp:BoundField DataField="Stock_p" HeaderText="Stock" SortExpression="Stock_p" />
                                    <asp:BoundField DataField="PrecioUnitario_p" HeaderText="Precio Unitario" SortExpression="PrecioUnitario_p" />
                                    <asp:BoundField DataField="Descripcion_p" HeaderText="Descripcion" SortExpression="Descripcion_p" />
                                    <asp:BoundField DataField="IdCategoria_p" HeaderText="IdCategoria" SortExpression="IdCategoria_p" />
                                    <asp:BoundField DataField="IdMarca_p" HeaderText="IdMarca" SortExpression="IdMarca_p"/>
                                    <asp:CheckBoxField DataField="Estado_p" HeaderText="Estado" SortExpression="Estado_p" />
                                </Columns>
                            </asp:GridView>
                            </div>
                           
                        </asp:View>

                        <asp:View runat="server">
                            <asp:Label Text="Ventas" runat="server" class="labels"/>
                            <br />
                            <asp:DropDownList ID="ListaFechas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListaFechas_SelectedIndexChanged">
                            </asp:DropDownList>
                            <div class="grid_scroll">
                            <asp:GridView ID="GridVentas" runat="server" AutoGenerateColumns="false"  Width="90%">
                                <Columns>
                                    <asp:BoundField DataField="IdVenta_v" HeaderText="Id Venta" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="DniUsuario_v" HeaderText="Dni Usuario" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="Domicilio_v" HeaderText="Domicilio" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="Fecha_v" HeaderText="Fecha" DataFormatString = "{0:dd/MM/yyyy}" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="Monto_v" HeaderText="Monto" SortExpression="NombreProducto_p" />
                                </Columns>
                            </asp:GridView>
                                </div>
                            <asp:Label ID="lblTotalVentas" Text="" runat="server" ForeColor="White" Font-Size="20px"/>
                        </asp:View>
                        <asp:View runat="server">
                            <asp:Label Text="Productos" runat="server" class="labels"/>
                            <div class="grid_scroll">
                            <asp:GridView ID="GridProductos" runat="server" AutoGenerateColumns="false" Height="" Width="90%">
                                <Columns>
                                    <asp:BoundField DataField="NombreProducto_p" HeaderText="Nombre Producto" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="Descripcion_p" HeaderText="Descripcion" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="PrecioUnitario_p" HeaderText="Precio" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad Vendida" SortExpression="NombreProducto_p" />
                                </Columns>
                            </asp:GridView>
                                </div>
                        </asp:View>
                        <asp:View runat="server">
                            <asp:Label Text="Stock" runat="server" class="labels"/>
                            <div class="grid_scroll">
                            <asp:GridView ID="GridStock" runat="server" AutoGenerateColumns="false" Height="" Width="90%">
                                <Columns>
                                    <asp:BoundField DataField="NombreProducto_p" HeaderText="Nombre Producto" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="Descripcion_p" HeaderText="Descripcion" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="PrecioUnitario_p" HeaderText="Precio" SortExpression="NombreProducto_p" />
                                    <asp:BoundField DataField="Stock_p" HeaderText="Stock En Bodega" SortExpression="NombreProducto_p" />
                                </Columns>
                            </asp:GridView>
                                </div>
                        </asp:View>
                    </asp:MultiView>
                </div>
    </div>
</asp:Content>
