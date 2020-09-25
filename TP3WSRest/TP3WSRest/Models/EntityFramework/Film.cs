using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TP3WSRest.Models.EntityFramework
{
    [Table("Film")]
    public partial class Film
    {
        public Film()
        {
            FavorisFilm = new HashSet<Favori>();
        }
        [Key]
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [Column("FLM_TITRE")]
        [Required]
        public string Titre { get; set; }

        [Column("FLM_SYNOPSIS")]
        public string Synopsis { get; set; }

        [Column("FLM_DATEPARUTION")]
        [Required]
        public DateTime DateParution { get; set; }

        [Column("FLM_DUREE")]
        [Required]
        public decimal Duree { get; set; }

        [Column("FLM_GENRE")]
        [Required]
        public string Genre { get; set; }

        [Column("FLM_URLPHOTO")]
        public string UrlPhoto { get; set; }

        [InverseProperty("FilmFavori")]
        public virtual ICollection<Favori> FavorisFilm { get; set; }

    }
}
