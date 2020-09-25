using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TP3WSRest.Models.EntityFramework
{
    [Table("T_E_COMPTE_CPT")]
    public partial class Compte
    {
        public Compte()
        {
            FavorisCompte = new HashSet<Favori>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CPT_ID")]
        public int CompteId { get; set; }

        [Column("CPT_NOM")]
        [StringLength(50)]
        [Required]
        public string Nom { get; set; }

        [Column("CPT_PRENOM")]
        [StringLength(50)]
        [Required]
        public string Prenom { get; set; }

        [Column("CPT_TELPORTABLE", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "")]
        public string TelPortable { get; set; }
        
        [Column("CPT_MEL")]
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string Mel { get; set; }

        [Column("CPT_PWD")]
        [StringLength(64)]
        public string Pwd { get; set; }

        [Column("CPT_RUE")]
        [StringLength(200)]
        [Required]
        public string Rue { get; set; }

        [Column("CPT_CP", TypeName = "char(5)")]
        [Required]
        public string CodePostal { get; set; }

        [Column("CPT_VILLE")]
        [StringLength(50)]
        [Required]
        public string Ville { get; set; }

        [Column("CPT_PAYS")]
        [StringLength(50)]
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
