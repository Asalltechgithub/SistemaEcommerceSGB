using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ProjetoSGB_Model;

namespace WebApplication4
{
    public partial class Consul_Estoque : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["oper"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            GridView1.ID = DropDownList1.DataValueField;
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

       
        

      
       
    }
}