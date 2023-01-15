using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseTracker2.Models;

namespace ExpenseTracker2.Controllers
{
    public class HomeController : Controller
    {
        DatabaseCon con = new DatabaseCon();
        public ActionResult Index()
        {
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
        public ActionResult ListofCategory()
        {
            float cat_sum = con.cobj.ToList().Sum(h => h.catExpLimit);
            Limit l = con.lobj.FirstOrDefault(h => h.Id == 1);

            float remain = l.totLimit - cat_sum;
            TempData["Remain"] = remain;

            return View(con.cobj.ToList());
        }
        [HttpGet]
        public ActionResult Create(long? ID)
        {
            if (ID == null)
            {
                return View(new Category());
            }
            else
            {
                return View(con.cobj.ToList().Find(c => c.catId == ID.Value));
            }

        }
        [HttpPost]
        public ActionResult Create(Category c)
        {
            string btnaction = Request.Params["btn"].ToString();
            float cat_sum = con.cobj.ToList().Sum(h => h.catExpLimit);
            Limit l = con.lobj.FirstOrDefault(h => h.Id == 1);

            cat_sum = cat_sum +c.catExpLimit;

            if (cat_sum > l.totLimit)
            {
                TempData["AlertMsg"] = "Total Limit First Edited...";
                return RedirectToAction("ListTotLimit","TotalLimit");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (c.catId == 0)
                    {
                        con.cobj.Add(c);
                        con.SaveChanges();
                        ModelState.Clear();
                        c = new Category();
                        TempData["AlertMsg"] = "Record Inserted...";
                        return RedirectToAction("ListofCategory");
                    }
                    else
                    {
                        con.Entry(c).State = System.Data.Entity.EntityState.Modified;
                        con.SaveChanges();
                        TempData["AlertMsg"] = "Record Updated...";
                        return RedirectToAction("ListofCategory");
                    }

                }

                return View(c);
            }
        }
        public ActionResult Delete(long? ID)
        {
            if (ID == null)
            {
                return View(new Category());
            }
            else
            {
                Category c = con.cobj.ToList().Find(j => j.catId == ID.Value);
                con.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                con.SaveChanges();
                TempData["AlertMsg"] = "Record Deleted...";
                return RedirectToAction("ListofCategory");

            }

        }

    }
}