using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Correos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Correos.Controllers
{
    public class UsuarioController : Controller
    {
        public object Debuger { get; private set; }

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
            public string rut { get; set; }
            public string nombre { get; set; }
            public string sexo { get; set; }
            public string domicilio { get; set; }
            public string fecha { get; set; }
            public string fono { get; set; }
            public string opcion { get; set; }
            public string previ { get; set; }
          
        }
        [HttpPost]
        public IActionResult AgregarCajero([FromBody] jsonCajero use) {

            Usuario u = new Usuario();
            u.AgregarUsuario(use.rut, use.nombre, use.sexo, use.domicilio, use.previ, use.fecha, use.fono, use.opcion);
            //{Debug.WriteLine(use.rut + " : "+use.nombre+" : "+use.sexo+" : "+use.domicilio+" : "+use.fecha+" : "+use.fono+" : "+use.opcion+" : "+use.previ);
            return Json(true);

        }

    }
}
