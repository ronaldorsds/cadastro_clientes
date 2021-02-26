using Dados.Cadastrais.Application.Interfaces;
using Dados.Cadastrais.Application.Services;
using Dados.Cadastrais.Data.Interfaces;
using Dados.Cadastrais.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dados.Cadastrais.Test
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddSingleton<IConfiguration>(AddConfigurationBuilder());

            return services;
        }

        public static IConfiguration AddConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();

            return builder;
        }
    }
}
