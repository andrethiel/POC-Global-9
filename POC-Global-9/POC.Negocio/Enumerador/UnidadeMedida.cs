using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Enumerador
{
    public enum UnidadeMedida
    {
        [Display(Name = "Kilo")]
        Kilo = 1,
        [Display(Name = "Saca")]
        Saca = 2,
        [Display(Name = "Peça")]
        Peça = 3
    }
}
