using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseTracker2.Models;
namespace ExpenseTracker2.Controllers
{
    public class TotalLimitController : Controller
    {
        DatabaseCon con = new DatabaseCon();
        // GET: TotalLimit
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddLimit()
        {
            Limit l = new Limit();
            l.totLimit = 40000.0f;
            con.lobj.Add(l);
            con.SaveChanges();
            return RedirectToAction("ListTotLimit");
            

           
        }
        [HttpPost]
        public ActionResult AddLimit(Limit l)
        {
            
            
            return View(l);
        }
        [HttpGet]
        public ActionResult EditLimit(int id)
        {
            var row = con.lobj.Where(h => h.Id == id).FirstOrDefault();
            return View(row);

        }
        [HttpPost]
        public ActionResult EditLimit(Limit l)
        {
            
            if (ModelState.IsValid)
            {
                l.Id = l.Id;
                l.totLimit = l.totLimit;
               

                con.Entry(l).State = EntityState.Modified;
                con.SaveChanges();
                TempData["AlertMsg"] = "Record Updated Successful...";

                return RedirectToAction("ListTotLimit");
            }
            ModelState.Clear();
            return View("AddLimit");
            // var row = Db_Conn.Model_Category.Where(h => h.Id == id).FirstOrDefault();
        }


        public ActionResult ListTotLimit()
        {
            return View(con.lobj.Where(h => h.Id == 1).ToList());
        }
       

    }
}