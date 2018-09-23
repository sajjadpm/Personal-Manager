<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PersonalManager.Login" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 598px;
        }
        .auto-style5 {
        height: 23px;
    }
        .auto-style6 {
            width: 598px;
            height: 23px;
        }
        </style>
    <link href="styles/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" Runat="Server">
    <div class="container" id="contentplaceholder1">
   
   
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td rowspan="5">
                    <br />
                  <h5 class="user">
                    
                       User Name
                  </h5>
                    <h5 class="pass">
                        Password
                    </h5>

                      <dx:ASPxTextBox ID="username" runat="server" Theme="MetropolisBlue" Width="220px">
                    </dx:ASPxTextBox>
                    <br />
                    <dx:ASPxTextBox ID="pass" runat="server" Theme="MetropolisBlue" Width="220px" NullText="Password" Password="True">
                    </dx:ASPxTextBox>
                    <br />
                    <br />
                    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Sign In" Theme="SoftOrange" OnClick="ASPxButton1_Click">
                    </dx:ASPxButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"><dx:ASPxLabel ID="label1" runat="server" style="font-size: x-large" Text="Manage your personal data" Theme="iOS">
</dx:ASPxLabel>

                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                
                <dx:ASPxLabel ID="label2" runat="server" style="font-size: x-large" Text="and get reminders on the go." Theme="iOS">
                </dx:ASPxLabel>

                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3" rowspan="4">
                    <dx:ASPxImage ID="ASPxImage4" CssClass="img" runat="server" Height="43px" ImageUrl="~/images/dsgf.png" ShowLoadingImage="true" Width="68px">
                    </dx:ASPxImage>


                <dx:ASPxLabel ID="label3" runat="server" Text="Store and access your data electronically" Theme="iOS" style="font-size: medium">
                </dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" style="font-size: medium; font-weight: 700" Text="Sign Up" Theme="Moderno">
                    </dx:ASPxLabel>
                </td>
            </tr>
            <tr>
                <td> 
                   
                    
                    
                    <dx:ASPxTextBox ID="Txt_Name" CssClass="" runat="server" Width="220px" NullText="Name" Theme="MetropolisBlue" >
                    </dx:ASPxTextBox>
                   
                    
                    
                </td>
            </tr>
            <tr>
                <td >
                    
                    <dx:ASPxTextBox ID="Txt_Email" runat="server" CssClass="" Width="220px" Theme="MetropolisBlue" NullText="Email Address">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" rowspan="2"> <dx:ASPxImage ID="ASPxImage2" CssClass="img" runat="server" Height="49px" ImageUrl="~/images/dsf.png" ShowLoadingImage="true" Width="59px">
                </dx:ASPxImage>
               
    &nbsp;<dx:ASPxLabel ID="label4" runat="server" style="font-weight: 700; font-size: medium" Text="Get reminders on the go." Theme="iOS">
    </dx:ASPxLabel>


   
                </td>
                <td >
                   
                    
                    
                    <dx:ASPxTextBox ID="Txt_passowrd" cssclass="" runat="server" Theme="MetropolisBlue" Width="220px" NullText="Password" >
                    </dx:ASPxTextBox>
                    
                    
                    
                </td>
            </tr>
            <tr>
                <td>
                    
                    <dx:ASPxTextBox ID="txtConfimpassword" runat="server" style="float:left;" NullText="Confirm Password" Theme="MetropolisBlue" Width="220px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" rowspan="3">
                    
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pmanagercnn%>" SelectCommand="SELECT * FROM [Logindetails]"></asp:SqlDataSource>
                    
                &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <dx:ASPxButton ID="Btn_SignUp" CssClass="" runat="server" Text="Sign Up" Theme="Moderno" OnClick="Btn_SignUp_Click" >
                    </dx:ASPxButton>
                    
                </td>
            </tr>
            <tr>
                <td> </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
             
                    </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
             
                    &nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
   
  
</div>

</asp:Content>
