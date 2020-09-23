using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.Model
{
    class Devise
    {
        public Devise()
        {

        }
        public int Id { get; set; }

        public string NomDevise { get; set; }

        public double Taux { get; set; }
    }
}
