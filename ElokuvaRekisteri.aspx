<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ElokuvaRekisteri.aspx.cs" Inherits="ElokuvaRekisteri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    

    <br />
    <asp:Label ID="Label3" runat="server" Text="Elokuvan Nimi:"> </asp:Label>     
    <asp:TextBox ID="txtElokuvanNimi" runat="server"></asp:TextBox>
    <br />
    
    <asp:Label ID="Label4" runat="server" Text="Ohjaaja:"> 
    </asp:Label><asp:TextBox ID="txtOhjaaja" runat="server"></asp:TextBox>
    <br />
    
    <asp:Label ID="Label5" runat="server" Text="Vuosi:"> </asp:Label>
    <asp:TextBox ID="txtVuosi" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="btnLaheta" runat="server" Text="Lisää elokuva!" OnClick="btnLaheta_Click" />
    <asp:Button ID="btnPoista" runat="server" Text="Poista Elokuva!" OnClick="btnPoista_Click" />

<asp:GridView ID="gv" runat="server" AutoGenerateColumns="true"></asp:GridView>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
</asp:Content>

