<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="Bagshop.Admin.ManageCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            margin-left: 0px;
        }
        .auto-style7 {
         
        }
    .auto-style8 {
     
    }
    .auto-style9 {
       
        color: #000000;
    
        text-align: left;
            font-size: x-large;
            background-color: #FFFFFF;
        }
        .auto-style12 {
            text-align: center;
            font-size: medium;
        }
        .auto-style13 {
            text-align: left;
        }
        .auto-style14 {
            text-align: left;
            font-size: medium;
            margin-top: 0px;
        }
    .auto-style15 {
        margin-left: 0px;
        background-color: #003366;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table class="auto-style12" align="center" style="padding: 3px; border: thin solid #C0C0C0;">
    <tr>
        <td class="auto-style9" colspan="2" ><strong>Manage Category<hr />
            </strong></td>
    </tr>
    <tr>
        <td class="auto-style13">Category Id</td>
        <td class="auto-style13">
            <asp:TextBox ID="txtid" runat="server" Height="30px" Width="363px" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style13">Category Name</td>
        <td class="auto-style13">
            <asp:TextBox ID="txtname" runat="server" Height="30px" Width="370px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style13">Category Image&nbsp; </td>
        <td class="auto-style13">&nbsp;<asp:ImageButton ID="imgcategoryimage" runat="server" Height="117px" Width="211px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style14" Height="24px" Width="295px" />
            &nbsp;<asp:Button ID="btnupload" runat="server" BackColor="Black" Height="30px" Text="Upload" Width="150px" OnClick="btnupload_Click" BorderStyle="None" ForeColor="White" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
      
    </tr>
    <tr>
        <td class="auto-style13">Category Info</td>
        <td class="auto-style13">
            <asp:TextBox ID="txtinfo" runat="server" Height="72px" TextMode="MultiLine" Width="383px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnnew" runat="server" BackColor="Black" Height="30px" OnClick="btnnew_Click" Text="New" Width="150px" BorderStyle="None" ForeColor="White" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnsave" runat="server" BackColor="Black" Height="30px" Text="Save" Width="150px" OnClick="btnsave_Click" BorderStyle="None" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnupdate" runat="server" BackColor="Black" Height="30px" Text="Update" Width="150px" OnClick="btnupdate_Click" BorderStyle="None" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btndelete" runat="server" BackColor="Black" Height="30px" Text="Delete" Width="150px" OnClick="btndelete_Click" BorderStyle="None" ForeColor="White" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btncancel" runat="server" BackColor="Black" Height="30px" Text="Cancel" Width="150px" OnClick="btncancel_Click" BorderStyle="None" ForeColor="White" />
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style15" DataKeyNames="Catid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1055px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="Catid" HeaderText="Catid" ReadOnly="True" SortExpression="Catid" />
                    <asp:BoundField DataField="Catname" HeaderText="Catname" SortExpression="Catname" />
                    <asp:BoundField DataField="Catimage" HeaderText="Catimage" SortExpression="Catimage" />
                    <asp:BoundField DataField="Catinfo" HeaderText="Catinfo" SortExpression="Catinfo" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT DISTINCT * FROM [Catagery]"></asp:SqlDataSource>
        </td>
    </tr>
</table>
</asp:Content>
