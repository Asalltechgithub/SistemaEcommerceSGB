using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Projeto.SGB.Dao;
using System.Data;
using WebMatrix.WebData;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace WebApplication4
{
    public partial class Carrinho_de_Compras : System.Web.UI.Page
    {
        int Tipo_Pedido;
        double Preco_frete;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["MSG"] = null;
            Valor_frete();

            
            TxtValores.Text = " Os produtos vendidos serão entregues Somente em território nacional (Brasil). o Frete é de " + string.Format("{0:c}", Convert.ToString(Preco_frete)) + " por item .";

            if (ddlForma_de_pagamento.SelectedValue == "2")
            {
                Panelcartao.Visible = true;
                LblNunCartao.Visible = true;
                txtNun_Cartao.Visible = true;
                ddlBandeira.Visible = true;
                ddlParcelas.Visible = true;
                lblVal_Parcela.Visible = true;
                double valtotal = Convert.ToDouble(lblValorTotal.Text);
                double valParcela = valtotal / Convert.ToDouble(ddlParcelas.Text);
                lblVal_Parcela.Text = Convert.ToString(String.Format("{0:G}", valParcela));
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
            qtde = verifica_qtd_prod(qtde, id);

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
            Calculafrete();







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

                lblVal_Frete.Text = "0";
                lblMsgCar_vazio.Visible = true;
                lblMsgCar_vazio.Text = "Sem itens no carrinho";


            }
            if (lblQtdeVol.Text != "0")
            {
                rptProdutos.Visible = true;
                btnFinalizar.Enabled = true;

                lblMsgCar_vazio.Visible = false;
                lblMsgCar_vazio.Text = "";

                lblForma_de_Pagamento.Visible = true;
                ddlForma_de_pagamento.Visible = true;

                Calculafrete();



            }






        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (ddlForma_de_pagamento.Text == "2")
            {

                if (txtNun_Cartao.Text == string.Empty && txtDigitoverificador.Text == string.Empty)
                {
                    string msg;
                    msg = ("Digite o numero do cartão e o digito verificador do mesmo");
                    MSG(msg);
                    return;
                }
                if (txtDestinatario.Text == string.Empty || txtEndereco.Text == string.Empty || txtCidade.Text == string.Empty || txtBairro.Text == string.Empty || txtCEP.Text == string.Empty || txtUF.Text == string.Empty)
                {

                    MSG("Todos o campos de Endereço  de envio devem ser Preenchidos ! ");
                    return;

                }
                    inserir_pedido();
                    atrelar_ped_carrinho();
                    up_carrinho();
                    Baixa_no_estoque();
                    enviar_Email();
                    int Id = Convert.ToInt32(Session["Cli_ID"]);
                    SqlConnection cn = clsDAO.conexao();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "Delete From tb_carrinho where cod_cli = @cod_cli ";
                    cmd.Connection = cn;
                    cmd.Parameters.AddWithValue("@cod_cli", Id);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    rptProdutos.DataBind();
                    Session["MSG"] = "o produto será entregue num prazo de 7(sete) dias uteis após ao envio";
                    Response.Redirect("Resumo.aspx");
                
                
            }

                else
                {
                    if (txtDestinatario.Text == string.Empty || txtEndereco.Text == string.Empty || txtCidade.Text == string.Empty || txtBairro.Text == string.Empty || txtCEP.Text == string.Empty || txtUF.Text == string.Empty)
                    {

                        MSG("Todos o campos de Endereço  de envio devem ser Preenchidos ! ");
                        return;


                    }
                    else
                    {



                        inserir_pedido();
                        atrelar_ped_carrinho();
                        up_carrinho();
                        Baixa_no_estoque();
                        enviar_Email();
                        int Id = Convert.ToInt32(Session["Cli_ID"]);
                        SqlConnection cn = clsDAO.conexao();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "Delete From tb_carrinho where cod_cli = @cod_cli ";
                        cmd.Connection = cn;
                        cmd.Parameters.AddWithValue("@cod_cli", Id);
                        cmd.ExecuteNonQuery();
                        cn.Close();
                        rptProdutos.DataBind();
                        Session["MSG"] = "o produto será entregue num prazo de 7(sete) dias uteis após ao envio";
                        Response.Redirect("Resumo.aspx");


                    }
                }
            }
        


        public void inserir_pedido()
        {

            int id_cli = Convert.ToInt32(Session["Cli_ID"]);//retorna  Id do cliente logado e atribui na variavel 
            // para que seja utilizada como parametro  no comando de insert 

            double valor_Frete = Convert.ToDouble(Session["valor_Frete"]);
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into tb_Pedido values ( @Cod_cli,@Data_Venda_Ped, @Data_Envio_Ped, @Data_Entrega_Ped ,@Status_Ped ,@Forma_de_pagamento,@Valor_Frete , @Valor_Total,@Endereco_Envio, @UF_Envio,@Cidade_Envio, @Bairro_Envio,@CEP_Envio,@Nome_Destinatario,@Num_Cartao,@Bandeira,@Parcelas,@Valor_parcelas)";
            cmd.Connection = cn;
            cmd.Parameters.AddWithValue("@Cod_cli", id_cli);

            cmd.Parameters.AddWithValue("@Data_Venda_Ped", DateTime.Now.Date);
            cmd.Parameters.AddWithValue("@Data_Envio_Ped", DateTime.Now.Date.AddDays(7));
            cmd.Parameters.AddWithValue("@Data_Entrega_Ped", DateTime.Now.Date.AddDays(14));
            if (ddlForma_de_pagamento.SelectedValue == "1")
            {
                cmd.Parameters.AddWithValue("@Status_Ped", "Aberto"); //como padrão o pedido fica aberto pois é um novo pedido
                cmd.Parameters.AddWithValue("@Num_Cartao", @"N\A");
                cmd.Parameters.AddWithValue("@Bandeira", @"N\A");
                cmd.Parameters.AddWithValue("@Parcelas", 0);
                cmd.Parameters.AddWithValue("@Valor_parcelas", 0);

            }
            if (ddlForma_de_pagamento.SelectedValue == "2")
            {
                cmd.Parameters.AddWithValue("@Status_Ped", "Confirmado");
                cmd.Parameters.AddWithValue("@Num_Cartao", txtNun_Cartao.Text);
                cmd.Parameters.AddWithValue("@Bandeira", ddlBandeira.Text);
                cmd.Parameters.AddWithValue("@Parcelas", ddlParcelas.Text);
                cmd.Parameters.AddWithValue("@Valor_parcelas", Convert.ToDouble(String.Format("{0:D}", lblVal_Parcela.Text)));
            }
            cmd.Parameters.AddWithValue("@Forma_de_pagamento", ddlForma_de_pagamento.SelectedValue);
            cmd.Parameters.AddWithValue("@Valor_Frete", valor_Frete);
            cmd.Parameters.AddWithValue("@Valor_Total", lblValorTotal.Text);
            if (DropDownList1.Text == "Opcional")
            {

                cmd.Parameters.AddWithValue("@Endereco_Envio", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@UF_Envio", txtUF.Text);
                cmd.Parameters.AddWithValue("@Cidade_Envio", txtCidade.Text);
                cmd.Parameters.AddWithValue("@Bairro_Envio", txtBairro.Text);
                cmd.Parameters.AddWithValue("@CEP_Envio", txtCEP.Text);
                cmd.Parameters.AddWithValue("@Nome_Destinatario", txtDestinatario.Text);



            }
            if (DropDownList1.Text == "Endereço Cadastrado")
            {

                cmd.Parameters.AddWithValue("@Endereco_Envio", txtEndereco.Text);
                cmd.Parameters.AddWithValue("@UF_Envio", txtUF.Text);
                cmd.Parameters.AddWithValue("@Cidade_Envio", txtCidade.Text);
                cmd.Parameters.AddWithValue("@Bairro_Envio", txtBairro.Text);
                cmd.Parameters.AddWithValue("@CEP_Envio", txtCEP.Text);
                cmd.Parameters.AddWithValue("@Nome_Destinatario", txtDestinatario.Text);
            }
            Session["lblValorTotal"] = lblValorTotal.Text;
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
            cmd.CommandText = "update Tb_lista_Historico set Cod_Pedido = @Cod_Pedido  where  cod_cli = @cod_cli and cod_Pedido=0";
            cmd.Connection = cn2;
            cmd.Parameters.AddWithValue("@cod_cli", id_cli);
            cmd.Parameters.AddWithValue("@Cod_Pedido", id_pedido);

            cmd.ExecuteNonQuery();
            cn2.Close();

        }
        protected void BtnCalcularFrete_Click(object sender, EventArgs e)
        {

            lblForma_de_Pagamento.Visible = true;
            ddlForma_de_pagamento.Visible = true;

            Calculafrete();


        }
        public void Calculafrete()
        {
            int id_cli = Convert.ToInt32(Session["Cli_ID"]);
            string regiao;
            double val_Frete;
            int qtd_Vol = Convert.ToInt16(lblQtdeVol.Text);
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
                qtd_text = 1;
            }
            return qtd_text;

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
        public void verifica_credito() // procedimento de compra com cartão de credito 
        {
            int id = Convert.ToInt16(Session["Cli_ID"]);
            double valor_Compra = Convert.ToDouble(lblValorTotal.Text);
            double valor_Cred_Cli;
            double debitar;
            SqlDataReader dr;
            SqlConnection con = new SqlConnection();
            con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = ("select Valor_credito from Tb_credito where Cod_Cli=@Cod_Cli and Nun_Cartao=@Nun_Cartao");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Cod_Cli", id);
            cmd.Parameters.AddWithValue("@Nun_Cartao", txtNun_Cartao.Text);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows == true)
            {

                valor_Cred_Cli = Convert.ToDouble(dr["Valor_credito"]);
                if (valor_Compra < valor_Cred_Cli)
                {
                    SqlConnection cn = new SqlConnection();
                    cn = clsDAO.conexao();
                    debitar = valor_Cred_Cli - valor_Compra;
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = ("update Tb_credito set Valor_credito=@Valor_credito Where Cod_Cli=@Cod_Cli ");
                    cmd2.Connection = cn;
                    cmd2.Parameters.AddWithValue("@Cod_Cli", id);
                    cmd2.Parameters.AddWithValue("@Valor_credito", debitar);
                    cmd2.ExecuteNonQuery();
                    cn.Close();

                    atrelar_ped_carrinho();
                    up_carrinho();
                    Baixa_no_estoque();
                    int Id = Convert.ToInt32(Session["Cli_ID"]);
                    SqlConnection cn3 = clsDAO.conexao();
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandText = "Delete From tb_carrinho where cod_cli = @cod_cli ";
                    cmd3.Connection = cn3;
                    inserir_pedido();
                    cmd3.Parameters.AddWithValue("@cod_cli", Id);
                    cmd3.ExecuteNonQuery();
                    cn3.Close();
                    rptProdutos.DataBind();
                    Session["MSG"] = "Seu pagamento foi Autorizado! Seu credito agora é de:" + string.Format("{0:C}", debitar)
                                   + " O produto será entregue num prazo de 7(sete) dias uteis após ao envio";

                    Response.Redirect("Resumo.aspx");

                }
                else
                {

                    MSG("Transação não autorizada !!! Seu credito  é de:" + string.Format("{0:C}", valor_Cred_Cli));
                    return;
                }


            }
            else
            {
                MSG("Cliente não posui Cartão Cadastrado ou o numero do cartão é invalido");
                return;

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Session["Cli_ID"]);
            SqlConnection cn3 = clsDAO.conexao();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "Delete From tb_carrinho where cod_cli = @cod_cli ";
            cmd3.Connection = cn3;
            cmd3.Parameters.AddWithValue("@cod_cli", Id);
            cmd3.ExecuteNonQuery();
            cn3.Close();
            rptProdutos.DataBind();
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
        public void enviar_Email()
        {
            string Email;
            int Id = Convert.ToInt32(Session["Cli_ID"]);
            SqlConnection con = clsDAO.conexao();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Email from Tb_Usuario where Id = " + Id;
            cmd.Connection = con;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                dr.Read();
                Email = Convert.ToString(dr["Email"]);
                string nomeMail = "contato@provedor.com.br";
                string concatBody = "Você tem uma nova compra verifique no site : " + "http://localhost:55118/Cliente/Menu_Cli.aspx";
                string destinarioEmail = Email;
                string remetenteEmail = "theglobogames@gmail.com";//estou usando um gmail // mais poderia ser qualquer 1
                string remetenteSenha = "123theglobogames";

                MailMessage mail = new MailMessage();
                mail.To.Add(destinarioEmail);
                mail.From = new MailAddress(nomeMail, "theglobogames@gmail.com", System.Text.Encoding.UTF8);
                mail.Subject = "Nova Compra ";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = concatBody;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High; //Prioridade do E-Mail // no caso deixei como alta
                SmtpClient client = new SmtpClient(); //Adicionando as credenciais do seu e-mail e senha:
                client.Credentials = new System.Net.NetworkCredential(remetenteEmail, remetenteSenha);
                client.Port = 587; // Esta porta ‚ a utilizada pelo Gmail para envio
                client.Host = "smtp.gmail.com"; //Definindo o provedor que ir  disparar o e-mail
                client.EnableSsl = true; //Gmail trabalha com Server Secured Layer
                try
                {
                    client.Send(mail);
                    // MSG("Email Enviado com Sucesso");

                }
                catch (Exception ex)
                {
                    MSG("Ocorreu um erro ao enviar:" + ex.Message);

                }

            }




        }

        protected void ddlParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            double valtotal = Convert.ToDouble(lblValorTotal.Text);
            double valParcela = valtotal / Convert.ToDouble(ddlParcelas.Text);
            lblVal_Parcela.Text = Convert.ToString(String.Format("{0:G}", valParcela));
        }

        public void Valor_frete()
        {
            SqlConnection cn3 = clsDAO.conexao();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "select* from tb_Frete";
            cmd3.Connection = cn3;
            SqlDataReader drfrete = cmd3.ExecuteReader();
            drfrete.Read();
            Preco_frete = Convert.ToDouble(drfrete["valor_frete"]);

        }


    }
}


