using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Cadastrais.Core.Models
{
    public class RegiaoImediata
    {
        #region Atributos

        public int id { get; set; }
        public string nome { get; set; }

        [JsonProperty("regiao-intermediaria")]
        public RegiaoIntermediaria RegiaoIntermediaria { get; set; }

        #endregion
    }
}
