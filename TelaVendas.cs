using System;
using CRUD.Functions;
namespace PocTest_Fazenda {

    public class TelaVendas {
        public static void MenuVendas(string cargo) {
            Console.WriteLine("Sistema de Vendas\n");
            Console.Write("1- Ir para seção Clientes\r\n2- Gerar pedido de venda\r\n");
            if (cargo == "Administrador") {
                Console.WriteLine("3- Voltar para o menu.");
            }

            while (true) {
                char opcaoVendas = char.Parse(Console.ReadLine());

                switch (opcaoVendas) {
                    case '1':
                        Console.Clear();
                        TelaCliente.MenuCliente();
                        break;
                    case '2':
                        Console.Clear();
                        Vendas.GerarPedidoVenda("pix", "CartaoCredito", "CartaoDebito");
                        Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                        Console.ReadKey(true);
                        Console.Clear();
                        TelaVendas.MenuVendas(TelaLogin.Cargo);
                        break;
                    case '3':
                        if (cargo == "Administrador") {
                            Console.Clear();
                            Program.MenuPrincipal(TelaLogin.Cargo);
                            return;
                        }
                        else {
                            Console.WriteLine("Acesso negado. Esta opção é apenas para administradores.");
                        }
                        break;
                    default:
                        Console.WriteLine("Insira uma opção válida.");
                        continue;
                }
            }
        }

    }
}

