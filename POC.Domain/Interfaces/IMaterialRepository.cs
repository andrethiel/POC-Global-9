using POC.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Domain.Interfaces
{
    public interface IMaterialRepository
    {
        Task Salvar(Material model);
        Task Editar(Material model);
        Task Deletar(int id);
        Task<IEnumerable<Material>> Listar();
        Task<Material> BuscarId(int id);
    }
}
