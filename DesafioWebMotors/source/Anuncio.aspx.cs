using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Anuncio : System.Web.UI.Page
{
    private int cod_Anuncio;


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Desafio - Anúncio Web Motors";

        //Recupera as variaveis da URL usando Query String
        cod_Anuncio = Convert.ToInt32(Request.QueryString["Cod_Anuncio"]);

        //Não rola a página no postback
        Page.MaintainScrollPositionOnPostBack = true;

        lblErro.Text = "";
    }

    protected void btnIncluirFacil_Click(object sender, ImageClickEventArgs e)
    {
        AnuncioBLL.IncluirFacil();
        gvAnuncio.DataBind();
    }


    protected void LimparForm()
    {
        lblId.Text = "";
        ddlMake.SelectedValue = "-1";
        ddlModel.SelectedValue = "-1";
        ddlVersion.SelectedValue = "-1";
        tbAno.Text = "";
        tbQuilometragem.Text = "";
        tbObservacao.Text = "";
    }

    protected void AnuncioCarregar()
    {
        try
        {
            DataTable dt = AnuncioBLL.GetAnuncio((Int32)gvAnuncio.SelectedDataKey["ID"]);

            lblId.Text = dt.Rows[0]["ID"].ToString();
            ddlMake.SelectedValue = dt.Rows[0]["marca"].ToString();

            ModeloCarregar(Convert.ToInt32(ddlMake.SelectedValue));
            ddlModel.SelectedValue = dt.Rows[0]["modelo"].ToString();

            VersaoCarregar(Convert.ToInt32(ddlModel.SelectedValue));
            ddlVersion.SelectedValue = dt.Rows[0]["versao"].ToString();

            tbAno.Text = dt.Rows[0]["ano"].ToString();
            tbQuilometragem.Text = dt.Rows[0]["quilometragem"].ToString();
            tbObservacao.Text = dt.Rows[0]["observacao"].ToString();
        }
        catch (Exception ex)
        {
            lblErro.Text = "Erro ao carregar o anúncio. " + ex.ToString();
        }

    }

    protected void btnGravar_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            //Inclusão
            if (lblId.Text == "")
            {
                AnuncioBLL.Incluir(
                    ddlMake.SelectedValue,
                    ddlModel.SelectedValue,
                    ddlVersion.SelectedValue,
                    tbAno.Text,
                    tbQuilometragem.Text,
                    tbObservacao.Text
                );
            }

            //Alteração
            else
            {
                AnuncioBLL.Alterar(
                    Convert.ToInt32(lblId.Text),
                    ddlMake.SelectedValue,
                    ddlModel.SelectedValue,
                    ddlVersion.SelectedValue,
                    Convert.ToInt32(tbAno.Text),
                    Convert.ToInt32(tbQuilometragem.Text),
                    tbObservacao.Text
                );
            }
        }
        catch (Exception ex)
        {
            lblErro.Text = "Erro ao gravar o anúncio. " + ex.ToString();
        }


        gvAnuncio.DataBind();
        LimparForm();
    }

    protected void ModeloCarregar(int makeId)
    {
        try
        {
            ddlModel.Items.Clear();
            ddlModel.Items.Add(new ListItem("-----", "-1"));
            ddlModel.DataSource = ModelBLL.GetModel(makeId);
            ddlModel.DataBind();
        }
        catch (Exception ex)
        {
            lblErro.Text = "Erro ao carregar lista de Modelos. " + ex.ToString();
        }
    }


    protected void ddlMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        ModeloCarregar(Convert.ToInt32(ddlMake.SelectedValue));
    }

    protected void VersaoCarregar(int modelId)
    {
        try
        {
            ddlVersion.Items.Clear();
            ddlVersion.Items.Add(new ListItem("-----", "-1"));
            ddlVersion.DataSource = VersionBLL.GetVersion(modelId);
            ddlVersion.DataBind();
        }
        catch (Exception ex)
        {
            lblErro.Text = "Erro ao carregar lista de Versões. " + ex.ToString();
        }
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        VersaoCarregar(Convert.ToInt32(ddlModel.SelectedValue));
    }


    protected void gvAnuncio_SelectedIndexChanged(object sender, EventArgs e)
    {
        AnuncioCarregar();
    }

    protected void btnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        LimparForm();
    }

    protected void btnExcluir_Click(object sender, ImageClickEventArgs e)
    {
        if (lblId.Text == "")
        {
            return;
        }

        try
        {
            AnuncioBLL.Excluir(Convert.ToInt32(lblId.Text));
        }
        catch (Exception ex)
        {
            lblErro.Text = "Erro ao excluir o anúncio. " + ex.ToString();
        }
        
        
        gvAnuncio.DataBind();
        LimparForm();
    }
}