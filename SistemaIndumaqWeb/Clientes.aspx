<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="SistemaIndumaqWeb.Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Clientes</title>
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
                <li><a class="seleccion" href="Clientes.aspx">Clientes</a></li>
                <li><a href="Ventas.aspx">Ventas</a></li>

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
                            <asp:LinkButton ID="lbtnEditar" CssClass="linkboton" runat="server" OnClick="lbtnEditar_Click1">Editar</asp:LinkButton>
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
            <h1 id="titParrafo" class="tituloParrafo" runat="server">Agregar nuevo cliente</h1>
            <div class="divisiones">
                <asp:Label ID="lblNombre" CssClass="lblBox" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="txtBox" runat="server"></asp:TextBox>
            </div>
            
            <div class="divisiones">
                <asp:Label ID="lblDireccion" CssClass="lblBox" runat="server" Text="Direccion:"></asp:Label>
                <asp:TextBox ID="txtDireccion" CssClass="txtBox" runat="server"></asp:TextBox>
            </div>
            
            <div class="divisiones">
                <asp:Label ID="lblMail" CssClass="lblBox" runat="server" Text="Mail:"></asp:Label>
                <asp:TextBox ID="txtMail" CssClass="txtBox" runat="server"></asp:TextBox>
            </div>
            
            <div class="divisiones">
                <asp:Label ID="lblTelefono" CssClass="lblBox" runat="server" Text="Telefono:"></asp:Label>
                <asp:TextBox ID="txtTelefono" CssClass="txtBox" runat="server"></asp:TextBox>
            </div>

            <div class="divisiones">
                <asp:Button ID="btnAgregarProd" CssClass="boton" runat="server" Text="Agregar"  OnClick="btnAgregarProd_Click" />
                <asp:Button ID="btnLimpiar" CssClass="boton bcentro" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                <asp:Button ID="btnCancelar" CssClass="boton" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
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
