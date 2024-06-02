using POC.Dados.Models;
using POC.Domain.Interfaces;
using POC.Negocio.Interfaces;
using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Services
{
    public class FornecedorServices : IFornecedorServices
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        public FornecedorServices(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<FornecedorViewModel> BuscarId(int id)
        {
            var dados = await _fornecedorRepository.BuscarId(id);
            if(dados == null)
            {
                return new FornecedorViewModel();
            }
            else
            {
                var fornecedor = new FornecedorViewModel()
                {
                    Id = id,
                    CNPJ = dados.CNPJ,
                    RazaoSocial = dados.RazaoSocial,
                };
                return fornecedor;
            }
        }            

        public Task Deletar(int id) => _fornecedorRepository.Deletar(id);

        public async Task<IEnumerable<FornecedorViewModel>> Listar()
        {
            var dados = await _fornecedorRepository.Listar();
            return dados.Select(x => new FornecedorViewModel()
            {
                Id = x.Id,
                CNPJ = x.CNPJ,
                RazaoSocial = x.RazaoSocial,
            });
        }

        public async Task Editar(FornecedorViewModel model)
        {
            var fornecedor = new Fornecedor(model.Id, model.CNPJ, model.RazaoSocial);
            await _fornecedorRepository.Editar(fornecedor);

        }

        public async Task Salvar(FornecedorViewModel model)
        {
            var fornecedor = new Fornecedor(model.Id, model.CNPJ, model.RazaoSocial);
            await _fornecedorRepository.Salvar(fornecedor);

        }
    }
}
