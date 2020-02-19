using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4.Cliente
{
    public partial class Msg_Erro : System.Web.UI.Page
    {
        string msg;
        string msgsenha;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MSG"] != null)
            {
                LblMSG.Visible = true;
                msg = "Campo requerido";
                LblMSG.Text = msg;
                

            }
            else 
            {
                LblMSG.Visible = false;
          
            
            }



            if (Session["MSGSenha"] != null)
            {
                LblMSGSenha.Visible = true;
                msgsenha = "Senha Não confere";
                LblMSGSenha.Text = msgsenha;

            }
            else 
            {
                LblMSGSenha.Visible = false;
               
            
            }
        }

        protected void Btnvoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cliente/Cad_Cliente.aspx");

        }
    }
}