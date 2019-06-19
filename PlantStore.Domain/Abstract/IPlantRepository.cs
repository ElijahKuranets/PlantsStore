using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantStore.Domain.Entities;

namespace PlantStore.Domain.Abstract
{
    public interface IPlantRepository
    {
        IEnumerable<Plant> Plants { get; }
    }
}
