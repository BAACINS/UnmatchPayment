<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="W002_AddTransaction.aspx.cs" Inherits="UnmatchPayment.UI.AddTransaction" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function rdbChecked(id) {
            document.getElementById('<%=hdCauseID.ClientID%>').value = id;
        }
    </script>
    <p>
        <h1>บันทึกรายการ Unmatch</h1>
    </p>
    <p class="underLine"></p>

    <div>
        <h2>รายการ Unmatched</h2>
        <table width="100%">
            <tr>
                <td>
                    <asp:Literal ID="ltrbl" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hdCauseID" runat="server" />
                </td>
            </tr>
    </table>
    </div>
    <div>
        <asp:GridView ID="gvListed" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" GridLines="Horizontal" PageSize="2">
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
        <asp:Button ID="bntSave" runat="server" Text="บันทึก" CssClass="button" OnClick="bntSave_Click" /> &nbsp
        <asp:Button ID="bntCancle" runat="server" Text="ยกเลิก" CssClass="button" />
    </div>

        <%--//----------------------------------------------------%>
    <asp:Panel ID="PanelUploadFile" runat="server" BorderColor="Black" Height="380px"
        Width="800px" HorizontalAlign="Left" BorderStyle="Double" BackColor="InactiveCaption" ><%--Style="display: none;"--%>
        <table style="width: 100%;">
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="width: 25%"></td>
                <td style="font-size: x-large; text-align: center; color: #4184b8;">อัพโหลดเอกสารประกอบการแก้ไขรายการ</td>
                <td style="width: 25%"></td>
            </tr>
            <tr>
                <td style="text-align: right">Slip pay in :</td>
                <td align="center">
                    <asp:FileUpload ID="FileSlip" runat="server" Height="28px" Width="450px" CssClass="textBox" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">ใบคำขอ/ใบแจ้ง :</td>
                <td align="center">
                    <asp:FileUpload ID="FileClaim" runat="server" Height="28px" Width="450px" CssClass="textBox" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">หน้าสมุด/Statement :</td>
                <td align="center">
                    <asp:FileUpload ID="FileStatement" runat="server" Height="28px" Width="450px" CssClass="textBox" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr id="trFileUpload6" runat="server">
                <td></td>
<%--                <td align="center">
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="28px" Width="450px" CssClass="textBox" />
                </td>--%>
                <td>
                    <asp:Label ID="lblFileUpload1" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="Left" style="color: red">*File ต้องเป็น .pdf หรือ .jpg และมีขนาดไม่เกิน 300 KB เท่านั้น </td>
                <td></td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Button ID="btnUpload" runat="server" Text="อัพโหลดไฟล์" CssClass="button"/>
                    &nbsp;
                    <asp:Button ID="btnCloseUploadFile" runat="server" Text="ปิด" Width="65px" CssClass="button" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
