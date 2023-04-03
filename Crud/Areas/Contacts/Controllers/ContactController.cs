using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Areas.Contacts.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contacts/Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}