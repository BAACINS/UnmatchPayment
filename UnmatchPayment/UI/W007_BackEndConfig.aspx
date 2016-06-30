<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="W007_BackEndConfig.aspx.cs" Inherits="UnmatchPayment.UI.Config" MaintainScrollPositionOnPostback="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <h1>ตั้งค่าการแสดงผลหน้าจอบันทึก/แก้ไขข้อมูล</h1>
    </p>
    <p class="underLine"></p>
    <div>
        <table width="100%">

            <tr>
                <td>
                    <asp:GridView ID="gvCause" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None"
                        BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" GridLines="Horizontal" PageSize="2"
                        HorizontalAlign="Center" ShowFooter="True" OnRowEditing="gvCause_RowEditing" OnRowUpdating="gvCause_RowUpdating">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:TemplateField HeaderText="รหัส">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("CauseID") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <FooterTemplate>
                                    <asp:Button ID="AddCause" runat="server" Text="Add" OnClick="btnAddCause_Click" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="รายละเอียด">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CauseDescription") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCauseDesc" runat="server" Text='<%# Bind("CauseDescription") %>' CommandArgument='<%#Eval("CauseID")%>'> </asp:TextBox>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                                <FooterTemplate>
                                    <asp:TextBox ID="NewCauseDescription" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comp Code">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkCompCode" runat="server" Checked='<%#Eval("isCompCode")%>' Enabled ="false" CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkCompCode_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditCompCode" runat="server" Enabled="true" Checked='<%#Eval("isCompCode")%>' OnCheckedChanged="chkCompCode_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewCompCode" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAmount" runat="server" Enabled ="false" Checked='<%#Eval("isAmount")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkAmount_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditAmount" runat="server" Enabled="true" Checked='<%#Eval("isAmount")%>' OnCheckedChanged="chkAmount_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewAmount" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ref1">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRef1" runat="server" Enabled ="false" Checked='<%#Eval("isRef1")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkRef1_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditRef1" runat="server" Enabled="true" Checked='<%#Eval("isRef1")%>' OnCheckedChanged="chkRef1_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewRef1" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ref2">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRef2" runat="server" Enabled ="false" Checked='<%#Eval("isRef2")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkRef2_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditRef2" runat="server" Enabled="true" Checked='<%#Eval("isRef2")%>' OnCheckedChanged="chkRef2_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewRef2" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RefName">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRefName" runat="server" Enabled ="false" Checked='<%#Eval("isRefName")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkRefName_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditRefName" runat="server" Enabled="true" Checked='<%#Eval("isRefName")%>' OnCheckedChanged="chkRefName_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewRefName" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payment date">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPaymentdate" runat="server" Enabled ="false" Checked='<%#Eval("isPaymentdate")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkPaymentdate_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditPaymentdate" runat="server" Enabled="true" Checked='<%#Eval("isPaymentdate")%>' OnCheckedChanged="chkPaymentdate_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewPaymentdate" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Refund">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRefund" runat="server" Enabled ="false" Checked='<%#Eval("isRefund")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkRefund_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditRefund" runat="server" Enabled="true" Checked='<%#Eval("isRefund")%>' OnCheckedChanged="chkRefund_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewRefund" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uploaded files">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkUploadFile" runat="server" Enabled ="false" Checked='<%#Eval("isUploadFile")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkUploadFile_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditUploadFile" runat="server" Enabled="true" Checked='<%#Eval("isUploadFile")%>' OnCheckedChanged="chkUploadFile_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewUploadFile" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spin">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSpin" runat="server" Enabled ="false" Checked='<%#Eval("isSpin")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkSpin_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditSpin" runat="server" Enabled="true" Checked='<%#Eval("isSpin")%>' OnCheckedChanged="chkSpin_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewSpin" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="G/L">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkGL" runat="server" Enabled ="false" Checked='<%#Eval("isGL")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkGL_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditGL" runat="server" Enabled="true" Checked='<%#Eval("isGL")%>' OnCheckedChanged="chkGL_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewGL" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update Unmatch">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkUnmatch" runat="server" Enabled ="false" Checked='<%#Eval("isUpdateUnmatched")%>' CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkUnmatch_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditUnmatch" runat="server" Enabled="true" Checked='<%#Eval("isUpdateUnmatched")%>' OnCheckedChanged="chkUnmatch_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>' />
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewUnmatch" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActive" runat="server" Checked='<%#Eval("isActive")%>' Enabled ="false" CommandArgument='<%#Eval("CauseID")%>' OnCheckedChanged="chkActive_CheckedChanged" AutoPostBack="True"></asp:CheckBox>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="EditActive" runat="server" Enabled ="true" Checked='<%#Eval("isActive")%>' OnCheckedChanged="chkActive_CheckedChanged" AutoPostBack="True" CommandArgument='<%#Eval("CauseID")%>'/>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewActive" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditCause" runat="server" Text="Edit" CommandName="Edit" />
                                    
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Done" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" HorizontalAlign="Center" />
                        <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Center" BackColor="#E7E7FF" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
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

</asp:Content>
