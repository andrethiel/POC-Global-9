using FluentValidation.Validators;
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
    public class RelatorioServices : IRelatorioServices
    {
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly Interfaces.IMaterialServices _materialServices;
        private readonly IEstoqueRepository _esteoqueRepository;
        public RelatorioServices(IRelatorioRepository relatorioRepository, Interfaces.IMaterialServices materialRepository, IEstoqueRepository esteoqueRepository)
        {
            _relatorioRepository = relatorioRepository;
            _materialServices = materialRepository;
            _esteoqueRepository = esteoqueRepository;
        }

        public async Task<List<RelatorioGeradoViewModel>> Relatorio(RelatorioViewModel model)
        {
            var relatorio = new Relatorio(model.DataDe, model.DataAte, model.FornecedorId, model.MaterialId, model.TipoOperacao.ToString());
            var dados = await _relatorioRepository.Gerar(relatorio);

            var lista = new List<RelatorioGeradoViewModel>();
            var listaValores = new List<EstoqueRelatorioViewModel>();
            //var material = await _materialServices.Listar();

            foreach (var item in dados)
            {
                var relatorioView = new RelatorioGeradoViewModel();
                //var estoque = await _esteoqueRepository.BuscarMaterialCodigo(item.CodigoMaterial, item.TipoOperacao);
                //if (estoque.Count > 0)
                //{

                //}
                var valores = new EstoqueRelatorioViewModel()
                {
                    Data = item.Data.ToShortDateString(),
                    Quantidade = item.Quantidade.ToString("F"),
                    Valor = item.Valor.ToString("F"),
                    TipoOperacao = item.TipoOperacao,
                };
                //var valores = estoque.Select(x => ).OrderBy(x => x.TipoOperacao).ToList();

                listaValores.Add(valores);

                var materialView = await _materialServices.BuscarId(item.MaterialId);

                relatorioView.Material = materialView;

                relatorioView.Valores = listaValores;

                lista.Add(relatorioView);
            }
            return lista;
        }
    }
}
