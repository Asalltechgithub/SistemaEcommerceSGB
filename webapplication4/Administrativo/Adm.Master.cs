using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Projeto.SGB.Dao;

namespace WebApplication4.Administrativo
{
    public partial class Adm : System.Web.UI.MasterPage
    {
       
       
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["admin"]== null)
            {
                Menu1.Visible = false;
                HyperAviso.Visible = false;
                HyperLink16.Visible = false;
                HyperLink17.Visible = true;
                HyperLink4.Visible = false;
                HyperLink5.Visible = false;
                HyperLink6.Visible = false;
                HyperLink8.Visible = false;
                HyperLink9.Visible = false;
                HyperLink7.Visible = true;
                Alertar_estoque();
                Label1.Text = Convert.ToString(Session["oper"]);
                lnkNomeusu.Text = Convert.ToString(Session["oper2"]);
            }
            if (Session["oper"] == null)
            {
                Alertar_estoque();
                Label1.Text = Convert.ToString(Session["admin"]);
                lnkNomeusu.Text = Convert.ToString(Session["admin2"]);

            }
            

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }


        public void Alertar_estoque() 
        {
            SqlConnection cn = new SqlConnection();
            cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Nome_Prod_Estq as Produto ,Categoria_Prod_Estoq Categoria, Qtd_Prod_Estoq as Qtde  from Tb_Prod_Estoque where  Qtd_Prod_Estoq < 10 ";
            cmd.Connection = cn;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows == true) 
            {
                HyperAviso.Visible = true;
            }
        }

    }
}