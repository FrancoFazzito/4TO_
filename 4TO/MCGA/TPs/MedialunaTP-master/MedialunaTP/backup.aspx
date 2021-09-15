<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="backup.aspx.cs" Inherits="MedialunaTP.backup" %>

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
            <asp:Label runat="server" ID="lblPermiso" Text="Perfil: Webmaster" Font-Bold="True" Font-Size="Medium" CssClass="aCenter"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" ID="Label2" Text="Copia de Seguridad y Restauración" Font-Bold="True" Font-Size="Medium" CssClass="aCenter"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <table style="width: 40%;" class="center">
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Hacer Copia de seguridad"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="Ejecutar" OnClick="btnBack_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Restaurar Copia de seguridad"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnRestaurar" runat="server" Text="Ejecutar" OnClick="btnRestaurar_Click" />
                    </td>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblmensaje" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
