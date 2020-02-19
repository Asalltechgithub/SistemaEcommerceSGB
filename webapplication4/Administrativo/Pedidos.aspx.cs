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
    public partial class Pedidos1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["oper"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            deletar_ped_inativos();
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           int codigo_pedido = Convert.ToInt16(GridView1.SelectedRow.Cells[0].Text);
           int Id_cli = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            Session["pedido"] = codigo_pedido;
            Session["Id_Cli"] = Id_cli;
            Response.Redirect("Detalhe_Pedido.aspx");
        }

        public void deletar_ped_inativos() 
        {
                SqlConnection cn2 = clsDAO.conexao();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "delete From Tb_Pedido  where Status_Ped='Aberto' and  Data_Venda_Ped < @Data_Venda_Ped";
                cmd2.Parameters.AddWithValue("@Data_Venda_Ped", DateTime.Now.AddDays(-7).Date.ToString("yyyy-MM-dd"));   
                cmd2.Connection = cn2;
                cmd2.ExecuteNonQuery();
            
        
        }
    }
}

