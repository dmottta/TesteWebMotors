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

public partial class Modelo : System.Web.UI.Page
{    
    private int cod_Unidade;


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Modelo";

        //Recupera as variaveis da URL usando Query String
        cod_Unidade = Convert.ToInt32(Request.QueryString["Cod_Unidade"]);

        //Não rola a página no postback
        Page.MaintainScrollPositionOnPostBack = true;

    }

    //Inclui um novo responsável
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {        
        try
        {
        
        }
        catch (Exception ex)
        {   
            //throw;
        }
        

    }

    //Inclui o Documento para a Unidade
    protected void btnIncluir_Click1(object sender, EventArgs e)
    {
        if (gvUnidade.SelectedIndex < 0)
        {
            return;
        }

        AnuncioBLL.IncluirFacil(
            //Convert.ToInt32(ddlCod_Doc.SelectedValue), 
            //Convert.ToInt32(gvUnidade.SelectedDataKey["Cod_Unidade"])
            );
        gvDocUnidade.DataBind();
    }


    
}