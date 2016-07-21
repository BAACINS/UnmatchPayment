<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="WR003_UnmatchUnbound.aspx.cs" Inherits="UnmatchPayment.UI.Reports.WR003_UnmatchUnbound" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UC/Calendar.ascx" TagPrefix="uc1" TagName="Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <h1>รายงานรายการ Unmatch ที่ไม่พบใบคำขอ</h1>
    </p>
     <table style="width: 850px">
        <tr>
            <td class="auto-style5">ฝ่ายภาค :</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlRegion" runat="server" CssClass="dropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"></asp:DropDownList></td>

        </tr>
        <tr>
            <td class="auto-style2">สำนักงานจังหวัด :</td>
            <td colspan="3" class="auto-style6">
                <asp:DropDownList ID="ddlProvince" runat="server" CssClass="dropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"></asp:DropDownList></td>

        </tr>
        <tr>
            <td class="auto-style5">สาขา :</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="dropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"></asp:DropDownList></td>

        </tr>
        <tr>
            <td class="auto-style5">วันที่จ่ายตั้งแต่ : 
            </td>
            <td>
                <uc1:calendar runat="server" id="txtDateFrom" />
            </td>
            <td>ถึง</td>
            <td>
                <uc1:calendar runat="server" id="txtDateTo" />
            </td>

        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style3">
                <asp:Button ID="btnPrint" runat="server" Text="พิมพ์รายงาน" CssClass="button"
                     OnClick="btnPrint_Click" /></td>
            <td></td>
            <td></td>
        </tr>

    </table>
</asp:Content>
