using System;
using CRUD.Functions;

namespace PocTest_Fazenda {
    public class TelaColaborador {
        public static void MenuColaborador() {

            while (true) {

                Console.Clear();
                Console.WriteLine("O que você deseja fazer na seção Colaborador?\n");
                Console.WriteLine("1- Cadastrar Colaborador\r\n2- Listar Colaboradores\r\n3- Atualizar Colaborador\r\n4- Excluir Colaborador\r\n5- Voltar para o menu de RH\n");

                char opcao = char.Parse(Console.ReadLine());

                switch (opcao) {

                    case '1':
                        Console.Clear();
                        Colaboradores.CadastrarColaborador();
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey();
                        MenuColaborador();
                        break;

                    case '2':
                        Console.Clear();
                        Colaboradores.ListarColaboradores();
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                        Console.ReadKey();
                        MenuColaborador();
                        break;

                    case '3':
                        Console.Clear();
                        int idColaborador;

                        while (true) {
                            Console.WriteLine("Digite o ID do colaborador que deseja atualizar:");
                            if (!int.TryParse(Console.ReadLine(), out idColaborador) || !Colaboradores.colaboradorExiste(idColaborador)) {
                                Console.Clear();
                                Console.WriteLine("O ID inserido está inválido. Por favor, insira um número de ID válido.");
                            }
                            else {
                                Colaboradores.AtualizarColaborador(idColaborador);
                                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                                Console.ReadKey(true);
                                Console.Clear();
                                MenuColaborador();
                                break;
                            }
                        }
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Digite o ID do colaborador que deseja excluir: ");
                        int idDelete = int.Parse(Console.ReadLine());
                        Colaboradores.ExcluirColaborador(idDelete);
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey();
                        MenuColaborador();
                        break;

                    case '5':
                        Console.Clear();
                        TelaRH.MenuRH(TelaLogin.Cargo);
                        break;

                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        Console.ReadKey();
                        continue;
                }
            }
        }

    }
}

