<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MrClean.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <link href="./Styles/EstiloContacto.css" rel="stylesheet" />
    </header>
    <h2>MrClean.</h2>
    <h3>Contactanos.</h3>

    <address>
        <img src="Imagenes/img-world-1.png" style="width: 19px; height: 18px" />
        Av. Del Libertador 6040.<br />
        Belgrano, CABA<br />
        <img src="Imagenes/img-phone-1.png" style="width: 19px; height: 18px" /><abbr title="Telefono">Telefono:</abbr>
        11-5065-0604
    </address>

    <address>
        <strong>&#9993 Soporte:</strong>   <a href="mailto:info@mrclean.com">info@mrclean.com</a><br />
        <strong>&#10052 Marketing:</strong> <a href="mailto:infoMarketing@mrclean.com">infoMarketing@mrclean.com</a>
    </address>
</asp:Content>
