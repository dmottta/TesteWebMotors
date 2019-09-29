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



    protected void btnIncluir_Click(object sender, ImageClickEventArgs e)
    {
        AnuncioBLL.IncluirFacil(
            //Convert.ToInt32(ddlCod_Doc.SelectedValue),
            //Convert.ToInt32(gvAnucio.SelectedDataKey["Cod_Unidade"])
            );
        gvAnuncio.DataBind();
    }



    protected void ddlMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlMake_SelectedIndexChanged";

        tbMakeId.Text = ddlMake.SelectedValue;

        try
        {
            ddlModel.DataSource = ModelBLL.GetModel(Convert.ToInt32(ddlMake.SelectedValue));
            ddlModel.DataBind();
        }
        catch (Exception ex)
        {
            lblErro.Text = "Erro ao carregar lista de Modelos. " + ex.ToString();
        }

        TextBox2.Text = ModelBLL.GetModelStr(Convert.ToInt32(ddlMake.SelectedValue));
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TextBox1.Text = ddlMake.SelectedValue + "aaa";

        TextBox1.Text += "\n" + "ddlModel_SelectedIndexChanged";
        tbModelId.Text = ddlMake.SelectedValue;

        try
        {
            ddlVersion.DataSource = VersionBLL.GetVersion(Convert.ToInt32(ddlModel.SelectedValue));
            ddlVersion.DataBind();
        }
        catch (Exception ex)
        {
            lblErro.Text = "Erro ao carregar lista de Versões. " + ex.ToString();
        }

    }

    protected void ddlVersion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        ddlVersion.DataSource = VersionBLL.GetVersion(4);
        ddlVersion.DataBind();
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        tbModelId.Text = ddlModel.SelectedValue;

        TextBox1.Text += "\n" + "ImageButton5_Click";

        //ddlVersion.DataSource = VersionBLL.GetVersion(Convert.ToInt32(ddlModel.SelectedValue));
        //ddlVersion.DataBind();
    }



    protected void btnListarMake_Click(object sender, ImageClickEventArgs e)
    {
        ddlMake.DataSource = MakeBLL.GetMake();
        ddlMake.DataBind();
    }

    protected void ddlModel_DataBinding(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlModel_DataBinding";
    }

    protected void ddlModel_DataBound(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlModel_DataBound";
    }

    protected void ddlModel_Load(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlModel_Load";
        TextBox1.Text += "\n" + ddlModel.SelectedValue;
    }

    protected void ddlModel_Disposed(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlModel_Disposed";
    }

    protected void ddlModel_Init(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlModel_Init";
    }

    protected void ddlModel_PreRender(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlModel_PreRender";
    }

    protected void ddlModel_TextChanged(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlModel_TextChanged";
    }

    protected void ddlModel_Unload(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "ddlModel_Unload";
    }

    protected void btn5_Click(object sender, ImageClickEventArgs e)
    {
        gvMake.DataSource = MakeBLL.GetMake();
        gvMake.DataBind();
    }


    protected void btn4_Click(object sender, ImageClickEventArgs e)
    {
        gvModel.DataSource = ModelBLL.GetModel(Convert.ToInt32(gvMake.SelectedDataKey["ID"]));
        gvModel.DataBind();
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        gvVersion.DataSource = VersionBLL.GetVersion(Convert.ToInt32(gvModel.SelectedDataKey["ID"]));
        gvVersion.DataSource = VersionBLL.GetVersion(Convert.ToInt32(gvModel.SelectedDataKey["ID"]));
        gvVersion.DataBind();
    }
}