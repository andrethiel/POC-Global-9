using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.ViewModels
{
    public class FornecedorViewModel
    {
        public int Id { get; set; }

        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
    }
}
