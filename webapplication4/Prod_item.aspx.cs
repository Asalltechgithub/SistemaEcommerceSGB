using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjetoSGB_Model;
using System.Data.SqlClient;
using Projeto.SGB.Dao;

namespace WebApplication4
{
    public partial class Prod_item : System.Web.UI.Page
    {
        int Venda = 1;
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (Session["admin"] != null || Session["oper"] != null)
            {
                Session["MSG"] = "Sua conta não da direito a compra !";
                Response.Redirect("~/login.aspx");
            }
            if (Session["cli"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Label lblIdProd = (Label)e.Item.FindControl("Nome_Prod_EstqLabel");
                Label lblProduto = (Label)e.Item.FindControl("Marca_Prod_EstoqLabel");
                Label lblCatg = (Label)e.Item.FindControl("Categoria_Prod_EstoqLabel");
                Label lblFabricante = (Label)e.Item.FindControl("Label2");
                Label lblEmEstq = (Label)e.Item.FindControl("Image2.ImageUrl");


            }
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

            }
        }

           protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
       
             {
           
                 int qtd = 1;
                 int cod_ped = 0;
                 if (verifica_prod() == false)
                 {
                   int Tipo_venda = Convert.ToUInt16( Session["Tipo_venda"]);
                   if (Tipo_venda == 1)
                   {
                       int id_cli = Convert.ToInt32(Session["Cli_ID"]);
                       int Cod_prd = Convert.ToInt32(Session["Cod_prd"]);
                       string nome = Convert.ToString(Session["Nome"]);
                       string marca = Convert.ToString(Session["Marca"]);
                       string categoria = Convert.ToString(Session["Categoria"]);
                       string preco = Convert.ToString(Session["preco"]);
                       int tipo_venda = Convert.ToInt16(Session["Tipo_venda"]);
                       string img = Convert.ToString(Session["img"]);
                       SqlConnection cn = clsDAO.conexao();
                       SqlCommand cmd = new SqlCommand();
                       cmd.CommandText = "insert into tb_carrinho values ( @cod_cli,@Cod_Pedido,@Cod_prd ,@Produto,@Marca,@Qtd,@Categoria,@Valor,@Foto)";
                       cmd.Connection = cn;
                       cmd.Parameters.AddWithValue("@cod_cli", id_cli);
                       cmd.Parameters.AddWithValue("@Cod_Pedido", cod_ped);
                       cmd.Parameters.AddWithValue("@Cod_prd", Cod_prd);
                       cmd.Parameters.AddWithValue("@Produto", nome);
                       cmd.Parameters.AddWithValue("@Marca", marca);
                       cmd.Parameters.AddWithValue("@Qtd", qtd);
                       cmd.Parameters.AddWithValue("@Categoria", categoria);
                       cmd.Parameters.AddWithValue("@Valor", Convert.ToDouble(preco));
                       cmd.Parameters.AddWithValue("@Foto", img);

                       cmd.ExecuteNonQuery();
                       cn.Close();
                       insert_historico();
                       Response.Redirect("Carrinho_de_Compras.aspx");
                   }
                                    }
                 else 
                 {

                     MSG("esse item já existe no Carrinho ");
                 }
        }

             public bool verifica_prod() 
             { 
           int id_cli =Convert.ToInt32( Session["Cli_ID"]) ;
           int Cod_prd = Convert.ToInt32(Session["Cod_prd"]); 
           string nome  =Convert.ToString( Session["Nome"]);
           string marca =Convert.ToString (Session["Marca"]);
           string categoria  =Convert.ToString (Session["Categoria"]);
           string preco =Convert.ToString (Session["preco"]);
           string img = Convert.ToString(Session["img"]);
            SqlConnection cn = clsDAO.conexao();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Cod_prd , cod_cli  from Tb_carrinho where cod_cli ="+id_cli +" "+" and "+" "+"Cod_prd ="+ Cod_prd +"";
            cmd.Connection = cn;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            
            return dr.HasRows;
            
            }
             public void insert_historico() 
             {
                 int qtd = 1;
                 int cod_ped = 0;
                 int id_cli = Convert.ToInt32(Session["Cli_ID"]);
                 int Cod_prd = Convert.ToInt32(Session["Cod_prd"]);
                 string nome = Convert.ToString(Session["Nome"]);
                 string marca = Convert.ToString(Session["Marca"]);
                 string categoria = Convert.ToString(Session["Categoria"]);
                 string preco = Convert.ToString(Session["preco"]);
                 int tipo_venda = Convert.ToInt16(Session["Tipo_venda"]);
                 string img = Convert.ToString(Session["img"]);
                 SqlConnection cn = clsDAO.conexao();
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandText = "insert into Tb_lista_Historico values ( @cod_cli,@Cod_Pedido,@Cod_prd ,@Produto,@Marca,@Qtd,@Categoria,@Valor,@Tipo_Pedido)";
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
               

                 cmd.ExecuteNonQuery();
                 cn.Close();
             }
             public void MSG(string msg)
             {
                 Response.Write("<script>alert('" + msg + "');</script>");

             }
        }  


    }

