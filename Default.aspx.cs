using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.util;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
namespace gestaostocks
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["base_dados"] = "";
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (tb_user.Text == "administrador" && tb_pwd.Text == "ebsf%2017")
            {
                panel_btn.Visible = true;
            }
            else {
                lb_erro.Visible = true;
                panel_btn.Visible = false;
            }
        }


      
 
        SQLHelper sqlHelper = new SQLHelper();
        protected void ib_material_apoio_Click(object sender, ImageClickEventArgs e)
        {
            
            Application["db"] = "LocalMySqlServerapoio";
            Response.Redirect("~\\produtos.aspx");

        }

        protected void ib_material_limpeza_Click(object sender, ImageClickEventArgs e)
        {
          
            Application["db"] = "LocalMySqlServer12";
            Response.Redirect("~\\produtos.aspx");
        }

        protected void ib_material_limpeza_lajes_Click(object sender, ImageClickEventArgs e)
        {
          
            Application["db"] = "LocalMySqlServerlajes";
            Response.Redirect("~\\produtos.aspx");
        }
    }
}