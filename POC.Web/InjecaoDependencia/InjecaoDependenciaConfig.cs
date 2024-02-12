using FluentValidation;
using POC.Dados.Context;
using POC.Domain.Interfaces;
using POC.Domain.Repository;
using POC.Negocio.Interfaces;
using POC.Negocio.Services;
using POC.Negocio.Validators;
using POC.Negocio.ViewModels;


namespace POC.Web.InjecaoDependencia
{
    public static class InjecaoDependenciaConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IFornecedorServices, FornecedorServices>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            services.AddTransient<IValidator<FornecedorViewModel>, ValidatorFornecedor>();
        }
    }
}
