<%@ Page Title="Forside" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron text-white bg-dark">
        <h1>Velkommen til Pane D´oro Italiano</h1>
        <p class="lead">Vi har ægte Italienske specialiteter. Pizza, Pasta, Sandwich, Salami, Ost, Juice, Vin, Oliven, Italiensk Is, Delikatesser, Nybagt italiensk brød hver dag, Menuer, m.m. Vi har Frokostpizzaer til kr. 50,-. Smag vores Røget Laks, med blandet salat og rucola (olivenolie & balsamico) kr. 52,-. Se vores fulde menukort, og ring og bestil Take Away, så er maden klar når du kommer. Vi tilbyder udbringning fra kr. 30,-.</p>
        <div>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary my-2 my-sm-0" Text="Se vores menu" OnClick="Button1_Click" />
        </div>
    </div>

    </asp:Content>
