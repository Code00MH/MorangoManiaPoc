using System;
using CRUD.Functions;

namespace PocTest_Fazenda {
    public class TelaFornecedor {

        public static void MenuFornecedor(string cargo) {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer na seção Fornecedor? \n");
            Console.WriteLine("1- Cadastrar Fornecedor\r\n2- Listar Fornecedores\r\n3- Atualizar Fornecedor\r\n4- Excluir Fornecedor\n");
            if (cargo == "Administrador" || cargo == "Gerente de produção") {
                Console.WriteLine("5- Voltar para o menu de produção");
            }
            char Fornecedor = char.Parse(Console.ReadLine());

            switch (Fornecedor) {

                case '1':
                    Console.Clear();
                    Fornecedores.CadastrarFornecedor();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    MenuFornecedor(TelaLogin.Cargo);
                    break;

                case '2':
                    Console.Clear();
                    Fornecedores.ListarFornecedores();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    MenuFornecedor(TelaLogin.Cargo);
                    break;

                case '3':
                    Console.Clear();
                    int idFornecedor;

                    while (true) {
                        Console.WriteLine("Digite o ID do fornecedor que deseja atualizar:");
                        if (!int.TryParse(Console.ReadLine(), out idFornecedor) || !Fornecedores.fornecedorExiste(idFornecedor)) {
                            Console.Clear();
                            Console.WriteLine("O ID inserido está inválido. Por favor, insira um número de ID válido.");
                        }
                        else {
                            Fornecedores.AtualizarFornecedor(idFornecedor);
                            Console.WriteLine("\nPressione qualquer tecla para retornar para o menu de fornecedor...");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                    break;

                case '4':
                    Console.Clear();
                    Console.WriteLine("Digite o ID do Fornecedor que deseja excluir: ");
                    int idDelete = int.Parse(Console.ReadLine());
                    Fornecedores.ExcluirFornecedor(idDelete);
                    Console.WriteLine("\nPressione qualquer tecla para voltar para o menu...");
                    Console.ReadKey(true);
                    MenuFornecedor(TelaLogin.Cargo);
                    break;

                case '5':
                    if (cargo == "Administrador" || cargo == "Gerente de produção") {
                        Console.Clear();
                        Program.MenuPrincipal(TelaLogin.Cargo);
                        return;
                    }
                    else {
                        Console.WriteLine("Acesso negado. Esta opção é apenas para administradores ou gerentes de produção.");
                        Console.ReadKey();
                        TelaProducao.MenuProducao(TelaLogin.Cargo);
                    }
                    break;

            }
        }





    }
}

