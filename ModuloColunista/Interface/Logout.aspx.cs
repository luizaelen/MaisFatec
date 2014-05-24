using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        Usuario usr = ((Usuario)Session["usuario"]);
        if (usr != null)
        {
            ChatNovo chat = new ChatNovo();
            chat.Disconnect(usr.IdUsuario);
        }
        */
        FormsAuthentication.SignOut();
        //Efetua o logout, desconectando o usuário.
        Response.Redirect("default.aspx");
        //Redireciona o usuário para a página "default.aspx".
    }
}//class