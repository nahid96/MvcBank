using MvcBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBank.Controllers
{
    public class LoginController : Controller
    {
        private MyDbContext _context;

        public LoginController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(Record record)
        {
            var recordInDb = _context.Records.Where(b => b.CardNo.Equals(record.CardNo) && b.Pin.Equals(record.Pin)).FirstOrDefault();

            if(recordInDb != null)
            {
                Session["Id"] = recordInDb.Id.ToString();
                Session["CardNo"] = recordInDb.CardNo.ToString();
                Session["Pin"] = recordInDb.Pin.ToString();
                Session["Balance"] = recordInDb.Balance.ToString();

                return RedirectToAction("Index", "Account");
            }

            return RedirectToAction("Index", "Login");
        }

    }
}