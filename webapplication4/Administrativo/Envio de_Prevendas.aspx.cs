using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ProjetoSGB_Model;
using Projeto.SGB.Dao;

namespace WebApplication4.Administrativo
{
    public partial class Envio_de_Prevendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.SelectedDate = DateTime.Now.Date;
            }

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

            int codigo_pedido = Convert.ToInt16(GridView1.SelectedRow.Cells[0].Text);
            int Id_cli = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            double Valor_total = Convert.ToInt16(GridView1.SelectedRow.Cells[9].Text);
            Session["pre_vendas"] = codigo_pedido;
            Session["Id_Cli"] = Id_cli;
            Session["total"] = Valor_total;
            Label1.Text = Convert.ToString(Id_cli);
            GridView2.Visible = true;
            btnGerarboleto.Enabled = true;




        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lista = Convert.ToInt16(GridView1.SelectedRow.Cells[0].Text);
            Session["Lista_pre_vendas"] = lista;

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            atualizar_status_pedido();
            GridView1.DataBind();
            GridView2.Visible = false;
            Session["pre_vendas"] = null;
        }
        public void atualizar_status_pedido()
        {


            int pedido = Convert.ToInt16(Session["pre_vendas"]);
            if (pedido == 0)
            {
                MSG("Selecione a Pré-venda !");
                btnOk.Enabled = false;
            }
            else
            {
                SqlCommand cmd3 = new SqlCommand();
                cmd3.CommandType = System.Data.CommandType.Text;
                cmd3.CommandText = " update Tb_Pre_Venda set  Status_Pre_Venda = @Status_Pre_Venda  WHERE  Id_Pre_Venda = " + pedido;
                cmd3.Parameters.AddWithValue("@Status_Pre_Venda", DdlStatus.Text);
                cmd3.Connection = clsDAO.conexao();
                cmd3.ExecuteNonQuery();


            }
        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }

        protected void btnGerarboleto_Click(object sender, EventArgs e)
        {
            if (Session["Lista_pre_vendas"] == null)
            {
                MSG("Selecione o Produto para gerar a nota fiscal !");

            }
            else
            {

                Gerar_boleto();
                btnOk.Enabled = true;
            }
        }

        public void Gerar_boleto()
        {

            string _open = "window.open('Nota_fiscal_Prevenda.aspx','_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
           
        }
    }
}