using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Correos.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reportes() {
            return View();
        }

        [HttpGet]
        public IActionResult Contacto() {
            List<Repartidor_familiar> lista = new Reporte().getLista();
            ViewData["lista"] = lista;
            return View();
        }

    }
}