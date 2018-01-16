<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Group1BookshopCA.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="GridView1_RowDataBound"  >
        <Columns>
            <asp:CommandField DeleteText="Remove" HeaderText="Remove Item" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label2" runat="server" CssClass="pricelabel"/><br />
 
    <asp:Button ID="Button1" runat="server" Text="Order" OnClick=Button1_Click />
        &nbsp;
    <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click1" />
</asp:Content>
