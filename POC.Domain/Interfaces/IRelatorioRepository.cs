using POC.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Domain.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<List<Relatorio>> Gerar(Relatorio model);
    }
}
