using PocTest_Fazenda;
using System;
using System.Threading;
class Program {
    static void Main(string[] args) {
        TelaLogin login = new TelaLogin();
        if (login.RealizarLogin()) {
            Console.WriteLine("Login feito com sucesso!");
            Thread.Sleep(1000);
            Console.WriteLine("Aguarde um instante para entrar no menu de opções...");
            Thread.Sleep(1000);
            MenuPrincipal(TelaLogin.Cargo);
        }
    }
    //Menu Principal
    public static void MenuPrincipal(string cargo) {
        Console.Clear();
        Console.WriteLine("Menu de Opções Fazenda Urbana: \n");
        Console.WriteLine("Digite qual opção deseja: \n");
        Console.WriteLine("1- Fazer Cadastro\r\n2- Sistema de Produção\r\n3- Sistema de Vendas\r\n4- Sistema de RH\r\n5- Sair do Programa");

        while (true) {
            char opcao = char.Parse(Console.ReadLine());
            switch (opcao) {
                case '1':
                    Console.Clear();
                    TelaCadastro.RealizarCadastro();
                    break;
                case '2':
                    Console.Clear();
                    TelaProducao.MenuProducao(TelaLogin.Cargo);
                    break;

                case '3':
                    Console.Clear();
                    TelaVendas.MenuVendas(cargo);
                    break;

                case '4':
                    Console.Clear();
                    TelaRH.MenuRH(TelaLogin.Cargo);
                    break;

                case '5':
                    Environment.Exit(0);
                    return;

                default:
                    Console.WriteLine("Digite uma opção válida.");
                    Console.ReadKey(true);
                    continue;

            }
        }
    }
}





