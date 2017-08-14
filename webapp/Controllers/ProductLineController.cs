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
    public class ProductLineController : Controller
    {
        private CenDekContext db = new CenDekContext();
        // GET: ProductLine
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name, Description")] ProductLine productLine)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (productLine != null)
                    {
                        db.ProductLines.Add(productLine);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        return Json(new { warning = "ProductLines is null" });
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
                return View(productLine);
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