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
    public partial class administracao : System.Web.UI.Page
    {
        BAL_registo destinos = new BAL_registo();
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

            if (!IsPostBack)
            {
                GridView1.DataSource=     destinos.get_all_destino(connstring);
                GridView1.DataBind();

                GridView2.DataSource = destinos.get_all_funcionario(connstring);
                GridView2.DataBind();
            }
        }

        protected void btn_gravar_Click(object sender, EventArgs e)
        {
         
            destinos.create_destino(tb_destino.Text, connstring);

            tb_destino.Text = "";

            GridView1.DataSource = destinos.get_all_destino(connstring);
            GridView1.DataBind();
        }

        protected void btn_funcionario_Click(object sender, EventArgs e)
        {
            destinos.create_funcionarios(tb_funcionario.Text, connstring);

            tb_funcionario.Text = "";

            GridView2.DataSource = destinos.get_all_funcionario(connstring);
            GridView2.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            destinos.delete_destinos(Convert.ToInt32(id), connstring);
            GridView1.DataSource = destinos.get_all_destino(connstring);
            GridView1.DataBind();
        }
    }
}