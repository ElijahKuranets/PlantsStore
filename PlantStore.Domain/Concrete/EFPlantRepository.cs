using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantStore.Domain.Abstract;
using PlantStore.Domain.Entities;

namespace PlantStore.Domain.Concrete
{
    public class EFPlantRepository : IPlantRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Plant> Plants
        {
            get { return context.Plants; }
        }
    }
}
