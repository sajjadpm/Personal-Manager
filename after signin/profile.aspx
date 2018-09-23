<%@ Page Title="" Language="C#" MasterPageFile="~/after signin/signin.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="after_signin_profile" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.2, Version=13.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">


        <div class="">

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

            <dx:ASPxGridView ID="Grd_Store1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlStore" Width="50%">
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="filename" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Download"  Width="15%"  VisibleIndex="8">
                          <DataItemTemplate>
                                  <asp:ImageButton ID="DOCGridDownload"  runat="server"  ImageUrl="~/images/button.png"  CssClass="addimgbtn"
                                  CommandArgument='<%# Bind("filename") %>'  OnClick="BtnDOCDownload_Click"  />
                          </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="Delete"  Width="10%" 
                       VisibleIndex="8">
                          <DataItemTemplate>
                                 <asp:ImageButton ID="DOCGriddel"  runat="server"  ImageUrl="~/images/button_cancel.png"  CssClass="addimgbtn"
                                  CommandArgument='<%# Bind("ID") %>' OnClientClick="javascript:return deleteSystem();" OnClick="BtnDOCDelete_Click"  />
                          </DataItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                          </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlStore" runat="server" ConnectionString="<%$ ConnectionStrings:pmanagercnn %>" SelectCommand="SELECT [ID],[filename] FROM [Storage]"></asp:SqlDataSource>
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
            <br />
        </div>


</div>


</asp:Content>

