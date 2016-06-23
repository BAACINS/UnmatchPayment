<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="WR002_AllStatusPayment.aspx.cs" Inherits="UnmatchPayment.UI.Reports.WR002_ApprovePayment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UC/Calendar.ascx" TagPrefix="uc1" TagName="Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <p>
        <h1>รายงานผลการอนุมัติรายการ Unmatch</h1>
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
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="dropDownList"></asp:DropDownList></td>

        </tr>
        <tr>
            <td class="auto-style5">สาเหตุ :</td>
            <td>
                <asp:DropDownList ID="ddlCause" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
            <td class="auto-style5">สถานะ :</td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropDownList" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style5">ผู้ทำรายการ :</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlUserID" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style5">วันที่สถานะ ตั้งแต่ : 
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
                    OnClientClick="return onSave();" OnClick="btnPrint_Click" /></td>
            <td></td>
            <td></td>
        </tr>

    </table>
</asp:Content>
