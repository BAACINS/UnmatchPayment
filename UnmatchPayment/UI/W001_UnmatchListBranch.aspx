<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="W001_UnmatchListBranch.aspx.cs" Inherits="UnmatchPayment.UI.UnmatchListBranch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>รายการ Unmatch</h1>

    <asp:GridView ID="gvUnmatchList" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AutoGenerateColumns="False">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="CompCode" HeaderText="รหัสรายการ" />
            <asp:BoundField DataField="Amount" HeaderText="จำนวนเงิน" />
            <asp:BoundField DataField="Ref1" HeaderText="Ref1" />
            <asp:BoundField DataField="Ref2" HeaderText="Ref2" />
            <asp:BoundField DataField="CustomerName" HeaderText="Ref อ้างอิงชื่อ" />
            <asp:BoundField DataField="PaymentDate" HeaderText="วันที่ชำระ" />
            <asp:BoundField HeaderText=""/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" Text=' View ' 
                        CssClass="button" OnClick="btnView_Click" CommandArgument='<%# Eval("TellerPaymentDetailID") %>'  />
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
</asp:Content>
