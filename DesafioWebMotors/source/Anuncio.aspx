﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Anuncio.aspx.cs" Inherits="Anuncio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ConteudoPrincipal" runat="Server">

    <h2>Anúncio
        <asp:ImageButton ID="btnIncluir" runat="server" ImageUrl="~/Images/button-add_24.png" OnClick="btnIncluir_Click" ToolTip="Inclui um novo anúncio" />

    </h2>
    <div class="divisor">
    </div>
    <asp:Label ID="lblErro" runat="server" ForeColor="Red"></asp:Label>
    <asp:GridView ID="gvAnuncio" runat="server" CssClass="gridView8" DataKeyNames="ID" DataSourceID="DSAnuncio">
        <Columns>

            <asp:CommandField ShowSelectButton="True" />

            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:ImageButton ID="btnRespAlterar" runat="server" CommandName="Update" ImageUrl="~/Images/Tick-icon_16.png" ToolTip="Gravar" ValidationGroup="0" />
                    <asp:ImageButton ID="btnRespCancelar" runat="server" CommandName="Cancel" ImageUrl="~/Images/Button-Cancel-icon_16.png" ToolTip="Cancelar" ValidationGroup="0" />
                </EditItemTemplate>

                <ItemTemplate>
                    <asp:ImageButton ID="btnRespAnexoEditar" runat="server" CommandName="Edit" ImageUrl="~/Images/lapis_16.png" ToolTip="Editar" ValidationGroup="0" />
                    <asp:ImageButton ID="btnRespAnexoExcluir" runat="server" CommandName="Delete" ImageUrl="~/Images/delete_16.png" ToolTip="Excluir" ValidationGroup="0" />
                    <asp:ConfirmButtonExtender ID="cbeAnexoExcluir" runat="server" ConfirmText="Confirma a exclusão?" Enabled="True" TargetControlID="btnRespAnexoExcluir"></asp:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>



            <%--  <asp:TemplateField HeaderText="Validade">
                <EditItemTemplate>
                    <asp:TextBox ID="lblValidade" runat="server" Text='<%# Eval("Dat_Validade","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                    <asp:CalendarExtender ID="tbDat_Validade_CalendarExtender" runat="server" Enabled="True" TargetControlID="lblValidade"></asp:CalendarExtender>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblValidade" runat="server" Text='<%# Eval("Dat_Validade","{0:dd/MM/yyyy}")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px" />
            </asp:TemplateField>--%>
        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>
    <asp:ObjectDataSource ID="DSAnuncio" runat="server" SelectMethod="GetAnuncio" TypeName="AnuncioBLL" DeleteMethod="Excluir" UpdateMethod="Alterar">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
            <asp:Parameter Name="marca" Type="String" />
            <asp:Parameter Name="modelo" Type="String" />
            <asp:Parameter Name="versao" Type="String" />
            <asp:Parameter Name="ano" Type="Int32" />
            <asp:Parameter Name="quilometragem" Type="Int32" />
            <asp:Parameter Name="observacao" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <asp:ImageButton ID="btnListarMake" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Listar Make" OnClick="btnListarMake_Click" />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Make:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMake" runat="server" Width="300px" AppendDataBoundItems="True" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged" AutoPostBack="True" DataSourceID="DSMake">
                    <asp:ListItem Value="-1">-----</asp:ListItem>
                </asp:DropDownList>

                <asp:ImageButton ID="btn01" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" />
                <asp:TextBox ID="tbMakeId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Model:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModel" runat="server" Width="300px" AutoPostBack="True" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged" OnDataBinding="ddlModel_DataBinding" OnDataBound="ddlModel_DataBound" OnDisposed="ddlModel_Disposed" OnInit="ddlModel_Init" OnLoad="ddlModel_Load" OnPreRender="ddlModel_PreRender" OnTextChanged="ddlModel_TextChanged" OnUnload="ddlModel_Unload">
                    <asp:ListItem Value="-1">-----</asp:ListItem>
                </asp:DropDownList>

                <asp:ImageButton ID="btn02" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" OnClick="ImageButton5_Click" />
                <asp:TextBox ID="tbModelId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Version:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlVersion" runat="server" Width="300px" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlVersion_SelectedIndexChanged">
                    <asp:ListItem Value="-1">-----</asp:ListItem>
                </asp:DropDownList>

                <asp:ImageButton ID="btn03" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" OnClick="ImageButton4_Click" />
                <asp:TextBox ID="tbVersionId" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>


    <br />

    <asp:ObjectDataSource ID="DSMake" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMake" TypeName="MakeBLL"></asp:ObjectDataSource>
    <asp:TextBox ID="TextBox1" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    <br />
    <br />
    <asp:TextBox ID="TextBox2" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    <br />
    <br />
    <h1>Make<asp:ImageButton ID="btn5" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" OnClick="btn5_Click" />
    </h1>
    <asp:GridView ID="gvMake" runat="server" CssClass="gridView8" DataKeyNames="ID">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>

    <br />
    <h1>Model<asp:ImageButton ID="btn4" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" OnClick="btn4_Click" />
    </h1>
    <asp:GridView ID="gvModel" runat="server" CssClass="gridView8" DataKeyNames="ID">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>

    <br />
    <h1>Version<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" OnClick="ImageButton1_Click" />
    </h1>
    <asp:GridView ID="gvVersion" runat="server" CssClass="gridView8" DataKeyNames="ID">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>

    <br />
</asp:Content>

