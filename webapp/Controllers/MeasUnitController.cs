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
    public class MeasUnitController : Controller
    {
        private CenDekContext db = new CenDekContext();
        // GET: ProductLine
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ShortDescription, LongDescription")] MeasUnit measUnit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (measUnit != null)
                    {
                        db.MeasUnits.Add(measUnit);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        return Json(new { warning = "status is null" });
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
                return View(measUnit);
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