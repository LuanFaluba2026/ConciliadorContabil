using DocumentFormat.OpenXml.Wordprocessing;
using System.Data.SQLite;

namespace Conciliacao_Plamev.Scripts
{
    internal static class Program
    {

        public static string ClienteFornecedor()
        {
            string dbName = Path.GetFileName(Path.Combine(Form1.dbPath, BancoDeDados._empresa) + ".sqlite");
            if (dbName.Contains("_Fornecedor", StringComparison.OrdinalIgnoreCase))
            {
                return "Fornecedor";
            }
            else if (dbName.Contains("_Cliente", StringComparison.OrdinalIgnoreCase))
            {
                return "Cliente";
            }
            else
            {
                return "invalidName";
            }
            
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