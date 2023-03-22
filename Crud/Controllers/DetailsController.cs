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
            //if (person.FName == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("CustomError", "The Display Order cannot exactly match the Name.");
            //}
            //Person personList = new Person();
            //if (ModelState.IsValid)
            //{
            //    //person.Insert()
            //    //_db.Categories.Add(obj);
            //    //_db.SaveChanges();
            //    //TempData["success"] = "Category created successfully";
            //    return RedirectToAction("Index");
            //}

            return View();
        }

        //[HttpPost]
        //public ActionResult Create()
        //{
        //    Person personList = new Person();

        //    return View(personList.Retrieve());
        //}
    }
}