using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Cadastrais.Core.Models
{
    public class Cliente
    {
        #region Atributos

        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public List<ClienteEndereco> ClienteEndereco { get; set; }

        #endregion
    }
}
