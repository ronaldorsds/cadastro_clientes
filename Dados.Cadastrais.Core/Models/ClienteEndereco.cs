using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Cadastrais.Core.Models
{
    public class ClienteEndereco
    {
        #region Atributos

        public int IdCliente { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }

        #endregion
    }
}
