using System;
using CRUD.Functions;

namespace PocTest_Fazenda {
    public class TelaNutrientes {
        
        public static void MenuNutriente(string cargo) {
            Console.WriteLine("O que você deseja fazer na seção Nutrientes?\n");
            Console.WriteLine("1- Cadastrar Nutriente \r\n2- Listar Nutrientes\r\n3- Atualizar Nutriente\r\n4- Excluir Nutriente\r\n");
            if (cargo == "Administrador") {
                Console.WriteLine("5- Voltar para o menu de produção");
            }
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao) {
                case 1:
                    Console.Clear();
                    Nutrientes.CadastrarNutriente();
                    Console.WriteLine("\nPressione qualquer tecla para retornar para o menu...");
                    Console.ReadKey();
                    Console.Clear();
                    MenuNutriente(TelaLogin.Cargo);
                    break;

                case 2:
                    Console.Clear();
                    Nutrientes.ListarNutriente();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    MenuNutriente(TelaLogin.Cargo);
                    break;

                case 3:
                    Console.Clear();
                    int idNutriente;

                    while (true) {
                        Console.WriteLine("Digite o ID do nutriente que deseja atualizar:");
                        if (!int.TryParse(Console.ReadLine(), out idNutriente) || !Nutrientes.nutrienteExiste(idNutriente)) {
                            Console.Clear();
                            Console.WriteLine("O ID inserido está inválido. Por favor, insira um número de ID válido.");
                        }
                        else {
                            Console.Clear();
                            Nutrientes.AtualizarNutriente(idNutriente);
                            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
                            Console.ReadKey();
                            Console.Clear();
                            MenuNutriente(TelaLogin.Cargo);
                            break;
                        }
                    }
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Digite o ID do nutriente que deseja excluir: ");
                    int idDelete = int.Parse(Console.ReadLine());
                    Nutrientes.ExcluirNutriente(idDelete);
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey(true);
                    Console.Clear();
                    MenuNutriente(TelaLogin.Cargo);
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
    