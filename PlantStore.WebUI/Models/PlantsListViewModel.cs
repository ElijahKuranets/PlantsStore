using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantStore.Domain.Entities;

namespace PlantStore.WebUI.Models
{
    public class PlantsListViewModel
    {
        public IEnumerable<Plant> Plants { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}