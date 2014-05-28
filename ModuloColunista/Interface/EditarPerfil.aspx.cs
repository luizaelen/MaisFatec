using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditarPerfil : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);
        if (!Page.IsPostBack)
        {
            PerfilBD perfilbd = new PerfilBD();
            carregaDadosBasicos(objUsuario);
            carregaMiniCv(objUsuario);
            carregaInteresses(objUsuario);

        }
    }//page load

    protected void FileUploadComplete(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);
        //string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
        string extension = Path.GetExtension(AsyncFileUpload1.FileName);
        string filename = (objUsuario.IdUsuario.ToString() + extension);
        AsyncFileUpload1.SaveAs(Server.MapPath("/FotosPerfil/") + filename);
        //grava a foto no colunista pois lá é usado foto+id como referencia, e aqui é nome+id
        //string colunista = ("foto" +objUsuario.IdUsuario.ToString() + extension);
        //AsyncFileUpload1.SaveAs(Server.MapPath("/colunista/images/colunistas/") + colunista);
        //fim do gravar colunista
        PerfilBD perfilbd = new PerfilBD();
        objUsuario.PerfilC.FotoPerfil = "/FotosPerfil/" + filename;
        perfilbd.Update(objUsuario);


    }

    private void carregaDadosBasicos(Usuario usr)
    {
        txtEdtPerfNome.Text = usr.PerfilC.NomePerfil;
        txtEdtPerfSobrenome.Text = usr.PerfilC.SobrenomePerfil;
        txtEdtPerfDtNasc.Text = usr.PerfilC.DataNascimentoPerfil.ToShortDateString();
        txtEdtPerfSobreVoce.Text = usr.PerfilC.SobrePerfil;
        txtEdtPerfCidadeAtual.Text = usr.PerfilC.CidadeAtualPerfil;
        txtEdtPerfCidadeNatal.Text = usr.PerfilC.CidadeNatalPerfil;
        ddlEdtPerfSexo.SelectedValue = usr.PerfilC.SexoPerfil;
        ddlEdtPerfRelacionamento.SelectedValue = usr.PerfilC.RelacionamentoPerfil;
        imgPerfilUsuario.ImageUrl = usr.PerfilC.FotoPerfil;
    }//Carrega Dados Básicos
    private void carregaMiniCv(Usuario usr)
    {
        MiniCvBD miniCvBd = new MiniCvBD();
        List<MiniCv> miniCvLista = miniCvBd.Select(usr.PerfilC.IdPerfil);
        int exp = 0;
        int comp = 0;
        foreach (MiniCv element in miniCvLista)
        {
            switch (element.MiniCvTipo)
            {
                case "cursando":
                    ttbCursandoNome.Text = element.MiniCvDescricao;
                    ttbCursandoInstituicao.Text = element.MiniCvInstituicao;
                    break;
                case "emprego":
                    txtEmpregoAtualFuncao.Text = element.MiniCvDescricao;
                    txtEmpregoAtualEmpresa.Text = element.MiniCvInstituicao;
                    break;
                case "expprofissional":
                    switch (exp)
                    {
                        case 0:
                            txtExpProf1Empresa.Text = element.MiniCvInstituicao;
                            txtExpProf1Funcao.Text = element.MiniCvDescricao;
                            exp++;
                            break;
                        case 1:
                            txtExpProf2Empresa.Text = element.MiniCvInstituicao;
                            txtExpProf2Funcao.Text = element.MiniCvDescricao;
                            ibtExpProf1.Visible = false;
                            ExpProf2.Visible = true;
                            exp++;
                            break;
                        case 2:
                            txtExpProf3Empresa.Text = element.MiniCvInstituicao;
                            txtExpProf3Funcao.Text = element.MiniCvDescricao;
                            ibtExpProf2.Visible = false;
                            ExpProf3.Visible = true;
                            exp++;
                            break;
                        case 3:
                            txtExpProf4Empresa.Text = element.MiniCvInstituicao;
                            txtExpProf4Funcao.Text = element.MiniCvDescricao;
                            ibtExpProf3.Visible = false;
                            ExpProf4.Visible = true;
                            exp++;
                            break;
                        case 4:
                            txtExpProf5Empresa.Text = element.MiniCvInstituicao;
                            txtExpProf5Funcao.Text = element.MiniCvDescricao;
                            ExpProf5.Visible = true;
                            exp++;
                            break;
                    }
                    break;
                case "curso":
                    switch (comp)
                    {
                        case 0:
                            txtCurComp1.Text = element.MiniCvDescricao;
                            comp++;
                            break;
                        case 1:
                            txtCurComp2.Text = element.MiniCvDescricao;
                            imbCurComp1.Visible = false;
                            CurComp2.Visible = true;
                            comp++;
                            break;
                        case 2:
                            txtCurComp3.Text = element.MiniCvDescricao;
                            imbCurComp2.Visible = false;
                            CurComp3.Visible = true;
                            comp++;
                            break;
                        case 3:
                            txtCurComp4.Text = element.MiniCvDescricao;
                            imbCurComp3.Visible = false;
                            CurComp4.Visible = true;
                            comp++;
                            break;
                        case 4:
                            txtCurComp5.Text = element.MiniCvDescricao;
                            CurComp5.Visible = true;
                            comp++;
                            break;
                    }
                    break;
            }
        }
    }//Carrega Mini CV
    private void carregaInteresses(Usuario usr)
    {
        InteressesBD interessesBd = new InteressesBD();
        List<Interesses> interesseslista = interessesBd.Select(usr.PerfilC.IdPerfil);
        Session["interesses"] = interesseslista;
        foreach (Interesses element in interesseslista)
        {
            switch (element.InteressesTipo)
            {
                case "Lazer":
                    switch (element.IndexInteresse)
                    {
                        case 1:
                            txtLazer1.Text = element.InteressesDescricao;
                            break;
                        case 2:
                            txtLazer2.Text = element.InteressesDescricao;
                            ibtLazer1.Visible = false;
                            Lazer2.Visible = true;
                            break;
                        case 3:
                            txtLazer3.Text = element.InteressesDescricao;
                            ibtLazer2.Visible = false;
                            Lazer3.Visible = true;
                            break;
                        case 4:
                            txtLazer4.Text = element.InteressesDescricao;
                            ibtLazer3.Visible = false;
                            Lazer4.Visible = true;
                            break;
                        case 5:
                            txtLazer5.Text = element.InteressesDescricao;
                            ibtLazer4.Visible = false;
                            Lazer5.Visible = true;
                            break;
                    }
                    break;
                case "Livros":
                    switch (element.IndexInteresse)
                    {
                        case 1:
                            txtEdtPerfLivro1.Text = element.InteressesDescricao;
                            break;
                        case 2:
                            txtEdtPerfLivro2.Text = element.InteressesDescricao;
                            ibtEdtPerfLivro1.Visible = false;
                            edtPerfLivro2.Visible = true;
                            break;
                        case 3:
                            txtEdtPerfLivro3.Text = element.InteressesDescricao;
                            ibtEdtPerfLivro2.Visible = false;
                            edtPerfLivro3.Visible = true;
                            break;
                        case 4:
                            txtEdtPerfLivro4.Text = element.InteressesDescricao;
                            ibtEdtPerfLivro3.Visible = false;
                            edtPerfLivro4.Visible = true;
                            break;
                        case 5:
                            txtEdtPerfLivro5.Text = element.InteressesDescricao;
                            ibtEdtPerfLivro4.Visible = false;
                            edtPerfLivro5.Visible = true;
                            break;
                    }
                    break;
                case "Musica":
                    switch (element.IndexInteresse)
                    {
                        case 1:
                            txtEdtPerfMusica1.Text = element.InteressesDescricao;
                            break;
                        case 2:
                            txtEdtPerfMusica2.Text = element.InteressesDescricao;
                            ibtEdtPerfMusica1.Visible = false;
                            edtPerfMusica2.Visible = true;
                            break;
                        case 3:
                            txtEdtPerfMusica3.Text = element.InteressesDescricao;
                            ibtEdtPerfMusica2.Visible = false;
                            edtPerfMusica3.Visible = true;
                            break;
                        case 4:
                            txtEdtPerfMusica4.Text = element.InteressesDescricao;
                            ibtEdtPerfMusica3.Visible = false;
                            edtPerfMusica4.Visible = true;
                            break;
                        case 5:
                            txtEdtPerfMusica5.Text = element.InteressesDescricao;
                            ibtEdtPerfMusica4.Visible = false;
                            edtPerfMusica5.Visible = true;
                            break;
                    }
                    break;
            }//switch
        }//foreach
    }//Carrega Interesses

    protected void ibtExpProf1_Click(object sender, ImageClickEventArgs e)
    {
        ExpProf2.Visible = true;
        ibtExpProf1.Visible = false;
    }
    protected void ibtExpProf2_Click(object sender, ImageClickEventArgs e)
    {
        ExpProf3.Visible = true;
        ibtExpProf2.Visible = false;
    }
    protected void ibtExpProf3_Click(object sender, ImageClickEventArgs e)
    {
        ExpProf4.Visible = true;
        ibtExpProf3.Visible = false;
    }
    protected void ibtExpProf4_Click(object sender, ImageClickEventArgs e)
    {
        ExpProf5.Visible = true;
        ibtExpProf4.Visible = false;
    }

    protected void imbCurComp1_Click(object sender, ImageClickEventArgs e)
    {
        CurComp2.Visible = true;
        imbCurComp1.Visible = false;
    }
    protected void imbCurComp2_Click(object sender, ImageClickEventArgs e)
    {
        CurComp3.Visible = true;
        imbCurComp2.Visible = false;
    }
    protected void imbCurComp3_Click(object sender, ImageClickEventArgs e)
    {
        CurComp4.Visible = true;
        imbCurComp3.Visible = false;
    }
    protected void imbCurComp4_Click(object sender, ImageClickEventArgs e)
    {
        CurComp5.Visible = true;
        imbCurComp4.Visible = false;
    }

    protected void ibtLazer1_Click(object sender, ImageClickEventArgs e)
    {
        Lazer2.Visible = true;
        ibtLazer1.Visible = false;
    }
    protected void ibtLazer2_Click(object sender, ImageClickEventArgs e)
    {
        Lazer3.Visible = true;
        ibtLazer2.Visible = false;
    }
    protected void ibtLazer3_Click(object sender, ImageClickEventArgs e)
    {
        Lazer4.Visible = true;
        ibtLazer3.Visible = false;
    }
    protected void ibtLazer4_Click(object sender, ImageClickEventArgs e)
    {
        Lazer5.Visible = true;
        ibtLazer4.Visible = false;
    }

    protected void ibtEdtPerfLivro1_Click(object sender, ImageClickEventArgs e)
    {
        edtPerfLivro2.Visible = true;
        ibtEdtPerfLivro1.Visible = false;
    }
    protected void ibtEdtPerfLivro2_Click(object sender, ImageClickEventArgs e)
    {
        edtPerfLivro3.Visible = true;
        ibtEdtPerfLivro2.Visible = false;
    }
    protected void ibtEdtPerfLivro3_Click(object sender, ImageClickEventArgs e)
    {
        edtPerfLivro4.Visible = true;
        ibtEdtPerfLivro3.Visible = false;
    }
    protected void ibtEdtPerfLivro4_Click(object sender, ImageClickEventArgs e)
    {
        edtPerfLivro5.Visible = true;
        ibtEdtPerfLivro4.Visible = false;
    }

    protected void ibtEdtPerfMusica1_Click(object sender, ImageClickEventArgs e)
    {
        edtPerfMusica2.Visible = true;
        ibtEdtPerfMusica1.Visible = false;
    }
    protected void ibtEdtPerfMusica2_Click(object sender, ImageClickEventArgs e)
    {
        edtPerfMusica3.Visible = true;
        ibtEdtPerfMusica2.Visible = false;
    }
    protected void ibtEdtPerfMusica3_Click(object sender, ImageClickEventArgs e)
    {
        edtPerfMusica4.Visible = true;
        ibtEdtPerfMusica3.Visible = false;
    }
    protected void ibtEdtPerfMusica4_Click(object sender, ImageClickEventArgs e)
    {
        edtPerfMusica5.Visible = true;
        ibtEdtPerfMusica4.Visible = false;
    }

    protected void btnEdtPerfSalvarDadosBasicos_Click(object sender, EventArgs e)
    {
        Usuario objUsuario = ((Usuario)Session["usuario"]);

        objUsuario.PerfilC.SobrenomePerfil = txtEdtPerfSobrenome.Text;
        objUsuario.PerfilC.RelacionamentoPerfil = ddlEdtPerfRelacionamento.Text;
        objUsuario.PerfilC.FotoPerfil = imgPerfilUsuario.ImageUrl;
        objUsuario.PerfilC.SobrePerfil = txtEdtPerfSobreVoce.Text;
        objUsuario.PerfilC.CidadeAtualPerfil = txtEdtPerfCidadeAtual.Text;
        objUsuario.PerfilC.CidadeNatalPerfil = txtEdtPerfCidadeNatal.Text;

        PerfilBD perfilbd = new PerfilBD();
        if (perfilbd.Update(objUsuario) == 0)
        {
            Session["usuario"] = objUsuario;
            btnEdtPerfSalvarDadosBasicos.Text = "Dados salvos com sucesso!";
        }
    }

    private void EditarInteressesUpdate(Usuario usr, List<Interesses> interessesLst, String tipo, String descricao, int index, int id)
    {
        Interesses interesses = new Interesses();
        interesses.InteressesDescricao = descricao;
        interesses.InteressesTipo = tipo;
        interesses.IdPerfil = usr.PerfilC.IdPerfil;
        interesses.IndexInteresse = index;
        interesses.IdInteresse = id;
        interessesLst.Add(interesses);
    }

    protected void btnEdtPerfSalvarInteresses_Click(object sender, EventArgs e)
    {
        List<Interesses> interessesLstInsert = new List<Interesses>();
        List<Interesses> interessesLstUpdate = new List<Interesses>();
        InteressesBD interessesbd = new InteressesBD();
        Usuario objUsuario = ((Usuario)Session["usuario"]);
        List<Interesses> interessesLista = interessesbd.Select(objUsuario.PerfilC.IdPerfil);

        foreach (Interesses element in interessesLista)
        {
            switch (element.InteressesTipo)
            {
                case "Lazer":
                    switch (element.IndexInteresse)
                    {
                        case 1:
                            if (txtLazer1.Text != "")
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Lazer", txtLazer1.Text, 1, element.IdInteresse);
                            }
                            break;
                        case 2:
                            if (txtLazer2.Text != "")
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Lazer", txtLazer2.Text, 2, element.IdInteresse);
                            }
                            break;
                        case 3:
                            if (txtLazer3.Text != "")
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Lazer", txtLazer3.Text, 3, element.IdInteresse);
                            }
                            break;
                        case 4:
                            if (txtLazer4.Text != "")
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Lazer", txtLazer4.Text, 4, element.IdInteresse);
                            }
                            break;
                        case 5:
                            if (txtLazer5.Text != "")
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Lazer", txtLazer5.Text, 5, element.IdInteresse);
                            }
                            break;
                    }
                    break;
                case "Livros":
                    switch (element.IndexInteresse)
                    {
                        case 1:
                            if (txtEdtPerfLivro1.Text != "")
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Livros", txtEdtPerfLivro1.Text, 1, element.IdInteresse);
                            }
                            break;
                        case 2:
                            if ((edtPerfLivro2.Visible) && (txtEdtPerfLivro2.Text != ""))
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Livros", txtEdtPerfLivro2.Text, 2, element.IdInteresse);
                            }
                            break;
                        case 3:
                            if ((edtPerfLivro3.Visible) && (txtEdtPerfLivro3.Text != ""))
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Livros", txtEdtPerfLivro3.Text, 3, element.IdInteresse);
                            }
                            break;
                        case 4:
                            if ((edtPerfLivro4.Visible) && (txtEdtPerfLivro4.Text != ""))
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Livros", txtEdtPerfLivro4.Text, 4, element.IdInteresse);
                            }
                            break;
                        case 5:
                            if ((edtPerfLivro5.Visible) && (txtEdtPerfLivro5.Text != ""))
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Livros", txtEdtPerfLivro5.Text, 5, element.IdInteresse);
                            }
                            break;
                    }
                    break;
                case "Musica":
                    switch (element.IndexInteresse)
                    {
                        case 1:
                            if (txtEdtPerfMusica1.Text != "")
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Musica", txtEdtPerfMusica1.Text, 1, element.IdInteresse);
                            }
                            break;
                        case 2:
                            if ((edtPerfMusica2.Visible) && (txtEdtPerfMusica2.Text != ""))
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Musica", txtEdtPerfMusica2.Text, 2, element.IdInteresse);
                            }
                            break;
                        case 3:
                            if ((edtPerfMusica3.Visible) && (txtEdtPerfMusica3.Text != ""))
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Musica", txtEdtPerfMusica3.Text, 3, element.IdInteresse);
                            }
                            break;
                        case 4:
                            if ((edtPerfMusica4.Visible) && (txtEdtPerfMusica4.Text != ""))
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Musica", txtEdtPerfMusica4.Text, 4, element.IdInteresse);
                            }
                            break;
                        case 5:
                            if ((edtPerfMusica5.Visible) && (txtEdtPerfMusica5.Text != ""))
                            {
                                EditarInteressesUpdate(objUsuario, interessesLstUpdate, "Musica", txtEdtPerfMusica5.Text, 5, element.IdInteresse);
                            }
                            break;
                    }
                    break;
            }
        }

        if ((interessesbd.Insert(interessesLstInsert) == 0) && (interessesbd.Update(interessesLstUpdate) == 0))
        {
            btnEdtPerfSalvarInteresses.Text = "Dados salvos com sucesso";
        }
        else
        {
            btnEdtPerfSalvarInteresses.Text = "Erro ao Salvar";
        }

    }
}//class