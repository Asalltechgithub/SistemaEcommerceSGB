using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoSGB_Model;
using System.Data.SqlClient;
using Projeto.SGB.Dao;

namespace WebApplication4.Administrativo
{
    public partial class Detalhe_Pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["oper"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");
            }
            Label1.Text = Convert.ToString( Session["Id_Cli"]);
            
        }
        protected void rptProdutos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Label lblIdProd = (Label)e.Item.FindControl("Lblcodprod");
                Label lblqtd = (Label)e.Item.FindControl("Lblqtd");
                Session["lblIdProd"] = lblIdProd.Text;
                Session["lblqtd"] = lblqtd.Text;
         
            }
        }
        //public void Baixa_no_estoque()
        //{
        //    foreach (RepeaterItem Item in rptProdutos.Items)
        //    {
        //        Label lblIdProd = (Label)Item.FindControl("Lblcodprod");
        //        Label lblqtd = (Label)Item.FindControl("Lblqtd");
        //        Session["lblIdProd"] = lblIdProd.Text;
        //        Session["lblqtd"] = lblqtd.Text;
        //        if (lblIdProd.Text != "")
        //        {

        //            int qtd_Compra;
        //            int qtd_Estoque;
        //            int id_produto;

        //            id_produto = Convert.ToInt16(Session["lblIdProd"]);
        //            qtd_Compra = Convert.ToInt16(Session["lblqtd"]);

        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandType = System.Data.CommandType.Text;
        //            cmd.CommandText = "select Qtd_Prod_Estoq from Tb_Prod_Estoque where Id_Prod_Estq = " + id_produto;
        //            cmd.Connection = clsDAO.conexao();
        //            SqlDataReader dr;
        //            dr = cmd.ExecuteReader();
        //            dr.Read();
        //            qtd_Estoque = Convert.ToInt16(dr["Qtd_Prod_Estoq"]);

        //            int baixa = qtd_Estoque - qtd_Compra;

        //            SqlCommand cmd2 = new SqlCommand();
        //            cmd2.CommandType = System.Data.CommandType.Text;
        //            cmd2.CommandText = "update Tb_Prod_Estoque set Qtd_Prod_Estoq =@Qtd_Prod_Estoq where Id_Prod_Estq = " + id_produto;
        //            cmd2.Parameters.AddWithValue("@Qtd_Prod_Estoq", baixa);
        //            cmd2.Connection = clsDAO.conexao();
        //            cmd2.ExecuteNonQuery();
        //        }
                
        //    }
        //}
        protected void btnFinalizar_Click1(object sender, EventArgs e)
            {                                        
                //Baixa_no_estoque();
                atualizar_status_pedido();
                Response.Redirect("MsgPedidoFinalizado.aspx");
            }
        public void atualizar_status_pedido() 
            {
                int pedido = Convert.ToInt16(Session["pedido"]);
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = " update Tb_Pedido set  Status_Ped =@Status_Ped  WHERE  Id_Pedido = " + pedido;
                cmd3.Parameters.AddWithValue("@Status_Ped", DdlStatus.Text);
                cmd3.Connection = clsDAO.conexao();
                cmd3.ExecuteNonQuery();
            
            }
    }
}