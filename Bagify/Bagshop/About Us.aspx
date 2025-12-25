<%@ Page Title="" Language="C#" MasterPageFile="~/User/Usermaster.Master" AutoEventWireup="true" CodeBehind="About Us.aspx.cs" Inherits="Bagshop.User.About_Us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 100%;
        }
        .auto-style9 {
            text-align: center;
        }
        .auto-style10 {
            text-align: center;
            text-decoration: underline;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="3" class="auto-style8">
        <tr>
            <td class="auto-style9" colspan="2">
                <asp:ImageButton ID="ImageButton5" runat="server" Height="200px" ImageUrl="~/Images/aboutus.jpg" Width="500px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style10" colspan="2">ABOUT US</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
