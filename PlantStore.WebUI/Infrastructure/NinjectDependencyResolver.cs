﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Moq;
using Ninject;
using PlantStore.Domain;
using PlantStore.Domain.Abstract;
using PlantStore.Domain.Entities;

namespace PlantStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Здесь размещаются привязки
            Mock<IPlantRepository> mock = new Mock<IPlantRepository>();
            mock.Setup(m => m.Plants).Returns(new List<Plant>
    {
        new Plant { Name = "SimCity", Price = 1499 },
        new Plant { Name = "TITANFALL", Price=2299 },
        new Plant { Name = "Battlefield 4", Price=899.4M }
    });
            kernel.Bind<IPlantRepository>().ToConstant(mock.Object);
        }
    }
}