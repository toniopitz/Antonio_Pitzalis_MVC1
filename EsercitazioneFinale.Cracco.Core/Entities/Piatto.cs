using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Cracco.Core.Entities
{
    public class Piatto
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string? Descrizione { get; set; }
        public double Prezzo { get; set; }
        public Tipologia Tipo { get; set; }
        public int? MenuId { get; set; }

        public Menu? Menu { get; set; }
        public enum Tipologia
        {
            Primo=1,
            Secondo=2,
            Contorno=3,
            Dolce=4
        }
    }
}
