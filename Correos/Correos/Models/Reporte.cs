using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correos.Models
{
    public class Reporte
    {
        public List<Repartidor_familiar> getLista() {
            List<Repartidor_familiar> lista= new List<Repartidor_familiar>();

            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                string consulta = "select empleado.nombre as Repartidor, familiar.nombre as Familiar, familiar.numero as NumeroFamiliar from empleado, repartidor, familiar where empleado.rut = repartidor.ref_empleado and familiar.ref_repartidor = repartidor.ref_empleado and empleado.eliminado = 1; ";

                // Retrieve all rows
                using(var cmd = new NpgsqlCommand(consulta, conn))
                using(var resultado = cmd.ExecuteReader())
                    while(resultado.Read()) {
                        //Debug.WriteLine(resultado.GetValue(0));
                        string nombre = resultado.IsDBNull(0) ? "-" : resultado.GetString(0);
                        string familiar = resultado.IsDBNull(1) ? "-" : resultado.GetString(1);
                        string telefono = resultado.IsDBNull(2) ? "-" : resultado.GetString(2);

                        Repartidor_familiar a = new Repartidor_familiar(nombre,familiar,telefono);

                        lista.Add(a);
                    }

            }

            return lista;
        }


        public List<Cartas_dep> getNumeroCartas() {
            List<Cartas_dep> lista = new List<Cartas_dep>();

            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                string consulta = "select departamento.direccion, count(carta.codigo) as nroCartas from departamento inner join carta on departamento.direccion = carta.ref_departamento group by departamento.direccion order by nroCartas";

                // Retrieve all rows
                using(var cmd = new NpgsqlCommand(consulta, conn))
                using(var resultado = cmd.ExecuteReader())
                    while(resultado.Read()) {
                        //Debug.WriteLine(resultado.GetValue(0));
                        string nombre = resultado.IsDBNull(0) ? "-" : resultado.GetString(0);
                        string cantidad = resultado.IsDBNull(1) ? "-" : resultado.GetInt64(1)+"";
                        
                        Cartas_dep a = new Cartas_dep(nombre, cantidad);

                        lista.Add(a);
                    }

            }

            return lista;
        }

        public List<Cartas_dep> getNumeroDestinatarios() {
            List<Cartas_dep> lista = new List<Cartas_dep>();

            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                string consulta = "select direccion, nroDestinatarios from "+ 
                    "(select max(t1.nroDestinatarios) maxNroDestinatarios from "+ 
                    "(select departamento.direccion, count(carta_destinatario.ref_carta) as nroDestinatarios from departamento, carta, carta_destinatario where departamento.direccion = carta.ref_departamento and carta_destinatario.ref_carta = carta.codigo "+
                    "group by departamento.direccion) "+ 
                    "as t1)"+
                    "t2,( select departamento.direccion, count(carta_destinatario.ref_carta) as nroDestinatarios "+
                    "from departamento, carta, carta_destinatario where departamento.direccion = carta.ref_departamento and carta_destinatario.ref_carta = carta.codigo group by departamento.direccion)as t3 "+
                    "where t2.maxNroDestinatarios = t3.nroDestinatarios";
                // Retrieve all rows
                using(var cmd = new NpgsqlCommand(consulta, conn))
                using(var resultado = cmd.ExecuteReader())
                    while(resultado.Read()) {
                        //Debug.WriteLine(resultado.GetValue(0));
                        string nombre = resultado.IsDBNull(0) ? "-" : resultado.GetString(0);
                        string cantidad = resultado.IsDBNull(1) ? "-" : resultado.GetInt64(1) + "";

                        Cartas_dep a = new Cartas_dep(nombre, cantidad);

                        lista.Add(a);
                    }

            }

            return lista;
        }

    }
}
