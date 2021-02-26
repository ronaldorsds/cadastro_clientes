using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Cadastrais.Core.Models
{
    public class Microrregiao
    {
        #region Atributos

        public int id { get; set; }
        public string nome { get; set; }
        public Mesorregiao mesorregiao { get; set; }

        #endregion
    }
}
