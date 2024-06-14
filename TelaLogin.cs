using System;
using System.Data.SqlClient;
using System.Threading;

namespace PocTest_Fazenda {
    public class TelaLogin {
        private string connectionString = "Data Source=localhost;Initial Catalog=FazendaUrbana;User ID=sa;Password=Mateus.80;";

        public static string Cargo;

        public bool RealizarLogin() {
            Console.WriteLine(@"
888b     d888                                                          888b     d888                   d8b          
8888b   d8888                                                          8888b   d8888                   Y8P          
88888b.d88888                                                          88888b.d88888                                
888Y88888P888  .d88b.  888d888 8888b.  88888b.   .d88b.   .d88b.       888Y88888P888  8888b.  88888b.  888  8888b.  
888 Y888P 888 d88""88b 888P""      ""88b 888 ""88b d88P""88b d88""88b      888 Y888P 888     ""88b 888 ""88b 888     ""88b 
888  Y8P  888 888  888 888    .d888888 888  888 888  888 888  888      888  Y8P  888 .d888888 888  888 888 .d888888 
888   ""   888 Y88..88P 888    888  888 888  888 Y88b 888 Y88..88P      888   ""   888 888  888 888  888 888 888  888 
888       888  ""Y88P""  888    ""Y888888 888  888  ""Y88888  ""Y88P""       888       888 ""Y888888 888  888 888 ""Y888888 
                                                     888                                                            
                                                Y8b d88P                                                            
                                                 ""Y88P""                                                                                                                                                                                              
");

            while (true) {
                Console.WriteLine("Bem-Vindo ao Sistema da Fazenda Urbana! Aqui, na Morango Mania, tem tudo e mais um pouco!\r");
                Console.WriteLine("Para começarmos, escolha uma opção:\r\n");
                Console.WriteLine("1- Fazer Login\n2- Sair do Programa \r\n");

                char opcao = char.Parse(Console.ReadLine());

                switch (opcao) {
                    case '1':
                        Console.Clear();
                        bool loginSuccessful = false;

                        do {
                            Console.Write("Digite seu CPF: ");
                            string cpf = Console.ReadLine();

                            Console.Write("Digite a senha: ");
                            string senha = InputSenha();

                            string cargo = VerificarUsuario(cpf, senha);
                            if (!string.IsNullOrEmpty(cargo)) {
                                Cargo = cargo;
                                ExibirMenuPorCargo(cargo);
                                loginSuccessful = true;
                            }
                            else {
                                Console.WriteLine("CPF ou senha incorreta. Tente novamente.");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                        } while (!loginSuccessful);
                        break;
                        

                    case '2':
                        Environment.Exit(0);
                        break;
                    
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        continue;
                }
            }
        }

        private static string InputSenha() {
            string password = "";
            ConsoleKeyInfo key;

            do {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace) {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0) {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }

        private string VerificarUsuario(string cpf, string senha) {
            string query = "SELECT Cargo FROM Cadastro WHERE CPF = @CPF AND Senha = @Senha";

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CPF", cpf);
                command.Parameters.AddWithValue("@Senha", senha);

                connection.Open();
                return command.ExecuteScalar()?.ToString();
            }
        }

        public static void ExibirMenuPorCargo(string cargo) {
            switch (cargo) {
                case "Administrador":
                    Console.Clear();
                    Program.MenuPrincipal(Cargo);
                    break;
                case "Gerente de vendas":
                case "Vendedor":
                    Console.Clear();
                    TelaVendas.MenuVendas(Cargo);
                    break;
                case "Gerente de RH":
                    Console.Clear();
                    TelaRH.MenuRH(TelaLogin.Cargo);
                    break;
                case "Gerente de produção":
                    Console.Clear();
                    TelaProducao.MenuProducao(TelaLogin.Cargo);
                    break;
                default:
                    Console.WriteLine("Cargo inválido.");
                    break;
            }
        }

    }
}