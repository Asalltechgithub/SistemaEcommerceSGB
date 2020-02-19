using System;
using System.Net.Mail;
using System.Net;

namespace WebApplication4
{
    class clsEmail
    {
        public string EmailDe { get; set; }
        public string[] EmailPara { get; set; }
        public string[] EmailCC { get; set; }
        public string[] EmailCCO { get; set; }
        public string[] CaminhoAnexos { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
        public string Smtp { get; set; }
        public string SenhaSmtp { get; set; }
        public int Porta { get; set; }

        public bool EnviarEmail(ref string Erro)
        {
            bool CamposOk = true;
            if (string.IsNullOrEmpty(EmailDe))
            {
                Erro = "Email do Remetente está vazio!\n";
                CamposOk = false;
            }
            if (EmailPara == null)
            {
                Erro += "Email do Destinatário está vazio!\n";
                CamposOk = false;
            }
            if (string.IsNullOrEmpty(Assunto))
            {
                Erro += "Assunto está vazio!\n";
                CamposOk = false;
            }
            if (string.IsNullOrEmpty(Mensagem))
            {
                Erro += "Mensagem está vazia!\n";
                CamposOk = false;
            }
            if (string.IsNullOrEmpty(Smtp))
            {
                Erro += "Smtp não informado!\n";
                CamposOk = false;
            }
            if (string.IsNullOrEmpty(SenhaSmtp))
            {
                Erro += "Senha do Smtp não informada!\n";
                CamposOk = false;
            }
            if (CamposOk)
            {
                //cria objeto com dados do e-mail 
                MailMessage objEmail = new MailMessage();
                //remetente do e-mail 
                objEmail.From = new MailAddress(EmailDe);
                //destinatários do e-mail 
                if (EmailPara != null)
                {
                    for (int i = 0; i < EmailPara.Length; i++)
                    {
                        objEmail.To.Add(EmailPara[i]);
                    }
                }
                if (EmailCC != null)
                {
                    for (int i = 0; i < EmailCC.Length; i++)
                    {
                        objEmail.CC.Add(EmailCC[i]);
                    }
                }
                if (EmailCCO != null)
                {
                    for (int i = 0; i < EmailCCO.Length; i++)
                    {
                        objEmail.Bcc.Add(EmailCCO[i]);
                    }
                }
                //prioridade do e-mail 
                objEmail.Priority = MailPriority.High;
                //'formato do e-mail HTML (caso não queira HTML alocar valor false) 
                objEmail.IsBodyHtml = true;
                //'título do e-mail 
                objEmail.Subject = Assunto;
                //'corpo do e-mail 
                objEmail.Body = Mensagem;
                // Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1" 
                objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                if (CaminhoAnexos != null)
                {
                    for (int i = 0; i < CaminhoAnexos.Length; i++)
                    {
                        objEmail.Attachments.Add(new Attachment(CaminhoAnexos[i]));
                    }
                }
                //cria objeto com os dados do SMTP 
                SmtpClient objSmtp = new SmtpClient();
                objSmtp.Host = Smtp;
                NetworkCredential creds = new System.Net.NetworkCredential(EmailDe, SenhaSmtp);
                objSmtp.Credentials = creds;
                objSmtp.Port = Porta;// 587;//Verifique no seu provedor as informações de SMTP
                objSmtp.EnableSsl = true;//Conforme orientação de seu provedor de email
                try
                {
                    objSmtp.Send(objEmail);
                    return true;
                }
                catch (SmtpException ex)
                {
                    Erro += ex.Message;
                    return false;
                }
                finally
                {
                    objEmail.Dispose();
                }
            }
            else
                return false;
        }
    }
}