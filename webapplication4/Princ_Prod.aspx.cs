using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Princ_Prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


        }

      
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
           
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
