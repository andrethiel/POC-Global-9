using FluentValidation;
using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Validators
{
    public class ValidatorMaterial : AbstractValidator<MaterialViewModel>
    {
        public ValidatorMaterial()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O Código do material deve ser informado")
                .MaximumLength(10).WithMessage("O Código deve ter no maximo 10 caracteres");

            RuleFor(x => x.NomeMaterial).NotEmpty().WithMessage("O Nome do material deve ser informado");

            RuleFor(x => x.UnidadeMedida).NotEmpty().WithMessage("Selecione a unidade de medida");
        }
    }
}
