using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantStore.Domain.Entities;

namespace PlantStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
    }
}
