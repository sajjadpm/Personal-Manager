<%@ Page Title="" Language="C#" MasterPageFile="~/after signin/signin.master" AutoEventWireup="true" CodeBehind="Reminders.aspx.cs" Inherits="PersonalManager.after_signin.Reminders" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridLookup" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style8 {
            font-size: x-large;
        }
        .auto-style9 {
            font-size: large;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">

    <br />
    <br />
    <br />
    <dx:ASPxLabel ID="ASPxLabel2" runat="server" CssClass="auto-style8" Text="Get Reminders On Your Personal Data Through E-mail." Theme="iOS">
    </dx:ASPxLabel>
    <br />
    <br />
    <br />
    <br />
    <dx:ASPxLabel ID="ASPxLabel3" runat="server" CssClass="auto-style9" Text="Select Your Personal Document" Theme="iOS">
    </dx:ASPxLabel>
    <br />
    <br />
    <br />
        <dx:ASPxComboBox ID="cbo_Type" runat="server" ValueType="System.String">
        </dx:ASPxComboBox>
    <br />
        <dx:ASPxTextBox ID="txt_fullname" runat="server" Theme="MetropolisBlue" Width="170px" NullText="Full Name">
        </dx:ASPxTextBox>
        <br />
          <dx:ASPxDateEdit ID="DE_expdate" runat="server">
          </dx:ASPxDateEdit>
        <br />
        <dx:ASPxTextBox ID="txt_email" runat="server" NullText="Email address" Width="170px" Theme="MetropolisBlue">
        </dx:ASPxTextBox>
        <br />
        <dx:ASPxTextBox ID="txt_country" runat="server" NullText="Country" Theme="MetropolisBlue" Width="170px">
        </dx:ASPxTextBox>
    <br />
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Send" Theme="SoftOrange" OnClick="ASPxButton1_Click" >
        </dx:ASPxButton>
    <br />
        <br />
        <br />
    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Select Your Personal Bill Receipt" Theme="iOS">
    </dx:ASPxLabel>
    <br />
    <br />
    <br />
        <br />
        <dx:ASPxComboBox ID="cbo_bill" runat="server" ValueType="System.String">
        </dx:ASPxComboBox>
        <br />
        <dx:ASPxTextBox ID="txt_billamount" runat="server" Theme="MetropolisBlue" Width="170px" NullText="Bill Amount">
        </dx:ASPxTextBox>
        <br />
          <dx:ASPxDateEdit ID="DE_billexp" runat="server">
          </dx:ASPxDateEdit>
        <br />
        <dx:ASPxTextBox ID="txt_billemil" runat="server" NullText="Email address" Width="170px">
        </dx:ASPxTextBox>
        <br />
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Send" Theme="SoftOrange" OnClick="ASPxButton2_Click">
        </dx:ASPxButton>
        <br />
        <br />
    <br />


    <br />
    <br />
    <br />
    <br />


</div>
</asp:Content>
