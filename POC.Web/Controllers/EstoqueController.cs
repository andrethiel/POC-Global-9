using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POC.Negocio.Interfaces;
using POC.Negocio.ViewModels;
using POC.Negocio.ViewModels.ErrorsValidator;
using POC.Web.Helper;

namespace POC.Web.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IEstoqueServices _estoqueServices;
        private readonly IMaterialServices _materialServices;
        private readonly IFornecedorServices _fornecedorServices;
        private readonly IValidator<EstoqueViewModel> _validator;
        public EstoqueController(IEstoqueServices estoqueServices, IMaterialServices materialServices, IFornecedorServices fornecedorServices, IValidator<EstoqueViewModel> validator)
        {
            _estoqueServices = estoqueServices;
            _materialServices = materialServices;
            _fornecedorServices = fornecedorServices;
            _validator = validator;
        }

        [Route("Estoque")]
        public async Task<IActionResult> Index()
        {
            ViewData["Estoque"] = await _estoqueServices.Listar();
            ListarFornecedorMaterial();

            return View(new EstoqueViewModel());
        }

        [Route("Estoque/Inserir")]
        [HttpPost]
        public async Task<IActionResult> Inserir(EstoqueViewModel model)
        {
            var validacao = _validator.Validate(model);
            try
            {
                if (!validacao.IsValid)
                {
                    ListarFornecedorMaterial();
                    return BadRequest(validacao.Errors.ConversaoValidator());
                }

                if (model.Id != 0)
                {
                    await _estoqueServices.Editar(model);
                }
                else
                {
                    await _estoqueServices.Salvar(model);
                }



                ViewData["Estoque"] = await _estoqueServices.Listar();
                ListarFornecedorMaterial();

                return Ok(new Response<EstoqueViewModel>
                {
                    Message = model.Id != 0 ? "Editado com sucesso" : "Inserido com sucesso",
                    Sucesso = true
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Response<EstoqueViewModel>
                {
                    Message = ex.Message,
                    Sucesso = false
                });
            }

        }

        [Route("/Estoque/Buscar")]
        [Route("/Estoque/Buscar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Buscar(int id)
        {
            ListarFornecedorMaterial();
            var dados = await _estoqueServices.BuscarId(id);
            ViewData["Estoque"] = await _estoqueServices.Listar();
            

            return View("Index", dados);
        }

        [Route("/Estoque/Deletar")]
        [Route("/Estoque/Deletar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _estoqueServices.Deletar(id);
                ViewData["Estoque"] = await _estoqueServices.Listar();

                return Ok(new Response<EstoqueViewModel>
                {
                    Message = "Excluido com sucesso",
                    Sucesso = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<EstoqueViewModel>
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
