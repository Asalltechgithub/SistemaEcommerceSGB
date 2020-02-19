using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Projeto.SGB.Dao;
using System.Data;
using WebMatrix.WebData;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace WebApplication4
{
    public partial class Rec_Senha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
             SqlConnection con = clsDAO.conexao();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Senha from Tb_Usuario where Email = "+"'" +txtEmail.Text+"'";
            cmd.Connection = con;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true) 
            {
                dr.Read();
                string senha = Convert.ToString(dr["Senha"]);
                string nomeMail = "contato@provedor.com.br";
                string concatBody = "Sua Senha é : "+ senha ;
                string destinarioEmail = txtEmail.Text;
                string remetenteEmail = "theglobogames@gmail.com";//estou usando um gmail // mais poderia ser qualquer 1
                string remetenteSenha = "123theglobogames";

                MailMessage mail = new MailMessage();
                mail.To.Add(destinarioEmail);
                mail.From = new MailAddress(nomeMail, "theglobogames@gmail.com", System.Text.Encoding.UTF8);
                mail.Subject = "Recuperar Senha ";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = concatBody;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High; //Prioridade do E-Mail // no caso deixei como alta
                SmtpClient client = new SmtpClient(); //Adicionando as credenciais do seu e-mail e senha:
                client.Credentials = new System.Net.NetworkCredential(remetenteEmail, remetenteSenha);
                client.Port = 587; // Esta porta ‚ a utilizada pelo Gmail para envio
                client.Host = "smtp.gmail.com"; //Definindo o provedor que ir  disparar o e-mail
                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer
                try
                {
                    client.Send(mail);
                   MSG("Email Enviado com Sucesso");
                   
                }
                catch (Exception ex)
                {
                    MSG("Ocorreu um erro ao enviar:" + ex.Message);
                    
                }
                          
            }
            if (dr.HasRows == false)
            {
                MSG("Email invalido");
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