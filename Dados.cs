using System.Collections.Generic;

namespace SistemaBancario
{
    public static class Dados
    {
        public static List<Conta> Contas = new List<Conta>();
        public static List<Transacao> Transacoes = new List<Transacao>();
        public static int ProximoIdConta = 1;
        public static int ProximoIdTransacao = 1;
        }
}
