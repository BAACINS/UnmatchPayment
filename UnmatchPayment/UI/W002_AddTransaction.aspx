<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="W002_AddTransaction.aspx.cs" Inherits="UnmatchPayment.UI.AddTransaction" MaintainScrollPositionOnPostback="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UC/Calendar.ascx" TagPrefix="uc1" TagName="Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function rdbChecked(id) {
            document.getElementById('<%=hdCauseID.ClientID%>').value = id;
            PageMethods.setCause(id);
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
    <br />
    <div>
        <table class="features-table">
            <thead>
                <tr>
                    <td>รายการ</td>
                    <td>ข้อมูลที่สาขาบันทึก</td>
                    <td>ข้อมูลที่ถูกต้อง</td>
                </tr>
            </thead>
            <%--<tfoot>
					<tr>
						<td></td>
						<td>$99</td>
						<td>$199</td>
					</tr>
				</tfoot>	--%>
            <tbody>
                <tr>
                    <td>รหัสบริการ</td>
                    <td>
                        <asp:Label ID="lblCompCode" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtCompCode" runat="server" CssClass="button"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>จำนวนเงิน</td>
                    <td>
                        <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="button"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ref1</td>
                    <td>
                        <asp:Label ID="lblRef1" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRef1" runat="server" CssClass="button"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ref2</td>
                    <td>
                        <asp:Label ID="lblRef2" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRef2" runat="server" CssClass="button"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ref อ้างอิง</td>
                    <td>
                        <asp:Label ID="lblRefName" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRefName" runat="server" CssClass="button"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>วันที่ชำระ</td>
                    <td>
                        <asp:Label ID="lblPaymentDate" runat="server" Text=""></asp:Label></td>
                    <td>                        
                        <table id="UCcalendar">
                            <tr>
                                <td><uc1:Calendar runat="server" ID="txtPaymentDate" /></td>
                            </tr>
                        </table>
                            
                    </td>
                </tr>
            </tbody>
        </table>
        <br />
    </div>
    <div>
        <table class="features-table">
            <thead>
                <tr>
                    <td colspan="3"></td>
                    <%--<td>ข้อมูลที่สาขาบันทึก</td>
						<td>ข้อมูลที่ถูกต้อง</td>--%>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>เลขที่บัญชีเงินฝาก</td>
                    <td>
                        <asp:TextBox ID="txtDepNo" Width="250px" runat="server" CssClass="button"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td>UploadFile :&nbsp;<asp:DropDownList ID="ddlFileType" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
                    <td>
                        <asp:FileUpload ID="BrowsFile" runat="server" Height="28px" Width="450px" CssClass="textBox" />&nbsp;<asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Upload" OnClick="btnUpload_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblFileUpload" runat="server" Text=""></asp:Label>
                        <br />

                    </td>
                </tr>
            </tbody>
        </table>
        <asp:GridView ID="gvUploadFile" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="ชื่อไฟล์">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkPartial" runat="server" Text='<%# Eval("FileName") %>' CommandArgument='<%# String.Format("{0}_{1}", Eval("FileID"), Eval("FileOriginName")) %>' OnClick="DownloadFile" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FileSize" HeaderText="ขนาดไฟล์ (KB)" />
                <asp:BoundField DataField="UploadDate" HeaderText="วันที่อัพโหลด" />
                <asp:BoundField DataField="UploadBy" HeaderText="อัพโหลดโดย" />
                <asp:BoundField HeaderText="" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDelFile" runat="server" Text="ลบ"
                            OnClick="btnDelFile_Click" CommandArgument='<%# Eval("FileID") %>' CssClass="button" />
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
    </div>
    <br />
    <div style="text-align: center;">
        <asp:Button ID="bntSave" runat="server" Text="บันทึก" CssClass="button" OnClick="bntSave_Click" />
        &nbsp
        <asp:Button ID="bntCancle" runat="server" Text="ยกเลิก" CssClass="button" />
    </div>

    <%--//----------------------------------------------------%>
</asp:Content>
