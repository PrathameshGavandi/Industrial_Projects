<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="Bagshop.Admin.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {            font-size: x-large;
        }
        .auto-style5 {
         
        }
        .auto-style6 {
          
        }
        .auto-style7 {
         
        }
        .auto-style8 {
         
        }
        .auto-style10 {
          
        }
        .auto-style11 {
            font-size: medium;
        }
        .auto-style12 {
            width: 143px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1" align="center" width="80%">
        <tr>
            <td class="auto-style4" colspan="3"><strong>Manage Product<hr />
                </strong></td>
            <td rowspan="6">&nbsp;<asp:ImageButton ID="Image1" runat="server" Height="195px" Width="233px" />
                <br />
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <br />
                <asp:Button ID="btnupload" runat="server" BackColor="Black" Height="30px" Text="Upload" Width="150px" OnClick="btnupload_Click" BorderStyle="None" Font-Bold="True" ForeColor="White" />
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Product Id</td>
            <td class="auto-style6" colspan="2">
                <asp:TextBox ID="txtid" runat="server" Height="30px" Width="350px" ClientIDMode="AutoID" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Product Name</td>
            <td class="auto-style6" colspan="2">
                <asp:TextBox ID="txtname" runat="server" Height="30px" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Product Catagery</td>
            <td class="auto-style6" colspan="2">
                <asp:DropDownList ID="drpcatagery" runat="server" Height="30px" Width="350px" DataSourceID="SqlDataSource2" DataTextField="Catname" DataValueField="Catname">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Catid], [Catname] FROM [Catagery]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Product Price</td>
            <td class="auto-style10" colspan="2">
                <asp:TextBox ID="txtprice" runat="server" Height="30px" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Product Specification</td>
            <td class="auto-style6" colspan="2">
                <asp:TextBox ID="txtspecification" runat="server" Height="70px" TextMode="MultiLine" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style12">Available Stock</td>
            <td class="auto-style12">
                <asp:TextBox ID="txtstock" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">&nbsp;&nbsp;&nbsp;<br />
                &nbsp;
                <asp:Button ID="btnaddnew" runat="server" BackColor="Black" Height="30px" Text="Add New" Width="150px" OnClick="btnaddnew_Click" BorderStyle="None" Font-Bold="True" ForeColor="White" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnasave" runat="server" BackColor="Black" Height="30px" Text="Save" Width="150px" OnClick="btnasave_Click" BorderStyle="None" Font-Bold="True" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnupdate" runat="server" BackColor="Black" Height="30px" Text="Update" Width="150px" OnClick="btnupdate_Click" BorderStyle="None" Font-Bold="True" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btndelete" runat="server" BackColor="Black" Height="30px" Text="Delete" Width="150px" OnClick="btndelete_Click" BorderStyle="None" Font-Bold="True" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server" BackColor="Black" Height="30px" Text="Cancel" Width="150px" OnClick="btncancel_Click" BorderStyle="None" Font-Bold="True" ForeColor="White" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <div class="auto-style8">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Pid" DataSourceID="SqlDataSource1" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" PageSize="5" Width="1129px">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:BoundField DataField="Pid" HeaderText="Pid" ReadOnly="True" SortExpression="Pid" />
                            <asp:BoundField DataField="Pname" HeaderText="Pname" SortExpression="Pname" />
                            <asp:BoundField DataField="Pcatagery" HeaderText="Pcatagery" SortExpression="Pcatagery" />
                            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                            <asp:BoundField DataField="Pspecification" HeaderText="Pspecification" SortExpression="Pspecification" />
                            <asp:BoundField DataField="Image" HeaderText="Image" SortExpression="Image" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6" colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
