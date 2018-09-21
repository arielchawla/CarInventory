using CarsInventory.BussinessLogic.Managers;
using CarsInventory.DataAccess;
using CarsInventory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsInventory.Controllers
{
    public class CarsController : BaseController
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CarsController));  //Declaring Log4Net 
        StorageManager manager = null;
        /// <summary>
        ///  GET: Get List of Cars
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["userId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                manager = new StorageManager(UnitOfWork);
                var cars = manager.GetAllCars();
                return View(cars);
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return View();
            }

        }
        /// <summary>
        ///  GET: Get Data in Model Popup by Id.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCarDetailsModal(string Id)
        {
            try
            {
                Car objectCar = new Car();
                manager = new StorageManager(UnitOfWork);
                ViewBag.Title = "Add";
                if (!string.IsNullOrEmpty(Id))
                {
                    var id = new Guid(Id);
                    objectCar = manager.GetById(id);
                    ViewBag.Title = "Edit";
                }
                return PartialView(objectCar);
            }
            catch(Exception ex)
            {
                logger.Error(ex.ToString());
                return PartialView();
            }
        }
        /// <summary>
        /// Add and Update Cars
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateCars(CarViewModel data)
        {
            try
            {
                if (Session["userId"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                manager = new StorageManager(UnitOfWork);
                // for updating the record
                if (new Guid(data.Id) != Guid.Empty)
                {
                    Car objectCars = new Car()
                    {
                        Id = new Guid(data.Id),
                        Brand = data.Brand,
                        Model = data.Model,
                        Year = data.Year,
                        Price = data.Price,
                        New = data.New,
                        UserId =Convert.ToString(Session["userId"])

                    };
                    manager.AddCar(objectCars);
                }
                else
                {
                    // for saving the record
                    Car objectCars = new Car()
                    {
                        Id = Guid.NewGuid(),
                        Brand = data.Brand,
                        Model = data.Model,
                        Year = data.Year,
                        Price = data.Price,
                        New = data.New,
                        UserId = Convert.ToString(Session["userId"])
                    };
                    manager.AddCar(objectCars);
                }
            }
            catch(Exception ex)
            {
                // handling the error
                logger.Error(ex.ToString());
            }

            return RedirectToAction("Index");
        }

    }
}