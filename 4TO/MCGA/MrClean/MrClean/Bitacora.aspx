<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="MrClean.Bitacora" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Aqui estan registrados los eventos ocurridos</h2>
    <div class="table-responsive">
        <asp:GridView ID="DgvBitacora" runat="server" CssClass="table table-bordered">
            <HeaderStyle BackColor="#6BC5E2" ForeColor="White" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
        </asp:GridView>
    </div>
</asp:Content>