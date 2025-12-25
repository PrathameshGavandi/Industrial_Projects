<%@ Page Title="" Language="C#" MasterPageFile="~/Custmar/Custmarmaster.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="Bagshop.Custmar.Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style9 {
        width: 80%;
    }
    .auto-style10 {
        font-size: x-large;
        width: 808px;
    }
    .auto-style11 {
        width: 808px;
    }
        .auto-style12 {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="4" class="auto-style9">
    <tr>
        <td class="auto-style10" colspan="2">Payment Details</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">Payment Id</td>
        <td>
            <asp:Label ID="lblpayid" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">Order Id</td>
        <td>
            <asp:Label ID="lbloid" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">Payment Date</td>
        <td>
            <asp:Label ID="lblpdate" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">Custmar Name</td>
        <td>
            <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">GST</td>
        <td>
            <asp:Label ID="lblgst" runat="server">9</asp:Label>
            %</td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">Discount</td>
        <td>
            <asp:Label ID="lbldis" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">Total Amount</td>
        <td>
            <asp:Label ID="lbltamount" runat="server" ForeColor="Red" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">Net Amount</td>
        <td>
            <asp:Label ID="lblnamount" runat="server" ForeColor="Red" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="3">Payment Method&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rd1" runat="server" Text="COD(Cash On Delivery)" OnCheckedChanged="rd1_CheckedChanged" />
&nbsp;&nbsp;
            <asp:RadioButton ID="rd2" runat="server" Text="UPI" OnCheckedChanged="rd2_CheckedChanged" />
        </td>
    </tr>
    <tr>
        <td class="auto-style12">
            <asp:Image ID="Image2" runat="server" Height="144px" Width="198px" />
        </td>
        <td class="auto-style11">
            <br />
            <br />
            <br />
            <asp:Button ID="btnorder" runat="server" BackColor="Black" ForeColor="White" Height="40px" OnClick="btnorder_Click" Text="Place Order" Width="180px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnbill" runat="server" BackColor="Black" ForeColor="White" Height="40px" OnClick="btnbill_Click" Text="Print Bill" Width="180px" Enabled="False" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style11" colspan="2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
