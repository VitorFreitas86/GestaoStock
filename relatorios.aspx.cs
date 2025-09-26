using gestaostocks.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.IO;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using DAL;
using System.Configuration;

namespace gestaostocks
{
    public partial class relatorios : System.Web.UI.Page
    {
        BAL_registo produto = new BAL_registo();
        SQLHelper sqlHelper = new SQLHelper();
        string connstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Application["db"].ToString() == "LocalMySqlServerapoio")
            { connstring = (ConfigurationManager.ConnectionStrings["LocalMySqlServerapoio"].ConnectionString); }

            if (Application["db"].ToString() == "LocalMySqlServer12")
            { connstring = (ConfigurationManager.ConnectionStrings["LocalMySqlServer12"].ConnectionString); }

            if (Application["db"].ToString() == "LocalMySqlServerlajes")
            { connstring = (ConfigurationManager.ConnectionStrings["LocalMySqlServerlajes"].ConnectionString); }
        }

        protected void btn_r_entrada_Click(object sender, EventArgs e)
        {
            panel_stock.Visible = false;
            panel_entradas.Visible = true;
            Panel_saidas.Visible = false;
        }

        protected void btn_r_saida_Click(object sender, EventArgs e)
        {
            panel_stock.Visible = false;
            panel_entradas.Visible = false;
            Panel_saidas.Visible = true;
        }

        protected void btn_r_stock_Click(object sender, EventArgs e)
        {
            panel_stock.Visible = true;
            panel_entradas.Visible = false;
            Panel_saidas.Visible = false;

            GridView1.DataSource = produto.get_all_produtos_relatorio(connstring);
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                btn_export_stock.Visible = true;
            }
         }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        private void ExportGridToPDF(GridView Gview,string nome_ficheiro)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename="+nome_ficheiro);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Gview.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/simbolo_da_escola_stock.png"));
            Phrase main1 = new Phrase("\n\nData:"+DateTime.Now+"                    O Funcionário:_________________________________");
            main1.Font.SetStyle(Font.BOLD);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(logo);
            htmlparser.Parse(sr);
            pdfDoc.Add(main1);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            GridView1.AllowPaging = true;
            GridView1.DataBind();
        }
        void Gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Font.Bold = true;
                e.Row.HorizontalAlign= HorizontalAlign.Center;
                //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
            }  
            //e.Row.Cells[0].Width = new Unit("520px");
                //e.Row.Cells[0].Width = 500;
                //e.Row.Cells[0].Wrap = false;
                //e.Row.Cells[0].Width = "30px";
                //e.Row.Cells[0].Attributes["width"] = "400px";
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //e.Row.Cells[0].Width = new Unit("520px");
            //    //e.Row.Cells[0].Attributes["width"] = "400px";
            //    //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            //    //e.Row.Cells[0].Attributes["width"] = "400px";
            //    //e.Row.Cells[1].Width=300;
            //    //e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            //}
        }
        protected void btn_export_stock_Click(object sender, EventArgs e)
        {
            //ExportGridToPDF(GridView1,"Relatorio_stock.pdf");
            DataTable dt = new DataTable("GridView_Data");
            foreach (System.Web.UI.WebControls.TableCell cell in GridView1.HeaderRow.Cells)
            {
                dt.Columns.Add(System.Web.HttpUtility.HtmlDecode(cell.Text));
            }
            foreach (GridViewRow row in GridView1.Rows)
            {
                //GridView GridView_produtoscell = (row.FindControl("GridView_produtos") as GridView);
                //for (int j = 0; j < GridView_produtoscell.Rows.Count; j++)
                //{
                //    if (j == 0)
                    //{
                        dt.Rows.Add(System.Web.HttpUtility.HtmlDecode(row.Cells[0].Text), row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text);
                //}
                //else
                //{
                //    dt.Rows.Add("", "", "", "", GridView_produtoscell.Rows[j].Cells[0].Text, GridView_produtoscell.Rows[j].Cells[1].Text, GridView_produtoscell.Rows[j].Cells[2].Text);
                //}
            }
            GridView GridView_dumb = new GridView();
            GridView_dumb.AllowPaging = false;
            GridView_dumb.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            GridView_dumb.RowDataBound += new GridViewRowEventHandler(Gv_RowDataBound);
            GridView_dumb.DataSource = dt;
            GridView_dumb.DataBind();
            
           
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/simbolo_da_escola_stock.png"));
            Phrase main1 = new Phrase("\n\nData:" + DateTime.Now + "                         O Funcionário:_________________________________");
            main1.Font.SetStyle(Font.BOLD);

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_stock.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView_dumb.RenderControl(hw);

            //GridView_dumb.Columns[0].ItemStyle.Width = 250;
            //GridView_dumb.Columns[1].ItemStyle.Width = 50;
            //GridView_dumb.Columns[2].ItemStyle.Width = 50;
            //GridView_dumb.Columns[3].ItemStyle.Width = 100;

            StringReader sr = new StringReader(sw.ToString());
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(logo);
            htmlparser.Parse(sr);
            pdfDoc.Add(main1);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView2.DataSource=produto.get_all_entrada(tb_data_inicio.Text, tb_data_fim.Text, connstring);
            GridView2.DataBind();
            if(GridView2.Rows.Count>0)
            {
                Button2.Visible = true;
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ID = GridView2.DataKeys[e.Row.RowIndex].Value.ToString();
           
                     GridView GridView_produtos = e.Row.FindControl("GridView_produtos") as GridView;
                GridView_produtos.DataSource = produto.get_all_produtos_by_entrada(ID, connstring);
                GridView_produtos.DataBind();
            }
       }


        protected void Button2_Click(object sender, EventArgs e)
        {
            //////////////////////////////------------------------------------------------------
                 DataTable dt = new DataTable("GridView_Data");
                GridView GridView_produtos = (GridView)GridView2.Rows[0].FindControl("GridView_produtos");
          
                foreach (System.Web.UI.WebControls.TableCell cell in GridView2.HeaderRow.Cells)
                {
                    dt.Columns.Add(System.Web.HttpUtility.HtmlDecode(cell.Text));
                }
                foreach (System.Web.UI.WebControls.TableCell cell in GridView_produtos.HeaderRow.Cells)
                {
                    dt.Columns.Add(System.Web.HttpUtility.HtmlDecode(cell.Text));
                }
                dt.Columns.RemoveAt(4);
                foreach (GridViewRow row in GridView2.Rows)
                {
                    GridView GridView_produtoscell = (row.FindControl("GridView_produtos") as GridView);
                    for (int j = 0; j < GridView_produtoscell.Rows.Count; j++)
                    {
                    if (j == 0)
                    {
                        dt.Rows.Add(System.Web.HttpUtility.HtmlDecode(row.Cells[0].Text),
                            System.Web.HttpUtility.HtmlDecode(row.Cells[1].Text),
                            System.Web.HttpUtility.HtmlDecode(row.Cells[2].Text),
                            System.Web.HttpUtility.HtmlDecode(row.Cells[3].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[0].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[1].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[2].Text));
                    }
                    else
                    {
                        dt.Rows.Add("", "", "", "", System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[0].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[1].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[2].Text));
                    }
                }
            }

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            GridView1.RowDataBound += new GridViewRowEventHandler(Gv_RowDataBound);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/simbolo_da_escola_entrada.png"));
            Phrase main1 = new Phrase("\n\nData:" + DateTime.Now + "                         O Funcionário:_________________________________");
            main1.Font.SetStyle(Font.BOLD);

            Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition",
                    "attachment;filename=Relatorio_entrada.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
            pdfDoc.Add(logo);
            htmlparser.Parse(sr);
            pdfDoc.Add(main1);
            pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
            }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //CARREGAR GRID SAIDAS
            GridView3.DataSource = produto.get_all_saida(tb_inicio_saida.Text, tb_fim_saida.Text, connstring);
            GridView3.DataBind();
            if (GridView3.Rows.Count > 0)
            {
                Button4.Visible = true;
            }
        }

        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ID = GridView3.DataKeys[e.Row.RowIndex].Value.ToString();

                GridView GridView_produtos = e.Row.FindControl("GridView_produtos_saidas") as GridView;
                GridView_produtos.DataSource = produto.get_all_produtos_by_saida(ID, connstring);
                GridView_produtos.DataBind();
            }
        }
    
        protected void Button4_Click(object sender, EventArgs e)
        {
            //////////////////////////////------------------------------------------------------
            DataTable dt = new DataTable("GridView_Data");
            GridView GridView_produtos = (GridView)GridView3.Rows[0].FindControl("GridView_produtos_saidas");

            foreach (System.Web.UI.WebControls.TableCell cell in GridView3.HeaderRow.Cells)
            {
                dt.Columns.Add(System.Web.HttpUtility.HtmlDecode(cell.Text));
            }
            foreach (System.Web.UI.WebControls.TableCell cell in GridView_produtos.HeaderRow.Cells)
            {
                dt.Columns.Add(System.Web.HttpUtility.HtmlDecode(cell.Text));
            }
            dt.Columns.RemoveAt(4);
            foreach (GridViewRow row in GridView3.Rows)
            {
                GridView GridView_produtoscell = (row.FindControl("GridView_produtos_saidas") as GridView);
                for (int j = 0; j < GridView_produtoscell.Rows.Count; j++)
                {
                    if (j == 0)
                    {
                        dt.Rows.Add(System.Web.HttpUtility.HtmlDecode(row.Cells[0].Text),
                            System.Web.HttpUtility.HtmlDecode(row.Cells[1].Text),
                            System.Web.HttpUtility.HtmlDecode(row.Cells[2].Text),
                            System.Web.HttpUtility.HtmlDecode(row.Cells[3].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[0].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[1].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[2].Text));
                    }
                    else
                    {
                        dt.Rows.Add("", "", "","",
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[0].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[1].Text),
                            System.Web.HttpUtility.HtmlDecode(GridView_produtoscell.Rows[j].Cells[2].Text));
                    }
                }
            }

            //Create a dummy GridView
            GridView GridView1 = new GridView();
            GridView1.AllowPaging = false;
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            GridView1.RowDataBound += new GridViewRowEventHandler(Gv_RowDataBound);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/simbolo_da_escola_saida.png"));
            Phrase main1 = new Phrase("\n\nData:" + DateTime.Now + "                         O Funcionário:_________________________________");
            main1.Font.SetStyle(Font.BOLD);

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition",
                "attachment;filename=Relatorio_saida.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            pdfDoc.Add(logo);
            htmlparser.Parse(sr);
            pdfDoc.Add(main1);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
    }

    }