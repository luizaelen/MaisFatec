using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;



public partial class colunista_admin_publicacao_solicitar_tema_contato : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        if (ValidaEmail(txtEmail.Text))
        {
            MailMessage oEmail = new MailMessage();
            MailAddress sDe = new MailAddress(txtEmail.Text);

            oEmail.To.Add("fabiano@attitudecomunicacao.com.br"); // email que irá receber as mensagens
            oEmail.From = sDe;
            oEmail.Priority = MailPriority.Normal;
            oEmail.IsBodyHtml = true;
            oEmail.Subject = "Cliente: " + txtNome.Text; // aqui definimos que aparecerá o nome do cliente no assunto
            oEmail.Body = txtMensagem.Text;
            oEmail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
            oEmail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

            SmtpClient oEnviar = new SmtpClient();
            oEnviar.Host = "localhost";

            try
            {
                oEnviar.Send(oEmail);
                lblMensagem.Text = txtNome.Text + "," + '\n' + "mensagem enviada com sucesso!";
            }
            catch
            {
                lblMensagem.Text = txtNome.Text + "," + '\n' + "ocorreu um erro ao tentar enviar a mensagem!";
            }

            oEmail.Dispose();

            txtNome.Text = "";
            txtEmail.Text = "";
            txtMensagem.Text = "";
        }
        else
        {
            lblMensagem.Text = "Email inválido!";
        }
        

    }
    public bool ValidaEmail(string emailaddress)
    {
        try
        {
            MailAddress m = new MailAddress(emailaddress);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
    
}