<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pass.aspx.cs" Inherits="usacreator.pass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="admin_themes/css/style.css" rel="stylesheet" />
    <script src="admin_themes/jquery.min.js"></script>

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
    <!--TITLE--><h2>Password Recovery</h2><!--END TITLE-->
    <!--DESCRIPTION--><span class="abc"><h4>Enter Email Address</h4></span><!--END DESCRIPTION-->
    </div>
    <!--END HEADER-->
	
	<!--CONTENT-->
    <div class="content">
	<!--USERNAME-->
        <asp:TextBox ID="username" CssClass="input username" TextMode="SingleLine"   runat="server"></asp:TextBox><!--END USERNAME-->
    
    </div>
    <!--END CONTENT-->
    
    <!--FOOTER-->
    <div class="footer">
    <!--LOGIN BUTTON-->
        <asp:Button ID="submit" runat="server" CssClass="button" Text="Submit" /><!--END LOGIN BUTTON-->
   
    </div>
    <!--END FOOTER-->

</form>
<!--END LOGIN FORM-->

</div>
<!--END WRAPPER-->

<!--GRADIENT--><div class="gradient">
        
    </div><!--END GRADIENT-->
   
</body>
</html>
