using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Projeto.SGB.Dao;
using System.Data;
using WebMatrix.WebData;
using System.Web.Security;
using System.Web.SessionState;



namespace WebApplication4
{
    public partial class login : System.Web.UI.Page
    {
        string email;
        int ID_TipoUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MSG"] != null) 
            {
                MSG("Sua conta não da direito a compra ! Entre com uma conta de Cliente !");
                Session["MSG"] = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Session.Clear();

            SqlConnection con = clsDAO.conexao();

            SqlCommand cmd = new SqlCommand("select Id, Nome , CPF, RG , Sexo, Estado_civil,Dt_Nascimento , Endereco,UF,CEP, Cidade, Telefone,Email,Senha,ID_TipoUsuario from  Tb_Usuario inner join Tb_Tipo_usuario on TipoUsuario = ID_TipoUsuario where Tb_Usuario.Email =" + "'" + txtUsuario.Text + "'" + "and Tb_Usuario.Senha =" + "'" + txtSenha.Text + "'" + "");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows == false) 
            {
                lblMsgLogin.Visible = true;
                lblMsgLogin.Text = "Email invalido ou Senha Incorreta";
                txtUsuario.Text = "";
            
            }
            if (dr.HasRows)
            {
                lblMsgLogin.Visible = false;
                dr.Read();
                Label1.Text = Convert.ToString(dr["Id"]);
                ID_TipoUsuario = Convert.ToInt16(dr["ID_TipoUsuario"]);
                email = Convert.ToString(dr["Email"]);

            }
            if (ID_TipoUsuario == 1)
            {


                Session["admin"] = ID_TipoUsuario;
                Session["admin2"] = txtUsuario.Text;
                var returnurl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrEmpty(returnurl))
                {
                    
                    Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");
                }
                else
                {
                    Response.Redirect(returnurl);
                }
            }
            if (ID_TipoUsuario == 2)
            {


                Session["oper"] = ID_TipoUsuario;
                Session["oper2"] = txtUsuario.Text;
                var returnurl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrEmpty(returnurl))
                {

                    Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");
                }
                else
                {
                    Response.Redirect(returnurl);
                }

            }
            if (ID_TipoUsuario == 3)
            {

                #region Criação do perfil - com variaves de seção

                Session["Cli_ID"] = Label1.Text;
                Session["Cli_Tipo"] = ID_TipoUsuario;
                Session["Cli_Email"] = email;
                #endregion
                Session.Add("cli", Label15.Text);
                Session["cli"] = Label15;
                
                Response.Redirect("~/principal.aspx");
                
            }

        
        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }

    }




}


