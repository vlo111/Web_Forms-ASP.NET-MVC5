#region Using

using DataAccess;
using DataAccess.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

#endregion

namespace CenDek.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private CenDekContext db = new CenDekContext();

        // GET: home/index
        public ActionResult Index()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.CategoryPID = db.Categories.Where(c => c.CategoryParentID == null).OrderBy(a => a.Name);
            ViewBag.ProductLineID = new SelectList(db.ProductLines, "ProductLineID", "Name");
            ViewBag.MeasUnitID = new SelectList(db.MeasUnits, "MeasUnitID", "ShortDescription");
            ViewBag.PartStatusID = new SelectList(db.PartStatus, "PartStatusID", "Status");

            ViewBag.CostCurrencyID = new SelectList(db.Currencies, "CurrencyID", "Name");
            ViewBag.SellCurrencyID = new SelectList(db.Currencies, "CurrencyID", "Name");

            if (Session["TmpModel"] != null)
            {
                var modelErrors = (ModelStateDictionary)Session["TmpModel"];

                foreach (ModelState modelState in modelErrors.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        if (error.ErrorMessage == "Required field Start Date" || error.ErrorMessage == "Required field End Date" || error.ErrorMessage == "Required field Cost" || error.ErrorMessage == "Required field Sell")
                        {
                            ModelState.AddModelError("ReviewErrors", "The Price is invalid");
                        }
                        else
                        {
                            ModelState.AddModelError("PartErrors", error.ErrorMessage);
                        }
                    }
                }

            }
            return View();
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