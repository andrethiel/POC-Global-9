using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Interfaces
{
    public interface IEstoqueServices
    {
        Task Salvar(EstoqueViewModel model);
        Task Editar(EstoqueViewModel model);
        Task Deletar(int id);
        Task<IEnumerable<EstoqueViewModel>> Listar();
        Task<EstoqueViewModel> BuscarId(int id);

        Task<IEnumerable<EstoqueViewModel>> ListarRelatorio();
    }
}
