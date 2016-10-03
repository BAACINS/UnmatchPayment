<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UnmatchPayment.Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>BAAC</title>
    <link href="CSS/Login_Style.css" rel="stylesheet" />
</head>
<body>
    <div class="wrapper">
        <div class="container">
            <h1>ระบบ E-Error Payment</h1>


            <form class="form" runat="server">
                <input id="username" type="text" placeholder="Username" runat="server" maxlength="7" />
                <input id="password" type="password" placeholder="Password" runat="server" maxlength="20" />
                <button type="submit" id="login-button">Login</button>
                <asp:Button ID="btnLogin" runat="server" Text="" Style="display: none;" OnClick="btnLogin_Click" />
                <br />
                <asp:Label ID="lblloginError" ForeColor="Red" runat="server" Text=""></asp:Label>
                
            </form>
        </div>


        <ul class="bg-bubbles">
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
        </ul>


    </div>
            <div class="logoContainer">
            <table style="width:300px;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="เบราว์เซอร์ที่รองรับ" ForeColor="Black"></asp:Label></td>
                    <td>
                        <img src="Images/internet_explorer_logo.png" style="width: 20px;" />
                    </td>
                    <td>
                        <img src="Images/google_chrome_logo.png" style="width: 20px;" />
                    </td>
                    <td>
                        <img src="Images/Mozilla_firefox_logo.png" style="width: 20px;" />
                    </td>
                    <td>
                        <img src="Images/safari_logo.png" style="width: 20px;" />
                    </td>

                </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="10+" ForeColor="Black"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="22+" ForeColor="Black"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="17+" ForeColor="Black"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="5+" ForeColor="Black"></asp:Label></td>
                </tr>
            </table>

        </div>
    
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script type="text/javascript">
        function OnSuccess() {
            alert('ss');
            event.preventDefault();

            $('form').fadeOut(1500);
            $('.wrapper').addClass('form-success');
        }
        function OnLogin() {
            //alert('login');
        }

        $("#login-button").click(function (event) {

            var userName = document.getElementById('username').value;
            var passWord = document.getElementById('password').value;
            document.getElementById('<%= btnLogin.ClientID %>').click();

            event.preventDefault();

            $('form').fadeOut(500);
            $('.wrapper').addClass('form-success');
        });
    </script>
</body>
</html>
