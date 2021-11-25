<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="MrClean.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Productos:</h2>
    <br />
    <asp:Label ID="LblInfoCatalogo" runat="server"></asp:Label>
    <br />
    <div class="table-responsive">
        <asp:GridView ID="DgvProductos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center">
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
                <asp:BoundField DataField="Stock" HeaderText="Stock">
                <HeaderStyle Width="50px" />
                </asp:BoundField>
            </Columns>
            <HeaderStyle BackColor="#6BC5E2" ForeColor="White" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </div>
</asp:Content>
