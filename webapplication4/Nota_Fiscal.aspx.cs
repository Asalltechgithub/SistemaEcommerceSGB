using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Nota_Fiscal : System.Web.UI.Page
    {
        int cod_pedido;
        double total;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblNum_Pedido.Text  = Convert.ToString(Session["pedido"]);
            total = Convert.ToDouble(Session["total"]);
            txtValor_total.Text = Convert.ToString(String.Format("{0:c}",total));
            Carregar_nota();
        }
        public void Carregar_nota() 
        { 
            string nome;
            double val_Frete;

            nome = Convert.ToString(Session["NomeDestinatirio"]);
            val_Frete = Convert.ToDouble(Session["val_Frete"]);
            txtDestinatario.Text = nome;
            txtRazao_social.Text = "The Globo Games LTDA ";
            Txt_CNPJ.Text = "40.516.040/0001-05";
            txtDatad_emi.Text = Convert.ToString(DateTime.Now.Date.Date);
            txtEndereco.Text = "Rua Doze de fevereiro Nº 300 ";
            txtBairro.Text = "Bangu";
            txtCEP.Text = "21810052";
            txtDatadeSaida.Text = Convert.ToString(DateTime.Now.Date.Date);
            txtMunicipio.Text ="Rio de Janeiro";
            txtUF.Text = "RJ";
            txtInscricaoEstadual.Text = "87.435.58-0";
            txtHoraSaida.Text = Convert.ToString(DateTime.Now.TimeOfDay);
            lblValorfrete.Text = Convert.ToString(String.Format("{0:c}", val_Frete));
            lbl_Nome_Cliente.Text = nome;
        }
        
        
    }
}