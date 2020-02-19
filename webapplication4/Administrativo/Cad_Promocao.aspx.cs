using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoSGB_Model;
using Projeto.SGB.Dao;
using System.Data.SqlClient;

namespace WebApplication4.Administrativo
{
    public partial class Cad_Promocao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection cn3 = clsDAO.conexao();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "select* from tb_Prod_Estoque where Id_Prod_Estq=" + DropDownList1.SelectedValue;
            cmd3.Connection = cn3;
            SqlDataReader dr = cmd3.ExecuteReader();
            dr.Read();
            txtNome_Produto.Text = Convert.ToString(dr["Nome_Prod_Estq"]);
            txt_Valor.Text = Convert.ToString(dr["Valor_Venda_Prod_Estoq"]);
            img_Prod.ImageUrl = Convert.ToString(dr["Foto_Prod_Estoq"]);
        }
    }
}