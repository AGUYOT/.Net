using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Model
{
    public class Devise
    {
        public Devise()
        {

        }
        public int Id { get; set; }

        public string NomDevise { get; set; }

        public double Taux { get; set; }

    }
}
