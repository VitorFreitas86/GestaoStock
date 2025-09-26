using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestaostocks
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_entrada_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/entrada.aspx");
        }

        protected void btn_saida_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/saida.aspx");
        }

        protected void btn_produtos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/produtos.aspx");
        }

        protected void btn_fornecedores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/fornecedor.aspx");
        }

        protected void btn_relatorios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/relatorios.aspx");
        }

        protected void btn_administracao_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/administracao.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}