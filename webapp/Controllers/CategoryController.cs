using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CenDek.Controllers
{
    public class CategoryController : Controller
    {
        private CenDekContext db = new CenDekContext();
        // GET: ProductLine
        public ActionResult Create()
        {
            ViewBag.CategoryParentID = new SelectList(db.Categories.Where(c => c.CategoryParentID == null).OrderBy(a => a.Name), "CategoryID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name, CategoryParentID")] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (category != null)
                    {
                        db.Categories.Add(category);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        return Json(new { warning = "category is null" });
                    }
                }
                else
                {
                    return Json(new { warning = "model is not valid" });
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(category);
            }
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}