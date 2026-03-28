using System;

namespace SistemaBancario
{
    public static class Utils
    {
        public static int GerarIdConta()
        {
            return Dados.ProximoIdConta++;
        }

        public static int GerarIdTransacao()
        {
            return Dados.ProximoIdTransacao++;
        }

        public static string FormatarMoeda(decimal valor)
        {
            return valor.ToString("C2");
        }

        public static string FormatarData(DateTime data)
        {
            return data.ToString("dd/MM/yyyy HH:mm");
        }

        public static void ExibirSeparador()
        {
            Console.WriteLine("================================");
        }
    }
}
