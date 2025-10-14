using DocumentFormat.OpenXml.ExtendedProperties;
using System.Diagnostics;
using System.Windows.Forms;

namespace Conciliacao_Plamev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private async void ProcessButton_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new();
            ConverterRazao conv = new();
            SheetLayout sheetL = new();
            Form1 form = new();

            logBox.AppendText("\r\nIniciando Processamento...\r\n");
            sw.Start();
            await Task.Run(() =>
            {
                Dictionary<string, List<(string, string, string, string, string, string)>> dic = conv.Conversao();
                sheetL.CreateSheet(dic);


                Invoke(new Action(() =>
                {
                    foreach (var i in dic)
                    {
                        foreach (var j in i.Value)
                        {
                            Debug.WriteLine(j.ToString());
                            logBox.AppendText($"{j.ToString()}\r\n");
                        }
                    }
                }));

            });
            sw.Stop();
            logBox.AppendText($"\r\n Processamento Concluído ! ({sw.Elapsed.ToString(@"hh\:mm\:ss")})");
        }

        public void MostrarLog(Dictionary<string, List<(string, string, string, string, string, string)>> dic)
        {
            
        }
    }
}
