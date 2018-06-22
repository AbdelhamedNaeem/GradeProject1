<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="DoctorPage.map" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script type="text/javascript">
    function recordvalue(button)
{
var hiddentext=document.getElementById("Hidden1");
hiddentext.value=button.value;
button.style.borderColor="red";


form1.action="Default.aspx?value="+hiddentext.value
}
</script>
<body>
   <form id="form1" method="post" target="_self" >
<input id="Hidden1" type="hidden" />
<input id="Button1" type="button" value="1" onclick="recordvalue(this)" />
<input id="Button2" type="button" value="2" onclick="recordvalue(this)"/>
<input id="Button3" type="button" value="3" onclick="recordvalue(this)"/>
<input id="Submit1" type="submit" value="submit"  />
</form>


</body>
</html>
