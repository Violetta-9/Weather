using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Weather.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
         
        }
    }
}
