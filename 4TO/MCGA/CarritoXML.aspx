<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarritoXML.aspx.cs" Inherits="MrClean.CarritoXML" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<asp:TextBox runat="server" ID="txtCantidad"></asp:TextBox>
	<asp:Button runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
</asp:Content>
