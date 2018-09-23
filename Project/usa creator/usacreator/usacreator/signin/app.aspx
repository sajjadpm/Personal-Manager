<%@ Page Title="" Language="C#" MasterPageFile="~/signin/main.Master" AutoEventWireup="true" CodeBehind="app.aspx.cs" Inherits="usacreator.signin.app" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 513px;
            position: absolute;
            margin-top: -192px;
        }
        .auto-style2 {
            width: 513px;
            position: absolute;
            margin-top: -192px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            width: 513px;
            position: absolute;
            margin-top: -192px;
            height: 20px;
        }
        .auto-style5 {
            height: 20px;
        }
    .auto-style6 {
        width: 513px;
        position: absolute;
        margin-top: -192px;
        height: 42px;
    }
    .auto-style7 {
        height: 42px;
    }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
       <br />
        <table class="nav-justified">
            <tr>
                <td class="auto-style6">
                    <asp:FileUpload ID="Fileupload1" runat="server" />
                    <div class="button1"> <dx:ASPxButton ID="Button1" runat="server" OnClick="Button1_Click1" Text="Upload">
                    </dx:ASPxButton></div>
                    
                <asp:Label CssClass="label" ID="Label1" runat="server" Font-Size="Medium"></asp:Label>     
                    <br />
                </td>
                <td class="auto-style7">
                    </td>
            </tr>
            <tr>
               
                <td class="auto-style4">
                    
                    &nbsp;</td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style1">
                   <div class="grid"> 
                       
                       <dx:ASPxGridView ID="ASPxGridView1" runat="server" DataSourceID="SqlDataSource1" EnableTheming="True" Theme="PlasticBlue" AutoGenerateColumns="False" KeyFieldName="id">
                       <Columns>
                           <dx:GridViewCommandColumn VisibleIndex="0">
                               <EditButton Visible="True">
                               </EditButton>
                               <DeleteButton Visible="True">
                               </DeleteButton>
                               <ClearFilterButton Visible="True">
                               </ClearFilterButton>
                           </dx:GridViewCommandColumn>
                           <dx:GridViewDataTextColumn FieldName="id" ReadOnly="True" VisibleIndex="1">
                               <EditFormSettings Visible="False" />
                           </dx:GridViewDataTextColumn>
                           <dx:GridViewDataTextColumn FieldName="cs" VisibleIndex="2">
                           </dx:GridViewDataTextColumn>
                           <dx:GridViewDataTextColumn FieldName="ec" VisibleIndex="3">
                           </dx:GridViewDataTextColumn>
                           <dx:GridViewDataTextColumn FieldName="bm" VisibleIndex="4">
                           </dx:GridViewDataTextColumn>
                           <dx:GridViewDataTextColumn FieldName="bt" VisibleIndex="5">
                           </dx:GridViewDataTextColumn>
                           <dx:GridViewDataTextColumn FieldName="eee" VisibleIndex="6">
                           </dx:GridViewDataTextColumn>
                           <dx:GridViewDataTextColumn FieldName="ce" VisibleIndex="7">
                           </dx:GridViewDataTextColumn>
                       </Columns>
                       <SettingsPager Visible="False">
                       </SettingsPager>
                           <Settings ShowFilterRow="True" />
                    </dx:ASPxGridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:usaConnectionString %>" SelectCommand="SELECT * FROM [stream]" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [stream] WHERE [id] = @original_id AND (([cs] = @original_cs) OR ([cs] IS NULL AND @original_cs IS NULL)) AND (([ec] = @original_ec) OR ([ec] IS NULL AND @original_ec IS NULL)) AND (([bm] = @original_bm) OR ([bm] IS NULL AND @original_bm IS NULL)) AND (([bt] = @original_bt) OR ([bt] IS NULL AND @original_bt IS NULL)) AND (([eee] = @original_eee) OR ([eee] IS NULL AND @original_eee IS NULL)) AND (([ce] = @original_ce) OR ([ce] IS NULL AND @original_ce IS NULL))" InsertCommand="INSERT INTO [stream] ([cs], [ec], [bm], [bt], [eee], [ce]) VALUES (@cs, @ec, @bm, @bt, @eee, @ce)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [stream] SET [cs] = @cs, [ec] = @ec, [bm] = @bm, [bt] = @bt, [eee] = @eee, [ce] = @ce WHERE [id] = @original_id AND (([cs] = @original_cs) OR ([cs] IS NULL AND @original_cs IS NULL)) AND (([ec] = @original_ec) OR ([ec] IS NULL AND @original_ec IS NULL)) AND (([bm] = @original_bm) OR ([bm] IS NULL AND @original_bm IS NULL)) AND (([bt] = @original_bt) OR ([bt] IS NULL AND @original_bt IS NULL)) AND (([eee] = @original_eee) OR ([eee] IS NULL AND @original_eee IS NULL)) AND (([ce] = @original_ce) OR ([ce] IS NULL AND @original_ce IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_id" Type="Int16" />
                            <asp:Parameter Name="original_cs" Type="String" />
                            <asp:Parameter Name="original_ec" Type="String" />
                            <asp:Parameter Name="original_bm" Type="String" />
                            <asp:Parameter Name="original_bt" Type="String" />
                            <asp:Parameter Name="original_eee" Type="String" />
                            <asp:Parameter Name="original_ce" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="cs" Type="String" />
                            <asp:Parameter Name="ec" Type="String" />
                            <asp:Parameter Name="bm" Type="String" />
                            <asp:Parameter Name="bt" Type="String" />
                            <asp:Parameter Name="eee" Type="String" />
                            <asp:Parameter Name="ce" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="cs" Type="String" />
                            <asp:Parameter Name="ec" Type="String" />
                            <asp:Parameter Name="bm" Type="String" />
                            <asp:Parameter Name="bt" Type="String" />
                            <asp:Parameter Name="eee" Type="String" />
                            <asp:Parameter Name="ce" Type="String" />
                            <asp:Parameter Name="original_id" Type="Int16" />
                            <asp:Parameter Name="original_cs" Type="String" />
                            <asp:Parameter Name="original_ec" Type="String" />
                            <asp:Parameter Name="original_bm" Type="String" />
                            <asp:Parameter Name="original_bt" Type="String" />
                            <asp:Parameter Name="original_eee" Type="String" />
                            <asp:Parameter Name="original_ce" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                   
                   </div>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />

    
     </asp:Content>
