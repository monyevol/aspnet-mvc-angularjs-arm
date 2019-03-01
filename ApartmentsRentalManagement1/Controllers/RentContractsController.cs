using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmentsRentalManagement1.Controllers
{
    public class RentContractsController : Controller
    {
        // GET: RentContracts
        public ActionResult Index()
        {
            return View();
        }

        // GET: RentContracts/Details
        public ActionResult Details() => View();

        // GET: RentContracts/Create
        public ActionResult Create() => View();

        // GET: RentContracts/Edit
        public ActionResult Edit() => View();

        // GET: RentContracts/Delete
        public ActionResult Delete() => View();
    }
}