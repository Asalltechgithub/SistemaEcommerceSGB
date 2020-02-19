using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Projeto.SGB.Dao;
using ProjetoSGB_Model;

namespace WebApplication4
{
    public partial class home1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["admin"] == null)
            //{
            //    Label1.Text = Convert.ToString(Session["oper"]);
            //    lnkNomeusu.Text = Convert.ToString(Session["oper2"]);
            //}
            //if (Session["oper"] == null)
            //{
            //    Label1.Text = Convert.ToString(Session["admin"]);
            //    lnkNomeusu.Text = Convert.ToString(Session["admin2"]);
            //}
            //if (Session["oper"] == null && Session["admin"] == null)
            //{
            //    Label1.Text = Convert.ToString(Session["Cli_Tipo"]);
            //    lnkNomeusu.Text = Convert.ToString(Session["Cli_Email"]);
            //}
            //if (lnkNomeusu.Text != "")
            //{
            //    LnkCadastro.Visible = false;
            //}
            //else { LnkCadastro.Visible = true; }
        }
        //protected void LinkButton1_Click(object sender, EventArgs e)
        //{
            
        //    if (Label1.Text == "1")
        //    {
        //        Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");

        //    }


        //    if (Label1.Text == "2")
        //    {
        //        Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");

        //    }

        //    if (Label1.Text == "3")
        //    {
        //        Response.Redirect("~/MenuCliente.aspx");

        //    }
        //    if (Label1.Text == "")
        //    {
        //        Response.Redirect("~/login.aspx");
        //    }



            //}

            //protected void LinkButton2_Click(object sender, EventArgs e)
            //{
            //    Session.Clear();
            //}

            //protected void lnkNomeusu_Click(object sender, EventArgs e)
            //{
            //    if (Label1.Text == "1")
            //    {
            //        Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");

            //    }


            //    if (Label1.Text == "2")
            //    {
            //        Response.Redirect("~/Administrativo/Menu_Funcionario.aspx");

            //    }

            //    if (Label1.Text == "3")
            //    {
            //        Response.Redirect("~/MenuCliente.aspx");

            //    }
            //    if (Label1.Text == "")
            //    {
            //        Response.Redirect("~/login.aspx");
            //    }

            //}

            //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
            //{

            //    Response.Redirect("Descricao_Prod.aspx");
            //}
        }
    }
