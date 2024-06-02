using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POC.Negocio.Interfaces;
using POC.Negocio.Services;
using POC.Negocio.ViewModels;
using System.Reflection;

namespace POC.Web.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IMaterialServices _materialServices;
        private readonly IFornecedorServices _fornecedorServices;
        private readonly IEstoqueServices _estoqueServices;
        private readonly IRelatorioServices _relatorioServices;
        public RelatorioController(IMaterialServices materialServices, IFornecedorServices fornecedorServices, IEstoqueServices estoqueServices, IRelatorioServices relatorioServices)
        {
            _materialServices = materialServices;
            _fornecedorServices = fornecedorServices;
            _estoqueServices = estoqueServices;
            _relatorioServices = relatorioServices;
        }

        [Route("Relatorio")]
        public IActionResult Index()
        {
            ListarFornecedorMaterial();

            return View(new RelatorioViewModel());
        }

        [Route("Relatorio/Gerar")]
        public async Task<IActionResult> Gerar(RelatorioViewModel model)
        {
            try
            {
                var estoque = await _relatorioServices.Relatorio(model);
                return Ok(new Response<List<RelatorioGeradoViewModel>>
                {
                    Dados = estoque,
                    Sucesso = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<RelatorioGeradoViewModel>
                {
                    Message = ex.Message,
                    Sucesso = false
                });
            }
        }

        private async void ListarFornecedorMaterial()
        {
            var fornecedor = await _fornecedorServices.Listar();
            var material = await _materialServices.Listar();
            ViewBag.Forncedor = fornecedor.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.RazaoSocial
            });
            ViewBag.Material = material.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.NomeMaterial
            });
        }
    }
}
