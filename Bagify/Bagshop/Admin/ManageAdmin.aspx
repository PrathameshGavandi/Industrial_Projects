<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.Master" AutoEventWireup="true" CodeBehind="ManageAdmin.aspx.cs" Inherits="Bagshop.Admin.ManageAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            text-decoration: underline;
            text-align: center;
            font-size: large;
            color: #FF0000;
        }
        .auto-style6 {
            height: 40px;
            text-align: left;
        }
        .auto-style7 {
            text-align: center;
        }
        .auto-style8 {
            text-align: left;
        }
        .auto-style9 {
            height: 40px;
            width: 697px;
            text-align: right;
        }
        .auto-style11 {
            text-align: center;
            height: 39px;
        }
        .auto-style12 {
            width: 697px;
            text-align: right;
        }
        .auto-style15 {
            margin-bottom: 0px;
        }
        .auto-style16 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" class="auto-style1">
        <tr>
            <td class="auto-style4" colspan="2" id="txtmanageadmin" rowspan="1"><strong>Manage Admin</strong></td>
        </tr>
        <tr>
            <td class="auto-style12" id="txtmanageadmin" rowspan="1">Admin Name</td>
            <td class="auto-style16" id="txtmanageadmin" rowspan="1">
                <asp:TextBox ID="txtname" runat="server" Height="30px" Width="200px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style12" id="txtmanageadmin" rowspan="1"> Old passward</td>
            <td class="auto-style16" id="txtmanageadmin" rowspan="1">
                <asp:TextBox ID="txtoldpassward" runat="server" Height="30px" Width="200px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9" id="txtmanageadmin" rowspan="1">New Passward</td>
            <td class="auto-style6" id="txtmanageadmin" rowspan="1">
                
                <asp:TextBox ID="txtnewpassward" runat="server" Height="30px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtnewpassward" ErrorMessage="Enter valid password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style12" id="txtmanageadmin" rowspan="1"> Confirm Passward</td>
            <td class="auto-style16" id="txtmanageadmin" rowspan="1">
                
                <asp:TextBox ID="txtconfirmpassward" runat="server" Height="30px" Width="200px" CssClass="auto-style15"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtnewpassward" ControlToValidate="txtconfirmpassward" ErrorMessage="Password does not match" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style11" colspan="2" id="txtmanageadmin" rowspan="1"><asp:Button ID="btnsave" runat="server" BackColor="Black" ForeColor="White" Height="30px" OnClick="btnsave_Click" Text="Save" Width="120px" />

                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                <asp:Button ID="btnupdate" runat="server" BackColor="Black" Height="30px" Text="Update" Width="120px" OnClick="btnupdate_Click" ForeColor="White" />
                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Button ID="btndelete" runat="server" BackColor="Black" Height="30px" OnClick="btndelete_Click" Text="Delete" Width="120px" ForeColor="White" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btncancel" runat="server" BackColor="Black" Height="30px" Text="Cancel" Width="120px" OnClick="btncancel_Click" ForeColor="White" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="2">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Adminname" HeaderText="Adminname" SortExpression="Adminname" />
                        <asp:BoundField DataField="Adminpassword" HeaderText="Adminpassword" SortExpression="Adminpassword" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Admin]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style7">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
