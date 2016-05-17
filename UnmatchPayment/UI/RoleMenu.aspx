<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RoleMenu.aspx.cs" Inherits="UnmatchPayment.UI.RoleMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<p>
        <h1>จัดการสิทธิ์การเข้าเมนู</h1>
    </p>

    <p class="underLine"></p>
    <div>
    <table width="100%" >  
        <tr>
            <td>
                สิทธิ์การใช้งาน : &nbsp; <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" CssClass="dropDownList"></asp:DropDownList>
                
            </td>
        </tr>      
        <tr>
            <td><asp:ListBox ID="lstLeftRoleMenu" runat="server" Height="310px" Width="384px"></asp:ListBox></td>
            <td>
                <table>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="bntAllRight" runat="server" Text=">>" CssClass="button" Width="30px" OnClick="bntAllRight_Click"/></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="bntRight" runat="server" Text=">" OnClick="bntRight_Click" CssClass="button" Width="30px" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnLeft" runat="server" Text="<" OnClick="btnLeft_Click" CssClass="button" Width="30px"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnAllLeft" runat="server" Text="<<"  CssClass="button" Width="30px" OnClick="btnAllLeft_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                
            </td>
            <td><asp:ListBox ID="lstRightRoleMenu" runat="server" Height="310px" Width="384px"></asp:ListBox></td>
        </tr>
           
    </table>
   <table>
                <tr>
   
             <td><asp:Button ID="btnSave" runat="server" Text="บันทึก" OnClick="btnSave_Click" CssClass="button" /></td>
            
            <td><asp:Button ID="btnCancel" runat="server" Text="ยกเลิก" OnClick="btnCancel_Click" CssClass="button" /></td>
        </tr>

    </table>
  </div>
  <p class="underLine"></p>

</asp:Content>
