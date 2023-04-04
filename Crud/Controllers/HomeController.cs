using PMSRedirect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        UserSessions session = new UserSessions(@"SERVER=192.168.0.101\sqlExpress;DATABASE=dbPMS;USER=SA;PWD=1234");
        public ActionResult Index()
        {
            session.InitializeAdmin(124);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}