using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Cadastrais.Core.Models
{
    public class RegiaoIntermediaria
    {
        #region Atributos

        public int id { get; set; }
        public string nome { get; set; }
        public UF UF { get; set; }

        #endregion
    }
}
