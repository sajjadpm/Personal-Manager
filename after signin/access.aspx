<%@ Page Title="" Language="C#" MasterPageFile="~/after signin/signin.master" AutoEventWireup="true" CodeFile="access.aspx.cs" Inherits="after_signin_access" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxFileManager" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style8 {
            font-size: x-large;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">


    <br />
    <br />
    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Store Your Data" Theme="iOS" CssClass="auto-style8">
    </dx:ASPxLabel>
    <br />
    <br />
        <input runat="server" ID="myfile" type="file" multiple="multiple" 
                  class="fileupload" size="100"></input>
        <dx:ASPxButton ID="Btn_Fileupload" runat="server" OnClick="Btn_Fileupload_Click" Text="Upload">
        </dx:ASPxButton>
        <br />
    <br />
    <br />
        <br />
        <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />


</div></asp:Content>

