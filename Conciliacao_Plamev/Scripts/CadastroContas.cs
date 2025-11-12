using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev.Scripts
{
    public class CodigoContas
    {
        public string? codigoForn { get; set; }
        public string? contaAnalitica { get; set; }
        public string? nomeForn { get; set; }
    }

    public class Movimento
    {
        public long idx { get; set; }
        public string? codigoForn { get; set; }
        public string? dataMov { get; set; }
        public string? historico { get; set; }
        public double debito { get; set; }
        public double credito { get; set; }
        public string? notaRef { get; set; }
        public string? dataEncerramento { get; set; }
    }
}
