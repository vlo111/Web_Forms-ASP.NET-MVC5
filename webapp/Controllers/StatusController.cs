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
    public class StatusController : Controller
    {
        private CenDekContext db = new CenDekContext();
        // GET: ProductLine
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Status")] PartStatu partStatu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (partStatu != null)
                    {
                        db.PartStatus.Add(partStatu);
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
                return Json(new { warning = e.Message });
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