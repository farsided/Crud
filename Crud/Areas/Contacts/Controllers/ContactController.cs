using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud.Areas.Contacts.Models;

namespace Crud.Areas.Contacts.Controllers
{
    public class ContactController : Controller
    {
        Contact mod = new Contact();

        // GET: Contacts/Contact
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //Create------------------------------------------
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                mod.Create(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //Update------------------------------------------
        [HttpGet]
        public ActionResult Update(int ID)
        {
            Contact contact = new Models.Contact();
            return View(contact.Find(ID));
        }

        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Update(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //Search------------------------------------------
        [HttpGet]
        public ActionResult List(string search = "")
        {
            Contact contact = new Models.Contact();
            return View(contact.List(search));
        }

        [HttpGet]
        public ActionResult Find(int ID)
        {
            Contact contact = new Models.Contact();
            return View(contact.Find(ID));
        }

        //Delete------------------------------------------
        [HttpGet]
        public ActionResult DeleteView(int ID)
        {
            Contact contact = new Contact();
            return View(contact.Find(ID));
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            Contact contact = new Models.Contact();
            contact.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}