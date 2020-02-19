using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4.Administrativo
{
    public partial class Pre_vendas_Consul : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["oper"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");
            }
           
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_pedido = Convert.ToInt16(GridView1.SelectedRow.Cells[0].Text);
            int Id_cli = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            Session["pedido"] = codigo_pedido;
            Session["Id_Cli"] = Id_cli;
            Response.Redirect("Detalhe_Pre_vendas.aspx");
        }
    }
}