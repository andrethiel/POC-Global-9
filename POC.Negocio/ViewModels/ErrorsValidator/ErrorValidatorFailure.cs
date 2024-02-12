using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC.Negocio.ViewModels.ErrorsValidator
{
    public static class ErrorValidatorFailure
    {
        public static IList<ErrorValidator> ConversaoValidator(this IList<ValidationFailure> failures)
        {
            return failures.Select(x => new ErrorValidator(x.PropertyName, x.ErrorMessage)).ToList();
        }
    }
}
