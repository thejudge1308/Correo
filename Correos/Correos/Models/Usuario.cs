using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Correos.Models
{
    public class Usuario
    {
        ConectorBaseDeDatos conector;

        private string rut;
        private string nombre;
        private string sexo;
        private string domicilio;
        private string previ;
        private string fecha;
        private string fono;
        private string departamento;

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public string Previ { get => previ; set => previ = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Fono { get => fono; set => fono = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Departamento { get => departamento; set => departamento = value; }

        public Usuario(string rut, string nombre, string sexo, string domicilio,string previ, string fecha, string fono) {
            this.rut = rut;
            this.domicilio = domicilio;
            this.nombre = nombre;
            this.sexo = sexo;
            this.previ = previ;
            this.fecha = fecha;
            this.fono = fono;
        }

        public Usuario() {

        }

        public List<Usuario> getEmpleados() {
            List<Usuario> lista = new List<Usuario>();
            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                string consulta = "SELECT * FROM public.empleado;";
                // Insert some data
                /**using(var cmd = new NpgsqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO data (some_field) VALUES (@p)";
                    cmd.Parameters.AddWithValue("p", "Hello world");
                    cmd.ExecuteNonQuery();
                }**/

                // Retrieve all rows
                using(var cmd = new NpgsqlCommand(consulta, conn))
                using(var resultado = cmd.ExecuteReader())
                    while(resultado.Read()) {
                        //Debug.WriteLine(resultado.GetValue(0));
                        string rut = resultado.IsDBNull(0)?"-":resultado.GetString(0);
                        string nombre = resultado.IsDBNull(1)? "-" : resultado.GetString(1);
                        string sexo = resultado.IsDBNull(2)? "-" : resultado.GetString(2);
                        string domicilio = resultado.IsDBNull(3)?"-":resultado.GetString(3);
                        string previ = resultado.IsDBNull(4)?"-":resultado.GetString(4);
                        string fecha = resultado.IsDBNull(5)?"-":resultado.GetDate(5).ToString();
                        string fono = resultado.IsDBNull(6)?"-": resultado.GetString(6);
                        Usuario user = new Usuario(rut, nombre, sexo, domicilio, previ, fecha, fono);
                        lista.Add(user);
                    }

            }




            

            //this.conector = new ConectorBaseDeDatos();
            //NpgsqlDataReader resultado = this.conector.RealizarConsulta(consulta);
            //Debug.WriteLine(resultado.Depth);
            //this.conector.CerrarConexion();
           
            
            Debug.WriteLine("lista: "+ lista.Count);
            return lista;
        }

        public List<Supervisor> getSupervisores() {
            List<Supervisor> lista = new List<Supervisor>();
            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                string consulta = "Select * FROM empleado INNER JOIN supervisor on empleado.rut = supervisor.ref_empleado;";

                // Retrieve all rows
                using(var cmd = new NpgsqlCommand(consulta, conn))
                using(var resultado = cmd.ExecuteReader())
                    while(resultado.Read()) {
                        //Debug.WriteLine(resultado.GetValue(0));
                        string rut = resultado.IsDBNull(0) ? "-" : resultado.GetString(0);
                        string nombre = resultado.IsDBNull(1) ? "-" : resultado.GetString(1);
                        string sexo = resultado.IsDBNull(2) ? "-" : resultado.GetString(2);
                        string domicilio = resultado.IsDBNull(3) ? "-" : resultado.GetString(3);
                        string previ = resultado.IsDBNull(4) ? "-" : resultado.GetString(4);
                        string fecha = resultado.IsDBNull(5) ? "-" : resultado.GetDate(5).ToString();
                        string fono = resultado.IsDBNull(6) ? "-" : resultado.GetString(6);
                        string dpto = resultado.IsDBNull(7) ? "-" : resultado.GetString(7);
                        Supervisor user = new Supervisor(rut, nombre, sexo, domicilio, previ, fecha, fono,dpto);
                        lista.Add(user);
                    }

            }

            Debug.WriteLine("lista: " + lista.Count);
            return lista;
        }

        public List<Usuario> getCajeros() {
            List<Usuario> lista = new List<Usuario>();
            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                string consulta = "Select * FROM empleado INNER JOIN cajero on empleado.rut = cajero.ref_empleado WHERE empleado.eliminado = 1;";

                // Retrieve all rows
                using(var cmd = new NpgsqlCommand(consulta, conn))
                using(var resultado = cmd.ExecuteReader())
                    while(resultado.Read()) {
                        //Debug.WriteLine(resultado.GetValue(0));
                        string rut = resultado.IsDBNull(0) ? "-" : resultado.GetString(0);
                        string nombre = resultado.IsDBNull(1) ? "-" : resultado.GetString(1);
                        string sexo = resultado.IsDBNull(2) ? "-" : resultado.GetString(2);
                        string domicilio = resultado.IsDBNull(3) ? "-" : resultado.GetString(3);
                        string previ = resultado.IsDBNull(4) ? "-" : resultado.GetString(4);
                        string fecha = resultado.IsDBNull(5) ? "-" : resultado.GetDate(5).ToString();
                        string fono = resultado.IsDBNull(6) ? "-" : resultado.GetString(6);
                        Usuario user = new Usuario(rut, nombre, sexo, domicilio, previ, fecha, fono);
                        lista.Add(user);
                    }

            }
            return lista;
        }

        public void AgregarUsuario(string rut,string nombre,string sexo, string domicilio,string prevision,string fecha,string num, string refdepa) {
            
            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                using(var cmd = new NpgsqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO empleado(rut, nombre, sexo, domicilio, prevision_salud, fecha_nacimiento, numero_telefono, ref_departamento)VALUES('"+rut+"','"+nombre+"','"+sexo+"', '"+domicilio+"', '"+prevision + "', '"+fecha+ "' , '" + num+"', '"+refdepa+"'); ";
                    Debug.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
            }

            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                using(var cmd = new NpgsqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO cajero(ref_empleado)VALUES('"+rut+"'); ";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarUsuario(string rut, string nombre, string sexo, string domicilio, string prevision, string fecha, string num, string refdepa) {
            //rut, nombre, sexo, domicilio, prevision_salud, fecha_nacimiento, numero_telefono, ref_departamento
            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                using(var cmd = new NpgsqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE empleado SET nombre='"+nombre+"' ,sexo = '"+sexo+ "',domicilio='"+domicilio+ "',prevision_salud='"+prevision+ "',fecha_nacimiento='"+fecha+ "',numero_telefono='"+num+ "',ref_departamento='"+ refdepa + "'  WHERE rut = '" + rut + "';";
                    Debug.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
            }

          
        }

        public void EliminarUsuario(string rut) {
            //rut, nombre, sexo, domicilio, prevision_salud, fecha_nacimiento, numero_telefono, ref_departamento
            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                using(var cmd = new NpgsqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE empleado SET eliminado = 0  WHERE rut = '" + rut + "';";
                    Debug.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
            }


        }


        public Usuario getUsuarioPorRut(string r) {
            Usuario usuario = null;
            using(var conn = new NpgsqlConnection(ConectorBaseDeDatos.path)) {
                conn.Open();
                string consulta = "SELECT * FROM public.empleado WHERE rut = '"+r+ "' AND empleado.eliminado = 1;";

                // Retrieve all rows
                using(var cmd = new NpgsqlCommand(consulta, conn))
                using(var resultado = cmd.ExecuteReader())
                    while(resultado.Read()) {
                        //Debug.WriteLine(resultado.GetValue(0));
                        string rut = resultado.IsDBNull(0) ? "-" : resultado.GetString(0);
                        string nombre = resultado.IsDBNull(1) ? "-" : resultado.GetString(1);
                        string sexo = resultado.IsDBNull(2) ? "-" : resultado.GetString(2);
                        string domicilio = resultado.IsDBNull(3) ? "-" : resultado.GetString(3);
                        string previ = resultado.IsDBNull(4) ? "-" : resultado.GetString(4);
                        string fecha = resultado.IsDBNull(5) ? "-" : resultado.GetDate(5).ToString();
                        string fono = resultado.IsDBNull(6) ? "-" : resultado.GetString(6);
                        string depa = resultado.IsDBNull(7) ? "-" : resultado.GetString(7);
                        usuario = new Usuario(rut, nombre, sexo, domicilio, previ, fecha, fono);
                        usuario.departamento = depa;
                    }

            }

            return usuario;
        }
    }
}
