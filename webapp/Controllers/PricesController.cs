using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CenDek.Controllers
{
    public class PricesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}