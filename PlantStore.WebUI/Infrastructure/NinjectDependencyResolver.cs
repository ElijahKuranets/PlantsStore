﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using PlantStore.Domain;
using PlantStore.Domain.Abstract;
using PlantStore.Domain.Entities;

namespace PlantStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : DefaultControllerFactory
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext reqCont, Type contType)

        {
            return contType == null
                ? null
                : (IController)kernel.Get(contType);
        }

        private void AddBindings()
        {
            // Здесь размещаются привязки
            Mock<IPlantRepository> mock = new Mock<IPlantRepository>();
            mock.Setup(m => m.Plants).Returns(new List<Plant>
    {
        new Plant { Name = "Smaragd", Price = 1499 },
        new Plant { Name = "Pinus", Price=2299 },
        new Plant { Name = "Conica", Price=899.4M }
    });
            kernel.Bind<IPlantRepository>().ToConstant(mock.Object);
        }
    }
}