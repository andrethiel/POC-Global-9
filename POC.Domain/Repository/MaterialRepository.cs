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
    public class MaterialRepository : IMaterialServices
    {
        private readonly IDataContext _context;
        public MaterialRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<Material> BuscarId(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);

                string sql = $"SP_Material_BuscarId";

                return await _context.ExecuteQuery<Material>(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao buscar material");
            }
        }

        public async Task Deletar(int id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", id);

                string sql = $"SP_Material_Deletar";

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao deletar material");
            }
        }

        public async Task Editar(Material model)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", model.Id);
                param.Add("@Codigo", model.Codigo);
                param.Add("@NomeMaterial", model.NomeMaterial);
                param.Add("@UnidadeMedida", model.UnidadeMedida);

                string sql = $"SP_Material_Editar";

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao editar fornecedor");
            }
        }

        public async Task<IEnumerable<Material>> Listar()
        {
            try
            {
                string sql = $"SP_Material_Listar";
                return await _context.ExecuteList<Material>(sql, null);
            }
            catch
            {
                throw new Exception("Erro ao listar fornecedor");
            }
        }

        public async Task Salvar(Material model)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Codigo", model.Codigo);
                param.Add("@NomeMaterial", model.NomeMaterial);
                param.Add("@UnidadeMedida", model.UnidadeMedida);

                string sql = $"SP_Material_Inserir";

                await _context.ExecuteSave(sql, param);
            }
            catch
            {
                throw new Exception("Erro ao inserir fornecedor");
            }
        }
    }
}
