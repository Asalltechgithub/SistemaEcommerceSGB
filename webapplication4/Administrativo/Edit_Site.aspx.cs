using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoSGB_Model;
using Projeto.SGB.Dao;
using System.Data.SqlClient;


namespace WebApplication4.Administrativo.ADM
{
    public partial class Edit_Site : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carrega_frete();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            img_Logo.ImageUrl = @"~/Imagens/Logotipos/" + f_up_logo.FileName;
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            txtVal_frete.Enabled = true;
            btnAlterar.Enabled = false;
            btnSalvar.Enabled = true;
        }
        public void carrega_frete() 
        {
            SqlConnection cn3 = clsDAO.conexao();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "select* from tb_Frete";
            cmd3.Connection = cn3;
            SqlDataReader drfrete = cmd3.ExecuteReader();
            drfrete.Read();
            txtVal_frete.Text = Convert.ToString(drfrete["valor_frete"]);
        
        }
        public void Alterar_Frete() 
        {
            SqlConnection cn3 = clsDAO.conexao();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "Update tb_Frete Set valor_frete = @valor_frete where Id_frete=1";
            cmd3.Connection = cn3;
            cmd3.Parameters.AddWithValue("@valor_frete", txtVal_frete.Text);
            cmd3.ExecuteNonQuery();
            cn3.Close();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Alterar_Frete();
            txtVal_frete.Enabled = false;
            btnSalvar.Enabled = false;
            carrega_frete();
            btnAlterar.Enabled = true;

        }
    }
}