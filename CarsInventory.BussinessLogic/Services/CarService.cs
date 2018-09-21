using CarsInventory.BussinessLogic.Base;
using CarsInventory.DataAccess;
using CarsInventory.DataAccess.Repositories;
using CarsInventory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.BussinessLogic.Services
{
    class CarService : BaseService<Car>
    {
        public CarService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            Repository = new CarRepository(unitOfWork);
        }
    }
}
