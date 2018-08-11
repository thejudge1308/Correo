using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correos.Models
{
    public class Cartas_dep
    {
        public string nombre { get; set; }
        public string cantidad { get; set; }

        public Cartas_dep(string nombre, string cantidad) {
            this.nombre = nombre;
            this.cantidad = cantidad;
        }
    }
}
