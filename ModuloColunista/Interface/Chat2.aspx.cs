using System;  
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Chat2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnChatTodos_Click(object sender, EventArgs e)
    {
        lblChat2.Text = "";
        ChatNovo chat = new ChatNovo();
        List<ChatUsers> lst = chat.Lista();
        foreach (ChatUsers element in lst)
        {
            lblChat2.Text += " ID: " + element.userId + " NAME: " + element.userName + "<br/>";
        }
    }
}//class