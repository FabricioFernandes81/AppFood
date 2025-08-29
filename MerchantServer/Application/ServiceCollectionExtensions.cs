
using Application.Middlewares;
using Application.Validations;
using Domain.IRepositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;

            /* services.AddScoped<ICommandHandler<CreateCategoryCommand>, CreateCategoryCommandHandler>();
             services.AddScoped<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
             services.AddScoped<ICommandHandler<CreateImageCommand>, CreateImageCommandHandler>();
             services.AddScoped<ICommandHandler<CreateItemsCommand>, CreateItemsCommandHandler>();
             services.AddScoped<ICommandHandler<UpdateCategoryCommand>, UpdateCategoryCommandHandler>();
             services.AddScoped<ICommandHandler<UpdateItemsCommand>, UpdateItemsCommandHandler>();
 */
            services.AddScoped<IComercioRepositorio, ComercioRepositorio>();
            services.AddScoped<ICozinhaRepositorio, CozinhaRepositorio>();
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();

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



           /* services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
*/



         //   services.AddScoped(typeof(IDispatcherQueryMiddleware<,>), typeof(QueryValidationMiddleware<,>));
            services.AddScoped(typeof(IDispatcherQueryMiddleware<,>), typeof(QueryLoggingMiddleware<,>));


            return services;
        }
    }
}
