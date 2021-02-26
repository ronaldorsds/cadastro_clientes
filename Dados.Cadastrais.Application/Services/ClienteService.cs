using Dados.Cadastrais.Application.Interfaces;
using Dados.Cadastrais.Core.Models;
using Dados.Cadastrais.Data.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Dados.Cadastrais.Application.Services
{
    public class ClienteService : IClienteService
    {
        #region Atributos

        private IClienteRepository _clienteRepository { get; set; }
        private IConfiguration _configuration { get; set; }

        private string _apiLocalidades { get; set; }
        private string _apiCeps { get; set; }

        #endregion

        #region Construtores

        public ClienteService(IConfiguration configuration,
               IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _configuration = configuration;
            _apiCeps = _configuration["ApiCep"];
            _apiLocalidades = _configuration["ApiLocalidades"];
        }

        #endregion

        #region Métodos

        public Task<bool> AlterarEndereco(ClienteEndereco clienteEndereco)
        {
            return _clienteRepository.AlterarEndereco(clienteEndereco);
        }

        public async Task<Ceps> ConsultarCep(string Cep)
        {
            var ceps = new Ceps();
            string urlService = _apiCeps;

            var client = new RestClient(urlService + Cep + "/json");
            var request = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                Method = Method.GET
            };

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                ceps = JsonConvert.DeserializeObject<Ceps>(response.Content);
            }

            return ceps;
        }

        public Task<Cliente> ConsultarCliente(string Cpf)
        {
            return _clienteRepository.Obter(Cpf);
        }

        public async Task<List<Estados>> ConsultarEstados(string Estado)
        {
            List<Estados> estados = new List<Estados>();
            var client = new RestClient(_apiLocalidades);
            var request = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                Method = Method.GET
            };

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var estadosResult = JsonConvert.DeserializeObject<List<Estados>>(response.Content);
                if (!string.IsNullOrEmpty(Estado))
                {
                    estados = estadosResult.Where(a => a.nome.Contains(Estado)).ToList();
                }
                else
                {
                    var sp = estadosResult.Where(a => a.nome == "São Paulo").FirstOrDefault();
                    var rio = estadosResult.Where(a => a.nome == "Rio de Janeiro").FirstOrDefault();

                    estados.Add(sp);
                    estados.Add(rio);
                    
                    estadosResult.RemoveAll(a => a.nome == "São Paulo");
                    estadosResult.RemoveAll(a => a.nome == "Rio de Janeiro");

                    estadosResult.OrderBy(a => a.nome);

                    estados.AddRange(estadosResult);
                }
            }

            return estados;

        }

        public async Task<Estados> ConsultarEstado(string Estado)
        {
            var estado = new Estados();
            var client = new RestClient(_apiLocalidades);
            var request = new RestRequest()
            {
                RequestFormat = DataFormat.Json,
                Method = Method.GET
            };

            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var estadosResult = JsonConvert.DeserializeObject<List<Estados>>(response.Content);
                estado = estadosResult.Where(a => a.nome.Equals(Estado)).FirstOrDefault();
            }

            return estado;

        }

        public async Task<List<Municipios>> ConsultarMunicipios(string Estado)
        {
            List<Municipios> municipios = new List<Municipios>();
            string urlService = _apiLocalidades;
            var estado = ConsultarEstado(Estado).Result;

            if (estado != null)
            {
                var client = new RestClient(urlService + estado.id + "/municipios");
                var request = new RestRequest()
                {
                    RequestFormat = DataFormat.Json,
                    Method = Method.GET
                };

                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    municipios = JsonConvert.DeserializeObject<List<Municipios>>(response.Content);
                }
            }

            return municipios;
        }

        #endregion
    }
}
