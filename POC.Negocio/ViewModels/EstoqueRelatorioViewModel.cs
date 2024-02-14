using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.ViewModels
{
    public class EstoqueRelatorioViewModel
    {
        public string Data { get; set; }
        public string Quantidade { get; set; }
        public string Valor { get; set; }
        public string TipoOperacao { get; set; }

        public string QuantidadeSaldo { get; set; }
        public string ValorSaldo { get; set; }
    }
}
