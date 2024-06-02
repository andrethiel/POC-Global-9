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
            services.AddScoped<Domain.Interfaces.IMaterialServices, MaterialRepository>();
            services.AddScoped<Negocio.Interfaces.IMaterialServices, MaterialServices>();
            services.AddScoped<IEstoqueServices, EstoqueServices>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IRelatorioServices, RelatorioServices>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();

            services.AddTransient<IValidator<FornecedorViewModel>, ValidatorFornecedor>();
            services.AddTransient<IValidator<MaterialViewModel>, ValidatorMaterial>();
            services.AddTransient<IValidator<EstoqueViewModel>, ValidatorEstoque>();
        }
    }
}
