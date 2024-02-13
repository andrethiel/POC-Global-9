using POC.Negocio.Enumerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.ViewModels
{
    public class MaterialViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NomeMaterial { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
