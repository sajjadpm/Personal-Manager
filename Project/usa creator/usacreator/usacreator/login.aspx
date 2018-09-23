<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="usacreator.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 500px;
        }
        .auto-style3 {
            width: 500px;
            height: 22px;
        }
        .auto-style4 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">






<div id="ourServices"> 	
<div class="container">
    
    <table class="auto-style1">
        <tr>
            <td class="auto-style2"><h2>Sign Up</h2></td>
            <td><h2>Sign In</h2></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <div class="Label1"><p>Name</p></div><asp:TextBox ID="TextBox1" runat="server" CssClass="txt1" Height="22px" Width="200px"></asp:TextBox>
            </td>
            <td>
               <div class="Label5"><p> Username</p></div><asp:TextBox ID="TextBox5" runat="server" Height="22px" Width="200px" EnableTheming="True" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
              <div class="Label2">  <p>Email Address</p></div><asp:TextBox ID="TextBox2" runat="server" Height="22px" CssClass="txt2" Width="200px"></asp:TextBox>
            </td>
            <td>
                
               <div class="Label6" ><p>Password</p></div> <asp:TextBox ID="TextBox6" runat="server" Height="22px" Width="200px" CssClass="textbox" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
               <div class="Label3"> <p>Password</p></div><asp:TextBox ID="TextBox3" runat="server" Height="22px" CssClass="txt3" Width="200px"  TextMode="Password">Password</asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" cssclass="btn button" runat="server" Text="SIGN IN" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
               <div class="Label4">  <p>Confirm Password</p></div> <asp:TextBox ID="TextBox4" runat="server" Height="22px" CssClass="txt4" Width="200px" TextMode="Password">Confirm Password</asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
           <div style=" position: absolute;left: 360px;"><asp:Button ID="Button3" runat="server" CssClass="btn-success" Text="SIGN UP" /></div>
            </td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style4"></td>
        </tr>
        <tr>
            <td class="auto-style2">
                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    
    <br />
    <br />
    <br />
    
    <br />
    <br />
    </div>
    </div>
    
    </asp:Content>
