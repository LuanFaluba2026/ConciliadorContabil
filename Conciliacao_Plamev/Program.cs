
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data.SQLite;

namespace Conciliacao_Plamev
{
    internal static class Program
    {

        public static List<CodigoContas> contasCadastradas = new List<CodigoContas>();
        public static List<Movimentacao> movimentacoes = new List<Movimentacao>();
        public static List<MovimentosAbertos> saldosEmAberto = new List<MovimentosAbertos>();
        public static void CadastrarConta(string codigo, string contaAnalitica, string nomeFornecedor, double saldo)
        {
            var conta = new CodigoContas
            {
                codigo = codigo,
                contaAnalitica = contaAnalitica,
                nomeFornecedor = nomeFornecedor,
                saldo = saldo
            };
            contasCadastradas.Add(conta);
        }

        public static void CadastrarMovimentacao(string codigoForn, string dataLancamento, string historico, double debito, double credito, string notaRef)
        {
            var movimentacao = new Movimentacao
            {
                codigoForn = codigoForn,
                dataLancamento = dataLancamento,
                historico = historico,
                debito = debito,
                credito = credito,
                notaRef = notaRef
            };
            movimentacoes.Add(movimentacao);
        }

        public static void CadastrarSaldo(string codigoForn, string dataMov, string notaRef, string historico, double credito)
        {
            var saldoAb = new MovimentosAbertos
            {
                codigoForn = codigoForn,
                dataMov = dataMov,
                notaRef = notaRef,
                historico = historico,
                credito = credito
            };
            saldosEmAberto.Add(saldoAb);
        }

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

}