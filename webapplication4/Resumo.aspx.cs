using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Projeto.SGB.Dao;


namespace WebApplication4
{
    public partial class Resumo : System.Web.UI.Page
    {
        string HTML;
        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.SelectedDate = DateTime.Now.Date;

            if (Session["admin"] != null || Session["oper"] != null)
            {

                Response.Redirect("~/login.aspx");
            }
            if (Session["cli"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");

            }
            if (Session["MSG"] != null)
            {
                string msg = Convert.ToString(Session["MSG"]);
                MSG(msg);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["MSG"] = null;
            double val_total = Convert.ToDouble(GridView1.SelectedRow.Cells[4].Text);
            Session["val_total"] = val_total;

            //Response.Redirect("Boleto.aspx");
            string _open = "window.open('Boleto.aspx','_blank');";
           ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
           // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Boleto", "janelaModal('Boleto.aspx','Sua','680','1020')", true);

        }
        public void MSG(string msg)
        {
            Response.Write("<script>alert('" + msg + "');</script>");

        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["MSG"] = null;
            double val_total = Convert.ToDouble(GridView3.SelectedRow.Cells[4].Text);
            Session["val_total"] = val_total;
            string _open = "window.open('Boleto.aspx','_blank');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

       

    }
}