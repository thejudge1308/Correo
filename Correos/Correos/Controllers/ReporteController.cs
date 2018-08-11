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
        public IActionResult Rank_1() {
            List<Cartas_dep> lista = new Reporte().getNumeroCartas();
            ViewData["lista"] = lista;
            return View();
        }

        [HttpGet]
        public IActionResult Rank_2() {
            List<Cartas_dep> lista = new Reporte().getNumeroDestinatarios();
            ViewData["lista"] = lista;
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