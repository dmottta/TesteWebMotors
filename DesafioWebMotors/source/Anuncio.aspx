<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Anuncio.aspx.cs" Inherits="Anuncio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ConteudoPrincipal" runat="Server">

    <h2>Anúncio</h2>
    <div class="divisor">
    </div>
    <asp:Label ID="lblErro" runat="server" ForeColor="Red"></asp:Label>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Marca:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMake" runat="server" Width="300px" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="DSMake" DataTextField="Name" DataValueField="Id" OnSelectedIndexChanged="ddlMake_SelectedIndexChanged" ValidationGroup="0">
                    <asp:ListItem Value="-1">-----</asp:ListItem>
                </asp:DropDownList>

                <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="ddlMake" CssClass="FonteTam14" ErrorMessage="*" Operator="NotEqual" ValidationGroup="0" ValueToCompare="-1"></asp:CompareValidator>

                <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Modelo:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlModel" runat="server" Width="300px" AutoPostBack="True" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged" ValidationGroup="0">
                    <asp:ListItem Value="-1">-----</asp:ListItem>
                </asp:DropDownList>

                <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="ddlModel" CssClass="FonteTam14" ErrorMessage="*" Operator="NotEqual" ValidationGroup="0" ValueToCompare="-1"></asp:CompareValidator>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Versão:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlVersion" runat="server" Width="400px" DataTextField="Name" DataValueField="Id" AppendDataBoundItems="True" ValidationGroup="0">
                    <asp:ListItem Value="-1">-----</asp:ListItem>
                </asp:DropDownList>

                <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="ddlVersion" CssClass="FonteTam14" ErrorMessage="*" Operator="NotEqual" ValidationGroup="0" ValueToCompare="-1"></asp:CompareValidator>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Ano:"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="tbAno" runat="server" ValidationGroup="0"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="tbDeh_Solicit_FilteredTextBoxExtender" runat="server"
                    Enabled="True" TargetControlID="tbAno" ValidChars="0123456789"></asp:FilteredTextBoxExtender>

                <asp:RequiredFieldValidator ID="tipoRequiredFieldValidator1" runat="server" ControlToValidate="tbAno" CssClass="FonteTam14" ErrorMessage="RequiredFieldValidator" ValidationGroup="0">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Km:"></asp:Label>
            </td>
            <td>

                <asp:TextBox ID="tbQuilometragem" runat="server" ValidationGroup="0"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                    Enabled="True" TargetControlID="tbQuilometragem" ValidChars="0123456789"></asp:FilteredTextBoxExtender>

                <asp:RequiredFieldValidator ID="tipoRequiredFieldValidator2" runat="server" ControlToValidate="tbQuilometragem" CssClass="FonteTam14" ErrorMessage="RequiredFieldValidator" ValidationGroup="0">*</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Observação:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbObservacao" runat="server" Height="100px" TextMode="MultiLine" Width="300px" ValidationGroup="0"></asp:TextBox>
                <asp:RequiredFieldValidator ID="tipoRequiredFieldValidator6" runat="server" ControlToValidate="tbObservacao" CssClass="FonteTam14" ErrorMessage="RequiredFieldValidator" ValidationGroup="0">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:ImageButton ID="btnGravar" runat="server" ImageUrl="~/Images/button_square_save.png" OnClick="btnGravar_Click" ToolTip="Grava o anúncio" ValidationGroup="0" />
                <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Images/Button-Cancel-icon_24.png" OnClick="btnCancelar_Click" ToolTip="Cancelar" />
                <asp:ImageButton ID="btnExcluir" runat="server" ImageUrl="~/Images/Button-Red-Delete-24.png" OnClick="btnExcluir_Click" ToolTip="Excluir o anúncio" />
                <asp:ConfirmButtonExtender ID="cbeExcluir" runat="server" ConfirmText="Confirma a exclusão?" Enabled="True" TargetControlID="btnExcluir"></asp:ConfirmButtonExtender>

            </td>
        </tr>
    </table>
    <br />
    <asp:ObjectDataSource ID="DSMake" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMake" TypeName="MakeBLL"></asp:ObjectDataSource>

    <asp:GridView ID="gvAnuncio" runat="server" CssClass="gridView8" DataKeyNames="ID" DataSourceID="DSAnuncio" OnSelectedIndexChanged="gvAnuncio_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
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
    <asp:Label ID="Label7" runat="server" Text="Configurações do BD em APP_Code\DAL\Dados.cs" Font-Size="10px"></asp:Label>
    <br />
    <br />
</asp:Content>

