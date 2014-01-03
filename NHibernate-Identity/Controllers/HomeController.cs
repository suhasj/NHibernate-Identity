using NHibernate;
using NHibernate_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NHibernate_Identity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var person = new Person() { FirstName = "foo", LastName = "bar" };
            using (var session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(person);
                    transaction.Commit();
                }
            }
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