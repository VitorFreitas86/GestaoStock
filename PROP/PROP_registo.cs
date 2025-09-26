using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestaostocks.PROP
{
    public class PROP_registo
    {
        private string v;

        public int idfornecedor { get; set; }
        public string nome { get; set; }
        public string morada { get; set; }
        public string telefone { get; set; }


        public int idprodutos { get; set; }
        public string designacao { get; set; }
        public string quantidade { get; set; }
        public string tipo { get; set; }
        public string nulo { get; set; }

        public int iddestinos { get; set; }
        public string designacao_destino { get; set; }

        public int idfuncionario { get; set; }
        public string nome_funcionario { get; set; }

        public int identrada { get; set; }
        public string data_entrada { get; set; }
        public string numero_fatura { get; set; }
        public string funcionario { get; set; }
        public string requerente { get; set; }

        public int idsaida { get; set; }
        public string data_saida { get; set; }

        public string quantidade_entrada { get; set; }
        public string quantidade_saida { get; set; }

        public PROP_registo(int idfornecedor, string nome, string morada, string telefone)
        {
            // TODO: Complete member initialization4
            this.idfornecedor = idfornecedor;
            this.nome = nome;
            this.morada = morada;
            this.telefone = telefone;
            
        }

        public PROP_registo(int idprodutos, string designacao, string quantidade_entrada, string tipo, string nulo)
        {
            // TODO: Complete member initialization5
            this.idprodutos = idprodutos;
            this.designacao = designacao;
            this.quantidade_entrada = quantidade_entrada;
            this.tipo = tipo;

        }

        public PROP_registo(int idprodutos, string designacao, string quantidade_saida, string tipo, string nulo,string nulo1)
        {
            // TODO: Complete member initialization6
            this.idprodutos = idprodutos;
            this.designacao = designacao;
            this.quantidade_saida = quantidade_saida;
            this.tipo = tipo;

        }

        public PROP_registo(int iddestinos, string designacao_destino)
        {
            // TODO: Complete member initialization2
            this.iddestinos = iddestinos;
            this.designacao_destino = designacao_destino;
       

        }

        public PROP_registo(int idfuncionario, string nome_funcionario,string vazio)
        {
            // TODO: Complete member initialization3
            this.idfuncionario = idfuncionario;
            this.nome_funcionario = nome_funcionario;

        }

        public PROP_registo(int identrada, string data_entrada, string numero_fatura, string funcionario, string nome, string vazio, string nulo1) 
        {
            //7
            this.identrada = identrada;
            this.data_entrada = data_entrada;
            this.numero_fatura = numero_fatura;
            this.funcionario = funcionario;
            this.nome = nome;
        }

        public PROP_registo(int idsaida, string data_saida, string funcionario, string designacao_destino, string requerente, string nulo1, string nulo2,string nulo3)
        {
            //8
                this.idsaida = idsaida;
            this.data_saida = data_saida;
            this.funcionario = funcionario;
            this.designacao_destino = designacao_destino;
            this.requerente = requerente;
        }

        public PROP_registo(int idprodutos, string designacao, string quantidade, string tipo, string nulo,string nulo1,string nulo2,string nulo3,string nulo4)
        {
            // TODO: Complete member initialization9
            this.idprodutos = idprodutos;
            this.designacao = designacao;
            this.quantidade = quantidade;
            this.tipo = tipo;

        }
    }
}