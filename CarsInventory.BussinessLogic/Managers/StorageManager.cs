using CarsInventory.BussinessLogic.Services;
using CarsInventory.DataAccess;
using CarsInventory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsInventory.BussinessLogic.Managers
{
    public class StorageManager
    {
        CarService CarService { get; set; }

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public StorageManager(UnitOfWork unitOfWork)
        {
            CarService = new CarService(unitOfWork);
        }
        /// <summary>
        /// Add Car Methode
        /// </summary>
        /// <param name="car"></param>
        public void AddCar(Car car)
        {
            CarService.Add(car);
            CarService.SaveChanges();
        }

        public IEnumerable<Car> GetAllCars()
        {
           return CarService.GetAll();
        }

        public Car GetById(Guid Id)
        {
            return CarService.GetById(Id);
        }
    }
}