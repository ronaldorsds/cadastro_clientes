using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Cadastrais.Core.Models
{
    public class Estados
    {
        #region Atributos

        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public Regiao regiao { get; set; }

        #endregion
    }
}
