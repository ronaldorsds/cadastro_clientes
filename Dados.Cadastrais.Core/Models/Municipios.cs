using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Cadastrais.Core.Models
{
    public class Municipios
    {
        #region Atributos

        public int id { get; set; }
        public string nome { get; set; }
        public Microrregiao microrregiao { get; set; }

        [JsonProperty("regiao-imediata")]
        public RegiaoImediata RegiaoImediata { get; set; }

        #endregion
    }
}
