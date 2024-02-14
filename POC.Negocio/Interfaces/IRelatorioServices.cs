using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Interfaces
{
    public interface IRelatorioServices
    {
        Task<List<RelatorioGeradoViewModel>> Relatorio(RelatorioViewModel model);
    }
}
