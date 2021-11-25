<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MrClean._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <link href="./Styles/EstiloContacto.css" rel="stylesheet" />
    </header>
    <div class="jumbotron jumbotron-fluid" style="background-image: url(./Imagenes/img-limpieza.png)">
        <h2>MrClean.</h2>
        <p class="lead"></p>
        
    </div>
    <div>
        <footer>
                <p>
                    &copy; <%: DateTime.Now.Year %> - Mr.Clean-
                    <br>
                     Fazzito, Perchet, Catala, Duclos.
                </p>
            </footer>
    </div>
</asp:Content>