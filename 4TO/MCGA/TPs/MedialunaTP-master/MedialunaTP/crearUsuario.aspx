<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crearUsuario.aspx.cs" Inherits="MedialunaTP.crearUsuario" %>

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
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ControlToValidate = "txtPass" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{8,}$" runat="server" ErrorMessage="Minimo 8 caracteres" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Nombre</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Apellido</td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtApellido" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Correo</td>
                <td>
                    <asp:TextBox ID="txtCorreo" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Campo Requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Correo invalido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                    <asp:Button ID="Button1" runat="server" Text="Crear" Width="100px" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    
    </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" BorderStyle="None" Text="Crear usuarios por defecto del sistema" CausesValidation="False" OnClick="Button2_Click" />
    </form>
</body>
</html>

