using POC.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Domain.Interfaces
{
    public interface IEstoqueRepository
    {
        Task Salvar(Estoque model);
        Task Editar(Estoque model);
        Task Deletar(int id);
        Task<IEnumerable<Estoque>> Listar();
        Task<Estoque> BuscarId(int id);
        Task<List<Estoque>> BuscarMaterial(int id);
        Task<List<Estoque>> BuscarMaterialCodigo(string codigo, string tipoOperacao);

    }
}
