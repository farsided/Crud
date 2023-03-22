using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Models;
using System.Data;

namespace Crud.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Details
        [HttpGet]
        public ActionResult Index()
        {
            Person personList = new Person();

            return View(personList.Retrieve());
        }
    }
}