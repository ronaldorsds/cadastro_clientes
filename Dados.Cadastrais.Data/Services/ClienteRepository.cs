using Dados.Cadastrais.Core.Models;
using Dados.Cadastrais.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Dados.Cadastrais.Data.Services
{
    public class ClienteRepository : IClienteRepository
    {
        #region Atributos

        private string connectionString { get; set; }
        private IConfiguration _configuration { get; set; }

        #endregion

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration["ClienteConnection"];
        }


        #region Métodos

        public async Task<bool> AlterarEndereco(ClienteEndereco clienteEndereco)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE [dbo].[ClienteEndereco]
                            SET [Logradouro] = @Logradouro
                                ,[Numero] = @Numero
                                ,[Complemento] = @Complemento
                                ,[Bairro] = @Bairro
                                ,[Cidade] = @Cidade
                                ,[Estado] = @Estado
                                ,[Pais] = @Pais
                                ,[Cep] = @Cep
                            WHERE [IdCliente] = @IdCliente";

                var operacao = await connection.ExecuteAsync(query, clienteEndereco);

                if (operacao > 0)
                    result = true;
            }

            return result;
        }

        public async Task<Cliente> Obter(string Cpf)
        {
            Cliente clienteResult = null;

            if (!string.IsNullOrEmpty(Cpf))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryCliente = @" SELECT [Id], [CPF], [Nome] FROM [Clientes].[dbo].[Clientes] WHERE [CPF] = @Cpf";

                    string queryClienteEndereco = @" SELECT [Id], [IdCliente], [Logradouro], [Numero], [Complemento], [Bairro], [Cidade], [Estado], [Pais], [Cep] FROM [Clientes].[dbo].[ClienteEndereco] WHERE [IdCliente] = @IdCliente";

                    clienteResult = await connection.QueryFirstAsync<Cliente>(queryCliente, new { CPF = Cpf });

                    if (clienteResult != null)
                    {
                        var IdCliente = clienteResult.Id;

                        var clienteEndereco = await connection.QueryAsync<ClienteEndereco>(queryClienteEndereco, new { IdCliente = IdCliente });

                        clienteResult.ClienteEndereco = clienteEndereco.ToList();
                    }
                }
            }
            
            return clienteResult;
        }

        #endregion
    }
}
