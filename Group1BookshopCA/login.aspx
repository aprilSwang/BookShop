<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Group1BookshopCA.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Login ID="Login1" runat="server"></asp:Login>
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/signup.aspx">No account? Register here.</asp:HyperLink>
</asp:Content>
