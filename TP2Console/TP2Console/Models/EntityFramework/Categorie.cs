using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP2Console.Models.EntityFramework
{
    [Table("categorie")]
    public partial class Categorie
    {
        public Categorie()
        {
            Film = new HashSet<Film>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nom")]
        [StringLength(50)]
        public string Nom { get; set; }
        [Column("description")]
        public string Description { get; set; }

        [InverseProperty("CategorieNavigation")]
        public virtual ICollection<Film> Film { get; set; }
    }
}
