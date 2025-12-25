<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.Master" AutoEventWireup="true" CodeBehind="Processorder.aspx.cs" Inherits="Bagshop.Admin.Processorder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
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
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Order]"
            UpdateCommand="update[Order] set [Orderstatus]=@OrderStatus where [Oid]=@Oid"
        DeleteCommand="delete from [Order] where [Oid]=@Oid" >
        </asp:SqlDataSource>
    </div>
    </asp:Content>
