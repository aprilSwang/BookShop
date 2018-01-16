<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Group1BookshopCA.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating">
</asp:GridView>
<%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BookshopConnectionString3 %>" SelectCommand="SELECT [BookID], [Title], [CategoryID], [ISBN], [Author], [Stock], [Price], [Discount] FROM [Book]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>--%>
</asp:Content>
