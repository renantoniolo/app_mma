using System;
using System.Collections.Generic;

namespace app_mma.Model
{
    public class Lutador
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        public List<string> Artes_Marcais { get; set; }

        public int Lutas { get; set; }

        public int Derrotas { get; set; }

        public int Vitorias { get; set; }

    }
}
