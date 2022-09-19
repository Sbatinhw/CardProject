using CardProject.Bl.Helpers.Implementations;
using CardProject.Bl.Helpers.Interfaces;
using CardProject.Bl.Services.Implementations.Card.Debit;
using CardProject.Bl.Services.Interfaces.Card.Debit;
using CardProject.Data.Repositories.Implementations;
using CardProject.Data.Repositories.Interfaces;

namespace CardProject.Api.Infrastructure.Extensions
{
    public static class ServiceCollectionExtions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IDebitCardService, DebitCardService>();
        }
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IReadOnlyRepository, ReadOnlyRepository>();
            services.AddSingleton<IRepository, Repository>();
        }
        public static void ConfigureHelpers(this IServiceCollection services)
        {
            services.AddSingleton<IFilterHelper, FilterHelper>();
        }
    }
}
