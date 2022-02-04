using EsercitazioneFinale.Cracco.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Cracco.Core.Interfaces
{
    public interface IRepositoryPiatti : IRepository<Piatto>
    {
        public Esito AssiociaPiatto(int id);
    }
}
