﻿using EsercitazioneFinale.Cracco.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace EsercitazioneFinale.Cracco.MVC.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public List<PiattoViewModel> Piatti { get; set; } = new List<PiattoViewModel>();
    }
}
