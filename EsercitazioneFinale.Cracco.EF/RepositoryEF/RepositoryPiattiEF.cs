using EsercitazioneFinale.Cracco.Core.Entities;
using EsercitazioneFinale.Cracco.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Cracco.EF.RepositoryEF
{
    public class RepositoryPiattiEF : IRepositoryPiatti
    {
        private readonly MasterContext ctx;
        public RepositoryPiattiEF (MasterContext ctx)
        {
            this.ctx = ctx;
        }
        public Piatto Add(Piatto item)
        {
            ctx.Piatti.Add(item);
            ctx.SaveChanges();
            return item;
        }

        public bool Delete(Piatto item)
        {
            ctx.Piatti.Remove(item);
            ctx.SaveChanges ();
            return true;
        }

        public List<Piatto> GetAll()
        {
            return ctx.Piatti.ToList();
        }

        public Piatto? GetById(int id)
        {
            return ctx.Piatti.FirstOrDefault(p => p.Id == id);
        }

        public Piatto Update(Piatto item)
        {
            ctx.Piatti.Update(item);
            ctx.SaveChanges();
            return item;
        }
        public Esito AssiociaPiatto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
