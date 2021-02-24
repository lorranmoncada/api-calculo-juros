using CalcularJuros.Api.Application.ServiceApp;
using CalcularJuros.Api.Domain.InterfaceService;
using CalcularJuros.Api.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcularJuros.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Application
            services.AddScoped<ICalculoJurosApp, CalculoJurosApp>();

            // Service
            services.AddScoped<ICalcularJurosService, CalcularJurosService>();
            services.AddScoped<IGitService, GitService>();
        }
    }
}
