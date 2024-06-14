using System;
using CRUD.Functions;

namespace PocTest_Fazenda {
    public class TelaProduto {
        public static void MenuProduto(string cargo) {
            Console.WriteLine("O que você deseja fazer na seção Produtos?\n");
            Console.WriteLine("1- Cadastrar Produto \r\n2- Listar Produtos\r\n3- Atualizar produto\r\n4- Excluir produto\r\n");
            if (cargo == "Administrador") {
                Console.WriteLine("5- Voltar para o menu de produção");
            }
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 1:
                    Console.Clear();
                    Produtos.CadastrarProduto();
                    Console.WriteLine("\nPressione qualquer tecla para retornar para o menu...");
                    Console.ReadKey();
                    Console.Clear();
                    MenuProduto(TelaLogin.Cargo);
                    break;

                case 2:
                    Console.Clear();
                    Produtos.ListarProdutos();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    MenuProduto(TelaLogin.Cargo);
                    break;

                case 3:
                    Console.Clear();
                    int idProduto;

                    while (true) {
                        Console.WriteLine("Digite o ID do produto que deseja atualizar:");
                        if (!int.TryParse(Console.ReadLine(), out idProduto) || !Produtos.produtoExiste(idProduto)) {
                            Console.Clear();
                            Console.WriteLine("O ID inserido está inválido. Por favor, insira um número de ID válido.");
                        }
                        else {
                            Console.Clear();
                            Produtos.AtualizarProduto(idProduto);
                            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                            Console.ReadKey();
                            Console.Clear();
                            MenuProduto(TelaLogin.Cargo);
                            break;
                        }
                    }
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Digite o ID do produto que deseja excluir: ");
                    int idDelete = int.Parse(Console.ReadLine());
                    Produtos.ExcluirProduto(idDelete);
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey(true);
                    Console.Clear();
                    MenuProduto(TelaLogin.Cargo);
                    break;

                case 5:
                    if (cargo == "Administrador") {
                        Console.Clear();
                        TelaProducao.MenuProducao(TelaLogin.Cargo);
                        return;
                    }
                    else {
                        Console.WriteLine("Acesso negado. Esta opção é apenas para administradores.");
                    }
                    break;
            }
        }

    }

}
