using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "Page Load";
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMakeId.Text = DropDownList1.SelectedValue;

        TextBox1.Text += "\n" + "DropDownList1_SelectedIndexChanged";

    }



    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "DropDownList2_SelectedIndexChanged";
    }

    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "DropDownList1_DataBound";
    }

    protected void DropDownList2_DataBound(object sender, EventArgs e)
    {
        TextBox1.Text += "\n" + "DropDownList2_DataBound";
    }
}
