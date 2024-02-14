using POC.Negocio.Enumerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.ViewModels
{
    public class EstoqueViewModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int FornecedorId { get; set; }
        public int MaterialId { get; set; }
        public string Quantidade { get; set; }
        public string Valor { get; set; }
        public TipoOperacao TipoOperacao { get; set; }

        public string ForncedorCNPJ { get; set; }
        public string NomeMaterial { get; set; }
        public string CodigoMaterial { get; set; }
    }
}
