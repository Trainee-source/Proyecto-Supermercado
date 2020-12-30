<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmarCompra.aspx.cs" Inherits="TrabajoPracticoFinalProgramacion3.ConfirmarCompra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
    </style>
</head>
<link href="Estilos%20CSS/popUp.css" rel="stylesheet"/>
<body>
    <form id="form1" runat="server">
        <div class="bg-modal">
            <div class="modal-content">
            <asp:MultiView ID="MultiView1" ActiveViewIndex="3" runat="server">
                <asp:View runat="server" ID="ViewRetiro">
                    <asp:Label ID="Label3" runat="server" Text="Elija si desea que su compra sea enviada a su domicilio o prefiere retirarla por la sucursal"></asp:Label>
                    
                    <br />
                    
                    <br />
                    
                        <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" runat="server" Height="59px" Width="493px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Value="1">     Envio a domicilio</asp:ListItem>
                            <asp:ListItem Value="2">     Retira por sucursal</asp:ListItem>
                        </asp:RadioButtonList>
                        

                    
                    <br />
                    <asp:Label ID="lblDireccion" runat="server" Text="Introduzca su domicilio: " Visible="false"></asp:Label>
                    <asp:TextBox ID="boxDireccion" runat="server" BackColor="#CCCCCC" BorderStyle="None" Visible="false"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblErrorDireccion" runat="server" ForeColor="Red" Text="Falta Escribir Una Direccion" Visible="false"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblError1" runat="server" Text="No ha elegido una opcion" ForeColor="Red" Visible="false"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Aceptar" OnClick="Button1_Click"/>
                        

                    
                </asp:View>

                <asp:View runat="server" ID="ViewPago">

                    Elija su metodo de pago<br />
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Height="59px" Width="493px">
                        <asp:ListItem Value="1">     Efectivo</asp:ListItem>
                        <asp:ListItem Value="2">     Pago Electronico</asp:ListItem>
                    </asp:RadioButtonList>

                    <br />
                    <asp:Label ID="lblError2" runat="server" ForeColor="Red" Text="No ha elegido una opcion" Visible="false"></asp:Label>
                    <br />

                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Atras" style="position: absolute; left: 30px;" OnClick="Button2_Click"/>
                    <asp:Button ID="Button3" runat="server" Text="Siguiente" style="position: absolute; right: 30px;" OnClick="Button3_Click"/>

                </asp:View>

                <asp:View runat="server" ID="ViewTarjeta">

                    Ingrese sus datos
                    <br />
                    <br />
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" >
                        <asp:ListItem>         Banco Provincia     </asp:ListItem>
                        <asp:ListItem>         Banco Provincia     </asp:ListItem>
                        <asp:ListItem>         Banco Nacion     </asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="Numero de Tarjeta:">   </asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="boxTarjetanro" runat="server" onkeypress="return justNumbers(event);" BackColor="#CCCCCC" BorderStyle="None"></asp:TextBox>
                    <asp:Label ID="lblTarjeta" runat="server" Text="*" Visible="False" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Numero de Seguridad:">   </asp:Label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="boxTarjetaSeg" runat="server" onkeypress="return justNumbers(event);" BackColor="#CCCCCC" BorderStyle="None"></asp:TextBox>
                    <asp:Label ID="lblSeguridad" runat="server" Text="*" Visible="False" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblCampos" runat="server" ForeColor="Red" Text="Falta Completar Campos" Visible="false"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblError3" runat="server" ForeColor="Red" Text="No ha elegido una opcion" Visible="false"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button4" runat="server" Text="Atras" style="position: absolute; left: 30px;" OnClick="Button4_Click"/>
                    <asp:Button ID="Button5" runat="server" Text="Finalizar" style="position: absolute; right: 30px;" OnClick="Button5_Click"/>
                    <br />

                </asp:View>

                <asp:View runat="server" ID="ViewFinal">Se ha completado la operacion con exito<br />
                    <br />
                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Aceptar" />
                </asp:View>
            </asp:MultiView>
                </div>
        </div>
    </form>
</body>
</html>
