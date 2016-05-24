<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="WR001_AddEditPayment.aspx.cs" Inherits="UnmatchPayment.UI.WR001_AddEditPayment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UC/Calendar.ascx" TagPrefix="uc1" TagName="Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <h1>รายงานบันทึก/แก้ไขรายการ Unmatch</h1>
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
            <td class="auto-style5">โครงการ :</td>
            <td>
                <asp:DropDownList ID="ddlProject" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
            <td class="auto-style5">ประเภท :</td>
            <td>
                <asp:DropDownList ID="ddlClaimDetail" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style5">ผู้บันทึก/แก้ไข :</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlUserID" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="auto-style5">วันที่บันทึกคำขอ ตั้งแต่ : 
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
