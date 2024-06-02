using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using POC.Negocio.Interfaces;
using POC.Negocio.ViewModels;
using POC.Negocio.ViewModels.ErrorsValidator;
using System.Reflection;

namespace POC.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorServices _fornecedorService;
        private readonly IValidator<FornecedorViewModel> _validator;
        public FornecedorController(IFornecedorServices fornecedorService, IValidator<FornecedorViewModel> validator)
        {
            _fornecedorService = fornecedorService;
            _validator = validator;
        }
        [Route("Fornecedor")]
        public async Task<IActionResult> Index()
        {
            ViewData["Fornecedor"] = await _fornecedorService.Listar();

            return View(new FornecedorViewModel());
        }

        [Route("Fornecedor/Inserir")]
        [HttpPost]
        public async Task<IActionResult> Inserir(FornecedorViewModel model)
        {
            var validacao = _validator.Validate(model);
            try
            {
                if (!validacao.IsValid)
                {
                    return BadRequest(validacao.Errors.ConversaoValidator());
                }

                if (model.Id != 0)
                {
                    await _fornecedorService.Editar(model);
                }
                else
                {
                    await _fornecedorService.Salvar(model);
                }



                ViewData["Fornecedor"] = await _fornecedorService.Listar();

                return Ok(new Response<FornecedorViewModel>
                {
                    Message = model.Id != 0 ? "Editado com sucesso" : "Inserido com sucesso",
                    Sucesso = true
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Response<FornecedorViewModel>
                {
                    Message = ex.Message,
                    Sucesso = false
                });
            }

        }

        [Route("/Fornecedor/Buscar")]
        [Route("/Fornecedor/Buscar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Buscar(int id)
        {

            var dados = await _fornecedorService.BuscarId(id);
            ViewData["Fornecedor"] = await _fornecedorService.Listar();

            return View("Index", dados);
        }

        [Route("/Fornecedor/Deletar")]
        [Route("/Fornecedor/Deletar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _fornecedorService.Deletar(id);
                ViewData["Fornecedor"] = await _fornecedorService.Listar();

                return Ok(new Response<FornecedorViewModel>
                {
                    Message = "Excluido com sucesso",
                    Sucesso = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<FornecedorViewModel>
                {
                    Message = ex.Message,
                    Sucesso = false
                });
            }

        }
    }
}
