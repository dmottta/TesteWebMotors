<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoPrincipal" runat="Server">
    <h1>Bem-vindo ao Desafio - Anúncio Web Motors</h1>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>

                        <asp:Label ID="Label1" runat="server" Text="Marca:"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" DataSourceID="DSMake" DataTextField="Name" DataValueField="Id" OnDataBound="DropDownList1_DataBound" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>

                        <asp:Label ID="lblMakeId" runat="server"></asp:Label>

                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Modelo:"></asp:Label></td>
                    <td>

                        <asp:DropDownList ID="DropDownList2" runat="server" Width="200px" DataTextField="Name" DataValueField="Id" DataSourceID="DSModel" OnDataBound="DropDownList2_DataBound" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                        <asp:Label ID="lblModelId" runat="server"></asp:Label>

                    </td>


                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Versão:"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server" Width="200px" DataTextField="Name" DataValueField="Id" DataSourceID="DSVersao" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"></asp:DropDownList>
                        <asp:Label ID="lblVersionId" runat="server"></asp:Label></td>

                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:ObjectDataSource ID="DSMake" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMake" TypeName="MakeBLL"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="DSModel" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetModel" TypeName="ModelBLL">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblMakeId" Name="makeId" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:ObjectDataSource ID="DSVersao" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetVersion" TypeName="VersionBLL">
        <SelectParameters>
            <asp:ControlParameter ControlID="lblModelId" Name="modelId" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:TextBox ID="TextBox1" runat="server" Height="200px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    <br />

    <br />


</asp:Content>

