using System;

namespace PocTest_Fazenda {
    public class TelaProducao {

        public static void MenuProducao(string cargo) {

            Console.WriteLine("Sistema de Produção\n");
            Console.WriteLine("Para onde deseja ir?\n");
            Console.WriteLine("1- Ir para Fornecedores\r\n2- Ir para Produtos\r\n3- Ir para Ferramentas\r\n4- Ir para Sementes\r\n5- Ir para Nutrientes\r\n");
            if (cargo == "Administrador") {
                Console.WriteLine("6- Voltar ao Menu Principal");
            }
            while (true) {
                char opcaoProducao = char.Parse(Console.ReadLine());
                switch (opcaoProducao) {
                    case '1':
                        Console.Clear();
                        TelaFornecedor.MenuFornecedor(TelaLogin.Cargo);
                        break;
                    case '2':
                        Console.Clear();
                        TelaProduto.MenuProduto(TelaLogin.Cargo);
                        break;
                    case '3':
                        Console.Clear();
                        TelaFerramenta.MenuFerramenta(TelaLogin.Cargo);
                        break;
                    case '4':
                        Console.Clear();
                        TelaSementes.MenuSemente(TelaLogin.Cargo);
                        break;
                    case '5':
                        Console.Clear();
                        TelaNutrientes.MenuNutriente(TelaLogin.Cargo);
                        break;
                    case '6':
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
                        Console.WriteLine("Digite uma opção válida.");
                        Console.ReadKey(true);
                        continue;
                }
            }
        }
    }
}
