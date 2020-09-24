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

        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string NomDevise { get; set; }

        [Required]
        public double Taux { get; set; }

        public override bool Equals(object obj)
        {
            Devise toCompare = (Devise)obj;
            return (Id == toCompare.Id && NomDevise == toCompare.NomDevise && Taux == toCompare.Taux);
        }
    }

}
