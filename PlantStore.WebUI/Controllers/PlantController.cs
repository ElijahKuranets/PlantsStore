using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlantStore.Domain.Abstract;
using PlantStore.WebUI.Models;

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
            PlantsListViewModel model = new PlantsListViewModel
            {
                Plants = repository.Plants.OrderBy(game => game.PlantId).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Plants.Count()
                }
            };
            return View(model);
        }
    }
}