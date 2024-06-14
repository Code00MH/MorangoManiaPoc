using System;
using System.Data.SqlClient;
using System.Threading;

namespace PocTest_Fazenda {
    public class TelaCadastro {
        static string connectionString = @"Data Source=localhost;Initial Catalog=FazendaUrbana;User ID=sa;Password=Mateus.80;";

        // main para realização de cadastro
        public static void RealizarCadastro() {
            try {
                while (true) {
                    string nome, cpf, cargo, email, senha, confirmarSenha;

                    Console.WriteLine("Digite o Nome: ");
                    nome = Console.ReadLine();
                    Console.WriteLine("Digite o CPF: ");
                    cpf = Console.ReadLine();
                    Console.WriteLine("Escolha o cargo do colaborador: ");
                    Console.WriteLine("1- Gerente de vendas");
                    Console.WriteLine("2- Gerente de RH");
                    Console.WriteLine("3- Gerente de produção");
                    Console.WriteLine("4- Vendedor");

                    char opcao = char.Parse(Console.ReadLine());
                    switch (opcao) {
                        case '1':
                            cargo = "Gerente de vendas";
                            break;
                        case '2':
                            cargo = "Gerente de RH";
                            break;
                        case '3':
                            cargo = "Gerente de produção";
                            break;
                        case '4':
                            cargo = "Vendedor";
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                            continue;
                    }

                    Console.WriteLine("Digite o E-mail: ");
                    email = Console.ReadLine();

                    do {
                        Console.WriteLine("Digite a senha do colaborador: ");
                        senha = InputSenha();
                        Console.WriteLine("Digite novamente a senha:");
                        confirmarSenha = InputSenha();

                        if (senha != confirmarSenha) {
                            Console.WriteLine("As senhas não são iguais. Por favor, tente novamente.");
                        }
                    } while (senha != confirmarSenha);

                    Console.WriteLine("Aguarde enquanto cadastramos na nossa base de dados...");
                    Thread.Sleep(2000);
                    Cadastro(nome, cpf, cargo, email, senha);
                    break;
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Ocorreu um erro ao cadastrar: {ex.Message} ");
                Console.ReadKey();
            }
        }

        // confirmação de cadastro
        static void Cadastro(string Nome, string CPF, string Cargo, string Email, string Senha) {
            string query = "INSERT INTO Cadastro (NomeFull, CPF, Cargo, Email, Senha) VALUES (@NomeFull, @CPF, @Cargo, @Email, @Senha)";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NomeFull", Nome);
                    command.Parameters.AddWithValue("@CPF", CPF);
                    command.Parameters.AddWithValue("@Cargo", Cargo);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Senha", Senha);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Colaborador cadastrado com sucesso!");
                    Thread.Sleep(2000);
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    Console.Clear();
                    Program.MenuPrincipal(TelaLogin.Cargo);
                }
                catch (Exception ex) {
                    Console.WriteLine($"Ocorreu um erro ao cadastrar: {ex.Message} ");
                    Console.ReadKey();
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
    }
}
