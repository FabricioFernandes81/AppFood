using Application.Middlewares;
using Infrastructure.Repositories;
using Infrastructure.Repositories.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAplicatios(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.Scan(scan => scan
                 .FromAssemblies(assembly)
                 .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<>)))
                 .AsImplementedInterfaces()
                 .WithScopedLifetime());

            services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.AddScoped(typeof(IDispatcherQueryMiddleware<,>), typeof(QueryLoggingMiddleware<,>));


            return services;

        }
    }
}
