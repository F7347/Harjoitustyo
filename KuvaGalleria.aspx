<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KuvaGalleria.aspx.cs" Inherits="KuvaGalleria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:FileUpload ID="FileUpload1" runat="server" />
    
    <asp:TextBox ID="txtNimi" runat="server" Text="Nimi"></asp:TextBox>
    
    <asp:Button ID="btnLisaaKuva" runat="server" Text="Lisää Kuva" OnClick="btnLisaaKuva_Click" />

    <asp:GridView ID="gvKuvat" runat="server" AutoGenerateColumns="true">

    </asp:GridView>
    <asp:Label ID="label1" runat="server" Text=""></asp:Label>
</asp:Content>



