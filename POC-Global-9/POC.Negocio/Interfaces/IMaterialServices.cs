using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Interfaces
{
    public interface IMaterialServices
    {
        Task Salvar(MaterialViewModel model);
        Task Editar(MaterialViewModel model);
        Task Deletar(int id);
        Task<IEnumerable<MaterialViewModel>> Listar();
        Task<MaterialViewModel> BuscarId(int id);
    }
}
