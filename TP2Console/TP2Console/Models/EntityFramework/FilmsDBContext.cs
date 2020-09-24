using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Configuration;

namespace TP2Console.Models.EntityFramework
{
    public partial class FilmsDBContext : DbContext
    {
        public FilmsDBContext()
        {
        }

        public FilmsDBContext(DbContextOptions<FilmsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avis> Avis { get; set; }
        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<Utilisateur> Utilisateur { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server=localhost;port=5432;Database=FilmsDB; uid=postgres; password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avis>(entity =>
            {
                entity.HasKey(e => new { e.Film, e.Utilisateur })
                    .HasName("pk_avis");

                entity.HasOne(d => d.FilmNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Film)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_film");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.Avis)
                    .HasForeignKey(d => d.Utilisateur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avis_utilisateur");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasOne(d => d.CategorieNavigation)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.Categorie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_categorie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
