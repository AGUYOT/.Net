using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TP3WSRest.Models.EntityFramework
{
    public partial class Compte
    {
        public Compte()
        {
            FavorisCompte = new HashSet<Favori>();
        }

        [Key]
        [Column("CPT_ID")]
        public int CompteId { get; set; }

        [Column("CPT_NOM")]
        [Required]
        public string Nom { get; set; }

        [Column("CPT_PRENOM")]
        [Required]
        public string Prenom { get; set; }

        [Column("CPT_TELPORTABLE", TypeName = "char(10)")]
        public string TelPortable { get; set; }
        
        [Column("CPT_MEL")]
        [Required]
        public string Mel { get; set; }

        [Column("CPT_PWD")]
        public string Pwd { get; set; }

        [Column("CPT_RUE")]
        [Required]
        public string Rue { get; set; }

        [Column("CPT_CP", TypeName = "char(5)")]
        [Required]
        public string CodePostal { get; set; }

        [Column("CPT_VILLE")]
        [Required]
        public string Ville { get; set; }

        [Column("CPT_PAYS")]
        [Required]
        public string Pays { get; set; }

        [Column("CPT_LATITUDE")]
        public Nullable<float> Latitude { get; set; }

        [Column("CPT_LONGITUDE")]
        public Nullable<float> Longitude { get; set; }

        [Column("CPT_DATECREATION")]
        [Required]
        public DateTime DateCreation { get; set; }

        [InverseProperty("CompteFavori")]
        public virtual ICollection<Favori> FavorisCompte { get; set; }

    }
}
