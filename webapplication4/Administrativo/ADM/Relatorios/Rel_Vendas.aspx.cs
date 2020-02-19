using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace WebApplication4.Administrativo.ADM.Relatorios
{
    public partial class Rel_Vendas : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Session.Clear();
                Response.Redirect("~/login.aspx");

            }
            if (!IsPostBack) 
            { 
            
            }

            
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void BtnVisualizar_Click(object sender, EventArgs e)
        {
            gvVendas_Cartao.Visible = true;
        }

        protected void btnFechar_venda_Cartao_Click(object sender, EventArgs e)
        {
            gvVendas_Cartao.Visible = false;
        }

        protected void BtnVisualizarb_Click(object sender, EventArgs e)
        {
            gvVendas_Boleto.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            gvVendas_Boleto.Visible = false;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_pedido = Convert.ToInt16(GridView1.SelectedRow.Cells[0].Text);
            int Id_cli = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            Session["pedido"] = codigo_pedido;
            Session["Id_Cli"] = Id_cli;
            Response.Redirect("Detalhe_Venda.aspx");
        }
       
      
        

        protected void imgb_Receita_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
            "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView2.AllowPaging = false;
            GridView2.DataBind();
            GridView2.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
           
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            Paragraph paragrafo2 = new Paragraph("Data de Emissão : " + DateTime.Now.Date.ToString("dd/MM/yyyy") + " Horário da emissão " + DateTime.Now.ToString("T")); 
            pdfDoc.Add(paragrafo2);

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\Users\Geovane\Desktop\WebApplication4\webapplication4\Imagens\Logotipos\logo.png");
            img.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(img);
           
            Paragraph paragrafo = new Paragraph("Receita Total ");
            paragrafo.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(paragrafo);
           

           
            Paragraph paragrafo4 = new Paragraph("           ");
            paragrafo4.Alignment = Element.ALIGN_CENTER;

            pdfDoc.Add(paragrafo4);
            
            htmlparser.Parse(sr);
            
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            
        }

       
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
            "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            GridView1.DataBind();
            GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
           
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            Paragraph paragrafo2 = new Paragraph("Data de Emissão : " + DateTime.Now.Date.ToString("dd/MM/yyyy") + " Horário da emissão " + DateTime.Now.ToString("T")); 
            pdfDoc.Add(paragrafo2);

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\Users\Geovane\Desktop\WebApplication4\webapplication4\Imagens\Logotipos\logo.png");
            img.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(img);
           
            Paragraph paragrafo = new Paragraph("Relátório de Pedidos ");
            paragrafo.Alignment = Element.ALIGN_CENTER;
             
            pdfDoc.Add(paragrafo);
            DateTime inicio = Convert.ToDateTime( Session["inicio"]);
            DateTime fim = Convert.ToDateTime(Session["Fim"]);
            Paragraph paragrafo3 = new Paragraph("De : " + inicio.Date.ToString("dd/MM/yyyy") + " Até : " + fim.Date.ToString("dd/MM/yyyy") + " ");
            paragrafo3.Alignment = Element.ALIGN_CENTER;

            pdfDoc.Add(paragrafo3);
            Paragraph paragrafo4 = new Paragraph("           ");
            paragrafo4.Alignment = Element.ALIGN_CENTER;

            pdfDoc.Add(paragrafo4);
            htmlparser.Parse(sr);
            
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Session["inicio"] = Calendar1.SelectedDate.Date.Date;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            Session["Fim"] = Calendar2.SelectedDate.Date.Date;
        }

        protected void img_btn_Cartao_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
            "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvVendas_Cartao.AllowPaging = false;
            gvVendas_Cartao.DataBind();
            gvVendas_Cartao.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            Paragraph paragrafo2 = new Paragraph("Data de Emissão : " + DateTime.Now.Date + " Horario da emissão : " + DateTime.Now.Date.Hour + "  ");
            pdfDoc.Add(paragrafo2);

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\Users\Geovane\Desktop\WebApplication4\webapplication4\Imagens\Logotipos\logo.png");
            img.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(img);

            Paragraph paragrafo = new Paragraph("Compras por Cartão ");
            paragrafo.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(paragrafo);



            Paragraph paragrafo4 = new Paragraph("           ");
            paragrafo4.Alignment = Element.ALIGN_CENTER;

            pdfDoc.Add(paragrafo4);

            htmlparser.Parse(sr);

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void img_btn_Boleto_Click(object sender, ImageClickEventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
            "attachment;filename=GridViewExport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            gvVendas_Boleto.AllowPaging = false;
            gvVendas_Boleto.DataBind();
            gvVendas_Boleto.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            Paragraph paragrafo2 = new Paragraph("Data de Emissão : " + DateTime.Now.Date + " Horario da emissão : " + DateTime.Now.Date.Hour + "  ");
            pdfDoc.Add(paragrafo2);

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\Users\Geovane\Desktop\WebApplication4\webapplication4\Imagens\Logotipos\logo.png");
            img.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(img);

            Paragraph paragrafo = new Paragraph("Compras por Boleto ");
            paragrafo.Alignment = Element.ALIGN_CENTER;
            pdfDoc.Add(paragrafo);



            Paragraph paragrafo4 = new Paragraph("           ");
            paragrafo4.Alignment = Element.ALIGN_CENTER;

            pdfDoc.Add(paragrafo4);

            htmlparser.Parse(sr);

            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        
    }
}