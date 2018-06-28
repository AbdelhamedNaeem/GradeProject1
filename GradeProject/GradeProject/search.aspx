<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css"
        href="//cdn.datatables.net/1.10.7/css/jquery.dataTables.min.css" />
    <script src="jquery-1.11.2.js"></script>
   <%-- <script>
        $(document).ready(function () {
            $('#Button1').click(function () {
                var h_city = $('#TextBox1').val();
                var h_zone = $('#TextBox2').val();
                var h_kind = $('#TextBox3').val();
                $.ajax({
                    url: 'search.aspx/Gethospitalbycity',
                    method: 'post',
                    contentType: 'application/json; charset=utf-8',
                    data: '{"h_city": h_city}' + '{"h_zone": h_zone}' + '{"h_kind": h_kind}',
                    //'{"h_city":h_city'} , 'h_zone' : h_zone + 'h_kind' + h_kind + '}',
                    dataType: "json",
                    success: function (data) {
                        $('#txtName').val(data.hospital_name);
                        $('#txtAdrress').val(data.hospital_address);
                        $('#txtlink').val(data.hospital_link);

                    },
                    error: function (err) {
                        alert(err);
                    }
                });
            });
        });

    </script>--%>
</head>
<body>
  <%--  <form id="form1" runat="server">
        <div>
            <p>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                المدينة</p>
            <p>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                المنطقة</p>
            <p>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                النوع</p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="search" />
            </p>

            <table border="1" style="border-collapse: collapse">
                <tr>
                    <td>Name</td>
                    <td>
                        <input id="txtName" type="text" /></td>
                </tr>
                <tr>
                    <td>Address</td>
                    <td>
                        <input id="txtAdrress" type="text" /></td>
                </tr>
                <tr>
                    <td>Link</td>
                    <td>
                        <input id="txtlink" type="text" /></td>
                </tr>
            </table>


        </div>
        
        <br />
    </form>--%>

    <div id="map" style="height: 440px; border: 1px solid #AAA;">  
         <script
        src="http://cdn.leafletjs.com/leaflet-0.7/leaflet.js">
    </script>
        <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>
        <asp:Repeater ID="rp" runat="server">
<ItemTemplate>
            {
            "title": '<%# Eval("Name") %>',
            "lat": '<%# Eval("Latitude") %>',
            "lng": '<%# Eval("Longitude") %>',
            "description": '<%# Eval("Description") %>'
        }
</ItemTemplate>
<SeparatorTemplate>
</SeparatorTemplate>
</asp:Repeater>
    <script type="text/javascript">
        var markers = [document.createElement("rp")];
        var map = L.map('map').setView([-41.3058, 174.82082], 8);
        mapLink =
            '<a href="http://openstreetmap.org">OpenStreetMap</a>';
        L.tileLayer(
            'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; ' + mapLink + ' Contributors',
                maxZoom: 18,
            }).addTo(map);

        for (var i = 0; i < markers.length; i++) {
            var popup = '<b>Name:</b> ' + data[i].hospital_name +
                '<br/><b>Address:</b> ' + data[i].hospital_address +
                  '<br/><b>Phone:</b> ' + data[i].hospital_phone +
               '<br/><b>WebSite:</b> ' + data[i].hospital_link +
                     '<br/><b>Speclization:</b> ' + data[i].h_spec +
                     '<br/><b>Type:</b> ' + data[i].hospital_kind;


            L.marker([data[i].hospital_lat, data[i].hospital_lng])
                .bindPopup(popup)
               .addTo(map);

            marker = new L.marker([markers[i][1], planes[i][2]])
				.bindPopup(planes[i][0])
				.addTo(map);
        }
</script>

     </div>







<%--<script type="text/javascript">

    $(document).ready(function () {
        var map = L.map('map', {

            center: [10.1102278, 77.8958904],
            minZoom: 4,
            zoom: 6
        });
        $.ajax({
            type: "POST",
            url: '/GethosResult.asmx.cs/getHospitals',
            success: function (data) {
                var result = JSON.stringify(data);

                for (var i = 0; i < result.length; ++i) {
                    var popup = '<b>Name:</b> ' + data[i].hospital_name +
                    '<br/><b>Address:</b> ' + data[i].hospital_address +
                      '<br/><b>Phone:</b> ' + data[i].hospital_phone +
                   '<br/><b>WebSite:</b> ' + data[i].hospital_link+
                         '<br/><b>Speclization:</b> ' + data[i].h_spec +
                         '<br/><b>Type:</b> ' + data[i].hospital_kind;


                    L.marker([data[i].hospital_lat, data[i].hospital_lng])
                        .bindPopup(popup)
                       .addTo(map);
                }
            },
            error: function (xhr) {
                console.log(xhr.responseText);
                alert("Error has occurred..");
            }
        });
        L.tileLayer('http://{s}.mqcdn.com/tiles/1.0.0/map/{z}/{x}/{y}.png', {
            attribution: '© <a href="http://osm.org/copyright" title="OpenStreetMap" target="_blank">OpenStreetMap</a> contributors | Tiles Courtesy of <a href="http://www.mapquest.com/" title="MapQuest" target="_blank">MapQuest</a> <img src="http://developer.mapquest.com/content/osm/mq_logo.png" width="16" height="16">',
            subdomains: ['otile1', 'otile2', 'otile3', 'otile4']
        }).addTo(map);
    });

</script> --%>
   
</body>
</html>
