<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MrClean.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: auto; text-align: center;">
        <h2>Bienvenido</h2>
        <br />
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server" Width="200px" TextMode="Email"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Clave:"></asp:Label>
            <asp:TextBox ID="TxtClave" runat="server" Width="198px" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="BtnIngresar" runat="server" class="btn btn-success" Text="Ingresar" Width="199px" OnClick="BtnIngresar_Click" />
        <br />
        <asp:Button ID="BtnRegistrarse" runat="server" class="btn btn-info" Text="Registrarse" Width="199px" OnClick="BtnRegistrarse_Click" />
        <br />
        <asp:Button ID="BtnCerrarSesion" runat="server" class="btn btn-danger" Text="Cerrar sesion" Width="199px" OnClick="BtnCerrarSesion_Click" />
        <br />
        <br />
        <asp:Label ID="lblInfoLogin" runat="server" BorderColor="Black" ForeColor="Black"></asp:Label>
        <br />
    </div>
</asp:Content>