using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String str = Request.Url.ToString();
        str = str.Remove(0, 29);

        PerfilC usr = ((Usuario)Session["usuario"]).PerfilC;
        if (!(str == usr.UrlPerfil))
        {
            PerfilBD perfilbd = new PerfilBD();
            usr = perfilbd.SelectOutro(str);
        }

        CarregaPerfil(usr);
    }
    private void CarregaPerfil(PerfilC objUsuario)
    {

        try
        {
            imgPerfilCapa1.ImageUrl = objUsuario.CapaUm;
            imgPerfilCapa2.ImageUrl = objUsuario.CapaDois;
            imgPerfilCapa3.ImageUrl = objUsuario.CapaTres;
            imgPerfilCapa4.ImageUrl = objUsuario.CapaQuatro;
            imgPerfilFoto.ImageUrl = objUsuario.FotoPerfil;

            //dados básicos
            lblPerfilNome.Text = objUsuario.NomePerfil + " " + objUsuario.SobrenomePerfil;
            lblDataNasc.Text = objUsuario.DataNascimentoPerfil.ToLongDateString();
            lblCidadeNasc.Text = objUsuario.CidadeNatalPerfil;
            lblSexo.Text = objUsuario.SexoPerfil;
            lblEstadoCivil.Text = objUsuario.RelacionamentoPerfil;
            lblCidadeAtual.Text = objUsuario.CidadeAtualPerfil;

            //interesses
            InteressesBD interessebd = new InteressesBD();
            List<Interesses> objInteresse = interessebd.Select(objUsuario.IdPerfil);
            foreach (Interesses element in objInteresse)
            {
                switch (element.InteressesTipo)
                {
                    case "Lazer":
                        IntLazer.Visible = true;
                        lblLazer.Text += element.InteressesDescricao + ", ";
                        break;
                    case "Livros":
                        IntLivros.Visible = true;
                        lblLivros.Text += element.InteressesDescricao + ", ";
                        break;
                    case "Musica":
                        IntMusica.Visible = true;
                        lblMusica.Text += element.InteressesDescricao + ", ";
                        break;
                    case "Filme":
                        IntFilmes.Visible = true;
                        lblFilmes.Text += element.InteressesDescricao + ", ";
                        break;
                    case "Esporte":
                        IntEsporte.Visible = true;
                        lblEsporte.Text += element.InteressesDescricao + ", ";
                        break;
                    default:
                        IntLazer.Visible = true;
                        lblLazer.Text += element.InteressesDescricao + ", ";
                        break;
                }
            }

            //mini cv
            MiniCvBD minicvbd = new MiniCvBD();
            List<MiniCv> objMinicv = minicvbd.Select(objUsuario.IdPerfil);
            foreach (MiniCv element in objMinicv)
            {
                switch (element.MiniCvTipo)
                {
                    case "cursando":
                        IntCursando.Visible = true;
                        lblCursando.Text = element.MiniCvDescricao;
                        lblInstituicaoEnsino.Text = element.MiniCvInstituicao;
                        break;
                    case "emprego":
                        IntEmprego.Visible = true;
                        lblEmprego.Text = element.MiniCvDescricao;
                        lblEmpresa.Text = element.MiniCvInstituicao;
                        break;
                    case "expprofissional":
                        IntExpProf.Visible = true;
                        lblExpProf.Text += element.MiniCvInstituicao + ", ";
                        break;
                    case "curso":
                        IntCursos.Visible = true;
                        lblCursos.Text += element.MiniCvDescricao + ", ";
                        break;
                }
            }
        }
        catch (Exception)
        {
            Response.Redirect("~/erro.aspx");
        }
    }

}//class