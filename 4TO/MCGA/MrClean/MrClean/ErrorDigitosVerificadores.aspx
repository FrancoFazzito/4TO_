<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorDigitosVerificadores.aspx.cs" Inherits="MrClean.ErrorDigitosVerificadores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .table-bordered {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Text="Ups, hubo un error con los digitos verificadores"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Errores:"></asp:Label>
            <asp:GridView ID="DgvErrores" runat="server" Height="163px" Width="500px" HorizontalAlign="Center" CssClass="table table-bordered">
                <HeaderStyle BackColor="Red" />
                <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:GridView>
            <br />
            <asp:Button ID="BtnRestaurar" runat="server" class="btn btn-success" Height="57px" Text="Restaurar" Width="185px" Font-Size="15pt" ForeColor="Black" OnClick="BtnRestaurar_Click"  />
        </div>
    </form>
</body>
</html>