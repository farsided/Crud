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
        public ActionResult Index(string searchItem="")
        {
            Person personList = new Person();

            return View(personList.Retrieve(searchItem));
        }

        [HttpGet]
        public ActionResult Search(string item)
        {
            Person personList = new Person();

            return View(personList.Retrieve(item));
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
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Person person = new Person();
            return View(person.Retrieve(ID));
        }

        [HttpPost]
        public ActionResult Delete(Person person)
        {
            person.Delete(person.ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            Person person = new Person();
            return View(person.Retrieve(ID));
        }
    }
}