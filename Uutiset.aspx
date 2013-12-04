<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Uutiset.aspx.cs" Inherits="Uutiset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Uutisia!</h1>



<asp:DataList ID="DataList1" runat="server" DataSourceID="XmlDataSource1">
    
    <ItemTemplate>
        Title: <a href="<%# XPath("link") %>"><%# XPath("title") %></a><br />
        Pulish Date: <%# XPath("pubDate") %><br />
        Description: <%# XPath("description") %>
        <hr />
    </ItemTemplate>

</asp:DataList>

       
<asp:XmlDataSource ID="XmlDataSource1" Runat="server"
        DataFile="http://www.iltalehti.fi/rss/rss.xml"
        XPath="rss/channel/item">
</asp:XmlDataSource>



</asp:Content>

