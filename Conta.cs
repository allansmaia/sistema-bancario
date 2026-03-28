using System;

namespace SistemaBancario
{
    public class Conta
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public string Cpf { get; set; }
        public decimal Saldo { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativa { get; set; }

        public Conta(int id, string titular, string cpf, decimal saldoInicial)
        {
            Id = id;
            Titular = titular;
            Cpf = cpf;
            Saldo = saldoInicial;
            DataCriacao = DateTime.Now;
            Ativa = true;
        }
    }
}
