using FluentValidation;
using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Validators
{
    public class ValidatorFornecedor : AbstractValidator<FornecedorViewModel>
    {
        public ValidatorFornecedor()
        {
            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage("CNPJ deve ser informado.")
                .MaximumLength(18).WithMessage("O CNPJ deve ter no maximo 18 caracteres");
            RuleFor(x => x.RazaoSocial)
                .NotEmpty().WithMessage("Razão Social deve ser informado.");
        }
    }
}
