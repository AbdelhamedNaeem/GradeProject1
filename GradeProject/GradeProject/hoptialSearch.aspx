<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="hoptialSearch.aspx.cs" Inherits="GradeProject.hoptialSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    <h1>الاستشارات </h1> 

       <script type="text\javascript">
  var location = [];
</script>
<asp:Repeater runat="server" ID="rpeatmarkers">
<ItemTemplate>
  "title": '<%# Eval("hospital_name") %>',
            "lat": '<%# Eval("hospital_lat") %>',
            "lng": '<%# Eval("hospital_lng") %>',
            "description": '<%# Eval("hospital_address") %>'
<script type="text\javascript">
   location.push({'lat': '<%# Eval("hospital_lat") %>', 'long': '<%# Eval("hospital_lng") %>'});
</script>
 </ItemTemplate>

 <SeparatorTemplate>
     ,
 </SeparatorTemplate>
    </asp:Repeater>
   <%--    <asp:Repeater ID="rpeatmarkers" runat="server">
<ItemTemplate>
            {
            "title": '<%# Eval("hospital_name") %>',
            "lat": '<%# Eval("hospital_lat") %>',
            "lng": '<%# Eval("hospital_lng") %>',
            "description": '<%# Eval("hospital_address") %>'
        }
</ItemTemplate>
<SeparatorTemplate>
</SeparatorTemplate>
</asp:Repeater>--%>
       </div>
       <div id="map" style="height: 440px; border: 1px solid #AAA;">  
         <script
        src="http://cdn.leafletjs.com/leaflet-0.7/leaflet.js">
    </script>
    
    <script type="text/javascript">
        var array = [];
        var map = L.map('map').setView([31.040948, 31.37847], 13);
            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: 'Hakona Matatatatatatata',
            maxZoom: 18,
            id: 'mapbox.streets',
            accessToken: 'your.mapbox.access.token'
        }).addTo(map);
            mapLink =
              '<a href="http://openstreetmap.org">OpenStreetMap</a>';

      //  var markers = [document.createElement("rpeatmarkers")];
           // for (var i = 0; i < location.length; i++) {
           //// var data = markers[i];

           //     var popup = '<b>Name:</b> ' + location[i].lat +
           //     '<br/><b>Address:</b> ' + location[i].long;
           //    // +
           //    //   '<br/><b>Phone:</b> ' + data[i].hospital_phone +
           //    //'<br/><b>WebSite:</b> ' + data[i].hospital_link +
           //    //      '<br/><b>Speclization:</b> ' + data[i].h_spec +
           //    //      '<br/><b>Type:</b> ' + data[i].hospital_kind;
           //     var m = L.marker([location[i].lat, location[i].long])
           //     .bindPopup(popup)
           //    .addTo(map);
           //     array.push(m);
           // }

           // markers.addLayers(array);
            for (var i = 0; i < location.length; i++) {
                var item = location[i];

                marker = new L.marker([item[2], item[3]], {
                  //  icon: mapOpts.myIcon
                }).bindPopup(item[1]);

                array.push(marker);
            }

            markers.addLayers(array);
            

</script>

     </div>
</asp:Content>
