using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Projeto.SGB.Dao;

namespace WebApplication4
{
    public partial class Nota_fiscal_Prevenda : System.Web.UI.Page
    {
        int cod_pedido;
        double total;
        string nome;
        double val_Frete;
        int tipo_pagamento;
        string Forma_de_Pagamento;
        int Parcelas;
        string CPF;
        string RG;
        string Nome_Destinatario;
        string End_destino;
        string Bairro;
        string Cidade;
        string UF;
        string CEP;
        protected void Page_Load(object sender, EventArgs e)
        {
            cod_pedido = Convert.ToInt16(Session["pre_vendas"]);
            lblNum_Pedido.Text = Convert.ToString(cod_pedido);
            total = Convert.ToDouble(Session["total"]);
            txtValor_total.Text = Convert.ToString(String.Format("{0:c}", total));
            carrega_dados_Comprador();
            Carregar_nota();
        }
        public void Carregar_nota()
        {



            
            LblNome_Comprador.Text = nome;
            txtRazao_social.Text = "The Globo Games LTDA ";
            Txt_CNPJ.Text = "40.516.040/0001-05";
            txtDatad_emi.Text = Convert.ToString(DateTime.Now.Date.Date.ToString("dd-MM-yyyy"));
            txtEndereco.Text = "Rua Doze de fevereiro Nº 300 ";
            txtBairro.Text = "Bangu";
            txtCEP.Text = "21810052";
            txtDatadeSaida.Text = Convert.ToString(DateTime.Now.Date.Date.ToString("dd-MM-yyyy"));
            txtMunicipio.Text = "Rio de Janeiro";
            txtUF.Text = "RJ";
            txtInscricaoEstadual.Text = "87.435.58-0";
            txtHoraSaida.Text = String.Format("{0:HH:mm}", Convert.ToString(DateTime.Now.ToString("T")));
            lblValorfrete.Text = Convert.ToString(String.Format("{0:c}", val_Frete));
            lbl_Nome_Cliente.Text = nome;
            LblTipodepaga.Text = Forma_de_Pagamento;
            LblCPF.Text = CPF;
            LblRG.Text = RG;
            LblParcelas.Text = Convert.ToString(Parcelas);
            LblDestinatario.Text = Nome_Destinatario;
            lblEnd_Destino.Text = End_destino;
            LblBairro.Text = Bairro;
            LblCidade.Text = Cidade;
            LblUF.Text = UF;
            LblCEP.Text = CEP;
        }
        public void carrega_dados_Comprador()
        {
            int id_cliente;
            id_cliente = Convert.ToInt32(Session["Id_Cli"]);

            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from  Tb_Usuario where Id = " + id_cliente;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            nome = Convert.ToString(dr["Nome"]);
            CPF = Convert.ToString(dr["CPF"]);
            RG = Convert.ToString(dr["RG"]);

            SqlConnection cn2 = clsDAO.conexao();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "Select Nome_Destinatario,Endereco_Envio,Bairro_Envio,Cidade_Envio,UF_Envio,CEP_Envio,Forma_de_pagamento,Parcelas,Valor_Frete from  Tb_Pre_Venda as p inner join Tb_Historico_prevenda as hp on p.Id_Pre_Venda = hp.Cod_Pedido  where Id_Pre_Venda =" + cod_pedido;
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = cn2;
            SqlDataReader dr2 = cmd2.ExecuteReader();
            dr2.Read();
            Nome_Destinatario = Convert.ToString(dr2["Nome_Destinatario"]);
            End_destino = Convert.ToString(dr2["Endereco_Envio"]);
            Bairro = Convert.ToString(dr2["Bairro_Envio"]);
            Cidade = Convert.ToString(dr2["Cidade_Envio"]);
            UF = Convert.ToString(dr2["UF_Envio"]);
            CEP = Convert.ToString(dr2["CEP_Envio"]);
            tipo_pagamento = Convert.ToInt32(dr2["Forma_de_pagamento"]);
            if (tipo_pagamento == 2)
            {
                Forma_de_Pagamento = "Cartão de Crédito";
                Parcelas = Convert.ToInt32(dr2["Parcelas"]);
            }
            else
            {
                Forma_de_Pagamento = "Boleto";
                Parcelas = 0;
            }
            val_Frete = Convert.ToDouble(dr2["Valor_Frete"]);


        }


    }
}


