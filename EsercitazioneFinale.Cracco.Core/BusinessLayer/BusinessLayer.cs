using EsercitazioneFinale.Cracco.Core.Entities;
using EsercitazioneFinale.Cracco.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Cracco.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryMenu menuRepo;
        private readonly IRepositoryPiatti piattiRepo;

        public BusinessLayer(IRepositoryMenu menu, IRepositoryPiatti piatti)
        {
            menuRepo = menu;
            piattiRepo = piatti;
        }

        #region MetodiPiatti

        public Esito AddPiatto(Piatto piatto)
        {
            
            Piatto existing = piattiRepo.GetById(piatto.Id);
            if(existing is null)
            {
                piattiRepo.Add(piatto);
                return new Esito { Mex = "Inserimento effettuato con successo", IsOK = true };
            }
            return new Esito { Mex="Qualcosa è andato storto", IsOK=false };
        }

        public Esito DeletePiatto(int id)
        {
            Piatto existing = piattiRepo.GetById(id);
            if(existing is not null)
            {
                piattiRepo.Delete(existing);
                return new Esito { Mex = "Eliminazione effettuata con successo", IsOK = true };
            }
            return new Esito { Mex ="Qualcosa è andato storto", IsOK=false};
        }

        public List<Piatto> GetAllPiatti()
        {
            return piattiRepo.GetAll();
        }


        public Piatto GetPiattoById(int id)
        {
            return piattiRepo.GetById(id);
        }

        public Esito UpdatePiatto(Piatto piatto)
        {
            Piatto existing = piattiRepo.GetById(piatto.Id);
            if (existing is not null)
            {
                existing.Nome = piatto.Nome;
                existing.Descrizione = piatto.Descrizione;
                existing.Tipo = piatto.Tipo;
                existing.Prezzo = piatto.Prezzo;
                piattiRepo.Update(existing);
                return new Esito { Mex = "Aggiornamento effettuata con successo", IsOK = true };
            }
            return new Esito { Mex = "Qualcosa è andato storto", IsOK = false };
        }
        public Esito AssociaPiatto(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region MetodiMenu
        public Esito AddMenu(Menu menu)
        {
            Menu existing = menuRepo.GetAll().FirstOrDefault(m=>m.Id==menu.Id);
            if(existing is null)
            {
                menuRepo.Add(menu);
                return new Esito { Mex="Inserimento eseguito con successo", IsOK=true };
            }
            return new Esito { Mex="Qualcosa è andato storto",IsOK=false };
        }
        public List<Menu> GetAllMenu()
        {
            return menuRepo.GetAll();
        }
        public Menu GetMenuById(int id)
        {
            return menuRepo.GetById(id);
        }

        #endregion

    }
}
