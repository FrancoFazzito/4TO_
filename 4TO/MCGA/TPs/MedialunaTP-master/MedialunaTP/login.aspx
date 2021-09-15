<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MedialunaTP.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>>Medialunas SA</title>
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
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width:620px;" class="center">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Usuario</td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Contraseña</td>
                <td>
                    <asp:TextBox ID="txtPAss" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPAss" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
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
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" Width="100px" OnClick="btnEnviar_Click" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar Contraseña" BorderStyle="None" CausesValidation="False" OnClick="btnRecuperar_Click" />
                    </td>
                <td>
                    <asp:Label ID="lblNueva" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

