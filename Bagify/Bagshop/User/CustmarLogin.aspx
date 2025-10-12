<%@ Page Title="" Language="C#" MasterPageFile="~/User/Usermaster.Master" AutoEventWireup="true" CodeBehind="CustmarLogin.aspx.cs" Inherits="Bagshop.User.CustmorLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    
        .auto-style9 {
            width: 90%;
        }
       
   
        .auto-style10 {
            text-align: center;
        }
        .auto-style11 {
            color: #666666;
            font-size: large;
        }
        .auto-style12 {
            font-size: x-large;
        }
    .auto-style13 {
        font-size: medium;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="7" class="auto-style9">
        <tr>
            <td>
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><table align="center" class="auto-style5" cellpadding="10" >
        <tr>
            <td class="auto-style10"><span class="auto-style11">Welcome! Sign In Here<br />
                </span><strong><br />
                <span class="auto-style12">REGISTERED CUSTOMERS</span><br />
                &nbsp;If you have an account, sign in with your Username and Password.</strong></td>
        </tr>
        <tr>
            <td class="auto-style10" >
                <asp:TextBox ID="txtusername" runat="server" placeholder="UserName" Style="border-radius:10px;" Height="40px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">
                <asp:TextBox ID="txtpassword" placeholder="Password" runat="server" TextMode="Password" Style="border-radius:10px;" Height="40px" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10" Style="border-radius:10px;">&nbsp;<asp:Button ID="btnlogin" runat="server" BackColor="Black" Height="40px" Text="Login" Width="180px" OnClick="btnlogin_Click" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" ForeColor="White" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server" BackColor="Black" ForeColor="White" Height="40px" Text="Cancel" Width="180px" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                &nbsp;<br />
                <br />
            </td>
        </tr>
    </table>
            </td>
            <td valign="top" class="auto-style10"><strong><span class="auto-style12">
                <br />
                <br />
                NEW CUSTOMERS<br />
                <br />
&nbsp;</span><span class="auto-style13">Creating an account has many benefits: check out
                <br />
                faster, keep more than one address, track orders<br />
&nbsp;and more.<br />
                <br />
                <asp:Button ID="btnlogin0" runat="server" BackColor="Black" Height="40px" Text="Create An Account" Width="250px" OnClick="btnlogin_Click" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" ForeColor="White" PostBackUrl="~/User/Registration.aspx" />
                <br />
                <br />
                <br />
                <br />
                <br />
                </span></strong></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
