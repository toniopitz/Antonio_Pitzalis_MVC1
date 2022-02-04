﻿using EsercitazioneFinale.Cracco.Core.Entities;
using EsercitazioneFinale.Cracco.MVC.Models;

namespace EsercitazioneFinale.Cracco.MVC.Mapping
{
    public static class Mapping
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();
            foreach(var item in menu.Piatti)
            {
                piattiViewModel.Add(item?.ToPiattoViewModel());
            }
            return new MenuViewModel
            {
                Id = menu.Id,
                Nome = menu.Nome,
                Piatti = piattiViewModel
            };
        }
        public static Menu ToMenu (this MenuViewModel menuViewModel)
        {
            List<Piatto> piatti = new List<Piatto>();
            foreach(var item in menuViewModel.Piatti)
            {
                piatti.Add(item?.ToPiatto());
            }
            return new Menu
            {
                Id = menuViewModel.Id,
                Nome = menuViewModel.Nome,
                Piatti = piatti
            };
        }
        public static PiattoViewModel ToPiattoViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                Id = piatto.Id,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Prezzo = piatto.Prezzo,
                Tipo = piatto.Tipo,
                MenuId = piatto.MenuId
            };
        }
        public static Piatto ToPiatto(this PiattoViewModel piattoViewModel)
        {
            return new Piatto
            {
                Id = piattoViewModel.Id,
                Nome = piattoViewModel.Nome,
                Descrizione = piattoViewModel.Descrizione,
                Prezzo = piattoViewModel.Prezzo,
                Tipo = piattoViewModel.Tipo,
                MenuId = piattoViewModel.MenuId
            };
        }
    }
}
