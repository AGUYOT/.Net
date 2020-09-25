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
            //Exo2Q1();
            //Exo2Q1Bis();
            //Exo2Q2();
            //Exo2Q3();
            //Exo2Q4();
            //Exo2Q5();
            //Exo2Q6();
            //Exo2Q7();
            //Exo2Q8();
            //Exo2Q9();
            //Exo3_AddUser();
            //Exo3_EditFilm();
            //Exo3_CreateAvis();
            Exo3_CreateFilms();
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
                Console.WriteLine("Id: " + film.Id + " Nom: " + film.Nom);
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
            Console.WriteLine("Moyenne de la note du film Pulp Fiction : " + somme / count);
            Console.ReadKey();
        }

        public static void Exo2Q9()
        {
            var ctx = new FilmsDBContext();
            var utilisateur = ctx.Utilisateur.Select(u => u)
                .Include(u => u.Avis)
                .Where(u => u.Id == ctx.Avis.Where(a => a.Note == ctx.Avis.Max(a => a.Note)).Select(a => a.Utilisateur).FirstOrDefault())
                .FirstOrDefault();
            Console.WriteLine("Utilisateur ayant attribué la meilleur note : " + utilisateur.ToString());
            Console.ReadKey();
        }

        public static void Exo3_AddUser()
        {
            var ctx = new FilmsDBContext();
            Utilisateur user = new Utilisateur
            {
                Login = "aguyot",
                Pwd = "test123",
                Email = "monMail@mail.fr"
            };
            ctx.Utilisateur.Add(user);
            ctx.SaveChanges();
            Console.WriteLine("Utilisateur Créé : " + user.ToString());
            Console.ReadKey();
        }

        public static void Exo3_EditFilm()
        {
            var ctx = new FilmsDBContext();
            var film = ctx.Film.FirstOrDefault(f => f.Nom.Equals("L'armee des douze singes"));
            film.Description = "Film de science-fiction d'un futur catastrophique. Voyage dans le temps au programme";
            film.Categorie = ctx.Categorie.Where(c => c.Nom.Equals("Drame")).Select(c => c.Id).FirstOrDefault();
            int nbChanges = ctx.SaveChanges();
            Console.WriteLine("Nombre de changements effectués : " + nbChanges);
            Console.ReadKey();
        }

        public static void Exo3_CreateAvis()
        {
            var ctx = new FilmsDBContext();
            Avis avis = new Avis
            {
                Note = new Decimal(0.954231),
                Film = 37,
                Utilisateur = 1,
                Avis1 = "Film génial !"
            };
            ctx.Avis.Add(avis);
            int nbChanges = ctx.SaveChanges();
            Console.WriteLine("Avis créé : " + avis.ToString());
            Console.ReadKey();
        }

        public static void Exo3_CreateFilms()
        {
            var ctx = new FilmsDBContext();
            Film film = new Film
            {
            };
            ctx.Film.AddRange(
                new Film
                { 
                    Nom = "Avatar",
                    Categorie = 5,
                    Description = "Des bonhommes bleus"
                },
                new Film
                {
                    Nom = "Avengers",
                    Categorie = 5,
                    Description = "Explosions partout"
                }
            );
            int nbChanges = ctx.SaveChanges();
            Console.WriteLine("Nombre de changes : " + nbChanges);
            Console.ReadKey();
        }
    }
}
