using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



namespace WebApplication4.Administrativo.ADM
{
    public partial class contatar_Fornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        
        {
                string Email;
                Email = DropDownList1.SelectedValue;
                string nomeMail = "contato@provedor.com.br";
                string concatBody = TextBox1.Text;
                string destinarioEmail = Email;
                string remetenteEmail = "theglobogames@gmail.com";//estou usando um gmail // mais poderia ser qualquer 1
                string remetenteSenha = "123theglobogames";

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.To.Add(destinarioEmail);
                mail.From = new MailAddress(nomeMail, "theglobogames@gmail.com", System.Text.Encoding.UTF8);
                mail.Subject = "Pedido de Produtos ";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = concatBody;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = System.Net.Mail.MailPriority.High; //Prioridade do E-Mail // no caso deixei como alta
                SmtpClient client = new SmtpClient(); //Adicionando as credenciais do seu e-mail e senha:
                client.Credentials = new System.Net.NetworkCredential(remetenteEmail, remetenteSenha);
                client.Port = 587; // Esta porta ‚ a utilizada pelo Gmail para envio
                client.Host = "smtp.gmail.com"; //Definindo o provedor que ir  disparar o e-mail
                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer
                try
                {
                    client.Send(mail);
                   // MSG("Email Enviado com Sucesso");

                }
                catch (Exception ex)
                {
                    MSG("Ocorreu um erro ao enviar:" + ex.Message);

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
    
