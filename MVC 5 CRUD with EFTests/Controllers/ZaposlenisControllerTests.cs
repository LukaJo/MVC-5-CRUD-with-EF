using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC_5_CRUD_with_EF.Controllers;
using MVC_5_CRUD_with_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_5_CRUD_with_EF.Controllers.Tests
{
    [TestClass]
    public class ZaposlenisControllerTests
    {
        [TestMethod]
        public void DetailsTest()
        {

            //test details metode ;za redirect test,dal dobro gadja rutu tj dal salje na Index

            // Arrange
            var controller = new ZaposlenisController();

            // Act
            var result = (RedirectToRouteResult)controller.Details(null);

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");

          
        }

        [TestMethod]
        public void DetailsTest2()
        {

            //test details metode ; dal je za uneti id u metodi Details vrednost property-ja sektor jednaka "IT"

            // Arrange
            var controller = new ZaposlenisController();

            // Act
            var result = controller.Details(1) as ViewResult; 
           
            var zaposleni = (Zaposleni)result.ViewData.Model;

            // Assert
            Assert.AreEqual("IT", zaposleni.Sektor);

        }

        [TestMethod]
        public void DetailsTest3()
        {

            //test details metode ; dal je za uneti id u metodi Details naziv View-a jednak ""

            // Arrange
            var controller = new ZaposlenisController();

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewName);
        }


        [TestMethod]
        public void DetailsTest4()
        {
            //test details metode; dal je result type view result

            // Arrange
            var controller = new ZaposlenisController();

            // Act
            ActionResult result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        [TestMethod]
        public void IndexTest()
        {
            //test index metode

            // Arrange
            var controller = new ZaposlenisController(); // you should mock your DbContext and pass that in

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
        }

        
        [TestMethod()]
        public void AddTest()
        {
            //test add metode

            // Arrange
            var controller = new ZaposlenisController();

            // Act
            int result = controller.Add(6, 5);

            // Assert
            Assert.AreEqual<int>(11, result);
        }
    }
}