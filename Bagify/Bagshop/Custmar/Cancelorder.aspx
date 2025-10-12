<%@ Page Title="" Language="C#" MasterPageFile="~/Custmar/Custmarmaster.Master" AutoEventWireup="true" CodeBehind="Cancelorder.aspx.cs" Inherits="Bagshop.Custmar.Cancelorder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Oid" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="Oid" HeaderText="Oid" ReadOnly="True" SortExpression="Oid" />
            <asp:BoundField DataField="Deliveryaddress" HeaderText="Deliveryaddress" SortExpression="Deliveryaddress" />
            <asp:BoundField DataField="Ocontact" HeaderText="Ocontact" SortExpression="Ocontact" />
            <asp:BoundField DataField="Odate" HeaderText="Odate" SortExpression="Odate" />
            <asp:BoundField DataField="Totalamount" HeaderText="Totalamount" SortExpression="Totalamount" />
            <asp:BoundField DataField="Orderstatus" HeaderText="Orderstatus" SortExpression="Orderstatus" />
            <asp:BoundField DataField="Custname" HeaderText="Custname" SortExpression="Custname" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT * FROM [Order]"
        DeleteCommand="delete from [Order] where [Oid]=@Oid">
        <DeleteParameters>
            <asp:Parameter Name="Oid" />
        </DeleteParameters>
    </asp:SqlDataSource>
</asp:Content>
