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



    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

        TextBox1.Text += ddlMake.SelectedValue;
        //TextBox1.Text += ModelBLL.GetModelStr(2);

    }

    protected void ddlMake_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text += ddlMake.SelectedValue;

        try
        {
            ddlModel.DataSource = ModelBLL.GetModel(Convert.ToInt32(ddlMake.SelectedValue));            
            ddlModel.DataBind();
        }
        catch (Exception ex)
        {            
            lblErro.Text = "Erro ao carregar lista de Modelos. " + ex.ToString();
        }
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        //TextBox1.Text = ddlMake.SelectedValue + "aaa";

        TextBox1.Text += "ddlModel_SelectedIndexChanged";


        //try
        //{
        //    ddlVersion.DataSource = VersionBLL.GetVersion(Convert.ToInt32(ddlModel.SelectedValue));
        //    ddlVersion.DataBind();
        //}
        //catch (Exception ex)
        //{            
        //    lblErro.Text = "Erro ao carregar lista de Versões. " + ex.ToString();
        //}

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
        ddlModel.DataSource = ModelBLL.GetModel(3);
        ddlModel.DataBind();
    }
}