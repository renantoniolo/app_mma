using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace app_mma.Model
{
    public class Lutador
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        [JsonProperty("ArtesMarcais")]
        public List<ArtesMarcais> Artes_Marcais { get; set; }

        public int Lutas { get; set; }

        public int Derrotas { get; set; }

        public int Vitorias { get; set; }

    }

    public class ArtesMarcais {

        public string Nome { get; set; }

    }
        
}
