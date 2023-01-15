using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseTracker2.Models;

namespace ExpenseTracker2.Controllers
{
    public class ExpenseController : Controller
    {
        DatabaseCon con = new DatabaseCon();
        // GET: Expense
        public ActionResult Index(int? cat)
        {
            if (cat != null)
            {
                var catlist = con.eobj.Where(x => x.catId == cat).ToList();
                return View(catlist);

            }
            else
            {
                var catlist = con.eobj.ToList();
                return View(catlist);
            }
           
        }   
          
        [HttpGet]
        public ActionResult Create(long? ID)
        {
            if (ID == null)
            {
                var catlist = con.cobj.ToList();
                ViewBag.catId = new SelectList(catlist, "catId", "catName");
                return View(new Expense());
            }
            else
            {
                var catlist = con.cobj.ToList();
                ViewBag.catId = new SelectList(catlist, "catId", "catName");
                return View(con.eobj.ToList().Find(e => e.exId == ID.Value));
            }
           
        }
        
        [HttpPost]
        public ActionResult Create(Expense e)
        {
            string btnaction = Request.Params["btn"].ToString();
            float total_exp = con.eobj.Where(j => j.catId == e.catId).ToList().Sum(j => j.Amount);
            Category c = con.cobj.FirstOrDefault(j => j.catId == e.catId);
            total_exp += e.Amount;
        
            if (total_exp > c.catExpLimit)
            {
               TempData["AlertMsg"] = "Edit Expense limit...";
                
                return RedirectToAction("ListofCategory","Home");

            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (e.exId == 0)
                    {

                        var catlist = con.cobj.ToList();
                        ViewBag.catId = new SelectList(catlist, "catId", "catName");
                        con.eobj.Add(e);
                        con.SaveChanges();
                        ModelState.Clear();
                        e = new Expense();
                        TempData["AlertMsg"] = "Record Inserted...";
                        return RedirectToAction("ExpenseList");
                    }
                    else
                    {
                        var catlist = con.cobj.ToList();
                        ViewBag.catId = new SelectList(catlist, "catId", "catName");

                        con.Entry(e).State = System.Data.Entity.EntityState.Modified;
                        con.SaveChanges();
                        TempData["AlertMsg"] = "Record Updated...";
                        return RedirectToAction("ExpenseList");
                    }

                }
                return View(e);
            }
        }
        public ActionResult ExpenseList()
        {
            return View(con.eobj.ToList());
        }
        public ActionResult Delete(long? ID)
        {
            if (ID == null)
            {
                return View(new Expense());
            }
            else
            {
                Expense e = con.eobj.ToList().Find(j => j.exId == ID.Value);
                con.Entry(e).State = System.Data.Entity.EntityState.Deleted;
                con.SaveChanges();
                 TempData["AlertMsg"] = "Record Deleted...";
                return RedirectToAction("ExpenseList");

            }

        }
        public ActionResult TotalExpense()
        {
            ViewBag.exp = con.eobj.Sum(h => h.Amount);
            return View(ViewBag.exp);
        }
       


    }

}