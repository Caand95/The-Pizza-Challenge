<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="TPC.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row" style="margin-left: auto; margin-right: auto; width: 30%">
            <asp:TextBox ID="MenuSearchTextBox" CssClass="form-control mr-sm-2" placeholder="Søg efter ingredienser.." runat="server" />
            <asp:Button ID="SearchButton" CssClass="btn btn-secondary my-2 my-sm-0" Text="Søg" runat="server" OnClick="SearchButton_Click" />
        </div>

    <asp:MultiView ID="MenuMultiView" runat="server">
        <asp:View ID="MenuView" runat="server">

            <!-- Displays the menu on page load -->
            <asp:TextBox ID="TextBox1" runat="server" Height="400px" Width="300px" TextMode="MultiLine"></asp:TextBox>

        </asp:View>

        <asp:View ID="SearchView" runat="server">

            <!-- Displays the search result -->
            <asp:TextBox ID="TextBox3" runat="server" Height="40px" Width="300px" TextMode="MultiLine"></asp:TextBox>

        </asp:View>
    </asp:MultiView>

</asp:Content>
