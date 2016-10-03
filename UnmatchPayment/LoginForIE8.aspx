<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForIE8.aspx.cs" Inherits="UnmatchPayment.LoginForIE8" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BAAC</title>
        <style type="text/css">
            h1 {
                font-weight: bold;
                color: black;
            }

            h3 {
                font-weight: bold;
                color: white;
            }
            .main-content {
                background: url("Images/bgforie2.png") no-repeat center;
                height: 500px;
            }
            .body {
                margin-top:7%;
                margin-left:35%;
            }
            .footer {
                background-color: yellow;
                font-size: 20px;
                color: red;
            }

    </style>
</head>
<body>
    <form id="form1" runat="server" style="text-align: center">
        <div class="main-content">
            <br />

            <h1>ระบบ e-Error payment</h1>
            <%--<h2>เข้าสู่ระบบ</h2>--%>
            <br />
            <div class="body">
                <table>
                    <tr>
                        <td style="text-align: right">รหัสพนักงาน &nbsp &nbsp
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtUserName" runat="server" Height="23px" MaxLength="7" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">รหัสผ่าน &nbsp &nbsp
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtPassword" type="password" runat="server" Height="22px" MaxLength="20" Width="250px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnLogin" runat="server" Text="เข้าสู่ระบบ" Height="30px" Width="101px" OnClick="btnLogin_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Label ID="lblLoginError" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
            <br />
            <br />
        </div>
        <div class="footer">
            เพื่อการแสดงผลที่ถูกต้องของระบบ
            แนะนำให้ใช้งานผ่านโปรแกรม CHROME BROWSER
            สามารถดาวน์โหลดและทำการติดโปรแกรมได้โดย <a href="http://xms2/it/?p=1612" target="_blank">คลิกที่นี่</a>
        </div>
    </form>
</body>
</html>
