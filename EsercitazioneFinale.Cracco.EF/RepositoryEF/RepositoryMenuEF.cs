using EsercitazioneFinale.Cracco.Core.Entities;
using EsercitazioneFinale.Cracco.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Cracco.EF.RepositoryEF
{
    public class RepositoryMenuEF : IRepositoryMenu
    {
        private readonly MasterContext ctx;
        public RepositoryMenuEF(MasterContext ctx)
        {
            this.ctx = ctx;
        }
        public Menu Add(Menu item)
        {
            ctx.Menu.Add(item);
            ctx.SaveChanges();
            return item;
        }

        public bool Delete(Menu item)
        {
            ctx.Menu.Remove(item);
            ctx.SaveChanges();
            return true;
        }

        public List<Menu> GetAll()
        {
            return ctx.Menu.ToList();
        }

        public Menu? GetById(int id)
        {
            return ctx.Menu.Include(m=>m.Piatti).FirstOrDefault(m=>m.Id == id);
        }

        public Menu Update(Menu item)
        {
            ctx.Menu.Update(item);
            ctx.SaveChanges();
            return item;
        }
    }
}
