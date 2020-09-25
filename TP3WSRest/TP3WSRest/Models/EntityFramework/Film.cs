using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TP3WSRest.Models.EntityFramework
{
    [Table("T_E_FILM_FLM")]
    public partial class Film
    {
        public Film()
        {
            FavorisFilm = new HashSet<Favori>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [Column("FLM_TITRE")]
        [StringLength(100)]
        [Required]
        public string Titre { get; set; }

        [Column("FLM_SYNOPSIS")]
        [StringLength(500)]
        public string Synopsis { get; set; }

        [Column("FLM_DATEPARUTION", TypeName = "date")]
        [Required]
        public DateTime DateParution { get; set; }

        [Column("FLM_DUREE")]
        [Required]
        public decimal Duree { get; set; }

        [Column("FLM_GENRE")]
        [StringLength(30)]
        [Required]
        public string Genre { get; set; }

        [Column("FLM_URLPHOTO")]
        [StringLength(200)]
        public string UrlPhoto { get; set; }

        [InverseProperty("FilmFavori")]
        public virtual ICollection<Favori> FavorisFilm { get; set; }

    }
}
