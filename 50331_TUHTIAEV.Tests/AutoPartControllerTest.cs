using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.DAL.Interfaces;
using Shop.DAL.Entities;
using System.Collections.Generic;
using _50331_TUHTIAEV.Controllers;
using System.Web.Mvc;
using _50331_TUHTIAEV.Models;
using System.Web;
using System.Web.Routing;

namespace _50331_TUHTIAEV.Tests
{
    [TestClass]
    public class AutoPartControllerTest
    {
        [TestMethod]
        public void PagingTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<AutoPart>>();
            mock.Setup(r => r.GetAllAutoParts())
                                            .Returns(new List<AutoPart> {
                                                                        new AutoPart { AutoPartId=1 },
                                                                        new AutoPart { AutoPartId=2 },
                                                                        new AutoPart { AutoPartId=3 },
                                                                        new AutoPart { AutoPartId=4 },
                                                                        new AutoPart { AutoPartId=5 },
                                                                        });
            // Создание объекта контроллера
            var controller = new AutoPartController(mock.Object);

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);
            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;


            // Act
            // Вызов метода List 
            var view = controller.List(null, 2) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<AutoPart> model = view.Model as PageListViewModel<AutoPart>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].AutoPartId);
            Assert.AreEqual(5, model[1].AutoPartId);
        }

        [TestMethod]
        public void CategoryTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<AutoPart>>();
            mock.Setup(r => r.GetAllAutoParts())
                                            .Returns(new List<AutoPart> {
                                                            new AutoPart { AutoPartId=1, GroupName="1" },
                                                            new AutoPart { AutoPartId=2, GroupName="2" },
                                                            new AutoPart { AutoPartId=3, GroupName="1" },
                                                            new AutoPart { AutoPartId=4, GroupName="2" },
                                                            new AutoPart { AutoPartId=5, GroupName="2" },
                                            });
            // Создание объекта контроллера
            var controller = new AutoPartController(mock.Object);
            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);
            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;

            // Act
            // Вызов метода List 
            var view = controller.List("1", 1) as ViewResult;

            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<AutoPart> model = view.Model as PageListViewModel<AutoPart>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].AutoPartId);
            Assert.AreEqual(3, model[1].AutoPartId);
        }

        [TestMethod]
        public void DefaultRouteTest()
        {
            // Arrange
            // Макет Http - контекста
            var mockContext = new Mock<HttpContextBase>();
            mockContext
                        .Setup(c => c.Request.AppRelativeCurrentExecutionFilePath)
                        .Returns("~/");
            // Создание коллекции маршрутов и регистрация маршрутов
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //Act
            //Получение данных маршрута
            var result = routes.GetRouteData(mockContext.Object);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home", result.Values["controller"]);
            Assert.AreEqual("Index", result.Values["action"]);
            Assert.AreEqual(UrlParameter.Optional, result.Values["id"]);
        }
    }
}
