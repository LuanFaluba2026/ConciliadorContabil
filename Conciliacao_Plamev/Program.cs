
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data.SQLite;

namespace Conciliacao_Plamev
{
    /*public class BancoDeDados
    {
        private static string path = "Dados.db";
        private static string conexao = $"Data Source={path};Version=3;";
        public static SQLiteConnection Connect()
        {
            if (!File.Exists(path))
            {
                SQLiteConnection.CreateFile(path);
                CriarTabelas();
            }
            return new SQLiteConnection(conexao);
        }

        private static void CriarTabelas()
        {
            using (var con = new SQLiteConnection(conexao))
            {
                con.Open();
                string sql =
                    @"CREATE TABLE IF NOT EXISTS contas (
                    codigo TEXT PRIMARY KEY,
                    conta TEXT NOT NULL,
                    notaRef TEXT,
                    historico)"
            }
        }
    }*/

    internal static class Program
    {

        public static List<CodigoContas> contasCadastradas = new List<CodigoContas>();
        public static List<Movimentacao> movimentacoes = new List<Movimentacao>();
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

        public static void cadastrarMovimentacao(string codigoForn, string dataLancamento, string historico, double debito, double credito)
        {
            var movimentacao = new Movimentacao
            {
                codigoForn = codigoForn,
                dataLancamento = dataLancamento,
                historico = historico,
                debito = debito,
                credito = credito
            };
            movimentacoes.Add(movimentacao);
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