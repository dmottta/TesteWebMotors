<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Modelo.aspx.cs" Inherits="Modelo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ConteudoPrincipal" runat="Server">

    <h2>responsável
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/button-add_24.png" OnClick="ImageButton1_Click" ToolTip="Inclui um novo ..." />
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/button_square_save.png" ToolTip="Gravar" CommandName="Update" />
        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/Button-Cancel-icon_24.png" ToolTip="Cancelar"  />
        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Zoom-icon_24.png" ToolTip="Pesquisar" />
        <asp:Image ID="imgPendente" runat="server" ImageUrl="~/Images/Alert-icon.png" />
        <asp:Image ID="imgConcluido" runat="server" ImageUrl="~/Images/Tick-icon.png" />
    </h2>
    <div class="divisor">
    </div>
    <asp:GridView ID="gvUnidade" runat="server" AutoGenerateColumns="False" CssClass="gridView8" DataKeyNames="Cod_Unidade" DataSourceID="DSUnidade">
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

            <asp:TemplateField HeaderText="Cód">
                <EditItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Cod_Unidade")%>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Cod_Unidade")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Responsável">
                <EditItemTemplate>
                    <asp:TextBox ID="Label3" runat="server" Text='<%# Bind("Nom_Unidade")%>' Width="300px"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Nom_Unidade")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="300px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Validade">
                <EditItemTemplate>
                    <asp:TextBox ID="lblValidade" runat="server" Text='<%# Eval("Dat_Validade","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                    <asp:CalendarExtender ID="tbDat_Validade_CalendarExtender" runat="server" Enabled="True" TargetControlID="lblValidade"></asp:CalendarExtender>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblValidade" runat="server" Text='<%# Eval("Dat_Validade","{0:dd/MM/yyyy}")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="60px" />
            </asp:TemplateField>




        </Columns>
        <SelectedRowStyle CssClass="SelectedRowStyle" />
    </asp:GridView>
    <asp:ObjectDataSource ID="DSUnidade" runat="server" SelectMethod="GetVencidos" TypeName="VersaoBLL">
    </asp:ObjectDataSource>

    <asp:Label ID="lblMensagem" runat="server"></asp:Label>

    <br />

    <h2>lista de documentos</h2>
    <div class="divisor"></div>
    <asp:Button ID="btnIncluir" runat="server" OnClick="btnIncluir_Click1" Text="Incluir" />
    <asp:DropDownList ID="ddlCod_Doc" runat="server" DataSourceID="DSDocumento" DataTextField="Nom_Doc" DataValueField="Cod_Doc" Width="200px">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="DSDocumento" runat="server" SelectMethod="GetDocumento" TypeName="DocumentoBLL"></asp:ObjectDataSource>
    <br />

    <asp:DropDownList ID="ddlDes_Permissao" runat="server" SelectedValue='<%# Bind("Des_Permissao") %>'>
        <asp:ListItem Value="R">Read</asp:ListItem>
        <asp:ListItem Value="W">Write</asp:ListItem>
    </asp:DropDownList>

    <asp:GridView ID="gvDocUnidade" runat="server" CssClass="gridView8" DataSourceID="DSDocUnidade" AutoGenerateColumns="False" DataKeyNames="cod_Doc">
        <Columns>

            <asp:TemplateField>
                <EditItemTemplate>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="btnDocUnidadeExcluir" runat="server" CommandName="Delete" ImageUrl="~/Images/delete_16.png" ToolTip="Excluir" ValidationGroup="0" />
                    <asp:ConfirmButtonExtender ID="cbeDocUnidadeExcluir" runat="server" ConfirmText="Confirma a exclusão?" Enabled="True" TargetControlID="btnDocUnidadeExcluir"></asp:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="40px" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Documento">
                <EditItemTemplate>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="Label3" runat="server" Text='<%# Bind("Nom_Doc")%>' NavigateUrl="~/source/Versao.aspx" ></asp:HyperLink>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="300px" />
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <asp:ObjectDataSource ID="DSDocUnidade" runat="server" SelectMethod="GetDocsDaUnidade" TypeName="DocUnidadeBLL" DeleteMethod="Excluir">
        <DeleteParameters>
            <asp:Parameter Name="cod_Doc" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="gvUnidade" Name="cod_Unidade" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <br />
</asp:Content>

