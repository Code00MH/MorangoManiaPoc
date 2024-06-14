using System;
using CRUD.Functions;

namespace PocTest_Fazenda {
    public class TelaCargos {
        public static void MenuCargo(string cargo) {
            while (true) {
                Console.Clear();
                Console.WriteLine("O que você deseja fazer na seção Cargo?\n");
                Console.WriteLine("1- Cadastrar Cargo\r\n2- Listar Cargos\r\n3- Atualizar Cargo\r\n4- Excluir Cargo\r\n");
                if (cargo == "Administrador") {
                    Console.WriteLine("5- Voltar para o menu de produção.");
                }
                char opcao = char.Parse(Console.ReadLine());

                switch (opcao) {

                    case '1':
                        Console.Clear();
                        Cargos.CadastrarCargo();
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey(true);
                        MenuCargo(TelaLogin.Cargo);
                        break;

                    case '2':
                        Console.Clear();
                        Cargos.ListarCargos();
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey(true);
                        MenuCargo(TelaLogin.Cargo);
                        break;

                    case '3':
                        Console.Clear();
                        int idCargo;

                        while (true) {
                            Console.WriteLine("Digite o ID do Cargo que deseja atualizar:");
                            if (!int.TryParse(Console.ReadLine(), out idCargo) || !Cargos.cargoExiste(idCargo)) {
                                Console.Clear();
                                Console.WriteLine("O ID inserido está inválido. Por favor, insira um número de ID válido.");
                            }
                            else {
                                Cargos.AtualizarCargos(idCargo);
                                Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                                Console.ReadKey(true);
                                MenuCargo(TelaLogin.Cargo);
                                break;
                            }
                        }
                        Cargos.AtualizarCargos(idCargo);
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Digite o ID do Cargo que deseja excluir: ");
                        int idDelete = int.Parse(Console.ReadLine());
                        Cargos.ExcluirCargos(idDelete);
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey(true);
                        MenuCargo(TelaLogin.Cargo);
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
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

    }
}
