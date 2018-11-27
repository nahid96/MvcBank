using MvcBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBank.Controllers
{
    public class BankController : Controller
    {
        private MyDbContext _context;

        public BankController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Bank
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexPost(User user)
        {
            var userInDb = _context.Users.Where(b => b.CardNumber == user.CardNumber && b.Pin == user.Pin).FirstOrDefault();

            if (userInDb != null)
            {
                //Session["Id"] = recordInDb.Id.ToString();
                //Session["CardNumber"] = recordInDb.CardNumber.ToString();
                Session["Pin"] = userInDb.Pin.ToString();
                //Session["Balance"] = recordInDb.Balance.ToString();

                return RedirectToAction("Dashboard", "Bank", new {userInDb.Id});
            }

            return RedirectToAction("Logout", "Bank");
        }

        [Route("Bank/{id}/Dashboard")]
        public ActionResult Dashboard(int id)
        {
            var userInDb = _context.Users.Where(b => b.Id == id).FirstOrDefault();

            if (Convert.ToInt32(Session["Pin"]) == userInDb.Pin)
            {
                if (userInDb != null)
                {
                    return View(userInDb);
                }
                else
                {
                    return RedirectToAction("Index", "Bank");
                }
            }
            else
            {
                return RedirectToAction("Logout", "Bank");
            }
            
        }

        [Route("Bank/{id}/CheckBalance")]
        public ActionResult CheckBalance(int id)
        {
            var userInDb = _context.Users.Where(b => b.Id == id).FirstOrDefault();

            if (Convert.ToInt32(Session["Pin"]) == userInDb.Pin)
            {
                return View(userInDb);
            }
            else
            {
                return RedirectToAction("Logout", "Bank");
            }

            
        }

        [Route("Bank/{id}/Withdraw")]
        public ActionResult Withdraw(int id)
        {
            var userInDb = _context.Users.Where(b => b.Id == id).FirstOrDefault();

            if (Convert.ToInt32(Session["Pin"]) == userInDb.Pin)
            {
                return View(userInDb);
            }
            else
            {
                return RedirectToAction("Logout", "Bank");
            }
            
        }

        [HttpPost]
        [Route("Bank/{id}/WithdrawPost")]
        public ActionResult WithdrawPost(int id, int balance)
        {
            var userInDb = _context.Users.Where(b => b.Id == id).FirstOrDefault();

            var transactionHistoryInDb = _context.TransactionHistories.Where(b => b.UserId == id).FirstOrDefault();

            if (Convert.ToInt32(Session["Pin"]) == userInDb.Pin)
            {
                if (transactionHistoryInDb.TransactionCount < 3)
                {
                    if (userInDb.Balance >= balance && userInDb.Balance != 0)
                    {
                        userInDb.Balance = (userInDb.Balance - balance);
                        transactionHistoryInDb.TransactionAmount = balance;
                        transactionHistoryInDb.TransactionCount = ++transactionHistoryInDb.TransactionCount;

                        _context.SaveChanges();

                        return RedirectToAction("TransactionDetails", "Bank");
                    }
                    else
                    {
                        return RedirectToAction("NotWithdraw", "Bank");
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Logout", "Bank");
            }
            
            //Session["Balance"] = userInDb.Balance.ToString();
        }

        [Route("Bank/{id}/NotWithdraw")]
        public ActionResult NotWithdraw()
        {
            return View();
        }

        [Route("Bank/{id}/TransactionDetails")]
        public ActionResult TransactionDetails(int id)
        {
            var userInDb = _context.Users.Where(b => b.Id == id).FirstOrDefault();
            var transactionHistoryInDb = _context.TransactionHistories.Where(b => b.UserId == id).FirstOrDefault();
            
            if (Convert.ToInt32(Session["Pin"]) == userInDb.Pin)
            {
                return View(transactionHistoryInDb);
            }
            else
            {
                return RedirectToAction("Logout", "Bank");
            }
        }

        
        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Bank");
        }
    }
}