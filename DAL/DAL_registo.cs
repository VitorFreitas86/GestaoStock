using DAL;
using MySql.Data.MySqlClient;
using gestaostocks.PROP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace gestaostocks.DAL
{
    public class DAL_registo
    {
        public string create_fornecedor(string nome, string morada, string telefone,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("nome", nome));
            parameters.Add(new MySqlParameter("morada", morada));
            parameters.Add(new MySqlParameter("telefone", telefone));
            return sqlHelper.executeScaler(parameters, "insert_fornecedor", connstring);
        }

    

        public List<PROP_registo> get_all_fornecedor(string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_fornecedor", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                movimentos = new PROP_registo(Convert.ToInt32(drow["idfornecedor"]),drow["nome"].ToString(), drow["morada"].ToString(), drow["telefone"].ToString());
                movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

        public string create_produtos(string designacao, string tipo, int quantidade,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("designacao", designacao));
            parameters.Add(new MySqlParameter("tipo", tipo));
            parameters.Add(new MySqlParameter("quantidade", quantidade));
            return sqlHelper.executeScaler(parameters, "insert_produto", connstring);
        }

        public List<PROP_registo> get_all_produtos(string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_produtos", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                movimentos = new PROP_registo(Convert.ToInt32(drow["idprodutos"]), drow["designacao"].ToString(), drow["quantidade"].ToString(), drow["tipo"].ToString(),"","","","","");
                movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

        public string create_registo_entrada(string data_entrada, string numero_fatura, int idfornecedor_in, int quantidade_in,string funcionario_in,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("data_entrada", data_entrada));
            parameters.Add(new MySqlParameter("numero_fatura", numero_fatura));
            parameters.Add(new MySqlParameter("idfornecedor_in", idfornecedor_in));
            parameters.Add(new MySqlParameter("quantidade_in", quantidade_in));
            parameters.Add(new MySqlParameter("funcionario_in", funcionario_in));
            return sqlHelper.executeScaler(parameters, "insert_entrada", connstring);
        }

        public string entrada_has_produtos(int identrada, int id_produtos, int quantidade_in,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("id_entrada", identrada));
            parameters.Add(new MySqlParameter("id_produtos", id_produtos));
            parameters.Add(new MySqlParameter("quantidade_in", quantidade_in));
            return sqlHelper.executeScaler(parameters, "insert_entrada_has_produtos", connstring);
        }

        public string create_destino(string designacao_in,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("designacao_in", designacao_in));
            return sqlHelper.executeScaler(parameters, "insert_destinos", connstring);
        }

        public List<PROP_registo> get_all_destinos(string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_destinos", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                movimentos = new PROP_registo(Convert.ToInt32(drow["iddestinos"]), drow["designacao_destino"].ToString());
                movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

        public string insert_funcionario(string funcionario_nome,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("funcionario_nome", funcionario_nome));
            return sqlHelper.executeScaler(parameters, "insert_funcionario", connstring);
        }

        public List<PROP_registo> get_all_funcionarios(string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_funcionario", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                movimentos = new PROP_registo(Convert.ToInt32(drow["idfuncionario"]), drow["nome_funcionario"].ToString(),"");
                movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

        public string delete_funcionario(int iddestinos_in,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("iddestinos_in", iddestinos_in));
            return sqlHelper.executeScaler(parameters, "delete_destinos", connstring);
        }

        public string create_registo_saida(string data_saida, string funcionario_in, int destinos_iddestinos,string requerente_in,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("data_saida", data_saida));
            parameters.Add(new MySqlParameter("destinos_iddestinos", destinos_iddestinos));
            parameters.Add(new MySqlParameter("funcionario_in", funcionario_in));
            parameters.Add(new MySqlParameter("requerente_in", requerente_in));
            return sqlHelper.executeScaler(parameters, "insert_saida", connstring);
        }

        public string create_saida_has_produtos(int saida_idsaida, int produtos_idprodutos, int quantidade_saida,string connstring)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("saida_idsaida", saida_idsaida));
            parameters.Add(new MySqlParameter("produtos_idprodutos", produtos_idprodutos));
            parameters.Add(new MySqlParameter("quantidade_saida", quantidade_saida));
            return sqlHelper.executeScaler(parameters, "insert_saida_has_produtos", connstring);
        }

        public List<PROP_registo> get_all_produtos_relatorio(string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_produtos_relatorio", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                movimentos = new PROP_registo(Convert.ToInt32(drow["idprodutos"]), drow["designacao"].ToString(), drow["quantidade"].ToString(), drow["tipo"].ToString(), "", "", "", "", "");
                movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

        public List<PROP_registo> get_entrada(string data_inicio, string data_fim,string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("data_inicio", data_inicio));
            parameters.Add(new MySqlParameter("data_fim", data_fim));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_entrada", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
               movimentos = new PROP_registo(Convert.ToInt32(drow["identrada"]), drow["data_entrada"].ToString(), drow["numero_fatura"].ToString(), drow["funcionario"].ToString(), drow["nome"].ToString(), "","");
               movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

        public List<PROP_registo> get_all_produtos_by_entrada(string identrada_in,string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("identrada_in", identrada_in));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_produto_by_entrada", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                movimentos = new PROP_registo(Convert.ToInt32(drow["idprodutos"]), drow["designacao"].ToString(), drow["tipo"].ToString(), drow["quantidade_entrada"].ToString(), "");
                movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

        public List<PROP_registo> get_saida(string data_inicio, string data_fim,string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("data_inicio", data_inicio));
            parameters.Add(new MySqlParameter("data_fim", data_fim));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_saida", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                movimentos = new PROP_registo(Convert.ToInt32(drow["idsaida"]), drow["data_saida"].ToString(), drow["funcionario"].ToString(), drow["designacao_destino"].ToString(), drow["requerente"].ToString(), "", "","");
                movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

        public List<PROP_registo> get_all_produtos_by_saida(string idsaida_in,string connstring)
        {
            List<PROP_registo> movimento_list = new List<PROP_registo>();
            SQLHelper sqlHelper = new SQLHelper();
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("idsaida_in", idsaida_in));
            var resultSet = sqlHelper.executeSP<DataSet>(parameters, "select_produto_by_saida", connstring);
            PROP_registo movimentos;
            foreach (DataRow drow in resultSet.Tables[0].Rows)
            {
                movimentos = new PROP_registo(Convert.ToInt32(drow["idprodutos"]), drow["designacao"].ToString(), drow["tipo"].ToString(), drow["quantidade_saida"].ToString(), "","");
                movimento_list.Add(movimentos);
            }
            return movimento_list;
        }

     

    }
}