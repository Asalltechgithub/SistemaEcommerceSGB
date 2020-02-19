using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4.Cliente
{
    public partial class Menu_Cli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cli"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }
    }
}