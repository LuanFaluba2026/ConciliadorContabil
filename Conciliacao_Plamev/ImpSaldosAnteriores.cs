using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev
{
    internal class ImpSaldosAnteriores
    {
        public static void ImportarSaldo(string path)
        {
            //@"C:\Users\luan\Downloads\MOVIMENTACOES EM ABERTO.csv";=
            try
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string[] lines = File.ReadAllLines(path, Encoding.GetEncoding("Windows-1252"));
                foreach (string line in lines.Skip(1))
                {
                    string[] col = line.Split(";");
                    if (BancoDeDados.GetContas().Any(x => x.codigoForn == col[0]))
                    {
                        BancoDeDados.AddMovimento(new Movimento()
                        {
                            codigoForn = col[0],
                            dataMov = col[1],
                            notaRef = col[2],
                            historico = col[3],
                            credito = double.Parse(col[4])
                        });
                    }
                    else
                    {
                        throw new Exception($"Fornecedor não encontrado. Codigo: {col[0]}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
