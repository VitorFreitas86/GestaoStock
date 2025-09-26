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
    public partial class produtos : System.Web.UI.Page
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
            if (!this.IsPostBack)
            {
                GridView1.DataSource=produto.get_all_produtos(connstring);
                GridView1.DataBind();
            }
        }

        protected void btn_gravar_Click(object sender, EventArgs e)
        {
            produto.create_produto(tb_designacao.Text, ddl_tipo.SelectedItem.Text, 0, connstring);
            Response.Redirect(Request.RawUrl);
        }
    }
}