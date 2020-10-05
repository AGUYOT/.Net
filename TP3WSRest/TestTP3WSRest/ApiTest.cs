using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TP3WSRest.Controllers;
using TP3WSRest.Models.EntityFramework;

namespace TestTP3WSRest
{
    [TestClass]
    public class ApiTest
    {
        private readonly WSFilmsContext _context;
        private ComptesController _controller;

        public ApiTest()
        {
            var builder = new DbContextOptionsBuilder<WSFilmsContext>().UseNpgsql("Server=localhost;port=5432;Database=WSFilms; uid=postgres; password=postgres;");
            _context = new WSFilmsContext(builder.Options);
            _controller = new ComptesController(_context);
        }

        [TestMethod]
        public void PostCompte_ModelValidated_CreationOK()
        {
            // Arrange
            Random rnd = new Random();
            int chiffre = rnd.Next(1, 1000000000);
            // Le mail doit être unique donc 2 possibilités :
            // 1. on s'arrange pour que le mail soit unique en concaténant un random ou
            // 2. On supprime le compte après l'avoir créé. Dans ce cas, nous avons
            Compte compteAtester = new Compte()
            {
                Nom = "MACHIN",
                Prenom = "Luc",
                TelPortable = "0606070809",
                Mel = "machin" + chiffre + "@gmail.com",
                Pwd = "Toto1234!",
                Rue = "Chemin de Bellevue",
                CodePostal = "74940",
                Ville = "Annecy-le-Vieux",
                Pays = "France",
                Latitude = null,
                Longitude = null
            };
            // Act
            var result = _controller.PostCompte(compteAtester).Result;
            var result2 = _controller.GetCompteByEmail(compteAtester.Mel);
            var actionResult = result2.Result as ActionResult<Compte>;
            // Assert
            Assert.IsInstanceOfType(actionResult.Value, typeof(Compte), "Pas un compte");
            Compte compteRecupere = _context.Comptes.Where(c => c.Mel == compteAtester.Mel).FirstOrDefault();
            compteAtester.CompteId = compteRecupere.CompteId;
            Assert.AreEqual(compteRecupere, compteAtester, "Comptes pas identiques");
        }
        }
}
