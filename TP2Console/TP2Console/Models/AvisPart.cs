using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Console.Models.EntityFramework
{
    public partial class Avis
    {
        public override string ToString()
        {
            return "Utilisateur: "+this.Utilisateur+" Film: "+this.Film+" Note: " + this.Note;
        }
    }
}
