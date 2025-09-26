using DAL;
using gestaostocks.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gestaostocks
{
    public partial class fornecedor : System.Web.UI.Page
    {
        BAL_registo fornecedores = new BAL_registo();
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
            if (!Page.IsPostBack)
            {
                GridView1.DataSource=fornecedores.get_all_fornecedor(connstring);
                GridView1.DataBind();
            }
        }

        protected void btn_inserir_fornecedor_Click(object sender, EventArgs e)
        {

            fornecedores.create_fornecedor(tb_nome.Text, tb_morada.Text, tb_telefone.Text, connstring);
            Response.Redirect(Request.RawUrl);
        }
    }
}