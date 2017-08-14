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
    public class CurrencyController : Controller
    {
        private CenDekContext db = new CenDekContext();
        // GET: Currency
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Code,Name")] Currency currency)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (currency != null)
                    {
                        db.Currencies.Add(currency);
                        await db.SaveChangesAsync();
                    }
                    else
                    {
                        return Json(new { warning = "currency is null" });
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
                return View(currency);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}