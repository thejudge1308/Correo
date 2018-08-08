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

        [HttpGet]
        public IActionResult Supervisor() {
            ViewData["usuarios"] = new Usuario().getSupervisores();
            return View();
        }

        [HttpGet]
        public IActionResult Cajero() {
            ViewData["usuarios"] = new Usuario().getCajeros();
            return View();
        }

        [HttpGet]
        public IActionResult AgregarCajero() {
            ViewData["sucursales"] = new Sucursal().getSucursales();

            //ViewData["Ingresar usuario."] = new Usuario().getCajeros();
            return View();
        }

        public class jsonCajero {
            public string ru { get; set; }
            public string no { get; set; }
            public string se { get; set; }
            public string dom { get; set; }
            public string fe { get; set; }
            public string fo { get; set; }
            public string op { get; set; }
            public string pre { get; set; }
        }
        [HttpPost]
        public IActionResult AgregarCajero(jsonCajero use) {

            Usuario u = new Usuario();
            u.AgregarUsuario(use.ru, use.no, use.se, use.dom, use.pre, use.fe, use.fo, use.op);

            return View();
        }

    }
}
