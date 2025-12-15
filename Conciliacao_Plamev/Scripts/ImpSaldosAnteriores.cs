using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev.Scripts
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
                var naoEncontrados = new List<string>();
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
                            debito = -Math.Abs(double.Parse(col[4])),
                            credito = double.Parse(col[5])
                        });
                    }
                    else
                    {
                        if(!naoEncontrados.Any(x => x.Contains(col[0])))
                            naoEncontrados.Add($"Conta - {col[0]} Descrição - {col[3]}");
                    }
                }
                if (naoEncontrados.Count == 0)
                    return;
                SaveFileDialog sfd = new();
                sfd.FileName = "log-NãoEcontrados.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllLines(sfd.FileName, naoEncontrados);
                }
                MessageBox.Show("Processamento Concluído");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
