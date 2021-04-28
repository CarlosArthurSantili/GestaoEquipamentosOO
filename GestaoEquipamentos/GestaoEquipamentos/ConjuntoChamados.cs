using GestaoEquipamentosPOO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos
{
    class ConjuntoChamados
    {
        private Chamado[] chamadosCadastrados = new Chamado[99];
        private int quantidadeChamadosCadastrados;

        public int getQuantidadeChamadosCadastrados()
        {
            return quantidadeChamadosCadastrados;
        }
        public Chamado[] getChamadosCadastrados()
        {
            return chamadosCadastrados;
        }

        public ConjuntoChamados(Chamado[] chamadosCadastrados, int quantidadeChamadosCadastrados)
        {
            this.chamadosCadastrados = chamadosCadastrados;
            this.quantidadeChamadosCadastrados = quantidadeChamadosCadastrados;
        }

        public int controleChamado(ConjuntoEquipamentos conjuntoEquipamentos)
        {
            int opcaoChamado = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            //adicionar
            if (opcaoChamado == 1)
            {
                string tituloChamado, descricaoChamado, idEquipamentoChamado, dataDeAberturaChamado;
                receberAtributosChamado(out tituloChamado, out descricaoChamado, out idEquipamentoChamado, out dataDeAberturaChamado);

                if (validarAtributosChamado(tituloChamado, descricaoChamado, idEquipamentoChamado, dataDeAberturaChamado, conjuntoEquipamentos.getEquipamentosCadastrados(), conjuntoEquipamentos.getQuantidadeEquipamentosCadastrados()))
                {
                    int idCorrecao = 1; //vai armazenar o equipamento no primeiro id zero que achar
                    foreach (Chamado c in chamadosCadastrados)
                    {
                        if (c == null)
                        {
                            string tituloChamadoValido = tituloChamado;
                            string descricaoChamadoValido = descricaoChamado;
                            int idEquipamentoChamadoValido = Convert.ToInt32(idEquipamentoChamado);
                            DateTime dataDeAberturaChamadoValido = Convert.ToDateTime(dataDeAberturaChamado);

                            Chamado novoChamado = new Chamado(idCorrecao, tituloChamadoValido, descricaoChamadoValido, idEquipamentoChamadoValido, dataDeAberturaChamadoValido);
                            chamadosCadastrados[idCorrecao - 1] = novoChamado;

                            Console.Clear();
                            Console.WriteLine("Chamado cadastrado com sucesso");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else if (c.getId() == 0)
                        {
                            string tituloChamadoValido = tituloChamado;
                            string descricaoChamadoValido = descricaoChamado;
                            int idEquipamentoChamadoValido = Convert.ToInt32(idEquipamentoChamado);
                            DateTime dataDeAberturaChamadoValido = Convert.ToDateTime(dataDeAberturaChamado);

                            Chamado novoChamado = new Chamado(idCorrecao, tituloChamadoValido, descricaoChamadoValido, idEquipamentoChamadoValido, dataDeAberturaChamadoValido);
                            chamadosCadastrados[idCorrecao - 1] = novoChamado;

                            Console.Clear();
                            Console.WriteLine("Chamado cadastrado com sucesso");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                            idCorrecao++;
                    }
                    quantidadeChamadosCadastrados++;
                }
                //break;

            }
            //editar
            else if (opcaoChamado == 2)
            {
                Console.WriteLine("Informe o id do chamado a ser editado:");
                string idChamado = Console.ReadLine();

                if (validarIdChamado(idChamado))
                {
                    int idChamadoValido = Convert.ToInt32(idChamado);
                    if (validarIdExistenteChamado(idChamadoValido, chamadosCadastrados, quantidadeChamadosCadastrados))
                    { 
                        Console.WriteLine("Informe o titulo do chamado:");
                        string tituloChamado = Console.ReadLine();

                        Console.WriteLine("Informe a descricao do chamado:");
                        string descricaoChamado = Console.ReadLine();

                        Console.WriteLine("Informe o id do equipamento:");
                        string idEquipamentoChamado = Console.ReadLine();

                        Console.WriteLine("Informe a data de abertura do chamado:");
                        string dataDeAberturaChamado = Console.ReadLine();


                        if (validarAtributosChamado(tituloChamado, descricaoChamado, idEquipamentoChamado, dataDeAberturaChamado, conjuntoEquipamentos.getEquipamentosCadastrados(), conjuntoEquipamentos.getQuantidadeEquipamentosCadastrados()))
                        {
                            string tituloChamadoValido = tituloChamado;
                            string descricaoChamadoValido = descricaoChamado;
                            int idEquipamentoChamadoValido = Convert.ToInt32(idEquipamentoChamado);
                            DateTime dataDeAberturaChamadoValido = Convert.ToDateTime(dataDeAberturaChamado);

                            Chamado novoChamado = new Chamado(idChamadoValido, tituloChamadoValido, descricaoChamadoValido, idEquipamentoChamadoValido, dataDeAberturaChamadoValido);
                            chamadosCadastrados[idChamadoValido - 1] = novoChamado;

                            Console.Clear();
                            Console.WriteLine("Chamado editado com sucesso");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("Valor de id chamado não está cadastrado, tente novamente");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Valor de id inválido, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            //excluir
            else if (opcaoChamado == 3)
            {
                Console.WriteLine("Informe o id do chamado a ser excluido:");
                string idChamado = Console.ReadLine();

                if (validarIdChamado(idChamado))
                {
                    int idChamadoValido = Convert.ToInt32(idChamado);
                    if (validarIdExistenteChamado(idChamadoValido, chamadosCadastrados, quantidadeChamadosCadastrados))
                    {
                        string tituloChamadoValido = null;
                        string descricaoChamadoValido = null;
                        int idEquipamentoChamadoValido = 0;
                        DateTime dataDeAberturaChamadoValido = DateTime.MinValue;

                        Chamado novoChamado = new Chamado(0, tituloChamadoValido, descricaoChamadoValido, idEquipamentoChamadoValido, dataDeAberturaChamadoValido);
                        chamadosCadastrados[idChamadoValido - 1] = novoChamado;
                        quantidadeChamadosCadastrados--;

                        Console.Clear();
                        Console.WriteLine("Chamado excluido com sucesso");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Valor de id chamado não cadastrado, tente novamente");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Valor de id inválido, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            //mostrar
            else if (opcaoChamado == 4)
            {
                Console.Clear();
                mostrarChamados();
            }
            //sair do menu chamado
            else if (opcaoChamado == 5)
            {
                Console.Clear();
            }
            //opcao invalida
            else
            {
                Console.WriteLine("Opção de menu equipamento inválida, tente novamente");
                Console.ReadLine();
            }
            return opcaoChamado;
        }

        private bool validarAtributosChamado(string tituloChamado, string descricaoChamado, string idEquipamentoChamado, string dataDeAberturaChamado, Equipamento[] equipamentosCadastrados, int quantidadeEquipamentos)
        {
            if (tituloChamado.Length < 1)
            {
                Console.Clear();
                Console.WriteLine("Titulo do chamado inválido, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            if (descricaoChamado.Length < 1)
            {
                Console.Clear();
                Console.WriteLine("Descrição do chamado inválido, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            //verificacao da data de abertura
            try
            {
                DateTime dataDeAberturaChamadoValido = Convert.ToDateTime(dataDeAberturaChamado);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Data inválida, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            //verificacao se id é existente
            try
            {
                int idEquipamentoChamadoValido = Convert.ToInt32(idEquipamentoChamado);
                if (validarIdExistenteEquipamento(idEquipamentoChamadoValido, equipamentosCadastrados, quantidadeEquipamentos))
                {
                    return true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("O id de equipamento fornecido não está cadastrado, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                    return false;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Id de equipamento  é inválido, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }
        }

        private bool validarIdChamado(string idChamado)
        {
            //verificacao se id do chamado pode ser convertido para int
            try
            {
                int idValido = Convert.ToInt32(idChamado);

                if (idValido <= 0)
                {
                    return false;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Número de id inválido, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }
            return true;
        }

        private bool validarIdExistenteEquipamento(int idCheck, Equipamento[] equipamentosCadastrados, int quantidadeEquipamentos)
        {
            //verificacao se o id já existe
            if (quantidadeEquipamentos == 0)
                return false;
            else
            {
                try
                {
                    for (int i = 0; i < quantidadeEquipamentos; i++)
                    {
                        if (equipamentosCadastrados[i].getId() == idCheck)
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Valor invalido de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
                return false;
            }

        }

        private bool validarIdExistenteChamado(int idCheck, Chamado[] chamadosCadastrados, int quantidadeChamadosCadastrados)
        {
            //verificacao se o id já existe
            if (quantidadeChamadosCadastrados == 0)
                return false;
            else
            {
                try
                {
                    for (int i = 0; i < 99; i++)
                    {
                        if (chamadosCadastrados[i].getId() == idCheck)
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Valor invalido de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
                return false;
            }

        }

        private void receberAtributosChamado(out string tituloChamado, out string descricaoChamado, out string idEquipamentoChamado, out string dataDeAberturaChamado)
        {
            Console.WriteLine("Informe o titulo do chamado:");
            tituloChamado = Console.ReadLine();
            Console.WriteLine("Informe a descricao do chamado:");
            descricaoChamado = Console.ReadLine();
            Console.WriteLine("Informe o id do equipamento:");
            idEquipamentoChamado = Console.ReadLine();
            Console.WriteLine("Informe a data de abertura do chamado:");
            dataDeAberturaChamado = Console.ReadLine();
        }

        private void mostrarChamados()
        {
            if (quantidadeChamadosCadastrados == 0)
            {
                Console.WriteLine("Não há chamados cadastrados");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                int chamadoContador = 0;
                Console.WriteLine("Chamados Cadastrados: ");
                for (int i = 0; i < 99; i++)
                {
                    if (chamadosCadastrados[i].getId() != 0)
                    {
                        Console.Write("Titulo:");
                        Console.WriteLine(chamadosCadastrados[i].getTitulo());

                        Console.Write("Descrição:");
                        Console.WriteLine(chamadosCadastrados[i].getDescricao());

                        Console.Write("Id de Equipamento:");
                        Console.WriteLine(chamadosCadastrados[i].getIdEquipamento());

                        Console.Write("Data de Abertura:");
                        Console.WriteLine(chamadosCadastrados[i].getDataDeAbertura().ToShortDateString());


                        Console.WriteLine();
                        Console.WriteLine();
                        chamadoContador++;
                    }
                    if (chamadoContador == quantidadeChamadosCadastrados)
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
