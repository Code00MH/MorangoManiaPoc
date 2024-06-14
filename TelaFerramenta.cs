using System;
using CRUD.Functions;
using static CRUD.Functions.Vendas;

namespace PocTest_Fazenda {
    public class TelaFerramenta {

        public static void MenuFerramenta(string cargo) {
            while (true) {
                Console.Clear();
                Console.WriteLine("O que você deseja fazer na seção Ferramentas?\n");
                Console.WriteLine("1- Cadastrar Ferramenta\r\n2- Listar Ferramentas\r\n3- Atualizar Ferramenta\r\n4- Excluir Ferramenta\r\n");
                if (cargo == "Administrador") {
                    Console.WriteLine("5 - Voltar para o menu de produção\n");
                }
                
                char opcao = char.Parse(Console.ReadLine());

                switch (opcao) {
                    case '1':
                        Console.Clear();
                        Ferramentas.CadastrarFerramenta();
                        Console.WriteLine("\nPressione qualquer tecla para retornar para o menu...");
                        Console.ReadKey();
                        Console.Clear();
                        MenuFerramenta(TelaLogin.Cargo);
                        break;

                    case '2':
                        Console.Clear();
                        Ferramentas.ListarFerramentas();
                        Console.WriteLine("\nPressione qualquer tecla para retornar para o menu...");
                        Console.ReadKey();
                        Console.Clear();
                        MenuFerramenta(TelaLogin.Cargo);
                        break;

                    case '3':
                        Console.Clear();
                        int idFerramenta;

                        while (true) {
                            Console.WriteLine("Digite o ID da ferramenta que deseja atualizar:");
                            if (!int.TryParse(Console.ReadLine(), out idFerramenta) || !Ferramentas.ferramentaExiste(idFerramenta)) {
                                Console.Clear();
                                Console.WriteLine("O ID inserido está inválido. Por favor, insira um número de ID válido.");
                            }
                            else {
                                Ferramentas.AtualizarFerramenta(idFerramenta);
                                Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                                Console.ReadKey();
                                Console.Clear();
                                MenuFerramenta(TelaLogin.Cargo);
                                break;
                            }
                        }
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Digite o ID da ferramenta que deseja excluir: ");
                        int idDelete = int.Parse(Console.ReadLine());
                        Ferramentas.ExcluirFerramenta(idDelete);
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey(true);
                        MenuFerramenta(TelaLogin.Cargo);
                        break;

                    case '5':
                        if (cargo == "Administrador") {
                            Console.Clear();
                            TelaProducao.MenuProducao(TelaLogin.Cargo);
                            return;
                        }
                        else {
                            Console.WriteLine("Acesso negado. Esta opção é apenas para administradores.");
                        }
                        break;

                    default:
                        Console.WriteLine("Digite uma opção válida: ");
                        continue;
                }
            }
        }


    }
}
