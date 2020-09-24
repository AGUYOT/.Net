using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WSConvertisseur.Controllers;
using WSConvertisseur.Model;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class DeviseTest
    {
        private DeviseController _controller;

        [TestInitialize]
        public void InitialisationDesTests()
        {
            _controller = new DeviseController();
        }


        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetById(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Act
            var result = _controller.GetById(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise");
            Assert.AreEqual(new Devise(1, "Dollar", 1.08), (Devise)result.Value, "Devises pas identiques");
        }

        [TestMethod]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var result = _controller.GetById(20);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public void GetAll_ReturnsOkObjectResult()
        {
            // Act
            var result = _controller.GetAll();
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }

        [TestMethod]
        public void GetAll_ReturnsCorrectDevises()
        {
            List<Devise> devises = new List<Devise>
            {
                new Devise{
                    Id = 1,
                    NomDevise = "Dollar",
                    Taux = 1.08
                },
                new Devise{
                    Id = 2,
                    NomDevise = "Franc Suisse",
                    Taux = 1.07
                },
                new Devise{
                    Id = 3,
                    NomDevise = "Yen",
                    Taux = 120
                },
            };
            // Act
            var result = _controller.GetAll() as OkObjectResult;
            // Assert
            CollectionAssert.AreEqual(devises, (List<Devise>)result.Value, "Devises non identiques");
        }

        [TestMethod]
        public void Post_ReturnsObjectCreatedResult()
        {
            Devise test = new Devise
            {
                Id = 4,
                NomDevise = "Livre",
                Taux = 0.8
            };
            // Act
            var result = _controller.Post(test);
            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteResult), "Pas un CreatedAtRouteResult");
        }

        [TestMethod]
        public void Post_ResultObjectLeggit()
        {
            Devise test = new Devise
            {
                Id = 4,
                NomDevise = "Livre",
                Taux = 0.8
            };
            // Act
            var result = _controller.Post(test) as CreatedAtRouteResult;
            // Assert
            Assert.AreEqual(test, (Devise)result.Value, "Pas la bonne devise");
        }

        [TestMethod]
        public void Put_Modified()
        {
            Devise test = new Devise
            {
                Id = 3,
                NomDevise = "Livre",
                Taux = 0.8
            };
            // Act
            var result = _controller.Put(test.Id, test);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult), "Pas un EmptyResult");
        }

        [TestMethod]
        public void Put_NotFound()
        {
            Devise test = new Devise
            {
                Id = 4,
                NomDevise = "Livre",
                Taux = 0.8
            };
            // Act
            var result = _controller.Put(test.Id, test);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }

        [TestMethod]
        public void Put_BadRequest()
        {
            Devise test = new Devise
            {
                Id = 3,
                NomDevise = "Livre",
                Taux = 0.8
            };
            // Act
            var result = _controller.Put(1, test);
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult), "Pas un BadRequestResult");
        }

        [TestMethod]
        public void Delete_Success()
        {
            // Act
            var result = _controller.Delete(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkResult");
        }

        [TestMethod]
        public void Delete_NotFound()
        {
            // Act
            var result = _controller.Delete(4);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }
    }
}
