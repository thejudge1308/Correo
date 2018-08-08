using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Correos.Models
{
    public class ConectorBaseDeDatos
    {
        public static string path = "Host=localhost;Username=postgres;Password=postgres;Database=correo";
        NpgsqlConnection conn = new NpgsqlConnection();

        public ConectorBaseDeDatos() {
            this.conn.ConnectionString = path;
            conn.Open();
        }

        public NpgsqlDataReader RealizarConsulta(string query) {
         
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                return dr;
            
            
        }

        public void CerrarConexion() {
            this.conn.Close();
        }
    }
}
