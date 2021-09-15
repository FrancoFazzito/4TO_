<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alta_producto.aspx.cs" Inherits="MedialunaTP.alta_producto" %>

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
            <asp:Label runat="server" ID="Label2" Text="Perfil: Administrador" Font-Bold="True" Font-Size="Medium" CssClass="aCenter"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" ID="lblPermiso" Text="Carga de Productos" Font-Bold="True" Font-Size="Medium" CssClass="aCenter"></asp:Label>

            <br />
            <br />
            <table style="width: 620px;" class="center">
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Descripcion</td>
                    <td>
                        <asp:TextBox ID="txtDesc" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDesc" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Imagen</td>
                    <td>
                        <asp:TextBox ID="txtImg" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtImg" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td class="auto-style1">
                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="100px" CausesValidation="False" OnClick="btnCancelar_Click" />
                        &nbsp;
                    <asp:Button ID="btnEnviar" runat="server" Text="Aceptar" Width="100px" OnClick="btnEnviar_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
