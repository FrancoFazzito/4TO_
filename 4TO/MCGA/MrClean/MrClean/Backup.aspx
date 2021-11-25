<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="MrClean.Backup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: auto; text-align: center;">
        <h2>Backup</h2>
        <br />
        <asp:Button ID="BtnBackup" runat="server" class="btn btn-success" Text="Resguardar" Width="260px" OnClick="BtnBackup_Click" Font-Size="25pt" Height="100px" />
        <br />
        <br />
        <asp:Label ID="lblInfoBackup" runat="server" BorderColor="Black" ForeColor="Black"></asp:Label>
        <br />
    </div>
</asp:Content>