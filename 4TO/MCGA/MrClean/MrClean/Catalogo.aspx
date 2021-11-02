<%@ Page Title="Catalogo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="MrClean.Catalogo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Catalogo de productos:</h2>
    <br />
    <asp:Label ID="LblInfoCatalogo" runat="server"></asp:Label>
    <br />
    <div class="table-responsive">
        <asp:GridView ID="DgvProductos" runat="server" CssClass="table table-bordered" OnSelectedIndexChanged="DgvProductos_SelectedIndexChanged" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                <HeaderStyle Width="75px" />
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="RutaImagen" HeaderText="Imagen" ControlStyle-Width="125" ControlStyle-Height = "100">
                <ControlStyle Height="200px" Width="200px"></ControlStyle>
                    <HeaderStyle Width="125px" />
                </asp:ImageField>
                <asp:BoundField DataField="Precio" HeaderText="Precio">
                <HeaderStyle Width="50px" />
                </asp:BoundField>
                <asp:ButtonField ControlStyle-CssClass="btn btn-info" Text="Agregar al carrito" ButtonType="Button" CommandName="Select" HeaderText="Acciones" ShowHeader="true">
                <ControlStyle CssClass="btn btn-info" Width="250px" Height="100px" BorderStyle="Solid" Font-Size="Large"></ControlStyle>
                <HeaderStyle Width="100px" />
                <ItemStyle Width="150px" />
                </asp:ButtonField>
            </Columns>
            <HeaderStyle BackColor="#6BC5E2" ForeColor="White" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </div>
</asp:Content>