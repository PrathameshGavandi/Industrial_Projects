<%@ Page Title="" Language="C#" MasterPageFile="~/Custmar/Custmarmaster.Master" AutoEventWireup="true" CodeBehind="ManageProfile.aspx.cs" Inherits="Bagshop.Custmar.ManageProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style9 {
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table align="center" cellpadding="5" class="auto-style9">
        <tr>
            <td>Manage Profile<hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource1" Height="50px"  Width="382px">
                    <Fields>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="contactno" HeaderText="contactno" SortExpression="contactno" />
                        <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                        <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                        <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
                        <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                        <asp:BoundField DataField="username" HeaderText="username" SortExpression="username" />
                        <asp:CommandField ShowEditButton="True" />
                    </Fields>
                </asp:DetailsView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [Registration] WHERE ([username] = @username)" 
                    UpdateCommand ="update Registration set [contactno]=@contactno, [email]=@email, [address]=@address,[city]=@city, [password]=@password where [username]=@username "
                    >
                    <SelectParameters>
                        <asp:SessionParameter Name="username" SessionField="user" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
