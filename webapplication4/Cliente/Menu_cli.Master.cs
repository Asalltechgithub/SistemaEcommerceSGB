using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4.Cliente
{
    public partial class Menu_cli : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = Convert.ToString(Session["Cli"]);
            Label2.Visible = false;
            Label1.Text = Convert.ToString(Session["Cli_Tipo"]);
            lnkNomeusu.Text = Convert.ToString(Session["Cli_Email"]);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}