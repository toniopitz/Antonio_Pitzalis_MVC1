using EsercitazioneFinale.Cracco.Core.Entities;
using System.ComponentModel.DataAnnotations;
using static EsercitazioneFinale.Cracco.Core.Entities.Piatto;

namespace EsercitazioneFinale.Cracco.MVC.Models
{
    public class PiattoViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string? Descrizione { get; set; }
        [Required]
        public double Prezzo { get; set; }
        [Required]
        public Tipologia Tipo { get; set; }
        public int? MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}
