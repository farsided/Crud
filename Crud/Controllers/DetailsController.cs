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

            if (ModelState.IsValid)
            {
                personL.Insert(person);
                return RedirectToAction("Index");
                
            }
            
            return View(personL);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Person person = new Person();
            return View(person.Retrieve(ID));
            //return View();
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
            person.Update(person);
            return View(person);
        }
    }
}