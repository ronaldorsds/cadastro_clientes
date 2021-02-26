using Dados.Cadastrais.API.Controllers;
using Dados.Cadastrais.Application.Interfaces;
using Dados.Cadastrais.Application.Services;
using Dados.Cadastrais.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Dados.Cadastrais.Test
{
    public class UnitTest
    {
        private IConfiguration _configuration { get; set; }
        private IClienteService _clienteService { get; set; }



        public UnitTest()
        {
            IServiceCollection services = Startup.ConfigureServices();
            var sp = services.BuildServiceProvider();
            _configuration = sp.GetService<IConfiguration>();
            _clienteService = sp.GetService<IClienteService>();
        }

        [Fact]
        public void ConsultarCliente()
        {
            string Cpf = "48302879002";

            var result = _clienteService.ConsultarCliente(Cpf).Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void ConsultarCep()
        {
            string Cep = "04055110";

            var result = _clienteService.ConsultarCep(Cep).Result;

            Assert.NotNull(result);
        }

        //Se não informar o estado todos os estados serão exibidos
        [Fact]
        public void ConsultarEstados()
        {
            string estado = "";

            var result = _clienteService.ConsultarEstados(estado).Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void ConsultarMunicipios()
        {
            string estado = "São Paulo";

            var result = _clienteService.ConsultarMunicipios(estado).Result;

            Assert.NotNull(result);
        }

        [Fact]
        public void AlterarEndereco()
        {
            var clienteEndereco = new ClienteEndereco()
            {
                IdCliente = 1,
                Logradouro = "Rua das Uvaias",
                Numero = "101",
                Complemento = "Apto 100",
                Bairro = "São Paulo",
                Cidade = "São Paulo",
                Estado = "SP",
                Pais = "Brasil",
                Cep = "04055110"
            };

            var result = _clienteService.AlterarEndereco(clienteEndereco).Result;

            Assert.True(result);
        }
    }
}
