using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.SGB.Dao;
using System.Data.SqlClient;
using ProjetoSGB_Model;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;



namespace WebApplication4
{
    public partial class Cad_Produtos : System.Web.UI.Page
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
                Limpar_campos();
            }

            if (lbl_Modo.Text == "")
            {
                btnEditar0.Enabled = false;
                btnSalvar.Enabled = false;
            }

            lbl_message.Text = "";
        }
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            lbl_Modo.Text = "MODO ICLUIR PRODUTO";
            btnEditar0.Enabled = false;
            Limpar_campos();
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = true;
            Habilita_campos();
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lbl_Modo.Text == "MODO ICLUIR PRODUTO")
            {


                Valida_campos();
                inserir();
                Limpar_campos();
                Desabilita_campos();
                gv_produtos.DataBind();
                ddlCodigo_prod.DataBind();
                btnSalvar.Enabled = false;
                Response.Redirect("~/Administrativo/msg_Inserir_prod.aspx");

            }
            if (lbl_Modo.Text == "MODO ALTERAR PRODUTO")
            {

                Valida_campos();
                alterar();
                Limpar_campos();
                Desabilita_campos();
                gv_produtos.DataBind();
                ddlCodigo_prod.DataBind();
                btnSalvar.Enabled = false;
                Response.Redirect("~/Administrativo/Msg_Alterar_Prod.aspx");
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lbl_Modo.Text = "MODO ALTERAR PRODUTO";
            Habilita_campos();
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = false;
        }
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            excluir();
            Desabilita_campos();
            Limpar_campos();
            gv_produtos.DataBind();
            ddlCodigo_prod.DataBind();
            Response.Redirect("~/Administrativo/Msg_Excluir_Prod.aspx");


        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpar_campos();
            Desabilita_campos();
            btnExcluir.Enabled = true;
            btnEditar0.Enabled = false;
            btnSalvar.Enabled = false;
        }

        protected void gv_produtos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExcluir.Enabled = true;
            btnEditar0.Enabled = true;
            int codigo = Convert.ToInt16(gv_produtos.SelectedRow.Cells[1].Text);
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
            cmd.CommandText = "Select *  from Tb_Prod_Estoque where Id_Prod_Estq = " + codigo;
            cmd.Connection = clsDAO.conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ddlCodigo_prod.Text = Convert.ToString(gv_produtos.SelectedRow.Cells[1].Text);
                txtNome.Text = Convert.ToString(dr["Nome_Prod_Estq"]);
                ddlMarca.Text = Convert.ToString(dr["Marca_Prod_Estoq"]);
                ddlCategoria.Text = Convert.ToString(dr["Categoria_Prod_Estoq"]);
                TxtDTlancamento.Text = Convert.ToString(dr["Dt_lancamento_Prod_Estoq"]);
                txtQtdEstoque.Text = Convert.ToString(dr["Qtd_Prod_Estoq"]);
                txtValor.Text = Convert.ToString(String.Format("{0:0.00}", dr["Valor_Venda_Prod_Estoq"]));
                txtValor_compra.Text = Convert.ToString(String.Format("{0:0.00}", dr["Valor_Compra_Prod"]));
                txtDescricao.Text = Convert.ToString(dr["Descricao_Prod_Estoq"]);
                ddlFornecedor.Text = Convert.ToString(dr["Cod_For"]);
                imagem_prod.ImageUrl = Convert.ToString(dr["Foto_Prod_Estoq"]);
                ddlTipovenda.Text = Convert.ToString(dr["Tipo_Venda"]);


            }

            clsDAO.conexao().Close();
        }
        public void inserir()
        {

            lbl_Modo.Text = "MODO ICLUIR PRODUTO";
            Produto p = new Produto();
            p.Nome = txtNome.Text;
            p.Marca = ddlMarca.Text;
            p.Categoria = ddlCategoria.Text;
            p.Data = Convert.ToDateTime(TxtDTlancamento.Text);
            p.Quantidade = Convert.ToInt32(txtQtdEstoque.Text);
            p.Valor_Venda = Convert.ToDouble(txtValor.Text);
            p.Valor_Compra = Convert.ToDouble(txtValor_compra.Text);
            p.Descricao = txtDescricao.Text;
            p.codigo = Convert.ToInt32(ddlFornecedor.SelectedValue);
            Carrega_foto c = new Carrega_foto();
            p.Foto = imagem_prod.ImageUrl;
            p.Tipo = Convert.ToInt32(ddlTipovenda.SelectedValue);
            new Business_Produto().incluir(p);
        }
        public void alterar()
        {

            lbl_Modo.Text = "MODO ALTERAR PRODUTO";
            Produto p = new Produto();

            p.Id = Convert.ToInt16(ddlCodigo_prod.Text);
            p.Nome = txtNome.Text;
            p.Marca = ddlMarca.Text;
            p.Categoria = ddlCategoria.Text;
            p.Data = Convert.ToDateTime(TxtDTlancamento.Text);
            p.Quantidade = Convert.ToInt32(txtQtdEstoque.Text);
            p.Valor_Venda = Convert.ToDouble(txtValor.Text);
            p.Valor_Compra = Convert.ToDouble(txtValor_compra.Text);
            p.Descricao = txtDescricao.Text;
            p.codigo = Convert.ToInt32(ddlFornecedor.SelectedValue);
            Carrega_foto c = new Carrega_foto();
            p.Foto = imagem_prod.ImageUrl;
            p.Tipo = Convert.ToInt32(ddlTipovenda.SelectedValue);

            new Business_Produto().Alterar(p);
        }
        public void excluir()
        {
            int codprod = Convert.ToInt32(ddlCodigo_prod.Text);
            new Business_Produto().excluir_produto(codprod);
        }

        public void Habilita_campos()
        {
            txtNome.Enabled = true;
            ddlMarca.Enabled = true;
            ddlCategoria.Enabled = true;
            TxtDTlancamento.Enabled = true;
            txtQtdEstoque.Enabled = true;
            txtValor.Enabled = true;
            txtValor_compra.Enabled = true;
            txtDescricao.Enabled = true;
            ddlFornecedor.Enabled = true;
            ddlTipovenda.Enabled = true;

        }
        public void Desabilita_campos()
        {
            txtNome.Enabled = false;
            ddlMarca.Enabled = false;
            ddlCategoria.Enabled = false;
            TxtDTlancamento.Enabled = false;
            txtQtdEstoque.Enabled = false;
            txtValor.Enabled = false;
            txtValor_compra.Enabled = false;
            txtDescricao.Enabled = false;
            ddlTipovenda.Enabled = false;
        }
        public void Limpar_campos()
        {

            txtNome.Text = string.Empty;
            txtValor_compra.Text = string.Empty;
            TxtDTlancamento.Text = string.Empty;
            txtQtdEstoque.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            imagem_prod.ImageUrl = string.Empty;


        }
        public void Valida_campos()
        {
            if (txtNome.Text == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (ddlMarca.Text == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (ddlCategoria.Text == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (TxtDTlancamento.Text == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (txtQtdEstoque.Text == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (txtValor.Text == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (txtDescricao.Text == string.Empty) { lbl_message.Text = "Campo Obrigatório"; return; }
            if (Convert.ToDouble(txtValor.Text) < Convert.ToDouble(txtValor_compra.Text))
            {
                MSG("Valor de venda não pode ser menor que o valor de Compra ");
                return;
            }

        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

         
                imagem_prod.ImageUrl = @"~/Imagens/" + FileUpload1.FileName;
           

            //private void saveImage()
            //{

            //    FileUpload upload = (FileUpload)FileUploadImage.FileName.("FileUploadImage");

            //    String path = Server.MapPath("~/Imagens/" + upload.FileName);

            //    if (!File.Exists(path))
            //    {
            //        if (upload.HasFile)
            //        {

            // To enable this sample, grant Write permission to the ASP.NET process account 
            // for the Images subdirectory and uncomment below lines of code.


            //#region Imagem Maior
            //using (Bitmap bitmap = new Bitmap(upload.PostedFile.InputStream, false))
            //    if (bitmap.Width > bitmap.Height)
            //    {
            //        int wi = bitmap.Width;
            //        int he = bitmap.Height;
            //        int novaAltura = (wi * 140) / he;
            //        CreateThumbnail(140, novaAltura, path, Server.MapPath("~/Imagens/Thumb424/" + upload.FileName));


            //    }
            //    else
            //    {
            //        int he = bitmap.Height;
            //        int wi = bitmap.Width;
            //        int novaLargura = (wi * 139) / he;
            //        CreateThumbnail(novaLargura, 139, path, Server.MapPath("~/Imagens/Thumb424/" + upload.FileName));
            //    }
            //#endregion

            //#region Imagem Menor
            //using (Bitmap bitmap = new Bitmap(upload.PostedFile.InputStream, false))
            //    if (bitmap.Width > bitmap.Height)
            //    {
            //        int wi = bitmap.Width;
            //        int he = bitmap.Height;
            //        int novaAltura = (he * 65) / wi;
            //        CreateThumbnail(65, novaAltura, path, Server.MapPath("~/Imagens/Thumb65/" + upload.FileName));

            //    }
            //    else
            //    {
            //        int he = bitmap.Height;
            //        int wi = bitmap.Width;
            //        int novaLargura = (wi * 65) / he;
            //        CreateThumbnail(novaLargura, 65, path, Server.MapPath("~/Imagens/Thumb65/" + upload.FileName));
            //    }
            //#endregion

            //    }


            //}




            //public void CreateThumbnail(int largura, int altura, string srcpath, string destpath)
            //{
            //    System.Drawing.Image img = System.Drawing.Image.FromFile(srcpath);
            //    System.Drawing.Image imgthumb = img.GetThumbnailImage(largura, altura, null, new System.IntPtr(0));
            //    imgthumb.Save(destpath, ImageFormat.Jpeg);
            //    img.Dispose();
            //    imgthumb.Dispose();
            //}
        }

        protected void btnOk_pesquisar_Click(object sender, EventArgs e)
        {
            if (txtPesquisar.Text != "")
            {
                Desabilita_campos();
                Limpar_campos();
                gv_produtos.Visible = true;
                gv_produtos2.Visible = false;
            }
            else
            {
                gv_produtos2.Visible = true;
            }
            }

        protected void gv_produtos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExcluir.Enabled = true;
            btnEditar0.Enabled = true;
            int codigo = Convert.ToInt16(gv_produtos2.SelectedRow.Cells[1].Text);
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
            cmd.CommandText = "Select *  from Tb_Prod_Estoque where Id_Prod_Estq = " + codigo;
            cmd.Connection = clsDAO.conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ddlCodigo_prod.Text = Convert.ToString(gv_produtos2.SelectedRow.Cells[1].Text);
                txtNome.Text = Convert.ToString(dr["Nome_Prod_Estq"]);
                ddlMarca.Text = Convert.ToString(dr["Marca_Prod_Estoq"]);
                ddlCategoria.Text = Convert.ToString(dr["Categoria_Prod_Estoq"]);
                TxtDTlancamento.Text = Convert.ToString(dr["Dt_lancamento_Prod_Estoq"]);
                txtQtdEstoque.Text = Convert.ToString(dr["Qtd_Prod_Estoq"]);
                txtValor.Text = Convert.ToString(String.Format("{0:0.00}", dr["Valor_Venda_Prod_Estoq"]));
                txtValor_compra.Text = Convert.ToString(String.Format("{0:0.00}", dr["Valor_Compra_Prod"]));
                txtDescricao.Text = Convert.ToString(dr["Descricao_Prod_Estoq"]);
                ddlFornecedor.Text = Convert.ToString(dr["Cod_For"]);
                imagem_prod.ImageUrl = Convert.ToString(dr["Foto_Prod_Estoq"]);
                ddlTipovenda.Text = Convert.ToString(dr["Tipo_Venda"]);


            }

            clsDAO.conexao().Close();
        }
       
            
       
        }
    }
