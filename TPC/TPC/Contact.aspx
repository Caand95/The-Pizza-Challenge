<%@ Page Title="Kontakt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TPC.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row">
            <div class="col-md-6" style="text-align: center; margin-top: 100px">
                <h3>Find os her.</h3>
                <address>
                    Sct Hansgade 26<br />
                    4100 Ringsted<br />
                    Telefon: 57 60 00 28
                </address>
            </div>
            <div class="col-md-6" style="text-align: center">
                <img src="Images/about-image.jpg" style="width: inherit" />
            </div>
        </div>
        <div class="row" style="margin-top: 40px">
            <div class="col-md-6" style="text-align: center">
                <iframe
                    width="605"
                    height="365"
                    frameborder="0" style="border: 0"
                    src="https://www.google.com/maps/embed/v1/place?key=AIzaSyAeQqMNq0zlcUdToRYeUQD7b7zVNNEGVUU&q=place_id:ChIJubXGt8-RUkYRXquBDJ7YJh0"
                    allowfullscreen></iframe>
            </div>
            <div class="col-md-6" style="text-align: center; margin-top: 60px">
                <h3>Åbningstider.</h3>
                <address>
                    Mandag 11:00 - 22:00<br />
                    Tirsdag 11:00 - 22:00<br />
                    Onsdag 11:00 - 22:00<br />
                    Torsdag 11:00 - 22:00<br />
                    Fredag 11:00 - 22:00<br />
                    Lørdag 12:00 - 21:30<br />
                    Søndag 12:00 - 21:30<br />
                </address>
            </div>
        </div>

</asp:Content>
