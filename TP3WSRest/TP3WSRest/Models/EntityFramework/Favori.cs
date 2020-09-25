using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TP3WSRest.Models.EntityFramework
{
    [Table("T_J_FAVORI_FAV")]
    public partial class Favori
    {
        [Key]
        [Column("CPT_ID")]
        public int CompteId { get; set; }

        [Key]
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty("FavorisFilm")]
        public virtual Film FilmFavori { get; set; }

        [ForeignKey(nameof(CompteId))]
        [InverseProperty("FavorisCompte")]
        public virtual Compte CompteFavori { get; set; }
    }
}
