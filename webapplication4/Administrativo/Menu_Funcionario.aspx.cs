using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Projeto.SGB.Dao;
using System.Data;
namespace WebApplication4
{
    public partial class Menu_Funcionario : System.Web.UI.Page
    {

        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["oper"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            if (!IsPostBack)
            {
                

                

            }
        }

        
    }
}