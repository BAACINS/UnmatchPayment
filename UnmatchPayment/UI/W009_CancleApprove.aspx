<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="W009_CancleApprove.aspx.cs" Inherits="UnmatchPayment.UI.W009_CancleApprove" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="icheck.min.js"></script>
    <link href="../skins/polaris/polaris.css" rel="stylesheet">
    <script type="text/javascript" language="javascript">
        function CheckAllEmp() {
            alert('aa');
            <%--var GridVwHeaderChckbox = document.getElementById("<%=gvUnmatchList.ClientID %>");
            for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
                GridVwHeaderChckbox.rows[i].cells[8].getElementsByTagName("INPUT")[0].checked = true;//Checkbox.checked;
            }--%>
        }
        window.onload = function () {
            var listCause = new Array();
            var hdlistCause = document.getElementById('<%=hdListCause.ClientID%>').value;
            var hdMaxCause = document.getElementById('<%=hdMaxCause.ClientID%>').value;

            if (hdlistCause != '') {
                listCause = hdlistCause.split(',');
                for (var j = 0; j < listCause.length; j++) {
                    if (listCause[j] != '') {
                        document.getElementById("radio" + listCause[j]).checked = true;
                    }
                }
            }
        };

        function rdbChecked(CauseID) {
            var listCause = new Array();
            var hdlistCause = document.getElementById('<%=hdListCause.ClientID%>').value;
            listCause = hdlistCause.split(',');
            if (document.getElementById("radio" + CauseID).checked) {
                listCause.push(CauseID);
            }
            else {
                for (var i = listCause.length; i--;) {
                    if (listCause[i] == CauseID) {
                        listCause.splice(i, 1);
                    }
                }
            }

            document.getElementById('<%=hdListCause.ClientID%>').value = listCause;
        }

        //$(document).ready(function () {
        //    $('input').iCheck({
        //        checkboxClass: 'icheckbox_polaris',
        //        radioClass: 'iradio_polaris',
        //        increaseArea: '-10%' // optional
        //    });
        //});
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>ยกเลิกอนุมัติรายการ Unmatch</h1>
    <br />

    <asp:CheckBoxList ID="cbCauseList" runat="server">
    </asp:CheckBoxList>
    <div>
        <table width="100%">
            <tr>
                <td>
                    <asp:Literal ID="ltrbl" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <asp:Button ID="btnSearch" runat="server" Text="ค้นหา" CssClass="button" OnClick="btnSearch_Click" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdListCause" runat="server" />
        <asp:HiddenField ID="hdMaxCause" runat="server" />
    </div>
    <br />

    <p>
        <asp:Label ID="lblDataNotFound" runat="server" Text="ไม่พบข้อมูล" ForeColor="Red"></asp:Label>
        <asp:GridView ID="gvUnmatchList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="TellerPaymentDetailID" HeaderText="รหัสอ้างอิง" />
                <asp:BoundField DataField="CompCode" HeaderText="รหัสรายการ" />
                <asp:BoundField DataField="Amount" HeaderText="จำนวนเงิน" />
                <asp:BoundField DataField="Ref1" HeaderText="Ref1" />
                <asp:BoundField DataField="Ref2" HeaderText="Ref2" />
                <asp:BoundField DataField="RefName" HeaderText="Ref อ้างอิงชื่อ" />
                <asp:BoundField DataField="PaymentDate" HeaderText="วันที่ชำระ" />
                <asp:BoundField DataField="CauseDescription" HeaderText="รายการ Unmatched" />
                <asp:BoundField HeaderText="คืนเงินด้วย SPIN" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbSPIN" Value="SPIN" runat="server" GroupName="rdbReturnType" Enabled='<%# Eval("IsSpin") %>' Checked='<%# CheckReturnDefault(DataBinder.Eval(Container.DataItem,"IsSpin"),DataBinder.Eval(Container.DataItem,"IsGL")) %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField HeaderText="คืนเงินด้วย GL" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbGL" Value="GL" runat="server" GroupName="rdbReturnType" Enabled='<%# Eval("IsGL") %>' Checked='<%# CheckReturnDefault(DataBinder.Eval(Container.DataItem,"IsGL"),DataBinder.Eval(Container.DataItem,"IsSpin")) %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField HeaderText="" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" Text=' แก้ไข '
                            CssClass="button" OnClick="btnView_Click" CommandArgument='<%# Eval("TellerPaymentDetailID") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ยกเลิกอนุมัติ" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkboxSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemTemplate>
                        <asp:CheckBox ID="chkApp" runat="server" CommandArgument='<%#Eval("TellerPaymentDetailID")%>'></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </p>
    <asp:Button ID="btnApprove" runat="server" Text="อนุมัติ" CssClass="button" OnClick="btnApprove_Click" />
    <p>
    </p>

</asp:Content>
