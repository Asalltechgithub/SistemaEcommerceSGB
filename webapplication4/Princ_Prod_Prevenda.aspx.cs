using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Princ_Prod_Prevenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["admin"] != null || Session["oper"] != null)
            {
                
                Response.Redirect("~/login.aspx");
            }
            if (Session["cli"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");


            }

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}