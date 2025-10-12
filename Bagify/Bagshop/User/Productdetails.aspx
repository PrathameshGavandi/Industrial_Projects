<%@ Page Title="" Language="C#" MasterPageFile="~/User/Usermaster.Master" AutoEventWireup="true" CodeBehind="Productdetails.aspx.cs" Inherits="Bagshop.User.Productdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 100%;
        }
        .auto-style9 {
            height: 35px;
        }
        .auto-style10 {
            height: 40px;
            width: 95px;
        }
        .auto-style11 {
            color: #FF0000;
        }
        .auto-style12 {
            width: 95px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="auto-style8">
        <tr>
            <td>
                <asp:DataList ID="DataList1" runat="server" DataKeyField="Pid" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" >
                    <ItemTemplate>
                        <table align="center" cellpadding="5" class="auto-style8">
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("Pname") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="4">
                                    <asp:Image ID="Image2" runat="server" Height="193px" ImageUrl='<%# Eval("Image") %>' Width="192px" />
                                </td>
                                <td class="auto-style12">Catagory:<br />
                                    <asp:Label ID="lblcat" runat="server" Text='<%# Eval("Pcatagery") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">Rs:<br />
                                    <asp:Label ID="lprice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">Available Stock:<br />
                                    <asp:Label ID="lblstock" runat="server" Text='<%# Eval("Stock") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10"></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    Per Item/ <span class="auto-style11">Price</span> :<asp:Label ID="lblprice" runat="server" ForeColor="Red" Text='<%# Eval("Price") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="lblspecification" runat="server" Text='<%# Eval("Pspecification") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style9" colspan="2">Quantity:
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem>Select Quantity</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    &nbsp;Total:
                                    <asp:Label ID="lbltot" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Button2" runat="server" BackColor="Black" ForeColor="White" Text="Add To Cart" OnClick="Button2_Click" />
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [Product] WHERE ([Pid] = @Pid)">
                    <SelectParameters>
                        <asp:SessionParameter Name="Pid" SessionField="pid" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
