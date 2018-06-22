<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="GradeProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div>
     
 </div>
      <div id="setmarker"></div>
    <br />
      <input type="text" id="lat" val=""/>
      <input type="text" id="lng" val=""/>
    <script>
        var map = L.map('setmarker').setView([31.040948, 31.37847], 13);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: 'Hakona Matatatatatatata',
            maxZoom: 18,
            id: 'mapbox.streets',
            accessToken: 'your.mapbox.access.token'
        }).addTo(map);

        marker = new L.marker([31.040948, 31.37847], {
            draggable: 'true'
        });
        // location select
        marker.on('dragend', function (event) {
            var marker = event.target;
            var position = marker.getLatLng();
            document.getElementById('lat').value = position.lat;
            document.getElementById('lng').value = position.lng;
            marker.bindPopup("<b> Lat : " + position.lat + " , Lng : " + position.lat + "</b>").openPopup();
        });
        map.addLayer(marker);
    </script>
</asp:Content>
