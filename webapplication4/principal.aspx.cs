using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.SGB.Dao;
using ProjetoSGB_Model;

namespace WebApplication4
{
    public partial class principal : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

          
        }

       

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            
            //Response.Redirect("Descricao_Prod.aspx");
        }

       

        
        //[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
        //public static List<Produto> SelectProductRandom()
        //{
        //    //Initialize command
        //    SqlConnection con =  clsDAO.conexao(); 
        //    SqlCommand cmd = new SqlCommand("dev_ProductRandom", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    List<Produto> results = new List<Produto>();
        //    using (con)
        //    {
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //            results.Add(new Product(reader));
        //    }
        //    return results;


        }
    }

