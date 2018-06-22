<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" style="margin-left: 179px" Width="277px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; المدينه
    
    </div>
        <p>
            &nbsp;<asp:TextBox ID="TextBox2" runat="server" style="margin-left: 179px" Width="277px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; zone</p>
        <asp:TextBox ID="TextBox3" runat="server" style="margin-left: 179px" Width="277px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; النوع&nbsp;&nbsp;
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 243px" Text="بحث" Width="157px" />
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Height="181px" Width="369px"></asp:Label>
        </p>
    <div>
    
    </div>
        <br />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
