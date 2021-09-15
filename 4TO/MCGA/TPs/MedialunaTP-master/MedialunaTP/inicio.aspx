<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="MedialunaTP.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Medialunas SA</title>
    <link href="/estilos/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;" class="center">
            <tr>
                <td class="aLeft">
                    <asp:Image ID="logo1" runat="server"  ImageUrl="~/imagenes/logo.png" Height="30" ImageAlign="Middle" />
                    <asp:Image ID="logoTXT" runat="server"  ImageUrl="~/imagenes/logoTXT.png" ImageAlign="Middle" />
                </td>
                <td class="aRight">
                    <asp:Label runat="server" Text="Usuario: " ID="lblUsu"></asp:Label>
                    <asp:Label ID="lblUsuario" runat="server" Text="usuario"></asp:Label>
                    &nbsp;<asp:Button ID="btnLogin" runat="server" Text="Login" Width="100px" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear Usuarios" OnClick="btnCrearUsuario_Click" />
                    <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" Visible="False" Width="100px" OnClick="btnCerrar_Click" />
                </td>
            </tr>
        </table>
        
        <br />
        <asp:Label runat="server" ID="lblPermiso" text="Listado de Productos" Font-Bold="True" Font-Size="Medium" CssClass="aCenter"></asp:Label>
        <br />
        <asp:Table ID="tablaProductos" class="tablaProductos" runat="server"></asp:Table>
        </div>

    </form>
</body>
</html>