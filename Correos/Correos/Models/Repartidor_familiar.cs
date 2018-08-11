using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correos.Models
{
    public class Repartidor_familiar
    {
        public string nombre { get; set; }
        public string familiar { get; set; }
        public string numero { get; set; }

        public Repartidor_familiar(string nombre, string familiar, string numero) {
            this.nombre = nombre;
            this.familiar = familiar;
            this.numero = numero;
        }
    }
}
