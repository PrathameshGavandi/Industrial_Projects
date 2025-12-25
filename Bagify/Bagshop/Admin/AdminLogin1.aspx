<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Bagshop.Admin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">



        .auto-style1 {
            width: 30%;
        }
        .auto-style2 {
            text-align: center;
        }
        </style>
    </head>
<body  style="background-image: url('../Images/adminbackground.jpg')">
    <form id="form1" runat="server">
        <br /><br /><br />
    <asp:Panel ID="Panel1" runat="server"   align="center">
        <br />
        <br />
        <br />
        <table align="center" cellpadding="10" cellspacing="0" class="auto-style1" style="background-color: #CCCCCC; border-radius:15px; border: thin solid #808080; font-family: Arial, Helvetica, sans-serif;" style="opacity:0.9">
            <tr>
                <td id="txtAdmin"  colspan="2" class="auto-style2" rowspan="1">
                    <asp:Image ID="Image1" runat="server" Height="151px" ImageUrl="~/Images/admin1.png" Width="173px" />
                </td>
            </tr>
            <tr>
                <td> Admin Name</td>
                <td >
                    <asp:TextBox ID="txtname" runat="server" Height="40px" placeholder="Enter admin name" Width="250px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td> Password</td>
                <td>
                    <asp:TextBox ID="txtpassword" runat="server" Height="40px" Textmode="Password" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td  colspan="2" class="auto-style2">
                    <asp:Button ID="btnlogin" runat="server" BackColor="Black" Height="40px" Text="Login" Width="180px" ForeColor="White"   />
                  <asp:Button ID="btncancel" runat="server" BackColor="Black" Height="40px" Text="Cancel" Width="180px" ForeColor="White" />
                </td>
            </tr>
        </table>
        <br />


    </asp:Panel>
    </form>
</body>
</html>
