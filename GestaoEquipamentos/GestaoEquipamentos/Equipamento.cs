using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentosPOO
{
    class Equipamento
    {
        private int id;
        private string nome;
        private double valorAquisicao;
        private int numeroDeSerie;
        private DateTime dataDeFabricacao;
        private string fabricante;
        

        public Equipamento(int id, string nome, double valorAquisicao, int numeroDeSerie, DateTime dataDeFabricacao, string fabricante)
        {
            this.id = id;
            this.nome = nome;
            this.valorAquisicao = valorAquisicao;
            this.numeroDeSerie = numeroDeSerie;
            this.dataDeFabricacao = dataDeFabricacao;
            this.fabricante = fabricante;
        }

        public int getId()
        {
            return id;
        }

        public string getNome()
        {
            return nome;
        }

        public double getValorAquisicao()
        {
            return valorAquisicao;
        }

        public int getNumeroDeSerie()
        {
            return numeroDeSerie;
        }

        public DateTime getDataDeFabricacao()
        {
            return dataDeFabricacao;
        }

        public string getFabricante()
        {
            return fabricante;
        }

    }
}
