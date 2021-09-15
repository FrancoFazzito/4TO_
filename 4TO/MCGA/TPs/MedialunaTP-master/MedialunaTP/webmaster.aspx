<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webmaster.aspx.cs" Inherits="MedialunaTP.webmaster" %>

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
            <br />
            <br />
            <br />
            <table style="width: 40%;" class="center">
                 <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Ver bitacora"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnBitacora" runat="server" Text="Ejecutar" OnClick="btnBitacora_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Copia de seguridad y Restauración"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="Ejecutar" OnClick="btnBack_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Verificar integridad Horizontal"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnVerificarH" runat="server" Text="Ejecutar" OnClick="btnVerificarH_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Recalcular Digitos Horizontales"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnRecalcularH" runat="server" Text="Ejecutar" OnClick="btnRecalcularH_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Verificar integridad Vertical"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnVerificarV" runat="server" Text="Ejecutar" OnClick="btnVerificarV_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Recalcular Digitos Verticales"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnRecalcularV" runat="server" Text="Ejecutar" OnClick="btnRecalcularV_Click" />
                    </td>
                </tr>
            </table>

            <br />
            <br />

            <table style="width: 900px;" class="center">
                <tr>
                    <td>
                        <asp:TextBox ID="txtResultado" runat="server" ReadOnly="True" TextMode="MultiLine" Width="900px" Height="200px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

