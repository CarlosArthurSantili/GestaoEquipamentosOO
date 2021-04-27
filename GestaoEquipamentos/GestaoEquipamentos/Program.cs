using GestaoEquipamentos;
using System;

//Equipamento (id, nome, precoAquisicao, numeroSerie, dataDeFabricacao, fabricante)
//Cadastrar - OK
//Editar - OK
//Excluir - OK
//Mostrar - OK

//Chamado (id, titulo, descricao, idEquipamento, dataDeAbertura)
//Criar - OK
//Editar - OK
//Excluir - OK
//Mostrar - OK

//Menu's (Loop com opções) - OK

//Validações
//Equipamento - OK
//Manutencao - OK

//Refatorar
//Classe ConjuntoEquipamentos - OK
//Classe ConjuntoChamados - OK
//Classe Menu - OK

namespace GestaoEquipamentosPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            ConjuntoEquipamentos conjuntoEquipamentos;
            ConjuntoChamados conjuntoChamados;
            int opcaoMenu;
            menu.declaracaoVariaveisMain(out conjuntoEquipamentos, out conjuntoChamados, out opcaoMenu);
            while (opcaoMenu != 3)
            {
                menu.exibirMenuPrincipal();
                opcaoMenu = menu.controleMenu(conjuntoEquipamentos, conjuntoChamados);
            }
        }
    }
}