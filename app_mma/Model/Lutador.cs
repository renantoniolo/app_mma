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

        [JsonProperty("ArtesMarciais")]
        public List<string> ArtesMarciais { get; set; }

        public int Lutas { get; set; }

        public int Derrotas { get; set; }

        public int Vitorias { get; set; }

        [JsonIgnore]
        public int Pontucao { get; set; } = 0;

    }
        
}
