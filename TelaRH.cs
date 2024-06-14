using System;

namespace PocTest_Fazenda {
    public class TelaRH {
        
        public static void MenuRH(string cargo) {
            Console.WriteLine("Sistema de Recursos Humanos\n");
            Console.WriteLine("Para onde deseja ir?\n");
            Console.WriteLine("1- Ir para Colaboradores\r\n2- Ir para Cargos\r\n");
            if (cargo == "Administrador") {
                Console.WriteLine("3- Voltar para o menu.");
            }
            while (true) {
                char opcaoProducao = char.Parse(Console.ReadLine());
                switch (opcaoProducao) {
                    case '1':
                        Console.Clear();
                        TelaColaborador.MenuColaborador();
                        break;
                    case '2':
                        Console.Clear();
                        TelaCargos.MenuCargo(TelaLogin.Cargo);
                        break;

                    case '3':
                        if (cargo == "Administrador") {
                            Console.Clear();
                            Program.MenuPrincipal(TelaLogin.Cargo);
                            return;
                        } break;
                    default:
                        Console.WriteLine("Digite uma opção válida.");
                        Console.ReadKey(true);
                        continue;
                }
            }
        }
    }
}
