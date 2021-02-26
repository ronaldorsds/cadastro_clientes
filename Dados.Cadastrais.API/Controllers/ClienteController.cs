using Dados.Cadastrais.Application.Interfaces;
using Dados.Cadastrais.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dados.Cadastrais.API.Controllers
{
    public class ClienteController : Controller
    {
        #region Atributos

        private IClienteService _clienteService { get; set; }

        #endregion

        #region Construtores

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        #endregion


        #region Métodos
        
        [Route("ConsultarCliente")]
        [HttpGet]
        public async Task<Cliente> ConsultarCliente([FromQuery] string Cpf)
        {
            return await _clienteService.ConsultarCliente(Cpf);
        }

        [HttpGet]
        [Route("ConsultarCep")]
        public async Task<Ceps> ConsultarCep([FromQuery] string Cep)
        {
            return await _clienteService.ConsultarCep(Cep);
        }

        [HttpGet]
        [Route("ConsultarEstados")]
        public async Task<List<Estados>> ConsultarEstados([FromQuery] string estado)
        {
            return await _clienteService.ConsultarEstados(estado);
        }

        [HttpGet]
        [Route("ConsultarMunicipios")]
        public async Task<List<Municipios>> ConsultarMunicipios([FromQuery] string estado)
        {
            return await _clienteService.ConsultarMunicipios(estado);
        }

        [HttpPost]
        [Route("AlterarEndereco")]
        public async Task<bool> AlterarEndereco([FromBody] ClienteEndereco clienteEndereco)
        {
            return await _clienteService.AlterarEndereco(clienteEndereco);
        }

        #endregion

    }
}
