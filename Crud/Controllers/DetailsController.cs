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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {

            Person personL = new Person();
            //personL.Insert(person.ID, person.FName, person.MName, person.LName);
            return View(personL);
        }
    }
}