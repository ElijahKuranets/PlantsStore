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
        public int pageSize = 4;

        public PlantController()
        {

        }
        public PlantController(IPlantRepository repo)
        {
            repository = repo;
        }

        //public ActionResult List()
        //{
        //    return View(repository.Plants);
        //}

        public ViewResult List(int page = 1)
        {
            return View(repository.Plants
                .OrderBy(plant => plant.PlantId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize));
        }
    }
}