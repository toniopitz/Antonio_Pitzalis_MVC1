using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsercitazioneFinale.Cracco.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UsareName { get; set; }
        public string Password { get; set; }
        public Role Ruolo { get; set; }

        public enum Role
        {
            Administratore=0,
            User=1,
        }
    }
}
