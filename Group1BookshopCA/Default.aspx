<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Group1BookshopCA._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>WELCOME TO THE G1 BOOKSHOP</h1>
        <p class="lead">We have the largest collection of Children, Finance, Non-fiction and Technical books around!</p>
        <p class="lead">Prices from as low as <span style="text-decoration: underline"><strong>$7.99</strong></span>! Unbelievable!</p>
        <p class="lead">
            <asp:Image ID="Image1" runat="server" BorderStyle="Solid" ImageAlign="Middle" ImageUrl="~/icon/image.gif" />
        </p>
        <p class="lead">Stock flies off our digital shelves fast so don&#39;t hesitate and buy now!</p>
        <p class="lead"><span style="font-weight: bold; text-decoration: underline">BOOK SEARCH:</span></p>
        <p>
            <strong style="font-weight: bold">Keyword Search:</strong>
            <asp:TextBox ID="searchTextBox" runat="server" ToolTip="Please type out whole words" Width="587px"></asp:TextBox>
            &nbsp;<strong><asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" style="font-weight: bold" Text="Search" />
            <em>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="searchTextBox" CssClass="text-danger" ErrorMessage="Search field is required" style="font-size: small"></asp:RequiredFieldValidator>
            </em>
            </strong>
        </p>
        <p>
            <strong style="font-weight: bold">Search Criteria:&nbsp;
            </strong>
            <span style="font-weight: bold">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" CellPadding="1" CellSpacing="4" RepeatDirection="Horizontal" RepeatLayout="Flow" EnableTheming="True" style="font-weight: normal">
                <asp:ListItem Selected="True" Value="Title">Title</asp:ListItem>
                <asp:ListItem>Author</asp:ListItem>
                <asp:ListItem>ISBN</asp:ListItem>
            </asp:RadioButtonList>
        </p>
            </span>
        <p>
            &nbsp;</p>
        <p>Or click here to browse from our entire range of books:
            <strong>
            <asp:Button ID="AllButton" runat="server" Text="Browse Catalog" OnClick="AllButton_Click" CausesValidation="False" style="font-weight: bold" />
            </strong>
        </p>
    </div>

    </asp:Content>
