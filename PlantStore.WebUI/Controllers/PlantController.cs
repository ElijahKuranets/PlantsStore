using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlantStore.Domain.Abstract;

namespace PlantStore.WebUI.Controllers
{
    public class PlantController : Controller
    {

        private IPlantRepository repository;

        public PlantController()
        {

        }
        public PlantController(IPlantRepository repo)
        {
            repository = repo;
        }

        public ActionResult List()
        {
            return View(repository.Plants);
        }
    }
}