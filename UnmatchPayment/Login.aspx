<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UnmatchPayment.Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="wrapper">
        <div class="container">
            <h1>ระบบสิทธิประโยชน์โครงการทวีสุข</h1>
            

            <form class="form" runat="server">
                <input id="username" type="text" placeholder="Username" runat="server" maxlength="7"/>
                <input id="password" type="password" placeholder="Password" runat="server" maxlength="20"/>
                <button type="submit" id="login-button" >Login</button>
                <asp:Button ID="btnLogin" runat="server" Text="" style="display: none;" />
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
