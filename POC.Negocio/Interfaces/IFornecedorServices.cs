using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Interfaces
{
    public interface IFornecedorServices
    {
        Task Salvar(FornecedorViewModel model);
        Task Editar(FornecedorViewModel model);
        Task Deletar(int id);
        Task<IEnumerable<FornecedorViewModel>> Listar();
        Task<FornecedorViewModel> BuscarId(int id);
    }
}
