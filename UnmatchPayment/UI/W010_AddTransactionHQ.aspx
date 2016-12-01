<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="W010_AddTransactionHQ.aspx.cs" Inherits="UnmatchPayment.UI.W010_AddTransactionHQ" MaintainScrollPositionOnPostback="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/UC/Calendar.ascx" TagPrefix="uc1" TagName="Calendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function stringToBoolean(string){
            switch(string.toLowerCase().trim()){
                case "true": case "yes": case "1": case "1]": return true;
                case "false": case "no": case "0": case "0]": case null: return false;
                default: return Boolean(string);
            }
        }
        window.onload = function(){
            var CauseID = document.getElementById('<%=hdCauseID.ClientID%>').value;
            if(CauseID != '')
                document.getElementById("radio"+CauseID).checked = true;

            var hdlistCause = document.getElementById('<%=hdlistCause.ClientID%>').value;
            if(hdlistCause != ''){
                var listCause = new Array();
                listCause = hdlistCause.split(',');
                //alert(listCause + '-' + stringToBoolean(listCause[1])+ '-' + stringToBoolean(listCause[2])+ '-' + stringToBoolean(listCause[3])+ '-' + stringToBoolean(listCause[4])+ '-' + stringToBoolean(listCause[5]) );
                document.getElementById('<%=txtCompCode.ClientID%>').disabled = !stringToBoolean(listCause[1]);
                document.getElementById('<%=txtAmount.ClientID%>').disabled = !stringToBoolean(listCause[2]);
                document.getElementById('<%=txtRef1.ClientID%>').disabled = !stringToBoolean(listCause[3]);
                document.getElementById('<%=txtRef2.ClientID%>').disabled = !stringToBoolean(listCause[4]);
                document.getElementById('<%=txtRefName.ClientID%>').disabled = !stringToBoolean(listCause[5]);
                if(stringToBoolean(listCause[6]))
                    document.getElementById('<%=UCcalendar.ClientID%>').style.visibility = "visible";
                else
                    document.getElementById('<%=UCcalendar.ClientID%>').style.visibility = "hidden";
                document.getElementById('<%=txtDepNo.ClientID%>').disabled = !stringToBoolean(listCause[7]);
                document.getElementById('<%=BrowsFile.ClientID%>').disabled = !stringToBoolean(listCause[8]);
                document.getElementById('<%=btnUpload.ClientID%>').disabled = !stringToBoolean(listCause[8]);

                document.getElementById('<%=rdSPIN.ClientID%>').disabled = !stringToBoolean(listCause[9]);
                document.getElementById('<%=rdGL.ClientID%>').disabled = !stringToBoolean(listCause[10]);
            }
        };
        function rdbChecked(id,listCause) {
            //alert(listCause);
            document.getElementById('<%=hdCauseID.ClientID%>').value = id;
            document.getElementById('<%=hdlistCause.ClientID%>').value = listCause;
            
            document.getElementById('<%=txtCompCode.ClientID%>').disabled = !Boolean(listCause[1]);
            document.getElementById('<%=txtAmount.ClientID%>').disabled = !Boolean(listCause[2]);
            document.getElementById('<%=txtRef1.ClientID%>').disabled = !Boolean(listCause[3]);
            document.getElementById('<%=txtRef2.ClientID%>').disabled = !Boolean(listCause[4]);
            document.getElementById('<%=txtRefName.ClientID%>').disabled = !Boolean(listCause[5]);
            if(Boolean(listCause[6]))
                document.getElementById('<%=UCcalendar.ClientID%>').style.visibility = "visible";
            else
                document.getElementById('<%=UCcalendar.ClientID%>').style.visibility = "hidden";
            document.getElementById('<%=txtDepNo.ClientID%>').disabled = !Boolean(listCause[7]);
            document.getElementById('<%=BrowsFile.ClientID%>').disabled = !Boolean(listCause[8]);
            document.getElementById('<%=btnUpload.ClientID%>').disabled = !Boolean(listCause[8]);
            
            document.getElementById('<%=rdSPIN.ClientID%>').disabled = !Boolean(listCause[9]);
            document.getElementById('<%=rdGL.ClientID%>').disabled = !Boolean(listCause[10]);
        }
        
        function onSave() {
            if(document.getElementById('<%=hdCauseID.ClientID%>').value == ''){
                alert('กรุณาระบุ รสาเหตุรายการ Unmatched');
                return false;
            }
            else if (document.getElementById('<%=txtCompCode.ClientID%>').disabled == false &&
                document.getElementById('<%=txtCompCode.ClientID%>').value == '') {
                alert('กรุณาระบุ รหัสบริการ');
                return false;
            }
            else if (document.getElementById('<%=txtAmount.ClientID%>').disabled == false &&
                document.getElementById('<%=txtAmount.ClientID%>').value == '') {
                alert('กรุณาระบุ จำนวนเงิน');
                return false;
            }
            else if (document.getElementById('<%=txtRef1.ClientID%>').disabled == false &&
                document.getElementById('<%=txtRef1.ClientID%>').value == '') {
                alert('กรุณาระบุ Ref 1');
                return false;
            }
            else if (document.getElementById('<%=txtRef2.ClientID%>').disabled == false &&
                document.getElementById('<%=txtRef2.ClientID%>').value == '') {
                alert('กรุณาระบุ Ref 2');
                return false;
            }
            else if (document.getElementById('<%=txtRefName.ClientID%>').disabled == false &&
                document.getElementById('<%=txtRefName.ClientID%>').value == '') {
                alert('กรุณาระบุ Ref อ้างอิงชื่อ');
                return false;
            }
            else if (document.getElementById('<%=UCcalendar.ClientID%>').style.visibility == "visible" &&
                document.getElementById('<%=txtPaymentDate.TextBoxClientID%>').value == '') {
                alert('กรุณาระบุ วันที่ชำระ');
                return false;
            }
            else if (document.getElementById('<%=txtDepNo.ClientID%>').disabled == false &&
                document.getElementById('<%=txtDepNo.ClientID%>').value == '') {
                alert('กรุณาระบุ เลขที่บัญชีเงินฝาก');
                return false;
            }
            else if (document.getElementById('<%=BrowsFile.ClientID%>').disabled == false &&
                <%=gvUploadFile.Rows.Count%> == 0) {
                alert('กรุณาแนบไฟล์');
                return false;
            }
            else if(document.getElementById('<%=rdSPIN.ClientID%>').disabled == false &&
                document.getElementById('<%=rdSPIN.ClientID%>').checked == false &&
                document.getElementById('<%=rdGL.ClientID%>').disabled == true){
                alert('กรุณาเลือกประเภทการคืนเงิน');
                return false;
            }
            else if(document.getElementById('<%=rdGL.ClientID%>').disabled == false &&
                document.getElementById('<%=rdGL.ClientID%>').checked == false &&
                document.getElementById('<%=rdSPIN.ClientID%>').disabled == true){
                alert('กรุณาเลือกประเภทการคืนเงิน');
                return false;
            }
            else if(document.getElementById('<%=rdGL.ClientID%>').disabled == false &&
                document.getElementById('<%=rdGL.ClientID%>').checked == false &&
                document.getElementById('<%=rdSPIN.ClientID%>').disabled == false &&
                document.getElementById('<%=rdSPIN.ClientID%>').checked == false){
                alert('กรุณาเลือกประเภทการคืนเงิน');
                return false;
            }
}
    </script>

    <p>
        <h1>บันทึกรายการ Unmatch</h1>
    </p>
    <p class="underLine"></p>

    <div>
        <h2>สาเหตุการทำรายการไม่สำเร็จ</h2>
        <table width="100%">
            <tr>
                <td>
                    <asp:Literal ID="ltrbl" runat="server"></asp:Literal>
                    <asp:HiddenField ID="hdCauseID" runat="server" />
                    <asp:HiddenField ID="hdlistCause" runat="server" />
                    <asp:HiddenField ID="hdBranchCode" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:Label ID="lbltellerPaymentID" runat="server" Font-Strikeout="False" 
            Font-Underline="True" Font-Names="TH Sarabun New" Font-Bold="true" Font-Size="30px"></asp:Label>
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
                        <asp:TextBox ID="txtCompCode" runat="server" CssClass="button" MaxLength="4"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>จำนวนเงิน</td>
                    <td>
                        <asp:Label ID="lblAmount" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="button" MaxLength="13"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ref1</td>
                    <td>
                        <asp:Label ID="lblRef1" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRef1" runat="server" CssClass="button" MaxLength="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ref2</td>
                    <td>
                        <asp:Label ID="lblRef2" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRef2" runat="server" CssClass="button" MaxLength="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Ref อ้างอิง</td>
                    <td>
                        <asp:Label ID="lblRefName" runat="server" Text=""></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRefName" runat="server" CssClass="button" MaxLength="50"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>วันที่ชำระ</td>
                    <td>
                        <asp:Label ID="lblPaymentDate" runat="server" Text=""></asp:Label></td>
                    <td>
                        <table id="UCcalendar" runat="server">
                            <tr>
                                <td style="width: 45px"></td>
                                <td>
                                    <uc1:Calendar runat="server" ID="txtPaymentDate" />
                                </td>
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
                    <td style="text-align:left;">
                        <asp:TextBox ID="txtDepNo" Width="250px" runat="server" CssClass="button" MaxLength="15"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td>การคืนเงิน</td>
                    <td style="text-align:left;">
                        <input type = 'radio' name='radio' id='rdSPIN' runat='server'/>
                        <label for= 'rdSPIN' > SPIN </label>

                        <input type = 'radio' name='radio' id='rdGL' runat='server'/>
                        <label for= 'rdGL' > GL </label>
                        </td>
                </tr>
                <tr>
                    <td>UploadFile :&nbsp;<asp:DropDownList ID="ddlFileType" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
                    <td style="text-align:left;">
                        <asp:FileUpload ID="BrowsFile" runat="server" Height="28px" Width="450px" CssClass="textBox" />&nbsp;<asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Upload" OnClick="btnUpload_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align:left;">
                        <asp:Label ID="lblUploadFileDetail" runat="server" Text="*File ต้องเป็น .pdf หรือ .jpg และมีขนาดไม่เกิน 600 KB เท่านั้น" ForeColor="Red"></asp:Label>
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
        <asp:Button ID="btnSave" runat="server" Text=" อนุมัติ " CssClass="button" OnClick="btnSave_Click" OnClientClick="return onSave()" />
        &nbsp
        <asp:Button ID="btnClose" runat="server" Text="  ปิด  " CssClass="button" OnClick="btnClose_Click" />
    </div>

    <%--//----------------------------------------------------%>
</asp:Content>
