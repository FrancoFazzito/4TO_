<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="MrClean.Carrito" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Estos son los productos que agregaste:</h2>
    <div class="table-responsive">
        <asp:GridView ID="DgvProductos" runat="server" CssClass="table table-bordered">
            <HeaderStyle BackColor="#6BC5E2" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
        Precio de la compra:
        <asp:Label ID="lblPrecio" runat="server"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="DropDownCodigosPostales" runat="server" CssClass="btn btn-primary dropdown-toggle" DataTextField="Codigo postal" Height="35px" Width="136px" BackColor="#6BC5E2">
            <asp:ListItem>B1650</asp:ListItem>
            <asp:ListItem>B5000</asp:ListItem>
            <asp:ListItem>C1004</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="BtnCalcularEnvio" runat="server" CssClass="btn btn-success" Height="35px" OnClick="BtnCalcularEnvio_Click" Text="Calcular Envio" Width="134px" />
        <br />
        Precio del envio:
        <asp:Label ID="lblPrecioEnvio" runat="server"></asp:Label>
        <br />
        Precio final con envio:
        <asp:Label ID="LblPrecioFinalConEnvio" runat="server"></asp:Label>
        <br />
        <asp:Label ID="LblInfoEnvio" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="BtnComprar" runat="server" CssClass="btn btn-success" Height="35px" Text="Comprar" Width="132px" OnClick="BtnComprar_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Su codigo de compra es:"></asp:Label>
        <asp:TextBox ID="TxtCodigo" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
        <br />
        <asp:Label ID="LblnfoCompra" runat="server"></asp:Label>
    </div>
</asp:Content>