using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev
{
    public class CodigoContas
    {
        public string? codigo { get; set; }
        public string? contaAnalitica { get; set; }
        public string? nomeFornecedor { get; set; }
        public double saldo { get; set; }
    }

    public class Movimentacao
    {
        public string? codigoForn { get; set; }
        public string? dataLancamento { get; set; }
        public string? historico { get; set; }
        public double debito { get; set; }
        public double credito { get; set; }
        public string? notaRef { get; set; }
    }

    public class MovimentosAbertos
    {
        public string? codigoForn { get; set; }
        public string? dataMov { get; set; }
        public string? notaRef { get; set; }
        public string? historico { get; set; }
        public double credito { get; set; }
        public string? dataEncerramento { get; set; }
    }
}
