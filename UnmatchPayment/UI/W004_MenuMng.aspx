<%@ Page Title="จัดการเมนู" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="W004_MenuMng.aspx.cs" Inherits="UnmatchPayment.UI.MenuMng" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <h1>จัดการเมนู</h1>
    </p>

    <p class="underLine"></p>
     
    <div>
        <table width="100%">

        <tr>
            <td>
                <asp:Button ID="bntAddMenu" runat="server" Text="เพิ่มข้อมูล" CssClass="button" OnClick="bntAddMenu_Click" />

            </td>
        </tr>
            <tr>

            </tr>
        <tr>
            <td>
                <asp:GridView ID="gvAllAppMenu" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" GridLines="Horizontal" PageSize="2">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField HeaderText="รหัส" DataField="MenuNo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ชื่อ" DataField="MenuDesc">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Url" DataField="MenuUrl">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" Text="แก้ไข" CssClass="button" Width="80px" 
                                     OnClick="btnEdit_Click" CommandArgument='<%# Eval("MenuNo") %>' />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnDel" runat="server" Text="ลบ" CssClass="button" Width="80px" CommandArgument='<%# Eval("MenuNo") %>' OnClientClick="return confirm('ยืนยันการลบข้อมูล');" OnClick="btnDel_Click" />
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
            </td>

        </tr>

    </table>
    </div>
     <div style="display: none;">
         <p class="underLine"></p>
        <asp:Button ID="btnShowForm" runat="server" Text="Show Form" class="button" />
        <asp:Button ID="btnCloseForm" runat="server" Text="Close Form" class="button" />
        <asp:HiddenField ID="hdnIsShowForm" runat="server" Value="0" />
    </div>
    <asp:ModalPopupExtender ID="ModalPopupForm" runat="server" BehaviorID="dialogForm"
        TargetControlID="btnShowForm" OkControlID="btnShowForm" CancelControlID="btnCloseForm"
        PopupControlID="pnlPopup" BackgroundCssClass="modalPopupBG" />
    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none;">
        <div class="popup_Container" style="width: 500px">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="titlebarLeft">
                    <asp:Label ID="lblDialogTitle" runat="server"></asp:Label>
                </div>
                <div class="titlebarRight" onclick="HideForm();"></div>
            </div>
            <div class="popup_Body"style="background-position: center top;  filter : progid:DXImageTransform.Microsoft.gradient(startColorstr='#E0E0E0', endColorstr='#FFFFFF'); box-shadow : 2px 2px 0px #F5F5F5; ">
                <table width="500px" >
                    <tr>
                        <td class="auto-style10"></td>
                        <td class="auto-style11"></td>
                        <td class="auto-style12"></td>
                    </tr>
                    <tr>
                        <td class="auto-style13"></td>
                        <td class="auto-style14">รหัสเมนู :</td>
                        <td class="auto-style15">
                            <asp:TextBox ID="txtMenuCode" runat="server" Width="100px" MaxLength="4" CssClass="textBox"></asp:TextBox>
                            <asp:HiddenField ID="hdMenuCode" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">ลำดับเมนู :</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtMenuSeq" runat="server" Width="100px" MaxLength="4" CssClass="textBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">ชื่อเมนู :</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtMenuName" runat="server" Width="300px" MaxLength="80" CssClass="textBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">เมนู URL :</td>
                        <td>
                            <asp:TextBox ID="txtMenuUrl" runat="server" Width="300px" MaxLength="256" CssClass="textBox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">กลุ่มเมนู :</td>
                        <td>
                            <asp:DropDownList ID="ddlMenuGroup" runat="server" Width="305px" CssClass="dropDownList"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td>
                            <asp:CheckBox ID="chbMenuShow" runat="server" Text="แสดงเมนู" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnSave" runat="server" Text="บันทึกข้อมูล" CssClass="button" Width="100px" OnClientClick="return onSave();" OnClick="btnSave_Click" /></td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" CssClass="button" Width="100px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style6">&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
