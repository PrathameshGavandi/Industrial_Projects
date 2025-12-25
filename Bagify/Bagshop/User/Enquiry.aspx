<%@ Page Title="" Language="C#" MasterPageFile="~/User/Usermaster.Master" AutoEventWireup="true" CodeBehind="Enquiry.aspx.cs" Inherits="Bagshop.User.Enquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style9 {
            width: 452px;
            height: 32px;
            text-align: left;
        }
        .auto-style10 {
            width: 452px;
            text-align: left;
        }
        .auto-style12 {
            height: 22px;
            font-size: large;
            color: #FF0000;
            text-align: center;
        }
        .auto-style18 {
            text-decoration: none;
        }
        .auto-style19 {
            color: #000000;
        }
        .auto-style20 {
            font-size: x-large;
        }
    .auto-style21 {
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table " align="center" cellpadding="5" cellspacing="0" width="60%">
        <tr>
            <td class="auto-style12" colspan="2"><strong><br />
                <span class="auto-style19"><span class="auto-style20">Customer Care
                <br />
                </span>
                <br />
                We are at your service with a tailored customer care service. For any information you<br />
&nbsp;may need, questions or requests don&#39;t hesitate to write or call us!
                <br />
                Phone number:+90 0412030789
                <br />
                Email address: </span> <a href="mailto:customerservice@obag.eu" class="auto-style18"><span class="auto-style19">customerservice@bag.</span></a>com
                <br class="auto-style19" />
                <span class="auto-style19">We are at your service every day from Monday to Friday from 08:30 am to 8:00 pm
                <br />
                </span> </strong></td>
        </tr>
        <tr>
            <td class="auto-style9">Name<br />
                <asp:TextBox ID="txtname" runat="server" Height="30px" ViewStateMode="Enabled" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname" ErrorMessage="Please enter your name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style9">Email<br />
                <asp:TextBox ID="txtemail" runat="server" Height="30px" ViewStateMode="Enabled" Width="400px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="Enter valid mail id " ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Contact No<br />
                <asp:TextBox ID="txtcontact" runat="server" Height="30px" Width="400px" TextMode="Phone"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtcontact" ErrorMessage="Enter valid number" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
            </td>
            <td class="auto-style9">Subject<br />
                    <asp:TextBox ID="txtsubject" runat="server" Height="30px" Width="400px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Address<br />
                <asp:TextBox ID="txtaddress" runat="server" Height="60px" ViewStateMode="Enabled" Width="400px"  TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="auto-style9">Enquiry Message<br />
                    <asp:TextBox ID="txtmessage" runat="server" TextMode="MultiLine" Width="400px" Height="70px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style21" colspan="2">
                <asp:Button ID="btnsubmit" runat="server" BackColor="black" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" ForeColor="White" Height="40px" Width="180px" Text="Submit" OnClick="btnsubmit_Click" />
            &nbsp;
            &nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server" BackColor="black" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" ForeColor="White" Height="40px" Width="180px" Text="Cancel" OnClick="btnsubmit_Click" />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
