using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.Domain
{
    public class CarContext : DbContext
    { 
        public static DbContext Create()
        {
            return new CarContext();
        }

        public DbSet<Car> Cars { get; set; }
    }
}
