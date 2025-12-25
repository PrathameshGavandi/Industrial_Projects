<%@ Page Title="" Language="C#" MasterPageFile="~/User/Usermaster.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Bagshop.User.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style5 {
            width: 100%;
        }
        .auto-style6 {
            text-align: center;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>
            <table align="center" cellpadding="3" class="auto-style5" style="border: thin solid #C0C0C0">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Pname") %>' CssClass="auto-style10" Width="350px"></asp:Label>
                    </td>
                    <td rowspan="4"></td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' Height="200px" Width="250px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Rs.
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Price") %>' CssClass="auto-style11"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Button ID="Button2" runat="server" CommandArgument='<%# Eval("Pid") %>' Text="View More" BackColor="Black" BorderStyle="None" Font-Bold="True" ForeColor="White" Height="30px" Width="250px" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Product] WHERE ([Pname] LIKE '%' + @Pname + '%')">
        <SelectParameters>
            <asp:SessionParameter Name="Pname" SessionField="search" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
