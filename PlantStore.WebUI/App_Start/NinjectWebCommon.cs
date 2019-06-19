using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace PlantStore.WebUI.App_Start
{
    public class NinjectWebCommon
    {
        private static void RegisterServices()
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new
                PlantStore.WebUI.Infrastructure.NinjectDependencyResolver());
        }
    }
}