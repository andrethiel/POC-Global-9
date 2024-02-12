using POC.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task Salvar(Fornecedor model);
        Task Editar(Fornecedor model);
        Task Deletar(int id);
        Task<IEnumerable<Fornecedor>> Listar();
        Task<Fornecedor> BuscarId(int id);

    }
}
