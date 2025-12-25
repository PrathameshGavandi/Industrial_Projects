<%@ Page Title="" Language="C#" MasterPageFile="~/User/Usermaster.Master" AutoEventWireup="true" CodeBehind="CustmarLogin1.aspx.cs" Inherits="Bagshop.User.CustmarLogin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

    
        .auto-style9 {
            width: 90%;
        }
       
   
        .auto-style11 {
            color: #666666;
            font-size: large;
        }
        .auto-style14 {
        color: #000000;
    }
    .auto-style13 {
        font-size: medium;
    }
        .auto-style15 {
            margin-left: 0px;
            text-align: center;
        }
        .auto-style16 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="7" class="auto-style9">
        <tr>
            <td>
                <br /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <table align="center" class="auto-style5" cellpadding="10" >
                    <tr>
                        <td class="auto-style15"><span class="auto-style11">Welcome! Sign In Here<br /></span><strong>
                            <br /><span ><span class="auto-style14">REGISTERED CUSTOMERS<br />If you have an account, sign in with your Username and Password.</span></span></strong></td>
                    </tr>
                    <tr>
                        <td class="auto-style15" >
                            <asp:TextBox ID="txtusername" runat="server" placeholder="UserName" Style="border-radius:10px;" Height="40px" Width="300px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtusername" ErrorMessage="Please enter username" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <asp:TextBox ID="txtpassword" placeholder="Password" runat="server" TextMode="Password" Style="border-radius:10px;" Height="40px" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15" Style="border-radius:10px;">&nbsp;<asp:Button ID="btnlogin" runat="server" BackColor="Black" Height="40px" Text="Login" Width="180px" OnClick="btnlogin_Click" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" ForeColor="White" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btncancel" runat="server" BackColor="Black" ForeColor="White" Height="40px" Text="Cancel" Width="180px" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" OnClick="btncancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;<br />
                            <br /></td>
                    </tr>
                </table>
            </td>
            <td valign="top" class="auto-style15"><strong><span class="auto-style12">
                <br />
                <br /><span class="auto-style14"><span class="auto-style16">NEW CUSTOMERS</span><br />
                <br />&nbsp;</span></span><span class="auto-style13"><span class="auto-style14">Creating an account has many benefits: check out
                <br />faster, keep more than one address, track orders<br />&nbsp;and more.</span><br />
                <br />
                <asp:Button ID="btnlogin0" runat="server" BackColor="Black" Height="40px" Text="Create An Account" Width="250px" OnClick="btnlogin_Click" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" ForeColor="White" PostBackUrl="~/User/Registration.aspx" />
                <br />
                <br />
                <br />
                <br />
                <br /></span></strong></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
