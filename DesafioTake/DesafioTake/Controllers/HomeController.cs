﻿using System.Web.Mvc;

namespace DesafioTake.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Help", new { area = "" });
        }
    }
}
