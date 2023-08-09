<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SistemaIndumaqWeb.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="styles/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
            <div class="centro">
                <h1 class="login"><asp:Label ID="lblLogin" runat="server" Text="LOGIN"></asp:Label></h1>
                <div class="formulario">
                    <div class="campo">
                        <asp:Label CssClass="texto" ID="lblUser" runat="server" Text="Usuario"></asp:Label>
                        <span></span>
                        <asp:TextBox CssClass="entrada" ID="txtUser" runat="server"></asp:TextBox>
                    </div>
                    <div class="campo">
                        <asp:Label CssClass="texto" ID="lblPass" runat="server" Text="Contraseña"></asp:Label>
                        <span></span>
                        <asp:TextBox CssClass="entrada" ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button CssClass="boton" ID="btnLogin" runat="server" Text="INGRESAR" OnClick="btnLogin_Click" />
                    </div>
                </div>
                <div class="errorCont">
                    <asp:Label class="error" ID="lblError" runat="server" Text=""></asp:Label>
                </div>
            </div>
        
    </form>
</body>
</html>
