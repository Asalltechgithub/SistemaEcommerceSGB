using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoSGB_Model;
using System.Data.SqlClient;
using Projeto.SGB.Dao;

namespace WebApplication4.Cliente
{
    public partial class Historico_Cli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cli"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }

      

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int codigo_pedido = Convert.ToInt16(GridView1.SelectedRow.Cells[0].Text);
            int Id_cli = Convert.ToInt16(Session["Cli_ID"]);
            Session["pedido"] = codigo_pedido;
            Session["Id_Cli"] = Id_cli;
            rptProdutos.Visible = true;
            btnFecharrpt.Visible = true;
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

        protected void btnFecharrpt_Click(object sender, EventArgs e)
        {
            btnFecharrpt.Visible =  false;
            rptProdutos.Visible  =  false;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_pedido = Convert.ToInt16(GridView2.SelectedRow.Cells[0].Text);
            int Id_cli = Convert.ToInt16(Session["Cli_ID"]);
            Session["prevenda"] = codigo_pedido;
            Session["Id_Cli"] = Id_cli;
           
            btnFecharrpt2.Visible = true;
            GridView3.Visible = true;
            lblItensprevenda.Visible = true;
        }

        protected void btnFecharrpt2_Click(object sender, EventArgs e)
        {
            btnFecharrpt2.Visible = false;
            GridView3.Visible = false;
            lblItensprevenda.Visible = false;

        }

       
       
    }
}