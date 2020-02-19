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
    public partial class Rel_prod_enviados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
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
            DateTime inicio;
            DateTime fim;
            inicio = Cl_Inicio.SelectedDate.Date.Date.Date;
            fim = Cl_Fim.SelectedDate.Date.Date.Date;
            Paragraph paragrafo3 = new Paragraph("Do dia  : " + inicio.ToString("dd/MM/yyyy") + " até  " + fim.ToString("dd/MM/yyyy"));
            pdfDoc.Add(paragrafo3);
            Paragraph paragrafo = new Paragraph("Relatório de Produtos Enviados");
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