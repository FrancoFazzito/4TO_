<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="administrador.aspx.cs" Inherits="MedialunaTP.administrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Medialunas SA</title>
    <link href="/estilos/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;" class="center">
                <tr>
                    <td class="aLeft">
                        <asp:Image ID="logo1" runat="server" ImageUrl="~/imagenes/logo.png" Height="30" ImageAlign="Middle" />
                        <asp:Image ID="logoTXT" runat="server" ImageUrl="~/imagenes/logoTXT.png" ImageAlign="Middle" />
                    </td>
                    <td class="aRight">
                        <asp:Label runat="server" Text="Usuario: " ID="Label1"></asp:Label>
                        <asp:Label ID="lblUsuario" runat="server" Text="usuario"></asp:Label>
                        &nbsp;
                    <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" Width="100px" OnClick="btnCerrar_Click" />
                    </td>
                </tr>
            </table>

            <br />
            <asp:Label runat="server" ID="lblPermiso" Text="Perfil: Administrador" Font-Bold="True" Font-Size="Medium" CssClass="aCenter"></asp:Label>

            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Alta de Productos" OnClick="Button1_Click" />

        </div>
    </form>
</body>
</html>
