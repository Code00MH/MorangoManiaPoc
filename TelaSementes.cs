using CRUD.Functions;
using System;

namespace PocTest_Fazenda {
    public class TelaSementes {
        public static void MenuSemente(string cargo) {
            Console.WriteLine("O que você deseja fazer na seção Nutrientes?\n");
            Console.WriteLine("1- Cadastrar Nutriente \r\n2- Listar Nutrientes\r\n3- Atualizar Nutriente\r\n4- Excluir Nutriente\r\n");
            if (cargo == "Administrador") {
                Console.WriteLine("5- Voltar para o menu de produção");
            }

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 1:
                    Console.Clear();
                    Sementes.CadastrarSemente();
                    Console.WriteLine("\nPressione qualquer tecla para retornar para o menu...");
                    Console.ReadKey();
                    Console.Clear();
                    MenuSemente(TelaLogin.Cargo);
                    break;

                case 2:
                    Console.Clear();
                    Sementes.ListarSemente();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    MenuSemente(TelaLogin.Cargo);
                    break;

                case 3:
                    Console.Clear();
                    int idSemente;

                    while (true) {
                        Console.WriteLine("Digite o ID da semente que deseja atualizar:");
                        if (!int.TryParse(Console.ReadLine(), out idSemente) || !Sementes.sementeExiste(idSemente)) {
                            Console.Clear();
                            Console.WriteLine("O ID inserido está inválido. Por favor, insira um número de ID válido.");
                        }
                        else {
                            Sementes.AtualizarSemente(idSemente);
                            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                            Console.ReadKey(true);
                            Console.Clear();
                            MenuSemente(TelaLogin.Cargo);
                            break;
                        }
                    }

                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Digite o ID da semente que deseja excluir: ");
                    int idDelete = int.Parse(Console.ReadLine());
                    Sementes.ExcluirSemente(idDelete);
                    Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                    Console.ReadKey(true);
                    MenuSemente(TelaLogin.Cargo);
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
    

