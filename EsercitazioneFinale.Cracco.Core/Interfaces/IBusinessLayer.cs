using EsercitazioneFinale.Cracco.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Cracco.Core.Interfaces
{
    public interface IBusinessLayer
    {
        #region MetodiPiatti
        public List<Piatto> GetAllPiatti();
        public Esito AddPiatto(Piatto piatto);
        public Esito UpdatePiatto(Piatto piatto);
        public Esito DeletePiatto(int id);
        public Piatto GetPiattoById(int id);
        public Esito AssociaPiatto(int id);

        #endregion

        #region MetodiMenu

        public List<Menu> GetAllMenu();
        public Esito AddMenu(Menu menu);
        public Menu GetMenuById(int id);
        
        #endregion
    }
}
