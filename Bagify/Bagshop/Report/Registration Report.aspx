<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Adminmaster.Master" AutoEventWireup="true" CodeBehind="Registration Report.aspx.cs" Inherits="Bagshop.Report.Registration_Report" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style9 {
            width: 90%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="3" class="auto-style9">
        <tr>
            <td class="auto-style8">Registration Report</td>
        </tr>
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" DisplayPage="False" DisplayToolbar="False" EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" />
            </td>
        </tr>
    </table>
</asp:Content>
