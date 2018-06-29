<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SearchClinic.aspx.cs" Inherits="GradeProject.SearchClinic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>ابحث عن العيادات </h1>
     <div>
            <p>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                المدينة</p>
            <p>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                المنطقة</p>
            <p>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                التخصص</p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="search" />
            </p>

            <table border="1" style="border-collapse: collapse">
                <tr>
                    <td>الاسم</td>
                    <td>
                        <input id="txtName" type="text" /></td>
                </tr>
                <tr>
                    <td>العنوان</td>
                    <td>
                        <input id="txtAdrress" type="text" /></td>
                </tr>
                <tr>
                    <td>الموقع</td>
                    <td>
                        <input id="txtlink" type="text" /></td>
                </tr>
            </table>


        </div>
</asp:Content>
