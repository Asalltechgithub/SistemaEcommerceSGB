using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.SGB.Dao;
using System.Data.SqlClient;
using ProjetoSGB_Model;

namespace WebApplication4.Administrativo
{
    public partial class Control_prevenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_pedido = Convert.ToInt16(GridView1.SelectedRow.Cells[0].Text);
            int Id_cli = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            Session["pre_venda"] = codigo_pedido;
            Session["Id_Cli"] = Id_cli;
            Pdetalhes.Visible = true;
        }

       
        protected void btnFinalizar_Click1(object sender, EventArgs e)
        {
            //Baixa_no_estoque();
            atualizar_status_pedido();
            Response.Redirect("MsgPedidoFinalizado.aspx");
        }
        public void atualizar_status_pedido()
        {
            int pedido = Convert.ToInt16(Session["pre_venda"]);
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = " update Tb_Pre_Venda set  Status_Pre_Venda = @Status_Pre_Venda  WHERE  Id_Pre_Venda = " + pedido;
            cmd3.Parameters.AddWithValue("@Status_Pre_Venda", DdlStatus.Text);
            cmd3.Connection = clsDAO.conexao();
            cmd3.ExecuteNonQuery();

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            atualizar_status_pedido();
            GvDetalhe.Visible = false;
            GridView1.DataBind();
        }
    }
}