using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSConvertisseur.Model
{
    public class Devise
    {
        public Devise()
        {

        }
        public int Id { get; set; }

        [Required]
        public string NomDevise { get; set; }

        public double Taux { get; set; }

    }

}
