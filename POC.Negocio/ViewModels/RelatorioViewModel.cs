using POC.Negocio.Enumerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.ViewModels
{
    public class RelatorioViewModel
    {
        public string DataDe { get; set; }
        public string DataAte { get; set; }
        public int FornecedorId { get; set; }
        public int MaterialId { get; set; }
        public TipoOperacao TipoOperacao { get; set; }
    }
}
