using Macorati.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macorati.Controllers
{
    public class LancheController : Controller
    {
        public LancheController()
        {

        }
        public IActionResult List()
        {
            Lanches lanche = new Lanches();
            var lancheAux = lanche.GetLanches();
            return View(lancheAux);
        }
        public IActionResult Lanches()
        {
            Lanches lanche = new Lanches();
            var lancheAux = lanche.GetLanches();
            return View(lancheAux);
        }
    }
}
