namespace SistemaBancario
{
    public static class Validacao
    {
        public static bool ValidarDeposito(decimal valor)
        {
            return valor > 0;
        }

        public static bool ValidarSaque(decimal valor, decimal saldo)
        {
            return valor > 0 && valor <= saldo;
        }

        public static bool ValidarTransferencia(decimal valor, decimal saldo)
        {
            return valor > 0 && valor <= saldo;
        }

        public static bool ValidarNome(string nome)
        {
            return !string.IsNullOrWhiteSpace(nome) && nome.Length >= 3;
        }

        public static bool ValidarCpf(string cpf)
        {
            return !string.IsNullOrWhiteSpace(cpf) && cpf.Length == 11;
        }
    }
}
