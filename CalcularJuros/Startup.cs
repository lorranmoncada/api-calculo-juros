using CalcularJuros.ServiceJuros;
using CalcularJuros.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CalcularJuros
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var taxaJurosBaseUrl = Configuration["TaxaJurosApi"].ToString();
            var git = Configuration["Git"].ToString();

      

            services
                 .AddRefitClient<IJurosService>()
                 .ConfigureHttpClient(c => c.BaseAddress = new Uri(taxaJurosBaseUrl));
            services
                 .AddRefitClient<IApiGitService>()
                 .ConfigureHttpClient(c => c.BaseAddress = new Uri(git));

            services.RegisterServices();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CalcularJuros",Description="Api que retorna o calculo de juros composto, e a URL do repositório que possui o código fonte", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/CalculoJurosComposto-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CalcularJuros v1"));

            ILogger logger = loggerFactory.CreateLogger<Startup>();
            // Camada de Exception nativa do Net Core
            app.UseExceptionHandler(
                   options =>
                   {
                       options.Run(
                           async context =>
                           {
                               context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                               context.Response.ContentType = "text/html";
                               var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                               if (null != exceptionObject)
                               {
                                   var errorMessage = $"<b>Exception Error: {exceptionObject.Error.Message} </b> {exceptionObject.Error.StackTrace}";
                                   logger.LogInformation($"<b>Exception Error: {exceptionObject.Error.Message} </b> {exceptionObject.Error.StackTrace}");
                                   await context.Response.WriteAsync(errorMessage).ConfigureAwait(false);
                               }
                           });
                   }
               );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
