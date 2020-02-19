using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.SGB.Dao;

namespace WebApplication4
{
    public partial class Site : System.Web.UI.MasterPage
    {
        string Tipo_Sessao;
        protected void Page_Load(object sender, EventArgs e)
        {
            deletar_ped_inativos();
             Lblitens.Text = Convert.ToString(Session["QtdeVol"]);
             lblvaltotal.Text = Convert.ToString(Session["ValorTotal"]);
             string.Format("0:C", lblvaltotal.Text);
            if (Session["admin"] == null)
            {
                lblBemVindo.Visible = true;
                Tipo_Sessao = Convert.ToString(Session["oper"]);
                lnkNomeusu.Text = Convert.ToString(Session["oper2"]);
            }
            if (Session["oper"] == null)
            {
                lblBemVindo.Visible = true;
                Tipo_Sessao = Convert.ToString(Session["admin"]);
                lnkNomeusu.Text = Convert.ToString(Session["admin2"]);
            }
            if (Session["oper"] == null && Session["admin"] == null)
            {
                lblBemVindo.Visible = true;
                Tipo_Sessao = Convert.ToString(Session["Cli_Tipo"]);
                lnkNomeusu.Text = Convert.ToString(Session["Cli_Email"]);
            }
            if (lnkNomeusu.Text == "")
            {
                lblBemVindo.Visible = false;
                LinkButton2.Visible = false;

            }
            if (lnkNomeusu.Text != "")
            {
                LnkCadastro.Visible = false;
                lblogin.Visible = false;

            }
            else { LnkCadastro.Visible = true; }
        
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            if (Tipo_Sessao == "1")
            {
                Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");

            }


            if (Tipo_Sessao == "2")
            {
                Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");

            }

            if (Tipo_Sessao == "3")
            {
                Response.Redirect("~/Cliente/Menu_Cli.aspx");

            }
            if (Tipo_Sessao == "")
            {
                Response.Redirect("~/login.aspx");
            }



        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {



            if (Tipo_Sessao == "3")
            {
                if (Session["Cli_Tipo"] != null)
                {

                    Apagar_carrinho();
                    Session.Clear();
                }
            }

            if (Tipo_Sessao != "3")
            {
                Session.Clear();
            }


            Response.Redirect("~/principal.aspx");
        }

        protected void lnkNomeusu_Click(object sender, EventArgs e)
        {
            if (Tipo_Sessao == "1")
           
            {
              
                Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");

            }


            if (Tipo_Sessao == "2")
           
            {
                
                Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");

            }

            if (Tipo_Sessao == "3")
            
            {

                Response.Redirect("~/Cliente/Menu_Cli.aspx");

            }
            if (Tipo_Sessao == "")
           
            {
                Response.Redirect("~/login.aspx");
            }

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            //Response.Redirect("Descricao_Prod.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/pesquisaProd.aspx?Nome_Prod_Estq=" + txtpesq.Text);
        }

        protected void txtpesq_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/pesquisaProd.aspx?Nome_Prod_Estq=" + txtpesq.Text);
        }
       

        public void Apagar_carrinho() 
        {
            int Id = Convert.ToInt32(Session["Cli_ID"]);
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete From tb_carrinho where cod_cli = @cod_cli ";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@cod_cli", Id);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void deletar_ped_inativos()
        {
            SqlConnection cn2 = clsDAO.conexao();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "delete From Tb_Pedido  where Status_Ped='Aberto' and  Data_Venda_Ped <= @Data_Venda_Ped";
            cmd2.Parameters.AddWithValue("@Data_Venda_Ped", DateTime.Now.AddDays(-7).Date.ToString("yyyy-MM-dd"));
            cmd2.Connection = cn2;
            cmd2.ExecuteNonQuery();


        }
    }
}