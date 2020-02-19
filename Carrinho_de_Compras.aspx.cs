using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoSGB_Model;
using Projeto.SGB.Dao;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class Carrinho_de_Compras : System.Web.UI.Page
    {
        int Tipo_Pedido;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["admin"] != null || Session["oper"] != null)
            {

                Response.Redirect("~/login.aspx");
            }
            if (Session["cli"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {

                if (Session["Carrinho"] != null)
                {
                    PeencheEditaProduto();
                }
            }

        }

        protected void txtQtde_TextChanged(object sender, EventArgs e)
        {

            TextBox txt = (TextBox)sender;
            RepeaterItem rpt = (RepeaterItem)txt.Parent;
            txt = (TextBox)rpt.FindControl("txtQtde");
            Label LblTotal = (Label)rpt.FindControl("LblTotal");
            Label LblValor = (Label)rpt.FindControl("lblPrecoVenda");
            Label codprod = (Label)rpt.FindControl("Lblcodprod");
            int Id = Convert.ToInt32(Session["Cli_ID"]);
            Label Nome = (Label)rpt.FindControl("lblNomeProd");
            LblTotal.Text = LblValor.Text;

            if (txt.Text == string.Empty)
            {
                txt.Text = "1";
            }
            int qtde = Convert.ToInt32(txt.Text);

            int id = Convert.ToInt16(codprod.Text);
            //qtde = verifica_qtd_prod(qtde, id);
            qtde = Convert.ToInt32(txt.Text);
            rptProdutos.DataBind();
            double valor = Convert.ToDouble(LblValor.Text);
            LblTotal.Text = (valor * qtde).ToString("##0.00");
            CalculaTotais();
            lblQtdeVol.Text = Convert.ToString(Session["QtdeVol"]);
            lblValorTotal.Text = Convert.ToString(Session["ValorTotal"]);
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update Tb_carrinho set Qtd =@Qtd  where  cod_cli =@cod_cli  and produto =@Produto  " + " Update Tb_lista_Historico set Qtd =@Qtd  where  cod_cli =@cod_cli  and produto =@Produto ";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@cod_cli", Id);
            cmd.Parameters.AddWithValue("@Produto", Nome.Text);
            cmd.Parameters.AddWithValue("@Qtd", qtde);
            cmd.ExecuteNonQuery();
            cn.Close();
            rptProdutos.DataBind();




        }
        private void PeencheEditaProduto()
        {
            List<Produto> f = (List<Produto>)Session["Carrinho"];
            foreach (RepeaterItem item in rptProdutos.Items)
            {
                Produto prod = f.Find(p => p.Id == Convert.ToInt32((item.FindControl("lblIdProd") as Label).Text));
                if (prod != null)
                {

                    Label Id = (Label)item.FindControl("lblIdProd");
                    Label Nome = (Label)item.FindControl("lblNomeProd");
                    Label Marca = (Label)item.FindControl("lblMarca");
                    Label Categoria = (Label)item.FindControl("lblCategoria");
                    Label Valor_Venda = (Label)item.FindControl("lblPrecoVenda");
                    TextBox Quantidade = (TextBox)item.FindControl("txtQtde");
                }
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            LinkButton lnk = (LinkButton)sender;
            RepeaterItem rpti = (RepeaterItem)lnk.Parent;
            int Id = Convert.ToInt32(Session["Cli_ID"]);
            Label Nome = (Label)rpti.FindControl("lblNomeProd");
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete From tb_carrinho where cod_cli =@cod_cli  and produto =@Produto " + "Delete From Tb_lista_Historico  where cod_cli =@cod_cli  and produto =@Produto ";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@cod_cli", Id);
            cmd.Parameters.AddWithValue("@Produto", Nome.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            rptProdutos.DataBind();






        }

        private void CalculaTotais()
        {
            double VTot = 0;
            int TVol = 0;
            foreach (RepeaterItem item in rptProdutos.Items)
            {
                TextBox txt = (TextBox)item.FindControl("txtQtde");
                if (txt.Text != "")
                {
                    TVol += Convert.ToInt32((item.FindControl("txtQtde") as TextBox).Text);
                    VTot += Convert.ToDouble((item.FindControl("lblPrecoVenda") as Label).Text);
                }
            }
            Label lblQtdeVol = (Label)rptProdutos.Controls[rptProdutos.Controls.Count - 1].FindControl("lblQtdeVol");
            Label lblValorTotal = (Label)rptProdutos.Controls[rptProdutos.Controls.Count - 1].FindControl("lblTotal");
            Session["QtdeVol"] = TVol.ToString();
            Session["ValorTotal"] = VTot.ToString("#,##0.00");
        }

        protected void rptProdutos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CalculaTotais();


            rptProdutos.Visible = true;
            int Id = Convert.ToInt32(Session["Cli_ID"]);
            //SELECT SUM(Total) Total  FROM Tb_carrinho WHERE (cod_cli = ?)
            SqlConnection con = new SqlConnection();
            con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand(); ///  joga o valor total no label da pagina

            cmd.CommandText = ("SELECT SUM(Total) Total  FROM Tb_carrinho WHERE cod_cli =" + Id + "");
            cmd.Connection = con;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            lblValorTotal.Text = Convert.ToString(dr["Total"]);
            lblQtdeVol.Text = Convert.ToString(Session["QtdeVol"]);
            Session["ValorTotal"] = lblValorTotal.Text;
            Session["QtdeVol"] = lblQtdeVol.Text;
            if (lblQtdeVol.Text == "0")
            {
                rptProdutos.Visible = false;
                btnFinalizar.Enabled = false;
                BtnCalcularFrete.Enabled = false;


            }
            if (lblQtdeVol.Text != "0")
            {
                rptProdutos.Visible = true;
                btnFinalizar.Enabled = true;
                BtnCalcularFrete.Enabled = true
                    ;


            }


        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (gvEndereco.Visible == false)
            {
                MSG("Informe o cep para calculo do Frete !!!");
                return;
            }
            else
            {

                inserir_pedido();
                atrelar_ped_carrinho();
                up_carrinho();
                Baixa_no_estoque();
                int Id = Convert.ToInt32(Session["Cli_ID"]);
                SqlConnection cn = clsDAO.conexao();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Delete From tb_carrinho where cod_cli = @cod_cli ";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@cod_cli", Id);
                cmd.ExecuteNonQuery();
                cn.Close();
                rptProdutos.DataBind();
                if (ddlForma_de_pagamento.SelectedValue == "1")
                {
                    Response.Redirect("Resumo.aspx");
                }
                else
                {

                    Response.Redirect("www.pagSeguro.com/");
                }
            }
        }

        public void inserir_pedido()
        {

            int id_cli = Convert.ToInt32(Session["Cli_ID"]);//retorna  Id do cliente logado e atribui na variavel 
            // para que seja utilizada como parametro  no comando de insert 
            string Status = "Aberto";//como padrão o pedido fica aberto pois é um novo pedido
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into tb_Pedido values ( @Cod_cli,@Data_Venda_Ped,@Data_Entrega_Ped,@Status_Ped,@Forma_de_pagamento,@Valor_Total)";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@Cod_cli", id_cli);
            cmd.Parameters.AddWithValue("@Data_Venda_Ped", DateTime.Now);
            cmd.Parameters.AddWithValue("@Data_Entrega_Ped", DateTime.Now.AddDays(7));// como padrão o pedido tem um prazo estimado de 7 dias para ser entregue ao cliente .
            cmd.Parameters.AddWithValue("@Status_Ped", Status);
            cmd.Parameters.AddWithValue("@Forma_de_pagamento", ddlForma_de_pagamento.SelectedValue);
            cmd.Parameters.AddWithValue("@Valor_Total", lblValorTotal.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void atrelar_ped_carrinho()
        {
            int id_cli = Convert.ToInt32(Session["Cli_ID"]);
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select MAX(Id_Pedido)NovoPedido from Tb_Pedido  where  cod_cli =@cod_cli  ";
            cmd1.Connection = cn;
            cmd1.Parameters.AddWithValue("@cod_cli", id_cli);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();

            int id_pedido = Convert.ToInt32(dr["NovoPedido"]);
            Session["NovoPedido"] = id_pedido;
            cn.Close();


        }

        public void up_carrinho()
        {
            int id_cli = Convert.ToInt32(Session["Cli_ID"]);
            int id_pedido = Convert.ToInt32(Session["NovoPedido"]);
            SqlConnection cn2 = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Tb_lista_Historico set Cod_Pedido = @Cod_Pedido where  cod_cli = @cod_cli and cod_Pedido=0";
            cmd.Connection = cn2;
            cmd.Parameters.AddWithValue("@cod_cli", id_cli);
            cmd.Parameters.AddWithValue("@Cod_Pedido", id_pedido);
            cmd.ExecuteNonQuery();
            cn2.Close();

        }
        public void deletar_lista_historico()
        {



        }

        protected void BtnCalcularFrete_Click(object sender, EventArgs e)
        {
            if (TxtCep.Text != "")
            {
                gvEndereco.Visible = true;
                gvEndereco.DataBind();
            }
            else
            {
                MSG("INforme um Cep Valido ");
            }

        }

        public int verifica_qtd_prod(int qtd_text, int cod_prod)
        {

            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Qtd_Prod_Estoq from Tb_Prod_Estoque where Id_Prod_Estq =@Id_Prod_Estq";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@Id_Prod_Estq", cod_prod);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            int qtd = Convert.ToInt16(dr["Qtd_Prod_Estoq"]);
            if (qtd_text > qtd)
            {

                MSG("quantidade acima do limite em estoque !!! Voce só pode levar no maximo:" + qtd);

            }
            return qtd;

        }

        public void Baixa_no_estoque()
        {
            foreach (RepeaterItem Item in rptProdutos.Items)
            {
                Label lblIdProd = (Label)Item.FindControl("Lblcodprod");
                TextBox lblqtd = (TextBox)Item.FindControl("txtQtde");
                Session["lblIdProd"] = lblIdProd.Text;
                Session["lblqtd"] = lblqtd.Text;
                if (lblIdProd.Text != "")
                {

                    int qtd_Compra;
                    int qtd_Estoque;
                    int id_produto;

                    id_produto = Convert.ToInt16(Session["lblIdProd"]);
                    qtd_Compra = Convert.ToInt16(Session["lblqtd"]);

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select Qtd_Prod_Estoq from Tb_Prod_Estoque where Id_Prod_Estq = " + id_produto;
                    cmd.Connection = clsDAO.conexao();
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    qtd_Estoque = Convert.ToInt16(dr["Qtd_Prod_Estoq"]);

                    int baixa = qtd_Estoque - qtd_Compra;

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandType = System.Data.CommandType.Text;
                    cmd2.CommandText = "update Tb_Prod_Estoque set Qtd_Prod_Estoq =@Qtd_Prod_Estoq where Id_Prod_Estq = " + id_produto;
                    cmd2.Parameters.AddWithValue("@Qtd_Prod_Estoq", baixa);
                    cmd2.Connection = clsDAO.conexao();
                    cmd2.ExecuteNonQuery();
                }

            }
        }

    }



}
