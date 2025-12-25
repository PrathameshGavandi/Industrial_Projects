<%@ Page Title="" Language="C#" MasterPageFile="~/User/Usermaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Bagshop.User.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
          
         
        }
        .auto-style12 {
           
        }
        .auto-style15 {
            font-size: large;
            color: #FF0000;
            text-align: center;
        }
        .auto-style16 {
            color: #000000;
        }
        .auto-style17 {
            font-size: x-large;
        }
        .auto-style18 {
            height: 74px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="70%" cellpadding="2" align="center">
        <tr>
            <td class="auto-style15" colspan="2"><strong><br />
                <span class="auto-style16"><span class="auto-style17">NEW CUSTOMERS 
                <br />
                </span>
                <br />
                Creating an account has many benefits: check out
                <br />
                faster, keep more than one address, track orders and more.</span></strong></td>
        </tr>
        <tr>
            <td class="auto-style18">Name<br />
                <asp:TextBox ID="txtname" runat="server" Height="35px" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="Please enter your name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style18">Contact No<br />
                <asp:TextBox ID="txtcontact" runat="server" Height="35px" Width="400px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtcontact" ErrorMessage="Enter valid number" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">Email<br />
                <asp:TextBox ID="txtemail" runat="server" Height="35px" TextMode="Email" Width="400px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Enter valid mail id" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style12">City<br />
                <asp:DropDownList ID="drpcity" runat="server" Height="35px" Width="400px">
                    <asp:ListItem>Sangli</asp:ListItem>
                    <asp:ListItem>Kolhapur</asp:ListItem>
                    <asp:ListItem>Satara</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">Address<br />
                <asp:TextBox ID="txtaddress" runat="server" Height="50px" TextMode="MultiLine" Width="400px"></asp:TextBox>
            </td>
            <td class="auto-style12">Username<br />
                <asp:TextBox ID="txtusername" runat="server" Height="35px" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtusername" ErrorMessage="Enter valid username" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Password<br />
                <asp:TextBox ID="txtpassword" runat="server" Height="35px" Width="400px"></asp:TextBox>
                <br />
            </td>
            <td class="auto-style10">Confirm Password<br />
                <asp:TextBox ID="txtconfirmpassword" runat="server" Height="35px" Width="400px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpassword" ControlToValidate="txtconfirmpassword" ErrorMessage="Invalid password" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;<br />
                <asp:Button ID="btncreareaccount" runat="server" BackColor="Black" Height="40px" Text="Create Account" Width="180px" OnClick="btncreareaccount_Click" BorderStyle="None" Font-Bold="True" ForeColor="White" style="border-radius:10px;" />
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Button ID="btnreset" runat="server" BackColor="Black" Height="40px" Text="Reset" Width="180px" style="border-radius:10px;" OnClick="btnreset_Click" BorderStyle="None" Font-Bold="True" ForeColor="White" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
