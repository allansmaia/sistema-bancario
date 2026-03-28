using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBancario
{
    public static class Banco
    {
        public static Conta CriarConta(string titular, string cpf, decimal saldoInicial = 0)
        {
            if (!Validacao.ValidarNome(titular))
            {
                Console.WriteLine("Erro: Nome invalido.");
                return null;
            }
            if (!Validacao.ValidarCpf(cpf))
            {
                Console.WriteLine("Erro: CPF invalido.");
                return null;
            }
            var conta = new Conta(Utils.GerarIdConta(), titular, cpf, saldoInicial);
            Dados.Contas.Add(conta);
            Console.WriteLine($"Conta #{conta.Id} criada para {conta.Titular}!");
            return conta;
        }

        public static void Depositar(int contaId, decimal valor)
        {
            var conta = Dados.Contas.FirstOrDefault(c => c.Id == contaId);
            if (conta == null) { Console.WriteLine("Erro: Conta nao encontrada."); return; }
            if (!Validacao.ValidarDeposito(valor)) { Console.WriteLine("Erro: Valor invalido."); return; }

            conta.Saldo += valor;
            var transacao = new Transacao(Utils.GerarIdTransacao(), "Deposito", valor, contaId, "Deposito em conta");
            Dados.Transacoes.Add(transacao);
            Console.WriteLine($"Deposito de {Utils.FormatarMoeda(valor)} realizado com sucesso!");
        }

        public static void Sacar(int contaId, decimal valor)
        {
            var conta = Dados.Contas.FirstOrDefault(c => c.Id == contaId);
            if (conta == null) { Console.WriteLine("Erro: Conta nao encontrada."); return; }
            if (!Validacao.ValidarSaque(valor, conta.Saldo)) { Console.WriteLine("Erro: Saldo insuficiente."); return; }

            conta.Saldo -= valor;
            var transacao = new Transacao(Utils.GerarIdTransacao(), "Saque", valor, contaId, "Saque em conta");
            Dados.Transacoes.Add(transacao);
            Console.WriteLine($"Saque de {Utils.FormatarMoeda(valor)} realizado com sucesso!");
        }

        public static void Transferir(int contaOrigemId, int contaDestinoId, decimal valor)
        {
            var origem = Dados.Contas.FirstOrDefault(c => c.Id == contaOrigemId);
            var destino = Dados.Contas.FirstOrDefault(c => c.Id == contaDestinoId);
            if (origem == null || destino == null) { Console.WriteLine("Erro: Conta nao encontrada."); return; }
            if (!Validacao.ValidarTransferencia(valor, origem.Saldo)) { Console.WriteLine("Erro: Saldo insuficiente."); return; }

            origem.Saldo -= valor;
            destino.Saldo += valor;
            var transacao = new Transacao(Utils.GerarIdTransacao(), "Transferencia", valor, contaOrigemId, "Transferencia entre contas", contaDestinoId);
            Dados.Transacoes.Add(transacao);
            Console.WriteLine($"Transferencia de {Utils.FormatarMoeda(valor)} realizada com sucesso!");
        }

        public static void ExibirExtrato(int contaId)
        {
            var conta = Dados.Contas.FirstOrDefault(c => c.Id == contaId);
            if (conta == null) { Console.WriteLine("Erro: Conta nao encontrada."); return; }

            Utils.ExibirSeparador();
            Console.WriteLine($"Extrato - {conta.Titular}");
            Console.WriteLine($"Saldo atual: {Utils.FormatarMoeda(conta.Saldo)}");
            Utils.ExibirSeparador();

            var transacoes = Dados.Transacoes.Where(t => t.ContaOrigemId == contaId || t.ContaDestinoId == contaId).ToList();
            foreach (var t in transacoes)
            {
                Console.WriteLine($"{Utils.FormatarData(t.Data)} | {t.Tipo} | {Utils.FormatarMoeda(t.Valor)} | {t.Descricao}");
            }
            Utils.ExibirSeparador();
        }

        public static void ListarContas()
        {
            Utils.ExibirSeparador();
            Console.WriteLine("Contas cadastradas:");
            foreach (var c in Dados.Contas)
            {
                Console.WriteLine($"#{c.Id} | {c.Titular} | CPF: {c.Cpf} | Saldo: {Utils.FormatarMoeda(c.Saldo)}");
            }
            Utils.ExibirSeparador();
        }
    }
}
