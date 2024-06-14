using System;
using CRUD.Functions;

namespace PocTest_Fazenda {
    public class TelaCliente {
        public static void MenuCliente() {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer na seção Cliente?\n");
            Console.WriteLine("1- Cadastrar Cliente \r\n2- Listar Clientes \r\n3- Atualizar Clientes\r\n4- Excluir Cliente\r\n5- Voltar para o menu de vendas\n");

            while (true) {
                char opcaoCliente = char.Parse(Console.ReadLine());

                switch (opcaoCliente) {
                    case '1':
                        Console.Clear();
                        Clientes.CadastrarClientes();
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey(true);
                        MenuCliente();
                        break;
                    case '2':
                        Console.Clear();
                        Clientes.ListarClientes();
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey(true);
                        MenuCliente();
                        break;

                    case '3':
                        Console.Clear();
                        int idCliente;

                        while (true) {
                            Console.WriteLine("Digite o ID do cliente que deseja atualizar:");
                            if (!int.TryParse(Console.ReadLine(), out idCliente) || !Clientes.clienteExiste(idCliente)) {
                                Console.Clear();
                                Console.WriteLine("O ID inserido está inválido. Por favor, insira um número de ID válido.");
                            }
                            else {
                                Clientes.AtualizarCliente(idCliente);
                                Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                                Console.ReadKey(true);
                                MenuCliente();
                                break;
                            }
                        }                       
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Digite o ID do cliente que deseja excluir: ");
                        int idDelete = int.Parse(Console.ReadLine());
                        Clientes.ExcluirCliente(idDelete);
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey(true);
                        MenuCliente();
                        break;

                    case '5':
                        Console.Clear();
                        TelaVendas.MenuVendas(TelaLogin.Cargo);
                        break;

                    default:
                        Console.WriteLine("Por favor, insira uma opção válida: ");
                        continue;

                }
            }
        }

    }

}
