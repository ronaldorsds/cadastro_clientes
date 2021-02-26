using Dados.Cadastrais.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Cadastrais.Application.Interfaces
{
    public interface IClienteService
    {
        #region Métodos

        Task<Cliente> ConsultarCliente(string Cpf);

        Task<Ceps> ConsultarCep(string Cep);

        Task<List<Estados>> ConsultarEstados(string Estado);

        Task<Estados> ConsultarEstado(string Estado);

        Task<List<Municipios>> ConsultarMunicipios(string Estado);

        Task<bool> AlterarEndereco(ClienteEndereco ClienteEndereco);

        #endregion
    }
}
