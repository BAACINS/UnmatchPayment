<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddTransaction.aspx.cs" Inherits="UnmatchPayment.UI.AddTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <h1>บันทึกรายการ Unmatch</h1>
    </p>
    <p class="underLine"></p>

    <div>
        <table width="100%">

            <tr>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server"></asp:RadioButtonList>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server"></asp:RadioButtonList>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList3" runat="server"></asp:RadioButtonList>
                </td>
            </tr>
    </table>
    </div>
    <div>
        <asp:GridView ID="gvAllAppMenu" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" GridLines="Horizontal" PageSize="2">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField HeaderText="รายการ" DataField="">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ข้อมูลที่สาขาบันทึก" DataField="">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ข้อมูลที่ถูกต้อง" >
                            <ItemTemplate>
                                <asp:TextBox ID="txt" runat="server" CssClass="textBox"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
    </div>
    <div style="text-align:center;">
        <asp:Button ID="bntSave" runat="server" Text="บันทึก" CssClass="button" /> &nbsp
        <asp:Button ID="bntCancle" runat="server" Text="ยกเลิก" CssClass="button" />
    </div>
</asp:Content>
