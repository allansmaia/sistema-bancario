using System;

namespace SistemaBancario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema Bancario ===\n");

            // Criando contas
            Console.WriteLine("--- Criando contas ---");
            var conta1 = Banco.CriarConta("Allan Maia", "12345678901", 1000);
            var conta2 = Banco.CriarConta("Beth Maia", "98765432100", 500);
            var conta3 = Banco.CriarConta("Edson Maia", "11122233344", 0);

            // Listando contas
            Console.WriteLine("\n--- Contas cadastradas ---");
            Banco.ListarContas();

            // Depositos
            Console.WriteLine("\n--- Realizando depositos ---");
            Banco.Depositar(1, 500);
            Banco.Depositar(3, 1000);

            // Saques
            Console.WriteLine("\n--- Realizando saques ---");
            Banco.Sacar(1, 200);
            Banco.Sacar(2, 100);

            // Transferencias
            Console.WriteLine("\n--- Realizando transferencias ---");
            Banco.Transferir(1, 2, 300);
            Banco.Transferir(3, 1, 150);

            // Extratos
            Console.WriteLine("\n--- Extrato Allan Maia ---");
            Banco.ExibirExtrato(1);

            Console.WriteLine("\n--- Extrato Maria Silva ---");
            Banco.ExibirExtrato(2);

            // Testando validacoes
            Console.WriteLine("\n--- Testando validacoes ---");
            Banco.CriarConta("Ab", "123", 0);
            Banco.Sacar(1, 99999);
            Banco.Depositar(1, -100);
        }
    }
}
