using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);

        try
        {
            CarregaMaster(objUsuario);
            StatusChat(objUsuario);
        }
        catch (Exception)
        {

            Response.Redirect("Logout.aspx");
        }
    }

    private void StatusChat(Usuario usr)
    {
        bool conectado = false;
        ChatNovo chat = new ChatNovo();
        List<ChatUsers> lst = chat.Lista();
        foreach (ChatUsers element in lst)
        {
            if (element.userId == usr.IdUsuario)
            {
                conectado = true;
            }
        }

        if (conectado)
        {
            imgStatusChat.ImageUrl = "~/img/chatOn.png";
        }
        else
        {
            imgStatusChat.ImageUrl = "~/img/chatOff.png";
        }

    }

    private void ConectaChat(Usuario usr)
    {
        ChatNovo chat = new ChatNovo();
        chat.addUser(usr.PerfilC.NomePerfil, usr.IdUsuario);
        StatusChat(usr);

    }

    private void DesconectarChat(Usuario usr)
    {
        ChatNovo chat = new ChatNovo();
        chat.Disconnect(usr.IdUsuario);
        StatusChat(usr);

    }

    private void CarregaMaster(Usuario usr)
    {
        
        
        imgBUPerfil.ImageUrl = usr.PerfilC.FotoPerfil;

        //dados básicos
        lblNomeUsr.Text = usr.PerfilC.NomePerfil + " "+ usr.PerfilC.SobrenomePerfil;

        hplPerfil.NavigateUrl = "~/Perfil/"+usr.PerfilC.UrlPerfil;
        
    }

    protected void lbtConectarChat_Click(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);
        ConectaChat(objUsuario);
    }
    protected void lbtDesconectarChat_Click(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);
        DesconectarChat(objUsuario);
    }
    protected void lbtAbrirChat_Click(object sender, EventArgs e)
    {

    }
}//class
