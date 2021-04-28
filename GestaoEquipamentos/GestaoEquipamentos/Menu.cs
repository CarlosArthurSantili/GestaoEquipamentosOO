using GestaoEquipamentosPOO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEquipamentos
{
    class Menu
    {

        public void declaracaoVariaveisMain(out ConjuntoEquipamentos conjuntoEquipamentos, out ConjuntoChamados conjuntoChamados, out int opcaoMenu)
        {
            int quantidadeEquipamentosCadastrados = 0;
            int quantidadeChamadosCadastrados = 0;
            Equipamento[] equipamentosCadastrados = new Equipamento[99];
            Chamado[] chamadosCadastrados = new Chamado[99];

            conjuntoEquipamentos = new ConjuntoEquipamentos(equipamentosCadastrados, quantidadeEquipamentosCadastrados);
            conjuntoChamados = new ConjuntoChamados(chamadosCadastrados, quantidadeChamadosCadastrados);
            opcaoMenu = 0;
        }

        public int controleMenu(ConjuntoEquipamentos conjuntoEquipamentos, ConjuntoChamados conjuntoChamados)
        {
            try
            {
                int opcaoMenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (opcaoMenu)
                {
                    case 1://equipamento
                        {
                            int opcaoEquipamento = '0';
                            //menu Equipamento
                            while (opcaoEquipamento != 5)
                            {
                                exibirMenuEquipamento();
                                opcaoEquipamento = conjuntoEquipamentos.controleEquipamento(conjuntoChamados);
                            }
                            break;
                        }
                    case 2://chamado
                        {
                            int opcaoChamado = '0';
                            while (opcaoChamado != 5)
                            {
                                exibirMenuChamado();
                                opcaoChamado = conjuntoChamados.controleChamado(conjuntoEquipamentos);
                            }
                            break;
                        }
                    case 3://sair
                        {
                            break;
                        }
                    default://opcao invalida
                        {
                            Console.WriteLine("Opção de menu inválida, tente novamente");
                            Console.ReadLine();
                            break;
                        }
                }
                return opcaoMenu;
            }
            catch
            {
                Console.WriteLine("Valor de opção inválido, tente novamente");
                Console.ReadLine();
                Console.Clear();
                return 0;
            }

        }

        public void exibirMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Opção 1 - Equipamento");
            Console.WriteLine("Opção 2 - Chamado");
            Console.WriteLine("Opção 3 - Sair da aplicação");

            Console.WriteLine("Digite a opcao desejada: ");
        }

        private void exibirMenuEquipamento()
        {
            Console.Clear();
            Console.WriteLine("Menu de Equipamento: ");
            Console.WriteLine("Opção 1 - Cadastrar");
            Console.WriteLine("Opção 2 - Editar");
            Console.WriteLine("Opção 3 - Excluir");
            Console.WriteLine("Opção 4 - Mostrar");
            Console.WriteLine("Opção 5 - Voltar ao Menu");

            Console.WriteLine("Digite a opcao desejada: ");
        }

        private void exibirMenuChamado()
        {
            Console.Clear();
            Console.WriteLine("Menu de Chamado: ");
            Console.WriteLine("Opção 1 - Cadastrar");
            Console.WriteLine("Opção 2 - Editar");
            Console.WriteLine("Opção 3 - Excluir");
            Console.WriteLine("Opção 4 - Mostrar");
            Console.WriteLine("Opção 5 - Voltar ao Menu");

            Console.WriteLine("Digite a opcao desejada: ");
        }
    }
}
