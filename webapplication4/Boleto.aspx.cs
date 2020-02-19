using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;




namespace WebApplication4
{
    public partial class Boleto : System.Web.UI.Page
    {
      double valor_doc;
        protected void Page_Load(object sender, EventArgs e)
        {
            Carregar_boleto();
        }
        
        public void Carregar_boleto() 
        {
            valor_doc = Convert.ToDouble(Session["val_total"]);
            txtCOd_principal.Text = "63748572920.234349894.545454334.454543.45345-0001";
            txtLocal_pag.Text = "Antes do vencimento em todos os bancos .";
            txtCedende.Text = "The Globo Games LTDA ";
            txtData_documento.Text = Convert.ToString(DateTime.Now.Date.ToString("dd/MM/yyyy"));
            txtNum_doc.Text = "7765";
            txt_Especie_doc.Text = string.Empty;
            txtAceite.Text = "N";
            txtData_proce.Text = Convert.ToString(DateTime.Now.Date.ToString("dd/MM/yyyy"));
            txtCod_banco.Text = String.Empty;
            txtCarteira.Text = "18078";
            txtEspecie.Text = "R$";
            txtQtd.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtVencimento.Text = Convert.ToString(DateTime.Now.Date.AddDays(4).ToString("dd/MM/yyyy"));
            txtAgencia.Text = "16013011.6013301034308E";
            txtValor_Documento.Text = Convert.ToString(string.Format("{0:C}", valor_doc));
            txtDesconto.Text = "R$ 0,00";
            txtMulta_juros.Text = "R$ 0,00";
            txtOutras_deducoes.Text = string.Empty;
            txt_acrecimos.Text = string.Empty;
            txtValor_cobrado.Text = Convert.ToString(string.Format("{0:C}",valor_doc));

        }
       
       
    }
}