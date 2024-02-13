using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using POC.Negocio.Interfaces;
using POC.Negocio.Services;
using POC.Negocio.ViewModels;
using POC.Negocio.ViewModels.ErrorsValidator;

namespace POC.Web.Controllers
{
    
    public class MaterialController : Controller
    {
        private readonly IMaterialServices _materialServices;
        private readonly IValidator<MaterialViewModel> _validator;

        public MaterialController(IMaterialServices materialServices, IValidator<MaterialViewModel> validator)
        {
            _materialServices = materialServices;
            _validator = validator;
        }

        [Route("Material")]
        public async Task<IActionResult> Index()
        {
            ViewData["Material"] = await _materialServices.Listar();
            return View(new MaterialViewModel());
        }

        [Route("Material/Inserir")]
        [HttpPost]
        public async Task<IActionResult> Inserir(MaterialViewModel model)
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
                    await _materialServices.Editar(model);
                }
                else
                {
                    await _materialServices.Salvar(model);
                }



                ViewData["Material"] = await _materialServices.Listar();

                return Ok(new Response<MaterialViewModel>
                {
                    Message = model.Id != 0 ? "Editado com sucesso" : "Inserido com sucesso",
                    Sucesso = true
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new Response<MaterialViewModel>
                {
                    Message = ex.Message,
                    Sucesso = false
                });
            }

        }

        [Route("/Material/Buscar")]
        [Route("/Material/Buscar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Buscar(int id)
        {

            var dados = await _materialServices.BuscarId(id);
            ViewData["Material"] = await _materialServices.Listar();

            return View("Index", dados);
        }

        [Route("/Material/Deletar")]
        [Route("/Material/Deletar/{id}")]
        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _materialServices.Deletar(id);
                ViewData["Material"] = await _materialServices.Listar();

                return Ok(new Response<MaterialViewModel>
                {
                    Message = "Excluido com sucesso",
                    Sucesso = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<MaterialViewModel>
                {
                    Message = ex.Message,
                    Sucesso = false
                });
            }

        }
    }
}
