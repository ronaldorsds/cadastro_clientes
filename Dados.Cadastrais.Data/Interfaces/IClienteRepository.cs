using Dados.Cadastrais.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Cadastrais.Data.Interfaces
{
    public interface IClienteRepository
    {
        #region Métodos
        Task<Cliente> Obter(string Cpf);
        Task<bool> AlterarEndereco(ClienteEndereco clienteEndereco);

        #endregion
    }
}
