<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="currentLocation.aspx.cs" Inherits="DoctorPage.currentLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <meta charset="utf-8" />
    <meta name="viewport" content="width-device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <script src="jquery.min.js"></script>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.3.1/dist/leaflet.css"
        integrity="sha512-Rksm5RenBEKSKFjgI3a41vrjkw4EVPlJ3+OiI65vTjIdo9brlAacEuKOiQ5OFh7cOI1bkDwLqdLw3Zg0cRJAAQ=="
        crossorigin="" />

    <!-- Make sure you put this AFTER Leaflet's CSS -->
    <script src="https://unpkg.com/leaflet@1.3.1/dist/leaflet.js"
        integrity="sha512-/Nsx9X4HebavoBvEBuyp3I7od5tA0UzAxs+j83KgC8PU0kgB4XiK4Lfe4y4cgBtaRJQEIFCW+oC506aPT2L1zw=="
        crossorigin=""></script>
    <style>
        #map { height: 650px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="map">
    <script>
        //
        //$(document).ready(function () {
        //    var map = L.map('map', {

        //        center: [10.1102278, 77.8958904],
        //        minZoom: 4,
        //        zoom: 6
        //    });
        //    $.ajax({
        //        type: "POST",
        //        url: '/Maps/GetMap',
        //        success: function (data) {
        //            var result = JSON.stringify(data);

        //            for (var i = 0; i < result.length; ++i) {
        //                var popup = '<b>Name:</b> ' + data[i].Name +
        //                '<br/><b>Latitude:</b> ' + data[i].Latitude +
        //                  '<br/><b>Longitude:</b> ' + data[i].Longitude +
        //               '<br/><b>Location:</b> ' + data[i].Location;


        //                L.marker([data[i].Latitude, data[i].Longitude])
        //                    .bindPopup(popup)
        //                   .addTo(map);
        //            }

        //        },
        //        error: function (xhr) {

        //            console.log(xhr.responseText);
        //            alert("Error has occurred..");
        //        }
        //    });

        //    L.tileLayer('http://{s}.mqcdn.com/tiles/1.0.0/map/{z}/{x}/{y}.png', {
        //        attribution: '© <a href="http://osm.org/copyright" title="OpenStreetMap" target="_blank">OpenStreetMap</a> contributors | Tiles Courtesy of <a href="http://www.mapquest.com/" title="MapQuest" target="_blank">MapQuest</a> <img src="http://developer.mapquest.com/content/osm/mq_logo.png" width="16" height="16">',
        //        subdomains: ['otile1', 'otile2', 'otile3', 'otile4']
        //    }).addTo(map);

        //});



        /////
        var map = L.map('map').setView([26.820553, 30.802498], 13);

        var layer = new L.StamenTileLayer('watercolor');
        map.addLayer(layer);

        var osmUrl = 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
        var mapTiles = new L.TileLayer(osmUrl, {
            attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>',
            maxZoom: 18
        });

        // add the CloudMade layer to the map set the view to a given center and zoom
        map.addLayer(mapTiles);

        // add location via browser geolocation
        function displayLocation(position) {
            console.log('position', position);
            var lat = position.coords.latitude;
            var lng = position.coords.longitude;
            L.marker([lat, lng]).addTo(map);
            console.log('{longitude:' + lng + ', latitude:' + lat + '}');
            map.setView([lat, lng], 16);
        }

        navigator.geolocation.getCurrentPosition(displayLocation);

        // get location via geoplugin.net
        jQuery(document).ready(function ($) {
            jQuery.getScript('http://www.geoplugin.net/javascript.gp', function () {
                var country = geoplugin_countryName();
                var zone = geoplugin_region();
                var district = geoplugin_city();
                console.log("Your location is: " + country + ", " + zone + ", " + district);
                var lat = geoplugin_latitude();
                var lng = geoplugin_longitude();
                L.marker([lat, lng]).addTo(map);
                console.log('{longitude:' + lng + ', latitude:' + lat + '}');

                map.setView([lat, lng], 13);
            });
        });
    </script>
    </div>
    </form>
</body>
</html>
