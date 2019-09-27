<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Anuncio.aspx.cs" Inherits="Anuncio" %>

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

    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" OnClick="ImageButton3_Click" />
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Make:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMake" runat="server" Width="300px" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="DSMake" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged">
                    <asp:ListItem Value="-1">-----</asp:ListItem>
                </asp:DropDownList>

    <asp:ImageButton ID="btn01" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" />
                <asp:TextBox ID="tb01" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Model:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModel" runat="server" Width="300px" AutoPostBack="True" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                    <asp:ListItem Value="-1">-----</asp:ListItem>
                </asp:DropDownList>

    <asp:ImageButton ID="btn02" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" OnClick="ImageButton5_Click" />
                <asp:TextBox ID="tb02" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="tb03" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>


    <br />
    <asp:ObjectDataSource ID="DSAnuncio0" runat="server" SelectMethod="GetAnuncio" TypeName="AnuncioBLL" DeleteMethod="Excluir" UpdateMethod="Alterar">
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

    <asp:ObjectDataSource ID="DSMake" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMake" TypeName="MakeBLL"></asp:ObjectDataSource>
    <asp:TextBox ID="TextBox1" runat="server" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
    <br />
    <br />

    <br />
</asp:Content>

