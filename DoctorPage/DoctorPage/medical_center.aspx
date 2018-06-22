<%@ Page Title="" Language="C#" MasterPageFile="~/profile.Master" AutoEventWireup="true" CodeBehind="medical_center.aspx.cs" Inherits="DoctorPage.medical_center" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="fclinic">

        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text="اسم مكتب الصحة"></asp:Label>
        <br />
        <asp:DropDownList ID="cityname" runat="server" DataTextField="city_name"
            DataValueField="city_id" AutoPostBack="True"
            OnSelectedIndexChanged="cityname_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="Label6" runat="server" Text="المدينة"></asp:Label>

        <br />
        <asp:DropDownList ID="zonename" runat="server" DataTextField="zone_name"
            DataValueField="zone_id">
        </asp:DropDownList>
        <asp:Label ID="Label8" runat="server" Text="المنطقة"></asp:Label>

        <br />
        <asp:TextBox ID="addresstxt" runat="server"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" Text="العنوان التفصيلي"></asp:Label>
        <br />
        <asp:TextBox ID="link" runat="server"></asp:TextBox>
        <asp:Label ID="Label11" runat="server" Text="اللينك"></asp:Label>
        <br />
        <asp:TextBox ID="phone" runat="server"></asp:TextBox>
        <asp:Label ID="Label12" runat="server" Text="التليفون"></asp:Label>
        <br />
        <h5>حدد موقعك علي الخريطة</h5>

        <div id="setmarker"></div>
        <input type="text" id="latclinic" value="" name="clat" />
        <input type="text" id="lngclinic" value="" name="clng" />
        <asp:Button ID="Button1" runat="server" Text="تأكيد الموقع" OnClick="Button1_Click" />

        <asp:Label ID="Label1" runat="server" BorderWidth="3px"></asp:Label>
        <asp:Label ID="Label2" runat="server" BorderWidth="3px"></asp:Label>

        &nbsp;<script>
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
                      document.getElementById('latclinic').value = position.lat;
                      document.getElementById('lngclinic').value = position.lng;
                      marker.bindPopup("<b> Lat : " + position.lat + " , Lng: " + position.lat + "</b>").openPopup();
                  });
                  map.addLayer(marker);

        </script>
        <asp:Button ID="btn_delete" runat="server" Text="مسح الحساب" Width="195px" />
        <asp:Button ID="btn_update" runat="server" Text="تعديل البيانات" Width="195px" />
        <asp:Button ID="btn_insert" runat="server" Text="ادخال البيانات" Width="195px" OnClick="btn_insert_Click" />

    </div>
</asp:Content>
