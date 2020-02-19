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
    public partial class Produtos_para_Envio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["oper"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");
            }
            Label1.Text = Convert.ToString(Session["Id_Cli"]);
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
            }
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
           
                atualizar_status_pedido();
                GridView1.DataBind();
                rptProdutos.Visible = false;
                GridView2.Visible = false;
                GridView1.DataBind();
               Response.Redirect("~/Administrativo/MsgPedidoEnviado.aspx");
               
        }
        public void atualizar_status_pedido()
        {
            int pedido = Convert.ToInt16(Session["pedido"]);
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = " update Tb_Pedido set  Status_Ped =@Status_Ped , Data_Envio_Ped = @Data_Envio_Ped , Data_Entrega_Ped=@Data_Entrega_Ped WHERE  Id_Pedido = " + pedido;
            cmd3.Parameters.AddWithValue("@Status_Ped", DdlStatus.Text);
            cmd3.Parameters.AddWithValue("@Data_Envio_Ped", DateTime.Now.Date);
            cmd3.Parameters.AddWithValue("@Data_Entrega_Ped", DateTime.Now.Date.AddDays(7));
            cmd3.Connection = clsDAO.conexao();
            cmd3.ExecuteNonQuery();

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

            int codigo_pedido = Convert.ToInt16(GridView1.SelectedRow.Cells[0].Text);
            int Id_cli = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            double total = Convert.ToInt16(GridView1.SelectedRow.Cells[2].Text);
            int frete = Convert.ToInt16(GridView1.SelectedRow.Cells[3].Text);
            Session["pedido"] = codigo_pedido;
            Session["Id_Cli"] = Id_cli;
            Session["total"] =  total;
            Session["Frete"] = frete;
            Label1.Text = Convert.ToString(Id_cli);
            rptProdutos.Visible = true;
            btnFinalizar.Visible = true;
            BtnGerarNOta.Visible = true;
        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }

        protected void BtnGerarNOta_Click(object sender, EventArgs e)
        {
           
            if (Session["NomeDestinatirio"] == null)
            {
                MSG("Selecione o endereço do Envio abaixo !!!");
                return;

            }
            else
            {
                btnFinalizar.Enabled = true;
                string _open = "window.open('Nota_Fiscal.aspx','_blank');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
}

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nome = Convert.ToString(GridView2.SelectedRow.Cells[0].Text);


            Session["NomeDestinatirio"] = nome;
        }
    }
}