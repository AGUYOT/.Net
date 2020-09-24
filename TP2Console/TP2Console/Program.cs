using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Globalization;
using System.Linq;
using TP2Console.Models.EntityFramework;

namespace TP2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Exo2Q8();
        }
        public static void Exo2Q1()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Film)
            {
                Console.WriteLine(film.ToString());
            }
            Console.ReadKey();
        }
        //Autre possibilité :
        public static void Exo2Q1Bis()
        {
            var ctx = new FilmsDBContext();
            //Pour que cela marche, il faut que la requête envoie les mêmes noms de colonnes

            var films = ctx.Film.FromSqlRaw("SELECT * FROM film");
            foreach (var film in films)
            {
                Console.WriteLine(film.ToString());
            }
            Console.ReadKey();
        }

        public static void Exo2Q2()
        {
            var ctx = new FilmsDBContext();
            foreach (var utilisateur in ctx.Utilisateur)
            {
                Console.WriteLine(utilisateur.Email);
            }
            Console.ReadKey();
        }

        public static void Exo2Q3()
        {
            var ctx = new FilmsDBContext();
            foreach (var utilisateur in ctx.Utilisateur.OrderBy(el => el.Login))
            {
                Console.WriteLine(utilisateur.ToString());
            }
            Console.ReadKey();
        }
        public static void Exo2Q4()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Film.Where(f => f.Categorie == ctx.Categorie.Where(c => c.Nom == "Action").Select(c => c.Id).FirstOrDefault()))
            {
                Console.WriteLine("Id: "+film.Id+" Nom: "+film.Nom);
            }
            Console.ReadKey();
        }

        public static void Exo2Q5()
        {
            var ctx = new FilmsDBContext();
            var nbCat = ctx.Categorie.Count();
            Console.WriteLine("Nombre de catégories: " + nbCat);
            Console.ReadKey();
        }
        public static void Exo2Q6()
        {
            var ctx = new FilmsDBContext();
            var min = ctx.Avis.Min(a => a.Note);
            Console.WriteLine("Note la plus basse: " + min);
            Console.ReadKey();
        }

        public static void Exo2Q7()
        {
            var ctx = new FilmsDBContext();
            foreach (var film in ctx.Film.AsEnumerable().Where(f => f.Nom.StartsWith("le", true, null)))
            {
                Console.WriteLine(film.ToString());
            }
            Console.ReadKey();
        }
        public static void Exo2Q8()
        {
            var ctx = new FilmsDBContext();
            var listeAvis = ctx.Avis.Select(a => a)
                .Include(a => a.FilmNavigation)
                .AsEnumerable()
                .Where(a => a.FilmNavigation.Nom.Equals("pulp fiction", StringComparison.InvariantCultureIgnoreCase));
            var somme = listeAvis.Sum(a => a.Note);
            var count = listeAvis.Count();
            Console.WriteLine("Moyenne de la note du film Pulp Fiction : "+somme/count);
            Console.ReadKey();
        }

        public static void Exo2Q9()
        {
            var ctx = new FilmsDBContext();
            var utilisateur = ctx.Utilisateur.Select(u => u)
                .Include(u => u.Avis)
                .Where(u => u.Id == ctx.Avis.Max(a => a.Note));
            Console.WriteLine("Utilisateur ayant attribué la meilleur note : ");
            Console.ReadKey();
        }
    }
}
