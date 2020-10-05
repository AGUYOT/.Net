using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAllocine.Model
{
    public class Favori
    {
        public int CompteId { get; set; }

        public int FilmId { get; set; }

        public virtual Film FilmFavori { get; set; }

        public virtual Compte CompteFavori { get; set; }
    }
}
