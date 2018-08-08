using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Correos.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Empleado() {
            ViewData["usuarios"] = new Usuario().getEmpleados();
            return View();
        }


    }
}
