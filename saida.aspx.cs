using DAL;
using gestaostocks.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestaostocks
{
    public partial class saida : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        BAL_registo produto = new BAL_registo();
        SQLHelper sqlHelper = new SQLHelper();
        string connstring;
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_data.Text = DateTime.Now.ToString("yyyy/MM/dd");

            if (Application["db"].ToString() == "LocalMySqlServerapoio")
            { connstring = (ConfigurationManager.ConnectionStrings["LocalMySqlServerapoio"].ConnectionString); }

            if (Application["db"].ToString() == "LocalMySqlServer12")
            { connstring = (ConfigurationManager.ConnectionStrings["LocalMySqlServer12"].ConnectionString); }

            if (Application["db"].ToString() == "LocalMySqlServerlajes")
            { connstring = (ConfigurationManager.ConnectionStrings["LocalMySqlServerlajes"].ConnectionString); }

            dt.Columns.Add("idprodutos");
            dt.Columns.Add("designacao");

            if (!IsPostBack)
            {
                carrega_produtos();


                string[] arr1 = new string[data_list.Items.Count + 1];
                int i = 0;
                int f = 0;
                if (data_list.Items.Count > 0)
                {
                    for (int x = 0; x < data_list.Items.Count; x++)
                    {
                        Label lb_id = data_list.Items[x].FindControl("lb_id_produto") as Label;
                        arr1[i] = lb_id.Text;
                        i++;
                    }
                    foreach (GridViewRow item2 in gv_produto.Rows)
                    {
                        if (gv_produto.DataKeys[item2.RowIndex].Values[0].ToString() == arr1[f])
                        {
                            CheckBox cb = item2.Cells[0].FindControl("cbSelect") as CheckBox;
                            cb.Checked = true;
                            item2.BackColor = System.Drawing.ColorTranslator.FromHtml("#A6D2FF");
                            item2.ForeColor = Color.Black;
                            f++;
                        }
                    }
                }

                ddl_funcionario.DataSource = produto.get_all_funcionario(connstring);
                ddl_funcionario.DataTextField = "nome_funcionario";
                ddl_funcionario.DataBind();
                ddl_funcionario.Items.Insert(0, new ListItem("Selecione Funcionário", "0"));

                ddl_zonas.DataSource = produto.get_all_destino(connstring);
                ddl_zonas.DataTextField = "designacao_destino";
                ddl_zonas.DataValueField = "iddestinos";
                ddl_zonas.DataBind();
                ddl_zonas.Items.Insert(0, new ListItem("Selecione Área", "0"));
            }
        }

        protected void carrega_produtos()
        {
            gv_produto.DataSource = produto.get_all_produtos(connstring);
            gv_produto.DataBind();
        }

        protected void gv_produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow linha_marcada = gv_produto.SelectedRow;
            CheckBox cb = linha_marcada.Cells[0].FindControl("cbSelect") as CheckBox;
            if (cb.Checked == true)
            {
                cb.Checked = false;
            }
            else
            { cb.Checked = true; }
            foreach (GridViewRow item in gv_produto.Rows)
            {
                if ((item.Cells[0].FindControl("cbSelect") as CheckBox).Checked)
                {
                    string PrimaryKey = gv_produto.DataKeys[item.RowIndex].Values[0].ToString();
                    item.BackColor = Color.SteelBlue;
                    item.ForeColor = Color.White;
                    DataRow dr = dt.NewRow();
                    dr["idprodutos"] = PrimaryKey;
                    dr["designacao"] = item.Cells[1].Text;
                    dt.Rows.Add(dr);
                }
                else
                {
                    item.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFF");
                    item.ForeColor = Color.Black;

                }
            }
            if (dt.Rows.Count == 0)
            {
            }
            data_list.DataSource = dt;
            data_list.DataBind();
        }

        protected void gv_produto_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Clique para selecionar a linha";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.gv_produto, "Select$" + e.Row.RowIndex);
            }
            if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#A6D2FF';this.style.color='#1E1E1E';this.style.fontWeight='bold';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;this.style.color='Black';this.style.fontWeight='normal';");
            }
        }

        protected void btn_gravar_Click(object sender, EventArgs e)
        {
            if (data_list.Items.Count > 0)
            {
                string idsaida = produto.create_registo_saida(tb_data.Text, ddl_funcionario.SelectedItem.Text, Convert.ToInt32(ddl_zonas.SelectedValue), tb_requerente.Text, connstring);

                for (int x = 0; x < data_list.Items.Count; x++)
                {
                    Label lb_id = data_list.Items[x].FindControl("lb_id_produto") as Label;
                    TextBox lb_quantidade = data_list.Items[x].FindControl("tb_quantidade") as TextBox;
                    produto.saida_has_produtos(Convert.ToInt32(idsaida), Convert.ToInt32(lb_id.Text), Convert.ToInt32(lb_quantidade.Text), connstring);
                }
            }
            else
            {
                RequiredFieldValidator_produtos.IsValid = false;
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}