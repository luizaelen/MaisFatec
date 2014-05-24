using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Perfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        carregaPerfil();
    }

    public void carregaPerfil()
    {
        imgPerfilCapa1.ImageUrl = "";
        imgPerfilCapa2.ImageUrl = "";
        imgPerfilCapa3.ImageUrl = "";
        imgPerfilCapa4.ImageUrl = "";
        //imgPerfilFoto.ImageUrl = "";

        //dados básicos
        lblPerfilNome.Text = "Gabriel Moblicci";
        lblDataNasc.Text = "07 de Agosto de 1990 ";
        lblCidadeNasc.Text = "Santos";
        lblSexo.Text = "Masculino";
        lblEstadoCivil.Text = "Noivo";
        lblCidadeAtual.Text = "Guaratinguetá";

        //interesses
        lblHobbies.Text = "Futebol, Jogos Eletrônicos, Leitura, Música";
        lblMusica.Text = "Rock, MPB, Samba, Música Clássica";
        lblLivros.Text = "O Velho e o Mar - Ernest Hemingway, O Céu e o Inferno - Allan Kardec, Fortaleza Digital - Dan Brown";

        //mini cv
        lblCurso.Text = "Análise e Desenvolvimento de Sistemas ";
        lblEmpregoAtual.Text = "GMSD - Desenvolvimento de Sistemas";
        lblEmpregosPassados.Text = "Equipe Informática, CSSR Editora Santuário";
        lblCursos.Text = "Formação em Hardware; Programação para web com PHP, HTML, CSS e JavaScript; Programação C# .Net; Certificação TOTVS ERP";

    }

}//class