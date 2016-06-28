﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="UnmatchPayment.UI.Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <h1>Back-end config</h1>
    </p>
    <p class="underLine"></p>
    <div>
        <table width="100%">

            <tr>
                <td>
                    <asp:GridView ID="gvCause" runat="server" Width="100%" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" GridLines="Horizontal" PageSize="2" HorizontalAlign="Center" ShowFooter="True">
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
                                <ItemStyle HorizontalAlign="Left" />
                                <FooterTemplate>
                                    <asp:TextBox ID="NewCauseDescription" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comp Code">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkCompCode" runat="server" Checked='<%#Eval("isCompCode")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewCompCode" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" >
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAmount" runat="server" Checked='<%#Eval("isAmount")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewAmount" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ref1">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRef1" runat="server" Checked='<%#Eval("isRef1")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewRef1" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ref2">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRef2" runat="server" Checked='<%#Eval("isRef2")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewRef2" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RefName">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRefName" runat="server" Checked='<%#Eval("isRefName")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewRefName" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Payment date">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkPaymentdate" runat="server" Checked='<%#Eval("isPaymentdate")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewPaymentdate" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Refund">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRefund" runat="server" Checked='<%#Eval("isRefund")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewRefund" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Uploaded files">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkUploadFile" runat="server" Checked='<%#Eval("isUploadFile")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewUploadFile" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Spin">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSpin" runat="server" Checked='<%#Eval("isSpin")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewSpin" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="G/L">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkGL" runat="server" Checked='<%#Eval("isGL")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewGL" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update Unmatch">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkUnmatch" runat="server" Checked='<%#Eval("isUpdateUnmatched")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewUnmatch" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActive" runat="server" Checked='<%#Eval("isActive")%>' CommandArgument='<%#Eval("CauseID")%>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:CheckBox ID="NewActive" runat="server" />
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" />
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
