using CarsInventory.DataAccess.Base;
using CarsInventory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.DataAccess.Repositories
{
    public class CarRepository : BaseRepository<Car>
    {
        public CarRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
