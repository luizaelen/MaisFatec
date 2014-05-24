using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregarGrid();
    }

    public void CarregarGrid()
    {
        UsuarioBD usr = new UsuarioBD();
        DataSet dsUsuarios = usr.UsuarioAdm();
        int qtd = dsUsuarios.Tables[0].Rows.Count;
        if (qtd > 0)
        {

            grvUsuario.DataSource = dsUsuarios.Tables[0].DefaultView;
            grvUsuario.DataBind();
        }
        else
        {
            grvUsuario.Visible = false;
        }

    }

    protected void grdItens_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvUsuario.PageIndex = e.NewPageIndex;

    }


}//class