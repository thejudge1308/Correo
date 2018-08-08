using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correos.Models
{
    public class Supervisor : Usuario
    {
        public string Departamento { get; set; }

        public Supervisor(string rut, string nombre, string sexo, string domicilio, string previ, string fecha, string fono,string departamento) : base(rut, nombre, sexo, domicilio, previ, fecha, fono) {
            Departamento = departamento;
        }

       

    }
}
