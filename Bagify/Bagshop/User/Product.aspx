<%@ Page Title="" Language="C#" MasterPageFile="~/User/Usermaster.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Bagshop.User.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 100%;
        }
        .auto-style6 {
            text-align: center;
        }
        .auto-style8 {
            font-size: x-large;
        }
        .auto-style9 {
            background-color: #FF3300;
        }
        .auto-style10 {
            font-size: large;
        }
        .auto-style11 {
            color: #FF9900;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style5">
        <tr>
            <td valign="top">
                <span class="auto-style8">&nbsp;&nbsp;&nbsp;
                <br />
&nbsp;&nbsp; Select Category ---&gt;</span><asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" CellPadding="5">
                    <ItemTemplate>
                        <table align="center" cellpadding="3" class="auto-style5">
                            <tr>
                                <td class="auto-style6">
                                    <asp:Button ID="Button1" runat="server" BackColor="#FF3300" CommandArgument='<%# Eval("Catname") %>' ForeColor="White" Height="35px" OnClick="Button1_Click" Text='<%# Eval("Catname") %>' Width="250px" style="border-radius:10px;" BorderStyle="None" CssClass="auto-style9" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT [Catname] FROM [Catagery]"></asp:SqlDataSource>
            </td>
            <td>
                <br />
                <asp:DataList ID="DataList2" runat="server" CellPadding="5" CellSpacing="2" DataKeyField="Pid" DataSourceID="SqlDataSource2" RepeatColumns="3" RepeatDirection="Horizontal">
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
                                <td class="auto-style6">
                                    Rs.
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
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [Product] WHERE ([Pcatagery] = @Pcatagery2)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Pcatagery2" SessionField="Catname" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
