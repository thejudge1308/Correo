using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Correos.Models
{
    public class Sucursal
    {
        public string id { get; set; }



        public List<string> getSucursales() {
            List<string> lista = new List<string>();
            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                string consulta = "SELECT direccion From departamento;";

                // Retrieve all rows
                using(var cmd = new NpgsqlCommand(consulta, conn))
                using(var resultado = cmd.ExecuteReader())
                    while(resultado.Read()) {
                        //Debug.WriteLine(resultado.GetValue(0));
                        string direccion = resultado.IsDBNull(0) ? "-" : resultado.GetString(0);
                        Debug.WriteLine(direccion);
                       
                        lista.Add(direccion);
                    }

            }
            return lista;
        }
    }
}
