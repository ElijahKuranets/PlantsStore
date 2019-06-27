using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlantStore.Domain.Abstract;
using PlantStore.Domain.Entities;
using PlantStore.WebUI.Controllers;
using PlantStore.WebUI.HtmlHelpers;
using PlantStore.WebUI.Models;

namespace PlantStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            var mock = new Mock<IPlantRepository>();
            mock.Setup(m => m.Plants).Returns(new List<Plant>
                {
                    new Plant {PlantId = 1, Name = "Pinus"},
                    new Plant {PlantId = 2, Name = "Thuja"},
                    new Plant {PlantId = 3, Name = "Juniperus"},
                    new Plant {PlantId = 4, Name = "Picea"},
                    new Plant {PlantId = 5, Name = "Acer"},
                }
            );
            var controller = new PlantController(mock.Object);
            controller.pageSize = 3;

            //Act
            IEnumerable<Plant> result = (IEnumerable<Plant>) controller.List(2).Model;

            //Assert
            List<Plant> plants = result.ToList();
            Assert.IsTrue(plants.Count == 2);
            Assert.AreEqual(plants[0].Name, "Picea");
            Assert.AreEqual(plants[1].Name, "Acer");
        }

        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;
            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
    }
}
