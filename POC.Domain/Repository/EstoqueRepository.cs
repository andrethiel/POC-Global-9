using Dapper;
using POC.Dados.Context;
using POC.Dados.Models;
using POC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POC.Domain.Repository
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly IDataContext _context;
        public EstoqueRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<Estoque> BuscarId(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);

                string sql = $"SP_Estoque_BuscarId";

                return await _context.ExecuteQuery<Estoque>(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao buscar Estoque");
            }
        }

        public async Task<List<Estoque>> BuscarMaterial(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@MaterialId", id);

                string sql = $"SP_Estoque_BuscarMaterial";

                return await _context.ExecuteList<Estoque>(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao buscar Estoque");
            }
        }

        public async Task Deletar(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);

                string sql = $"SP_Estoque_Deletar";

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao deletar Estoque");
            }
        }

        public async Task Editar(Estoque model)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", model.Id);
                param.Add("@Data", model.Data);
                param.Add("@FornecedorId", model.FornecedorId);
                param.Add("@MaterialId", model.MaterialId);
                param.Add("@Quantidade", model.Quantidade);
                param.Add("@Valor", model.Valor);
                param.Add("@TipoOperacao", model.TipoOperacao);

                string sql = $"SP_Estoque_Editar";

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao editar esquece");
            }
        }

        public async Task<IEnumerable<Estoque>> Listar()
        {
            try
            {
                string sql = $"SP_Estoque_Listar";
                return await _context.ExecuteList<Estoque>(sql, null);
            }
            catch
            {
                throw new Exception("Erro ao listar fornecedor");
            }
        }

        public async Task Salvar(Estoque model)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Data", model.Data);
                param.Add("@FornecedorId", model.FornecedorId);
                param.Add("@MaterialId", model.MaterialId);
                param.Add("@Quantidade", model.Quantidade);
                param.Add("@Valor", model.Valor);
                param.Add("@TipoOperacao", model.TipoOperacao);

                string sql = $"SP_Estoque_Inserir";

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao inserir estoque");
            }
        }

        public async Task<List<Estoque>> BuscarMaterialCodigo(string codigo, string tipoOperacao)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@CodigoMaterial", codigo);
                param.Add("@TipoOperacao", tipoOperacao);

                string sql = $"SP_Estoque_BuscarMaterialCodigo";
                return await _context.ExecuteList<Estoque>(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao listar fornecedor");
            }
        }
    }
}
