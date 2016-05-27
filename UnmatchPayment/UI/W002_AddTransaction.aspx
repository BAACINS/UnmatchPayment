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
						<td><asp:Label ID="lblCompCode" runat="server" Text=""></asp:Label></td>
						<td><asp:TextBox ID="txtCompCode" runat="server" CssClass="button"></asp:TextBox></td>	
					</tr>
					<tr>
						<td>จำนวนเงิน</td>
						<td><asp:Label ID="lblAmount" runat="server" Text=""></asp:Label></td>
						<td><asp:TextBox ID="txtAmount" runat="server" CssClass="button"></asp:TextBox></td>			
					</tr>
					<tr>
						<td>Ref1</td>
						<td><asp:Label ID="lblRef1" runat="server" Text=""></asp:Label></td>
						<td><asp:TextBox ID="txtRef1" runat="server" CssClass="button"></asp:TextBox></td>
					</tr>
					<tr>
						<td>Ref2</td>
						<td><asp:Label ID="lblRef2" runat="server" Text=""></asp:Label></td>
						<td><asp:TextBox ID="txtRef2" runat="server" CssClass="button"></asp:TextBox></td>
					</tr>
                    <tr>
						<td>Ref อ้างอิง</td>
						<td><asp:Label ID="lblRefName" runat="server" Text=""></asp:Label></td>
						<td><asp:TextBox ID="txtRefName" runat="server" CssClass="button"></asp:TextBox></td>
					</tr>
                    <tr>
						<td>วันที่ชำระ</td>
						<td><asp:Label ID="lblPaymentDate" runat="server" Text=""></asp:Label></td>
						<td><asp:TextBox ID="txtPaymentDate" runat="server" CssClass="button"></asp:TextBox></td>
					</tr>
				</tbody>
		</table>
        <br />
    </div>
    <div>
        <table class="features-table">
				<thead>
					<tr>
						<td colspan="3">Upload File</td>
						<%--<td>ข้อมูลที่สาขาบันทึก</td>
						<td>ข้อมูลที่ถูกต้อง</td>--%>
					</tr>
				</thead>			
				<tbody>
					<tr>
						<td>Slip pay in</td>
						<td><asp:FileUpload ID="FileSlip" runat="server" Height="28px" Width="450px" CssClass="textBox" /></td>
					</tr>
                    <tr>
						<td>ใบคำขอ/ใบแจ้ง</td>
						<td><asp:FileUpload ID="FileUpload1" runat="server" Height="28px" Width="450px" CssClass="textBox" /></td>
					</tr>
                    <tr>
						<td>หน้าสมุด/Statement</td>
						<td><asp:FileUpload ID="FileUpload2" runat="server" Height="28px" Width="450px" CssClass="textBox" /></td>
					</tr>
                    <tr>
                        <td>เลขที่บัญชีเงินฝาก</td>
                        <td><asp:TextBox ID="txtDepNo" Width="250px" runat="server" CssClass="button"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    </tr>
				</tbody>
		</table>
    </div>
    <br />
    <div style="text-align: center;">
        <asp:Button ID="bntSave" runat="server" Text="บันทึก" CssClass="button" OnClick="bntSave_Click" />
        &nbsp
        <asp:Button ID="bntCancle" runat="server" Text="ยกเลิก" CssClass="button" />
    </div>

    <%--//----------------------------------------------------%>
</asp:Content>
