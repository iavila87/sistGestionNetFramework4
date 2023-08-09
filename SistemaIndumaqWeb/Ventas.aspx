<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="SistemaIndumaqWeb.Ventas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ventas</title>
    <link href="styles/mainMaster.css" rel="stylesheet" />
    <link href="styles/items.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="navbar">
            <ul>
                <li><a href="Main.aspx">Inicio</a></li>
                <li><a href="Productos.aspx">Productos</a></li>
                <li><a href="Proveedores.aspx">Proveedores</a></li>
                <li><a href="Clientes.aspx">Clientes</a></li>
                <li><a class="seleccion" href="Ventas.aspx">Ventas</a></li>

                <li class="user">
                    <span style="display: list-item">

                        <asp:Label CssClass="textoSup" ID="lblUser1" runat="server" Text="Usuario:" ForeColor="White"></asp:Label>
                        <asp:Label CssClass="textoInf" ID="lblUserValue1" runat="server" Text="Usuario" ForeColor="White"></asp:Label>
                    </span>
                    <span>
                        <asp:Label CssClass="textoSup" ID="lblRol1" runat="server" Text="Rol:" ForeColor="White"></asp:Label>
                        <asp:Label CssClass="textoInf" ID="lblRolValue1" runat="server" Text="rol"></asp:Label>

                    </span>

                </li>
                <li>
                    <asp:Button CssClass="logout" ID="btnLogout1" runat="server" OnClick="btnLogout_Click" Text="Logout" />
                </li>
                
            </ul>
            
        </div>
        
        <!-- aca todo codigo de la web a mostrar -->
        <div class="cuerpo desplaza">
        <div class="contTabla">
            <asp:GridView runat="server" ID="Gv1" AutoGenerateColumns="true" 
                GridLines="None" CssClass="mGrid">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%if ( lblRolValue1.Text.Equals("Admin")) {  %>
                            <asp:LinkButton ID="lbtnBorrar" CssClass="linkboton" runat="server" OnClick="lbtnBorrar_Click">Borrar</asp:LinkButton>
                            <asp:LinkButton ID="lbtnVer" CssClass="linkboton" runat="server" OnClick="lbtnVer_Click">Ver</asp:LinkButton>            
                            <% } %>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div id="conterror" class="conterror" runat="server">
                <div class="cuadroAlerta">
                    
                    <asp:Label CssClass="lblerror" runat="server" Text="" ID="lblError"></asp:Label>
                    <asp:Button ID="btnAceptarError" CssClass="botonError" runat="server" Text="Aceptar" OnClick="btnAceptarError_Click" />

                    
                </div>
            </div>

        </div>
        <%if ( lblRolValue1.Text.Equals("Admin")) {  %>
        <div id="agregar" class="contAgregar" runat="server">
            <h1 id="titParrafo" class="tituloParrafo" runat="server">Agregar nuevo producto para la venta</h1>
            
            <div class="divisiones">
                <asp:Label ID="lblCliente" CssClass="lblBox" runat="server" Text="Cliente:"></asp:Label>
                <asp:DropDownList ID="ddClil" CssClass="txtBox" runat="server"></asp:DropDownList>
            </div>
            
            <div class="divisiones">
                <asp:Label ID="lblProducto" CssClass="lblBox" runat="server" Text="Producto:"></asp:Label>
                <asp:DropDownList ID="ddProdl" CssClass="txtBox" runat="server" OnSelectedIndexChanged="ddProdl_SelectedIndexChanged"></asp:DropDownList>
            </div>
            
            <div class="divisiones">
                <asp:Label ID="lblCantidad" CssClass="lblBox" runat="server" Text="Cantidad:"></asp:Label>
                <asp:TextBox ID="txtCantidad" CssClass="txtBox" runat="server"></asp:TextBox>
            </div>
            
            <div class="divisiones">
                <asp:Button ID="btnAgregarProd" CssClass="boton" runat="server" Text="Agregar Producto"  OnClick="btnAgregarProd_Click" />
                <asp:Button ID="btnLimpiar" CssClass="boton bderecho" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
            </div>

            <div class="divisiones">
                <asp:Button ID="btnAgregarVenta" CssClass="boton" runat="server" Text="Agregar Venta"  OnClick="btnAgregarVenta_Click" />
                <asp:Button ID="btnCancelar" CssClass="boton bderecho" runat="server" Text="Cancelar Venta" OnClick="btnCancelar_Click" />
            </div>

            <div class="divisiones">
                <asp:GridView runat="server" ID="Gv2" AutoGenerateColumns="true" 
                    GridLines="None" CssClass="mGrid">
                    
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnBorrarProd" CssClass="linkboton" runat="server" OnClick="lbtnBorrarProd_Click">Borrar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <% } %>
        <!-- -->

        <div id="footer">
            <span>contacto@atsoft.com</span>
            <span>Whatsapp 341-2525036</span>
            <span>Derechos Reservados ATSoft - 2022</span>
        </div>
        
        </div>
    </form>
</body>
</html>
