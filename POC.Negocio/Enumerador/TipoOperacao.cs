using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Enumerador
{
    public enum TipoOperacao
    {
        [Display(Name = "Entrada")]
        Entrada = 1,
        [Display(Name = "Saida")]
        Saida = 2,
    }
}
