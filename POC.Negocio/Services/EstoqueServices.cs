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
    public class EstoqueServices : IEstoqueServices
    {
        private readonly IEstoqueRepository _estoqueRepository;
        public EstoqueServices(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }
        public async Task<EstoqueViewModel> BuscarId(int id)
        {
            var dados = await _estoqueRepository.BuscarId(id);
            var estoque = new EstoqueViewModel()
            {
                Id = dados.Id,
                Data = dados.Data.ToString("yyyy-MM-dd"),
                FornecedorId = dados.FornecedorId,
                MaterialId = dados.MaterialId,
                Quantidade = dados.Quantidade.ToString(),
                Valor = dados.Valor.ToString(),
                TipoOperacao = (TipoOperacao)Enum.Parse(typeof(TipoOperacao), dados.TipoOperacao)
            };
            return estoque;
        }

        public Task Deletar(int id) => _estoqueRepository.Deletar(id);

        public async Task Editar(EstoqueViewModel model)
        {
            var estoque = new Estoque(model.Id, model.Data, model.FornecedorId, model.MaterialId, model.Quantidade, model.Valor, model.TipoOperacao.ToString());
            await _estoqueRepository.Editar(estoque);
        }

        public async Task<IEnumerable<EstoqueViewModel>> Listar()
        {
            var dados = await _estoqueRepository.Listar();
            return dados.Select(x => new EstoqueViewModel()
            {
                Id = x.Id,
                Data = x.Data.ToShortDateString(),
                ForncedorCNPJ = x.ForncedorCNPJ,
                NomeMaterial = x.NomeMaterial,
                Quantidade = x.Quantidade.ToString(),
                Valor = x.Valor.ToString(),
                TipoOperacao = (TipoOperacao)Enum.Parse(typeof(TipoOperacao), x.TipoOperacao)
            });
        }

        public async Task Salvar(EstoqueViewModel model)
        {
            var estoque = new Estoque(model.Id, model.Data, model.FornecedorId, model.MaterialId, model.Quantidade, model.Valor, model.TipoOperacao.ToString());
            await _estoqueRepository.Salvar(estoque);
        }
    }
}
