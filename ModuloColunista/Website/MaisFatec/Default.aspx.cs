using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        carregaPerfilSide();
    }

    public void carregaPerfilSide()
    {
        //1
        defPerf1.HRef = "gabrielmoblicci.aspx";
        imgDefPerf1.ImageUrl = "~/img/DSC01610.jpg";
        lblDefPerfNome1.Text = "Gabriel Moblicci ";
        lblDefPerfStatus1.Text = "se cadastrou no Mais Fatec";
        //2
        defPerf2.HRef = "lucassantos.aspx";
        imgDefPerf2.ImageUrl = "~/img/lucasPerfil.JPG";
        lblDefPerfNome2.Text = "Lucas Santos ";
        lblDefPerfStatus2.Text = "está online";
        //3
        defPerf3.HRef = "anaportes.aspx";
        imgDefPerf3.ImageUrl = "~/img/logomarca2.png";
        lblDefPerfNome3.Text = "Ana Carla ";
        lblDefPerfStatus3.Text = "está online";
        //4
        defPerf4.HRef = "joaopasin.aspx";
        imgDefPerf4.ImageUrl = "~/img/joaoPerfil.JPG";
        lblDefPerfNome4.Text = "João Pasin ";
        lblDefPerfStatus4.Text = "atualizou a foto de seu Perfil";
        //5
        defPerf5.HRef = "pedrocampos.aspx";
        imgDefPerf5.ImageUrl = "~/img/logomarca2.png";
        lblDefPerfNome5.Text = "Pedro Campos ";
        lblDefPerfStatus5.Text = "concluiu um curso de extensão acadêmica: Programação PHP";
        //6
        defPerf6.HRef = "francielecastilho.aspx";
        imgDefPerf6.ImageUrl = "~/img/logomarca2.png";
        lblDefPerfNome6.Text = "Franciele Castilho ";
        lblDefPerfStatus6.Text = "adicionou novos interesses: Leitura, Dormir ...";
        //7
        defPerf7.HRef = "joaopasin.aspx";
        imgDefPerf7.ImageUrl = "~/img/joaoPerfil.JPG";
        lblDefPerfNome7.Text = "João Pasin ";
        lblDefPerfStatus7.Text = "adicionou um novo interesse: Magic the Gathering";
        //8
        defPerf8.HRef = "jessicafrattari.aspx";
        imgDefPerf8.ImageUrl = "~/img/logomarca2.png";
        lblDefPerfNome8.Text = "Jéssica Frattari ";
        lblDefPerfStatus8.Text = "está noiva de Lucas Santos";
        //9
        defPerf9.HRef = "camilamartinelli.aspx";
        imgDefPerf9.ImageUrl = "~/img/logomarca2.png";
        lblDefPerfNome9.Text = "Camila Martinelli ";
        lblDefPerfStatus9.Text = "está lecionando uma nova matéria: Programação em Scripts";
        //10
        defPerf10.HRef = "gabrielmoblicci.aspx";
        imgDefPerf10.ImageUrl = "~/img/DSC01610.jpg";
        lblDefPerfNome10.Text = "Gabriel Moblicci ";
        lblDefPerfStatus10.Text = "está a procura de emprego";
        //11
        defPerf11.HRef = "josemanoel.aspx";
        imgDefPerf11.ImageUrl = "~/img/logomarca2.png";
        lblDefPerfNome11.Text = "José Manoel ";
        lblDefPerfStatus11.Text = "mudou de função em seu emprego: Diretor da Fatec Guaratinguetá";
        //12
        defPerf12.HRef = "allbert.aspx";
        imgDefPerf12.ImageUrl = "~/img/logomarca2.png";
        lblDefPerfNome12.Text = "Allbert ";
        lblDefPerfStatus12.Text = "concluiu um curso de extensão acadêmica: Certificação Master C# .Net - Microsoft";
    }

}//class