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
    public partial class add_categorias_marcas : System.Web.UI.Page
    {
        string Inserir;
        string Alterar;
        string marca;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["admin"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        protected void lbAdd_Cat_Click(object sender, EventArgs e)
        {
            
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCategoria.Text = ddlCategoria.SelectedValue;
            btnExcluir.Enabled = true;
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMarca.Text = ddlMarca.SelectedValue;
        }
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            lblModo.Text = "Inserir";
            txtCategoria.Enabled = true;
            txtCategoria.Text = "";
            Button1.Enabled = false;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblModo.Text = "Editar";

            txtCategoria.Enabled = true;
            btnNovo.Enabled = false;

            if (txtCategoria.Text == string.Empty) 
            {
                MSG("Selecione uma Categoria ! ");
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

            if (lblModo.Text == "Inserir")
            {
                inserir_Categoria();
                btnNovo.Enabled = true;
                Button1.Enabled = true;

            }
            if (lblModo.Text == "Editar") 
            {
                Alterar_Categoria();
                btnNovo.Enabled = true;
                Button1.Enabled = true;
            }
            ddlCategoria.DataBind();
        }
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (verificar_Categoria() == true)
            {
                MSG("Essa Categoria possui produtos ligado a mesma !");
            }
            else
            {

                deletar_categoria();
                ddlCategoria.DataBind();
                txtCategoria.Text = string.Empty;
            }
        }
        
        public void inserir_Categoria() 
        {
            SqlConnection con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into Tb_Categoria Values (@nome_Categoria)";
            cmd.Parameters.AddWithValue("@nome_Categoria", txtCategoria.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Alterar_Categoria()
        {
            SqlConnection con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Tb_Categoria set nome_Categoria=@nome_Categoria where nome_Categoria = @nome_CategoriaValue ";
            cmd.Parameters.AddWithValue("@nome_Categoria", txtCategoria.Text);
            cmd.Parameters.AddWithValue("@nome_CategoriaValue", ddlCategoria.SelectedValue);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deletar_categoria()
        {
            
            SqlConnection con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from  Tb_Categoria where nome_Categoria = @nome_CategoriaValue ";
            cmd.Parameters.AddWithValue("@nome_CategoriaValue", ddlCategoria.SelectedValue);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        
        }

        protected void ddlM_C_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlM_C.Text == "Categoria") 
            {
                PnCategoria.Enabled = true;
                PnMarca.Enabled = false;
            }
            if (ddlM_C.Text == "Marca") 
            {
                PnCategoria.Enabled = false;
                PnMarca.Enabled = true;
            }
        }
        
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            lblModo.Text = "Inserir";
            txtMarca.Text = string.Empty;
            txtMarca.Enabled = true;
            Button2.Enabled = false;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (verificar_Marca() == true)
            {
                MSG("Essa marca possui produtos ligado a mesma !");
            }
            else
            {
                deletar_marca();
                ddlMarca.DataBind();
                txtMarca.Text = string.Empty;
            }
        }



        protected void Button6_Click(object sender, EventArgs e)
        {
            if (lblModo.Text == "Inserir")
            {
                inserir_marca();
                btnNovo.Enabled = true;
                Button5.Enabled = true;
                Button6.Enabled = false;

            }
            if (lblModo.Text == "Editar")
            {
                Alterar_marca();
                btnNovo.Enabled = true;
                Button5.Enabled = true;
                Button6.Enabled = false;
            }
            ddlMarca.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            lblModo.Text = "Editar";

            txtMarca.Enabled = true;
            Button5.Enabled = false;

            if (txtMarca.Text == string.Empty)
            {
                MSG("Selecione uma Marca ! ");
            }
        }
        public void inserir_marca()
        {
            SqlConnection con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Insert into Tb_marca Values (@nome_Categoria)";
            cmd.Parameters.AddWithValue("@nome_Categoria", txtMarca.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Alterar_marca()
        {
            SqlConnection con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "update Tb_marca set Nome_marca=@Nome_marca where Nome_marca = @nome_MarcaValue";
            cmd.Parameters.AddWithValue("@Nome_marca", txtMarca.Text);
            cmd.Parameters.AddWithValue("@nome_MarcaValue", ddlMarca.SelectedValue);

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deletar_marca()
        {

            SqlConnection con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete from  Tb_marca where Nome_marca = @nome_marcaValue ";
            cmd.Parameters.AddWithValue("@nome_marcaValue", ddlMarca.SelectedValue);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

        }


        public bool verificar_Marca() 
        {
            
          
            SqlConnection con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select *from Tb_Prod_Estoque where Marca_Prod_Estoq = " + "'" + txtMarca.Text + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = clsDAO.conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();

            return dr.HasRows;
            
        }
        public bool verificar_Categoria()
        {


            SqlConnection con = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select *from Tb_Prod_Estoque where Categoria_Prod_Estoq = " + "'" + txtCategoria.Text+ "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = clsDAO.conexao();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();

            return dr.HasRows;

        }


       
        

       
    }
}