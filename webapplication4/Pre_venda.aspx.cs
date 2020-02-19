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
    public partial class Pre_venda : System.Web.UI.Page
    {
        double frete;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            


            if (ddlForma_de_pagamento.SelectedValue == "2")
            {
                Panelcartao.Visible = true;
                LblNunCartao.Visible = true;
                txtNun_Cartao.Visible = true;
                ddlBandeira.Visible = true;
                ddlParcelas.Visible = true;
                lblVal_Parcela.Visible = true;
            }
            if (ddlForma_de_pagamento.SelectedValue == "1")
            {
                Panelcartao.Visible = false;
                LblNunCartao.Visible = false;
                txtNun_Cartao.Visible = false;
                ddlBandeira.Visible = false;
                ddlParcelas.Visible = false;
                lblVal_Parcela.Visible = false;
            }
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
                prencheendereco();
            }

            SqlConnection cn3 = clsDAO.conexao();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "select* from tb_Frete";
            cmd3.Connection = cn3;
            SqlDataReader drfrete = cmd3.ExecuteReader();
            drfrete.Read();
            frete = Convert.ToDouble(drfrete["valor_frete"]);
            TxtValores.Text = "O Valor do frete por item  é  : R$ " + frete + ",00";
            if (ddlForma_de_pagamento.SelectedValue == "2")
            {
                LblNunCartao.Visible = true;
                txtNun_Cartao.Visible = true;
            }
            if (ddlForma_de_pagamento.SelectedValue == "1")
            {
                LblNunCartao.Visible = false;
                txtNun_Cartao.Visible = false;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlForma_de_pagamento.SelectedValue == "2")
            {
                
                if (txtNun_Cartao.Text == string.Empty)
                {
                    MSG("DIgite o numero do cartão de Crédito !");
                    return;
                }
            }
            if (txtQTd.Text == "0")
            {
                MSG("A quantidade deve ser maior que 0 ");
                txtQTd.Text = string.Empty;
                return;
            }
            if (txtQTd.Text == string.Empty)
            {
                MSG("Coloque a quantidade que e necessario");
                txtQTd.Text = string.Empty;
                return;
            }
            DateTime lancamento = Convert.ToDateTime(Session["dt_lancamento"]);

            insert_historico();
            inserir_pedido();
            atrelar_ped_carrinho();
            up_carrinho();
            Baixa_no_estoque();
            Session["MSG"] = "O Produtos de Pré -Venda são enviados no dia do lancamento  " + lancamento + "o produto será entregue num prazo de 7(sete) dias uteis após ao envio";
            Response.Redirect("Resumo.aspx");


        }

        protected void DataList1_ItemDataBound1(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblcodprod = (Label)e.Item.FindControl("Label7");
                Label lblnome = (Label)e.Item.FindControl("Nome_Prod_EstqLabel");
                Label lblmarca = (Label)e.Item.FindControl("Marca_Prod_EstoqLabel");
                Label lblCategoria = (Label)e.Item.FindControl("Categoria_Prod_EstoqLabel");
                Label lblpreco = (Label)e.Item.FindControl("Label2");
                Label lblTipo = (Label)e.Item.FindControl("lblTipoVenda");
                Image img = (Image)e.Item.FindControl("Image2");

                Session["Cod_prd"] = lblcodprod.Text;
                Session["Nome"] = lblnome.Text;
                Session["Marca"] = lblmarca.Text;
                Session["Categoria"] = lblCategoria.Text;
                Session["preco"] = lblpreco.Text;
                Session["img"] = img.ImageUrl;
                Session["Tipo_venda"] = lblTipo.Text;
                lblValorTotal.Text = Convert.ToString(Session["preco"]);

            }
        }
        public void up_carrinho()
        {
            int id_cli = Convert.ToInt32(Session["Cli_ID"]);
            int id_pedido = Convert.ToInt32(Session["NovoPedido"]);
            SqlConnection cn2 = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Tb_Historico_prevenda set Cod_Pedido = @Cod_Pedido where  cod_cli = @cod_cli and cod_Pedido=0 and Tipo_Pedido = 2";
            cmd.Connection = cn2;
            cmd.Parameters.AddWithValue("@cod_cli", id_cli);
            cmd.Parameters.AddWithValue("@Cod_Pedido", id_pedido);
            cmd.ExecuteNonQuery();
            cn2.Close();

        }
        public void insert_historico()
        {


            int qtd = Convert.ToInt16(txtQTd.Text);
            int cod_ped = 0;
            int id_cli = Convert.ToInt32(Session["Cli_ID"]);
            int Cod_prd = Convert.ToInt32(Session["Cod_prd"]);
            string nome = Convert.ToString(Session["Nome"]);
            string marca = Convert.ToString(Session["Marca"]);
            string categoria = Convert.ToString(Session["Categoria"]);
            string preco = Convert.ToString(Session["preco"]);
            int tipo_venda = Convert.ToInt16(Session["Tipo_venda"]);
            string img = Convert.ToString(Session["img"]);

            if (id_cli == 0)
            {
                MSG("Faça o login para porder efetuar a compra !");
                return;
            }

            else
            {
                SqlConnection cn = clsDAO.conexao();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Tb_Historico_prevenda values ( @cod_cli,@Cod_Pedido,@Cod_prd ,@Produto,@Marca,@Qtd,@Categoria,@Valor,@Tipo_Pedido)";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@cod_cli", id_cli);
                cmd.Parameters.AddWithValue("@Cod_Pedido", cod_ped);
                cmd.Parameters.AddWithValue("@Cod_prd", Cod_prd);
                cmd.Parameters.AddWithValue("@Produto", nome);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Qtd", qtd);
                cmd.Parameters.AddWithValue("@Categoria", categoria);
                cmd.Parameters.AddWithValue("@Valor", Convert.ToDouble(preco));

                cmd.Parameters.AddWithValue("@Tipo_Pedido", tipo_venda);
                //cmd.Parameters.AddWithValue("@Foto", img);

                cmd.ExecuteNonQuery();
                cn.Close();

                rec_valtotal();

            }
        }
        public void atrelar_ped_carrinho()
        {
            int id_cli = Convert.ToInt32(Session["Cli_ID"]);
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select MAX(Id_Pre_Venda)NovoPedido from Tb_Pre_Venda  where  cod_cli =@cod_cli  ";
            cmd1.Connection = cn;
            cmd1.Parameters.AddWithValue("@cod_cli", id_cli);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();

            int id_pedido = Convert.ToInt32(dr["NovoPedido"]);
            Session["NovoPedido"] = id_pedido;
            cn.Close();


        }
        public void inserir_pedido()
        {

            int id_cli = Convert.ToInt32(Session["Cli_ID"]);//retorna  Id do cliente logado e atribui na variavel 
            // para que seja utilizada como parametro  no comando de insert 
            DateTime data_lanc = Convert.ToDateTime(Session["dt_lancamento"]);
            double total =Convert.ToDouble(lblValorTotal.Text);
            double valor_Frete = Convert.ToDouble(Session["valor_Frete"]);
            int cod_prod = Convert.ToInt16(Session["Cod_prd"]);

            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Tb_Pre_Venda values ( @Cod_cli,@Cod_Prod, @Data_Venda_Ped, @Data_Envio_Ped, @Data_Entrega_Ped ,@Status_Ped ,@Forma_de_pagamento,@Valor_Frete , @Valor_Total,@Endereco_Envio, @UF_Envio,@Cidade_Envio, @Bairro_Envio, @CEP_Envio,@Nome_Destinatario,@Num_cartao,@Bandeira,@Parcelas,@Valor_Parcelas)";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@Cod_cli", id_cli);
            cmd.Parameters.AddWithValue("@Cod_Prod", cod_prod);
            cmd.Parameters.AddWithValue("@Data_Venda_Ped", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@Data_Envio_Ped", data_lanc);
            cmd.Parameters.AddWithValue("@Data_Entrega_Ped", DateTime.Now.Date.AddDays(14));
            if (ddlForma_de_pagamento.SelectedValue == "1")
            {

                cmd.Parameters.AddWithValue("@Status_Ped", "Aberto"); //como padrão o pedido fica aberto pois é um novo pedido
                cmd.Parameters.AddWithValue("@Forma_de_pagamento", 1);
            }
            if (ddlForma_de_pagamento.SelectedValue == "2")
            {

                cmd.Parameters.AddWithValue("@Status_Ped", "Confirmado");
                cmd.Parameters.AddWithValue("@Forma_de_pagamento", 2);
            }

            cmd.Parameters.AddWithValue("@Valor_Frete", valor_Frete);

            cmd.Parameters.AddWithValue("@Valor_Total", total);
            if (DropDownList1.Text == "Opcional")
            {

                cmd.Parameters.AddWithValue("@Endereco_Envio", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@UF_Envio", txtUF.Text);
                cmd.Parameters.AddWithValue("@Cidade_Envio", txtCidade.Text);
                cmd.Parameters.AddWithValue("@Bairro_Envio", TxtBairro.Text);
                cmd.Parameters.AddWithValue("@CEP_Envio", txtCEP.Text);
                cmd.Parameters.AddWithValue("@Nome_Destinatario", txtDestinatario.Text);



            }
            if (DropDownList1.Text == "Endereço Cadastrado")
            {

                cmd.Parameters.AddWithValue("@Endereco_Envio", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@UF_Envio", txtUF.Text);
                cmd.Parameters.AddWithValue("@Cidade_Envio", txtCidade.Text);
                cmd.Parameters.AddWithValue("@Bairro_Envio", TxtBairro.Text);
                cmd.Parameters.AddWithValue("@CEP_Envio", txtCEP.Text);
                cmd.Parameters.AddWithValue("@Nome_Destinatario", txtDestinatario.Text);
            }
            if (ddlForma_de_pagamento.SelectedValue == "2")
            {

                cmd.Parameters.AddWithValue("@Num_Cartao", txtNun_Cartao.Text);
                cmd.Parameters.AddWithValue("@Bandeira", ddlBandeira.Text);
                cmd.Parameters.AddWithValue("@Parcelas", ddlParcelas.Text);
                cmd.Parameters.AddWithValue("@Valor_parcelas", lblVal_Parcela.Text);
            }
            if (ddlForma_de_pagamento.SelectedValue == "1")
            {

                cmd.Parameters.AddWithValue("@Num_Cartao", "N/a");
                cmd.Parameters.AddWithValue("@Bandeira", "N/a");
                cmd.Parameters.AddWithValue("@Parcelas", 0);
                cmd.Parameters.AddWithValue("@Valor_parcelas", 0);
            }
            cmd.ExecuteNonQuery();
            cn.Close();



        }
        public void rec_valtotal()
        {
            int id_cli = Convert.ToInt32(Session["Cli_ID"]);
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "select * from Tb_Historico_prevenda where  cod_cli =@cod_cli and Cod_Pedido=0  ";
            cmd1.Connection = cn;
            cmd1.Parameters.AddWithValue("@cod_cli", id_cli);
            SqlDataReader dr = cmd1.ExecuteReader();
            dr.Read();
            int total = Convert.ToInt32(dr["Total"]);
            Session["Total"] = total;
            cn.Close();

        }
        public int verifica_qtd_prod(int qtd_text, int cod_prod)
        {

            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Qtd_Prod_Estoq,Dt_lancamento_Prod_Estoq from Tb_Prod_Estoque where Id_Prod_Estq =@Id_Prod_Estq";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@Id_Prod_Estq", cod_prod);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            int qtd = Convert.ToInt16(dr["Qtd_Prod_Estoq"]);
            DateTime lancamento = Convert.ToDateTime(dr["Dt_lancamento_Prod_Estoq"]);
            Session["dt_lancamento"] = lancamento;
            if (qtd_text > qtd)
            {

                MSG("quantidade acima do limite em estoque !!! Voce só pode levar no maximo:" + qtd);
                qtd_text = 1;
            }
            return qtd_text;


        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }

        protected void txtQTd_TextChanged(object sender, EventArgs e)
        {

            int cod_prod = Convert.ToInt16(Session["Cod_prd"]);
            double preco = Convert.ToDouble(Session["preco"]);
            int qtd = verifica_qtd_prod(Convert.ToInt16(txtQTd.Text), cod_prod);
            txtQTd.Text = Convert.ToString(qtd);
            Session["qtd"] = txtQTd.Text;
            lblValorTotal.Text = Convert.ToString(preco * qtd);
            Calculafrete();
            double valtotal = Convert.ToDouble(lblValorTotal.Text);
            double valParcela = valtotal / Convert.ToDouble(ddlParcelas.Text);
            lblVal_Parcela.Text = Convert.ToString(String.Format("{0:G}", valParcela));
        }
        public void Baixa_no_estoque()
        {



            int qtd_Compra;
            int qtd_Estoque;
            int id_produto;

            id_produto = Convert.ToInt16(Session["Cod_prd"]);
            qtd_Compra = Convert.ToInt16(Session["qtd"]);

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
        public void Calculafrete()
        {
            int id_cli = Convert.ToInt32(Session["Cli_ID"]);
            double val_Frete;
            int qtd_Vol = Convert.ToInt16(Session["qtd"]);
            double val_total = Convert.ToDouble(lblValorTotal.Text);
            double valor_porqtd;
            SqlConnection cn3 = clsDAO.conexao();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "select* from tb_Frete";
            cmd3.Connection = cn3;
            SqlDataReader drfrete = cmd3.ExecuteReader();
            drfrete.Read();
            val_Frete = Convert.ToDouble(drfrete["valor_frete"]);
            valor_porqtd = qtd_Vol * val_Frete;
            val_total = val_total + valor_porqtd;
            lblValorTotal.Text = Convert.ToString(val_total);
            lblVal_Frete.Text = Convert.ToString(valor_porqtd);
            Session["valor_Frete"] = valor_porqtd;




        }
        //public void verifica_credito() // procedimento de compra com cartão de credito 
        //{
        //    DateTime lancamento = Convert.ToDateTime(Session["dt_lancamento"]);
        //    int id = Convert.ToInt16(Session["Cli_ID"]);
        //    double valor_Compra = Convert.ToDouble(lblValorTotal.Text);
        //    double valor_Cred_Cli;
        //    double debitar;
        //    SqlDataReader dr;
        //    SqlConnection con = new SqlConnection();
        //    con = clsDAO.conexao();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = ("select Valor_credito from Tb_credito where Cod_Cli=@Cod_Cli and Nun_Cartao=@Nun_Cartao");
        //    cmd.Connection = con;
        //    cmd.Parameters.AddWithValue("@Cod_Cli", id);
        //    cmd.Parameters.AddWithValue("@Nun_Cartao", txtNun_Cartao.Text);
        //    dr = cmd.ExecuteReader();
        //    dr.Read();
        //    if (dr.HasRows == true)
        //    {

        //        valor_Cred_Cli = Convert.ToDouble(dr["Valor_credito"]);
        //        if (valor_Compra < valor_Cred_Cli)
        //        {
        //            SqlConnection cn = new SqlConnection();
        //            cn = clsDAO.conexao();
        //            debitar = valor_Cred_Cli - valor_Compra;
        //            SqlCommand cmd2 = new SqlCommand();
        //            cmd2.CommandText = ("update Tb_credito set Valor_credito=@Valor_credito Where Cod_Cli=@Cod_Cli ");
        //            cmd2.Connection = cn;
        //            cmd2.Parameters.AddWithValue("@Cod_Cli", id);
        //            cmd2.Parameters.AddWithValue("@Valor_credito", debitar);
        //            cmd2.ExecuteNonQuery();
        //            cn.Close();

        //            insert_historico();
        //            inserir_pedido();
        //            atrelar_ped_carrinho();
        //            up_carrinho();
        //            Baixa_no_estoque();
        //            Session["MSG"] = "Seu pagamento foi Autorizado!"
        //            + " O Produto de Pré -Venda Será enviado no dia do lancamento : Dia :  " + lancamento + "O produto será entregue num prazo de 7(sete) dias uteis após ao envio";


        //            Response.Redirect("Resumo.aspx");

        //        }
        //        else
        //        {

        //            MSG("Transação não autorizada !!! ");
        //            return;
        //        }


        //    }
        //    else
        //    {
        //        MSG("Cliente não posui Cartão Cadastrado ou o numero do cartão é invalido");
        //        return;

        //    }
        //}
        public void prencheendereco()
        {
            int id;
            id = Convert.ToInt16(Session["Cli_ID"]);
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select* from Tb_Usuario Where Id =" + id;
            cmd.Connection = cn;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            txtEndereco.Text = Convert.ToString(dr["Endereco"]);
            txtCEP.Text = Convert.ToString(dr["CEP"]);
            txtCidade.Text = Convert.ToString(dr["Cidade"]);
            txtUF.Text = Convert.ToString(dr["UF"]);
            txtDestinatario.Text = Convert.ToString(dr["Nome"]);


        }
        public void limpar_campos_endereco()
        {
            txtEndereco.Text = string.Empty;
            txtCEP.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtUF.Text = string.Empty;
            txtDestinatario.Text = string.Empty;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Opcional")
            {
                txtEndereco.Enabled = true;
                txtCEP.Enabled = true;
                txtCidade.Enabled = true;
                txtUF.Enabled = true;
                limpar_campos_endereco();

            }
            else
            {
                txtEndereco.Enabled = false;
                txtCEP.Enabled = false;
                txtCidade.Enabled = false;
                txtUF.Enabled = false;
            }
            if (DropDownList1.SelectedValue == "Endereço Cadastrado")
            {
                prencheendereco();
            }
        }

        protected void ddlParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            double valtotal = Convert.ToDouble(lblValorTotal.Text);
            double valParcela = valtotal / Convert.ToDouble(ddlParcelas.Text);
            lblVal_Parcela.Text = Convert.ToString(String.Format("{0:G}", valParcela));
        }

    }


}