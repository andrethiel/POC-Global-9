using POC.Dados.Models;
using POC.Domain.Interfaces;
using POC.Negocio.Enumerador;
using POC.Negocio.Interfaces;
using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Services
{
    public class MaterialServices : Interfaces.IMaterialServices
    {
        private readonly Domain.Interfaces.IMaterialServices _materialRepository;
        public MaterialServices(Domain.Interfaces.IMaterialServices materialRepository)
        {
            _materialRepository = materialRepository;
        }
        public async Task<MaterialViewModel> BuscarId(int id)
        {
            var dados = await _materialRepository.BuscarId(id);
            var material = new MaterialViewModel()
            {
                Id = dados.Id,
                Codigo = dados.Codigo,
                NomeMaterial = dados.NomeMaterial,
                UnidadeMedida = (UnidadeMedida)Enum.Parse(typeof(UnidadeMedida), dados.UnidadeMedida)
        };
            return material;
        }

        public Task Deletar(int id) => _materialRepository.Deletar(id);

        public async Task Editar(MaterialViewModel model)
        {
            var material = new Material(model.Id, model.Codigo, model.NomeMaterial, model.UnidadeMedida.ToString());
            await _materialRepository.Editar(material);
        }

        public async Task<IEnumerable<MaterialViewModel>> Listar()
        {
            var dados = await _materialRepository.Listar();
            return dados.Select(x => new MaterialViewModel()
            {
                Id = x.Id,
                Codigo = x.Codigo,
                NomeMaterial = x.NomeMaterial,
                UnidadeMedida = (UnidadeMedida)Enum.Parse(typeof(UnidadeMedida), x.UnidadeMedida)
            });
        }

        public async Task Salvar(MaterialViewModel model)
        {
            var material = new Material(model.Id, model.Codigo, model.NomeMaterial, model.UnidadeMedida.ToString());
            await _materialRepository.Salvar(material);
        }
    }
}
