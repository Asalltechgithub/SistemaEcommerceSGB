using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

using System.Net;

using System.Text;



namespace WebApplication4
{
    public partial class Contato : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Enviar_Click(object sender, EventArgs e)
        {
            if (ValidaEmail(txtEmail.Text) == true)
            {

                SmtpClient Cliente = new SmtpClient();
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                System.Net.NetworkCredential SmtpCreds = new System.Net.NetworkCredential("theglobogames@gmail.com", "123theglobogames");

                try
                {
                    Cliente.Host = "smtp.gmail.com";
                    Cliente.Port = 587;
                    Cliente.UseDefaultCredentials = false;
                    Cliente.Credentials = SmtpCreds;
                    Cliente.EnableSsl = true;
                    string body = string.Concat("Nome:", txtNome.Text, "\nEmail:", txtEmail.Text, "\nMensagem: ", txtMenssagem.Text);
                    msg.Subject = "Fale conosco";
                    msg.Body = body;
                    msg.From = new MailAddress("theglobogames@gmail.com");
                    msg.To.Add(new MailAddress("theglobogames@gmail.com"));
                    Cliente.Send(msg);
                    MSG("Email enviado com sucesso !");

                }
                catch
                {
                    MSG("Erro ao enviar o Email !");
                }
            }
            else 
            {
                MSG("Email Invalido ");
                   return;
            }
            
        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }
        public static bool ValidaEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, ("(?<user>[^@]+)@(?<host>.+)"));
        }
 
    }
}