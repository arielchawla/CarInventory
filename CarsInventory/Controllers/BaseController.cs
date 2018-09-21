using CarsInventory.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsInventory.Controllers
{
    public abstract class BaseController : Controller
    {
        public UnitOfWork UnitOfWork { get; set; }

        public BaseController()
        {
            UnitOfWork = new UnitOfWork();
        }
    }
}