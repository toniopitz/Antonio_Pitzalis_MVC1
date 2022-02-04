﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Cracco.Core.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Piatto> Piatti { get; set; } = new List<Piatto>();
    }
}
