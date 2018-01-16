<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Group1BookshopCA.Books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Books</h2>
    <p><strong style="font-weight: bold">Keyword Search:</strong>
            <asp:TextBox ID="searchTextBox" runat="server" Width="587px" ToolTip="Please type out whole words"></asp:TextBox>
&nbsp;<strong><asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" style="font-weight: bold" />
        </strong>
        <em>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="searchTextBox" CssClass="text-danger" ErrorMessage="Search field is required" style="font-size: small; font-weight: normal;"></asp:RequiredFieldValidator>
        </em>
        </p>
        <p><strong style="font-weight: bold">Search Criteria:&nbsp; 
            </strong>
            <span style="font-weight: bold"> <asp:RadioButtonList ID="RadioButtonList1" runat="server" CellPadding="1" CellSpacing="1" RepeatDirection="Horizontal" RepeatLayout="Flow" style="font-weight: normal">
                <asp:ListItem Selected="True" Value="Title">Title</asp:ListItem>
                <asp:ListItem>Author</asp:ListItem>
                <asp:ListItem>ISBN</asp:ListItem>
            </asp:RadioButtonList>
            </span>
        </p>
    <p>
        <asp:Label ID="BookNumLabel" runat="server"></asp:Label>
        </p>
    <asp:Button ID="ViewAllButton" runat="server" CausesValidation="False" OnClick="ViewAllButton_Click" Text="View All" />
    <div class="labels">
<asp:Label ID="Label5" runat="server"></asp:Label>
<asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Images/Shopping-Cart-icon.png" ImageWidth="50px" ImageHeight="50px" NavigateUrl="~/ShoppingCart.aspx"></asp:HyperLink>
    <asp:Label ID="Label3" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand" >
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>

        <table border="0" style ="width:100%">
            <tr>
                <td rowspan="4" style="width:230px"><img src="/Images/<%# Eval("ISBN") %>.jpg" width="210" height="220" /></td>
                
                <td colspan="2" style="font-size:30px;color:black;text-decoration:underline;">
                <strong><asp:Label ID="Title" runat="server" Text='<%# Eval("Title") %>'/></strong>
            </td>

                <td rowspan ="4" class="price">
                    <asp:Label ID="Label1" runat="server" Text="Price"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="$"></asp:Label><asp:Label ID="Price" runat="server" Text='<%# Eval("Price") %>'/>
                    <br />
<asp:Button ID="Button1"  runat="server" Text="Add to cart" ForeColor="Black" Font-Size="12px" Font-Bold="True" CausesValidation ="False" CommandName="cart" /><br />
                </td>
            </tr>
            
            <tr>
                <td >
                       
                </td>
                <td>
                    <asp:Label ID="Author" runat="server" Text='<%# Eval("Author") %>'  /><br />
                
                ISBN: <asp:Label ID="ISBN" runat="server" Text='<%# Eval("ISBN") %>' /></td>
            </tr>

        </table>
            <p></p>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>

    </asp:Repeater>

</asp:Content>