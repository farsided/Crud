using Crud.Areas.Contacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Crud.Areas.Contacts.Controllers
{
    public class NetworkTypeController : Controller
    {
        // GET: Contacts/NetworkType
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
        public ActionResult Create(NetworkType networkType)
        {
            NetworkType mod = new NetworkType();
            if (ModelState.IsValid)
            {
                mod.Create(networkType);
                return RedirectToAction("Index");
            }

            return View(networkType);
        }

        //Update------------------------------------------
        [HttpGet]
        public ActionResult Update(int ID)
        {
            NetworkType networkType = new Models.NetworkType();
            return View(networkType.Find(ID));
        }

        [HttpPost]
        public ActionResult Update(NetworkType networkType)
        {
            if (ModelState.IsValid)
            {
                networkType.Update(networkType);
                return RedirectToAction("Index");
            }

            return View(networkType);
        }

        //Search------------------------------------------
        [HttpGet]
        public ActionResult List(string search = "")
        {
            NetworkType networkType = new Models.NetworkType();
            return View(networkType.List(search));
        }

        [HttpGet]
        public ActionResult Find(int ID)
        {
            NetworkType networkType = new Models.NetworkType();
            return View(networkType.Find(ID));
        }

        //Delete------------------------------------------
        [HttpGet]
        public ActionResult DeleteView(int ID)
        {
            NetworkType networkType = new NetworkType();
            return View(networkType.Find(ID));
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            NetworkType networkType = new Models.NetworkType();
            networkType.Delete(ID);
            return RedirectToAction("Index");
        }
    }
}