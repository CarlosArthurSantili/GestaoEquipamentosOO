using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentosPOO
{
    class Chamado
    {
        //quantidade
        private int id;
        private string titulo;
        private string descricao;
        private int idEquipamento;
        private DateTime dataDeAbertura;

        public Chamado(int id, string titulo, string descricao, int idEquipamento, DateTime dataDeAbertura) 
        {
            this.id = id;
            this.titulo = titulo;
            this.descricao = descricao;
            this.idEquipamento = idEquipamento;
            this.dataDeAbertura = dataDeAbertura;
        }

        public int getId()
        {
            return id;
        }
        public string getTitulo()
        {
            return titulo;
        }
        public string getDescricao()
        {
            return titulo;
        }
        public int getIdEquipamento() 
        {
            return idEquipamento;
        }
        public DateTime getDataDeAbertura()
        {
            return dataDeAbertura;
        }
    }
}
