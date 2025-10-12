<%@ Page Title="" Language="C#" MasterPageFile="~/Custmar/Custmarmaster.Master" AutoEventWireup="true" CodeBehind="Cartdetails1.aspx.cs" Inherits="Bagshop.Custmar.Cartdetails11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style13 {
            width: 1499px;
            height: 33px;
        }
        .auto-style10 {
            height: 33px;
        }
        .auto-style11 {
            width: 1499px;
        }
        .auto-style9 {
            width: 80%;
        }
        .auto-style12 {
            text-align: right;
        }
        .auto-style14 {
            height: 36px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="4" class="auto-style1">
        <tr>
            <td class="auto-style13">Cart Details</td>
            <td class="auto-style10"></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="Pid" HeaderText="Pid" SortExpression="Pid"></asp:BoundField>
                        <asp:BoundField DataField="Catagery" HeaderText="Catagery" SortExpression="Catagery"></asp:BoundField>
                        <asp:BoundField DataField="Pname" HeaderText="Pname" SortExpression="Pname"></asp:BoundField>
                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username"></asp:BoundField>
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"></asp:BoundField>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity"></asp:BoundField>
                        <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total"></asp:BoundField>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Cartdetails]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">
                <table align="center" cellpadding="4" class="auto-style9">
                    <tr>
                        <td class="auto-style10" colspan="2">Shipping Details</td>
                    </tr>
                    <tr>
                        <td class="auto-style14">Name</td>
                        <td class="auto-style14">
                            <asp:TextBox ID="txtname" runat="server" Height="20px" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Address</td>
                        <td>
                            <asp:TextBox ID="txtaddress" runat="server" Height="51px" TextMode="MultiLine" Width="245px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>City</td>
                        <td>
                            <asp:TextBox ID="txtcity" runat="server" Height="20px" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Pin</td>
                        <td>
                            <asp:TextBox ID="txtpin" runat="server" Height="20px" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Contact No</td>
                        <td>
                            <asp:TextBox ID="txtcontactno" runat="server" Height="20px" TextMode="Number" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="auto-style12">
                            <asp:Button ID="btnorder" runat="server" Text="Confirm Order" BackColor="Black" ForeColor="White" Height="30px" Width="200px" OnClick="btnorder_Click" />
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
                <table align="center" cellpadding="4" class="auto-style9">
                    <tr>
                        <td colspan="2">Order Details</td>
                    </tr>
                    <tr>
                        <td>Order Id</td>
                        <td>
                            <asp:Label ID="lblid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Custmar Name</td>
                        <td>
                            <asp:Label ID="lblname" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Order Date</td>
                        <td>
                            <asp:Label ID="lbldate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Total Amount</td>
                        <td>
                            <asp:Label ID="lblamount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Order Time</td>
                        <td>
                            <asp:Label ID="lbltime" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
