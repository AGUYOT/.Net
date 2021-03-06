﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP3WSRest.Models.EntityFramework
{
    public partial class WSFilmsContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public WSFilmsContext()
        {
        }

        public WSFilmsContext(DbContextOptions<WSFilmsContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Favori> Favoris { get; set; }
        public virtual DbSet<Compte> Comptes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseLoggerFactory(MyLoggerFactory).EnableSensitiveDataLogging();
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Favori>(entity =>
            {
                entity.HasKey(f => new { f.CompteId, f.FilmId })
                    .HasName("PK_FAV");

                entity.HasOne(f => f.FilmFavori)
                    .WithMany(f => f.FavorisFilm)
                    .HasForeignKey(f => f.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAV_FLM");

                entity.HasOne(f => f.CompteFavori)
                    .WithMany(c => c.FavorisCompte)
                    .HasForeignKey(f => f.CompteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAV_CPT");
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.HasIndex(c => c.Mel)
                    .IsUnique();

                entity.Property(c => c.Pays)
                    .HasDefaultValue("France");

                entity.Property(c => c.DateCreation)
                    .HasDefaultValueSql("NOW()");
            });

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
