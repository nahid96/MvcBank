using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBank.Models;

namespace MvcBank.Controllers
{
    public class AccountController : Controller
    {
        private MyDbContext _context;

        public AccountController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Account
        public ActionResult Index()
        {
            if (Session["CardNo"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Exit()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Withdraw(Record record) { 
       
            var recordInDb = _context.Records.Where(b => b.CardNo.Equals(record.CardNo) && b.Pin.Equals(record.Pin)).FirstOrDefault();
            
            if (recordInDb.Balance >= record.Balance && recordInDb.CardNo == record.CardNo && recordInDb.Pin == record.Pin)
            {
                if (recordInDb.Count < 3)
                {
                    recordInDb.Balance = (recordInDb.Balance - record.Balance);
                    recordInDb.Count = ++recordInDb.Count;

                    _context.SaveChanges();

                    Session["Balance"] = recordInDb.Balance.ToString();

                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    return View("Withdraw");
                }
                
            }
            else
            {
                return View("Withdraw1");
            }
        }
    }
}