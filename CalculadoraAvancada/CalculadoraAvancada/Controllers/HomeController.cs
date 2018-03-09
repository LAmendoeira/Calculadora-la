using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraAvancada.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Visor = 0;
            return View();
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {
            // identificar o valor da variavel 'bt'

            switch (bt)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    if (visor.Equals("0"))
                    {
                        visor = bt;
                        break;
                    } else
                    {
                        visor += bt;
                        break;
                    }
            }

            ViewBag.Visor = visor;
            return View();
        }
    }
}