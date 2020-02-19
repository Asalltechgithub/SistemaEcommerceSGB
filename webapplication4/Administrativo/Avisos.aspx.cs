using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4.Administrativo
{
    public partial class Avisos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null && Session["oper"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }
    }
}