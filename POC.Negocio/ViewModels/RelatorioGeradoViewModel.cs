
using POC.Negocio.Enumerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.ViewModels
{
    public class RelatorioGeradoViewModel
    {
        public MaterialViewModel Material { get; set; }
        public List<EstoqueRelatorioViewModel> Valores {  get; set; }
    }
}
