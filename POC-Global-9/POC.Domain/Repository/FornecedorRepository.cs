using Dapper;
using POC.Dados.Context;
using POC.Dados.Models;
using POC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POC.Domain.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly IDataContext _context;
        public FornecedorRepository(IDataContext context) { _context = context; }

        public async Task<Fornecedor> BuscarId(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);

                string sql = $"SP_Fornecedor_BuscarId";

                return await _context.ExecuteQuery<Fornecedor>(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao buscar fornecedor");
            }
        }

        public async Task Deletar(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);

                string sql = $"SP_Fornecedor_Deletar";

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao deletar fornecedor");
            }
        }

        public async Task Editar(Fornecedor model)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", model.Id);
                param.Add("@CNPJ", model.CNPJ);
                param.Add("@RazaoSocial", model.RazaoSocial);

                string sql = $"SP_Fornecedor_Editar";

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao editar fornecedor");
            }
        }

        public async Task<IEnumerable<Fornecedor>> Listar()
        {
            try
            {
                string sql = $"SP_Fornecedor_Listar";
                return await _context.ExecuteList<Fornecedor>(sql, null);
            }
            catch
            {
                throw new Exception("Erro ao listar fornecedor");
            }
        }

        public async Task Salvar(Fornecedor model)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@CNPJ", model.CNPJ);
                param.Add("@RazaoSocial", model.RazaoSocial);

                string sql = $"SP_Fornecedor_Inserir";             

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao inserir fornecedor");
            }
        }
    }
}
