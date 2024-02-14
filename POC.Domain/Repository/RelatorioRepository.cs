using Dapper;
using POC.Dados.Context;
using POC.Dados.Models;
using POC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Domain.Repository
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly IDataContext _context;
        public RelatorioRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task<List<Relatorio>> Gerar(Relatorio model)
        {
            try
            {

                string sql = $"SELECT E.MaterialId, E.data, e.Quantidade, e.Valor, e.TipoOperacao, M.Codigo as CodigoMaterial FROM estoque E, Fornecedor F, Material M WHERE E.FornecedorId = F.Id and E.MaterialId = M.Id ";

                if(model.DataDe.HasValue && model.DataAte.HasValue)
                {
                    sql += $"and E.Data BETWEEN '{model.DataDe.Value}' AND '{model.DataAte}'";
                }

                return await _context.ExecuteList<Relatorio>(sql);
            }
            catch
            {
                throw new Exception("Erro ao buscar material");
            }
        }
    }
}
