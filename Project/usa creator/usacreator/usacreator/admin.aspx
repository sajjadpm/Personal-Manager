<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="usacreator.admin" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="admin_themes/css/style.css" rel="stylesheet" />
    <script src="admin_themes/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".username").focus(function () {
                $(".user-icon").css("left", "-48px");
            });
            $(".username").blur(function () {
                $(".user-icon").css("left", "0px");
            });

            $(".password").focus(function () {
                $(".pass-icon").css("left", "-48px");
            });
            $(".password").blur(function () {
                $(".pass-icon").css("left", "0px");
            });
        });
</script>
</head>
<body>
    <!--WRAPPER-->
<div id="wrapper">

	<!--SLIDE-IN ICONS-->
    <div class="user-icon"></div>
    <div class="pass-icon"></div>
    <!--END SLIDE-IN ICONS-->

<!--LOGIN FORM-->

<form id="form1" class="login-form" runat="server">
    
	<!--HEADER-->
    <div class="header">
    <!--TITLE--><div class="adn"><h1>Admin Login</h1></div><!--END TITLE-->
    <!--DESCRIPTION--><span><div class="adn1"><h4>Fill out Username & Password to login.</h4></div></span><!--END DESCRIPTION-->
    </div>
    <!--END HEADER-->
	
	<!--CONTENT-->
    <div class="content">
	<!--USERNAME-->
        <asp:TextBox ID="username" CssClass="input username" TextMode="SingleLine"   runat="server"></asp:TextBox><!--END USERNAME-->
    <!--PASSWORD-->
        <asp:TextBox ID="password" CssClass="input password"  TextMode="Password"  runat="server"></asp:TextBox><!--END PASSWORD-->
    </div>
    <!--END CONTENT-->
    
    <!--FOOTER-->
    <div class="footer">
    <!--LOGIN BUTTON-->
        <asp:Button ID="submit" runat="server" CssClass="button" Text="Login" OnClick="submit_Click" /><!--END LOGIN BUTTON-->
   
    </div>
    <!--END FOOTER-->

</form>
<!--END LOGIN FORM-->

</div>
<!--END WRAPPER-->

<!--GRADIENT--><div class="gradient">
        
    </div><!--END GRADIENT-->
    <dx:ASPxHyperLink ID="ASPxHyperLink2" CssClass="pass" runat="server" NavigateUrl="~/pass.aspx" Text="Forget password" Theme="Office2003Blue" />
</body>
</html>
