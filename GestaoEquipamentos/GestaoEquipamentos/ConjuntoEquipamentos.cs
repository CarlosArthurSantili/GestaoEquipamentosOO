using GestaoEquipamentosPOO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos
{
    class ConjuntoEquipamentos
    {
        Equipamento[] equipamentosCadastrados = new Equipamento[99];
        int quantidadeEquipamentosCadastrados;

        public ConjuntoEquipamentos(Equipamento[] equipamentosCadastrados, int quantidadeEquipamentosCadastrados)
        {
            this.equipamentosCadastrados = equipamentosCadastrados;
            this.quantidadeEquipamentosCadastrados = quantidadeEquipamentosCadastrados;
        }

        //recebe informações e cadastra/altera/deleta/mostra um novo equipamento

        public Equipamento[] getEquipamentosCadastrados()
        {
            return equipamentosCadastrados;
        }

        public int getQuantidadeEquipamentosCadastrados() 
        {
            return quantidadeEquipamentosCadastrados;
        }

        public int controleEquipamento(ConjuntoChamados conjuntoChamados)
        {
            int opcaoEquipamento = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            //adicionar
            if (opcaoEquipamento == 1)
            {
                //Console.WriteLine("Cadastrar Equipamento");
                string nomeEquipamento, valorAquisicaoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento;
                receberAtributosEquipamento(out nomeEquipamento, out valorAquisicaoEquipamento, out numeroSerieEquipamento, out dataFabricacaoEquipamento, out fabricanteEquipamento);

                if (validarAtributosEquipamento(nomeEquipamento, valorAquisicaoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento))
                {
                    int idCorrecao = 1; //vai armazenar o equipamento no primeiro id zero que achar
                    foreach (Equipamento e in equipamentosCadastrados)
                    {
                        if (e == null)
                        {
                            string nomeEquipamentoValido = nomeEquipamento;
                            double valorAquisicaoEquipamentoValido = Convert.ToDouble(valorAquisicaoEquipamento);
                            int numeroSerieEquipamentoValido = Convert.ToInt32(numeroSerieEquipamento);
                            DateTime dataFabricacaoEquipamentoValido = Convert.ToDateTime(dataFabricacaoEquipamento);
                            string fabricanteEquipamentoValido = fabricanteEquipamento;

                            Equipamento novoEquipamento = new Equipamento(idCorrecao, nomeEquipamentoValido, valorAquisicaoEquipamentoValido, numeroSerieEquipamentoValido, dataFabricacaoEquipamentoValido, fabricanteEquipamentoValido);
                            equipamentosCadastrados[idCorrecao-1] = novoEquipamento;

                            Console.Clear();
                            Console.WriteLine("Equipamento cadastrado com sucesso");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else if (e.getId()==0)
                        {
                            string nomeEquipamentoValido = nomeEquipamento;
                            double valorAquisicaoEquipamentoValido = Convert.ToDouble(valorAquisicaoEquipamento);
                            int numeroSerieEquipamentoValido = Convert.ToInt32(numeroSerieEquipamento);
                            DateTime dataFabricacaoEquipamentoValido = Convert.ToDateTime(dataFabricacaoEquipamento);
                            string fabricanteEquipamentoValido = fabricanteEquipamento;

                            Equipamento novoEquipamento = new Equipamento(idCorrecao, nomeEquipamentoValido, valorAquisicaoEquipamentoValido, numeroSerieEquipamentoValido, dataFabricacaoEquipamentoValido, fabricanteEquipamentoValido);
                            equipamentosCadastrados[idCorrecao - 1] = novoEquipamento;

                            Console.Clear();
                            Console.WriteLine("Equipamento cadastrado com sucesso");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        idCorrecao++;
                    }
                    quantidadeEquipamentosCadastrados++;
                }
            }
            //editar
            else if (opcaoEquipamento == 2)
            {
                Console.WriteLine("Informe o id do equipamento a ser editado:");
                string idEquipamento = Console.ReadLine();

                if (validarIdEquipamento(idEquipamento))
                {
                    if (validarIdExistenteEquipamento(Convert.ToInt32(idEquipamento)))
                    {
                        Console.WriteLine("Informe o nome do equipamento:");
                        string nomeEquipamento = Console.ReadLine();

                        Console.WriteLine("Informe o preço de aquisição do equipamento:");
                        string valorAquisicaoEquipamento = Console.ReadLine();

                        Console.WriteLine("Informe o número de série do equipamento:");
                        string numeroSerieEquipamento = Console.ReadLine();

                        Console.WriteLine("Informe a data de fabricação do equipamento:");
                        string dataFabricacaoEquipamento = Console.ReadLine();

                        Console.WriteLine("Informe o fabricante do equipamento:");
                        string fabricanteEquipamento = Console.ReadLine();

                        if (validarAtributosEquipamento(nomeEquipamento, valorAquisicaoEquipamento, numeroSerieEquipamento, dataFabricacaoEquipamento, fabricanteEquipamento))
                        {

                            int idNovo = Convert.ToInt32(idEquipamento);
                            string nomeEquipamentoValido = nomeEquipamento;
                            double valorAquisicaoEquipamentoValido = Convert.ToDouble(valorAquisicaoEquipamento);
                            int numeroSerieEquipamentoValido = Convert.ToInt32(numeroSerieEquipamento);
                            DateTime dataFabricacaoEquipamentoValido = Convert.ToDateTime(dataFabricacaoEquipamento);

                            Equipamento novoEquipamento = new Equipamento(idNovo, nomeEquipamentoValido, valorAquisicaoEquipamentoValido, numeroSerieEquipamentoValido, dataFabricacaoEquipamentoValido, fabricanteEquipamento);

                            int alteraPosicao = 0;
                            foreach (Equipamento e in equipamentosCadastrados)
                            {
                                if (e.getId() == idNovo)
                                {
                                    equipamentosCadastrados[alteraPosicao] = novoEquipamento;

                                    Console.Clear();
                                    Console.WriteLine("Equipamento editado com sucesso");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                                }
                                alteraPosicao++;
                            }
                        }


                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("O id informado não está cadastrado, tente novamente");
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
            else if (opcaoEquipamento == 3)
            {
                Console.WriteLine("Informe o id do equipamento a ser excluido:");
                string idEquipamento = Console.ReadLine();

                if (validarIdEquipamento(idEquipamento))
                {
                    if (validarIdExistenteEquipamento(Convert.ToInt32(idEquipamento)))
                    {
                        int idNovo = 0;
                        string nomeEquipamentoValido = null;
                        double valorAquisicaoEquipamentoValido = 0;
                        int numeroSerieEquipamentoValido = 0;
                        DateTime dataFabricacaoEquipamentoValido = DateTime.MinValue;
                        string fabricanteEquipamentoValido = null;
                        Equipamento novoEquipamento = new Equipamento(idNovo, nomeEquipamentoValido, valorAquisicaoEquipamentoValido, numeroSerieEquipamentoValido, dataFabricacaoEquipamentoValido, fabricanteEquipamentoValido);
                        
                        int idCorrecao = Convert.ToInt32(idEquipamento);
                        int contadorEquipamento = 0;

                        for (int i = 0; i < 99; i++)
                        {
                            if (equipamentosCadastrados[i].getId() == idCorrecao)
                            {
                                if (validarExclusao(conjuntoChamados, idCorrecao))
                                {
                                    equipamentosCadastrados[idCorrecao - 1] = novoEquipamento;
                                    quantidadeEquipamentosCadastrados--;
                                    Console.Clear();
                                    Console.WriteLine("Equipamento excluido com sucesso");
                                    Console.ReadLine();
                                    break;
                                }
                                else 
                                {
                                    Console.Clear();
                                    Console.WriteLine("Não foi possível excluir o equipamento, ele está vinculado a um chamado, tente novamente");
                                    Console.ReadLine();
                                    break;
                                }
                            }
                            contadorEquipamento++;
                            if (contadorEquipamento == quantidadeEquipamentosCadastrados)
                                break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("O id informado não está cadastrado, tente novamente");
                        Console.ReadLine();
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Valor de id inválido, tente novamente");
                    Console.ReadLine();
                }
            }
            //mostrar
            else if (opcaoEquipamento == 4)
            {
                mostrarEquipamentos(quantidadeEquipamentosCadastrados, equipamentosCadastrados);
            }
            //sair do menu equipamento
            else if (opcaoEquipamento == 5)
            {
                Console.Clear();
            }
            //opcao invalida
            else
            {
                Console.WriteLine("Opção de menu equipamento inválida, tente novamente");
                Console.ReadLine();
            }
            return opcaoEquipamento;
        }

        private bool validarExclusao(ConjuntoChamados conjuntoChamados, int idEquipamento) 
        {
            int contadorConjuntos = 0;
            for (int i = 0; i < 99; i++)
            {
                if (conjuntoChamados.getChamadosCadastrados()[i].getIdEquipamento() == idEquipamento)
                {
                    return false;
                }
                contadorConjuntos++;
                if (contadorConjuntos == conjuntoChamados.getQuantidadeChamadosCadastrados())
                    break;
            }
            return true;
        }

        private bool validarAtributosEquipamento(string nomeEquipamento, string valorAquisicaoEquipamento, string numeroSerieEquipamento, string dataFabricacaoEquipamento, string fabricanteEquipamento)
        {
            if (nomeEquipamento.Length < 6)
            {
                Console.Clear();
                Console.WriteLine("Nome de equipamento deve ter pelo menos 6 letras, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            if (fabricanteEquipamento.Length < 1)
            {
                Console.Clear();
                Console.WriteLine("Fabricante inválido, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            //verificacao do valor de aquisicao
            try
            {
                double valorAquisicaoValido = Convert.ToInt32(valorAquisicaoEquipamento);

            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Numero do valor de aquisicao, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            //verificacao do numero de serie
            try
            {
                int numeroSerieValido = Convert.ToInt32(numeroSerieEquipamento);

            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Numero de série inválido, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            //verificacao da data fabricacao
            try
            {
                DateTime dataFabricacaoValido = Convert.ToDateTime(dataFabricacaoEquipamento);
                if (dataFabricacaoValido>DateTime.Now)
                {
                    Console.Clear();
                    Console.WriteLine("Data inválida ('data de fabricação futura'), tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                    return false;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Data inválida, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return false;
            }

            return true;
        }

        private bool validarIdEquipamento(string idEquipamento)
        {
            //verificacao se id do equipamento pode ser convertido para int
            try
            {
                int idValido = Convert.ToInt32(idEquipamento);

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

        private bool validarIdExistenteEquipamento(int idCheck)
        {
            //verificacao se o id já existe
            if (quantidadeEquipamentosCadastrados == 0)
                return false;
            else
            {
                int contador = 0;
                for (int i = 0; i < 99; i++)
                {
                    if (equipamentosCadastrados[i].getId() == idCheck)
                    {
                        return true;
                    }
                    contador++;
                    if (contador == quantidadeEquipamentosCadastrados)
                        break;
                }
                return false;
            }

        }

        private void receberAtributosEquipamento(out string nomeEquipamento, out string valorAquisicaoEquipamento, out string numeroSerieEquipamento, out string dataFabricacaoEquipamento, out string fabricanteEquipamento)
        {
            Console.WriteLine("Informe o nome do equipamento:");
            nomeEquipamento = Console.ReadLine();
            Console.WriteLine("Informe o preço de aquisição do equipamento:");
            valorAquisicaoEquipamento = Console.ReadLine();
            Console.WriteLine("Informe o número de série do equipamento:");
            numeroSerieEquipamento = Console.ReadLine();
            Console.WriteLine("Informe a data de fabricação do equipamento:");
            dataFabricacaoEquipamento = Console.ReadLine();
            Console.WriteLine("Informe o fabricante do equipamento:");
            fabricanteEquipamento = Console.ReadLine();
        }

        private void mostrarEquipamentos(int quantidadeEquipamentosCadastrados, Equipamento[] equipamentosCadastrados)
        {
            if (quantidadeEquipamentosCadastrados == 0)
            {
                Console.WriteLine("Não há equipamentos cadastrados");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                int equipamentoContador = 0; //contador de quantos equipamentos já foram mostrados
                Console.WriteLine("Equipamentos Cadastrados: ");
                for (int i = 0; i < 99; i++)
                {
                    if (equipamentosCadastrados[i].getId() != 0)
                    {
                        Console.Write("ID:");
                        Console.WriteLine(equipamentosCadastrados[i].getId());

                        Console.Write("Nome:");
                        Console.WriteLine(equipamentosCadastrados[i].getNome());

                        Console.Write("Valor Aquisição:");
                        Console.WriteLine(equipamentosCadastrados[i].getValorAquisicao());

                        Console.Write("Número de Série:");
                        Console.WriteLine(equipamentosCadastrados[i].getNumeroDeSerie());

                        Console.Write("Data Fabricação:");
                        Console.WriteLine(equipamentosCadastrados[i].getDataDeFabricacao().ToShortDateString());

                        Console.Write("Fabricante:");
                        Console.WriteLine(equipamentosCadastrados[i].getFabricante());


                        Console.WriteLine();
                        Console.WriteLine();
                        equipamentoContador++;
                    }

                    if (equipamentoContador == quantidadeEquipamentosCadastrados)
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
