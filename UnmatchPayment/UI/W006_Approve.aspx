<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="W006_Approve.aspx.cs" Inherits="UnmatchPayment.UI.W006_Approve" MaintainScrollPositionOnPostback="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        function CheckAllEmp(Checkbox) {
            var GridVwHeaderChckbox = document.getElementById("<%=gvUnmatchList.ClientID %>");
            for (i = 1; i < GridVwHeaderChckbox.rows.length; i++) {
                GridVwHeaderChckbox.rows[i].cells[8].getElementsByTagName("INPUT")[0].checked = Checkbox.checked;
            }
        }
    </script>
    <h1>อนุมัติรายการ Unmatched</h1>
    <br />
    <p style="margin-left: -50px; padding-left: -10px;">
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
                        <asp:RadioButton ID="rdbSPIN" Value="SPIN" runat="server" GroupName="rdbReturnType" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField HeaderText="คืนเงินด้วย GL" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbGL" Value="GL" runat="server" GroupName="rdbReturnType" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField HeaderText="" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" Text=' View '
                            CssClass="button" OnClick="btnView_Click" CommandArgument='<%# Eval("TellerPaymentDetailID") %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkboxSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                    </HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkApp" runat="server"></asp:CheckBox>
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
