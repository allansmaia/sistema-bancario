using System;

namespace SistemaBancario
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public int ContaOrigemId { get; set; }
        public int ContaDestinoId { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }

        public Transacao(int id, string tipo, decimal valor, int contaOrigemId, string descricao, int contaDestinoId = 0)
        {
            Id = id;
            Tipo = tipo;
            Valor = valor;
            ContaOrigemId = contaOrigemId;
            ContaDestinoId = contaDestinoId;
            Data = DateTime.Now;
            Descricao = descricao;
        }
    }
}
