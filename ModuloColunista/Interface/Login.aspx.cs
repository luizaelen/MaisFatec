using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

        UsuarioBD usuariobd = new UsuarioBD();
        Usuario usr = usuariobd.ValidaUsuario(Login1.UserName, usuariobd.HashValue(Login1.Password));

        if (usr != null)
        {
            e.Authenticated = true;
            Session["usuario"] = usr; // aqui grava o id do usuario na session

            HttpCookie userIdCookie = new HttpCookie("UserdID");// aqui em gravo o id do perfil do usuario no cookie do navegador essas 3 linhas
            userIdCookie.Value = usr.PerfilC.IdPerfil.ToString();
            Response.Cookies.Add(userIdCookie);
            
            FormsAuthentication.RedirectFromLoginPage(Login1.UserName, false);
        }
        else
        {
            e.Authenticated = false;
            ShowStatus("Usuário não encontrado!Por favor efetue o cadastro antes!", "Login.aspx");
        }
    }
    protected void btnCadastro_Click(object sender, EventArgs e)
    {
        logCadastro.Visible = true;
        Login1.Visible = false;

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        logCadastro.Visible = false;
        Login1.Visible = true;

    }
    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        UsuarioBD usuariobd = new UsuarioBD();
        Usuario usr = new Usuario();

        if (usuariobd.VerificaUsuarioExiste(txtRegistro.Text, txtRg.Text) == null)
        {
            usr.PerfilC = usuariobd.ValidaCadastro(txtRegistro.Text, txtRg.Text);
            if (usr != null)
            {
                usr.LoginUsuario = txtEmail.Text;
                usr.SenhaUsuario = txtSenha.Text;
                usr.EmailUsuario = txtEmail.Text;
                usr.RgUsuario = txtRg.Text;
                usr.RegistroUsuario = txtRegistro.Text;
                usuariobd.Insert(usr);
                btnCadastrar.Text = "Cadastro Realizado";

                Response.Redirect("Login.aspx");

                txtEmail.Text = "";
                txtSenha.Text = "";
                txtEmail.Text = "";
                txtRg.Text = "";
                txtRegistro.Text = "";
            }
            else
            {
                txtEmail.Text = "";
                txtSenha.Text = "";
                txtEmail.Text = "";
                txtRg.Text = "";
                txtRegistro.Text = "";

                ShowStatus("RA do aluno não encontrado! Para se cadastrar é preciso ser aluno!", "Login.aspx");
            
            }
        }
        else
        {
            ShowStatus("Usuário já cadastrado!", "Login.aspx");
        }
    }

    //exibe uma mensagem para o usuario e redireciona para a pagina passada
    protected void ShowStatus(string mensagem, string pagina)
    {
        string popupScript = "<script language='javascript'>" +
            "mensagemErro('" + mensagem + "','" + pagina + "')" +
            "</script>";

        Page.ClientScript.RegisterStartupScript(typeof(Page), "popupScript", popupScript);
    }
}//class