<%@ Page Title="" Language="C#" MasterPageFile="~/Custmar/Custmarmaster.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="Bagshop.Custmar.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

         .auto-style5 {
            width: 50%;
        }
        .auto-style6 {
            font-size: x-large;
            color: #000000;
            text-align: center;
            }
       
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table cellpadding="2" cellspacing="1" class="auto-style5" align="center">
        <tr>
            <td class="auto-style6" colspan="5"><strong>Feedback Form<hr />
                </strong></td>
        </tr>
        <tr>
            <td class="auto-style26">Name</td>
            <td colspan="4">
                <asp:TextBox ID="txtname" runat="server" Height="30px" Width="400px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="auto-style26">Email</td>
            <td colspan="4">
                <asp:TextBox ID="txtemail" runat="server" Height="30px"  Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style26">Contact No</td>
            <td colspan="4">
                <asp:TextBox ID="txtcontact" runat="server" Height="30px"  Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="5"><strong>How satisfied where you with:</strong></td>
        </tr>
        <tr>
            <td class="auto-style26"></td>
            <td>V.Satisfied</td>
            <td class="auto-style12">Satisfied</td>
            <td class="auto-style19">Unsatisfied</td>
            <td>V.Unsatisfied</td>
        </tr>
        <tr>
            <td class="auto-style14">Product Quality</td>
            <td class="auto-style15">
                <asp:RadioButton ID="rdqualityvsatisfied" runat="server" GroupName="pq" />
            </td>
            <td class="auto-style16">
                <asp:RadioButton ID="rdqualitysatisfied" runat="server" GroupName="pq" />
            </td>
            <td class="auto-style20">
                <asp:RadioButton ID="rdqualityunsatisfied" runat="server" GroupName="pq" />
            </td>
            <td class="auto-style18">
                <asp:RadioButton ID="rdqualityvunsatisfied" runat="server" GroupName="pq" />
            </td>
        </tr>
        <tr>
            <td class="auto-style14">Product Price</td>
            <td class="auto-style15">
                <asp:RadioButton ID="rdpricevsatisfied" runat="server" EnableTheming="True" GroupName="pp" />
            </td>
            <td class="auto-style16">
                <asp:RadioButton ID="rdpricesatisfied" runat="server" GroupName="pp" />
            </td>
            <td class="auto-style20">
                <asp:RadioButton ID="rdpriceunsatisfied" runat="server" GroupName="pp" />
            </td>
            <td class="auto-style18">
                <asp:RadioButton ID="rdpricevunsatisfied" runat="server" GroupName="pp" />
            </td>
        </tr>
        <tr>
            <td class="auto-style26">Order Process</td>
            <td class="auto-style11">
                <asp:RadioButton ID="rdprocessvsatisfied" runat="server" GroupName="op" />
            </td>
            <td class="auto-style12">
                <asp:RadioButton ID="rdprocesssatisfied" runat="server" GroupName="op" />
            </td>
            <td class="auto-style19">
                <asp:RadioButton ID="rdprocessunsatisfied" runat="server" GroupName="op" />
            </td>
            <td>
                <asp:RadioButton ID="rdprocessvunsatisfied" runat="server" GroupName="op" />
            </td>
        </tr>
        <tr>
            <td class="auto-style26">Delivery Service</td>
            <td>
                <asp:RadioButton ID="rddeliveryvsatisfied" runat="server" GroupName="ds" />
            </td>
            <td class="auto-style12">
                <asp:RadioButton ID="rddeliverysatisfied" runat="server" GroupName="ds" />
            </td>
            <td class="auto-style19">
                <asp:RadioButton ID="rddeliveryunsatisfied" runat="server" GroupName="ds" />
            </td>
            <td>
                <asp:RadioButton ID="rddeliveryvunsatisfied" runat="server" GroupName="ds" />
            </td>
        </tr>
        <tr>
            <td class="auto-style26">Date</td>
            <td class="auto-style11" colspan="3">
                &nbsp;<asp:TextBox ID="txtdate" runat="server" Height="30px" TextMode="Date" Width="400px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style26">Feel free to add any other comments of suggestions:</td>
            <td colspan="4">
                <asp:TextBox ID="txtsuggestion" runat="server" Height="62px" TextMode="MultiLine" Width="400px" CssClass="auto-style25"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style22"></td>
            <td class="auto-style23" colspan="4"></td>
        </tr>
        <tr>
            <td class="auto-style26" colspan="5">&nbsp;<asp:Button ID="btnreset" runat="server" BackColor="black" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" ForeColor="White" Height="40px" Width="180px" Text="Reset"  OnClick="btnreset_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnsubmit" runat="server" BackColor="black" BorderStyle="None" Font-Bold="True" style="border-radius:10px;" ForeColor="White" Height="40px" Width="180px" Text="Submit"  OnClick="btnsubmit_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style26">&nbsp;</td>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
