using gestaostocks.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using gestaostocks.PROP;

namespace gestaostocks.BAL
{
    public class BAL_registo
    {

        public string create_fornecedor(string nome, string morada, string telefone,string connstring)
        {
            DAL_registo registo = new DAL_registo();
          return   registo.create_fornecedor(nome, morada, telefone, connstring);
        }


        public List<PROP_registo> get_all_fornecedor(string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_all_fornecedor(connstring);
        }

        public string create_produto(string designacao, string tipo, int quantidade,string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.create_produtos(designacao, tipo, quantidade, connstring);
        }

        public List<PROP_registo> get_all_produtos(string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_all_produtos(connstring);
        }

        public string create_registo_entrada(string data_entrada, string numero_fatura, int idfornecedor_in, int quantidade_in, string funcionario_in,string connstring)
        {
            DAL_registo entrada = new DAL_registo();
            return entrada.create_registo_entrada(data_entrada, numero_fatura,  idfornecedor_in,  quantidade_in,funcionario_in, connstring);
        }

        public string entrada_has_produtos(int identrada, int id_produtos, int quantidade_in,string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.entrada_has_produtos(identrada, id_produtos, quantidade_in, connstring);
        }

        public string create_destino(string designacao_in,string connstring)
        {
            DAL_registo entrada = new DAL_registo();
            return entrada.create_destino(designacao_in, connstring);
        }

        public List<PROP_registo> get_all_destino(string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_all_destinos(connstring);
        }

        public string create_funcionarios(string funcionario_nome,string connstring)
        {
            DAL_registo entrada = new DAL_registo();
            return entrada.insert_funcionario(funcionario_nome, connstring);
        }

        public List<PROP_registo> get_all_funcionario(string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_all_funcionarios(connstring);
        }

        public string delete_destinos(int iddestinos_in,string connstring)
        {
            DAL_registo entrada = new DAL_registo();
            return entrada.delete_funcionario(iddestinos_in, connstring);
        }

        public string create_registo_saida(string data_saida, string funcionario_in, int destinos_iddestinos,string requerente_in,string connstring)
        {
            DAL_registo entrada = new DAL_registo();
            return entrada.create_registo_saida(data_saida, funcionario_in, destinos_iddestinos, requerente_in,connstring);
        }

        public string saida_has_produtos(int saida_idsaida, int produtos_idprodutos, int quantidade_saida,string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.create_saida_has_produtos(saida_idsaida, produtos_idprodutos, quantidade_saida, connstring);
        }


        public List<PROP_registo> get_all_produtos_relatorio(string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_all_produtos_relatorio(connstring);
        }

        public List<PROP_registo> get_all_entrada(string data_inicio, string data_fim,string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_entrada(data_inicio, data_fim, connstring);
        }

        public List<PROP_registo> get_all_produtos_by_entrada(string identrada_in,string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_all_produtos_by_entrada(identrada_in, connstring);
        }

        public List<PROP_registo> get_all_saida(string data_inicio, string data_fim,string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_saida(data_inicio, data_fim, connstring);
        }

        public List<PROP_registo> get_all_produtos_by_saida(string idsaida_in,string connstring)
        {
            DAL_registo registo = new DAL_registo();
            return registo.get_all_produtos_by_saida(idsaida_in, connstring);
        }
     
    }
}