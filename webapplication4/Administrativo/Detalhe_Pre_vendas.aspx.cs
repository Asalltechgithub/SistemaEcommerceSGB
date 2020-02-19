using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Projeto.SGB.Dao;

namespace WebApplication4.Administrativo
{
    public partial class Detalhe_Pre_vendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["oper"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");
            }
            Label1.Text = Convert.ToString(Session["Id_Cli"]);
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
                cmd3.CommandText = " update Tb_Pre_Venda set  Status_Pre_Venda = @Status_Pre_Venda  WHERE  Id_Pre_Venda = " + pedido;
                cmd3.Parameters.AddWithValue("@Status_Pre_Venda", DdlStatus.Text);
                cmd3.Connection = clsDAO.conexao();
                cmd3.ExecuteNonQuery();
            
            }
        }
    }
