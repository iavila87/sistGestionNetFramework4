<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SistemaIndumaqWeb.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido</title>
    <link href="styles/mainMaster.css" rel="stylesheet" />
    <link href="styles/items.css" rel="stylesheet" />
</head>
<body>
    <form id="Main" runat="server">
        <div>
            
            <div id="navbar">
                <ul>
                    <li><a class="seleccion" href="Main.aspx">Inicio</a></li>
                    <li><a href="Productos.aspx">Productos</a></li>
                    <li><a href="Proveedores.aspx">Proveedores</a></li>
                    <li><a href="Clientes.aspx">Clientes</a></li>
                    <li><a href="Ventas.aspx">Ventas</a></li>
                    
                    <li class="user">
                        <span style="display:list-item">
                            
                                <asp:Label CssClass="textoSup" ID="lblUser1" runat="server" Text="Usuario:" ForeColor="White"></asp:Label>
                            
                            
                                <asp:Label CssClass="textoInf" ID="lblUserValue1" runat="server" Text="Usuario" ForeColor="White"></asp:Label>
                            
                        </span>
                    <!--</li>
                    <li class="user">-->
                        <span>
                            
                                <asp:Label CssClass="textoSup" ID="lblRol1" runat="server" Text="Rol:" ForeColor="White"></asp:Label>
                            
                            
                                <asp:Label CssClass="textoInf" ID="lblRolValue1" runat="server" Text="Rol" ForeColor="White"></asp:Label>
                            
                        </span>
                    </li>
                    <li>
                        <asp:Button CssClass="logout" ID="btnLogout1" runat="server" OnClick="btnLogout_Click" Text="Logout" />  
                    </li>
                </ul>
            </div>
            
            <!-- aca todo codigo de la web a mostrar -->
            <div class="desplaza titulo">
                <asp:Image ID="imgIndumaq" runat="server" ImageUrl="~/Resources/indumaq.png" />
            </div>
                
            <div class="parrafo texto">
                <asp:Label ID="lblBienvenido" runat="server" Text="¡ Bienvenido !"></asp:Label>
            </div>
            <div class="parrafo">
                <asp:Image ID="imgMotor" runat="server" ImageUrl="~/Resources/motor02_75.png" />
            </div>

            <div id="footer" >
                <span > contacto@atsoft.com</span >
                <span > Whatsapp 341-2525036</span >
                <span > Derechos Reservados ATSoft - 2022</span >
            </div >
        </div>
        <!--<div>
            <div>
                <asp:Panel ID="Panel1" runat="server" BackColor="#3366FF" Height="40px">
                </asp:Panel>
            </div>
        </div>
        <asp:Panel ID="PanelMenu" runat="server" BackColor="#042944" Width="30%">
            <div>
                <asp:Label ID="lblUser" runat="server" Text="Usuario:" ForeColor="White"></asp:Label>
                <asp:Label ID="lblUserValue" runat="server" Text="Usuario" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Text="Rol:" ForeColor="White"></asp:Label>
                <asp:Label ID="lblRolValue" runat="server" Text="Rol" ForeColor="White"></asp:Label>
            </div>
            <div>
                <asp:Button ID="btnProductos" runat="server" Text="Productos" BackColor="#042944" BorderStyle="None" ForeColor="Gainsboro" Height="45px" Width="200px" OnClick="btnProductos_Click" />
                <asp:Button ID="btnProveedores" runat="server" BackColor="#042944" BorderStyle="None" ForeColor="Gainsboro" Height="45px" Text="Proveedores" Width="200px" OnClick="btnProveedores_Click" />
                <asp:Button ID="btnClientes" runat="server" BackColor="#042944" BorderStyle="None" ForeColor="Gainsboro" Height="45px" Text="Clientes" Width="200px" OnClick="btnClientes_Click" />
                <asp:Button ID="btnVentas" runat="server" BackColor="#042944" BorderStyle="None" ForeColor="Gainsboro" Height="45px" Text="Ventas" Width="200px" OnClick="btnVentas_Click" />
            </div>
            <div>
                <asp:Button ID="btnLogout" runat="server" BackColor="#042944" BorderStyle="None" ForeColor="Gainsboro" Height="45px" OnClick="btnLogout_Click" Text="Logout" Width="200px" />
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">
            <asp:MultiView ID="mvMain" runat="server">
                
                <asp:View ID="vwInicial" runat="server">
                    inicio
                </asp:View>

                <asp:View ID="vwProductos" runat="server">
                    productos
                </asp:View>

                <asp:View ID="vwProveedores" runat="server">
                    proveedores
                </asp:View>

                <asp:View ID="vwClientes" runat="server">
                    clientes
                </asp:View>

                <asp:View ID="vwVentas" runat="server">
                    ventas
                </asp:View>

            </asp:MultiView>
        </asp:Panel>  -->
        
    </form>
</body>
</html>
