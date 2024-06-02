using FluentValidation;
using POC.Negocio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.Validators
{
    public class ValidatorEstoque : AbstractValidator<EstoqueViewModel>
    {
        public ValidatorEstoque()
        {
            RuleFor(x => x.Data).NotEmpty().WithMessage("Selecione uma data");
            RuleFor(x => x.FornecedorId).NotEmpty().WithMessage("Selecione um fornecedor");
            RuleFor(x => x.MaterialId).NotEmpty().WithMessage("Selecione um material");
            RuleFor(x => x.Quantidade).NotEmpty().When(x => x.Valor == null).WithMessage("Informe o valor do material");
            RuleFor(x => x.TipoOperacao).NotEmpty().WithMessage("Selecione o tipo da operação");
        }
    }
}
