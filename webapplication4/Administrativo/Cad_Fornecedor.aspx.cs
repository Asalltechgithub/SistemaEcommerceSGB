using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.SGB.Dao;
using System.Data.SqlClient;
using ProjetoSGB_Model;

namespace WebApplication4
{
    public partial class Cad_Fornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack) 
            {
                Desabilita_campos(); 
            }
            if (lbl_Modo.Text == "") 
            { 
                btnEditar.Enabled = false; 
                btnSalvar.Enabled = false; 
            }

            lbl_message.Text = "";
            
        }


        protected void btnNovo_Click(object sender, EventArgs e)
        {
            lbl_Modo.Text = "MODO ICLUIR PRODUTO";
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            Habilita_campos();
            Limpar_campos();
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lbl_Modo.Text == "MODO ICLUIR PRODUTO")
            {


                Valida_campos();
                inserir();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Dados gravados com sucesso')", true);
                Limpar_campos();
                Desabilita_campos();
                gvFornecedores.DataBind();
                ddlCodFornecedor.DataBind();
                btnSalvar.Enabled = false;

            }
            if (lbl_Modo.Text == "MODO ALTERAR PRODUTO")
            {

                Valida_campos();
                alterar();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Dados alterados com sucesso')", true);
                Limpar_campos();
                Desabilita_campos();
                gvFornecedores.DataBind();
                ddlCodFornecedor.DataBind();
                btnSalvar.Enabled = false;
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lbl_Modo.Text = "MODO ALTERAR PRODUTO";
            Habilita_campos();
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;

        }
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            excluir();
            Desabilita_campos();
            Limpar_campos();
            gvFornecedores.DataBind();
            ddlCodFornecedor.DataBind();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", "alert('Dados Excluidos com sucesso')", true);


        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar_campos();
            Desabilita_campos();
            btnExcluir.Enabled = true;
            btnEditar.Enabled = false;
            btnSalvar.Enabled = false;
        }

        protected void gv_produtos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExcluir.Enabled = true;
            btnEditar.Enabled = true;
            int codigo = Convert.ToInt16(gvFornecedores.SelectedRow.Cells[2].Text);
            clsDAO.conexao();
            try
            {
                clsDAO.conexao();
                lbl_message.Text = "conexao ok";

            }
            catch (Exception ex)
            {
                lbl_message.Text = String.Format(" Erro {0}", ex.Message);
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Tb_Fornecedor where Id_Fornecedor = " + codigo;
            cmd.Connection = clsDAO.conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                ddlCodFornecedor.Text = Convert.ToString(gvFornecedores.SelectedRow.Cells[2].Text);
                txtRazao_social.Text = Convert.ToString((dr["For_Razao_Social"]));
                txtCnpj.Text = Convert.ToString(dr["For_CNPJ"]);
                txtTelefone.Text = Convert.ToString(dr["For_Telefone"]);
                txtEmail.Text = Convert.ToString(dr["For_Email"]);
                txtCidade.Text = Convert.ToString(dr["For_Cidade"]);
                TxtEndereco.Text = Convert.ToString(dr["For_Endereco"]);
                txtCEP.Text = Convert.ToString(dr["For_CEP"]);
                ddlStatus.Text = Convert.ToString(dr["For_Status"]);
                ddlUF.Text = Convert.ToString(dr["For_UF"]);
                clsDAO.conexao().Close();

            }
        }
        public void inserir()
        {

            Fornecedor f = new Fornecedor();
            f.Razao_Social = txtRazao_social.Text;
            f.CNPJ = txtCnpj.Text;
            f.Telefone = txtTelefone.Text;
            f.Email_Fornecedor = txtEmail.Text;
            f.CEP = txtCEP.Text;
            f.Endereco = TxtEndereco.Text;
            f.UF = ddlUF.Text;
            f.Cidade = txtCidade.Text;
            f.Status_Fornecedor =ddlStatus.Text;
            new Bussines_Fornecedor().Inserir_Fornecedor_cl(f);
        }
        public void alterar()
        {

            lbl_Modo.Text = "MODO ALTERAR PRODUTO";
            Fornecedor f = new Fornecedor();
            f.Cod = Convert.ToInt16(ddlCodFornecedor.Text);
            f.Razao_Social = txtRazao_social.Text;
            f.CNPJ = txtCnpj.Text;
            f.Telefone = txtTelefone.Text;
            f.Email_Fornecedor = txtEmail.Text;
            f.CEP = txtCEP.Text;
            f.Endereco = TxtEndereco.Text;
            f.UF = ddlUF.Text;
            f.Cidade = txtCidade.Text;
            f.Status_Fornecedor = ddlStatus.Text;
            new Bussines_Fornecedor().Alterar_Fornecedor_cl(f);
           
        }
        public void excluir()
        {
            int codprod = Convert.ToInt32(ddlCodFornecedor.Text);
            new Bussines_Fornecedor().excluir_Fornecedor_cl(codprod);
        }

        public void Habilita_campos()
        {
            txtRazao_social.Enabled = true;
            txtCnpj.Enabled = true;
          
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtCidade.Enabled = true;
            TxtEndereco.Enabled = true;
            txtCEP.Enabled = true;
            ddlUF.Enabled = true;
            ddlStatus.Enabled = true;
            ddlCodFornecedor.Enabled = true;
        }
        public void Desabilita_campos()
        {
            txtRazao_social.Enabled =false;
           
            txtCnpj.Enabled = false;
            
            
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtCidade.Enabled = false;
            TxtEndereco.Enabled = false;
            txtCEP.Enabled = false;
            ddlUF.Enabled = false;
            ddlStatus.Enabled = false;
            ddlCodFornecedor.Enabled = false;
        }
        public void Limpar_campos()
        {

             txtRazao_social.Text= string.Empty;
            
             txtCnpj.Text        = string.Empty;
            
             txtTelefone.Text    = string.Empty;
             txtEmail.Text       = string.Empty;
             txtCidade.Text      = string.Empty;
             TxtEndereco.Text    = string.Empty;
             txtCEP.Text = string.Empty;

        }
        public void Valida_campos()
        {
            if (txtRazao_social.Text== string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (txtCnpj.Text        == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (txtTelefone.Text    == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (txtEmail.Text       == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (txtCidade.Text      == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (TxtEndereco.Text    == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (txtCEP.Text         == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }

        }
    }
}